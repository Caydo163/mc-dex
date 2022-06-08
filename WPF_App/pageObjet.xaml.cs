﻿using Modele;
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

namespace WPF_App
{
    /// <summary>
    /// Logique d'interaction pour pageObjet.xaml
    /// </summary>
    public partial class pageObjet : UserControl
    {
        /// <summary>
        /// Fenêtre de l'application
        /// </summary>
        public MainWindow Window { get; set; }

        /// <summary>
        /// Manager
        /// </summary>
        public static Manager Mgr => ((App)Application.Current).LeManager;

        /// <summary>
        /// Page d'accueil
        /// </summary>
        public home detail = new();

        /// <summary>
        /// Constructeur
        /// </summary>
        public pageObjet()
        {
            InitializeComponent();

            // Création de la page home
            detail.Width = 250;
            detail.Margin = new Thickness(0,0,20,20);
            zoneHome.Children.Add(detail);
            Creation_Page();
        }

        public void chargementHome()
        {
            detail.Window = Window;
        }


        /// <summary>
        /// Ajouter les userControl nécessaire en fonction des informations de l'item
        /// </summary>
        private void Creation_Page()
        {
            //////////////////////// Ajout de la partie craft /////////////////////////////

            // On créé les zones
            craftUC zoneCraftO = new();
            zoneCraftO.TypeCraft.Text = "Craft  Objet";
            craftUC zoneCraftU = new();
            zoneCraftU.TypeCraft.Text = "Craft  Utilisation";

            // On initialise 2 booléen pour savoir si on devra les afficher
            bool checkCraftO = false;
            bool checkCraftU = false;


            // XXXXXXXXXXXXXXX à modif 
            foreach (Craft elt in Mgr.SelectedItem.ListeCraft)
            {
                // Si le craft est un craft objet
                if (elt.GetType() == typeof(CraftObjet))
                {
                    grilleCraftUC craftUC = new();
                    if (elt.Objet0_0 != null) craftUC.ImageName1 = "..\\img\\"+elt.Objet0_0.Image;
                    if (elt.Objet0_1 != null) craftUC.ImageName2 = "..\\img\\" + elt.Objet0_1.Image;
                    if (elt.Objet0_2 != null) craftUC.ImageName3 = "..\\img\\" + elt.Objet0_2.Image;
                    if (elt.Objet1_0 != null) craftUC.ImageName4 = "..\\img\\" + elt.Objet1_0.Image;
                    if (elt.Objet1_1 != null) craftUC.ImageName5 = "..\\img\\" + elt.Objet1_1.Image;
                    if (elt.Objet1_2 != null) craftUC.ImageName6 = "..\\img\\" + elt.Objet1_2.Image;
                    if (elt.Objet2_0 != null) craftUC.ImageName7 = "..\\img\\" + elt.Objet2_0.Image;
                    if (elt.Objet2_1 != null) craftUC.ImageName8 = "..\\img\\" + elt.Objet2_1.Image;
                    if (elt.Objet2_2 != null) craftUC.ImageName9 = "..\\img\\" + elt.Objet2_2.Image;
                    craftUC.ImageName10 = "..\\img\\" + Mgr.SelectedItem.Image;
                    if (elt.NbFinal != 1)
                    {
                        craftUC.nbBlocCraft.Text = elt.NbFinal.ToString();
                    }
                    List<KeyValuePair<string, int>> listIngredient = elt.CalculIngredient();
                    foreach (KeyValuePair<string, int> ing in listIngredient)
                    {
                        TextBlock textBlock = new()
                        {
                            Text = "* " + ing.Value.ToString() + " " + ing.Key,
                            Style = (Style)((App)Application.Current).Resources["pageObjet_textePartie"]
                        };
                        craftUC.stackPanelGrilleCraft.Children.Add(textBlock);
                    }

                    zoneCraftO.wrapPanelCraft.Children.Add(craftUC);
                    checkCraftO = true;

                }



                if (elt.GetType() == typeof(CraftUtilisation))
                {
                    CraftUtilisation craft = (CraftUtilisation)elt;
                    grilleCraftUC craftUC = new();
                    if (craft.Objet0_0 != null) craftUC.ImageName1 = "..\\img\\" + craft.Objet0_0.Image;
                    if (craft.Objet0_1 != null) craftUC.ImageName2 = "..\\img\\" + craft.Objet0_1.Image;
                    if (craft.Objet0_2 != null) craftUC.ImageName3 = "..\\img\\" + craft.Objet0_2.Image;
                    if (craft.Objet1_0 != null) craftUC.ImageName4 = "..\\img\\" + craft.Objet1_0.Image;
                    if (craft.Objet1_1 != null) craftUC.ImageName5 = "..\\img\\" + craft.Objet1_1.Image;
                    if (craft.Objet1_2 != null) craftUC.ImageName6 = "..\\img\\" + craft.Objet1_2.Image;
                    if (craft.Objet2_0 != null) craftUC.ImageName7 = "..\\img\\" + craft.Objet2_0.Image;
                    if (craft.Objet2_1 != null) craftUC.ImageName8 = "..\\img\\" + craft.Objet2_1.Image;
                    if (craft.Objet2_2 != null) craftUC.ImageName9 = "..\\img\\" + craft.Objet2_2.Image;
                    if (craft.ObjetFinal != null) craftUC.ImageName10 = "..\\img\\" + craft.ObjetFinal.Image;

                    if (craft.NbFinal != 1)
                    {
                        craftUC.nbBlocCraft.Text = craft.NbFinal.ToString();
                    }


                    List<KeyValuePair<string, int>> listIngredient = craft.CalculIngredient();
                    foreach (KeyValuePair<string, int> ing in listIngredient)
                    {
                        TextBlock textBlock = new()
                        {
                            Style = (Style)((App)Application.Current).Resources["pageObjet_textePartie"]
                        };
                        if (ing.Key[0] == '§')
                        {
                            textBlock.Text = "* " + ing.Value.ToString() + " " + ing.Key[1..];
                            textBlock.Foreground = Brushes.Red;
                        }
                        else
                        {
                            textBlock.Text = "* " + ing.Value.ToString() + " " + ing.Key;
                        }

                        craftUC.stackPanelGrilleCraft.Children.Add(textBlock);
                    }

                    zoneCraftU.wrapPanelCraft.Children.Add(craftUC);
                    checkCraftU = true;
                }
            }
            if (checkCraftO)
            {
                StackPanelObjet.Children.Add(zoneCraftO);
            }
            if (checkCraftU)
            {
                StackPanelObjet.Children.Add(zoneCraftU);
            }


            //////////////////////// Ajout de la partie textes /////////////////////////////
            foreach (KeyValuePair<string, string> elt in Mgr.SelectedItem.ListeTexte)
            {
                texteUC texte = new();
                texte.texteTitre.Text = elt.Key;
                texte.textePartie.Text = elt.Value;
                StackPanelObjet.Children.Add(texte);
            }


            //////////////////////// Ajout de la partie statistiques /////////////////////////////
            
            // On créé la zone
            statistiqueUC zoneStat = new();
            // On déclare un compteur
            int cpt = 1;

            foreach (KeyValuePair<string, string> stat in Mgr.SelectedItem.ListeStats)
            {
                // On ajoute une ligne à la grille
                zoneStat.gridStat.RowDefinitions.Add(new RowDefinition());

                // On créé les 2 textblock
                TextBlock t1 = new(new Run(stat.Key));
                Border b1 = new()
                {
                    BorderThickness = new Thickness(0, 1, 1, 1),
                    BorderBrush = Brushes.Gray,
                    Child = t1
                };
                zoneStat.gridStat.Children.Add(b1);
                b1.SetValue(Grid.RowProperty, cpt);
                b1.SetValue(Grid.ColumnProperty, 0);

                TextBlock t2 = new(new Run(stat.Value.ToString()));
                Border b2 = new()
                {
                    BorderThickness = new Thickness(1, 1, 0, 1),
                    BorderBrush = Brushes.Gray,
                    Child = t2
                };
                zoneStat.gridStat.Children.Add(b2);
                b2.SetValue(Grid.RowProperty, cpt);
                b2.SetValue(Grid.ColumnProperty, 1);

                cpt++;
            }
            // Si le compteur est différent de 1 (donc au moins 1 statistiques), on affiche la zone
            if(cpt != 1)
            {
                StackPanelObjet.Children.Add(zoneStat);
            }
        }


        /// <summary>
        /// Bouton pour modifier l'item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Modifier(object sender, RoutedEventArgs e)
        {
            // Booléen permettant de dire qu'il faut affiche la paje ajouter en mode modifier
            PageAjouter pageA = new(true)
            {
                Window = Window
            };
            Window.Title = "MC-Dex - Modifier";
            Window.contentControl.Content = pageA;
        }

        /// <summary>
        /// Bouton pour supprimer l'item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Supprimer(object sender, RoutedEventArgs e)
        {
            // Affiche un pop up de demande de suppression
            if (!PopUpDemandeSuppression.popUpOpen)
            {
                PopUpDemandeSuppression popUp = new(Window);
                PopUpDemandeSuppression.popUpOpen = true;
                popUp.Show();
            }
        }
    }
}
