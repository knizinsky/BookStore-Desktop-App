using System;
using System.Windows;

namespace BookStoreApp
{
    internal class BookFormViewModel
    {
        private BookStoreDbContext _dbContext;

        public Book Book { get; set; }

        public BookFormViewModel()
        {
            _dbContext = new BookStoreDbContext();
            Book = new Book();
        }

        internal void SaveBook()
        {
            try
            {
                _dbContext.Books.Add(Book);
                _dbContext.SaveChanges();
                MessageBox.Show("Książka została zapisana.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisywania książki: {ex.Message}");
            }
        }
    }
}
