using System.ComponentModel.DataAnnotations;


namespace Entities.Old
{
    public class ItemOld
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityAvailable { get; set; }
        public double Price { get; set; }

    }
}
