using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Fat.Model
{
    class Base_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperty([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(prop) );
        }
    }
}
