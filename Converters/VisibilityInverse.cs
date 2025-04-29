using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SFUListParser.Converters
{
    public class VisibilityInverse : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is Visibility visibility)
                return visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
