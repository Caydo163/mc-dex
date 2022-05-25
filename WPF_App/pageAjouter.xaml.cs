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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Modele;

namespace MC_Dex
{
    /// <summary>
    /// Logique d'interaction pour pageAjouter.xaml
    /// </summary>
    public partial class PageAjouter : UserControl
    {
        public static Manager Mgr => ((App)Application.Current).LeManager;
        public MainWindow Window { get; set; }

        public PageAjouter()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_AjouterCraft(object sender, RoutedEventArgs e)
        {
            textBoxCraftUC box = new();
            panelBlocAjout.Children.Add(box);
        }

        private List<textBoxBaseUC> listeTextBoxBase = new List<textBoxBaseUC>();
        private void Button_AjouterTexte(object sender, RoutedEventArgs e)
        {
            textBoxBaseUC box = new();
            listeTextBoxBase.Add(box);
            panelBlocAjout.Children.Add(box);
        }

        private TextBoxStatistiqueUC? textBoxStat = null;
        private void Button_AjouterStat(object sender, RoutedEventArgs e)
        {
            textBoxStat = new TextBoxStatistiqueUC();

            panelBlocAjout.Children.Add(textBoxStat);
            HideButtonStat.Visibility = Visibility.Collapsed;
        }

        private textBoxUC? textBoxNomE = null;
        private void Button_AjouterNomE(object sender, RoutedEventArgs e)
        {
            textBoxNomE = new textBoxUC()
            {
                Nom = "Nom (anglais)"
            };
            panelBlocAjout.Children.Add(textBoxNomE);
            HideButtonName.Visibility = Visibility.Collapsed;
        }

        private String image;
        private void Button_OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new()
            {
                Filter = "Image File (*.png;*.jpeg) | *.png;*.jpeg"
            };
            if (ofd.ShowDialog() == true)
            {
                TextBlockPathFile.Text = ofd.FileName;
                image = ofd.FileName;
            }
            
        }

        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            //(Application.Current as App).MainWindow.abc =
            String desc = textBoxDesc.Text;
            String nom = textBoxNom.textBox.Text;
            String nomE = "";
            String id = textBoxId.textBox.Text;

            if (nom == "" || id == "" || desc == "")
            {
                return;
                // Afficher message dans text box si vide
            }

            List<KeyValuePair<string, string>> listeTexte = new() ;
            Dictionary<string, double> listeStats = new() ;

            listeTexte = new List<KeyValuePair<string, string>>();
            if (textBoxNomE != null)
            {
                nomE = textBoxNomE.textBox.Text;
            }
            foreach(textBoxBaseUC elt in listeTextBoxBase)
            {
                listeTexte.Add(new KeyValuePair<string, string>(elt.textBoxTitre.Text, elt.textBoxTexte.Text));
            }
            if (listeTextBoxBase.Any())
            {
                TextBlockPathFile.Text = listeTexte[0].Key;
            }
            if(textBoxStat != null)
            {
                foreach(int value in Enumerable.Range(1,textBoxStat.nbStat))
                {
                    //listeStats.Add(textBoxStat.ligneStat1.nomStat.Text, Convert.ToDouble(textBoxStat.ligneStat1.valStat.Text));
                    // creer liste de ligneGridStatUC dans textboxStatistique
                    // foreach dans cette liste
                    
                }
            }


            Mgr.AjouterItem(nom, nomE, id, image, desc, listeTexte);

            home Home = new();
            Home.Window = Window;
            Window.contentControl.Content = Home;

        }
    }
}
