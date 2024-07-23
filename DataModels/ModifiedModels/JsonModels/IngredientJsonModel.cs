using System.ComponentModel.DataAnnotations.Schema;

namespace ChefkochScraper;

public class IngredientJsonModel{
    public string id { get; set; }
    public string? name { get; set; }
    public bool? isBasic { get; set; }
    public string? url { get; set; }
    public string? foodId { get; set; }
    public string? productGroup { get; set; }
    public string? blsKey { get; set; }
    public string? unit { get; set; }
    public string? unitId { get; set; }
    public double? amount { get; set; }
    public string? usageInfo { get; set; }
    public string? previewImageUrlTemplate { get; set; }

    public IngredientUsedDbModel convertToDbModel(){
        return new IngredientUsedDbModel
        {
            unit = this.unit,
            unitId = this.unitId,
            amount = this.amount,
            usageInfo = this.usageInfo,
            previewImageUrlTemplate = this.previewImageUrlTemplate,
            ingredient = new IngredientDbModel
            {
                id = this.id,
                name = this.name,
                isBasic = this.isBasic,
                url = this.url,
                foodId = this.foodId,
                productGroup = this.productGroup,
                blsKey = this.blsKey,
            }
        };
    }
}