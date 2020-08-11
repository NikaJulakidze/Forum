using System.ComponentModel.DataAnnotations;

namespace Forum.Models.PostType
{
    public class CreatePostTypeRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
