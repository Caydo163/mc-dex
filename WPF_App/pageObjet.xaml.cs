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
using WPF_App;

namespace MC_Dex
{
    /// <summary>
    /// Logique d'interaction pour pageObjet.xaml
    /// </summary>
    public partial class pageObjet : UserControl
    {
        public static Manager Mgr => ((App)Application.Current).LeManager;
        public pageObjet()
        {
            InitializeComponent();
            Creation_Page();
        }

        private void Creation_Page()
        {
            //foreach (KeyValuePair<string, string> elt in Mgr.SelectedItem.ListeTexte)
            //{
            //    texteUC texte = new();
            //    texte.texteTitre.Text = elt.Key;
            //    texte.textePartie.Text = elt.Value;
            //    StackPanelObjet.Children.Add(texte);


            //}
        }


        private void Button_Modifier(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Supprimer(object sender, RoutedEventArgs e)
        {
            if (!PopUpDemandeSuppression.popUpOpen)
            {
                PopUpDemandeSuppression popUp = new();
                PopUpDemandeSuppression.popUpOpen = true;
                popUp.Show();
                
            }
        }
    }
}
