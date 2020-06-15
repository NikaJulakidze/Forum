using Forum.Data.Entities;
using Forum.Service.StaticSettings;
using System.IO;

namespace Forum.Service.Models
{
    public class EmailSendModel
    {
        public string ConfirmationLink { get; set; }
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string Body { get; set; }
        public string ToUserName { get; set; }
        public string FromName { get; set; }
        public string FromPassword { get; set; }
        public string Subject { get; set; }

        
        public static EmailSendModel BuildEmailVerificationModel(ApplicationUser user,AppSettings _options) => new EmailSendModel()
        {
            Body = File.ReadAllText(_options.MailSendSettings.EmailConfirmationText),
            FromAddress = _options.MailSendSettings.FromAddress,
            FromName = _options.MailSendSettings.FromName,
            FromPassword = _options.MailSendSettings.FromPassword,
            Subject = _options.MailSendSettings.EmailConfirmationSubject,
            ToAddress = user.Email,
            ToUserName = user.UserName,
            ConfirmationLink = StaticRoutes.BaseUrl + $"Account/FirstSetup/{user.Id}",
        };

        public static EmailSendModel BuildPasswordRecoveryModel(ApplicationUser user, AppSettings _options) => new EmailSendModel();
    }
}
