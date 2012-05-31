using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Request.UserAgent.IndexOf("Chrome") > 0)
        {
            Request.Browser.Adapters.Clear();
        }

    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.UserAgent.IndexOf("Chrome") > 0)
        //{
        //    Request.Browser.Adapters.Clear();
        //}

    }
    protected void lbtnSignout_Click(object sender, EventArgs e)
    {
        Response.Redirect("../login.aspx");
    }
    
}
