using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public decimal Price { get; set; } 
    }
}
