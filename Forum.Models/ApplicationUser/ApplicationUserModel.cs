using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models.ApplicationUser
{
    public class ApplicationUserModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int RatingPoints { get; set; }
    }
}
