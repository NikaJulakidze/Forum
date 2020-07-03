using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models.Account
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
