using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Entities
{
    public class AuthenticationRequest
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
