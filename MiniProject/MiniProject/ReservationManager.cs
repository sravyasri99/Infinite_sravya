using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MiniProject
{
    public class ReservationManager
    {
        public void ReserveTicket()
        {
            Console.Write("CustomerID: "); int cid = int.Parse(Console.ReadLine());
            Console.Write("CustomerName: "); string cna = Console.ReadLine();
            Console.Write("TrainNo: "); int tno = int.Parse(Console.ReadLine());
            Console.Write("Travel Date (yyyy-mm-dd): "); DateTime dt = DateTime.Parse(Console.ReadLine());
            Console.Write("Class: "); string cls = Console.ReadLine();
            Console.Write("Seat Count: "); int count = int.Parse(Console.ReadLine());

            int reservationId = 0;

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                //  Check if train-class is active
                string checkQuery = @"SELECT COUNT(*) FROM Trains 
                              WHERE TrainNo = @TrainNo AND Class = @Class AND IsActive = 1";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@TrainNo", tno);
                    checkCmd.Parameters.AddWithValue("@Class", cls);

                    int activeCount = (int)checkCmd.ExecuteScalar();
                    if (activeCount == 0)
                    {
                        Console.WriteLine("Reservation failed: Train-Class combination is inactive.");
                        return;
                    }
                }

                //  Proceed with reservation
                SqlCommand cmd = new SqlCommand("ReserveTicket", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", cid);
                cmd.Parameters.AddWithValue("@TrainNo", tno);
                cmd.Parameters.AddWithValue("@DateOfJourney", dt);
                cmd.Parameters.AddWithValue("@Class", cls);
                cmd.Parameters.AddWithValue("@SeatsBooked", count);
                cmd.Parameters.AddWithValue("@CustomerName", cna);

                SqlParameter outputParam = new SqlParameter("@ReservationID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                cmd.ExecuteNonQuery();
                reservationId = (int)outputParam.Value;
                conn.Close();
            }

            Console.WriteLine("Reservation successful.");
            Console.WriteLine($"Your Reservation ID is: {reservationId}");
        }


    }
}
