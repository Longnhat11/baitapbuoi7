using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapbuoi7
{
    public class FullTimeEmployee : Employee
    {
        public double MonthlySalary { get; set; }
        public FullTimeEmployee(string name, string id,double monthlySalary) : base(name, id)
        {
            MonthlySalary = monthlySalary;
        }

        public override double CalculateSalary()
        {
            return MonthlySalary;
        }
    }
}
