using Forum.Data.Entities;
using Forum.Models.NewFolder;
using Forum.Service.StaticSettings;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
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
        public List<string> ToManyAdresses { get; set; }

        public static EmailSendModel BuildBirthDayGiftModel(List<ApplicationUser> users)
        {
            return null;
        }


        public static EmailSendModel BuildEmailVerificationModel(ApplicationUser user,AppSettings _options,string token) => new EmailSendModel()
        {
            Body = File.ReadAllText(_options.MailSendSettings.EmailConfirmationText),
            FromAddress = _options.MailSendSettings.FromAddress,
            FromName = _options.MailSendSettings.FromName,
            FromPassword = _options.MailSendSettings.FromPassword,
            Subject = _options.MailSendSettings.EmailConfirmationSubject,
            ToAddress = user.Email,
            ToUserName = user.UserName,
            ConfirmationLink = StaticRoutes.BaseUrl + $"Account/FirstSetup",
        };

        public static EmailSendModel BuildPasswordRecoveryModel(ApplicationUser user, AppSettings _options,string token) => new EmailSendModel()
        {
            Body=File.ReadAllText(_options.MailSendSettings.RessetPasswordText),
            FromAddress=_options.MailSendSettings.FromAddress,
            FromName=_options.MailSendSettings.FromName,
            FromPassword=_options.MailSendSettings.FromPassword,
            Subject=_options.MailSendSettings.RessetPasswordSubject,
            ToAddress=user.Email,
            ToUserName=user.UserName,
            ConfirmationLink=StaticRoutes.BaseUrl +$"Account/RessetPassword/{token}"
        };
    }
}
