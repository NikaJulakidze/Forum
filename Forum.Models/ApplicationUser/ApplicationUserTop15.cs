using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models.ApplicationUser
{
    public class ApplicationUserTop15
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int RatingPoints { get; set; }
        public int RatingPointsSum { get; set; }
        public string ImageUrl { get; set; }
    }
}
