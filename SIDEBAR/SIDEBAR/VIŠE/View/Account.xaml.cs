using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace SIDEBAR.VIŠE.View
{
    public partial class Account : UserControl
    {
        // Connection string for MySQL database
        private const string ConnectionString = "Server=localhost;Database=userdatabase;uid=root;Password=ADGe96zn;";

        public User CurrentUser
        {
            get { return (User)GetValue(CurrentUserProperty); }
            set { SetValue(CurrentUserProperty, value); }
        }

        public static readonly DependencyProperty CurrentUserProperty =
            DependencyProperty.Register("CurrentUser", typeof(User), typeof(Account), new PropertyMetadata(null));

        public Account()
        {
            InitializeComponent();
            DataContext = this; // Set DataContext to this UserControl
            LoadUserData();
        }

        private void LoadUserData()
        {
            // Replace 'your_user_id' with the actual user ID or email to retrieve the specific user's data
            string query = "SELECT Email, Registration_Date FROM Users WHERE id = @UserId";

            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        // Example parameter; replace with actual user ID or criteria
                        command.Parameters.AddWithValue("@UserId", "some_user_id");

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

        // Ensure the User class is implemented correctly for binding
        public class User
        {
            public string Email { get; set; }
            public DateTime RegistrationDate { get; set; }
        }

        // Ensure these properties are correctly defined for binding
        public string UserEmail
        {
            get { return CurrentUser?.Email; }
        }

        public string UserDate
        {
            get { return CurrentUser?.RegistrationDate.ToString("yyyy-MM-dd"); }
        }
    }
}
