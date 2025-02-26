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
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Manufacturer? Manufacturer { get; set; }

        // Foreign Key for Stock
        public int? StockId { get; set; }
        public Stock? Stock { get; set; } = null!;


    }
}
