using Forum.Data.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class Forum:EntityCommon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        
        
        public string UserId { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
