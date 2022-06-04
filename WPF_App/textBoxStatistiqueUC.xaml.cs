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

namespace WPF_App
{
    /// <summary>
    /// Logique d'interaction pour textBoxStatistiqueUC.xaml
    /// </summary>
    public partial class TextBoxStatistiqueUC : UserControl
    {
        public TextBoxStatistiqueUC()
        {
            InitializeComponent();
            ligneGridStatUC newLine = new();
            Grid_stat.Children.Add(newLine);
            newLine.SetValue(Grid.RowProperty, listLigneStat.Count);
            listLigneStat.Add(newLine);
        }


        public List<ligneGridStatUC> listLigneStat = new();
        private void Button_ajoutLigneStat(object sender, RoutedEventArgs e)
        {
            Grid_stat.RowDefinitions.Add(new RowDefinition());
            ligneGridStatUC newLine = new();
            Grid_stat.Children.Add(newLine);
            newLine.SetValue(Grid.RowProperty, listLigneStat.Count);
            listLigneStat.Add(newLine);
        }

        public void AjouterLigneStat(KeyValuePair<string, string> stat)
        {
            if (listLigneStat[0].nomStat.Text == "" && listLigneStat[0].valStat.Text == "")
            {
                listLigneStat[0].nomStat.Text = stat.Key;
                listLigneStat[0].valStat.Text = stat.Value;
            }
            else
            {
                Grid_stat.RowDefinitions.Add(new RowDefinition());
                ligneGridStatUC newLine = new();
                newLine.nomStat.Text = stat.Key;
                newLine.valStat.Text = stat.Value;
                Grid_stat.Children.Add(newLine);
                newLine.SetValue(Grid.RowProperty, listLigneStat.Count);
                listLigneStat.Add(newLine);
            }
        }

        private void Button_supprimeLigneStat(object sender, RoutedEventArgs e)
        {
            int nb = listLigneStat.Count;
            if (nb == 0)
            {
                return;
            }
            ligneGridStatUC line = listLigneStat[nb - 1];
            Grid_stat.Children.Remove(line);
            Grid_stat.RowDefinitions.RemoveAt(nb - 1);
            listLigneStat.RemoveAt(nb - 1);
        }

    }
}
