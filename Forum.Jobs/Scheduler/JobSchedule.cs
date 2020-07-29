using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Jobs.Scheduler
{
    public class JobSchedule
    {
        public Type Type { get; set; }
        public string CronExpression { get; set; }

        public JobSchedule(Type jobType, string cronExpression=null)
        {
            this.Type = jobType;
            this.CronExpression = cronExpression;
        }
    }
}
