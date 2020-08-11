using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Data.Entities
{
    public class VoteType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
