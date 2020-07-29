namespace Forum.Models.AppSettings
{
    public class JwtSettings
    {
        public string Audiance { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public string Expires { get; set; }
    }
}
