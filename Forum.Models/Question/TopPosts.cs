using Forum.Models.Enums;
using System;

namespace Forum.Models.Question
{
    public class TopPosts
    {
        public string QuestionTitle { get; set; }
        public int RatingPoints { get; set; }
        public DateTime PostCreatedTime { get; set; }

        public int PostTypeId { get; set; }
    }
}
