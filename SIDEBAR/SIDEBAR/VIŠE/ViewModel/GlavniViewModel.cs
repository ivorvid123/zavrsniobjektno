
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
    public class GlavniViewModel : INotifyPropertyChanged
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

        public ICommand ShowDescriptionCommand { get; }


        public GlavniViewModel()
        {
            // Initialize default view
            TrenutniPrikaz = new HomeView();

            // Initialize commands
            PrikaziFilmoviISerijeCommand = new RelayCommand(_ => ShowFilmoviISerije());

            PrikaziListuCommand = new RelayCommand(_ => ShowList());

            PrikaziHomeCommand = new RelayCommand(_ => ShowHome());

            PrikaziAccountCommand = new RelayCommand(_ => ShowAccount());

        }

        private void ShowAccount()
        {
            // Create the UserControl instance
            var acountview = new VIŠE.View.Account();

            // Set the DataContext to the appropriate ViewModel
            acountview.DataContext = new AccountVM();

            // Update the current view
            TrenutniPrikaz = acountview;
        }
        private void ShowList()
        {
            // Create the UserControl instance
            var listaview = new VIŠE.View.MojaLista();

            // Set the DataContext to the appropriate ViewModel
            listaview.DataContext = new Lista();

            // Update the current view
            TrenutniPrikaz = listaview;
        }
       

        private void ShowFilmoviISerije()
        {
            // Create the UserControl instance
            var filmoviISerijeView = new VIŠE.View.FilmoviISerije();

            // Set the DataContext to the appropriate ViewModel
            filmoviISerijeView.DataContext = new FilmoviISerijeViewModel();

            // Update the current view
            TrenutniPrikaz = filmoviISerijeView;
        }

        private void ShowHome()
        {
            // Create the UserControl instance
            var homeview = new VIŠE.View.GlavniProzor();

            // Set the DataContext to the appropriate ViewModel
            homeview.DataContext = new HomeView();

            // Update the current view
            TrenutniPrikaz = homeview;
        }

        // Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

