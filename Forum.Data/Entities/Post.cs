using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime LastActivityDate { get; set; } = DateTime.Now;
        [Required]
        public int RatingPoints { get; set; }
        [Required]
        public int AnswersCount { get; set; }
        [Required]
        public int ViewCount { get; set; }
        [Required]
        public string OwnerDisplayName { get; set; }


        public  Post AcceptedAnswer { get; set; }
        public  Post Parent { get; set; }
        public virtual PostType PostType { get; set; }
        public virtual ApplicationUser User { get; set; }   
        public virtual ICollection<TagPost> TagPosts { get; set; }
    }
}
