namespace ChefkochScraper
{
    public class CommentGroup
    {
        public int count { get; set; }
        public List<Comment> results { get; set; }
        public int maxAge { get; set; }
        public int sharedMaxAge { get; set; }
        public List<string> surrogateKeys { get; set; }
    }
}

