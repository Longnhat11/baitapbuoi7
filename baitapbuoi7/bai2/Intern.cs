using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapbuoi7
{
    public class Intern : Employee
    {
        public double Stipend { get; set; }

        public Intern(string name, string id, double stipend) : base(name, id)
        {
            Stipend = stipend;
        }

        public override double CalculateSalary()
        {
            return Stipend;
        }
    }
}
