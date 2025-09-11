using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ConnectedADO
{
    //Client
    class ADO2
    {
        public static void main()
        {
            Region region = new Region();
            SqlDataReader ret_dr = region.SelectRegion();
            while(ret_dr.Read())
            {
                Console.WriteLine($"Region ID : {ret_dr["regionid"]} and the Region Description is :{ret_dr["regiondescription"]}");
            }
            Console.Read();
        }
    }
    //Business logic
    class Region
    {
        public int RegionID { get; set; }
        public string RegionDescription { get; set; }

        DataAccess da = new DataAccess();

        internal SqlDataReader SelectRegion()
        {
            SqlDataReader dr = da.SelectRegionData();
            return dr;
        }
    }
    //Data Layer
    class DataAccess
    {
        static SqlConnection con = null;
        static SqlCommand cmd = null;
        static SqlDataReader dr;

        public SqlConnection GetConnection()
        {
            string connect = "Data Source=ICS-LT-FFQZC64\\SQLEXPRESS;Initial Catalog=pract;" +
                "user id=sa; password=Ommisravyasri@950";
            con = new SqlConnection(connect);
            con.Open();
            return con;
        }

        public SqlDataReader SelectRegionData()
        {
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("Select * from Region", con);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch(SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                con.Close();
            }
            return dr;
        }
    }
}
