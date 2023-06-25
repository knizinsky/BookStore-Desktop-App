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

                if (Book.Category == null || Book.Category.categoriesId == 0)
                {
                    Categories newCategory = new Categories()
                    {
                        name = "Nowa kategoria",
                        description = "Opis nowej kategorii"
                    };

                    _dbContext.Categories.Add(newCategory);
                    _dbContext.SaveChanges();

                    Book.categoriesId = newCategory.categoriesId;
                }
                else
                {
                    Book.categoriesId = Book.Category.categoriesId;
                }

                if (Book.Author == null || Book.Author.AuthorsId == 0)
                {
                    Authors newAuthor = new Authors()
                    {
                        name = "Nowy Autor",
                        secondName = "Nowy Autor"
                    };

                    _dbContext.Authors.Add(newAuthor);
                    _dbContext.SaveChanges();

                    int newAuthorId = newAuthor.AuthorsId;

                    Book.AuthorsId = newAuthorId;
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
                MessageBox.Show($"Wystąpił błąd podczas zapisywania książki: {ex.InnerException}");
            }
        }

    }
}
