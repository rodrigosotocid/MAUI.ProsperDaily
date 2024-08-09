using System.Globalization;

namespace MAUI.ProsperDaily.Converters
{
    public class AmountToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var isIncome = ((Label)parameter).Text;
            var amount = (decimal)value;

            if (isIncome == "True")
            {
                return Colors.Green;
            }
            else
            {
                return Colors.Red;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
