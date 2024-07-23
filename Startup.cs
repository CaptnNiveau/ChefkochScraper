using System;
using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper{
    class Program{
        public static async Task Main(string[] args){
            CkApiRecipeRequest ckApi = new("821341186642853");
            string input = await ckApi.Request();

            RecipeDbModel test = JsonParser.ReadJson(input).ConvertToDbModel();

            ChefkochContext appDb = new ChefkochContext();
            appDb.Add(test);
            appDb.SaveChanges();

            var owner = appDb.Recipes
                .Include(r => r.owner)
                .First();

            Console.Write(owner.owner.username);
        }
    }
}
