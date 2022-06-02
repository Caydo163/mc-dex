using Modele;
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

namespace WPF_App
{
    /// <summary>
    /// Logique d'interaction pour PopUpDemandeSuppression.xaml
    /// </summary>
    /// 
    public partial class PopUpDemandeSuppression : Window
    {
        public MainWindow Window { get; set; }
        public static Manager Mgr => ((App)Application.Current).LeManager;
        public static bool popUpOpen = false;
        public PopUpDemandeSuppression()
        {
            InitializeComponent();
            DataContext = Mgr.SelectedItem;
            //if(Window.ModeNether)
            //{
            //    backgroundPopUpSuppr.ImageSource = new BitmapImage(new Uri("..\\..\\..\\img\\background_nether.png", UriKind.Relative));
            //}
        }

        private void Button_Confirmer(object sender, RoutedEventArgs e)
        {
            Mgr.SupprimerItem(Mgr.SelectedItem);
            popUpOpen = false;
            home pageH = new()
            {
                Window = Window
            };
            Window.contentControl.Content = pageH;
            this.Close();
        }

        private void Button_Annuler(object sender, RoutedEventArgs e)
        {
            popUpOpen = false;
            this.Close();
        }
    }
}
