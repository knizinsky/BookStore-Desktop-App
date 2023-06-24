using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace BookStoreApp
{
    internal class MainWindowViewModel
    {
        private BookStoreDbContext _dbContext;
        public ObservableCollection<Book> Books { get; set; }

        public MainWindowViewModel()
        {
            _dbContext = new BookStoreDbContext();
            Books = new ObservableCollection<Book>(_dbContext.Books.ToList());
        }

        internal void RefreshBookList()
        {
            Books.Clear();
            foreach (var book in _dbContext.Books.ToList())
            {
                Books.Add(book);
            }
        }

        internal void DeleteBook(Book book)
        {
            try
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
                MessageBox.Show("Książka została usunięta.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas usuwania książki: {ex.Message}");
            }
        }
    }
}
