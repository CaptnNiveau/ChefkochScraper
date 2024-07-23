using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper
{
    public class IngredientGroupDbModel : IngredientGroupBaseModel
    {
        public List<IngredientUsedDbModel> ingredients { get; set; } = new List<IngredientUsedDbModel>();
    }
}