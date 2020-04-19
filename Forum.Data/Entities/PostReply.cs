using Forum.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Data.Entities
{
    public class PostReply:EntityCommon
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }
        public int? PostId { get; set; }
        public virtual Post Post { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
