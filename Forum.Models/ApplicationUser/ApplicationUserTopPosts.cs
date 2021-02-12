using Forum.Models.Answer;
using Forum.Models.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models.ApplicationUser
{
    public class ApplicationUserTopPosts
    {
        public List<AnswerModel> Answers { get; set; }
        public List<QuestionModel> Questions { get; set; }
    }
}
