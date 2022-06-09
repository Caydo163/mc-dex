using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;

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

        public bool ModeModifier = false;

        /// <summary>
        /// Constructeur
        /// </summary>
        public PageAjouter(bool mode,MainWindow window)
        {
            InitializeComponent();
            Window = window;
            Mgr.ModeAjouter(true);
            ModeModifier = mode;
            if(ModeModifier)
            {
                RemplissageModeModifier();
            }
        }

        private void RemplissageModeModifier()
        {
            textBoxNom.textBox.Text = Mgr.SelectedItem.Nom;
            textBoxId.textBox.Text = Mgr.SelectedItem.Id;
            textBoxDesc.Text = Mgr.SelectedItem.Desc;
            TextBlockPathFile.Text = Mgr.SelectedItem.Image;
            image = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "..\\img"), Mgr.SelectedItem.Image);

            // Nom anglais
            if (Mgr.SelectedItem.NomE != null && Mgr.SelectedItem.NomE != "")
            {
                textBoxNomE = new textBoxUC()
                {
                    Nom = "Nom (anglais)"
                };
                textBoxNomE.textBox.Text = Mgr.SelectedItem.NomE;
                panelBlocAjout.Children.Add(textBoxNomE);
                HideButtonName.Visibility = Visibility.Collapsed;
            }

            // Texte
            foreach (KeyValuePair<string, string> elt in Mgr.SelectedItem.ListeTexte)
            {
                textBoxBaseUC box = new();
                box.textBoxTitre.Text = elt.Key;
                box.textBoxTexte.Text = elt.Value;
                listeTextBoxBase.Add(box);
                panelBlocAjout.Children.Add(box);
            }

            // Stat
            if (Mgr.SelectedItem.ListeStats.Count > 0)
            {
                textBoxStat = new TextBoxStatistiqueUC();
                panelBlocAjout.Children.Add(textBoxStat);
                HideButtonStat.Visibility = Visibility.Collapsed;

                foreach (KeyValuePair<string, string> stat in Mgr.SelectedItem.ListeStats)
                {
                    textBoxStat.AjouterLigneStat(stat);
                }
            }

            // Craft
            foreach (Craft elt in Mgr.SelectedItem.ListeCraft)
            {
                textBoxCraftUC craft = new(Window)
                {
                    Window = Window,
                };

                listeTextBoxCraft.Add(craft);
                panelBlocAjout.Children.Add(craft);
                string currentDir = new(Path.Combine(Directory.GetCurrentDirectory(), "..\\img"));
                if (elt.Objet0_0 != null)
                {
                    craft.ListItemCraft[0] = elt.Objet0_0;
                    craft.Button1_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, elt.Objet0_0.Image), UriKind.RelativeOrAbsolute));
                }
                if (elt.Objet0_1 != null)
                {
                    craft.ListItemCraft[1] = elt.Objet0_1;
                    craft.Button2_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, elt.Objet0_1.Image), UriKind.RelativeOrAbsolute));
                }
                if (elt.Objet0_2 != null) 
                {
                    craft.ListItemCraft[2] = elt.Objet0_2;
                    craft.Button3_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, elt.Objet0_2.Image), UriKind.RelativeOrAbsolute));
                }
                if (elt.Objet1_0 != null) 
                {
                    craft.ListItemCraft[3] = elt.Objet1_0;
                    craft.Button4_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, elt.Objet1_0.Image), UriKind.RelativeOrAbsolute));
                }
                if (elt.Objet1_1 != null) 
                {
                    craft.ListItemCraft[4] = elt.Objet1_1;
                    craft.Button5_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, elt.Objet1_1.Image), UriKind.RelativeOrAbsolute));
                }
                if (elt.Objet1_2 != null) 
                {
                    craft.ListItemCraft[5] = elt.Objet1_2;
                    craft.Button6_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, elt.Objet1_2.Image), UriKind.RelativeOrAbsolute));
                }
                if (elt.Objet2_0 != null) 
                {
                    craft.ListItemCraft[6] = elt.Objet2_0;
                    craft.Button7_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, elt.Objet2_0.Image), UriKind.RelativeOrAbsolute));
                }
                if (elt.Objet2_1 != null) 
                {
                    craft.ListItemCraft[7] = elt.Objet2_1;
                    craft.Button8_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, elt.Objet2_1.Image), UriKind.RelativeOrAbsolute));
                }
                if (elt.Objet2_2 != null) 
                {
                    craft.ListItemCraft[8] = elt.Objet2_2;
                    craft.Button9_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, elt.Objet2_2.Image), UriKind.RelativeOrAbsolute));
                }
                if (elt.NbFinal != 1)
                {
                    craft.nbrItemObtenu.Text = elt.NbFinal.ToString();
                }
                if (elt.GetType() == typeof(CraftObjet))
                {
                    craft.ListItemCraft[9] = Mgr.SelectedItem;
                    craft.Button10_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, Mgr.SelectedItem.Image), UriKind.RelativeOrAbsolute));
                }
                else
                {
                    CraftUtilisation craftU = (CraftUtilisation)elt;
                    if (craftU.ObjetFinal.Image != null)
                    {
                        craft.ListItemCraft[9] = craftU.ObjetFinal;
                        craft.Button10_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, craftU.ObjetFinal.Image), UriKind.RelativeOrAbsolute));
                    }
                }

            }
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
            textBoxCraftUC box = new(Window)
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
                            if(ModeModifier == true && id == Mgr.SelectedItem.Id)
                            {
                                continue;
                            }
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
                    if(elt.textBoxTitre.Text != "" && elt.textBoxTexte.Text != "")
                    {
                        listeTexte.Add(new KeyValuePair<string, string>(elt.textBoxTitre.Text, elt.textBoxTexte.Text));
                    }
                    
                }

                // Récupération des statistiques
                if (textBoxStat != null)
                {
                    foreach (ligneGridStatUC elt in textBoxStat.listLigneStat)
                    {
                        if(elt.nomStat.Text != "" && elt.valStat.Text != "")
                        {
                            listeStats.Add(elt.nomStat.Text, elt.valStat.Text);
                        }
                            
                    }
                }







                if(ModeModifier)
                {
                    Mgr.SupprimerItem(Mgr.SelectedItem);
                }
                // On créé l'item
                string currentDir = new(Path.Combine(Directory.GetCurrentDirectory(), "..\\img"));
                string CheminImage;
                if (File.Exists(Path.Combine(currentDir, Path.GetFileName(image))))
                {
                    int i = 1;
                    while (File.Exists(Path.Combine(currentDir, Path.GetFileNameWithoutExtension(image) + i.ToString() + Path.GetExtension(image))))
                    {
                        i++;
                    }
                    File.Copy(image, Path.Combine(currentDir, Path.GetFileNameWithoutExtension(image) + i.ToString() + Path.GetExtension(image)));
                    CheminImage = Path.Combine(currentDir, Path.GetFileNameWithoutExtension(image) + i.ToString() + Path.GetExtension(image));
                }
                else
                {
                    File.Copy(image, Path.Combine(currentDir, Path.GetFileName(image)));
                    CheminImage = Path.Combine(currentDir, Path.GetFileName(image));
                }

                Item item = Mgr.AjouterItem(nom, nomE, id, Path.GetFileName(CheminImage), desc, listeTexte, listeStats);



                // Regarder si elt vide
                foreach(textBoxCraftUC elt in listeTextBoxCraft)
                {
                    int nb = 1;
                    if (elt.nbrItemObtenu.Text != "")
                    {
                        nb = Convert.ToInt16(elt.nbrItemObtenu.Text);
                    }

                    List<Item> temp = new(elt.ListItemCraft);


                    
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


                if(ModeModifier)
                {
                    Mgr.SelectedItem = item;
                    pageObjet pageO = new(Window);
                    Window.Title = "Item - " + Mgr.SelectedItem.Nom;
                    pageO.Window = Window;
                    pageO.chargementHome();
                    Window.contentControl.Content = pageO;
                }
                // On affiche la page d'accueil
                else
                {
                    home Home = new()
                    {
                        Window = Window
                    };
                    Window.contentControl.Content = Home;
                }

            }
        }

        }

    }

