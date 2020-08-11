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
        [Required]
        public DateTime RegisterTime { get; set; } = DateTime.Now;
        [Required]
        public int Credits { get; set; }
        public string AboutMe { get; set; }
        public string WebSiteUrl { get; set; }
        [Required]
        public int ProfileViewCount { get; set; }
        public string Location { get; set; }
        [Required]
        public int UpVotesCount { get; set; }
        [Required]
        public int DownVotesCount { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UserRatingPointsHistory> RatingPointsHistory { get; set; }

    }
}
