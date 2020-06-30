using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using TextEbit.Model;

namespace TextEbit.ViewModel
{
	class MainViewModel:Base_VM
	{
		public ushort _FontSize { get { return this.FontSize; } set { this.FontSize = value; OnPropery(); } }
		private ushort FontSize=13;

		public string _FontFamily { get { return this.FontFamily; } set { this.FontFamily = value;OnPropery(); } }
		private string FontFamily= "Microsoft Sans Serif";


		public string _Text { get {return this.Text; } set { this.Text =value;OnPropery(); } }
		private string Text;

		private string Path;
		public  ICommand Parameters 
		{ 
			get {
				return new RelayCommand((obj) => 
				{
					
					using (FontDialog fontDialog = new FontDialog() { MinSize = 1, MaxSize = 65534,ShowEffects=false})
					{
						
						if (fontDialog.ShowDialog() == DialogResult.OK)
						{
							this._FontSize = (ushort)fontDialog.Font.Size;
							this._FontFamily = fontDialog.Font.FontFamily.Name;

						}
					}
				});
			} 
		
		
		}//Настройки текста
	
		public ICommand OpenFile
		{
			get { 
				return new RelayCommand((obj) =>
				{ 
					using (OpenFileDialog openFile = new OpenFileDialog() {Multiselect=false,Filter="*.txt|*.txt" })
					{
						if (openFile.ShowDialog()==DialogResult.OK)
						{
							Path = openFile.FileName;
							_Text =File.ReadAllText(Path, Encoding.UTF8);	
						}
					}

				});
			}
		}//Открытие файла

		public ICommand SaveFileAs
		{
			get {
				return new RelayCommand((obj) =>
				{
					
					using (SaveFileDialog saveFile = new SaveFileDialog() { AddExtension = true, Filter = "*.txt|*.txt" })
					{
						if (saveFile.ShowDialog() == DialogResult.OK)
						{
							Path = saveFile.FileName;
							WriteToFile();
						}
					}
				});
			}
		}//Сохранить как

		public ICommand JastSaveFile
		{
			get
			{
				return new RelayCommand((obj) =>
				{
					WriteToFile();
				},(obj)=> Path!=null);
			}
		}//Сохранить 
		
		private void WriteToFile()//Запись текста в файл
		{
			File.WriteAllText(Path, _Text, Encoding.UTF8);
		}

	}
}
