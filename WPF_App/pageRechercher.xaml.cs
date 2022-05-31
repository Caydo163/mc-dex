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

namespace MC_Dex
{
    /// <summary>
    /// Logique d'interaction pour pageRechercher.xaml
    /// </summary>
    public partial class pageRechercher : UserControl
    {
        public MainWindow Window { get; set; }
        public static Manager Mgr => ((App)Application.Current).LeManager;
        public pageRechercher()
        {
            InitializeComponent();
        }

        public void Button_Rechercher(object sender, RoutedEventArgs e)
        {
            Rechercher();
        }

        private void ToucheEntree(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                Rechercher();
            }
        }

        private void Rechercher()
        {
            Mgr.Rechercher(textBox_Recherche.Text);
            Mgr.modeRecherche = true;

            home pageH = new();
            pageH.Window = Window;
            Window.contentControl.Content = pageH;
        }
    }
}
