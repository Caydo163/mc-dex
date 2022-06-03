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
        /// <summary>
        /// Manager
        /// </summary>
        public static Manager Mgr => ((App)Application.Current).LeManager;

        /// <summary>
        /// Fenêtre de l'application
        /// </summary>
        public MainWindow Window { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public PageAjouter()
        {
            InitializeComponent();
            Mgr.ModeAjouter(true);
        }

        /// <summary>
        /// Liste des textbox contenant les crafts de l'item
        /// </summary>
        public List<textBoxCraftUC> listeTextBoxCraft = new();

        /// <summary>
        /// Bouton pour ajouter un craft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AjouterCraft(object sender, RoutedEventArgs e)
        {
            textBoxCraftUC box = new()
            {
                Window = Window,
            };
            listeTextBoxCraft.Add(box);
            panelBlocAjout.Children.Add(box);
        }

        /// <summary>
        /// Liste des textbox contenant les textes de l'item
        /// </summary>
        private List<textBoxBaseUC> listeTextBoxBase = new();
        private void Button_AjouterTexte(object sender, RoutedEventArgs e)
        {
            textBoxBaseUC box = new();
            listeTextBoxBase.Add(box);
            panelBlocAjout.Children.Add(box);
        }

        /// <summary>
        /// Textbox contenant les statistiques de l'item
        /// </summary>
        private TextBoxStatistiqueUC? textBoxStat = null;

        /// <summary>
        /// Bouton pour ajouter des statistiques
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AjouterStat(object sender, RoutedEventArgs e)
        {
            textBoxStat = new TextBoxStatistiqueUC();

            panelBlocAjout.Children.Add(textBoxStat);
            HideButtonStat.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Nom anglais de l'item
        /// </summary>
        private textBoxUC? textBoxNomE = null;

        /// <summary>
        /// Bouton pour ajouter un nom anglais à l'item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AjouterNomE(object sender, RoutedEventArgs e)
        {
            textBoxNomE = new textBoxUC()
            {
                Nom = "Nom (anglais)"
            };
            panelBlocAjout.Children.Add(textBoxNomE);
            HideButtonName.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Image de l'item
        /// </summary>
        private string image;

        /// <summary>
        /// Bouton pour ajouter une image à l'item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// Méthode permettant de vérifier la validité des informations entrées par l'utilisateur
        /// </summary>
        /// <returns></returns>
        private bool Verif_textBox()
        {
            // Bouléen pour savoir si il y a des erreurs
            bool check = false;

            // On cache tous les messages d'erreurs
            textBoxId.MessageErreur.Visibility = Visibility.Collapsed;
            textBoxNom.MessageErreur.Visibility = Visibility.Collapsed;
            MessageErreurDesc.Visibility = Visibility.Collapsed;
            MessageErreurImg.Visibility = Visibility.Collapsed;
            foreach(textBoxCraftUC elt in listeTextBoxCraft)
            {
                elt.MessageErreurNbItem.Visibility = Visibility.Collapsed;
            }
            
            // Test de l'identifiant
            string id = textBoxId.textBox.Text;
            if (id == "")
            {
                textBoxId.MessageErreur.Text = "Erreur : Veuillez entrer un identifiant";
                textBoxId.MessageErreur.Visibility = Visibility;
                check = true;
            }
            else
            {
                if (!Regex.IsMatch(id, @"^[0-9:]+$") || id[0] == '0')
                {
                    textBoxId.MessageErreur.Text = "Erreur : Veuillez entrer un identifiant au bon format (chiffre et \":\")";
                    textBoxId.MessageErreur.Visibility = Visibility;
                    check = true;
                }
                else
                {
                    // Si l'identifiant est valide, on vérifie s'il est disponible
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

            }

            // Test du nom
            if (textBoxNom.textBox.Text == "")
            {
                textBoxNom.MessageErreur.Text = "Erreur : Veuillez entrer un nom";
                textBoxNom.MessageErreur.Visibility = Visibility;
                check = true;
            }

            // Test de la description
            if(textBoxDesc.Text == "")
            {
                MessageErreurDesc.Visibility = Visibility;
                check = true;
            }

            // Test de l'image
            if(image == null)
            {
                MessageErreurImg.Visibility = Visibility;
                check = true;
            }

            // Test des crafts
            foreach (textBoxCraftUC elt in listeTextBoxCraft)
            {
                if ((!Regex.IsMatch(elt.nbrItemObtenu.Text, @"^[0-9]+$") || elt.nbrItemObtenu.Text.Length > 3) && elt.nbrItemObtenu.Text != "")
                {
                    elt.MessageErreurNbItem.Visibility = Visibility;
                    check = true;
                }
            }

            return check;
        }

        /// <summary>
        /// Bouton pour ajouter l'item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            // On vérifie si il n'y a pas d'erreur de saisie
            bool check = Verif_textBox();

            if (!check)
            {
                // Déclaration et initialisation des variables
                string desc = textBoxDesc.Text;
                string nom = textBoxNom.textBox.Text;
                string id = textBoxId.textBox.Text;
                string nomE = "";
                List<KeyValuePair<string, string>> listeTexte = new();
                Dictionary<string, string> listeStats = new();

                // Récupération du nom anglais
                if (textBoxNomE != null)
                {
                    nomE = textBoxNomE.textBox.Text;
                }

                // Récupération des textes
                foreach (textBoxBaseUC elt in listeTextBoxBase)
                {
                    listeTexte.Add(new KeyValuePair<string, string>(elt.textBoxTitre.Text, elt.textBoxTexte.Text));
                }

                // Récupération des statistiques
                if (textBoxStat != null)
                {
                    foreach (ligneGridStatUC elt in textBoxStat.listLigneStat)
                    {
                        listeStats.Add(elt.nomStat.Text, elt.valStat.Text);
                    }
                }

                // On créé l'item
                Item item = Mgr.AjouterItem(nom, nomE, id, image, desc, listeTexte, listeStats);


                // Regarder si elt vide
                foreach(textBoxCraftUC elt in listeTextBoxCraft)
                {
                    int nb = 1;
                    if (elt.nbrItemObtenu.Text != "")
                    {
                        nb = Convert.ToInt16(elt.nbrItemObtenu.Text);
                    }

                    List<Item> temp = new(elt.ListItemCraft);


                    // Remplacer par LINQ ?
                    foreach (Item i in elt.ListItemCraft)
                    {
                        if (i != null && i.Id == "999:2")
                        {
                            temp[temp.IndexOf(i)] = item;
                        }
                    }

                    //item.AjouterCraft(elt.ListItemCraft[0], elt.ListItemCraft[1], elt.ListItemCraft[2], elt.ListItemCraft[3], elt.ListItemCraft[4], elt.ListItemCraft[5], elt.ListItemCraft[6],
                    //    elt.ListItemCraft[7], elt.ListItemCraft[8], nb, elt.ListItemCraft[9]);
                    item.AjouterCraft(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6], temp[7], temp[8], nb, temp[9]);
                }


                Mgr.ModeAjouter(false);

                // On affiche la page d'accueil
                home Home = new()
                {
                    Window = Window
                };
                Window.contentControl.Content = Home;

            }
        }

        }

    }

