using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace SIDEBAR
{
    public partial class LoginWindow : Window
    {
        private string connectionString = "server=88.207.112.60;database=userdatabase;uid=root;pwd=ADGe96zn;";

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string lozinka = txtPassword.Password;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // dobivanje vrjednosti id korisnika koji se prijavljuje
                    string query = "SELECT id FROM users WHERE email = @Email AND password = @Lozinka";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Lozinka", lozinka);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        SessionManager.LoggedInUserId = Convert.ToInt32(result);
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Pogrešan email ili lozinka.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Dogodila se greška: {ex.Message}");
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
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

    public static class SessionManager
    {
        public static int LoggedInUserId { get; set; }
    }
}
