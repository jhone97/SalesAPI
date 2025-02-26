using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public List<Item>? Items { get; set; } = new(); // One-to-many relationship with Items

        // Foreign key for Company
        public int? CompanyId { get; set; }
        public Company? Company { get; set; } = null!;

    }
}
