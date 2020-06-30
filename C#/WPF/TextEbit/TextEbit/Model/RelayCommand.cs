using System;

using System.Windows.Input;

namespace TextEbit.Model
{
	class RelayCommand : ICommand
	{
		private Action<object> _execute;
		private Func<object, bool> _canExecute;

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }


		}
		public bool CanExecute(object parameter)
		{
			return this._canExecute == null || this._canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			this._execute(parameter);
		}

		public RelayCommand(Action<object>action,Func<object,bool> func=null )
		{
			this._execute = action;
			this._canExecute = func;
		}
	}
}


