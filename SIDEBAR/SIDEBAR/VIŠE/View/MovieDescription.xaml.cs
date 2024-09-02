using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MySql.Data.MySqlClient;

namespace SIDEBAR.VIŠE.View
{
    public partial class MovieDescription : UserControl
    {
        private MainWindow _mainWindow;
        private Movie _currentMovie;

        public MovieDescription(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        public void SetMovieDetails(Movie movie)
        {
            _currentMovie = movie;
            MovieTitle.Text = movie.Ime;
            MovieImage.Source = new BitmapImage(new Uri(movie.Image, UriKind.Relative));
            MovieDetails.Text = $"{movie.Opis}\n\nDirector: {movie.Director}\n\nRating: {movie.Ocjena}\nDetails from IMDb";
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

        private void SaveMovie_Click(object sender, RoutedEventArgs e)
        {
            int userId = SessionManager.LoggedInUserId;

            if (userId == 0)
            {
                MessageBox.Show("User ID not found. Please log in again.");
                return;
            }
            if (_currentMovie != null)
            {
                string connectionString = "server=192.168.1.20;database=userdatabase;uid=root;pwd=ADGe96zn;"; // Replace with your connection string
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "INSERT INTO UserMovies (UserId, MovieName, Rating, Image, Director, Description) VALUES (@UserId, @MovieName, @Rating, @Image, @Director, @Description)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId); // Replace with the actual user ID
                        command.Parameters.AddWithValue("@MovieName", _currentMovie.Ime);
                        command.Parameters.AddWithValue("@Rating", _currentMovie.Ocjena);
                        command.Parameters.AddWithValue("@Image", _currentMovie.Image);
                        command.Parameters.AddWithValue("@Director", _currentMovie.Director);
                        command.Parameters.AddWithValue("@Description", _currentMovie.Opis);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Movie saved successfully.");
            }
        }

        private void RemoveMovie_Click(object sender, RoutedEventArgs e)
        {
            int userId = SessionManager.LoggedInUserId;

            if (userId == 0)
            {
                MessageBox.Show("User ID not found. Please log in again.");
                return;
            }
            if (_currentMovie != null)
            {
                string connectionString = "server=192.168.1.20;database=userdatabase;uid=root;pwd=ADGe96zn;"; // Replace with your connection string
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "DELETE FROM UserMovies WHERE UserId = @UserId AND MovieName = @MovieName";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId); // Replace with the actual user ID
                        command.Parameters.AddWithValue("@MovieName", _currentMovie.Ime);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Movie removed successfully.");
            }
        }
    }
}
