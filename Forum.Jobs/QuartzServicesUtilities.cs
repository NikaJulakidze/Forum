using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Jobs
{
    public class QuartzServicesUtilities
    {
        public static void StartJobs<TJob>() where TJob:IJob
        {
            IScheduler scheduler = new StdSchedulerFactory().GetScheduler().Result;


            var job = JobBuilder.Create<TJob>()
                .WithIdentity("BirthDay")
                .Build();

            var BirthDayTrigger = TriggerBuilder.Create()
                .WithIdentity("BirthdayTrigger")
                .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(1)).RepeatForever())
                .ForJob(job)
                .Build();

            var dictionary = new Dictionary<IJobDetail, IReadOnlyCollection<ITrigger>>()
            {
                { job,new HashSet<ITrigger>{ BirthDayTrigger} }
            };

            scheduler.ScheduleJob(job,BirthDayTrigger);
            scheduler.Start();
        }
    }
}
