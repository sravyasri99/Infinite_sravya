using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Project_2
{
    public interface IEmployeeDAL
    {
        List<Employee> GetAllEmployees();
    }
    public class EmployeeDALImplementor : IEmployeeDAL
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee(){ID=1, Name = "Nandini",Department="IT"},
                new Employee(){ID=1, Name = "Rakesh",Department="Admin"},
                new Employee(){ID=1, Name = "Susmitha",Department="Quality"},
            };
            return empList;
        }
    }
}
