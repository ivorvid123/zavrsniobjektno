using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace SIDEBAR.VIŠE.View
{
    public partial class Account : UserControl, INotifyPropertyChanged
    {
        // konekcija na mysql bazu podataka
        private const string ConnectionString = "Server=88.207.112.60;Database=userdatabase;uid=root;Password=ADGe96zn;";

        private User _trenutniKorisnik;
        public User TrenutniKorisnik
        {
            get { return _trenutniKorisnik; }
            set
            {
                _trenutniKorisnik = value;
                OnPropertyChanged("CurrentUser");
                OnPropertyChanged("UserEmail");
                OnPropertyChanged("UserDate");
            }
        }

        public Account()
        {
            InitializeComponent();
            DataContext = this;
            LoadUserData();
        }

        private void LoadUserData()
        {
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
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TrenutniKorisnik = new User
                                {
                                    Email = reader["Email"].ToString(),
                                    RegistrationDate = Convert.ToDateTime(reader["Registration_Date"])
                                };
                            }
                            else
                            {
                                MessageBox.Show("Nisu pronađeni podaci za trenutni userID.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greška pri učitavanju korisničkih podataka: {ex.Message}");
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Window window = Window.GetWindow(this);
            if (window != null)
            {
                window.Close();
            }
        }

        public class User
        {
            public string Email { get; set; }
            public DateTime RegistrationDate { get; set; }
        }

        public string UserEmail => TrenutniKorisnik?.Email;

        public string UserDate => TrenutniKorisnik?.RegistrationDate.ToString("yyyy-MM-dd");

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}