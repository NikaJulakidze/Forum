using Forum.Models.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models.Account
{
    public class UserProfileModel
    {
        public string Username { get; set; }
        public int AnswersCount { get; set; }
        public int QuestionsCount { get; set; }
        public string ImageUrl { get; set; }
        public int RatingPoints { get; set; }
        public DateTime RegisterTime { get; set; }
        public string AboutMe { get; set; }
        public int ProfileViewCount { get; set; }
        public int PeopleReached { get; set; }


        public List<ApplicationUserTopPosts> TopPosts { get; set; }
    }
}
