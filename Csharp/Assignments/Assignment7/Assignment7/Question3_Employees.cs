using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class Employees
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }

    class Question3_Employees
    {
        static void DisplayEmployees(IEnumerable<Employees> employees)
        {
            
            foreach (var e in employees)
            {
                Console.WriteLine($"EmpId: {e.EmpId}, EmpName: {e.EmpName}, EmpCity: {e.EmpCity}, EmpSalary: {e.EmpSalary}");
            }
        }
        static void Main()
        {
            List<Employees> employees = new List<Employees>();

            Console.WriteLine("Enter the number of Employees:");
            int n = Convert.ToInt32(Console.ReadLine());

            for(int i=0; i<n; i++)
            {
                Console.WriteLine($"\nEnter details for Employee {i + 1}:");

                Console.Write("Enter Employee ID: ");
                int empid = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Employee Name: ");
                string empname = Console.ReadLine();

                Console.Write("Enter Employee City: ");
                string empcity = Console.ReadLine();

                Console.Write("Enter Employee Salary: ");
                double empsalary = Convert.ToDouble(Console.ReadLine());

                employees.Add(new Employees
                {
                    EmpId = empid,
                    EmpName = empname,
                    EmpCity = empcity,
                    EmpSalary = empsalary
                });
            }
            Console.WriteLine("\na) The all Employees Data is: ");
            DisplayEmployees(employees);

            Console.WriteLine("\nb) Employees with Salary > 45000 are:");
            var Salary = employees.Where(e => e.EmpSalary > 45000);
            DisplayEmployees(Salary);

            Console.WriteLine("\nc) Employees from Bangalore are:");
            var frombangalore = employees.Where(e => e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase));
            DisplayEmployees(frombangalore);

            Console.WriteLine("\nd) Employees sorted by Name in Ascending order are:");
            var sortedName = employees.OrderBy(e => e.EmpName);
            DisplayEmployees(sortedName);

            Console.Read();
        }

    }
}
