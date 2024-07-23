namespace ChefkochScraper
{
    public class CommentModel : EntityBase
    {
        public string id { get; set; }
        public UserModel? owner { get; set; }
        public DateTime? createdAt { get; set; }
        public string? text { get; set; }
        public bool? helpful { get; set; }
        public int? helpfulCount { get; set; }
        public object? parentId { get; set; }
        public object? children { get; set; }
    }
}