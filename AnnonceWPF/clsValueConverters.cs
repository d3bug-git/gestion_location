using AnnonceBDD;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace AnnonceWPF
{
    class AvatarStringBase64ToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) { return ""; }
            string AvatarStringBase64 = ((String)value);

            // Convert Base64 String to byte[]
            byte[] imageBytes = System.Convert.FromBase64String(AvatarStringBase64);
            Console.WriteLine(AvatarStringBase64);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image =  Image.FromStream(ms, true);

            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
