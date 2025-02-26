

using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Manufacturer
    {


        public int Id { get; set; }
        public string? ManufacturerName { get; set; }

        public ICollection<Item>? Items { get; }



    }
}
