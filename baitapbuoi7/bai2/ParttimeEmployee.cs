using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapbuoi7
{
    public class PartTimeEmployee : Employee
    {
        private double hoursWorked;

        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public PartTimeEmployee(string name, string id, double hourlyRate, int hoursWorked) : base(name, id)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public PartTimeEmployee(string name, string id, double hourlyRate, double hoursWorked) : base(name, id)
        {
            HourlyRate = hourlyRate;
            this.hoursWorked = hoursWorked;
        }

        public override double CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }
    }

}
