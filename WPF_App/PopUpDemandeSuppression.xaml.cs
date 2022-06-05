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
        /// <summary>
        /// Fenêtre de l'application
        /// </summary>
        public MainWindow Window { get; set; }

        /// <summary>
        /// Manager
        /// </summary>
        public static Manager Mgr => ((App)Application.Current).LeManager;

        /// <summary>
        /// Booléen pour savoir si un pop up est ouvert ou non
        /// </summary>
        public static bool popUpOpen = false;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="window"></param>
        public PopUpDemandeSuppression(MainWindow window)
        {
            InitializeComponent();
            DataContext = Mgr.SelectedItem;
            Window = window;
            // Si le mode nether est activé, on change l'arrière plan
            if (Window.ModeNether)
            {
                backgroundPopUpSuppr.ImageSource = new BitmapImage(new Uri("..\\..\\..\\WPF_App\\img\\background_nether.png", UriKind.Relative));
            }
        }

        /// <summary>
        /// Bouton pour confirmer la suppression de l'item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        // Bouton pour annuler la suppression de l'item
        private void Button_Annuler(object sender, RoutedEventArgs e)
        {
            popUpOpen = false;
            this.Close();
        }
    }
}
