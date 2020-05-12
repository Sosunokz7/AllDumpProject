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
    /// <summary>
    /// Логика взаимодействия для Avtorizat.xaml
    /// </summary>
    public partial class Avtorizat : Page
    {
        

        public Avtorizat()
        {
            InitializeComponent();
        }
       


        private void Zati_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SQLQes.AllSQLQuest SqlQests = new SQLQes.AllSQLQuest(); 

                int Bols=SqlQests.ForTestLoginAndPassword(Login.Text, Password.Password);

                if (Bols == 1)
                {
                    InputUser();
                }
                else if (Bols == 2)
                {
                    this.NavigationService.Navigate(new ForLotersi());
                }
                else
                {
                    MessageBox.Show("Такой пользователь не найден");
                }

            }
            catch(Exception ep)
            {
                MessageBox.Show(ep.Message);
            }
        }

        private void InputUser()
        {
            try
            {

                this.NavigationService.Navigate(new Users());

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Bacg_Click(object sender, RoutedEventArgs e)
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

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MakeUser());
        }
    }
}
