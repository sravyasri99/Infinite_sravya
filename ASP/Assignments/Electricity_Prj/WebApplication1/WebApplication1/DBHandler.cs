using System.Data.SqlClient;
using System.Configuration;
using System;

namespace WebApplication1
{
        public class DBHandler
        {
            public SqlConnection GetConnection()
            {
                string connStr = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;
                return new SqlConnection(connStr);
            }
        }
    }


