using System;
using Windows.UI.Xaml.Data;

namespace SFUListParser.Converters
{
    internal class StringToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            int val = -1;
            if (int.TryParse(value as string, out val))
                return val;

            return val;
        }
    }
}
