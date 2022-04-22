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

namespace MC_Dex
{
    /// <summary>
    /// Logique d'interaction pour pageAjouter.xaml
    /// </summary>
    public partial class pageAjouter : UserControl
    {
        public pageAjouter()
        {
            InitializeComponent();
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private int nbStat = 1 ;
        private void Button_ajoutLigneStat(object sender, RoutedEventArgs e)
        {
            Grid_stat.RowDefinitions.Add(new RowDefinition());
            nomGridStatUC newNom = new nomGridStatUC();
            valeurGridStatUC newValeur = new valeurGridStatUC();

            Grid_stat.Children.Add(newNom);
            newNom.SetValue(Grid.RowProperty, nbStat+1);
            newNom.SetValue(Grid.ColumnProperty, 0);

            Grid_stat.Children.Add(newValeur);
            newValeur.SetValue(Grid.RowProperty, nbStat+1);
            newValeur.SetValue(Grid.ColumnProperty, 1);

            nbStat++;
        }
    }
}
