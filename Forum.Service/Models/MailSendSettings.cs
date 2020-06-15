using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Service.Models
{
    public class MailSendSettings
    {
        public string FromAddress { get; set; }
        public string FromPassword { get; set; }
        public string EmailConfirmationText { get; set; }
        public string PasswordConfirmationText { get; set; }
        public string FromName { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string EmailConfirmationSubject { get; set; }
        public string PasswordConfirmationSubject { get; set; }
    }
}
