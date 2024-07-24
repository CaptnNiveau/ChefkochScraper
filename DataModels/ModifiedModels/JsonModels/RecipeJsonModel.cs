using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper
{
    public class RecipeJsonModel : RecipeBaseModel
    {
        public Rating? rating { get; set; }
        public Nutrition? nutrition { get; set; }
        public List<IngredientGroupJsonModel> ingredientGroups { get; set; }

        public RecipeDbModel ConvertToDbModel()
        {
            RecipeDbModel dbModel = new RecipeDbModel();

            var type = typeof(RecipeJsonModel);
            string[] ignoreProperties = ["rating", "nutrition", "ingredientGroups", "LocalId", "LocalCreatedAt", "LocalModifiedAt"];

            foreach (var sourceProperty in type.GetProperties())
            {
                if (!ignoreProperties.Contains(sourceProperty.Name))
                {
                    var targetProperty = type.GetProperty(sourceProperty.Name);
                    targetProperty.SetValue(dbModel, sourceProperty.GetValue(this, null), null);
                }
            }
            
            if (dbModel.rating != null)
            {
                dbModel.rating = this.rating.rating;
                dbModel.numVotes = this.rating.numVotes;
            }

            if (this.nutrition != null)
            {
                dbModel.fatContent = this.nutrition.fatContent;
                dbModel.proteinContent = this.nutrition.proteinContent;
                dbModel.carbohydrateContent = this.nutrition.carbohydrateContent;
            }

            return dbModel;
        }
    }
}