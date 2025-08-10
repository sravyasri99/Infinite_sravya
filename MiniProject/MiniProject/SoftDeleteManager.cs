using System;
using System.Data.SqlClient;

namespace MiniProject
{
    public class SoftDeleteManager
    {
        // Soft delete a specific class of a train
        public void SoftDeleteTrainClass(int trainNo, string className)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = @"UPDATE Trains SET IsActive = 0 
                               WHERE TrainNo = @tno AND Class = @cls";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tno", trainNo);
                cmd.Parameters.AddWithValue("@cls", className);
                conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
            }
            Console.WriteLine($"Class '{className}' for TrainNo {trainNo} marked as inactive.");
        }

        // Soft delete all classes of a train
        public void SoftDeleteEntireTrain(int trainNo)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = @"UPDATE Trains SET IsActive = 0 WHERE TrainNo = @tno";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tno", trainNo);
                conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
            }
            Console.WriteLine($"TrainNo {trainNo} marked as inactive.");
        }

        // Restore a specific class of a train
        public void RestoreTrainClass(int trainNo, string className)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = @"UPDATE Trains SET IsActive = 1 
                               WHERE TrainNo = @tno AND Class = @cls";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tno", trainNo);
                cmd.Parameters.AddWithValue("@cls", className);
                conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
            }
            Console.WriteLine($"Class '{className}' for TrainNo {trainNo} restored.");
        }

        // Restore all classes of a train
        public void RestoreEntireTrain(int trainNo)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = @"UPDATE Trains SET IsActive = 1 WHERE TrainNo = @tno";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tno", trainNo);
                conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
            }
            Console.WriteLine($"TrainNo {trainNo} and all its classes restored.");
        }
    }
}
