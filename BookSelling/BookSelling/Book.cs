using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSelling
{
    public class Book
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Promotion { get; set; }
        public int Count { get; set; }
        public int Sum { get; set; }


        public Book(string title, int price, int promotion, int count) {
            Title = title;
            Price = price;
            Promotion = promotion;
            Count = count;
            Sum = Count * (Price - Price * Promotion / 100);
        }

        public int getSum()
        {
            return Count * Sum;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} x {2} = {3}", Title, Count, Sum, Count * Sum);
        }
    }
}
