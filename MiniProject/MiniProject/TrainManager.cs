using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace MiniProject
{
    public class TrainManager
    {
        public void AddTrain()
        {
            Console.Write("TrainNo: "); int tno = int.Parse(Console.ReadLine());
            Console.Write("Train Name: "); string tname = Console.ReadLine();
            Console.Write("Source: "); string src = Console.ReadLine();
            Console.Write("Destination: "); string dst = Console.ReadLine();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                while (true)
                {
                    Console.Write("\nEnter Class (e.g., Sleeper, 2nd AC, 3rd AC): ");
                    string cls = Console.ReadLine();
                    Console.Write("Availability: "); int avail = int.Parse(Console.ReadLine());
                    Console.Write("Cost/Seat: "); decimal cost = decimal.Parse(Console.ReadLine());

                    string sql = @"INSERT INTO Trains (TrainNo, TrainName, Source, Destination, Class, Availability, Cost)
                           VALUES (@tno,@tname,@src,@dst,@cls,@avail,@cost)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tno", tno);
                    cmd.Parameters.AddWithValue("@tname", tname);
                    cmd.Parameters.AddWithValue("@src", src);
                    cmd.Parameters.AddWithValue("@dst", dst);
                    cmd.Parameters.AddWithValue("@cls", cls);
                    cmd.Parameters.AddWithValue("@avail", avail);
                    cmd.Parameters.AddWithValue("@cost", cost);
                    cmd.ExecuteNonQuery();

                    Console.Write("Do you want to add another class for this train? (Y/N): ");
                    string choice = Console.ReadLine().Trim().ToUpper();
                    if (choice != "Y") break;
                }

                conn.Close();
            }

            Console.WriteLine("Train and class details added successfully.");
        }

    }
}
