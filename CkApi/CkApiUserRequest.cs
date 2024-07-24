using System.Text.RegularExpressions;

namespace ChefkochScraper;

/// <summary>
/// Klasse für Nutzer-Anfragen.
/// </summary>
public class CkApiUserRequest : CkApiRequestBase
{
    public CkApiUserRequest(string? id)
    {
        this.ApiUrl += "/users";
        this.Id = id;
    }

    public CkApiUserRequest GetProfile()
    {
        this.Subpage = "/profile";
        return this;
    }

    public async Task<List<string>> GetRecipeIds()
    {
        ////TODO: auf ausführlichere seite https://www.chefkoch.de/user/rezepte/s1/{id}/friaufeck.html ummünzen
        var result = new List<string>();
        try
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync($"https://www.chefkoch.de/user/profil/{this.Id}");
            var responseBody = await response.Content.ReadAsStringAsync();

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(responseBody);

            if (htmlDoc.DocumentNode != null)
            {
                HtmlAgilityPack.HtmlNode bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body");

                var regex = new Regex(@"https:\/\/www\.chefkoch\.de\/rezepte\/(\d+)");
                var recipeCards = htmlDoc.DocumentNode.Descendants(0)
                    .Where(n => n.HasClass("ds-recipe-card"));

                foreach (var card in recipeCards)
                {
                    var recipeId = regex.Match(card.InnerHtml).Groups[1];
                    result.Add(recipeId.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("CAN'T fetch URL: " + $"https://www.chefkoch.de/user/profil/{this.Id}");
        }


        return result;
    }
}