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
                    Console.WriteLine("Số tiền không được bằng 0 hoặc là số âm!");
                    return false;
                }
                else
                    return true;
            }
            else
            {
                Console.WriteLine("Số tiền không được quá lớn, không được là kí tự, không để trống hay chứa khoảng trắng!");
                return false;
            }
        }
        public void bai2()
        {
            EmployeeManager manager = new EmployeeManager();

            Console.WriteLine("1. Nhập vào N nhân viên.");
            Console.WriteLine("2. Tính toán lương tương ứng cho mỗi loại nhân viên.");
            Console.WriteLine("Nhập lựa chọn của bạn:");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    bool check;
                    double n ;
                    string tongNV ;
                    do
                    {
                        Console.WriteLine("Nhập số lượng nhân viên:");
                        tongNV = Console.ReadLine();
                        if (CheckNumber(tongNV, out n))
                            check = true;
                        else check = false;
                    } while (!check);
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine($"Nhập thông tin cho nhân viên thứ {i + 1}:");
                        Console.WriteLine("Nhập tên:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Nhập ID:");
                        string id = Console.ReadLine();
                        Console.WriteLine("Nhập loại nhân viên (1 - Toàn thời gian, 2 - Bán thời gian, 3 - Thực tập):");
                        double type;
                        string LoaiNV;
                        do
                        {
                            LoaiNV = Console.ReadLine();
                            if (CheckNumber(LoaiNV, out type))
                                check = true;                            
                            else
                            { check = false;
                                if ((type < 1) && (type > 3))
                                {
                                    check = true;
                                }
                            }
                        } while (!check);
                        switch (type)
                        {
                            case 1:
                                Console.WriteLine("Nhập lương hàng tháng:");
                                double monthlySalary;
                                bool checkMoth;
                                string Monthsalary;
                                do
                                {
                                    Monthsalary = Console.ReadLine();
                                    if (CheckNumber(Monthsalary, out monthlySalary))
                                        checkMoth = true;
                                    else checkMoth = false;
                                } while (!checkMoth);
                                manager.AddEmployee(new FullTimeEmployee(name, id, monthlySalary));
                                break;
                            case 2:
                                Console.WriteLine("Nhập mức lương theo giờ:");
                                double hourlyRate;
                                bool checkhour;
                                string hour;
                                do
                                {
                                    hour = Console.ReadLine();
                                    if (CheckNumber(hour, out hourlyRate))
                                        checkhour = true;
                                    else checkhour = false;
                                } while (!checkhour);
                                Console.WriteLine("Nhập số giờ làm việc:");
                                double hoursWorked;
                                bool checkhourswork;
                                string hourwork;
                                do
                                {
                                    hourwork = Console.ReadLine();
                                    if (CheckNumber(hourwork, out hoursWorked))
                                        checkhourswork = true;
                                    else checkhourswork = false;
                                } while (!checkhourswork);
                                manager.AddEmployee(new PartTimeEmployee(name, id, hourlyRate, hoursWorked));
                                break;
                            case 3:
                                Console.WriteLine("Nhập tiền trợ cấp:");
                                double stipend;
                                bool checkstipend;
                                string stiprndin;
                                do
                                {
                                    stiprndin = Console.ReadLine();
                                    if (CheckNumber(stiprndin, out stipend))
                                        checkstipend = true;
                                    else checkstipend = false;
                                } while (!checkstipend);
                                manager.AddEmployee(new Intern(name, id, stipend));
                                break;
                        }
                    }
                    break;
                    case "2":
                    manager.CalculateSalaries();
                    break;
                    default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }

        }
    }
}
