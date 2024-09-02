using SIDEBAR.VIŠE.View;
using SIDEBAR.VIŠE.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SIDEBAR
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new GlavniProzor();


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

        public void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new GlavniProzor();
        }

        public void FilmoviISerijeButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new FilmoviISerije();
        }

        private void MojaListaButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MojaLista();
        }
        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Account();
        }
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Initiates the dragging of the window.
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
         
    }
}

