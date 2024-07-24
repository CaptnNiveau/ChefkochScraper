using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper
{
    class FastBot
    {
        private static List<string> scrapedUserIds;
        private static List<string> unscrapedUserIds;
        private static List<string> scrapedRecipeIds;
        private static List<string> unscrapedRecipeIds;
        private static ChefkochContext appDb;

        //set a higher number on systems with a better CPU / internet connection
        private static int parralelUserSearches = 512;
        bool scrapeRecipes;

        public async Task Startup()
        {
            appDb = new ChefkochContext();
            unscrapedUserIds = GetScrapedUserIds();
            unscrapedRecipeIds = GetScrapedRecipeIds();

            Console.WriteLine("Found " + unscrapedUserIds.Count + " users in existing database");
            Console.WriteLine("Found " + unscrapedRecipeIds.Count + " recipes in existing database");

            //CkApiRecipeRequest ckApi = new("592547d097443354dd8cc30086b470cc");
            //string input = await ckApi.Request();

            //RecipeDbModel test = JsonParser.ReadJson(input).ConvertToDbModel();

            await AddNullRecipes();
            scrapeRecipes = true;
            scrapedUserIds = new();
            scrapedRecipeIds = new();
            await CreateScraperTasks();
        }
        private async Task CreateScraperTasks()
        {
            while (scrapeRecipes)
            {
                Stopwatch fastSw = new();
                fastSw.Start();
                Console.WriteLine("scraped users: " + scrapedUserIds.Count + " | " + unscrapedUserIds.Count + " unscraped");
                List<Task<RecipeDbModel?[]>> getUserRecipes = new();
                for (int i = parralelUserSearches; i > 0; i--)
                {
                    string id;
                    if (unscrapedUserIds.Count > i)
                    {
                        id = unscrapedUserIds[i];
                        getUserRecipes.Add(GetRecipesFromUser(id));
                    }
                }

                RecipeDbModel?[][] newRecipes = await Task.WhenAll(getUserRecipes);
                RecipeDbModel?[] recipeDbModels = newRecipes.SelectMany(array => array).ToArray();

                foreach (RecipeDbModel? recipe in recipeDbModels)
                {
                    if (recipe != null && recipe.id != null)
                        appDb.Add(recipe);
                }
                appDb.SaveChanges();

                Console.WriteLine("scraped recipes: " + scrapedRecipeIds.Count + " (+ " + recipeDbModels.Count() + ") | "
                 + ((float)recipeDbModels.Count() / fastSw.ElapsedMilliseconds * 1000).ToString("F2") + " /s");
                fastSw.Stop();
            }
        }

        private async Task<RecipeDbModel?[]> GetRecipesFromUser(string userId)
        {
            CkApiUserRequest ckApi = new(userId);
            List<string> recipes = await ckApi.GetRecipeIds();
            List<Task<RecipeDbModel?>> RecipeModelsToAdd = new();
            if (recipes.Count > 0)
            {
                foreach (string id in recipes)
                {
                    if (scrapedRecipeIds != null && !scrapedRecipeIds.Contains(id) && !unscrapedRecipeIds.Contains(id))
                    {
                        RecipeModelsToAdd.Add(GetRecipeModel(id));
                    }
                }
            }
            RecipeDbModel?[] recipeDbModels = await Task.WhenAll(RecipeModelsToAdd);

            unscrapedUserIds.Remove(userId);
            scrapedUserIds.Add(userId);
            return recipeDbModels;
        }

        private async Task<RecipeDbModel?> GetRecipeModel(string recipeId)
        {
            CkApiRecipeRequest ckApiRecipeRequest = new(recipeId);
            Task<string> getRecipeJson = ckApiRecipeRequest.Request();

            ckApiRecipeRequest.GetComments();
            string commentsJson = await ckApiRecipeRequest.Request();
            JsonParser jsonParser = new();
            CommentGroup? commentGroup = jsonParser.ReadJson<CommentGroup>(commentsJson);
            if (commentGroup != null && commentGroup.results != null && commentGroup.results.Count > 0)
            {
                foreach (CommentModel c in commentGroup.results)
                {
                    if (c != null && c.owner != null
                    && !scrapedUserIds.Contains(c.owner.id) && !unscrapedUserIds.Contains(c.owner.id))
                        unscrapedUserIds.Add(c.owner.id);
                }
            }

            string recipeJson = await getRecipeJson;
            RecipeJsonModel? recipeJsonModel = jsonParser.ReadJson<RecipeJsonModel>(recipeJson);
            RecipeDbModel? recipeDb = new();
            if (recipeJsonModel != null)
                recipeDb = recipeJsonModel.ConvertToDbModel();
            if (unscrapedRecipeIds.Contains(recipeId))
                unscrapedRecipeIds.Remove(recipeId);
            scrapedRecipeIds.Add(recipeId);

            return recipeDb;
        }

        private List<string> GetScrapedUserIds()
        {
            List<string> scrapedUserIds = new();
            DbSet<UserModel> userModels = appDb.Users;

            if (userModels != null)
                scrapedUserIds = userModels.Select(u => u.id).ToList();

            return scrapedUserIds;
        }

        private List<string> GetScrapedRecipeIds()
        {
            List<string> scrapedRecipeIds = new();
            DbSet<RecipeDbModel> recipeDbModels = appDb.Recipes;

            if (recipeDbModels != null)
                scrapedRecipeIds = recipeDbModels.Select(r => r.id).ToList();

            return scrapedRecipeIds;
        }

        private async Task AddNullRecipes()
        {
            var nullRecipes = appDb.Recipes
                .Include(r => r.owner)
                .Where(r => r.title == null);

            if (nullRecipes.Count() != 0)
            {
                List<Task> requestNullRecipes = new List<Task>();

                //ScrapeRecipes
                foreach (var v in nullRecipes)
                {
                    await GetRecipeModel(v.id);
                    //requestNullRecipes.Add(AddRecipeModel(v.id));
                }
                //await Task.WhenAll(requestNullRecipes);
            }

            Console.WriteLine("Added " + nullRecipes.Count().ToString() + " null recipes");
        }
    }
}