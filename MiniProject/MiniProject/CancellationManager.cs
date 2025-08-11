using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MiniProject
{
    public class CancellationManager
    {
        public void CancelTicket()
        {
            Console.Write("Reservation ID: ");
            int rid = int.Parse(Console.ReadLine());

            Console.Write("How many seats to cancel? ");
            int seats = int.Parse(Console.ReadLine());
            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand("CancelTicket", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReservationID", rid);
                cmd.Parameters.AddWithValue("@SeatsToCancel", seats);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal refund = Convert.ToDecimal(reader["RefundAmount"]);
                        string status = reader["NewStatus"].ToString();
                        string rate = reader["RefundRatePercent"].ToString();

                        Console.WriteLine("\n Ticket cancelled.");
                        Console.WriteLine($"Refund Rate Applied: {rate}%");
                        Console.WriteLine($"Refund Amount: {refund}");
                        Console.WriteLine($"Updated Reservation Status: {status}");
                    }
                    else
                    {
                        Console.WriteLine(" Cancellation failed or no data returned.");
                    }
                }
            }
        }
    }

}
