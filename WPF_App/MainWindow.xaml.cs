using Modele;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Manager
        /// </summary>
        public static Manager Mgr => ((App)Application.Current).LeManager;

        /// <summary>
        /// Booléen pour connaitre le mode actuel de l'application (Nether / Overworld)
        /// </summary>
        public bool ModeNether = false;

        /// <summary>
        /// Constructeur
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // On ajoute la page accueil puis on charge les données
            home Home = new()
            {
                Window = this
            };
            contentControl.Content = Home;
            Mgr.LoadItems();
            DataContext = Mgr;
        }

        /// <summary>
        /// Méthode permettant de désactiver le mode ajouter et de sauvegarder les items si la fenêtre est fermé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Mgr.ModeAjouter(false);
            Mgr.SaveItems();

            // On supprime les images des items supprimés
            //foreach(string elt in Mgr.images_a_supprimer)
            //{
            //    File.Delete(elt);
            //}
        }

        /// <summary>
        /// Méthode permettant d'afficher une message box
        /// </summary>
        /// <returns>Booléen en fonction de la réponse de l'utilisateur</returns>
        private static bool MessageConfirmationFermeturePageA()
        {
            MessageBoxResult choix = MessageBox.Show("Voulez-vous vraiment quitter la page ajouter ?\nVos informations ne seront pas sauvegardé.", 
                "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No);

            switch(choix)
            {
                case MessageBoxResult.Yes:
                    Mgr.ModeAjouter(false);
                    return true;
                case MessageBoxResult.No:
                    return false;
            }
            return false;

        }

        /// <summary>
        /// Méthode permettant de tester si il y a une collision.
        /// 1 - Changement de page alors qu'un popup est ouvert
        /// 2 - Chanegement de page lorsque l'utilisateur est sur la page ajouter
        /// </summary>
        /// <returns></returns>
        private bool TestCollision()
        {
            if (PopUpListObject.popUpOpen || PopUpDemandeSuppression.popUpOpen)
            {
                return false;
            }
            if (contentControl.Content.GetType() == typeof(PageAjouter))
            {
                return MessageConfirmationFermeturePageA();
            }
            return true;
        }

        /// <summary>
        /// Bouton permettant d'aller sur la page d'accueil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Button_home(object sender, RoutedEventArgs e)
        {
            if(TestCollision())
            {
                this.Title = "MC-DEX - Accueil";
                Mgr.modeRecherche = false;
                home pageH = new()
                {
                    Window = this
                };
                contentControl.Content = pageH;
            }
        }

        /// <summary>
        /// Bouton permettant de changer le thème de l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Button_theme(object sender, RoutedEventArgs e)
        {
            if(!ModeNether)
            {
                backgroundApp.ImageSource = new BitmapImage(new Uri("..\\..\\..\\WPF_App\\img\\background_nether.png", UriKind.Relative));
                backgroundMenu.ImageSource = new BitmapImage(new Uri("..\\..\\..\\WPF_App\\img\\menu_background_nether.png", UriKind.Relative));
                imageBoutonTheme.Source = new BitmapImage(new Uri("img\\bouton_mode_overworld.png", UriKind.Relative));
                Application.Current.Resources["MainColor"] = new SolidColorBrush(Color.FromRgb(19, 126, 134));
                ModeNether = true;
            }
            else
            {
                backgroundApp.ImageSource = new BitmapImage(new Uri("..\\..\\..\\WPF_App\\img\\background2.png", UriKind.Relative));
                backgroundMenu.ImageSource = new BitmapImage(new Uri("..\\..\\..\\WPF_App\\img\\menu_background.png", UriKind.Relative));
                imageBoutonTheme.Source = new BitmapImage(new Uri("img\\bouton_mode_nether.png", UriKind.Relative));
                Application.Current.Resources["MainColor"] = new SolidColorBrush(Color.FromRgb(83, 143, 40));
                ModeNether = false;
            }

        }

        /// <summary>
        /// Bouton permettant d'aller sur la page ajouter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Button_ajouter(object sender, RoutedEventArgs e)
        {
            if(TestCollision())
            {
                PageAjouter pageA = new(false,this)
                {
                    Window = this
                };
                contentControl.Content = pageA;
                this.Title = "MC-DEX - Ajouter";
            }

        }

        /// <summary>
        /// Bouton permettant d'afficher la barre de recherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Button_rechercher(object sender, RoutedEventArgs e)
        {
            if (TestCollision())
            {
                this.Title = "MC-DEX - Recherche";
                Mgr.modeRecherche = false;
                home pageH = new()
                {
                    Window = this
                };
                pageH.barreRecherche.Visibility = Visibility;

                contentControl.Content = pageH;
                pageH.barreRecherche.textBox_Recherche.Focusable = true;
                pageH.barreRecherche.textBox_Recherche.Focus();
            }
        }
    }
}
