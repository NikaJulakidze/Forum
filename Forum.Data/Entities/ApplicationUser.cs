using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public int RatingPoints { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public DateTime RegisterTime { get; set; } = DateTime.Now;
        public int Credits { get; set; }


        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<UserRatingPointsHistory> UserRatingPoints { get; set; }
    }
}
