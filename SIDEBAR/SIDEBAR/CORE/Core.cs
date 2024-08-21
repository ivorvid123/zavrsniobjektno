using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace SIDEBAR.CORE
{
    class CoreObjekt : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged( [CallerMemberName]  string ime = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs( ime ) );
        }
    }
}
