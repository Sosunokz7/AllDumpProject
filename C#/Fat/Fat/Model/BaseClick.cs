using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fat.Model
{
    class BaseClick : ICommand
    {
        private Action<object> _Execute;
        private Func<object, bool> _CanExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return this._CanExecute == null || this._CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this._Execute(parameter);
        }

        public BaseClick(Action<object> action,Func<object,bool> func=null)
        {
            this._Execute = action;
            this._CanExecute=func;
        }
    }
}
