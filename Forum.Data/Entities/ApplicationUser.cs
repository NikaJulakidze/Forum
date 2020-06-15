using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public int RatingPoints { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
