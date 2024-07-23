using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper
{
    public class IngredientGroupJsonModel : IngredientGroupBaseModel
    {
        public List<IngredientJsonModel> ingredients { get; set; }

        public IngredientGroupDbModel convertToDbModel(){
            IngredientGroupDbModel dbModel = new IngredientGroupDbModel
            {
                header = this.header
            };

            foreach (var ingredient in ingredients){
                dbModel.ingredients.Add(ingredient.convertToDbModel());
            }

            return dbModel;
        }
    }
}