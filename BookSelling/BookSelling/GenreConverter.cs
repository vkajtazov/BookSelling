using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BookSelling
{
    class GenreConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int val = (int)value;
            if (val == 1) { return "Drama"; }
            else if (val == 2) { return "Romance"; }
            else if (val == 3) { return "Satire"; }
            else if (val == 4) { return "Tragedy"; }
            else if (val == 5) { return "Comedy"; }
            else if (val == 6) { return "Tragicomedy"; }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
