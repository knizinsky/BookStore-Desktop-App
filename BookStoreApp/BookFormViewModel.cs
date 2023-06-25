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

        public BookFormViewModel(Book book)
        {
            _dbContext = new BookStoreDbContext();
            Book = book;
            Authors = new ObservableCollection<Authors>(_dbContext.Authors.ToList());
            Categories = new ObservableCollection<Categories>(_dbContext.Categories.ToList());
        }

        internal void SaveBook(Book book)
        {
            if (book.bookId == 0)
            {
                _dbContext.Books.Add(book);
            }
            else
            {
                var existingBook = _dbContext.Books.Find(book.bookId);
                if (existingBook != null)
                {
                    _dbContext.Entry(existingBook).CurrentValues.SetValues(book);
                    _dbContext.Entry(existingBook).Property(x => x.AuthorsId).IsModified = true;
                }
            }
            _dbContext.SaveChanges();
        }


    }

}
