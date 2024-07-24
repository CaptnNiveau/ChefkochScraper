using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            CkApiUserRequest ckApi = new("592547d097443354dd8cc30086b470cc");

            var test = await ckApi.GetRecipeIds();

            /*ChefkochContext appDb = new();

            var recipe = appDb.Recipes
                .Include(r => r.owner)
                .Where(r => r.title != null)
                .First();

            CkApiRecipeRequest ckApiRecipeRequest = new(recipe.id);
            string recipeJson = await ckApiRecipeRequest.Request();

            Console.WriteLine(JsonParser.ReadJson<RecipeJsonModel>(recipeJson).title);

            ckApiRecipeRequest.GetComments();
            string commentsJson = await ckApiRecipeRequest.Request();
            Console.WriteLine(commentsJson.Length);
            CommentGroup? cg = JsonParser.ReadJson<CommentGroup>(commentsJson);
            Console.WriteLine(cg.results[0].text);
*/

            Functions f = new();
            await f.testrun();
        }
    }
}
