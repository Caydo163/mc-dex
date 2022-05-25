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
    /// Logique d'interaction pour textBoxStatistiqueUC.xaml
    /// </summary>
    public partial class TextBoxStatistiqueUC : UserControl
    {
        public TextBoxStatistiqueUC()
        {
            InitializeComponent();
        }

        public int nbStat = 1;
        private void Button_ajoutLigneStat(object sender, RoutedEventArgs e)
        {
            Grid_stat.RowDefinitions.Add(new RowDefinition());
            ligneGridStatUC newLine = new();
            newLine.Name = "ligneStat" + nbStat+1;

            Grid_stat.Children.Add(newLine);
            newLine.SetValue(Grid.RowProperty, nbStat);

            nbStat++;
        }

/*        private void Button_supprimeLigneStat(object sender, RoutedEventArgs e)
        {
            if (nbStat < 1)
            {
                return;
            }
            Grid_stat.RowDefinitions.RemoveAt(nbStat - 1);

            nbStat--;
        }*/


        
    }
}
