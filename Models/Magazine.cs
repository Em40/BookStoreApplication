using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Models
{
    public class Magazine
    {
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(64)]
        public string Title { get; set; }

        [MinLength(2)]
        [MaxLength(32)]
        public string Type { get; set; }

        [Range(0, 1000)]
        public int NumberOfPages { get; set; }

        [Range(0.0, 100000)]
        public decimal Price { get; set; }
        [Min(0)]
        public int CountInStock { get; set; }

        [Required]
        public int PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}
