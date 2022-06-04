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
    /// Logique d'interaction pour home.xaml
    /// </summary>
    public partial class home : UserControl
    {
        /// <summary>
        /// Manager
        /// </summary>
        public static Manager Mgr => ((App)Application.Current).LeManager;

        /// <summary>
        /// Fenêtre de l'application
        /// </summary>
        private MainWindow window;
        public MainWindow Window { 
            get => window; 
            set
            {
                window = value;
                barreRecherche.Window = value;
            } 
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public home()
        {
            InitializeComponent();
            DataContext = Mgr;
            if(Mgr.modeRecherche)
            {
                listBox.ItemsSource = Mgr.ItemsRecherche;
            }
            else
            {
                listBox.ItemsSource = Mgr.Items;
            }
            barreRecherche.Home = this;
        }

        /// <summary>
        /// Méthode permettant d'afficher la page de l'objet sélectionné par l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void ChoixItem(object sender, SelectionChangedEventArgs args)
        {
            if(Mgr.modeRecherche)
            {
                Mgr.SelectedItem = Mgr.ItemsRecherche[listBox.SelectedIndex];
            }
            else
            {
                Mgr.SelectedItem = Mgr.Items[listBox.SelectedIndex];
            }
            pageObjet pageO = new();
            Window.Title = "Item - " + Mgr.SelectedItem.Nom;
            pageO.Window = Window;
            pageO.chargementHome();
            Window.contentControl.Content = pageO;
        }
    }
}
