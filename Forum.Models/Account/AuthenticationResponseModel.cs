using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models.Account
{
    public class AuthenticationResponseModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
