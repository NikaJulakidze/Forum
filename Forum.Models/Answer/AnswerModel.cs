using Forum.Models.ApplicationUser;
using System;
using System.Collections.Generic;

namespace Forum.Models.Answer
{
    public class AnswerModel
    {
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RatingPoints { get; set; }

        public ApplicationUserModel ApplicationUser { get; set; }

    }
}
