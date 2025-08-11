using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MiniProject
{
    public class ReportManager
    {
        public void ShowReport(string role)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // 1️ Train Availability Report (Accessible to all)
                Console.WriteLine("\n--- Train Availability Report ---");
                string availabilitySql = @"SELECT TrainNo, TrainName, Source, Destination, Class, Availability 
                                       FROM Trains ORDER BY TrainNo, Class";
                using (SqlCommand cmd = new SqlCommand(availabilitySql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"TrainNo: {reader["TrainNo"]}, Name: {reader["TrainName"]}, Route: {reader["Source"]} to {reader["Destination"]}, Class: {reader["Class"]}, Seats Available: {reader["Availability"]}");
                    }
                }

                //  Admin-only reports
                if (role.ToLower() != "admin")
                {
                    Console.WriteLine("\nAccess to detailed reports is restricted to administrators.");
                    conn.Close();
                    return;
                }

                // 2️ Daily Booking Summary
                Console.WriteLine("\n--- Daily Booking Summary ---");
                string summarySql = @"
                    SELECT 
                    COUNT(R.ReservationID) AS TicketsBooked,
                    COUNT(C.CancellationID) AS TicketsCancelled,
                    ISNULL(SUM(C.RefundAmount), 0) AS TotalRefunds,
                    ISNULL(SUM(R.TotalCost), 0) - ISNULL(SUM(C.RefundAmount), 0) AS RevenueEarnedToday
                    FROM Reservations R
                    LEFT JOIN Cancellations C 
                    ON R.ReservationID = C.ReservationID
                    WHERE CAST(R.BookingDate AS DATE) = CAST(GETDATE() AS DATE)
                    AND (C.CancellationID IS NULL OR CAST(C.CancellationDate AS DATE) = CAST(GETDATE() AS DATE));";
                using (SqlCommand cmd = new SqlCommand(summarySql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int booked = Convert.ToInt32(reader["TicketsBooked"]);
                        int cancelled = Convert.ToInt32(reader["TicketsCancelled"]);
                        decimal refunds = reader["TotalRefunds"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["TotalRefunds"]);
                        decimal revenue = reader["RevenueEarnedToday"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["RevenueEarnedToday"]);

                        Console.WriteLine($" Tickets Booked: {booked}");
                        Console.WriteLine($" Tickets Cancelled: {cancelled}");
                        Console.WriteLine($" Refunds Issued: {refunds}");
                        Console.WriteLine($" Revenue Earned Today: {revenue}");
                    }
                }

                // 3️ Daily Cancellation Summary
                Console.WriteLine("\n--- Cancellations Today ---");
                string cancelSql = @"SELECT COUNT(*) AS Cancelled, SUM(RefundAmount) AS Refunds 
                                 FROM Cancellations WHERE CAST(CancellationDate AS DATE) = CAST(GETDATE() AS DATE)";
                using (SqlCommand cmd = new SqlCommand(cancelSql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int cancelled = Convert.ToInt32(reader["Cancelled"]);
                        decimal refunds = reader["Refunds"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Refunds"]);
                        Console.WriteLine($"Tickets Cancelled: {cancelled}, Total Refunds: {refunds}");
                    }
                }

                // 4️ Ask if admin wants Reservation Report
                Console.Write("\nDo you want to view reservations for a specific journey date? (Y/N): ");
                string resChoice = Console.ReadLine().Trim().ToUpper();
                if (resChoice == "Y")
                {
                    Console.Write("Enter reservation date (yyyy-mm-dd): ");
                    DateTime resDate = DateTime.Parse(Console.ReadLine());
                    string resDateSql = @"SELECT ReservationID, CustomerName, TrainNo, Class, SeatsBooked, TotalCost, Status 
                                      FROM Reservations WHERE CAST(DateOfJourney AS DATE) = @resDate";
                    using (SqlCommand cmd = new SqlCommand(resDateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@resDate", resDate);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine($"\n--- Reservations on {resDate.ToShortDateString()} ---");
                            while (reader.Read())
                            {
                                Console.WriteLine($"ReservationID: {reader["ReservationID"]}, Name: {reader["CustomerName"]}, TrainNo: {reader["TrainNo"]}, Class: {reader["Class"]}, Seats: {reader["SeatsBooked"]}, Cost: ₹{reader["TotalCost"]}, Status: {reader["Status"]}");
                            }
                        }
                    }
                }

                // 5️ Ask if admin wants Cancellation Report
                Console.Write("\nDo you want to view cancellations for a specific date? (Y/N): ");
                string cancelChoice = Console.ReadLine().Trim().ToUpper();
                if (cancelChoice == "Y")
                {
                    Console.Write("Enter cancellation date (yyyy-mm-dd): ");
                    DateTime cancelDate = DateTime.Parse(Console.ReadLine());
                    string cancelDateSql = @"SELECT C.CancellationID, R.CustomerName, R.TrainNo, R.Class, C.RefundAmount 
                                         FROM Cancellations C 
                                         JOIN Reservations R ON C.ReservationID = R.ReservationID
                                         WHERE CAST(C.CancellationDate AS DATE) = @cancelDate";
                    using (SqlCommand cmd = new SqlCommand(cancelDateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cancelDate", cancelDate);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine($"\n--- Cancellations on {cancelDate.ToShortDateString()} ---");
                            while (reader.Read())
                            {
                                Console.WriteLine($"CancellationID: {reader["CancellationID"]}, Name: {reader["CustomerName"]}, TrainNo: {reader["TrainNo"]}, Class: {reader["Class"]}, Refund: ₹{reader["RefundAmount"]}");
                            }
                        }
                    }
                }

                conn.Close();
            }
        }
    }

}
