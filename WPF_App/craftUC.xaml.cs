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
    /// Logique d'interaction pour craftUC.xaml
    /// </summary>
    public partial class craftUC : UserControl
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public craftUC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Propriété permettant de changer le nom de la textblock
        /// </summary>
        public string NameTypeCraft
        {
            set
            {
                TypeCraft.Text = value;
            }
        }

    }
}
