using Forum.Models.Answer;
using Forum.Models.ApplicationUser;
using System;
using System.Collections.Generic;

namespace Forum.Models.Question
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RatingPoints { get; set; }
        public ApplicationUserListingModel QuestionAuthor { get; set; }


        public List<AnswerModel> Answers { get; set; }
        public List<string> Tags { get; set; }
    }
}
