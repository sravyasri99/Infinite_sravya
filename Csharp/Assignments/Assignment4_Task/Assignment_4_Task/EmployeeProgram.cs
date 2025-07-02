using System;
using System.Collections.Generic;

class Employee
{
    public int EmpId;
    public string EmpName;
    public string Department;
    public double Salary;
}

class EmployeeProgram
{
    static List<Employee> employeedetails = new List<Employee>();

    static void Main()
    {

        Console.WriteLine("------ Employee Management Menu -------");
        Console.WriteLine(" Add New Employee -1");
        Console.WriteLine(" View All Employees -2");
        Console.WriteLine(" Search Employee by ID -3");
        Console.WriteLine(" Update Employee Details -4");
        Console.WriteLine(" Delete Employee -5");
        Console.WriteLine(" Exit -6");
        Console.Write("Enter your choice from the above : ");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                AddEmployee();
                break;
            case 2:
                ViewEmployees();
                break;
            case 3:
                SearchEmployee();
                break;
            case 4:
                UpdateEmployee();
                break;
            case 5:
                DeleteEmployee();
                break;
            case 6:
                Console.WriteLine("Program exited");
                return;

        }
        Console.Read();

    }

    static void AddEmployee()
    {
        try
        {
            Employee emp = new Employee();

            Console.Write("Enter Employee ID: ");
            emp.EmpId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Name: ");
            emp.EmpName = Console.ReadLine();

            Console.Write("Enter Department: ");
            emp.Department = Console.ReadLine();

            Console.Write("Enter Salary: ");
            emp.Salary = double.Parse(Console.ReadLine());

            employeedetails.Add(emp);
            Console.WriteLine("Employee added successfully");
        }
        catch
        {
            Console.WriteLine("Wrong details entered");
        }
    }

    static void ViewEmployees()
    {
        if (employeedetails.Count == 0)
        {
            Console.WriteLine("No employees found");
            return;
        }

        foreach (var emp in employeedetails)
        {
            Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, Dept: {emp.Department}, Salary: {emp.Salary}");
        }
    }

    static void SearchEmployee()
    {
        Console.Write("Enter Emp ID to search: ");
        int Empid = Convert.ToInt32(Console.ReadLine());

        Employee emp = null;
        foreach (var e in employeedetails)
        {
            if (e.EmpId == Empid)
            {
                emp = e;
                break;
            }
        }

        if (emp != null)
        {
            Console.WriteLine($"Found -> ID: {emp.EmpId}, Name: {emp.EmpName}, Dept: {emp.Department}, Salary: {emp.Salary}");
        }
        else
        {
            Console.WriteLine("Employee not found");
        }
    }

    static void UpdateEmployee()
    {
        Console.Write("Enter ID to update: ");
        int Empid = Convert.ToInt32(Console.ReadLine());

        Employee emp = null;
        foreach (var e in employeedetails)
        {
            if (e.EmpId == Empid)
            {
                emp = e;
                break;
            }
        }

        if (emp != null)
        {
            Console.Write("Enter new Name: ");
            emp.EmpName = Console.ReadLine();

            Console.Write("Enter new Department: ");
            emp.Department = Console.ReadLine();

            Console.Write("Enter new Salary: ");
            emp.Salary = double.Parse(Console.ReadLine());

            Console.WriteLine("Employee updated successfully");
        }
        else
        {
            Console.WriteLine("Employee not found");
        }
    }

    static void DeleteEmployee()
    {
        Console.Write("Enter ID to delete: ");
        int Empid = Convert.ToInt32(Console.ReadLine());

        Employee emp = null;
        foreach (var e in employeedetails)
        {
            if (e.EmpId == Empid)
            {
                emp = e;
                break;
            }
        }

        if (emp != null)
        {
            employeedetails.Remove(emp);
            Console.WriteLine("Employee was deleted");
        }
        else
        {
            Console.WriteLine("Employee not found");
        }
    }
}
