using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapbuoi7
{
    public class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void CalculateSalaries()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"Lương của {employee.Name} là: {employee.CalculateSalary()}");
            }
        }
    }
}
