using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string JobDescription { get; set; }
        public string JobType { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public string UserId { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }


        public ApplicationUser User { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;


    }
}
