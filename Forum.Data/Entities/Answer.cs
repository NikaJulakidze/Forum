using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class Answer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public bool IsAcceptedAnswer { get; set; }
        [Required]
        public int RatingPoints { get; set; }
        public string UserId { get; set; }
        public int QuestionId { get; set; }


        public virtual Question Question { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<TagAnswer> TagAnswers { get; set; }
    }
}
