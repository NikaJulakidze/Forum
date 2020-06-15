using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Data.Entities
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ViewCount { get; set; }
        public bool IsEdited { get; set; }
        public string UserId { get; set; }


        public ApplicationUser User { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<TagQuestion> TagQuestions { get; set; }
    }
}
