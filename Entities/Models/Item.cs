using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "item name is requierd")]
        public string Name { get; set; }

        [Required(ErrorMessage = "item code is requierd")]
        public string Code { get; set; }

        public ItemDetails? itemDetails { get; set; }
        
    }
}
