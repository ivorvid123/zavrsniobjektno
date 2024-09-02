using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace SIDEBAR.VIŠE.View
{
    public partial class Account : UserControl, INotifyPropertyChanged
    {
        // Connection string for MySQL database
        private const string ConnectionString = "Server=192.168.1.20;Database=userdatabase;uid=root;Password=ADGe96zn;";

        private User _currentUser;
        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged("CurrentUser");
                OnPropertyChanged("UserEmail");
                OnPropertyChanged("UserDate");
            }
        }

        public Account()
        {
            InitializeComponent();
            DataContext = this; // Set DataContext to this UserControl
            LoadUserData(); // Load the user data when the control is initialized
        }

        private void LoadUserData()
        {
            // Retrieve the user ID from SessionManager
            int userId = SessionManager.LoggedInUserId;

            if (userId == 0)
            {
                MessageBox.Show("User ID not found. Please log in again.");
                return;
            }

            string query = "SELECT Email, Registration_Date FROM users WHERE id = @UserId";

            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        // Use the user ID stored in SessionManager
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CurrentUser = new User
                                {
                                    Email = reader["Email"].ToString(),
                                    RegistrationDate = Convert.ToDateTime(reader["Registration_Date"])
                                };
                            }
                            else
                            {
                                MessageBox.Show("No user data found for the given ID.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading user data: {ex.Message}");
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (window != null)
            {
                window.Close();
            }
        }

        // User class for data binding
        public class User
        {
            public string Email { get; set; }
            public DateTime RegistrationDate { get; set; }
        }

        public string UserEmail => CurrentUser?.Email;

        public string UserDate => CurrentUser?.RegistrationDate.ToString("yyyy-MM-dd");

        // INotifyPropertyChanged implementation to notify the UI about property changes
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}