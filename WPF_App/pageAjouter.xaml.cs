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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace MC_Dex
{
    /// <summary>
    /// Logique d'interaction pour pageAjouter.xaml
    /// </summary>
    public partial class PageAjouter : UserControl
    {
        private MainWindow window;
        public MainWindow Window { get; set; }

        public PageAjouter()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_AjouterCraft(object sender, RoutedEventArgs e)
        {
            textBoxCraftUC box = new();
            panelBlocAjout.Children.Add(box);
        }

        private void Button_AjouterTexte(object sender, RoutedEventArgs e)
        {
            textBoxBaseUC box = new();
            panelBlocAjout.Children.Add(box);
        }

        private void Button_AjouterStat(object sender, RoutedEventArgs e)
        {
            TextBoxStatistiqueUC box = new();
            panelBlocAjout.Children.Add(box);
            HideButtonStat.Visibility = Visibility.Collapsed;
        }

        private void Button_AjouterNom(object sender, RoutedEventArgs e)
        {
            textBoxUC box = new()
            {
                Nom = "Nom (anglais)"
            };
            panelBlocAjout.Children.Add(box);
            HideButtonName.Visibility = Visibility.Collapsed;
        }

        private void Button_OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new()
            {
                Filter = "Image File (*.png;*.jpeg) | *.png;*.jpeg"
            };
            if (ofd.ShowDialog() == true)
            {
                TextBlockPathFile.Text = ofd.FileName;
            }
        }

        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            //(Application.Current as App).MainWindow.abc =
            Window.contentControl.Content = new home() ;
            
        }
    }
}
