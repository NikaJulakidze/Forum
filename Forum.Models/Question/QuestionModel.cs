using Forum.Models.Answer;
using Forum.Models.ApplicationUser;
using System;
using System.Collections.Generic;

namespace Forum.Models.Question
{
    public class QuestionModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public DateTime AskedTime { get; set; }
        public int RatingPoints { get; set; }
        public ApplicationUserModel QuestionAuthor { get; set; }


        public List<AnswerModel> Answers { get; set; }
        public List<string> Tags { get; set; }
    }
}
