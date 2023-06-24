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
        public int categoriesId { get; set; }

        public Authors Author { get; set; }
        public Categories Category { get; set; }

        public Book()
        {
            title = string.Empty;
            ISBN = string.Empty;
            description = string.Empty;
            Category = new Categories();
            Author = new Authors();
        }
    }
}
