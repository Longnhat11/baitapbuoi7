using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapbuoi7
{
     public abstract class Employee
    {
        public string Name { get; set; }
        public string ID { get; set; }

        public Employee(string name, string id)
        {
            Name = name;
            ID = id;
        }

        public abstract double CalculateSalary();
    }
}
