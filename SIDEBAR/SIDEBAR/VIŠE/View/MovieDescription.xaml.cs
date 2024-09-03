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
        private Movie _trenutniFilm;

        public MovieDescription(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        public void SetMovieDetails(Movie movie)
        {
            _trenutniFilm = movie;
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
                MessageBox.Show("Referenca na glavni prozor nije postavljena.");
            }
        }

        private void SaveMovie_Click(object sender, RoutedEventArgs e)
        {
            int userId = SessionManager.LoggedInUserId;

            if (userId == 0)
            {
                MessageBox.Show("Nije pronađen user ID.");
                return;
            }

            if (_trenutniFilm != null)
            {
                string connectionString = "server=88.207.112.60;database=userdatabase;uid=root;pwd=ADGe96zn;";

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // provjerava se postoji li film koji se sprema u korisnikovoj listi
                    var checkQuery = "SELECT COUNT(*) FROM UserMovies WHERE UserId = @idKorisnika AND MovieName = @imeFilma";
                    using (var checkCommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@idKorisnika", userId);
                        checkCommand.Parameters.AddWithValue("@imeFilma", _trenutniFilm.Ime);

                        var movieCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (movieCount > 0)
                        {
                            MessageBox.Show("Film je već u vašoj listi.");
                            return;
                        }
                    }

                    var insertQuery = "INSERT INTO UserMovies (UserId, MovieName, Rating, Image, Director, Description) VALUES (@idKorisnika, @imeFilma, @Rating, @Slika, @Direktor, @Opis)";
                    using (var insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@idKorisnika", userId);
                        insertCommand.Parameters.AddWithValue("@imeFilma", _trenutniFilm.Ime);
                        insertCommand.Parameters.AddWithValue("@Rating", _trenutniFilm.Ocjena);
                        insertCommand.Parameters.AddWithValue("@Slika", _trenutniFilm.Image);
                        insertCommand.Parameters.AddWithValue("@Direktor", _trenutniFilm.Director);
                        insertCommand.Parameters.AddWithValue("@Opis", _trenutniFilm.Opis);
                        insertCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Film je uspješno spremljen.");
                }
            }
        }

        private void RemoveMovie_Click(object sender, RoutedEventArgs e)
        {
            int userId = SessionManager.LoggedInUserId;

            if (userId == 0)
            {
                MessageBox.Show("Nije pronađen user ID.");
                return;
            }
            if (_trenutniFilm != null)
            {
                string connectionString = "server=88.207.112.60;database=userdatabase;uid=root;pwd=ADGe96zn;";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "DELETE FROM UserMovies WHERE UserId = @idKorisnika AND MovieName = @imeFilma";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idKOrisnika", userId);
                        command.Parameters.AddWithValue("@imeFilma", _trenutniFilm.Ime);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Film je uspješno izbrisan sa liste.");
            }
        }
    }
}
