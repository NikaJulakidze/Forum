using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Service.Dto.PostReply
{
    public class PostReplyDto
    {
        public int Id { get; set; }
        public string Content { get; set; }


        public int PostId { get; set; }
    }
}
