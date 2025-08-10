using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MiniProject
{
    public class CustomerManager
    {
        public void RegisterCustomer()
        {
            Console.Write("Name: "); string name = Console.ReadLine();
            Console.Write("Age: "); int age = int.Parse(Console.ReadLine());
            Console.Write("Gender (M/F): "); string gender = Console.ReadLine();
            Console.Write("Email: "); string email = Console.ReadLine();

            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = @"INSERT INTO Customers (Name, Age, Gender, Email) 
                               VALUES (@n,@a,@g,@e); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@a", age);
                cmd.Parameters.AddWithValue("@g", gender);
                cmd.Parameters.AddWithValue("@e", email);

                conn.Open();
                int custID = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

                Console.WriteLine($"Customer registered successfully! Your Customer ID is: {custID}");
            }
        }
    }
}
