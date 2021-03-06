﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMvcCore.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Brand { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
