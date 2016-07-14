using System;
using System.Windows.Data;

namespace NoteManager
{
    public class RadioButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            String parameterToCompare = (String)parameter.ToString();
            String valueRadiodButton = (String)value.ToString();
            Boolean result = valueRadiodButton.Equals(parameterToCompare, StringComparison.InvariantCultureIgnoreCase);
            Console.Write("parameterToCompare = " + parameterToCompare + " , ");
            Console.Write(" valueRadiodButton = " + valueRadiodButton + " et ");
            Console.WriteLine("Retour = " + result);
            return (result);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Boolean)value);
        }
    }
}
