using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyStorage.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Supplier { get; set; }
        [Required]
        [RegularExpression(@"-?\d+(?:\.\d+)?", ErrorMessage = "Price must be in numeric format")]
        public double Price { get; set; }
    }
}