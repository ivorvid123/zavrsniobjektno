using System;
using System.Windows.Input;

namespace SIDEBAR
{
    public class Movie
    {
        public string Ime { get; set; }
        public double Ocjena { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public Movie(string ime, double ocjena, string image, string description)
        {
            Ime = ime;
            Ocjena = ocjena;
            Image = image;
            Description = description;
      
        }

        
    }
}
