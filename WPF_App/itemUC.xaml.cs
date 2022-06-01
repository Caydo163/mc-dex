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

namespace WPF_App
{
    /// <summary>
    /// Logique d'interaction pour itemUC.xaml
    /// </summary>
    public partial class ItemUC : UserControl
    {

        public ItemUC()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        /*        public string Nom
                {
                    set
                    {
                        NomItem.Text = value;
                    }
                }*/

        public string Nom
        {
            get { return (string)GetValue(NomProperty); }
            set { SetValue(NomProperty, value); }
        }

        // UsingaDependencyProperty as the backing store for Texte.This enables animation,styling,binding,etc ...
        public static readonly DependencyProperty NomProperty =
            DependencyProperty.Register("Nom", typeof(string), typeof(ItemUC), new PropertyMetadata("Nom Vide"));

        /*public string ImageName
                {
                    set
                    {
                        SrcImg.Source = new BitmapImage(new Uri(value, UriKind.Relative));
                    }
                }*/


        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // UsingaDependencyProperty as the backing store for Texte.This enables animation,styling,binding,etc ...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(string), typeof(ItemUC), new PropertyMetadata("img\\terre.png"));

        public void Button_item(object sender, RoutedEventArgs e)
        {

        }
    }
}