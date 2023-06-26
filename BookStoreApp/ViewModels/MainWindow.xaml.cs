using System;
using System.Linq;
using System.Windows;

namespace BookStoreApp
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            BookForm bookForm = new BookForm();
            bookForm.ShowDialog();
            _viewModel.RefreshBookList();
        }

        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedBook = (Book)BookList.SelectedItem;
                if (selectedBook != null)
                {
                    var result = MessageBox.Show("Czy na pewno chcesz usunąć tę książkę?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        _viewModel.DeleteBook(selectedBook);
                        _viewModel.RefreshBookList();
                    }
                }
                else
                {
                    MessageBox.Show("Wybierz książkę do usunięcia.");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Wybierz książkę do usunięcia.");
            }
        }

        private void OrderBookButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedBook = (Book)BookList.SelectedItem;
                if (selectedBook != null)
                {
                    var order = new Orders
                    {
                        orderType = "Zamówienie",
                        bookId = selectedBook.bookId
                    };

                    order.GenerateExpectedOrderDate();

                    _viewModel.CreateOrder(order);
                    MessageBox.Show("Książka została zamówiona.");
                    _viewModel.RefreshBookList();
                }
                else
                {
                    MessageBox.Show("Wybierz książkę do zamówienia.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Wybierz książkę do zamówienia.");
            }
        }


    }

}
