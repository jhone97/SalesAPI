using System.ComponentModel.DataAnnotations;


namespace Entities.Models
{
    public class ItemDetails
    {
        [Key]
        public int Id { get; set; }
        
        public string? Description { get; set; }

        public int ItemId { get; set; }


    }
}
