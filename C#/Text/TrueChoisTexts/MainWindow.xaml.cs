using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace TrueChoisTexts
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool FersSave = false;
        public string PathsToFile;

       
        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0,1),
                
            };
            timer.Tick += Sets;
            timer.Start();

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog()
                {
                    Filter = "*.txt|.txt"
                };

                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TextRange AllTexts = new TextRange(FullText.Document.ContentStart, FullText.Document.ContentEnd);
                    File.WriteAllText(saveFile.FileName, AllTexts.Text);

                    PathsToFile = saveFile.FileName;
                    FersSave = true;
                    Notifys.Visibility = Visibility.Hidden;
                }
            }

            catch (Exception s)
            {
                System.Windows.MessageBox.Show(s.Source);
            }

        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                OpenFileDialog OpensFile = new OpenFileDialog()
                {
                    Multiselect = false,
                    InitialDirectory = @"C:\Users\" + Environment.UserName.ToString() + @"\Desktop"

                };

                if (OpensFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Paragraph texts = new Paragraph();
                    
                    texts.Inlines.Add(File.ReadAllText(OpensFile.FileName));
                    FullText.Document.Blocks.Clear();
                    FullText.Document.Blocks.Add(texts);
                    PathsToFile = OpensFile.FileName;
                    FersSave = true;
                    Notifys.Visibility = Visibility.Hidden;
                }

                
            }
            catch (Exception s)
            {
                System.Windows.MessageBox.Show(s.Source);
            }
        }

        private void Grid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {


            if (e.KeyboardDevice.Modifiers == (ModifierKeys.Control | ModifierKeys.Shift) && e.Key == Key.O)
            {
                Open_Click(null, null);
            }
            else if (e.KeyboardDevice.Modifiers == (ModifierKeys.Control | ModifierKeys.Alt) && e.Key == Key.S)
            {
                Save_Click(null, null);
            }
            else if (e.KeyboardDevice.Modifiers == (ModifierKeys.Control) && e.Key == Key.S)
            {
                SaveAll_Click(null, null);
            }
            else if (e.KeyboardDevice.Modifiers==ModifierKeys.None)
            {
                Notifys.Visibility = Visibility.Visible;
            }

        }

        private void SaveAll_Click(object sender, RoutedEventArgs e)
        {

            if (FersSave == false)
            {
                Save_Click(null, null);
            }
            else
            {
                TextRange Texts = new TextRange(FullText.Document.ContentStart, FullText.Document.ContentEnd);

                File.WriteAllText(PathsToFile, Texts.Text);
                Notifys.Visibility = Visibility.Hidden;
            }
            

        }

        private void Setings_Click(object sender, RoutedEventArgs e)
        {

            Seting  NewSeting= new Seting();

            NewSeting.ShowDialog();
        }

        private void Sets(object sender, object e)
        {

            FullText.FontSize = AllSetings.FonSiz;
            FullText.FontFamily = new FontFamily (AllSetings.FontFamils);
        }

    }
}
