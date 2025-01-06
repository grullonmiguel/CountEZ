using CountEZ.Core.Helpers;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CountEZ.Core.Converters
{
    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return DependencyProperty.UnsetValue;

            return EnumHelper.GetDisplayName((Enum)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
