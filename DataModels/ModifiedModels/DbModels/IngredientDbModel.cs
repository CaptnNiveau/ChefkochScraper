namespace ChefkochScraper;

public class IngredientDbModel : EntityBase{
    public string id { get; set; }
    public string? name { get; set; }
    public bool? isBasic { get; set; }
    public string? url { get; set; }
    public string? foodId { get; set; }
    public string? productGroup { get; set; }
    public string? blsKey { get; set; }
}