using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapbuoi7
{
    public class Library :checkInput
    {
        public List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            bool check;
            string title;
            Console.WriteLine("Nhập sách thêm:");
            do
            {
                Console.Write("Nhập Title:");
                title = Console.ReadLine();
                if (CheckContainSpecialChar(title) || CheckIsNullOrWhiteSpace(title) || ContainsNumber(title))
                    check = false;
                else check = true;
            }while (!check);
            book.Title = title;
            string author;
            do
            {
                Console.Write("Tên Khách Hàng:");
                author = Console.ReadLine();
                if (CheckContainSpecialChar(author) || CheckIsNullOrWhiteSpace(author) || ContainsNumber(author))
                    check = false;
                else check = true;
            } while (!check);
            book.Author = author;
            int isbn;
            string checkisbn;
            do
            {
                Console.Write("Nhập ISBN không dấu -:");
                checkisbn = Console.ReadLine();
                if (CheckNumber(checkisbn, out isbn))
                    check = true;
                else check = false;
            } while (!check);
            book.ISBN = isbn;
            int price;
            string checkprice;
            do
            {
                Console.Write("Nhập giá:");
                checkprice = Console.ReadLine();
                if (CheckNumber(checkisbn, out price))
                    check = true;
                else check = false;
            } while (!check);
            book.Price = price; 
            books.Add(new Book(title,author,isbn,price));
        }

        public Book SearchByAuthor(string author)
        {
            return books.FirstOrDefault(b => b.Author == author);
        }

        public Book SearchByISBN(int isbn)
        {
            return books.FirstOrDefault(b => b.ISBN == isbn);
        }

        public void BorrowBook(int isbn)
        {
            var book = SearchByISBN(isbn);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine($"Bạn đã mượn sách {book.Title}.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sách.");
            }
        }

        public void ReturnBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Bạn đã trả sách {book.Title}.");
        }
    }
}
