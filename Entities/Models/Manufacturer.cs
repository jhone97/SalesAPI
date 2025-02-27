
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Manufacturer
    {


        public int Id { get; set; }
        public string ManufacturerName { get; set; }
        [JsonIgnore]
        public List<Item> Items { get; set; }




    }
}
