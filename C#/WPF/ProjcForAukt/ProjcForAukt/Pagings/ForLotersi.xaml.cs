
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
    /// Логика взаимодействия для ForLotersi.xaml
    /// </summary>
    public partial class ForLotersi : Page
    {
        public ForLotersi()
        {
            InitializeComponent();
        }

        private void SELLLS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SQLQes.AllSQLQuest SQLS = new SQLQes.AllSQLQuest();

                SQLS.SELLSLOT();
            }

            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
        }

        private void Bac_Click(object sender, RoutedEventArgs e)
        {

            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }

        }
    }
}
