using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PostTypeId { get; set; }
        //If Post is Answer
        public int? ParrentId { get; set; }
        //If Post is Question
        public int? AcceptedAnswerId { get; set; }
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } 
        public DateTime LastActivityDate { get; set; }
        //public DateTime? ClosedDate { get; set; }
        [Required]
        public int RatingPoints { get; set; }
        public int AnswersCount { get; set; }
        public int ViewCount { get; set; }
        [Required]
        public string OwnerDisplayName { get; set; }


        public  Post AcceptedAnswer { get; set; }
        public  Post Parent { get; set; }
        public virtual ICollection<Post> Answers { get; set; }
        public virtual PostType PostType { get; set; }
        public virtual ApplicationUser User { get; set; }   
        public virtual ICollection<TagPost> TagPosts { get; set; }
    }
}
