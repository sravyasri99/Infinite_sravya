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
        public void ReserveTicket(string role)
        {
            Console.Write("CustomerID: "); int cid = int.Parse(Console.ReadLine());
            Console.Write("CustomerName: "); string cna = Console.ReadLine();
            Console.Write("TrainNo: "); int tno = int.Parse(Console.ReadLine());

            DateTime dt;
            while (true)
            {
                Console.Write("Travel Date (yyyy-mm-dd): ");
                string input = Console.ReadLine();

                if (!DateTime.TryParse(input, out dt))
                {
                    Console.WriteLine("Invalid date format. Please enter in yyyy-mm-dd format.");
                    continue;
                }

                if (dt.Date < DateTime.Today)
                {
                    Console.WriteLine("Reservation failed: Cannot book ticket for a past date.");
                }
                else
                {
                    break;
                }
            }

            Console.Write("Class: "); string cls = Console.ReadLine();
            Console.Write("Seat Count: "); int count = int.Parse(Console.ReadLine());

            decimal baseFare = 0;
            decimal discount = 0;
            decimal netAmount = 0;
            int reservationId = 0;

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // Check if train-class is active
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

                // Get fare per seat
                string fareQuery = @"SELECT cost FROM Trains WHERE TrainNo = @TrainNo AND Class = @Class";
                using (SqlCommand fareCmd = new SqlCommand(fareQuery, conn))
                {
                    fareCmd.Parameters.AddWithValue("@TrainNo", tno);
                    fareCmd.Parameters.AddWithValue("@Class", cls);
                    baseFare = Convert.ToDecimal(fareCmd.ExecuteScalar());
                }

                decimal totalFare = baseFare * count;

                if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    discount = totalFare * 0.10m; // 10% discount
                    Console.WriteLine($"Admin discount applied: {discount}");
                }

                netAmount = totalFare - discount;

                // Call stored procedure
                SqlCommand cmd = new SqlCommand("ReserveTicket", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", cid);
                cmd.Parameters.AddWithValue("@TrainNo", tno);
                cmd.Parameters.AddWithValue("@DateOfJourney", dt);
                cmd.Parameters.AddWithValue("@Class", cls);
                cmd.Parameters.AddWithValue("@SeatsBooked", count);
                cmd.Parameters.AddWithValue("@CustomerName", cna);
                cmd.Parameters.AddWithValue("@NetAmount", netAmount);
                cmd.Parameters.AddWithValue("@DiscountAmount", discount);

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
            Console.WriteLine($"Total Fare: {baseFare * count}");
            Console.WriteLine($"Discount: {discount}");
            Console.WriteLine($"Net Amount Payable: {netAmount}");
        }
    }

}
