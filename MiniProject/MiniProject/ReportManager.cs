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
                string availabilitySql = @"SELECT TrainNo, TrainName, Source, Destination, Class, Availability,Cost, IsActive 
                           FROM Trains ORDER BY TrainNo, Class";

                using (SqlCommand cmd = new SqlCommand(availabilitySql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string status = (bool)reader["IsActive"] ? "Active" : "Inactive";
                        Console.WriteLine($"TrainNo: {reader["TrainNo"]}, Name: {reader["TrainName"]}, Route: {reader["Source"]} to {reader["Destination"]}, Class: {reader["Class"]}, Seats Available: {reader["Availability"]},Cost: {reader["Cost"]}, Status: {status}");
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
                //  Ask if admin wants to view reservations booked on a specific date
                Console.Write("\nDo you want to view reservations booked on a specific date? (Y/N): ");
                string bookedChoice = Console.ReadLine().Trim().ToUpper();
                if (bookedChoice == "Y")
                {
                    Console.Write("Enter booking date (yyyy-MM-dd): ");
                    string inputDate = Console.ReadLine().Trim();
                    DateTime bookingDate;
                    if (DateTime.TryParseExact(inputDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out bookingDate))
                    {
                        Console.WriteLine($"\n--- Reservations Booked on {bookingDate:yyyy-MM-dd} ---");
                        string bookedSql = @"SELECT ReservationID, CustomerName, TrainNo, Class, SeatsBooked, TotalCost, Status, DateOfJourney 
                             FROM Reservations 
                             WHERE CAST(BookingDate AS DATE) = @BookingDate";
                        using (SqlCommand cmd = new SqlCommand(bookedSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@BookingDate", bookingDate.Date);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                bool hasRows = false;
                                while (reader.Read())
                                {
                                    hasRows = true;
                                    Console.WriteLine($"ReservationID: {reader["ReservationID"]}, Name: {reader["CustomerName"]}, TrainNo: {reader["TrainNo"]}, Class: {reader["Class"]}, Seats: {reader["SeatsBooked"]}, Cost: {reader["TotalCost"]}, Journey Date: {Convert.ToDateTime(reader["DateOfJourney"]).ToString("yyyy-MM-dd")}, Status: {reader["Status"]}");
                                }
                                if (!hasRows)
                                {
                                    Console.WriteLine("No reservations were booked on that date.");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
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
                          FROM Reservations 
                          WHERE DateOfJourney >= @resDate AND DateOfJourney < DATEADD(DAY, 1, @resDate)";

                    using (SqlCommand cmd = new SqlCommand(resDateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@resDate", resDate);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine($"\n--- Reservations on {resDate:yyyy-MM-dd} ---");
                            bool hasRows = false;
                            while (reader.Read())
                            {
                                hasRows = true;
                                Console.WriteLine($"ReservationID: {reader["ReservationID"]}, Name: {reader["CustomerName"]}, TrainNo: {reader["TrainNo"]}, Class: {reader["Class"]}, Seats: {reader["SeatsBooked"]}, Cost: {reader["TotalCost"]}, Status: {reader["Status"]}");
                            }
                            if (!hasRows)
                            {
                                Console.WriteLine("No reservations found for this date.");
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
                                Console.WriteLine($"CancellationID: {reader["CancellationID"]}, Name: {reader["CustomerName"]}, TrainNo: {reader["TrainNo"]}, Class: {reader["Class"]}, Refund: {reader["RefundAmount"]}");
                            }
                        }
                    }
                }

                conn.Close();
            }
        }

        public void ShowCustomerReservations(int customerId)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // Step 1: Get customer name
                string nameQuery = "SELECT Name FROM Customers WHERE CustomerID = @cid";
                SqlCommand nameCmd = new SqlCommand(nameQuery, conn);
                nameCmd.Parameters.AddWithValue("@cid", customerId);
                string customerName = nameCmd.ExecuteScalar()?.ToString() ?? "Unknown";

                // Step 2: Get reservations
                string sql = @"SELECT ReservationID, TrainNo, Class, DateOfJourney, SeatsBooked, TotalCost, Status, BookingDate 
                       FROM Reservations 
                       WHERE CustomerID = @cid 
                       ORDER BY BookingDate DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cid", customerId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine($"\n--- Reservations for {customerName} (CustomerID: {customerId}) ---");

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No reservations found for this customer.");
                        return;
                    }

                    // Header
                    Console.WriteLine("\n{0,-15} {1,-10} {2,-10} {3,-12} {4,-6} {5,-10} {6,-18} {7,-12}",
                        "ReservationID", "TrainNo", "Class", "JourneyDate", "Seats", "Cost", "Status", "BookingDate");

                    Console.WriteLine(new string('-', 95));

                    // Rows
                    while (reader.Read())
                    {
                        Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,-12} {4,-6} {5,-10} {6,-18} {7,-12}",
                            reader["ReservationID"],
                            reader["TrainNo"],
                            reader["Class"],
                            Convert.ToDateTime(reader["DateOfJourney"]).ToString("yyyy-MM-dd"),
                            reader["SeatsBooked"],
                            reader["TotalCost"],
                            reader["Status"],
                            Convert.ToDateTime(reader["BookingDate"]).ToString("yyyy-MM-dd"));
                    }
                }

                conn.Close();
            }
        }

        public void PrintTicket(int reservationId)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT R.ReservationID, R.TrainNo, R.Class, R.DateOfJourney, R.SeatsBooked, R.TotalCost, R.Status, R.BookingDate,
                              R.CustomerName, C.CustomerID
                       FROM Reservations R
                       JOIN Customers C ON R.CustomerID = C.CustomerID
                       WHERE R.ReservationID = @rid";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@rid", reservationId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No ticket found with the given Reservation ID.");
                        return;
                    }

                    reader.Read();
                    Console.WriteLine("\n========== TICKET DETAILS ==========");
                    Console.WriteLine($"Reservation ID : {reader["ReservationID"]}");
                    Console.WriteLine($"Customer Name  : {reader["CustomerName"]} (ID: {reader["CustomerID"]})");
                    Console.WriteLine($"Train No       : {reader["TrainNo"]}");
                    Console.WriteLine($"Class          : {reader["Class"]}");
                    Console.WriteLine($"Journey Date   : {Convert.ToDateTime(reader["DateOfJourney"]).ToString("yyyy-MM-dd")}");
                    Console.WriteLine($"Seats Booked   : {reader["SeatsBooked"]}");
                    Console.WriteLine($"Total Cost     : {Convert.ToDecimal(reader["TotalCost"]):F2}");
                    Console.WriteLine($"Status         : {reader["Status"]}");
                    Console.WriteLine($"Booking Date   : {Convert.ToDateTime(reader["BookingDate"]).ToString("yyyy-MM-dd")}");
                    Console.WriteLine("====================================");
                }

                conn.Close();
            }
        }



    }

}
