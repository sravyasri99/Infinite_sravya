using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Employee
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
            List<Employee> empList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("16/11/1984"), DOJ = DateTime.Parse("8/6/2011"), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("20/08/1984"), DOJ = DateTime.Parse("7/7/2012"), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("14/11/1987"), DOJ = DateTime.Parse("12/4/2015"), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("3/6/1990"), DOJ = DateTime.Parse("2/2/2016"), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("8/3/1991"), DOJ = DateTime.Parse("2/2/2016"), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("7/11/1989"), DOJ = DateTime.Parse("8/8/2014"), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.Parse("2/12/1989"), DOJ = DateTime.Parse("1/6/2015"), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.Parse("11/11/1993"), DOJ = DateTime.Parse("6/11/2014"), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.Parse("12/8/1992"), DOJ = DateTime.Parse("3/12/2014"), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.Parse("12/4/1991"), DOJ = DateTime.Parse("2/1/2016"), City = "Pune" }
            };
            // 1.Display a list of all the employee who have joined before 1/1/2015

            var joinedBefore2015 = empList.Where(e => e.DOJ < new DateTime(2015, 1, 1));
            Console.WriteLine("1. Employees joined before 1/1/2015:");
            foreach (var e in joinedBefore2015)
                Console.WriteLine($"{e.FirstName} {e.LastName} - DOJ: {e.DOJ.ToShortDateString()}");

            // 2. DOB after 1/1/1990
            var dobAfter1990 = empList.Where(e => e.DOB > new DateTime(1990, 1, 1));
            Console.WriteLine("\n2. Employees born after 1/1/1990:");
            foreach (var e in dobAfter1990)
                Console.WriteLine($"{e.FirstName} {e.LastName} - DOB: {e.DOB.ToShortDateString()}");

            // 3. Title is Consultant or Associate
            var selectedTitles = empList.Where(e => e.Title == "Consultant" || e.Title == "Associate");
            Console.WriteLine("\n3. Employees who are Consultant or Associate:");
            foreach (var e in selectedTitles)
                Console.WriteLine($"{e.FirstName} {e.LastName} - {e.Title}");

            // 4. Total employees
            Console.WriteLine($"\n4. Total number of employees: {empList.Count}");

            // 5. Total from Chennai
            Console.WriteLine($"5. Total employees from Chennai: {empList.Count(e => e.City == "Chennai")}");

            // 6. Highest EmployeeID
            Console.WriteLine($"6. Highest Employee ID: {empList.Max(e => e.EmployeeID)}");

            // 7. Joined after 1/1/2015
            Console.WriteLine($"7. Employees joined after 1/1/2015: {empList.Count(e => e.DOJ > new DateTime(2015, 1, 1))}");

            // 8. Title NOT Associate
            Console.WriteLine($"8. Employees NOT titled 'Associate': {empList.Count(e => e.Title != "Associate")}");

            // 9. Employees by City
            Console.WriteLine("\n9. Employees grouped by City:");
            var byCity = empList.GroupBy(e => e.City);
            foreach (var group in byCity)
                Console.WriteLine($"{group.Key}: {group.Count()}");

            // 10. Employees by City & Title
            Console.WriteLine("\n10. Employees grouped by City and Title:");
            var byCityTitle = empList.GroupBy(e => new { e.City, e.Title });
            foreach (var group in byCityTitle)
                Console.WriteLine($"{group.Key.City} - {group.Key.Title}: {group.Count()}");

            // 11. Youngest Employee
            var youngest = empList.OrderByDescending(e => e.DOB).First();
            Console.WriteLine($"\n11. Youngest Employee: {youngest.FirstName} {youngest.LastName} - DOB: {youngest.DOB.ToShortDateString()}");

            Console.Read();
        
        }
    }
}
