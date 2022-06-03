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

namespace WPF_App
{
    /// <summary>
    /// Logique d'interaction pour pageObjet.xaml
    /// </summary>
    public partial class pageObjet : UserControl
    {
        public MainWindow Window { get; set; }
        public static Manager Mgr => ((App)Application.Current).LeManager;
        public home detail = new();
        public pageObjet()
        {
            InitializeComponent();
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
            craftUC zoneCraftO = new();
            zoneCraftO.TypeCraft.Text = "Craft  Objet";
            craftUC zoneCraftU = new();
            zoneCraftU.TypeCraft.Text = "Craft  Utilisation";

            bool chechCraftO = false;
            bool chechCraftU = false;

            foreach (Craft elt in Mgr.SelectedItem.ListeCraft)
            {
                
                if (elt.GetType() == typeof(CraftObjet))
                {
                    grilleCraftUC craftUC = new();
                    if (elt.Objet0_0 != null) craftUC.ImageName1 = elt.Objet0_0.Image;
                    if (elt.Objet0_1 != null) craftUC.ImageName2 = elt.Objet0_1.Image;
                    if (elt.Objet0_2 != null) craftUC.ImageName3 = elt.Objet0_2.Image;
                    if (elt.Objet1_0 != null) craftUC.ImageName4 = elt.Objet1_0.Image;
                    if (elt.Objet1_1 != null) craftUC.ImageName5 = elt.Objet1_1.Image;
                    if (elt.Objet1_2 != null) craftUC.ImageName6 = elt.Objet1_2.Image;
                    if (elt.Objet2_0 != null) craftUC.ImageName7 = elt.Objet2_0.Image;
                    if (elt.Objet2_1 != null) craftUC.ImageName8 = elt.Objet2_1.Image;
                    if (elt.Objet2_2 != null) craftUC.ImageName9 = elt.Objet2_2.Image;
                    craftUC.ImageName10 = Mgr.SelectedItem.Image;
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
                    chechCraftO = true;

                }



                if (elt.GetType() == typeof(CraftUtilisation))
                {
                    CraftUtilisation craft = (CraftUtilisation)elt;
                    grilleCraftUC craftUC = new();
                    if (craft.Objet0_0 != null) craftUC.ImageName1 = craft.Objet0_0.Image;
                    if (craft.Objet0_1 != null) craftUC.ImageName2 = craft.Objet0_1.Image;
                    if (craft.Objet0_2 != null) craftUC.ImageName3 = craft.Objet0_2.Image;
                    if (craft.Objet1_0 != null) craftUC.ImageName4 = craft.Objet1_0.Image;
                    if (craft.Objet1_1 != null) craftUC.ImageName5 = craft.Objet1_1.Image;
                    if (craft.Objet1_2 != null) craftUC.ImageName6 = craft.Objet1_2.Image;
                    if (craft.Objet2_0 != null) craftUC.ImageName7 = craft.Objet2_0.Image;
                    if (craft.Objet2_1 != null) craftUC.ImageName8 = craft.Objet2_1.Image;
                    if (craft.Objet2_2 != null) craftUC.ImageName9 = craft.Objet2_2.Image;
                    if (craft.ObjetFinal != null) craftUC.ImageName10 = craft.ObjetFinal.Image;

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
                    chechCraftU = true;
                }
            }
            if (chechCraftO)
            {
                StackPanelObjet.Children.Add(zoneCraftO);
            }
            if (chechCraftU)
            {
                StackPanelObjet.Children.Add(zoneCraftU);
            }






            foreach (KeyValuePair<string, string> elt in Mgr.SelectedItem.ListeTexte)
            {
                texteUC texte = new();
                texte.texteTitre.Text = elt.Key;
                texte.textePartie.Text = elt.Value;
                StackPanelObjet.Children.Add(texte);
            }





            int cpt = 1;
            statistiqueUC zoneStat = new(); ;
            foreach (KeyValuePair<string, string> stat in Mgr.SelectedItem.ListeStats)
            {
                zoneStat.gridStat.RowDefinitions.Add(new RowDefinition());

                Border b1 = new();
                Border b2 = new();
                b1.BorderThickness = new Thickness(0, 1, 1, 1) ;
                b2.BorderThickness = new Thickness(1, 1, 0, 1);
                b1.BorderBrush = Brushes.Gray;
                b2.BorderBrush = Brushes.Gray;
                //b1.BorderBrush = new Brushes.zoneStat.gridStat.FindResource("Brush");
                TextBlock t1 = new(new Run(stat.Key));
                TextBlock t2 = new(new Run(stat.Value.ToString()));
                b1.Child = t1;
                b2.Child = t2;
                zoneStat.gridStat.Children.Add(b1);
                b1.SetValue(Grid.RowProperty, cpt);
                b1.SetValue(Grid.ColumnProperty, 0);
                zoneStat.gridStat.Children.Add(b2);
                b2.SetValue(Grid.RowProperty, cpt);
                b2.SetValue(Grid.ColumnProperty, 1);

                cpt++;
            }
            if(cpt != 1)
            {
                StackPanelObjet.Children.Add(zoneStat);
            }



        }


        private void Button_Modifier(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Supprimer(object sender, RoutedEventArgs e)
        {
            if (!PopUpDemandeSuppression.popUpOpen)
            {
                PopUpDemandeSuppression popUp = new(Window);
                PopUpDemandeSuppression.popUpOpen = true;
                popUp.Show();
                
            }
        }
    }
}
