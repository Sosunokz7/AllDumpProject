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
using ProjcForAukt.SQLQes.PeremiiForSQL;
namespace ProjcForAukt.Pagings
{
    /// <summary>
    /// Логика взаимодействия для Auk.xaml
    /// </summary>
    public partial class Auk : Page
    {
        private int NowLenLots=0;
        SQLQes.AllSQLQuest SQLQuests = new SQLQes.AllSQLQuest();

        public Auk()
        {
            try
            {
                InitializeComponent();
                

                SQLQuests.ForSellLot();
                AgoLot.IsEnabled = false;

                Perexod();

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }

        private void Perexod()
        {
            try
            {
                PhotLota.Source = new BitmapImage(new Uri(@"C:\Users\" + FormWind.NamePCUsera + @"\Desktop\ProjcForAukt\ProjcForAukt\Fots\" + PeremenSQL.ForLots[6, NowLenLots]));

                LookNameLot.Text = PeremenSQL.ForLots[1, NowLenLots];
                NowStavka.Text = "Нынешняя ставка :" + PeremenSQL.ForLots[5, NowLenLots].ToString() + " Руб";

                Opisan.Text = PeremenSQL.ForLots[2, NowLenLots];
            }
            catch (Exception s)
            {

                MessageBox.Show("Лоты закончились");
            }
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
            catch(Exception s)
            {
                MessageBox.Show(s.Message);
            }


        }
        


        private void NextLot_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AgoLot.IsEnabled = true;
                if (SQLQes.PeremiiForSQL.PeremenSQL.LenLots == NowLenLots)
                {
                    MessageBox.Show("Лоты закончились");
                    NextLot.IsEnabled = false;
                }
                else
                {
                    NowLenLots++;
                    Console.WriteLine(NowLenLots);
                    Perexod();
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }



        private void AgoLot_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NextLot.IsEnabled = true;
                NowLenLots--;
                
                Perexod();
                if (NowLenLots == 0)
                {
                    AgoLot.IsEnabled = false;
                }
            }
            catch(Exception s)
            {
                MessageBox.Show(s.Message);
            }
            
            
        }

        private void BuyLot_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                long Mani = Convert.ToInt64(InputStacka.Text);
                if (Mani > Convert.ToInt64(PeremenSQL.ForLots[5, NowLenLots]))
                {

                    long NewManiForStatPage= SQLQuests.TraidValueMany(Mani, NowLenLots);
                    NowStavka.Text = "Нынешняя ставка :" + NewManiForStatPage + " Руб";
                    MessageBox.Show("Вы успешно слелали ставку");
                   
                }
                else
                {
                    MessageBox.Show("Ваша ставка слишком мала");
                }


            }
            catch(Exception s)
            {
                MessageBox.Show(s.Message);
            }

        }
    }
}
