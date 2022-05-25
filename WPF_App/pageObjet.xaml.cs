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

namespace MC_Dex
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

        private void Creation_Page()
        {
            foreach (KeyValuePair<string, string> elt in Mgr.SelectedItem.ListeTexte)
            {
                texteUC texte = new();
                texte.texteTitre.Text = elt.Key;
                texte.textePartie.Text = elt.Value;
                StackPanelObjet.Children.Add(texte);
            }


            int cpt = 1;
            statistiqueUC zoneStat = new(); ;
            foreach (KeyValuePair<string, double> stat in Mgr.SelectedItem.ListeStats)
            {
                //if(cpt == 1)
                //{
                //    zoneStat = new statistiqueUC();
                //}
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
                PopUpDemandeSuppression popUp = new();
                popUp.Window = Window;
                PopUpDemandeSuppression.popUpOpen = true;
                popUp.Show();
                
            }
        }
    }
}
