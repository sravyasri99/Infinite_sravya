using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //EmployeeBAL employeeBAL = new EmployeeBAL(new EmployeeDALImplementor());
            EmployeeBAL employeeBAL = new EmployeeBAL();

            //employeeBAL.EmpDataObject = new EmployeeDALImplementor();
            List<Employee> emplist = employeeBAL.SelectAllEmployees(new EmployeeDALImplementor());

            foreach(Employee e in emplist)
            {
                Console.WriteLine($"ID = {e.ID} , Name = {e.Name} and Dept = {e.Department}");
            }
            Console.Read();
        }
    }
}
