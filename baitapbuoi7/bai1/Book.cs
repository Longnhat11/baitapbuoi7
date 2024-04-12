using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapbuoi7
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public double Price { get; set; }

        public Book(string title, string author, int isbn, double price)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Price = price;
        }
    }

}
