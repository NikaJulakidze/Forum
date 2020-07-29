using Forum.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Jobs.Jobs
{
    public class AnniversaryGiftJob : IJob
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<AnniversaryGiftJob> _logger;

        public AnniversaryGiftJob(IServiceProvider serviceProvider,ILogger<AnniversaryGiftJob> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var users = dbContext.ApplicationUsers.ToList();
            foreach (var i in users)
            {
                i.RatingPoints += 10;
            }
            dbContext.UpdateRange(users);
            dbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
