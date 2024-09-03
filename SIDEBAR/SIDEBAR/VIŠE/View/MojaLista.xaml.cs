using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace SIDEBAR.VIŠE.View
{
    public partial class MojaLista : UserControl
    {
        public MojaLista()
        {
            InitializeComponent();
            LoadUserMovies();
        }

        private void LoadUserMovies()
        {
            int userId = SessionManager.LoggedInUserId;

            if (userId == 0)
            {
                MessageBox.Show("Nije pronađen User ID.");
                return;
            }
            string connectionString = "server=88.207.112.60;database=userdatabase;uid=root;pwd=ADGe96zn;";
            var movies = new List<Movie>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM UserMovies WHERE UserId = @idKorisnika";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idKorisnika", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var movie = new Movie(
                                reader["MovieName"].ToString(),
                                Convert.ToDouble(reader["Rating"]),
                                reader["Image"].ToString(),
                                reader["Director"].ToString(),
                                reader["Description"].ToString(),
                                null);
                            movies.Add(movie);
                        }
                    }
                }
            }
            ListViewMovie.ItemsSource = movies;
        }
        private void SavedMovieButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedMovie = button?.DataContext as Movie;
            if (selectedMovie != null)
            {
                var parentWindow = Window.GetWindow(this) as MainWindow;
                if (parentWindow != null)
                {
                    var movieDescriptionPage = new MovieDescription(parentWindow);
                    movieDescriptionPage.SetMovieDetails(selectedMovie);
                    parentWindow.MainContent.Content = movieDescriptionPage;
                }
            }
        }
    }
}
