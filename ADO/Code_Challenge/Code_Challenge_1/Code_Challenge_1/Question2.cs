using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Code_Challenge_1
{
    class Question2
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        static void Main(string[] args)
        {
            UpdateSalaryWithProcedure();
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

        static void UpdateSalaryWithProcedure()
        {
            try
            {
                con = getConnection();
                Console.WriteLine("Enter Empid of the Employee to update:");
                int eid = Convert.ToInt32(Console.ReadLine());

               
                cmd = new SqlCommand("UpdateAndFetchSalary", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Input parameter
                cmd.Parameters.AddWithValue("@EmpId", eid);

                // Output parameter for updated salary
                SqlParameter updatedSalaryParam = new SqlParameter("@UpdatedSalary", SqlDbType.Decimal)
                {
                    Precision = 10,
                    Scale = 2,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(updatedSalaryParam);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    decimal updatedSalary = Convert.ToDecimal(updatedSalaryParam.Value);
                    Console.WriteLine("Salary Updated to: " + updatedSalary);


                    dr?.Close(); 

                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM Employee_Details WHERE Empid = @eid", con);
                    cmd2.Parameters.AddWithValue("@eid", eid);

                    dr = cmd2.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Console.WriteLine("\nUpdated Employee Details:");
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
                        Console.WriteLine("\n All Employee Records:");
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
                else
                {
                    Console.WriteLine("No matching employee found...");
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}

