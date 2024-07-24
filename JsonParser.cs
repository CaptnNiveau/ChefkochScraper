using System.Text.Json;
using System.Threading.Tasks;

namespace ChefkochScraper
{
    public class JsonParser
    {

        public T? ReadJson<T>(string inputJson)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(inputJson);
            }
            catch
            {
                return default;
            }
        }

        public async Task<T?> ReadJsonAsync<T>(Stream inputJson)
        {
            var deserializedCommentGroup = await JsonSerializer.DeserializeAsync<T>(inputJson);

            return deserializedCommentGroup;
        }
    }
}
