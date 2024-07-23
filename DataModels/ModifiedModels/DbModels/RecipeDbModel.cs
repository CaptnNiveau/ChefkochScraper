using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper
{
    public class RecipeDbModel : RecipeBaseModel
    {
        public double? rating { get; set; }
        public int? numVotes { get; set; }
        public double? carbohydrateContent { get; set; }
        public double? proteinContent { get; set; }
        public double? fatContent { get; set; }
        public List<IngredientGroupDbModel> ingredientGroups { get; set; }
    }
}