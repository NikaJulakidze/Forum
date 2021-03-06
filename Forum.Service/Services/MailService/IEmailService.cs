﻿using Forum.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Services.MailService
{
    public interface IEmailService
    {
        Task SendBirthDayGiftMail(EmailSendModel model);
        Task SendMail(EmailSendModel model);
    }
}
