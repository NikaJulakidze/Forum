using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Service.Dto.Account
{
    public class UserRegistrationResponseDto
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
