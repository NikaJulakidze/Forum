using Forum.Models.PostType;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

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
