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

namespace WPF_App
{
    /// <summary>
    /// Logique d'interaction pour pageRechercher.xaml
    /// </summary>
    public partial class barreRecherche : UserControl
    {
        public MainWindow Window { get; set; }
        public home Home { get; set; }
        public static Manager Mgr => ((App)Application.Current).LeManager;
        public barreRecherche()
        {
            InitializeComponent();
        }

        public void Button_Rechercher(object sender, RoutedEventArgs e)
        {
            Rechercher();
            this.Visibility = Visibility.Collapsed;
        }

        private void ToucheEntree(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                Rechercher();
                this.Visibility = Visibility.Collapsed;
            }
        }

        private void textBoxChanged_Recherche(object sender, TextChangedEventArgs args)
        {
            Mgr.Rechercher(textBox_Recherche.Text);
            Mgr.modeRecherche = true;
            Home.listBox.ItemsSource = Mgr.ItemsRecherche;
        }

        private void Rechercher()
        {
            Mgr.Rechercher(textBox_Recherche.Text);
            Mgr.modeRecherche = true;
            Home.listBox.ItemsSource = Mgr.ItemsRecherche;
        }
    }
}
