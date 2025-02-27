using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Company Company { get; set; }
        [JsonIgnore]
        public List<Item> Items { get; set; }
    }
}
