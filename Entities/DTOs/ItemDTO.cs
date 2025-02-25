using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ItemDTO : Item
    {
        [Required(ErrorMessage = "item code can't be empty")]
        public string ItemCode { get; set; }
        [Required(ErrorMessage = "item decription can't be empty")]
        public string ItemDescription { get; set; }
        public int ManufacturerId { get; set; }
        [Required(ErrorMessage = "manufacturere details can't be empty")]
        public Manufacturer Manufacturer { get; set; }
    }
}
