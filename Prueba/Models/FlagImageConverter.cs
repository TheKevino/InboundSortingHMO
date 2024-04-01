using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Pallets.Models
{
    public class FlagImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string basePath = Environment.CurrentDirectory;
            if (value is string && !String.IsNullOrEmpty(value as string))
            {
                string imagePath = Path.Combine(basePath, "Flags", $"{value}.png");
                try
                {
                    BitmapImage image = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                    return image;
                }
                catch (Exception)
                {
                    // Si no se puede cargar la imagen, asigna una imagen de bandera por defecto
                    string defaultImagePath = Path.Combine(basePath, "Flags", "EMEA.png");
                    BitmapImage defaultImage = new BitmapImage(new Uri(defaultImagePath, UriKind.RelativeOrAbsolute));
                    return defaultImage;
                }
            }
            else
            {
                // Si el valor es nulo o no es de tipo cadena
                return Path.Combine(basePath, "Flags", "NULL.png");
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
