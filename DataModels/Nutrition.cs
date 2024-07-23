using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper
{
    public class Nutrition : EntityBase
    {
        public int? kCalories { get; set; }
        public double? carbohydrateContent { get; set; }
        public double? proteinContent { get; set; }
        public double? fatContent { get; set; }
    }
}