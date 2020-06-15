using Forum.Service.Dto.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Service.Dto.Question
{
    public class CreateQuestionRequestDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public List<TagsDto> Tags { get; set; }
    }
}
