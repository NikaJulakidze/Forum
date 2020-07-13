using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models.Question
{
    public class AddQuestionRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public List<string> Tags { get; set; }
    }
}
