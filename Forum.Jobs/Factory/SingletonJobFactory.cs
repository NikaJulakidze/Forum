using Quartz;
using Quartz.Spi;
using System;

namespace Forum.Jobs.Factory
{
    public class SingletonJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SingletonJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return (IJob)_serviceProvider.GetService(bundle.JobDetail.JobType);
        }

        public void ReturnJob(IJob job) { }
    }
}
