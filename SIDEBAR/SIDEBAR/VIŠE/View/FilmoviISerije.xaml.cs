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

namespace SIDEBAR.VIŠE.View
{
    /// <summary>
    /// Interaction logic for FilmoviISerije.xaml
    /// </summary>
    public partial class FilmoviISerije : UserControl
    {
        public FilmoviISerije()
        {
            InitializeComponent();
            var movie = GetMovie();
            if (movie.Count > 0)
                ListViewMovie.ItemsSource = movie;
        }

        private List<Movie> GetMovie()
        {
            return new List<Movie>()
      {
        new Movie("21 Jump street", 7.2, "/SLIKE/21.jpg",""),
        new Movie("Rubber Face", 3.4, "/SLIKE/face.jpg",""),
        new Movie("Home Alone", 7.7, "/SLIKE/home alone.jpg",""),
        new Movie("Monty Python", 8.2, "/SLIKE/monty.jpg",""),
        new Movie("DeadPool", 8.0, "/SLIKE/Deadpool.jpg",""),
        new Movie("Naked Gun", 7.6, "/SLIKE/naked gun.jpg", ""),
        new Movie("Tropic Thunder", 7.1, "/SLIKE/tropicthund.jpg",  "Through a series of freak occurrences, a group of actors shooting a big-budget war movie are forced to become the soldiers they are portraying.")
      };
        }
    }
}