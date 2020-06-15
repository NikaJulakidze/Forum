using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Service.Dto.Account
{
    public class UserRegistrationRequestDto
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Name ="Display name")]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
