using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BookSelling
{
    class PromotionPriceConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DataRowView dr = (DataRowView)value;
            string prom = dr["Promotions"].ToString();
            string cena = dr["Price"].ToString();

            int promotion = Int32.Parse(prom);
            int price = Int32.Parse(cena);
            return price - price * promotion / 100;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
