using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace BookStoreApp
{
    /// <summary>
    /// Represents the main view model for the MainWindow.
    /// </summary>
    internal class MainWindowViewModel
    {
        private BookStoreDbContext _dbContext;
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Orders> Orders { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainWindowViewModel class.
        /// </summary>
        public MainWindowViewModel()
        {
            _dbContext = new BookStoreDbContext();
            Books = new ObservableCollection<Book>(_dbContext.Books.Include("Author").Include("Category").ToList());
            Orders = new ObservableCollection<Orders>(_dbContext.Orders.Include("Book").ToList());
        }

        internal void RefreshBookList()
        {
            Books.Clear();
            Orders.Clear();

            foreach (var book in _dbContext.Books.Include("Author").Include("Category").ToList())
            {
                Books.Add(book);
            }

            foreach (var order in _dbContext.Orders.Include("Book").ToList())
            {
                Orders.Add(order);
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

        internal void CreateOrder(Orders order)
        {
            try
            {
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas tworzenia zamówienia: {ex.InnerException}");
            }
        }
    }
}
