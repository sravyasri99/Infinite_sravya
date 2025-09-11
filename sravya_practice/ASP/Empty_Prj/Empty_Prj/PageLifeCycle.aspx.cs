using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Empty_Prj
{
    public partial class PageLifeCycle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Page Load Event" + "<br/>");
        }
        protected void Page_PreInt(object sender, EventArgs e)
        {
            Response.Write("Page PreInt Event" + "<br/>");
        }
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            Response.Write("Page Init Complete Event" + "<br/>");
        }
        protected void Page_PreInint(object sender, EventArgs e)
        {
            Response.Write("Page  pre Init Event" + "<br/>");
        }
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Response.Write("Page  PreLoad Event" + "<br/>");
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("Page PreRender Event" + "<br/>");
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Response.Write("Page Load complete Event" + "<br/>");
        }
        protected void Page_Render(object sender, EventArgs e)
        {
            Response.Write("Page Render Event" + "<br/>");
        }
        //protected void Page_UnLoad(object sender, EventArgs e)
        //{
        //    Response.Write("Page Un Load Event" + "<br/>");
        //}
    }
}