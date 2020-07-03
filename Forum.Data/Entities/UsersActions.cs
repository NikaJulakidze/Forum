using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Entities
{
    public class UsersAction
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string IpAddress { get; set; }
        public string ActionType { get; set; }

        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
