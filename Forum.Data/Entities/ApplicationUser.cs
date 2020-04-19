using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public virtual ICollection<Forum> Forums { get; set; }
        public virtual ICollection<PostReply> PostReplies { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
