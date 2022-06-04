﻿using System;
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
    /// Logique d'interaction pour boutonAjoutUC.xaml
    /// </summary>
    public partial class boutonAjoutUC : UserControl
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public boutonAjoutUC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Propriété pour changer le nom de la textblock
        /// </summary>
        public string Message
        {
            set 
            {
                nomAjout.Text = value;
            }
        }
    }
}
