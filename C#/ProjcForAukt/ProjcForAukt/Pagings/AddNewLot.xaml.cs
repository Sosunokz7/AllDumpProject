using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace ProjcForAukt.Pagings
{

    public partial class AddNewLot : Page
    {
        private string PathForImageLota = @"C:\Users\" + FormWind.NamePCUsera + @"\Desktop\ProjcForAukt\ProjcForAukt\Fots\";

        private string PathForImage = @"C:\Users\" + FormWind.NamePCUsera + @"\Desktop\ProjcForAukt\ProjcForAukt\";

        private SQLQes.AllSQLQuest AddLotForSell = new SQLQes.AllSQLQuest();

        public System.Windows.Forms.OpenFileDialog ImagLota = new System.Windows.Forms.OpenFileDialog();

       
        
        public AddNewLot()
        {
            InitializeComponent();

            FotaLota.Source = new BitmapImage(new Uri(PathForImage + "Empty.jpg"));
        }

        private void AddImages_Click(object sender, RoutedEventArgs e)
        {
           
            ImagLota.Multiselect = false;
            ImagLota.InitialDirectory = @"C:\Users\" + FormWind.NamePCUsera + @"\Desktop";
            ImagLota.Filter = "Фото (*.bmp,*.jpg,*.png)|*.jpg;*.png;*.bmp";

            if (ImagLota.ShowDialog() == DialogResult.OK)
            {

                FotaLota.Source = new BitmapImage(new Uri(ImagLota.FileName));

            }


        }


        private void Bac_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();

            }
         }


            
        

        private void TapRegist_Click(object sender, RoutedEventArgs e)
        {
            if ((String.IsNullOrWhiteSpace(InputNameLot.Text) == true) || (String.IsNullOrWhiteSpace(InputOpisanieLot.Text) == true) || (String.IsNullOrWhiteSpace(InputPraisLot.Text)) == true)
            {

                System.Windows.Forms.MessageBox.Show("Вы ввели не все значения");
            }
            else
            {
                try
                {
                    string Filts = System.IO.Path.GetExtension(ImagLota.FileName).ToString();
                    string NewNameImageLot = DateTime.Now.ToFileTimeUtc().ToString()+Filts;
                    File.Copy(ImagLota.FileName, PathForImageLota + NewNameImageLot);

                    AddLotForSell.AddLot(InputNameLot.Text, InputOpisanieLot.Text, Convert.ToInt64(InputPraisLot.Text),NewNameImageLot);
                }
                catch (Exception g)
                {
                    System.Windows.Forms.MessageBox.Show(g.Message);
                }
            }


        }


    }
}

