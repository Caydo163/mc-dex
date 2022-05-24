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

namespace MC_Dex
{
    /// <summary>
    /// Logique d'interaction pour PopUpDemandeSuppression.xaml
    /// </summary>
    /// 
    public partial class PopUpDemandeSuppression : Window
    {
        public static Manager Mgr => ((App)Application.Current).LeManager;
        public static bool popUpOpen = false;
        public PopUpDemandeSuppression()
        {
            InitializeComponent();
            Mgr.LoadItems();
            DataContext = Mgr.SelectedItem;
        }

        private void Button_Confirmer(object sender, RoutedEventArgs e)
        {
            this.Close();
            popUpOpen = false;
        }
    }
}
