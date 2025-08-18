using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "admin" && password == "admin123")
            {
                // Optional: Store session info
                Session["AdminLoggedIn"] = true;

                // Redirect to billing entry page
                Response.Redirect("BillEntry.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid login credentials.";
            }
        }
    }
}