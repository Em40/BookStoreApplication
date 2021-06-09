using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Models
{
    public class OfficeSupply
    {
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(64)]
        public string Name { get; set; }

        [Range(0.0, 100000)]
        public decimal Price { get; set; }

        [Min(0)]
        public int CountInStock { get; set; }

        public Brand Brand { get; set; }
    }
}
