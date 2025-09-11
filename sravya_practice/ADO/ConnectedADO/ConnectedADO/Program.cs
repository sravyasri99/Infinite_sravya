using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConnectedADO
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        static void Main(string[] args)
        {
            //SelectData();
            //DeleteData();
            InsertData();
            //UpdateSalary();

            Console.Read();
        }

        //commom function to get the connection
        static SqlConnection getConnection()
        {
            con = new SqlConnection("Data Source=ICS-LT-FFQZC64\\SQLEXPRESS;Initial Catalog=sravya;" +
                "user id=sa; password=Ommisravyasri@950");
            con.Open();
            return con;
        }

        static void SelectData()
        {
            try
            {
                con = getConnection();
                Console.WriteLine("Enter the Department :");
                int deptid = Convert.ToInt32(Console.ReadLine());
                cmd = new SqlCommand("select * from employee where departmentid = @did", con);
                //cmd.Connection = con;
                cmd.Parameters.AddWithValue("@did", deptid);
                dr = cmd.ExecuteReader();
                bool status = dr.HasRows;
                if (status)
                {
                    Console.WriteLine("Starting to display records..");
                    while (dr.Read())
                    {
                        // Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[3] + " " + dr[4]);
                        Console.WriteLine("Employee ID : " + dr["Empid"]);
                        Console.WriteLine("Employee name: " + dr["empname"]);
                        Console.WriteLine("Employee Salary : " + dr["salary"]);
                    }
                }
                else
                    Console.WriteLine("No Data Fetched ..");
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
        }

        static void InsertData()
        {
            try
            {
                con = getConnection();
                //hard coded values during insertion will lead violation
                // cmd = new SqlCommand("Insert into employee values(500,'Nandini','Female',6400,2,'543465')");
                Console.WriteLine("Please Enter Employee Details viz Empid,Name,Gender,Salary,Deptid,Phone :");
                int eid = Convert.ToInt32(Console.ReadLine());
                string ename = Console.ReadLine();
                string egender = Console.ReadLine();
                float esalary = Convert.ToSingle(Console.ReadLine());
                int edept = Convert.ToInt32(Console.ReadLine());
                string ephone = Console.ReadLine();

                cmd = new SqlCommand("insert into employee values(@ecode,@empname,@egen,@esal,@edid,@eph)");
                cmd.Connection = con;

                //bind or mapping the C# variables to SQL parameters
                cmd.Parameters.AddWithValue("@ecode", eid);
                cmd.Parameters.AddWithValue("@empname", ename);
                cmd.Parameters.AddWithValue("@egen", egender);
                cmd.Parameters.AddWithValue("@esal", esalary);
                cmd.Parameters.AddWithValue("@edid", edept);
                cmd.Parameters.AddWithValue("@eph", ephone);

                int result = cmd.ExecuteNonQuery();
             if (result > 0)
                {
                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM employee WHERE Empid = @ecode", con);
                    cmd2.Parameters.AddWithValue("@ecode", eid);

                    dr = cmd2.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Console.WriteLine("\nInserted Employee Details:");
                        while (dr.Read())
                        {
                            Console.WriteLine("Employee ID   : " + dr["EmpId"]);
                            Console.WriteLine("Name          : " + dr["EmpName"]);
                            Console.WriteLine("Gender        : " + dr["Gender"]);
                            Console.WriteLine("Salary        : " + dr["salary"]);
                            Console.WriteLine("Dept ID       : " + dr["DepartmentId"]);
                            Console.WriteLine("Phone         : " + dr["Phone"]);
                            
                        }
                    }
                    dr.Close();
                }
                    
                else
                    Console.WriteLine("Could not Insert...");
            }
            catch (SqlException s)
            {
                Console.WriteLine(s.Message);
            }
        }

        static void UpdateSalary()
        {
            try
            {
                con = getConnection();
                Console.WriteLine("Enter Empid of the Employee whose salary you want to update:");
                int eid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Updated Salary:");
                float esalary = Convert.ToSingle(Console.ReadLine());

                cmd = new SqlCommand("UPDATE employee SET salary = @esal WHERE EmpId = @ecode");
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("@ecode", eid);
                cmd.Parameters.AddWithValue("@esal", esalary);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Salary Updated successfully..");
                else
                    Console.WriteLine("No matching record found...");
            }
            catch (SqlException s)
            {
                Console.WriteLine(s.Message);
            }
        }

        static void DeleteData()
        {
            try
            {
                con = getConnection();
                Console.WriteLine("Enter Empid to delete :");
                int empid = Convert.ToInt32(Console.ReadLine());

                SqlCommand cmd1 = new SqlCommand("select * from employee where " + "empid=@eid", con);
                cmd1.Parameters.AddWithValue("@eid", empid);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while(dr1.Read())
                {
                    for(int i=0; i<dr1.FieldCount;i++)
                    {
                        Console.WriteLine(dr1[i]);
                    }
                }
                con.Close();
                Console.WriteLine();
                Console.WriteLine("Are you sure to delete this employee ? (Y/N)");
                string answer = Console.ReadLine();
                if(answer == "Y" || answer  == "y")
                {
                    cmd =new SqlCommand("delete from employee where empid=@eid", con);
                    cmd.Parameters.AddWithValue("@eid", empid);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("record deleted...");

                }
            }
            catch(SqlException se)
            {
                Console.WriteLine(se.Message);
            }
        }

    }
}
