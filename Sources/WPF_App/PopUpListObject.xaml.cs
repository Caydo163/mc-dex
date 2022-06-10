using Modele;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using WPF_App.converter;
using Path = System.IO.Path;

namespace WPF_App
{
    /// <summary>
    /// Logique d'interaction pour PopUpListObject.xaml
    /// </summary>
    public partial class PopUpListObject : Window
    {
        /// <summary>
        /// Manager
        /// </summary>
        public static Manager Mgr => ((App)Application.Current).LeManager;

        /// <summary>
        /// Booléen pour savoir si un pop up est ouvert ou non
        /// </summary>
        public static bool popUpOpen = false;

        /// <summary>
        /// UserControl pour pouvoir modifier son contenu
        /// </summary>
        public textBoxCraftUC Craft { get; set; }

        /// <summary>
        /// Entier pour avoir la position du bouton à modifier
        /// </summary>
        public int Pos { get; set; }


        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public PopUpListObject(MainWindow window)
        {
            InitializeComponent();
            DataContext = Mgr;
            // Si le mode nether est activé, on change l'arrière plan
            if (window.ModeNether)
            {
                backgroundPopUpList.ImageSource = new BitmapImage(new Uri("img\\background_nether.png", UriKind.Relative));
                backgroundMenuPopUpList.ImageSource = new BitmapImage(new Uri("WPF_App\\img\\menu_background_nether.png", UriKind.Relative));
            }
        }

        /// <summary>
        /// Méthode permettant d'affciher les items correspondant à la recherche entré par l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RechercheItem(object sender, TextChangedEventArgs args)
        {
            Mgr.Rechercher(textBox_RechercheItem.Text);
            Mgr.modeRecherche = true;
            listBoxItem.ItemsSource = Mgr.ItemsRecherche;
        }


        /// <summary>
        /// Bouton "VALIDER" qui ferme le pop up et changer l'image du bouton cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            if (listBoxItem.SelectedIndex > -1)
            {
                // On récupère la liste d'items en fonction du mode actuel
                ReadOnlyCollection<Item> listItems;
                if(Mgr.modeRecherche)
                {
                    listItems = new ReadOnlyCollection<Item>(Mgr.ItemsRecherche);
                }
                else
                {
                    listItems = new ReadOnlyCollection<Item>(Mgr.Items);
                }

                // Switch pour pouvoir modifier le bon bouton
                string currentDir = new(Path.Combine(Directory.GetCurrentDirectory(), "img"));
                switch (Pos)
                {
                    case 1:
                        // Si l'item sélectionné correspond à l'item "Bloc Vide" (Id = "999:1"), on afficher le bouton de base et on change la valeur de l'item à null dans la liste
                        if (listItems[listBoxItem.SelectedIndex].Id == "999:1")
                        {
                            Craft.Button1_Image.Source = new BitmapImage(new Uri("..\\..\\..\\img\\ajouter.png", UriKind.Relative));
                            Craft.ListItemCraft[Pos - 1] = null;
                        }
                        // Sinon on affcihe l'image de l'item sélectionné et on ajoute l'item dans la liste
                        else
                        {
                            Craft.Button1_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, listItems[listBoxItem.SelectedIndex].Image), UriKind.RelativeOrAbsolute));
                            Craft.ListItemCraft[Pos - 1] = listItems[listBoxItem.SelectedIndex];
                        }
                        break;

                    case 2:
                        if (listItems[listBoxItem.SelectedIndex].Id == "999:1")
                        {
                            Craft.Button2_Image.Source = new BitmapImage(new Uri("..\\..\\..\\img\\ajouter.png", UriKind.Relative));
                            Craft.ListItemCraft[Pos - 1] = null;
                        }
                        else
                        {
                            Craft.Button2_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, listItems[listBoxItem.SelectedIndex].Image), UriKind.RelativeOrAbsolute));
                            Craft.ListItemCraft[Pos - 1] = listItems[listBoxItem.SelectedIndex];
                        }
                        break;

                    case 3:
                        if (listItems[listBoxItem.SelectedIndex].Id == "999:1")
                        {
                            Craft.Button3_Image.Source = new BitmapImage(new Uri("..\\..\\..\\img\\ajouter.png", UriKind.Relative));
                            Craft.ListItemCraft[Pos - 1] = null;
                        }
                        else
                        {
                            Craft.Button3_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, listItems[listBoxItem.SelectedIndex].Image), UriKind.RelativeOrAbsolute));
                            Craft.ListItemCraft[Pos - 1] = listItems[listBoxItem.SelectedIndex];
                        }
                        break;

                    case 4:
                        if (listItems[listBoxItem.SelectedIndex].Id == "999:1")
                        {
                            Craft.Button4_Image.Source = new BitmapImage(new Uri("..\\..\\..\\img\\ajouter.png", UriKind.Relative));
                            Craft.ListItemCraft[Pos - 1] = null;
                        }
                        else
                        {
                            Craft.Button4_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, listItems[listBoxItem.SelectedIndex].Image), UriKind.RelativeOrAbsolute));
                            Craft.ListItemCraft[Pos - 1] = listItems[listBoxItem.SelectedIndex];
                        }
                        break;

                    case 5:
                        if (listItems[listBoxItem.SelectedIndex].Id == "999:1")
                        {
                            Craft.Button5_Image.Source = new BitmapImage(new Uri("..\\..\\..\\img\\ajouter.png", UriKind.Relative));
                            Craft.ListItemCraft[Pos - 1] = null;
                        }
                        else
                        {
                            Craft.Button5_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, listItems[listBoxItem.SelectedIndex].Image), UriKind.RelativeOrAbsolute));
                            Craft.ListItemCraft[Pos - 1] = listItems[listBoxItem.SelectedIndex];
                        }
                        break;

                    case 6:
                        if (listItems[listBoxItem.SelectedIndex].Id == "999:1")
                        {
                            Craft.Button6_Image.Source = new BitmapImage(new Uri("..\\..\\..\\img\\ajouter.png", UriKind.Relative));
                            Craft.ListItemCraft[Pos - 1] = null;
                        }
                        else
                        {
                            Craft.Button6_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, listItems[listBoxItem.SelectedIndex].Image), UriKind.RelativeOrAbsolute));
                            Craft.ListItemCraft[Pos - 1] = listItems[listBoxItem.SelectedIndex];
                        }
                        break;

                    case 7:
                        if (listItems[listBoxItem.SelectedIndex].Id == "999:1")
                        {
                            Craft.Button7_Image.Source = new BitmapImage(new Uri("..\\..\\..\\img\\ajouter.png", UriKind.Relative));
                            Craft.ListItemCraft[Pos - 1] = null;
                        }
                        else
                        {
                            Craft.Button7_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, listItems[listBoxItem.SelectedIndex].Image), UriKind.RelativeOrAbsolute));
                            Craft.ListItemCraft[Pos - 1] = listItems[listBoxItem.SelectedIndex];
                        }
                        break;

                    case 8:
                        if (listItems[listBoxItem.SelectedIndex].Id == "999:1")
                        {
                            Craft.Button8_Image.Source = new BitmapImage(new Uri("..\\..\\..\\img\\ajouter.png", UriKind.Relative));
                            Craft.ListItemCraft[Pos - 1] = null;
                        }
                        else
                        {
                            Craft.Button8_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, listItems[listBoxItem.SelectedIndex].Image), UriKind.RelativeOrAbsolute));
                            Craft.ListItemCraft[Pos - 1] = listItems[listBoxItem.SelectedIndex];
                        }
                        break;

                    case 9:
                        if (listItems[listBoxItem.SelectedIndex].Id == "999:1")
                        {
                            Craft.Button9_Image.Source = new BitmapImage(new Uri("..\\..\\..\\img\\ajouter.png", UriKind.Relative));
                            Craft.ListItemCraft[Pos - 1] = null;
                        }
                        else
                        {
                            Craft.Button9_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, listItems[listBoxItem.SelectedIndex].Image), UriKind.RelativeOrAbsolute));
                            Craft.ListItemCraft[Pos - 1] = listItems[listBoxItem.SelectedIndex];
                        }
                        break;

                    case 10:
                        if (listItems[listBoxItem.SelectedIndex].Id == "999:1")
                        {
                            Craft.Button10_Image.Source = new BitmapImage(new Uri("..\\..\\..\\img\\ajouter.png", UriKind.Relative));
                            Craft.ListItemCraft[Pos - 1] = null;
                        }
                        else
                        {
                            Craft.Button10_Image.Source = new BitmapImage(new Uri(Path.Combine(currentDir, listItems[listBoxItem.SelectedIndex].Image), UriKind.RelativeOrAbsolute));
                            Craft.ListItemCraft[Pos - 1] = listItems[listBoxItem.SelectedIndex];
                        }
                        break;

                }
        }
        // On ferme le pop up
        popUpOpen = false;
        this.Close();
        }

    }
}
