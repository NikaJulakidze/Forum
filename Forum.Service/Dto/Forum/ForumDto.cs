using Forum.Service.Dto.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Service.Dto.Forum
{
    public class ForumDto
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public ICollection<PostDto> Posts { get; set; }
    }
}
