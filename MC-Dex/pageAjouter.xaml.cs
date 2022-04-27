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
using Microsoft.Win32;

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

        private void Button_AjouterCraft(object sender, RoutedEventArgs e)
        {
            textBoxCraftUC box = new textBoxCraftUC();
            panelBlocAjout.Children.Add(box);
        }

        private void Button_AjouterTexte(object sender, RoutedEventArgs e)
        {
            textBoxBaseUC box = new textBoxBaseUC();
            panelBlocAjout.Children.Add(box);
        }

        private void Button_AjouterStat(object sender, RoutedEventArgs e)
        {
            textBoxStatistiqueUC box = new textBoxStatistiqueUC();
            panelBlocAjout.Children.Add(box);
        }

        private void Button_OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image File (*.png;*.jpeg) | *.png;*.jpeg";
            if(ofd.ShowDialog() == true)
            {
                TextBlockPathFile.Text = ofd.FileName;
            }
        }
    }
}
