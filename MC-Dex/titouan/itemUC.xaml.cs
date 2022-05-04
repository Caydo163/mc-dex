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

namespace MC_Dex
{
    /// <summary>
    /// Logique d'interaction pour itemUC.xaml
    /// </summary>
    public partial class itemUC : UserControl
    {

        public itemUC()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public string Nom
        {
            set
            {
                NomItem.Text = value;
            }
        }

        public string ImageName
        {
            set
            {
                SrcImg.Source = new BitmapImage(new Uri(value, UriKind.Relative));
            }
        }

        public void Button_item(object sender, RoutedEventArgs e)
        {
            //.contentControl.Content = new pageObjet();
        }
    }
}
