using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Service.Dto
{
    public class CreateAnswerDto
    {
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
