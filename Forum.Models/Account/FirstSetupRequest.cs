using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models.Account
{
    public class FirstSetupRequest
    {
        public string ImageUrl { get; set; }
        public string Location { get; set; }
        public string JobTitle { get; set; }
        public string AboutMe { get; set; }
    }
}
