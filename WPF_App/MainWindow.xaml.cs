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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Manager Mgr => ((App)Application.Current).LeManager;
        public bool ModeNether = false;
        public MainWindow()
        {
            InitializeComponent();
            home Home = new()
            {
                Window = this
            };
            contentControl.Content = Home;
            Mgr.LoadItems();
            DataContext = Mgr;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Mgr.ModeAjouter(false);
            Mgr.SaveItems();
        }

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

        public void Button_theme(object sender, RoutedEventArgs e)
        {
            if(!ModeNether)
            {
                backgroundApp.ImageSource = new BitmapImage(new Uri("..\\..\\..\\img\\background_nether.png", UriKind.Relative));
                backgroundMenu.ImageSource = new BitmapImage(new Uri("..\\..\\..\\img\\menu_background_nether.png", UriKind.Relative));
                imageBoutonTheme.Source = new BitmapImage(new Uri("..\\..\\..\\img\\bouton_mode_overworld.png", UriKind.Relative));
                Application.Current.Resources["MainColor"] = new SolidColorBrush(Color.FromRgb(19, 126, 134));
                ModeNether = true;
            }
            else
            {
                backgroundApp.ImageSource = new BitmapImage(new Uri("..\\..\\..\\img\\background2.png", UriKind.Relative));
                backgroundMenu.ImageSource = new BitmapImage(new Uri("..\\..\\..\\img\\menu_background.png", UriKind.Relative));
                imageBoutonTheme.Source = new BitmapImage(new Uri("..\\..\\..\\img\\bouton_mode_nether.png", UriKind.Relative));
                Application.Current.Resources["MainColor"] = new SolidColorBrush(Color.FromRgb(83, 143, 40));
                ModeNether = false;
            }

        }

        public void Button_ajouter(object sender, RoutedEventArgs e)
        {
            if(TestCollision())
            {
                PageAjouter pageA = new()
                {
                    Window = this
                };
                contentControl.Content = pageA;
                this.Title = "MC-DEX - Ajouter";
            }

        }

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
            }
        }
    }
}
