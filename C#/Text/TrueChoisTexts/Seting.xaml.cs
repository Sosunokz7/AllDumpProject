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
using System.Windows.Shapes;

namespace TrueChoisTexts
{
    /// <summary>
    /// Логика взаимодействия для Seting.xaml
    /// </summary>
    public partial class Seting : Window
    {
        public Seting()
        {
            InitializeComponent();
            
        }

        private void EndSet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AllSetings.FonSiz = Convert.ToInt32(InputSize.Text);
                AllSetings.FontFamils = Selects.Text;
                this.Close();


            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }
    }
}
