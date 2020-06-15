using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Entities
{
    public class TagQuestion
    {
        public int TagId { get; set; }
        public int QuestionId { get; set; }

        public Tag Tag { get; set; }
        public Question Question { get; set; }
    }
}
