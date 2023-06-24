using System.Collections.Generic;

namespace BookStoreApp
{
    public class Categories
    {
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
