namespace Forum.Models.AppSettings
{
    public class MailSendSettings
    {
        public string FromAddress { get; set; }
        public string FromPassword { get; set; }
        public string EmailConfirmationText { get; set; }
        public string RessetPasswordText { get; set; }
        public string FromName { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string EmailConfirmationSubject { get; set; }
        public string RessetPasswordSubject { get; set; }
    }
}
