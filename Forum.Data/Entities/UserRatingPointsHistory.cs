using System;

namespace Forum.Data.Entities
{
    public class UserRatingPointsHistory
    {
        public int Id { get; set; }
        public int RatingPoints { get; set; }
        public DateTime AddedTime { get; set; } = DateTime.Now;

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
