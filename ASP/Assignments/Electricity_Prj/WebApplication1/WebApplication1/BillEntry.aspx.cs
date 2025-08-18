using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1
{
    public partial class BillEntry : System.Web.UI.Page
    {
        private ElectricityBoard board = new ElectricityBoard();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["BillList"] = new List<ElectricityBill>();
                ViewState["CurrentIndex"] = 0;
            }
        }

        protected void btnStep1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtTotalBills.Text.Trim(), out int total) && total > 0)
            {
                ViewState["TotalBills"] = total;
                pnlStep1.Visible = false;
                pnlStep2.Visible = true;
            }
            else
            {
                lblResult.Text = "Please enter a valid number of bills.";
            }
        }

        protected void btnStep2_Click(object sender, EventArgs e)
        {
            string cno = txtCno.Text.Trim();
            try
            {
                ElectricityBill temp = new ElectricityBill();
                temp.ConsumerNumber = cno; // This will throw FormatException if invalid

                ViewState["ConsumerNumber"] = cno;
                lblResult.Text = ""; //  Clear previous error message

                lblStep3Info.Text = $"Consumer Number: <b>{cno}</b>";
                pnlStep2.Visible = false;
                pnlStep3.Visible = true;
            }

            catch (FormatException)
            {
                lblResult.Text = "Given Consumer Number is invalid. Please enter again.";
                txtCno.Text = ""; // clear invalid input
                pnlStep2.Visible = true;
            }

        }


        protected void btnStep3_Click(object sender, EventArgs e)
        {
            string cname = txtCname.Text.Trim();
            if (string.IsNullOrEmpty(cname))
            {
                lblResult.Text = "Consumer Name is required.";
                lblStep3Info.Text = $"Consumer Number: <b>{ViewState["ConsumerNumber"]}</b>";
                pnlStep3.Visible = true;
                return;
            }

            ViewState["ConsumerName"] = cname;
            lblStep4Info.Text = $"Consumer Number: <b>{ViewState["ConsumerNumber"]}</b><br/>Consumer Name: <b>{cname}</b>";
            pnlStep3.Visible = false;
            pnlStep4.Visible = true;
        }

        protected void btnStep4_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtUnits.Text.Trim(), out int units) || units < 0)
            {
                lblResult.Text = "Given units is invalid";
                lblStep4Info.Text = $"Consumer Number: <b>{ViewState["ConsumerNumber"]}</b><br/>Consumer Name: <b>{ViewState["ConsumerName"]}</b>";
                pnlStep4.Visible = true;
                return;
            }

            string cno = ViewState["ConsumerNumber"].ToString();
            string cname = ViewState["ConsumerName"].ToString();

            var eb = new ElectricityBill
            {
                ConsumerNumber = cno,
                ConsumerName = cname,
                UnitsConsumed = units
            };

            board.CalculateBill(eb);
            board.AddBill(eb);

            var billList = (List<ElectricityBill>)ViewState["BillList"];
            billList.Add(eb);
            ViewState["BillList"] = billList;

            // Before adding bill info
            lblResult.Text = ""; // ✅ Clear previous error

            lblResult.Text += $"{eb.ConsumerNumber} {eb.ConsumerName} {eb.UnitsConsumed} Bill Amount : {eb.BillAmount:0.##}<br/>";

            int currentIndex = (int)ViewState["CurrentIndex"] + 1;
            ViewState["CurrentIndex"] = currentIndex;

            if (currentIndex < (int)ViewState["TotalBills"])
            {
                txtCno.Text = "";
                txtCname.Text = "";
                txtUnits.Text = "";
                pnlStep4.Visible = false;
                pnlStep2.Visible = true;
            }
            else
            {
                pnlStep4.Visible = false;
                lblResult.Text += "<br/>";
            }
        }



        protected void btnGetLast_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLastN.Text.Trim(), out int n) || n < 1)
            {
                lblResult.Text = "Enter a valid positive number for Last 'N'.";
                return;
            }

            var lastBills = board.Generate_N_BillDetails(n);
            var sb = new StringBuilder();
            sb.AppendLine("<br/>Details of last ‘N’ bills:<br/>");

            foreach (var bill in lastBills)
            {
                sb.AppendLine($"EB Bill for {bill.ConsumerName} is {bill.BillAmount:0.##}<br/>");
            }

            lblResult.Text += sb.ToString();
        }
    }
}
