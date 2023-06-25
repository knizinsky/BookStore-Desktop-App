using System.Windows;

namespace BookStoreApp
{
    public partial class BookForm : Window
    {
        private BookFormViewModel _viewModel;

        public BookForm(Book? book = null)
        {
            InitializeComponent();
            _viewModel = new BookFormViewModel(book ?? new Book());
            DataContext = _viewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveBook(_viewModel.Book);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
