using System;
using System.Windows.Input;

namespace SIDEBAR
{
    public class Movie
    {
        public string Ime { get; set; }
        public double Ocjena { get; set; }
        public string Image { get; set; }
        public string Opis { get; set; }

        public string Director { get; set; }

        public ICommand ShowDescription { get; }

        public Movie(string ime, double ocjena, string image, string direct, string opis, Action<Movie> showDescriptionAction)
        {
            Ime = ime;
            Ocjena = ocjena;
            Image = image;
            Director = direct;
            Opis = opis;
            ShowDescription = new RelayCommand(_ => showDescriptionAction(this));

        }

        
    }
}
