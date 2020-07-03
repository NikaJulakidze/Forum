using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models.Question
{
    public class AddQuestionModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
    }
}
