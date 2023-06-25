using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BookStoreApp
{
    public class Book
    {
        public int bookId { get; set; }
        [AllowNull]
        public string title { get; set; }
        public string ISBN { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int amount { get; set; }
        public int AuthorsId { get; set; }
        public int categoriesId { get; set; }

        [ForeignKey("AuthorsId")]
        public Authors Author { get; set; }

        [ForeignKey("categoriesId")]
        public Categories Category { get; set; }

        public ICollection<Orders> Orders { get; set; }

        public Book()
        {
            title = string.Empty;
            ISBN = string.Empty;
            description = string.Empty;
            Category = new Categories();
            Author = new Authors();
            Orders = new List<Orders>();
        }
    }
}
