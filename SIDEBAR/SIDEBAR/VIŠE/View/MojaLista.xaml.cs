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
            string connectionString = "your_connection_string_here"; // Replace with your connection string
            var movies = new List<Movie>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM UserMovies WHERE UserId = @UserId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", 1); // Replace with the actual user ID
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
                                null); // You might need to modify this part
                            movies.Add(movie);
                        }
                    }
                }
            }
            ListViewMovie.ItemsSource = movies;
        }
    }
}
