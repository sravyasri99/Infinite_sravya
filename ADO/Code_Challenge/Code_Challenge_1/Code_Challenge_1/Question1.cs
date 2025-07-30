using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Code_Challenge_1
{
    class Question1
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        static void Main(string[] args)
        {
            InsertData();
            Console.Read();
        }

        //function to get the connection
        static SqlConnection getConnection()
        {
            con = new SqlConnection("Data Source=ICS-LT-FFQZC64\\SQLEXPRESS;Initial Catalog=sravya;" +
                "user id=sa; password=Ommisravyasri@950");
            con.Open();
            return con;
        }
        static void InsertData()
        {
            try
            {
                con = getConnection();

                Console.WriteLine("Please Enter Employee Details (Name, Gender, Salary):");
                string ename = Console.ReadLine();
                string egender = Console.ReadLine();
                float esalary = Convert.ToSingle(Console.ReadLine());

                cmd = new SqlCommand("InsertEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Input parameters
                cmd.Parameters.AddWithValue("@Name", ename);
                cmd.Parameters.AddWithValue("@Salary", esalary);
                cmd.Parameters.AddWithValue("@Gender", egender);

                // Output parameters
                SqlParameter empIdParam = new SqlParameter("@GeneratedEmpId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(empIdParam);

                SqlParameter netSalaryParam = new SqlParameter("@NetSalary", SqlDbType.Decimal)
                {
                    Precision = 10,
                    Scale = 2,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(netSalaryParam);

               
                cmd.ExecuteNonQuery(); 

                if (empIdParam.Value != DBNull.Value && netSalaryParam.Value != DBNull.Value)
                {
                    Console.WriteLine("\nEmployee Inserted Successfully!");
                    Console.WriteLine("Generated EmpId   : " + empIdParam.Value);
                    Console.WriteLine("Computed NetSalary: " + netSalaryParam.Value);
                }
                else
                {
                    Console.WriteLine("Could not fetch output values from procedure.");
                }
                // Display the inserted record using the output EmpId
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Employee_Details WHERE EmpId = @eid", con);
                cmd2.Parameters.AddWithValue("@eid", Convert.ToInt32(empIdParam.Value));

                dr = cmd2.ExecuteReader();
                if (dr.HasRows)
                {
                    Console.WriteLine("\nInserted Employee Details:");
                    while (dr.Read())
                    {
                        Console.WriteLine("Employee ID   : " + dr["EmpId"]);
                        Console.WriteLine("Name          : " + dr["Name"]);
                        Console.WriteLine("Gender        : " + dr["Gender"]);
                        Console.WriteLine("Salary        : " + dr["Salary"]);
                        Console.WriteLine("NetSalary     : " + dr["NetSalary"]);
                    }
                }
                dr.Close(); 

                // Display all employee records
                SqlCommand cmd3 = new SqlCommand("SELECT * FROM Employee_Details", con);
                dr = cmd3.ExecuteReader();
                if (dr.HasRows)
                {
                    Console.WriteLine("\nAll Employee Records:");
                    while (dr.Read())
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Employee ID   : " + dr["EmpId"]);
                        Console.WriteLine("Name          : " + dr["Name"]);
                        Console.WriteLine("Gender        : " + dr["Gender"]);
                        Console.WriteLine("Salary        : " + dr["Salary"]);
                        Console.WriteLine("NetSalary     : " + dr["NetSalary"]);
                    }
                }
                dr.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
        }

    }
}

