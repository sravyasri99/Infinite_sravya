using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    public class Employee
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }
        
        public string Department { get; set; }
    }

    class LocalFunction_Usecases
    {
        static void Main()
        {
            Employee emp1 = new Employee()
            {
                Id = 1001,
                Name = "Sravya",
                Gender = "Female",
                Salary = 56000,
                Department = "IT"

            };
            bool IsInserted = AddEmployee(emp1);
            Console.WriteLine($"Is Emplpyee with id {emp1.Id} inserted ? :{0}", IsInserted);

            Employee emp2 = new Employee()
            {
                Id = 1002,
                Name = "Susmitha",
                Department = "IT"
            };
            IsInserted = AddEmployee(emp2);
            Console.WriteLine($"Is Emplpyee with id {emp1.Id} inserted ? :"+" "+ IsInserted);
            Console.Read();

        }
        public static bool AddEmployee(Employee eRequest)
        {
            var validationReault = IsRequestValid();
            if(validationReault.isvalid == false)
            {
                Console.WriteLine($"{nameof(eRequest)}'S {nameof(validationReault.errorMessage)}:"+$"{validationReault.errorMessage}");
                return false;

            }
            return true;

            //Local Function
            (bool isvalid, string errorMessage) IsRequestValid()
            {
                if(eRequest == null)
                {
                    throw new ArgumentNullException(nameof(eRequest), $"TH e{nameof(eRequest)} cannot be null");

                }

                var msg = new Lazy<StringBuilder>();
                if (string.IsNullOrWhiteSpace(eRequest.Name))
                {
                    msg.Value.AppendLine($" The {nameof(eRequest)}'s {nameof(eRequest.Name)} property cannot be empty");
                }
                if(eRequest.Id <= 0)
                {
                    msg.Value.AppendLine($" The {nameof(eRequest)}'s {nameof(eRequest.Id)} property cannot be less than or equal to zero");
                }
                if(eRequest.Salary <= 10000 || eRequest.Salary >=60000 )
                {
                    msg.Value.AppendLine($" The {nameof(eRequest)}'s {nameof(eRequest.Salary)} property has to be between 10000 to 60000 only");
                }

                if(msg.IsValueCreated)
                {
                    var errorMessage = msg.Value.ToString();
                    return (isvalid: false, errorMessage: errorMessage);
                }
                return (isvalid: true, errorMessage: string.Empty);
            }
        }
    }
}
