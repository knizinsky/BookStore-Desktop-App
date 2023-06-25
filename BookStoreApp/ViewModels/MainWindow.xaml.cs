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

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = (Book)BookList.SelectedItem;
            if (selectedBook != null)
            {
                BookForm bookForm = new BookForm();
                bookForm.DataContext = new BookFormViewModel { Book = selectedBook };
                bookForm.ShowDialog();
                _viewModel.RefreshBookList();
            }
            else
            {
                MessageBox.Show("Wybierz książkę do edycji.");
            }
        }

        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
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
    }
}
