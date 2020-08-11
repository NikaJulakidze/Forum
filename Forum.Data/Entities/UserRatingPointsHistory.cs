using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class UserRatingPointsHistory
    {
        public int Id { get; set; }
        [Required]
        public int RatingPoints { get; set; }
        [Required]
        public DateTime AddedTime { get; set; } = DateTime.Now;


        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
