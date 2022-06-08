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
    /// Logique d'interaction pour grilleCraftUC.xaml
    /// </summary>
    public partial class grilleCraftUC : UserControl
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public grilleCraftUC()
        {
            InitializeComponent();
        }

        
        public string ImageName1
        {
            set
            {
                Image1.Source = new BitmapImage(new Uri(value, UriKind.RelativeOrAbsolute));
            }
        }
        public string ImageName2
        {
            set
            {
                Image2.Source = new BitmapImage(new Uri(value, UriKind.RelativeOrAbsolute));
            }
        }
        public string ImageName3
        {
            set
            {
                Image3.Source = new BitmapImage(new Uri(value, UriKind.RelativeOrAbsolute));
            }
        }
        public string ImageName4
        {
            set
            {
                Image4.Source = new BitmapImage(new Uri(value, UriKind.RelativeOrAbsolute));
            }
        }
        public string ImageName5
        {
            set
            {
                Image5.Source = new BitmapImage(new Uri(value, UriKind.RelativeOrAbsolute));
            }
        }
        public string ImageName6
        {
            set
            {
                Image6.Source = new BitmapImage(new Uri(value, UriKind.RelativeOrAbsolute));
            }
        }
        public string ImageName7
        {
            set
            {
                Image7.Source = new BitmapImage(new Uri(value, UriKind.RelativeOrAbsolute));
            }
        }
        public string ImageName8
        {
            set
            {
                Image8.Source = new BitmapImage(new Uri(value, UriKind.RelativeOrAbsolute));
            }
        }
        public string ImageName9
        {
            set
            {
                Image9.Source = new BitmapImage(new Uri(value, UriKind.RelativeOrAbsolute));
            }
        }
        public string ImageName10
        {
            set
            {
                Image10.Source = new BitmapImage(new Uri(value, UriKind.RelativeOrAbsolute));
            }
        }
    }
}
