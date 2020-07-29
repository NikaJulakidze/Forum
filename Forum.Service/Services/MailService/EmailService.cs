using Forum.Models.NewFolder;
using Forum.Service.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Services.MailService
{
    public class EmailService:IEmailService
    {
        private readonly AppSettings _options;
        public EmailService(IOptionsSnapshot<AppSettings> options)
        {
            _options = options.Value;
        }

        public async Task SendBirthDayGiftMail(EmailSendModel model)
        {
            try
            {
                var body = "GiftTest";

                var mailMessage = new MailMessage();

                //foreach(var i in model.ToManyAdresses)
                //{
                //    mailMessage.To.Add(i);
                //}
                mailMessage.To.Add(model.ToAddress);
                mailMessage.From = new MailAddress("julakidzenika30@gmail.com", "nika");
                mailMessage.Subject = "GiftTest";
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;

                var smtp = new SmtpClient()
                {
                    Host = _options.MailSendSettings.Host,
                    Port = Convert.ToInt32(_options.MailSendSettings.Port),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(model.FromAddress, model.FromPassword),
                };

                await smtp.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }

        }

        public async Task SendMail(EmailSendModel model)
        {
            try
            {
                var body = model.Body;
                body = body.Replace("ConfirmationLink", model.ConfirmationLink);
                body = body.Replace("userName", model.ToUserName);
                body = body.Replace("otpCode", model.Subject);

                var mailMessage = new MailMessage();

                mailMessage.To.Add(model.ToAddress);
                mailMessage.From = new MailAddress(model.FromAddress, model.FromName);
                mailMessage.Subject = model.Subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;

                var smtp = new SmtpClient()
                {
                    Host = _options.MailSendSettings.Host,
                    Port = Convert.ToInt32(_options.MailSendSettings.Port),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(model.FromAddress, model.FromPassword),
                };

                await smtp.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
        }
    }
}
