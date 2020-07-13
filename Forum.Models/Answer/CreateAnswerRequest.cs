using Forum.Models.ApplicationUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Models.Answer
{
    public class CreateAnswerRequest
    {
        public string Content { get; set; }
        public int QuestionId { get; set; }
    }
}
