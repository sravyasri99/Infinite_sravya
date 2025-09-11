using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Building_DataSets
{
    class Datasets_Manipulations
    {
        public static void Main()
        {
            DataSet_Ops();
            Console.Read();
        }
        public static void DataSet_Ops()
        {
            DataTable tableCust = new DataTable("Customers");
            tableCust.Columns.Add("CustomerID", typeof(int));
            tableCust.Columns.Add("CustomerName", typeof(string));

            //populate data
            DataRow row = tableCust.NewRow();
            row["CustomerID"] = 1;
            row["CustomerName"] = "Infinite Ltd.";
            tableCust.Rows.Add(row);

            row = tableCust.NewRow();
            row["CustomerID"] = 4;
            row["CustomerName"] = "CTS.";
            tableCust.Rows.Add(row);

            row = tableCust.NewRow();
            row["CustomerID"] = 3;
            row["CustomerName"] = "InFOSYS.LTD";
            tableCust.Rows.Add(row);

            DataTable tableOrders = new DataTable("Orders");
            tableCust.Columns.Add("OrderID", typeof(int));
            tableCust.Columns.Add("OrderValue", typeof(decimal));

            DataRow r = tableOrders.NewRow();
            r["OrderID"] = 100;
            r["OrderValue"] = 25000.75;

            tableOrders.Rows.Add(r);

            //SORTING
            tableCust.DefaultView.Sort = "CustomerName DESC";

            //filtering
            DataRow[] result = tableCust.Select("CustomerID > 2");

           

            //CONVERTING THE DATATABLE TO A LIST

            List<DataRow> dtlist = tableCust.AsEnumerable().ToList();

            //var custlist = tableCust.AsEnumerable().Select(r1 => new Customer
            //{
            //    CustomerId = r1.Field<int>("CustomerID"),
            //    CustomerName = r1.Field<string>("CustomerName")
            //}).ToList();
            foreach(DataRow var in dtlist)
            {
                Console.WriteLine(var["CustomerID"] + " " + var["CustomerName"]);
            }
        }
    }
}
