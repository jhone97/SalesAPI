﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Old
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string? SignalRConnectionId { get; set; }
        public bool IsConnected { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        [EmailAddress]
        [Required(ErrorMessage = "Email is requeried")]
        public string EmailAddress { get; set; } = string.Empty;


        public string CompanyName { get; set; } = string.Empty;

      

    }

}