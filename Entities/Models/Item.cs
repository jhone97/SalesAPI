﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "item code can't be empty")]
        public string ItemCode { get; set; }
        [Required(ErrorMessage = "item decription can't be empty")]
        public string ItemDescription { get; set; }
        public int ManufacturerId { get; set; }
        [Required(ErrorMessage = "manufacturere details can't be empty")]
        public Manufacturer Manufacturer { get; set; }


    }
}
