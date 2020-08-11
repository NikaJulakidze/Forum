using Forum.Models.NewFolder;
using Forum.Service.Identity;
using Forum.Service.Models;
using Forum.Service.Services.MailService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Jobs.Jobs
{
    public class Top15ThisWeekJob : IJob
    {
        private readonly ILogger<Top15ThisWeekJob> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Top15ThisWeekJob(ILogger<Top15ThisWeekJob> logger,IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            using var scope = _serviceProvider.CreateScope();
            var accountService = scope.ServiceProvider.GetRequiredService<IAccountService>();
            await accountService.GiftTop15Users();
        }
    }
}
