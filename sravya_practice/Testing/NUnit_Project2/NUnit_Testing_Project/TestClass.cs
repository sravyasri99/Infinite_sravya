using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using NUnit_Project2;

namespace NUnit_Testing_Project
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestEmployeeDetails_for_non_nullValues()
        {
            Employee emp = new Employee();
            List<Employee> elist = emp.EmployeeList();

            foreach(var item in elist)
            {
                ClassicAssert.IsNotNull(item.ID);
                ClassicAssert.IsNotNull(item.Salary);
            }
        }
    }
}
