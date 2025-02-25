using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("clients")]
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string SignalRConnectionId { get; set; } = string.Empty;
        public bool IsConnected { get; set; } = false;
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

      

    }

}