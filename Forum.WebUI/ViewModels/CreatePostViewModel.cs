using System.ComponentModel.DataAnnotations;

namespace Forum.WebUI.ViewModels
{
    public class CreatePostViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
