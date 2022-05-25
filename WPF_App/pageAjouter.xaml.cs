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

        private void Button_AjouterStat(object sender, RoutedEventArgs e)
        {
            TextBoxStatistiqueUC box = new();

            panelBlocAjout.Children.Add(box);
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
            List<KeyValuePair<string, string>> listeTexte ;
            listeTexte = new List<KeyValuePair<string, string>>();
            if (textBoxNomE != null)
            {
                nomE = textBoxNomE.textBox.Text;
            }
            if(listeTextBoxBase.Any())
            {
                listeTexte.Add(new KeyValuePair<string, string>(listeTextBoxBase[0].textBoxTitre.Text, listeTextBoxBase[0].textBoxTexte.Text));
            }
            if (listeTextBoxBase.Any())
            {
                TextBlockPathFile.Text = listeTexte[0].Key;
                
            }

            Mgr.AjouterItem(nom, nomE, id, image, desc);

            home Home = new();
            Home.Window = Window;
            Window.contentControl.Content = Home;

        }
    }
}
