using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SIDEBAR.VIŠE.View
{
    public partial class MovieDescription : UserControl
    {
        public MovieDescription()
        {
            InitializeComponent();
        }

        public void SetMovieDetails(Movie movie)
        {
            MovieTitle.Text = movie.Ime;
            MovieImage.Source = new BitmapImage(new Uri(movie.Image, UriKind.Relative));
            MovieDetails.Text = $"{movie.Opis}\n\n Director:{movie.Director}. \n\n Ocjena: {movie.Ocjena} \n\n Detalji sa Imdb"; // Placeholder for actual description
        }

    }
}
