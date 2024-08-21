using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SIDEBAR.CORE
{
    internal class CoreKomanda : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CoreKomanda(Action<object> odradi, Func<object, bool> mozesOdradit = null)
        {
            _execute = odradi;
            _canExecute = mozesOdradit;
        }

        public bool CanExecute(object parametar)
        {
            return _canExecute== null || _canExecute(parametar);
        }
        public void Execute(object parametar)
        {
            _execute(parametar);
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
            {
                textEmail.Visibility = Visibility.Collapsed;
            }
            else
            {
                textEmail.Visibility = Visibility.Visible;
            }
        }
    }
}
