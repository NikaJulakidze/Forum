using Forum.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class PostType
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public PostTypeEnum PostTypeName { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
