using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFDataBindingDemo.ValueConverterSample
{
    public class YesNoToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString().ToUpper())
            {
                case "YES":
                    return true;
                    break;
                case "NO":
                    return false;
                    break;
                default:
                    return false;
                    break;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool)
            {
                if ((bool)value)
                    return "YES";
                else
                    return "NO";
            }
            return "NO";
        }
    }
}
