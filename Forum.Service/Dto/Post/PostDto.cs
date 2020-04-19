using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Service.Dto.Post
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int? ForumId { get; set; }
    }
}
