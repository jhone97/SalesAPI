using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Item
    {
      

        public int Id { get; set; }

        public string? ItemName { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemDescription { get; set; }
       
        public Manufacturer? Manufacturer { get; set; }


    }
}
