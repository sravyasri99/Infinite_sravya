using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Project_2
{
    public class EmployeeBAL
    {
        public EmployeeDALImplementor employeeDAL;

        //public EmployeeBAL(IEmployeeDAL _edal)
        //{
        //    employeeDAL = (EmployeeDALImplementor)_edal;
        //}
        //public IEmployeeDAL EmpDataObject
        //{
        //    set
        //    {
        //        this.employeeDAL = (EmployeeDALImplementor)value;
        //    }
        //}

        //3.Methos Injection
        public List<Employee> SelectAllEmployees(IEmployeeDAL employeeDAL)

        public List<Employee>SelectAllEmployees()
        {
            //employeeDAL = new EmployeeDAL();
            return employeeDAL.GetAllEmployees();
        }
    }
}
