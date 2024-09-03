
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIDEBAR.CORE;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using SIDEBAR.VIŠE.View;
using System.Windows.Forms;

namespace SIDEBAR.VIŠE.ViewModel
{
    public class OpisVM : INotifyPropertyChanged
    {
        private object _trenutniPrikaz;
        public object TrenutniPrikaz
        {
            get { return _trenutniPrikaz; }
            set
            {
                _trenutniPrikaz = value;
                OnPropertyChanged(nameof(TrenutniPrikaz));
            }
        }

        public ICommand PrikaziFilmoviISerijeCommand { get; }
        public ICommand PrikaziListuCommand { get; }
        public ICommand PrikaziHomeCommand { get; }
        public ICommand PrikaziAccountCommand { get; }



        public OpisVM()
        {
            TrenutniPrikaz = new HomeView();

            PrikaziFilmoviISerijeCommand = new RelayCommand(_ => ShowFilmoviISerije());

            PrikaziListuCommand = new RelayCommand(_ => ShowList());

            PrikaziHomeCommand = new RelayCommand(_ => ShowHome());

            PrikaziAccountCommand = new RelayCommand(_ => ShowAccount());

        }

        private void ShowAccount()
        {

            var acountview = new VIŠE.View.Account();

            acountview.DataContext = new AccountVM();

            TrenutniPrikaz = acountview;
        }
        private void ShowList()
        {
            var listaview = new VIŠE.View.MojaLista();

            listaview.DataContext = new Lista();

            TrenutniPrikaz = listaview;
        }


        private void ShowFilmoviISerije()
        {
            var filmoviISerijeView = new VIŠE.View.FilmoviISerije();

            filmoviISerijeView.DataContext = new FilmoviISerijeViewModel();

            TrenutniPrikaz = filmoviISerijeView;
        }

        private void ShowHome()
        {
            var homeview = new VIŠE.View.GlavniProzor();

            homeview.DataContext = new HomeView();

            TrenutniPrikaz = homeview;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

