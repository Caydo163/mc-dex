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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MC_Dex
{
    /// <summary>
    /// Logique d'interaction pour home.xaml
    /// </summary>
    public partial class home : UserControl
    {

        public static Manager Mgr => ((App)Application.Current).LeManager;
        private MainWindow window;
        public MainWindow Window { get => window; set => window = value; }
        public home()
        {
            InitializeComponent();
            DataContext = Mgr;
            //Mgr.LoadItems();
        }

        void ChoixItem(object sender, SelectionChangedEventArgs args)
        {
            Mgr.SelectedItem = Mgr.Items[listBox.SelectedIndex];

            Window.contentControl.Content = new pageObjet();
        }
    }
}
