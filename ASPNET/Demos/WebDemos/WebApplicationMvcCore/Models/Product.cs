using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMvcCore.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
