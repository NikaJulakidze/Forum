using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Service.Models
{
    public class AppSettings
    {
        public MailSendSettings MailSendSettings{ get; set; }
        public JwtSettings JwtSettings { get; set; }
    }
}
