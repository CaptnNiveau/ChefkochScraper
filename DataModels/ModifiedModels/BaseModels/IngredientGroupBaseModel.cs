using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper
{
    public abstract class IngredientGroupBaseModel : EntityBase
    {
        public string? header { get; set; }
    }
}