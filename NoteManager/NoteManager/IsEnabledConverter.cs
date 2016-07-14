using System;
using System.Windows.Data;

namespace NoteManager
{
    class IsEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            String parameterToCompare = (String)parameter.ToString();
            String valueIsEnabled = (String)value.ToString();
            Boolean result = valueIsEnabled.Equals(parameterToCompare, StringComparison.InvariantCultureIgnoreCase);
            return (result);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Boolean)value);
        }
    }
}
