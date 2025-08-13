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
        public string LoginForTest(string expectedRole)
        {
            bool success = Login(expectedRole);
            return success ? Role : "Invalid";
        }

        public bool Login(string expectedRole)
        {
            Console.Write("User ID: ");
            string uid = Console.ReadLine();

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

                // Step 2: Check if role matches expected
                if (!string.Equals(Role, expectedRole, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Access denied. You are not a {expectedRole}.");
                    return false;
                }

                // Step 3: If Admin, ask for password
                if (Role == "Admin")
                {
                    Console.Write("Password: ");
                    string pwd = Console.ReadLine();

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
            while (true) //  Outer loop for login cycle
            {
                Console.WriteLine("Welcome to Railway Reservation System");
                Console.Write("Are you logging in as Admin or Customer? (A/C): ");
                string roleChoice = Console.ReadLine().Trim().ToUpper();

                UserManager um = new UserManager();

                if (roleChoice == "A")
                {
                    Console.WriteLine("\n--- Admin Login ---");
                    if (!um.Login("Admin")) continue;
                }
                else if (roleChoice == "C")
                {
                    Console.WriteLine("\n--- Customer Login ---");
                    if (!um.Login("Customer")) continue;
                }
                else
                {
                    Console.WriteLine("Invalid role selection.");
                    continue;
                }

                Console.WriteLine($"\nWelcome {um.Role}");
                Console.WriteLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm}");

                CustomerManager cm = new CustomerManager();
                TrainManager tm = new TrainManager();
                ReservationManager rm = new ReservationManager();
                CancellationManager cancel = new CancellationManager();
                ReportManager report = new ReportManager();

                bool stayLoggedIn = true;
                while (stayLoggedIn)
                {
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("     Railway Reservation System     ");
                    Console.WriteLine("====================================");
                    Console.WriteLine("1. Register Customer");
                    Console.WriteLine("2. Reserve Ticket");
                    Console.WriteLine("3. Cancel Ticket");
                    Console.WriteLine("4. Print Particular Ticket");
                    Console.WriteLine("5. View My Reservations");
                    Console.WriteLine("6. Show Complete Report(Admin or User Specific)");
                    Console.WriteLine("7. Add Train (Admin Only)");
                    Console.WriteLine("8. Soft Delete Train/Class (Admin Only)");
                    Console.WriteLine("9. Return to login page");
                    Console.WriteLine("10.Exit Application");
                    Console.Write("Select an option (1-9): ");
                    string opt = Console.ReadLine();

                    switch (opt)
                    {
                        case "1":
                            cm.RegisterCustomer();
                            break;
                        
                        case "2":
                            rm.ReserveTicket(um.Role);
                            break;
                        case "3":
                            cancel.CancelTicket(um.Role);
                            break;
                        case "4":
                            Console.Write("Enter Reservation ID to print ticket: ");
                            int rid = int.Parse(Console.ReadLine());
                            report.PrintTicket(rid);
                            break;
                        case "5":
                            Console.Write("Enter your CustomerID to view reservations: ");
                            int viewCid = int.Parse(Console.ReadLine());
                            report.ShowCustomerReservations(viewCid);
                            break;
                        case "6":
                            Console.WriteLine($"\nGenerating report for role: {um.Role}");
                            report.ShowReport(um.Role);
                            break;
                        case "7":
                            if (um.Role == "Admin") tm.AddTrain();
                            else Console.WriteLine("Access denied. Admin only.");
                            break;
                        case "8":
                            if (um.Role == "Admin")
                            {
                                SoftDeleteManager sdm = new SoftDeleteManager();
                                Console.WriteLine("\n--- Soft Delete / Restore Options ---");
                                Console.WriteLine("a. Soft Delete Train Class");
                                Console.WriteLine("b. Soft Delete Entire Train");
                                Console.WriteLine("c. Restore Train Class");
                                Console.WriteLine("d. Restore Entire Train");
                                Console.Write("Choose an option (a/b/c/d): ");
                                string delChoice = Console.ReadLine().Trim().ToLower();

                                switch (delChoice)
                                {
                                    case "a":
                                        Console.Write("Enter TrainNo: ");
                                        int tnoClass = int.Parse(Console.ReadLine());
                                        Console.Write("Enter Class to delete: ");
                                        string clsToDelete = Console.ReadLine();
                                        sdm.SoftDeleteTrainClass(tnoClass, clsToDelete);
                                        break;

                                    case "b":
                                        Console.Write("Enter TrainNo to delete: ");
                                        int tnoTrain = int.Parse(Console.ReadLine());
                                        sdm.SoftDeleteEntireTrain(tnoTrain);
                                        break;

                                    case "c":
                                        Console.Write("Enter TrainNo: ");
                                        int tnoRestoreClass = int.Parse(Console.ReadLine());
                                        Console.Write("Enter Class to restore: ");
                                        string clsToRestore = Console.ReadLine();
                                        sdm.RestoreTrainClass(tnoRestoreClass, clsToRestore);
                                        break;

                                    case "d":
                                        Console.Write("Enter TrainNo to restore: ");
                                        int tnoRestoreTrain = int.Parse(Console.ReadLine());
                                        sdm.RestoreEntireTrain(tnoRestoreTrain);
                                        break;

                                    default:
                                        Console.WriteLine("Invalid option.");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Access denied. Admin only.");
                            }
                            break;
                       
                        case "9":
                            Console.WriteLine("Logging out and returning to login screen...\n");
                            stayLoggedIn = false; //  Return to login
                            break;
                        case "10":
                            Console.Write("Are you sure you want to exit the application? (Y/N): ");
                            string confirmExit = Console.ReadLine().Trim().ToUpper();
                            if (confirmExit == "Y")
                            {
                                Console.WriteLine("Exiting application. Goodbye!");
                                Environment.Exit(0); //  Terminate program
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please select between 1 and 9.");
                            break;
                    }
                }
            }
        }
    }


}
