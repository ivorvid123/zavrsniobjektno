using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient; // Add this using directive
using SIDEBAR;

namespace SIDEBAR
{
    public partial class RegisterWindow : Window
    {
        internal string connectionString = "server=localhost;database=userdatabase;uid=root;pwd=ADGe96zn;";

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a valid username and password.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Check if the username already exists
                    string checkUserQuery = "SELECT COUNT(*) FROM users WHERE email = @email";
                    MySqlCommand checkUserCmd = new MySqlCommand(checkUserQuery, conn);
                    checkUserCmd.Parameters.AddWithValue("@email", username);
                    int userExists = Convert.ToInt32(checkUserCmd.ExecuteScalar());

                    if (userExists > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.");
                    }
                    else
                    {
                        // Insert the new user into the database
                        string insertQuery = "INSERT INTO users (email, password) VALUES (@email, @password)";
                        MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                        cmd.Parameters.AddWithValue("@email", username);
                        cmd.Parameters.AddWithValue("@password", password); // In real applications, hash the password!
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registration successful! Please login.");
                        LoginWindow loginWindow = new LoginWindow();
                        loginWindow.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
