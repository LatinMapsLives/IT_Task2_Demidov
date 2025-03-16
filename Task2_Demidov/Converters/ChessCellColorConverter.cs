using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_Demidov.ViewModels;

namespace Task2_Demidov.Converters
{
    public class ChessCellColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ChessBoardViewModel vm && parameter is CellViewModel cell)
            {
                return (cell.X + cell.Y) % 2 == 0
                    ? Brushes.LightGray
                    : Brushes.DimGray;
            }
            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
