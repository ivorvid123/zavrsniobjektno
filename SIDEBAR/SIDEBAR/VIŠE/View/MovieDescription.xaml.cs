using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace SIDEBAR.VIŠE.View
{
    public partial class MovieDescription : UserControl
    {
        private MainWindow _mainWindow;

    // Constructor that accepts a reference to MainWindow
      public MovieDescription(MainWindow mainWindow)
    {
        InitializeComponent();
        _mainWindow = mainWindow;
    }
        

        public void SetMovieDetails(Movie movie)
        {
            MovieTitle.Text = movie.Ime;
            MovieImage.Source = new BitmapImage(new Uri(movie.Image, UriKind.Relative));
            MovieDetails.Text = $"{movie.Opis}\n\n Director:{movie.Director}. \n\n Ocjena: {movie.Ocjena} \n Detalji sa Imdb"; // Placeholder for actual description
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {

            if (_mainWindow != null)
            {
                _mainWindow.MainContent.Content = new FilmoviISerije();
            }
            else
            {
                MessageBox.Show("Main window reference is not set.");
            }
        }

    }
}
