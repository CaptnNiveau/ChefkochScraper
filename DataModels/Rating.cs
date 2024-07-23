using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper
{
    public class Rating : EntityBase
    {
        public double? rating { get; set; }
        public int? numVotes { get; set; }
    }
}