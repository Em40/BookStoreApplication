using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(32)]
        public string Name { get; set; }

        public ICollection<Notebook> Notebooks { get; set; }

        public ICollection<OfficeSupply> OfficeSupplies { get; set; }
    }
}
