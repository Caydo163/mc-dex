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
using System.Diagnostics;

namespace MC_Dex
{
    /// <summary>
    /// Logique d'interaction pour textBoxCraftUC.xaml
    /// </summary>
    public partial class textBoxCraftUC : UserControl
    {
        public textBoxCraftUC()
        {
            InitializeComponent();
        }

        private void Button1(object sender, RoutedEventArgs e)
        {
            if(! PopUpListObject.popUpOpen)
            {
                Debug.WriteLine(Mouse.GetPosition(null));
                PopUpListObject popUp = new PopUpListObject();
                //popUp.WindowStartupLocation = WindowStartupLocation.Manual;
                //popUp.Top = PointToScreen(Mouse.GetPosition(null)).X;
                //popUp.Left = PointToScreen(Mouse.GetPosition(null)).Y;
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }
        private void Button2(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                Debug.WriteLine(Mouse.GetPosition(null));
                PopUpListObject popUp = new PopUpListObject();
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }
        private void Button3(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                Debug.WriteLine(Mouse.GetPosition(null));
                PopUpListObject popUp = new PopUpListObject();
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }
        private void Button4(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                Debug.WriteLine(Mouse.GetPosition(null));
                PopUpListObject popUp = new PopUpListObject();
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }
        private void Button5(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                Debug.WriteLine(Mouse.GetPosition(null));
                PopUpListObject popUp = new PopUpListObject();
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }
        private void Button6(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                Debug.WriteLine(Mouse.GetPosition(null));
                PopUpListObject popUp = new PopUpListObject();
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }
        private void Button7(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                Debug.WriteLine(Mouse.GetPosition(null));
                PopUpListObject popUp = new PopUpListObject();
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }
        private void Button8(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                Debug.WriteLine(Mouse.GetPosition(null));
                PopUpListObject popUp = new PopUpListObject();
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }
        private void Button9(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                Debug.WriteLine(Mouse.GetPosition(null));
                PopUpListObject popUp = new PopUpListObject();
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }
        private void Button10(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                Debug.WriteLine(Mouse.GetPosition(null));
                PopUpListObject popUp = new PopUpListObject();
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }
    }
}
