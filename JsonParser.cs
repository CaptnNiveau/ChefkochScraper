using System.Text.Json;
using System.Threading.Tasks;

namespace ChefkochScraper
{
    public class JsonParser
    {
        //not sure if we need an async implementation of this
        public static async Task<RecipeModel> ReadJsonAsync(Stream inputJson)
        {
            RecipeModel recipe = new RecipeModel();

            try
            {
                RecipeModel? deserializedRecipe = await JsonSerializer.DeserializeAsync<RecipeModel>(inputJson);
                if (deserializedRecipe != null)
                    recipe = deserializedRecipe;
            }
            catch (Exception)
            {
                Console.WriteLine("Input JSON is not valid");
            }

            return recipe;
        }

        public static RecipeModel ReadJson(string inputJson)
        {
            RecipeModel recipe = new RecipeModel();

            try
            {
                RecipeModel? deserializedRecipe = JsonSerializer.Deserialize<RecipeModel>(inputJson);
                if (deserializedRecipe != null)
                    recipe = deserializedRecipe;
            }
            catch (Exception e)
            {
                Console.WriteLine("Input JSON is not valid");
                Console.WriteLine(e);
            }

            return recipe;
        }
    }
}