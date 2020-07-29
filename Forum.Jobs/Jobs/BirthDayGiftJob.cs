using Forum.Data;
using Forum.Data.Entities;
using Forum.Service.Identity;
using Forum.Service.JobServices;
using Forum.Service.Models;
using Forum.Service.Services.MailService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Forum.Jobs.Jobs
{
    [DisallowConcurrentExecution]
    public class BirthDayGiftJob : IJob
    {
        private readonly ILogger<BirthDayGiftJob> _logger;
        private readonly IServiceProvider _serviceProvider;

        public BirthDayGiftJob(ILogger<BirthDayGiftJob> logger,IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        public Task Execute(IJobExecutionContext context)
        { 
            using (var scope = _serviceProvider.CreateScope())
            {
                var accountService = scope.ServiceProvider.GetService<IAccountService>();
                var emailService = scope.ServiceProvider.GetService<IEmailService>();
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var users = dbContext.ApplicationUsers.ToList();
                users = users.Select(x => { x.Credits += 10;return x; }).ToList();
                foreach(var i in users)
                {
                    i.Credits += 10;
                }
                dbContext.UpdateRange(users);
                dbContext.SaveChanges();
                
                return Task.CompletedTask;
                
            }
        }
    }
}
