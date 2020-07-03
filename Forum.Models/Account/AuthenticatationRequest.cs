using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models.Account
{
    public class AuthenticatationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
