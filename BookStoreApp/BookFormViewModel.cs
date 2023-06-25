using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace BookStoreApp
{
    internal class BookFormViewModel
    {
        private BookStoreDbContext _dbContext;

        public Book Book { get; set; }
        public ObservableCollection<Authors> Authors { get; set; }
        public ObservableCollection<Categories> Categories { get; set; }

        public BookFormViewModel()
        {
            _dbContext = new BookStoreDbContext();
            Book = new Book();
            Authors = new ObservableCollection<Authors>(_dbContext.Authors.ToList());
            Categories = new ObservableCollection<Categories>(_dbContext.Categories.ToList());
        }

        internal void SaveBook()
        {
            try
            {
                if (Book.bookId == 0)
                {
                    _dbContext.Books.Add(Book);
                }
                else
                {
                    _dbContext.Books.Update(Book);
                }

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
