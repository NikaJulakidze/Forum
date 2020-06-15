﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Service.Dto.Tags
{
    public class TagsDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
