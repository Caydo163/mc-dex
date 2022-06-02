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
        public MainWindow()
        {
            InitializeComponent();
            home Home = new();
            Home.Window = this;
            contentControl.Content = Home;
            Mgr.LoadItems();
            DataContext = Mgr;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Mgr.SaveItems();
        }

        private bool MessageConfirmationFermeturePageA()
        {
            MessageBoxResult choix = MessageBox.Show("Voulez-vous vraiment quitter la page ajouter ?\nVos informations ne seront pas sauvegardé.", 
                "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No);

            switch(choix)
            {
                case MessageBoxResult.Yes:
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
                home pageH = new();
                pageH.Window = this;
                contentControl.Content = pageH;
            }
        }

        public void Button_ajouter(object sender, RoutedEventArgs e)
        {
            if(TestCollision())
            {
                PageAjouter pageA = new();
                pageA.Window = this;
                contentControl.Content = pageA;
                this.Title = "MC-DEX - Ajouter";
            }

        }

        public void Button_rechercher(object sender, RoutedEventArgs e)
        {
            if(TestCollision())
            {
                pageRechercher pageR = new();
                pageR.Window = this;
                contentControl.Content = pageR;
                this.Title = "MC-DEX - Rechercher";
            }

        }
    }
}
