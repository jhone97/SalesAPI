using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Item
    {

        public int Id { get; set; }
        public string? ItemName { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemDescription { get; set; }
        public float Price { get; set; }
        [JsonIgnore]
        public Manufacturer Manufacturer { get; set; }

    }
}
