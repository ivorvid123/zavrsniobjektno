using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using SIDEBAR.VIŠE.View;

namespace SIDEBAR.VIŠE.View
{
    public partial class FilmoviISerije : UserControl
    {
        public FilmoviISerije()
        {
            InitializeComponent();
            var movie = GetMovie();
            if (movie.Count > 0)
                ListViewMovie.ItemsSource = movie;
        }

        private List<Movie> GetMovie()
        {
            return new List<Movie>()
            {
                new Movie("21 Jump street", 7.2, "/SLIKE/21.jpg","Phil Lord & Christopher Miller", "A pair of underachieving cops are sent back to a local high school to blend in and bring down a synthetic drug ring.\r\n\r\n", ShowDescription),
                new Movie("Rubber Face", 3.4, "/SLIKE/face.jpg","Glen Salzman & Rebecca Yates", "This film was shot in Canada and released there as, \"Introducing...Janet.\" Janet is an overweight girl who has a knack for making the other children in school laugh...by making fun of her own weight. In seeing the other kids' reaction, she feels that she might have a career as a comedian. She visits the local comedy club, where she finds Tony Moroni, a struggling comedian whose jokes often fail. Together, Tony helps Janet build self-esteem and she helps him with his material.", ShowDescription),
                new Movie("Home Alone", 7.7, "/SLIKE/home alone.jpg","Chris Columbus", "An eight-year-old troublemaker, mistakenly left home alone, must defend his home against a pair of burglars on Christmas Eve.\r\n\r\n", ShowDescription),
                new Movie("Monty Python", 8.2, "/SLIKE/monty.jpg","Terry Gilliam & Terry Jones", "King Arthur and his Knights of the Round Table embark on a surreal, low-budget search for the Holy Grail, encountering many, very silly obstacles.\r\n\r\n", ShowDescription),
                new Movie("DeadPool", 8.0, "/SLIKE/Deadpool.jpg","Tim Miller", "A wisecracking mercenary gets experimented on and becomes immortal yet hideously scarred, and sets out to track down the man who ruined his looks.\r\n\r\n", ShowDescription),
                new Movie("Naked Gun", 7.6, "/SLIKE/naked gun.jpg","David Zucker", "Incompetent police Detective Frank Drebin must foil an attempt to assassinate Queen Elizabeth II.\r\n\r\n", ShowDescription),
                new Movie("Tropic Thunder", 7.1, "/SLIKE/tropicthund.jpg","Ben Stiller", "Through a series of freak occurrences, a group of actors shooting a big-budget war movie are forced to become the soldiers they are portraying.\r\n\r\n", ShowDescription)
            };
        }

        private void MovieButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedMovie = button?.DataContext as Movie;
            if (selectedMovie != null)
            {
                var movieDescriptionPage = new MovieDescription();
                movieDescriptionPage.SetMovieDetails(selectedMovie);

                // Get the parent window and change the content of the ContentControl
                var parentWindow = Window.GetWindow(this) as MainWindow;
                if (parentWindow != null)
                {
                    parentWindow.MainContent.Content = movieDescriptionPage;
                }
            }
        }
        private void ShowDescription(Movie movie)
        {
            var movieDescriptionPage = new MovieDescription();
            movieDescriptionPage.SetMovieDetails(movie);

            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainContent.Content = movieDescriptionPage;
            }
        }
    }
}
    