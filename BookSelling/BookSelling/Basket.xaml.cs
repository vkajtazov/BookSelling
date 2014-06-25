using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookSelling
{
    /// <summary>
    /// Interaction logic for Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {
        public Basket()
        {
            InitializeComponent();
        }

        public Basket(List<Book>list)
        {
            InitializeComponent();

            int f = list.Count;
            OrderProducts.ItemsSource = list;
            setTotalSum(list);


        }

        private void setTotalSum(List<Book> list) {
            int sum = 0;
            
            foreach (Book b in list)
            {
                sum += b.getSum();
            }

            TotalSum.Content = sum.ToString();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }


    }
}
