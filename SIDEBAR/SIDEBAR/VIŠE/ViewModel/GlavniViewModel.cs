
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIDEBAR.CORE;
using System.Threading.Tasks;

namespace SIDEBAR.VIŠE.ViewModel
{
    internal class GlavniViewModel :CoreObjekt
    {


        public HomeView HomeView { get; set; }  
        public object _trenutniPrikaz;

            public object TrenutniPrikaz
        {
            get {  return _trenutniPrikaz;}
            set {_trenutniPrikaz = value; OnPropertyChanged(); }
        }
        public GlavniViewModel() { 

            HomeView = new HomeView();
            TrenutniPrikaz = HomeView;
            

        }
    }
}
