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
    /// Логика взаимодействия для MakeUser.xaml
    /// </summary>
    public partial class MakeUser : Page
    {
        private string [] AllDanUser = new string[7];
        public MakeUser()
        {
            InitializeComponent();
        }


        private void TapRegist_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (DigitPasport.Text != null && Familes.Text != null && Names.Text != null && Adres.Text != null && NomerKarti.Text != null && Login.Text != null && Passwor.Text != null)
                {
                    SQLQes.AllSQLQuest SqlQues = new SQLQes.AllSQLQuest();

                    AllDanUser[0] = DigitPasport.Text;
                    AllDanUser[1] = Familes.Text;
                    AllDanUser[2] = Names.Text;
                    AllDanUser[3] = Adres.Text;
                    AllDanUser[4] = NomerKarti.Text;
                    AllDanUser[5] = Login.Text;
                    AllDanUser[6] = Passwor.Text;

                    SqlQues.ForTestRegistr(AllDanUser);

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
                else
                {
                    MessageBox.Show("Вы заполнили не все поля");
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
          

           


        }

        private void Bac_Click(object sender, RoutedEventArgs e)
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
    }
}
