using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Validation_Prj
{
    public partial class CustomForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblmsg.Text = "Data Validated..., and now Saving..";
                lblmsg.ForeColor = System.Drawing.Color.DarkGreen;
            }
            else
            {
                lblmsg.Text = " Validation Failed..., Not Saving..";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void cvLoginName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int len = args.Value.Length;
            args.IsValid = (len >= 6 && len <= 10) || len > 8;
        }

        protected void cvPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int len = args.Value.Length;
            args.IsValid = (len >= 3 && len <= 10);
        }

    }
}