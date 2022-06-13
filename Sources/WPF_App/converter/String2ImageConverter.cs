using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF_App.converter
{
    /// <summary>
    /// Classe permettant de convertir un nom d'image en chemin
    /// </summary>
    public class String2ImageConverter : IValueConverter
    {
        private static string imagesPath;

        /// <summary>
        /// Constructeur
        /// </summary>
        static String2ImageConverter()
        {
            //imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "img\\");
            imagesPath = "..\\..\\..\\img\\";
        }

        /// <summary>
        /// Convertit nom image en chemin
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageName = value as string;
            if (string.IsNullOrWhiteSpace(imageName)) return null;
            string imagePath = Path.Combine(imagesPath, imageName);
            return new Uri(imagePath, UriKind.RelativeOrAbsolute);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
