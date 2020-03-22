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

namespace ProjcForAukt.Pagings
{
    
    public partial class MyBayLot : Page
    {
        public int LenLota = SQLQes.PeremiiForSQL.PeremenSQL.LenLots;
        private string PutForImage = @"C:\Users\"+FormWind.NamePCUsera+ @"\Desktop\ProjcForAukt\ProjcForAukt\Fots\";
        public MyBayLot()
        {
            InitializeComponent();
          

            SQLQes.AllSQLQuest MyLotForList = new SQLQes.AllSQLQuest();

            MyLotForList.MyLots();
            MainWindow_Loade();
        }

        private void MainWindow_Loade()
        {
            //MyLotis.Items.Add(new {
            //    NumLot1 = "Номер лота",
            //    NameLot1 = "Название лота ",
            //    Prais1 = "Цена лота",
            //    DateSell1="Дата покупки",
            //    Adres1="Адрес доставки ",
            //    Imag1="Фота лота",

            //});



            for (int i = 0; i <= SQLQes.PeremiiForSQL.PeremenSQL.LenMyLots; i++)
                MyLotis.Items.Add(new
                {
                    NumLot = SQLQes.PeremiiForSQL.PeremenSQL.MyLotsForMe[0, i],
                    NameLot = SQLQes.PeremiiForSQL.PeremenSQL.MyLotsForMe[1, i],
                    Prais = SQLQes.PeremiiForSQL.PeremenSQL.MyLotsForMe[2, i],
                   
                    Adres = SQLQes.PeremiiForSQL.PeremenSQL.MyLotsForMe[3, i],
                    Imag = new BitmapImage(new Uri(PutForImage + SQLQes.PeremiiForSQL.PeremenSQL.MyLotsForMe[4, i])),

                });

        }

        private void Bac_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.NavigationService.CanGoBack)
                {
                    this.NavigationService.GoBack();
                }
                else
                {
                    FormWind.ButtonMaiWindow.Visibility = Visibility.Visible;
                    FormWind.StatPerexod.Visibility = Visibility.Collapsed;
                    FormWind.ButtonRegistration.Visibility = Visibility.Visible;
                }

            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }
    }
}
