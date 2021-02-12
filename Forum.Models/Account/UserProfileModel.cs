using Forum.Models.Answer;
using Forum.Models.ApplicationUser;
using Forum.Models.Enums;
using Forum.Models.Question;
using Forum.Models.Tag;
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
        public int PostCount { get; set; }
        public int PeopleReached { get; set; }
        public int ProfileViewCount { get; set; }
        public DateTime LastSeen { get; set; }
        public int TagCount { get; set; }
        public string ImageUrl { get; set; }
        public int RatingPoints { get; set; }
        public DateTime RegisterTime { get; set; }
        public string AboutMe { get; set; }

        public PostTypeEnum PostTypeEnum { get; set; }
        public List<UserTopTags> UserTopTags { get; set; }
        public List<TopPosts> TopPosts { get; set; }
    }
}
