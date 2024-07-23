using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper
{
    public class IngredientGroup : EntityBase
    {
        public string? header { get; set; }
        public List<Ingredient> ingredients { get; set; }
    }
}