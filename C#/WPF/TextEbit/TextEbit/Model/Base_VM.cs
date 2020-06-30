
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TextEbit.Model
{
	class Base_VM : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropery([CallerMemberName] string prop="")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
