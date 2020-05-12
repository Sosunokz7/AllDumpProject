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
using ProjcForAukt.SQLQes.PeremiiForSQL;

namespace ProjcForAukt.Pagings
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Page
    {

        public Users()
        {
            InitializeComponent();
            Famile.Text = PeremenSQL.InfMens[1];
            Names.Text = PeremenSQL.InfMens[2];

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Array.Clear(PeremenSQL.InfMens,0,7);
            
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

        private void AuktionForBu_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Auk());
        }

        private void MyBayLot_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MyBayLot());
        }

        private void SellMyLot_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new AddNewLot());
        }
    }
}
