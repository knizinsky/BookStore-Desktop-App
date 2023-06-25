using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp
{
    public class Categories
    {
        [Key]
        public int categoriesId { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public ICollection<Book> Book { get; set; }

        public Categories()
        {
            name = string.Empty;
            description = string.Empty;
            Book = new List<Book>();
        }
    }
}
