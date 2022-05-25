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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Manager Mgr => ((App)Application.Current).LeManager;
        public MainWindow()
        {
            InitializeComponent();

            Mgr.LoadItems();
            DataContext = Mgr;
        }

        public void Button_home(object sender, RoutedEventArgs e)
        {
            this.Title = "MC-DEX - Accueil";
            home pageH = new();
            pageH.Window = this;
            contentControl.Content = pageH;

        }

        public void Button_ajouter(object sender, RoutedEventArgs e)
        {
            PageAjouter pageA = new();
            pageA.Window = this;
            contentControl.Content = pageA ;
            
            this.Title = "MC-DEX - Ajouter";

        }

        public void Button_rechercher(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new pageRechercher();
            this.Title = "MC-DEX - Rechercher";
        }
    }
}
