using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpQuestion
{
    public class Employee_Details
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Employee_Details> empList = new List<Employee_Details>();

            Console.Write("Enter the number of employees in the list: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Employee_Details employee = new Employee_Details();

                Console.WriteLine($"\n--- Enter details for Employee {i + 1} ---");
                Console.Write($"Enter the {i + 1} EmployeeID: ");
                employee.EmployeeID = int.Parse(Console.ReadLine());

                Console.Write("First Name: ");
                employee.FirstName = Console.ReadLine();

                Console.Write("Last Name: ");
                employee.LastName = Console.ReadLine();

                Console.Write("Title: ");
                employee.Title = Console.ReadLine();
                Console.Write("DOB (yyyy-mm-dd): ");
                employee.DOB = DateTime.Parse(Console.ReadLine());

                Console.Write("DOJ (yyyy-mm-dd): ");
                employee.DOJ = DateTime.Parse(Console.ReadLine());

                Console.Write("City: ");
                employee.City = Console.ReadLine();

                empList.Add(employee);
            }

            Console.WriteLine("The details of all the Employees are:");
            foreach (var emp in empList)
            {
                Console.WriteLine($"{emp.EmployeeID} | {emp.FirstName} {emp.LastName} | {emp.Title} | {emp.City}");
            }

            var nonMumbaiEmployees = empList.Where(emp => emp.City != "Mumbai");

            Console.WriteLine("\nDetails of all the employees whose location is not Mumbai:");
            foreach (var emp in nonMumbaiEmployees)
            {
                Console.WriteLine($"{emp.EmployeeID} | {emp.FirstName} {emp.LastName} | {emp.Title} | {emp.City}");
            }


            var asstManagers = empList.Where(emp => emp.Title == "AsstManager");
            Console.WriteLine($"\ndetails of all the employee whose title is AsstManager are :");
            foreach (var emp in asstManagers)
            {
                Console.WriteLine($"{emp.EmployeeID} | {emp.FirstName} {emp.LastName} | {emp.Title} | {emp.City}");
            }

            var lastNameStartsWithS = empList.Where(emp => emp.LastName.StartsWith("S"));
            Console.WriteLine($"\ndetails of all the employee whose Last Name start with S are :");
            foreach (var emp in lastNameStartsWithS)
            {
                Console.WriteLine($"{emp.EmployeeID} | {emp.FirstName} {emp.LastName} | {emp.Title} | {emp.City}");
            }

            Console.Read();
        }
    }
}
