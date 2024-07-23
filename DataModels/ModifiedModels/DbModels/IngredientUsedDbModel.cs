using System.ComponentModel.DataAnnotations.Schema;

namespace ChefkochScraper;

public class IngredientUsedDbModel : EntityBase{
    public IngredientDbModel ingredient { get; set; }
    public string? unit { get; set; }
    public string? unitId { get; set; }
    public double? amount { get; set; }
    public string? usageInfo { get; set; }
    public string? previewImageUrlTemplate { get; set; }
}