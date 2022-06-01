using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WPF_App;

namespace WPF_App
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

        public List<textBoxCraftUC> listeTextBoxCraft = new();
        private void Button_AjouterCraft(object sender, RoutedEventArgs e)
        {
            textBoxCraftUC box = new();
            listeTextBoxCraft.Add(box);
            panelBlocAjout.Children.Add(box);
        }

        private List<textBoxBaseUC> listeTextBoxBase = new();
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

        private string image;
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
        
        private bool verif_textBox()
        {
            string id = textBoxId.textBox.Text;
            bool check = false;

            textBoxId.MessageErreur.Visibility = Visibility.Collapsed;
            textBoxNom.MessageErreur.Visibility = Visibility.Collapsed;
            MessageErreurDesc.Visibility = Visibility.Collapsed;
            MessageErreurImg.Visibility = Visibility.Collapsed;

            if (!Regex.IsMatch(id, @"^[0-9:]+$") || id[0] == '0')
            {
                textBoxId.MessageErreur.Text = "Erreur : Veuillez entrer un identifiant au bon format (chiffre et \":\")";
                textBoxId.MessageErreur.Visibility = Visibility;
                check = true;
            }
            if (id == "")
            {
                textBoxId.MessageErreur.Text = "Erreur : Veuillez entrer un identifiant";
                textBoxId.MessageErreur.Visibility = Visibility;
                check = true;
            }

            if (id == "")
            {
                textBoxId.MessageErreur.Text = "Erreur : Veuillez entrer un identifiant";
                textBoxId.MessageErreur.Visibility = Visibility;
                check = true;
            }
            else
            {
                foreach (Item elt in Mgr.Items)
                {
                    if (elt.Id == id)
                    {
                        textBoxId.MessageErreur.Text = "Erreur : Cet identifiant est deja pris";
                        textBoxId.MessageErreur.Visibility = Visibility;
                        check = true;
                        break;
                    }
                }
            }
            if (textBoxNom.textBox.Text == "")
            {
                textBoxNom.MessageErreur.Text = "Erreur : Veuillez entrer un nom";
                textBoxNom.MessageErreur.Visibility = Visibility;
                check = true;
            }
            if(textBoxDesc.Text == "")
            {
                MessageErreurDesc.Visibility = Visibility;
                check = true;
            }
            if(image == null)
            {
                MessageErreurImg.Visibility = Visibility;
                check = true;
            }

            return check;
        }

        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            //(Application.Current as App).MainWindow.abc =
            string desc = textBoxDesc.Text;
            string nom = textBoxNom.textBox.Text;
            string id = textBoxId.textBox.Text;
            string nomE = "";

            bool check = verif_textBox();

            if (!check)
            {
                List<KeyValuePair<string, string>> listeTexte = new();
                Dictionary<string, string> listeStats = new();

                //listeTexte = new List<KeyValuePair<string, string>>();
                if (textBoxNomE != null)
                {
                    nomE = textBoxNomE.textBox.Text;
                }

                foreach (textBoxBaseUC elt in listeTextBoxBase)
                {
                    listeTexte.Add(new KeyValuePair<string, string>(elt.textBoxTitre.Text, elt.textBoxTexte.Text));
                }

                //if (listeTextBoxBase.Any())
                //{
                //    TextBlockPathFile.Text = listeTexte[0].Key;
                //}

                if (textBoxStat != null)
                {
                    foreach (ligneGridStatUC elt in textBoxStat.listLigneStat)
                    {
                        listeStats.Add(elt.nomStat.Text, elt.valStat.Text);
                    }
                }


                Mgr.AjouterItem(nom, nomE, id, image, desc, listeTexte, listeStats);

                home Home = new()
                {
                    Window = Window
                };
                Window.contentControl.Content = Home;

            }
            }
        }

    }

