using System.ComponentModel.DataAnnotations.Schema;

namespace ChefkochScraper
{
    public class Ingredient : EntityBase
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? unit { get; set; }
        public string? unitId { get; set; }
        public double? amount { get; set; }
        public bool? isBasic { get; set; }
        public string? usageInfo { get; set; }
        public string? url { get; set; }
        public string? foodId { get; set; }
        public string? productGroup { get; set; }
        public string? blsKey { get; set; }
        public string? previewImageUrlTemplate { get; set; }
        [NotMapped]
        public object sponsoring { get; set; }
    }
}