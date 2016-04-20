using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_Zaawansowane.Windows
{
    public class GridViewModel : INotifyPropertyChanged
    {
        private bool isVisible = false;

        public bool IsVisible
        {
            get
            {
                return isVisible;
            }

            set
            {
                isVisible = value;
                NotifyPropertyChanged("IsVisible");
            }
        }

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
