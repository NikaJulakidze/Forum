using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Data.Entities
{
    public class AnswerReply
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public string UsedId { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        

        public virtual ApplicationUser User { get; set; }
    }
}
