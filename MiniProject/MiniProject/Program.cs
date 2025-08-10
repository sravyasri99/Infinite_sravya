using System;
using System.Data;
using System.Data.SqlClient;

namespace MiniProject
{
    public static class Database
    {
        public static string ConnectionString = "Data Source=ICS-LT-FFQZC64\\SQLEXPRESS;Initial Catalog=SQL_Assignment1;User ID=sa;Password=Ommisravyasri@950";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }

    public class UserManager
    {
        public string Role = "";

        public bool Login()
        {
            Console.Write("User ID: "); string uid = Console.ReadLine();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // Step 1: Get role for the given user
                string roleQuery = "SELECT Role FROM Users WHERE UserId = @id";
                SqlCommand roleCmd = new SqlCommand(roleQuery, conn);
                roleCmd.Parameters.AddWithValue("@id", uid);

                var roleResult = roleCmd.ExecuteScalar();
                if (roleResult == null)
                {
                    Console.WriteLine("User not found.");
                    return false;
                }

                Role = roleResult.ToString();

                // Step 2: If role is not Customer, ask for password and validate
                if (Role != "Customer")
                {
                    Console.Write("Password: "); string pwd = Console.ReadLine();

                    string authQuery = "SELECT COUNT(*) FROM Users WHERE UserId = @id AND Password = @pwd";
                    SqlCommand authCmd = new SqlCommand(authQuery, conn);
                    authCmd.Parameters.AddWithValue("@id", uid);
                    authCmd.Parameters.AddWithValue("@pwd", pwd);

                    int match = (int)authCmd.ExecuteScalar();
                    if (match == 0)
                    {
                        Console.WriteLine("Invalid credentials.");
                        return false;
                    }
                }

                conn.Close();
                Console.WriteLine($"Login successful! Role: {Role}");
                return true;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            UserManager um = new UserManager();
            if (!um.Login()) return;

            Console.WriteLine($"\nWelcome  {um.Role}");
            Console.WriteLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm}");

            CustomerManager cm = new CustomerManager();
            TrainManager tm = new TrainManager();
            ReservationManager rm = new ReservationManager();
            CancellationManager cancel = new CancellationManager();
            ReportManager report = new ReportManager();

            while (true)
            {
                Console.WriteLine("\n====================================");
                Console.WriteLine("     Railway Reservation System     ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Register Customer");
                Console.WriteLine("2. Add Train (Admin Only)");
                Console.WriteLine("3. Reserve Ticket");
                Console.WriteLine("4. Cancel Ticket");
                Console.WriteLine("5. Show Complete Report");
                Console.WriteLine("6. Soft Delete Train/Class (Admin Only)");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option (1-7): ");
                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "1": cm.RegisterCustomer(); break;
                    case "2":
                        if (um.Role == "Admin") tm.AddTrain();
                        else Console.WriteLine("Access denied. Admin only.");
                        break;
                    case "3": rm.ReserveTicket(); break;
                    case "4": cancel.CancelTicket(); break;
                    case "5":
                        Console.WriteLine($"\nGenerating report for role: {um.Role}");
                        report.ShowReport(um.Role);
                        break;
                    case "6":
                        if (um.Role == "Admin")
                        {
                            SoftDeleteManager sdm = new SoftDeleteManager();
                            Console.WriteLine("\n--- Soft Delete Options ---");
                            Console.WriteLine("a. Soft Delete Train Class");
                            Console.WriteLine("b. Soft Delete Entire Train");
                            Console.Write("Choose an option (a/b): ");
                            string delChoice = Console.ReadLine().Trim().ToLower();

                            if (delChoice == "a")
                            {
                                Console.Write("Enter TrainNo: ");
                                int tnoClass = int.Parse(Console.ReadLine());
                                Console.Write("Enter Class to delete: ");
                                string clsToDelete = Console.ReadLine();
                                sdm.SoftDeleteTrainClass(tnoClass, clsToDelete);
                            }
                            else if (delChoice == "b")
                            {
                                Console.Write("Enter TrainNo to delete: ");
                                int tnoTrain = int.Parse(Console.ReadLine());
                                sdm.SoftDeleteEntireTrain(tnoTrain);
                            }
                            else
                            {
                                Console.WriteLine("Invalid soft delete option.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Access denied. Admin only.");
                        }
                        break;
                    case "7":
                        Console.Write("Are you sure you want to exit? (Y/N): ");
                        string exitChoice = Console.ReadLine().Trim().ToUpper();
                        if (exitChoice == "Y") return;
                        break;
                    default: Console.WriteLine("Invalid option. Please select between 1 and 7."); break;

                }
            }
        }
    }

}
