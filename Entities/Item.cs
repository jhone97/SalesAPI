
using System.ComponentModel.DataAnnotations;


namespace Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityAvailable { get; set; }
        public double Price { get; set; }

    }
}
