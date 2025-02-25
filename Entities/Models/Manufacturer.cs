

using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
       
        [Required(ErrorMessage = "manufacturer name can't be empty")]

        public string ManufacturerName { get; set; }

        public ICollection<Item> Items { get; } = new List<Item>();
       


    }
}
