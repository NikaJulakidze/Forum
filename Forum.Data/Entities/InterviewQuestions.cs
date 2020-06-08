using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Entities
{
    public class InterviewQuestions
    {
        public int Id { get; set; }
        public int ForumId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }


        public Forum Forum { get; set; }
    }
}
