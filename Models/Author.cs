using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Models
{
    public class Author
    {
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(32)]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(32)]
        public string LastName { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
