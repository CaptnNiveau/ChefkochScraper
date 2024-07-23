namespace ChefkochScraper;

/// <summary>
/// Klasse für Rezept-Anfragen.
/// </summary>
public class CkApiRecipeRequest: CkApiRequestBase{
    public CkApiRecipeRequest(string? id = null){
        this.ApiUrl += "/recipes";
        this.Id = id;
    }

    public CkApiRecipeRequest GetComments(){
        this.Subpage = "/comments";
        return this;
    }

    public CkApiRecipeRequest GetImages(){
        this.Subpage = "/images";
        return this;
    }
}