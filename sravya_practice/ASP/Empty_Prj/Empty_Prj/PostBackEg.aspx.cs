using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Empty_Prj
{
    public partial class PostBackEg : System.Web.UI.Page
    {
        int ClicksCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //let us check if the page is requested for the first time or not
            if(!IsPostBack)
            {
                textcount.Text = "0";
            }
        }

        protected void btncount_Click(object sender, EventArgs e)
        {
            //option 1
            //ClicksCount = ClicksCount + 1;
            //textcount.Text = ClicksCount.ToString();

            //OPTION 2 USING EXPLICIT VIEWSTATE
            if(ViewState["clicks"]!=null)
            {
                ClicksCount = (int)ViewState["clicks"] + 1;
            }
            ViewState["clicks"] = ClicksCount;
            textcount.Text = ClicksCount.ToString();

        }
    }
}