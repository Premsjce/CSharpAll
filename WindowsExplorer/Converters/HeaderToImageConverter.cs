using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WindowsExplorer
{
    /// <summary>
    /// Converted the Full Path to a Image for a Drive, Folder or File
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = "Images/File.png";

            switch ((DirectoryItemType)value)
            {
                case DirectoryItemType.DRIVE:
                    image = "Images/Drive.png";
                    break;
                case DirectoryItemType.FOLDER:
                    image = "Images/Folder.png";
                    break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
