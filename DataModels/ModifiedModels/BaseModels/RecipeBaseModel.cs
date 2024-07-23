using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper
{
    public abstract class RecipeBaseModel : EntityBase
    {
        public string id { get; set; }
        public int? type { get; set; }
        public string? title { get; set; }
        public string? subtitle { get; set; }
        public UserModel? owner { get; set; }
        public int? difficulty { get; set; }
        public bool? hasImage { get; set; }
        public bool? hasVideo { get; set; }
        public string? previewImageId { get; set; }
        public UserModel? previewImageOwner { get; set; }
        public int? preparationTime { get; set; }
        public bool? isSubmitted { get; set; }
        public bool? isRejected { get; set; }
        public string? createdAt { get; set; }
        public int? imageCount { get; set; }
        public UserModel? editor { get; set; }
        public string? submissionDate { get; set; }
        public bool? isPremium { get; set; }
        public int? status { get; set; }
        public string? slug { get; set; }
        public string? previewImageUrlTemplate { get; set; }
        public UserModel? previewImageCredits { get; set; }
        public bool? isPlus { get; set; }
        public string? additionalDescription { get; set; }
        [NotMapped]
        public object? source { get; set; }
        public int? servings { get; set; }
        public int? kCalories { get; set; }
        public string? instructions { get; set; }
        public string? miscellaneousText { get; set; }
        public string? ingredientsText { get; set; }
        public List<string> tags { get; set; }
        public List<FullTagModel> fullTags { get; set; }
        public int? viewCount { get; set; }
        public int? cookingTime { get; set; }
        public int? restingTime { get; set; }
        public int? totalTime { get; set; }
        public List<string> categoryIds { get; set; }
        public string? recipeVideoId { get; set; }
        public bool? isIndexable { get; set; }
        public string? affiliateContent { get; set; }
        public string? metaTitle { get; set; }
        public string? metaDescription { get; set; }
        public string? siteUrl { get; set; }
    }
}