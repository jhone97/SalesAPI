
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        public List<Item> Inventory { get; set; } = new List<Item>();
        
    }
}
