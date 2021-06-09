using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Models
{
    public class Publisher
    {
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(32)]
        public string Name { get; set; }

        public ICollection<Magazine> Magazines { get; set; }
    }
}
