using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class Vote
    {
        public int Id { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public int BountyAmount { get; set; }

        public string UserId { get; set; }
        public int VoteTypeId { get; set; }
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
        public virtual VoteType VoteType { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
