using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project2
{
    public class Employee
    {
        public int ? ID { get; set; }
        public string Name { get; set; }
        public double  ? Salary { get; set; }

        public List<Employee>EmployeeList()
        {
            List<Employee> emplist = new List<Employee>()
            {
                new Employee{ID = 100, Name = "Sravy", Salary = 5000},
                new Employee{ID = 100, Name = "Sra", Salary = 6000},
            };
            return emplist;
        }
    }
}
