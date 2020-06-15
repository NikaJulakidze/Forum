using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public int RatingPoints { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<Tag> Forums { get; set; }
    }
}
