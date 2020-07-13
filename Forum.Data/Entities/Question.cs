using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public int RatingPoints { get; set; }
        [Required]
        public int ViewCount { get; set; }
        [Required]
        public bool IsEdited { get; set; }
        public string UserId { get; set; }


        public ApplicationUser User { get; set; }   
        public ICollection<Answer> Answers { get; set; }
        public ICollection<TagQuestion> TagQuestions { get; set; }
    }
}
