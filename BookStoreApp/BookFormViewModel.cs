using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

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
                if (Book.title == "" || Book.title == null)
                {
                    MessageBox.Show("Tytuł książki nie może być pusty.");
                    return;
                }

                if (Book.ISBN == "" || Book.ISBN == null)
                {
                    MessageBox.Show("ISBN nie może być pusty.");
                    return;
                }

                if (Book.description == "" || Book.description == null)
                {
                    MessageBox.Show("Opis nie może być pusty.");
                    return;
                }

                if (Book.Category == null || Book.Category.name.Trim() == "" || Book.Category.categoriesId == 0)
                { 
                    MessageBox.Show("Kategoria nie może być pusta.");
                    return;
                }
                else
                {
                    Book.categoriesId = Book.Category.categoriesId;
                }

                if (Book.Author.name == null || Book.Author.name.Trim() == "")
                {
                    MessageBox.Show("Autor nie może być pusty.");
                    return;
                }
                else
                {
                    Book.AuthorsId = Book.Author.AuthorsId;
                }

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
