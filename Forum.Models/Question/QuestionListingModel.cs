using System;
using System.Collections.Generic;

namespace Forum.Models.Question
{
    public class QuestionListingModel
    {
        public int Id { get; set; }
        public int AnswersCount { get; set; }
        public int ViewsCount { get; set; }
        public string Title { get; set; }
        public DateTime AskedTime { get; set; }
        public List<string> Tags { get; set; }
        public string OwnerName { get; set; }
    }
}
