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
using System.Windows.Shapes;

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

        public MainWindow Window { get;set; }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public PopUpListObject()
        {
            InitializeComponent();
            DataContext = Mgr;
            //if (Window.ModeNether)
            //{
            //    backgroundPopUpList.ImageSource = new BitmapImage(new Uri("..\\..\\..\\img\\background_nether.png", UriKind.Relative));
            //    backgroundMenuPopUpList.ImageSource = new BitmapImage(new Uri("..\\..\\..\\img\\menu_background_nether.png", UriKind.Relative));
            //}
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
                switch (Pos)
            {
                case 1:
                    Craft.Button1_Image.Source = new BitmapImage(new Uri(Mgr.Items[listBoxItem.SelectedIndex].Image, UriKind.Relative));
                    Craft.ListItemCraft[Pos - 1] = Mgr.Items[listBoxItem.SelectedIndex];
                    break;
                case 2:
                    Craft.Button2_Image.Source = new BitmapImage(new Uri(Mgr.Items[listBoxItem.SelectedIndex].Image, UriKind.Relative));
                    Craft.ListItemCraft[Pos - 1] = Mgr.Items[listBoxItem.SelectedIndex];
                    break;
                case 3:
                    Craft.Button3_Image.Source = new BitmapImage(new Uri(Mgr.Items[listBoxItem.SelectedIndex].Image, UriKind.Relative));
                    Craft.ListItemCraft[Pos - 1] = Mgr.Items[listBoxItem.SelectedIndex];
                    break;
                case 4:
                    Craft.Button4_Image.Source = new BitmapImage(new Uri(Mgr.Items[listBoxItem.SelectedIndex].Image, UriKind.Relative));
                    Craft.ListItemCraft[Pos - 1] = Mgr.Items[listBoxItem.SelectedIndex];
                    break;
                case 5:
                    Craft.Button5_Image.Source = new BitmapImage(new Uri(Mgr.Items[listBoxItem.SelectedIndex].Image, UriKind.Relative));
                    Craft.ListItemCraft[Pos - 1] = Mgr.Items[listBoxItem.SelectedIndex];
                    break;
                case 6:
                    Craft.Button6_Image.Source = new BitmapImage(new Uri(Mgr.Items[listBoxItem.SelectedIndex].Image, UriKind.Relative));
                    Craft.ListItemCraft[Pos - 1] = Mgr.Items[listBoxItem.SelectedIndex];
                    break;
                case 7:
                    Craft.Button7_Image.Source = new BitmapImage(new Uri(Mgr.Items[listBoxItem.SelectedIndex].Image, UriKind.Relative));
                    Craft.ListItemCraft[Pos - 1] = Mgr.Items[listBoxItem.SelectedIndex];
                    break;
                case 8:
                    Craft.Button8_Image.Source = new BitmapImage(new Uri(Mgr.Items[listBoxItem.SelectedIndex].Image, UriKind.Relative));
                    Craft.ListItemCraft[Pos - 1] = Mgr.Items[listBoxItem.SelectedIndex];
                    break;
                case 9:
                    Craft.Button9_Image.Source = new BitmapImage(new Uri(Mgr.Items[listBoxItem.SelectedIndex].Image, UriKind.Relative));
                    Craft.ListItemCraft[Pos - 1] = Mgr.Items[listBoxItem.SelectedIndex];
                    break;
                case 10:
                    Craft.Button10_Image.Source = new BitmapImage(new Uri(Mgr.Items[listBoxItem.SelectedIndex].Image, UriKind.Relative));
                    Craft.ListItemCraft[Pos - 1] = Mgr.Items[listBoxItem.SelectedIndex];
                    break;

            }
        }
        popUpOpen = false;
            this.Close();
        }

    }
}
