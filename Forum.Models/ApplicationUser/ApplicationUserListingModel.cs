namespace Forum.Models.ApplicationUser
{
    public class ApplicationUserListingModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int RatingPoints { get; set; }
        public string ImageUrl { get; set; }
    }
}
