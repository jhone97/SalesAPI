using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class PublicMessage
    {
        [Required]
        public Client Sender { get; set; }
        [Required]
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Content { get; set; }

    }
}
