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
using System.Data.OleDb;


namespace ProjcForAukt
{

    public partial class MainWindow : Window
    {
      

       // private OleDbConnection myConnection;
        
        public MainWindow()
        {
            InitializeComponent();
            PerexodNewPag.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            this.MinWidth = 1050;
            this.MinHeight = 450;
            this.Icon = new BitmapImage(new Uri(@"C:\Users\"+FormWind.NamePCUsera+@"\Desktop\ProjcForAukt\ProjcForAukt\0048.jpg"));
            

            FormWind.StatPerexod = PerexodNewPag;
            FormWind.ButtonMaiWindow = Avtorizt;
            FormWind.ButtonRegistration = Registration;

        }


        

        private void Avtorizt_Click(object sender, RoutedEventArgs e)
        {
            PerexodNewPag.Visibility = Visibility.Visible;
            PerexodNewPag.Navigate(new ProjcForAukt.Pagings.Avtorizat());
            Avtorizt.Visibility = Visibility.Collapsed;
            Registration.Visibility = Visibility.Collapsed;
        }

        private void Registrat_Click(object sender, RoutedEventArgs e)
        {
            PerexodNewPag.Visibility = Visibility.Visible;
            PerexodNewPag.Navigate(new ProjcForAukt.Pagings.MakeUser());
            Avtorizt.Visibility = Visibility.Collapsed;
            Registration.Visibility = Visibility.Collapsed;

        }

   
    }
}
