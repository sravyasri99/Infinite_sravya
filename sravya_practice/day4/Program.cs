using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4
{
    class Employee
    {
        int empid;
        string empname;
        DateTime doj;
        public Employee()
        {
            empid = 1806645;
            empname = "sravya";
            doj = Convert.ToDateTime("02/06/2025");
        }
        public Employee(int Empid, String Empname)
        {
            empid = Empid;
            empname = Empname;

        }
        public Employee(int empid, string empname, DateTime doj)
        {
            this.empid = empid;
            this.empname = empname;
            this.doj = doj;
        }
        ~Employee()
        {

        }

        public void ShowEmployee()
        {
            Console.WriteLine("{0}, {1},{2}", empid, empname, doj);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.ShowEmployee();
            Employee employee1 = new Employee(100, "SRAVYA");
            employee1.ShowEmployee();
            Employee employee2 = new Employee(1806645, "srvyasri", Convert.ToDateTime("021/02/2022"));
            employee2.ShowEmployee();
        }
    }
}
