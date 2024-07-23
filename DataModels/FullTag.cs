using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper
{
    [Keyless]
    public class FullRecipeTag
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}