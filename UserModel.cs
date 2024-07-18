namespace ChefkochScraper
{
    public class UserModel
    {
        public string id { get; set; }
        public string username { get; set; }
        public int rank { get; set; }
        public string role { get; set; }
        public bool hasAvatar { get; set; }
        public bool hasPaid { get; set; }
        public bool deleted { get; set; }
        public string avatarImageUrlTemplate { get; set; }
        public bool isVerified { get; set; }
        public string displayName { get; set; }
    }
}