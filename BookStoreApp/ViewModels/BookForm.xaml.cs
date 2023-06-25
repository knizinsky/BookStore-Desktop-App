using System.Windows;

namespace BookStoreApp
{
    public partial class BookForm : Window
    {
        private BookFormViewModel _viewModel;

        public BookForm()
        {
            InitializeComponent();
            _viewModel = new BookFormViewModel();
            DataContext = _viewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveBook();
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
