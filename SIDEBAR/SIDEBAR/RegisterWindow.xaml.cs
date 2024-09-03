using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using SIDEBAR;

namespace SIDEBAR
{
    public partial class RegisterWindow : Window
    {
        internal string connectionString = "server=88.207.112.60;database=userdatabase;uid=root;pwd=ADGe96zn;";

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string lozinka = txtPassword.Password;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(lozinka))
            {
                MessageBox.Show("Molim vas unesite pravilan email i lozinku.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string checkUserQuery = "SELECT COUNT(*) FROM users WHERE email = @email";
                    MySqlCommand checkUserCmd = new MySqlCommand(checkUserQuery, conn);
                    checkUserCmd.Parameters.AddWithValue("@email", email);
                    int userExists = Convert.ToInt32(checkUserCmd.ExecuteScalar());

                    if (userExists > 0)
                    {
                        MessageBox.Show("Email vec postoji. Molim vas unesite drugi email.");
                    }
                    else
                    {
                        // Unos novog korisnika u bazu podataka
                        string insertQuery = "INSERT INTO users (email, password) VALUES (@Email, @Lozinka)";
                        MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Lozinka", lozinka);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Uspješno ste registrirani. Molim vas prijavite se.");
                        LoginWindow loginWindow = new LoginWindow();
                        loginWindow.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dogodila se greška: " + ex.Message);
                }
            }
        }
        private void PovratakButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeRestore_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
