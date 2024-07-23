using System.Text.Json;
using System.Threading.Tasks;

namespace ChefkochScraper
{
    public class JsonParser
    {
        //not sure if we need an async implementation of this
        public static async Task<RecipeJsonModel> ReadJsonAsync(Stream inputJson)
        {
            RecipeJsonModel recipe = new RecipeJsonModel();

            try
            {
                RecipeJsonModel? deserializedRecipe = await JsonSerializer.DeserializeAsync<RecipeJsonModel>(inputJson);
                if (deserializedRecipe != null)
                    recipe = deserializedRecipe;
            }
            catch (Exception)
            {
                Console.WriteLine("Input JSON is not valid");
            }

            return recipe;
        }

        public static RecipeJsonModel ReadJson(string inputJson)
        {
            RecipeJsonModel recipe = new RecipeJsonModel();

            try
            {
                RecipeJsonModel? deserializedRecipe = JsonSerializer.Deserialize<RecipeJsonModel>(inputJson);
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