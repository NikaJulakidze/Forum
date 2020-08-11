using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Entities
{
    public class TagPost
    {
        public int TagId { get; set; }
        public int PostId { get; set; }

        public Tag Tag { get; set; }
        public Post Post { get; set; }
    }
}
