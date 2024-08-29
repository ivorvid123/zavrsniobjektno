using SIDEBAR.VIŠE.ViewModel;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SIDEBAR.VIŠE.View
{
    public partial class MovieDescription : UserControl
    {
        public MovieDescription()
        {
            InitializeComponent();
        }

        public MovieDescription(OpisVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}

