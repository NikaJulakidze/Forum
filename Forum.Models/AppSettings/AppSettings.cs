using Forum.Models.AppSettings;

namespace Forum.Models.NewFolder
{
    public class AppSettings
    {
        public MailSendSettings MailSendSettings { get; set; }
        public JwtSettings JwtSettings { get; set; }
        public PagingSettings PagingSettings { get; set; }
    }
}
