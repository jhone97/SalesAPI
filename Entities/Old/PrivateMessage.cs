using System.ComponentModel.DataAnnotations;


namespace Entities.Old
{
    public class PrivateMessage
    {
        /// <summary>
        /// sender
        /// </summary>

        [Required]
        public Client From { get; set; }

        /// <summary>
        /// SignalRConnectionId
        /// </summary>

        [Required]
        public Client To { get; set; }

        /// <summary>
        /// message content
        /// </summary>

        [Required]
        public string Content { get; set; }

        /// <summary>
        /// auto generated time
        /// </summary>
        public DateTime SentAt { get; set; } = DateTime.Now;


    }
}
