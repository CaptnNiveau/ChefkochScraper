using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper
{
    [Index(nameof(id), IsUnique = true)]
    public class FullTagModel: EntityBase
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}