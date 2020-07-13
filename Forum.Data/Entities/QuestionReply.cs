using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class QuestionReply
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public int QuestionId { get; set; }


        public virtual Question Question { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
