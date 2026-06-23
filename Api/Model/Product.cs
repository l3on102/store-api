using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string SpecialTag { get; set; }
        public string Category { get; set; }
        [Range(1, 1000)]
        public double Price { get; set; }
        public string Image { get; set; }
    }
}