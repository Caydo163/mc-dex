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
using System.Diagnostics;
using Modele;

namespace WPF_App
{
    /// <summary>
    /// Logique d'interaction pour textBoxCraftUC.xaml
    /// </summary>
    public partial class textBoxCraftUC : UserControl
    {
        /// <summary>
        /// Fenêtre de l'application
        /// </summary>
        public MainWindow Window { get; set; }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public textBoxCraftUC(MainWindow wIndow)
        {
            InitializeComponent();
            Window = wIndow;
        }

        /// <summary>
        /// Liste d'item initialisé à 10 objet null
        /// </summary>
        private List<Item> listItemCraft = new() { null, null, null, null, null, null, null, null, null, null};

        /// <summary>
        /// Prporiété contenant la liste d'item
        /// </summary>
        public List<Item> ListItemCraft { get => listItemCraft; set => listItemCraft = value; }

        /// <summary>
        /// Bouton permettant de choisir le premier item du craft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1(object sender, RoutedEventArgs e)
        {
            if(! PopUpListObject.popUpOpen)
            {
                Debug.WriteLine(Mouse.GetPosition(null));
                PopUpListObject popUp = new(Window)
                {
                    Craft = this,
                    Pos = 1
                };
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }

        /// <summary>
        /// Bouton permettant de choisir le deuxième item du craft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                PopUpListObject popUp = new(Window)
                {
                    Craft = this,
                    Pos = 2
                };
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }

        /// <summary>
        /// Bouton permettant de choisir le troisième item du craft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                PopUpListObject popUp = new(Window)
                {
                    Craft = this,
                    Pos = 3
                };
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }

        /// <summary>
        /// Bouton permettant de choisir le quatrième item du craft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                PopUpListObject popUp = new(Window)
                {
                    Craft = this,
                    Pos = 4
                };
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }

        /// <summary>
        /// Bouton permettant de choisir le cinquième item du craft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button5(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                PopUpListObject popUp = new(Window)
                {
                    Craft = this,
                    Pos = 5
                };
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }

        /// <summary>
        /// Bouton permettant de choisir le sixième item du craft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button6(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                PopUpListObject popUp = new(Window)
                {
                    Craft = this,
                    Pos = 6
                };
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }

        /// <summary>
        /// Bouton permettant de choisir le septième item du craft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button7(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                PopUpListObject popUp = new(Window)
                {
                    Craft = this,
                    Pos = 7
                };
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }

        /// <summary>
        /// Bouton permettant de choisir le huitième item du craft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button8(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                PopUpListObject popUp = new(Window)
                {
                    Craft = this,
                    Pos = 8
                };
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }

        /// <summary>
        /// Bouton permettant de choisir le neuvième item du craft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button9(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                PopUpListObject popUp = new(Window)
                {
                    Craft = this,
                    Pos = 9
                };
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }

        /// <summary>
        /// Bouton permettant de choisir le dixième item du craft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button10(object sender, RoutedEventArgs e)
        {
            if (!PopUpListObject.popUpOpen)
            {
                PopUpListObject popUp = new(Window)
                {
                    Craft = this,
                    Pos = 10
                };
                PopUpListObject.popUpOpen = true;
                popUp.Show();
            }
        }
    }
}
