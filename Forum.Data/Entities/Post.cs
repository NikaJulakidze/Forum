using Forum.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class Post
    {
        private DateTime _createdDate=DateTime.Now;

        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate
        {
            get { return DateTime.Now; }
            set { _createdDate = value; }
        }

        public int? ForumId { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual IEnumerable<PostReply> PostReplies { get; set; }
        public virtual Forum Forum { get; set; }
    }
}
