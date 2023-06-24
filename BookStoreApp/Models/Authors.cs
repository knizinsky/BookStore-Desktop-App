using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp
{
    [Table("Authors1")]
    public class Authors
    {
        [Key]
        public int AuthorsId { get; set; }
        public string name { get; set; }
        public string secondName { get; set; }

        public ICollection<Book> Book { get; set; }

        public Authors()
        {
            name = string.Empty;
            secondName = string.Empty;
            Book = new List<Book>();
        }
    }
}
