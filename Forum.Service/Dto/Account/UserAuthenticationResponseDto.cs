using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Service.Dto.Account
{
    public class UserAuthenticationResponseDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
