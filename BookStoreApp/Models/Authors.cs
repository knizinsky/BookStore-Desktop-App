using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp
{
    /// <summary>
    /// Represents an author of a book.
    /// </summary>
    public class Authors
    {
        [Key]
        public int AuthorsId { get; set; }
        public string name { get; set; }

        public ICollection<Book> Book { get; set; }

        public Authors()
        {
            name = string.Empty;
            Book = new List<Book>();
        }
    }
}
