using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace baitapbuoi7
{
    public class checkInput
    {
        public static bool ContainsNumber(string input)
        {
            if (input.Any(char.IsDigit))
            {
                Console.WriteLine("Không được chứa chữ số!");
                return true;
            }
            else
                return false;
        }
        public static bool CheckContainSpecialChar(string input)
        {
            Regex specialCharRegex = new Regex(@"[~`!@#$%^&*()+=|\\{}':;,.<>?/""-]");
            if (specialCharRegex.IsMatch(input))
            {
                Console.WriteLine("Không được chứa kí tự đặc biệt!");
                return true;
            }
            else
                return false;
        }
        public static bool CheckIsNullOrWhiteSpace(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Không được để trống hay chỉ chứa khoảng trắng!");
                return true;
            }
            else
                return false;
        }
        public static bool CheckDateTime(string input)
        {
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                DateTime now = DateTime.Now;
                TimeSpan interval = now - date;
                if (interval.Days > 0)
                    return true;
                else
                {
                    Console.WriteLine("Ngày phát hành hóa đơn không được lớn hơn thời gian hiện tại!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Định dạng ngày không hợp lệ!");
                return false;
            }
        }
        public static bool CheckNumber(string input, out double number)
        {
            if (double.TryParse(input, out number))
            {
                if (number <= 0)
                {
                    Console.WriteLine("Số không được bằng 0 hoặc là số âm!");
                    return false;
                }
                else
                    return true;
            }
            else
            {
                Console.WriteLine("Số không được quá lớn, không được là kí tự, không để trống hay chứa khoảng trắng!");
                return false;
            }
        }
        public void bai3()
        {
            ProductManager productManager = new ProductManager();
            while (true)
            {
                Console.WriteLine("1. Nhập vào N sản phẩm");
                Console.WriteLine("2. Xóa sản phẩm theo id hoặc tên");
                Console.WriteLine("3. Update sản phẩm");
                Console.WriteLine("4. Xóa nhiều sản phẩm cùng lúc");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn một lựa chọn: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        // Nhập vào N sản phẩm
                        Console.Write("Nhập số lượng sản phẩm: ");
                        double n;
                        bool check;
                        string tongSanPham;
                        do
                        {
                            tongSanPham = Console.ReadLine();
                            if (CheckNumber(tongSanPham, out n))
                                check = true;
                            else check = false;
                        } while (!check);
                        for (int i = 0; i < n; i++)
                        {
                            Product product = new Product();
                            Console.Write("Nhập ProductId: ");
                            double ProductID;
                            string ID;
                            bool checkID;
                            do
                            {
                                ID = Console.ReadLine();
                                if (CheckNumber(ID, out ProductID))
                                    checkID = true;
                                else checkID = false;
                            } while (!checkID);
                            product.ProductId = ProductID;
                            Console.Write("Nhập ProductName: ");
                            string productname;
                            bool checkname;
                            do
                            {
                                productname = Console.ReadLine();
                                if (CheckContainSpecialChar(productname) || CheckIsNullOrWhiteSpace(productname) || ContainsNumber(productname))
                                    checkname = false;
                                else checkname = true;
                            } while (!checkname);

                            product.ProductName = productname;
                            Console.Write("Nhập Price: ");
                            bool checkPrice;
                            double ProductPrice;
                            string Price;
                            do
                            {
                                Price = Console.ReadLine();
                                if (CheckNumber(Price, out ProductPrice))
                                    checkPrice = true;
                                else checkPrice = false;
                            } while (!checkPrice);
                            product.Price = ProductPrice;
                            productManager.Insert(product);
                        }
                        Console.WriteLine("Đã nhập thành công " + n + " sản phẩm.");
                        break;
                    case 2:
                        // Xóa sản phẩm theo id hoặc tên
                        Console.Write("Nhập ProductId hoặc ProductName: ");
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out int productId))
                        {
                            productManager.Delete(productId);
                        }
                        else
                        {
                            string productName = input;
                            Product product = productManager.Searchname(productName);
                            if (product != null)
                            {
                                productManager.Delete(product.ProductId);
                            }
                        }
                        Console.WriteLine("Đã xóa sản phẩm.");
                        break;
                    case 3:
                        // Update sản phẩm
                        Console.Write("Nhập ProductId: ");
                        bool checkIDU;
                        double ProductIDU;
                        string IDU;
                        do
                        {
                            IDU = Console.ReadLine();
                            if (CheckNumber(IDU, out ProductIDU))
                                checkIDU = true;
                            else checkIDU = false;
                        } while (!checkIDU);
                        Product prod = productManager.Search(ProductIDU);
                        if (prod != null)
                        {
                            Console.Write("Nhập ProductName mới: ");
                            string productname;
                            bool checkname;
                            do
                            {
                                productname = Console.ReadLine();
                                if (CheckContainSpecialChar(productname) || CheckIsNullOrWhiteSpace(productname) || ContainsNumber(productname))
                                    checkname = false;
                                else checkname = true;
                            } while (!checkname);
                            prod.ProductName = productname;
                            Console.Write("Nhập Price mới: ");
                            bool checkPrice;
                            double ProductPrice;
                            string Price;
                            do
                            {
                                Price = Console.ReadLine();
                                if (CheckNumber(Price, out ProductPrice))
                                    checkPrice = true;
                                else checkPrice = false;
                            } while (!checkPrice);
                            prod.Price = ProductPrice;
                            productManager.Update(prod);
                            Console.WriteLine("Đã cập nhật sản phẩm.");
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy sản phẩm.");
                        }
                        break;
                    case 4:
                        // Xóa nhiều sản phẩm cùng lúc
                        Console.Write("Nhập số lượng sản phẩm cần xóa: ");
                        int m = int.Parse(Console.ReadLine());
                        for (int i = 0; i < m; i++)
                        {
                            Console.Write("Nhập ProductId: ");
                            bool checkIDDel;
                            double ProductIDDel;
                            string IDDel;
                            do
                            {
                                IDDel = Console.ReadLine();
                                if (CheckNumber(IDDel, out ProductIDDel))
                                    checkIDDel= true;
                                else checkIDDel = false;
                            } while (!checkIDDel);
                            productManager.Delete(ProductIDDel);
                        }
                        Console.WriteLine("Đã xóa " + m + " sản phẩm.");
                        break;
                    case 5:
                        // Thoát
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        } 
    }
}
