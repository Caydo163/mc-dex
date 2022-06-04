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
        /// <summary>
        /// Fenêtre de l'application
        /// </summary>
        public MainWindow Window { get; set; }

        /// <summary>
        /// Page home
        /// </summary>
        public home Home { get; set; }

        /// <summary>
        /// Manager
        /// </summary>
        public static Manager Mgr => ((App)Application.Current).LeManager;

        /// <summary>
        /// Constructeur
        /// </summary>
        public barreRecherche()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bouton pour rechercher et cacher la barre de recherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Button_Rechercher(object sender, RoutedEventArgs e)
        {
            Rechercher();
            this.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Touche entrer pour rechercher et cacher la barre de recherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToucheEntree(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                Rechercher();
                this.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Recherche à chaque changement dans la textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void textBoxChanged_Recherche(object sender, TextChangedEventArgs args)
        {
            Rechercher();
        }

        /// <summary>
        /// Méthode permettant d'affocher les items correspondant à la recherche
        /// </summary>
        private void Rechercher()
        {
            Mgr.Rechercher(textBox_Recherche.Text);
            Mgr.modeRecherche = true;
            Home.listBox.ItemsSource = Mgr.ItemsRecherche;
        }
    }
}
