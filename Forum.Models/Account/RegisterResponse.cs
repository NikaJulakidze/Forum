using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models.Account
{
    public class RegisterResponse
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
