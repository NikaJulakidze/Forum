using Forum.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Data.Entities
{
    public class QuestionReply
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public DateTime CreatedDate { get; set; }


        public virtual Question Answer { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
