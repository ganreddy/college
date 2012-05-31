using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BusinessLayer;

public partial class Login : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text != "" && txtPassword.Text != "")
        {
            ds = objComm.GetLoginDetails(txtUsername.Text, txtPassword.Text);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["UserID"] = ds.Tables[0].Rows[0][0].ToString();
                    Session["UserName"] = ds.Tables[0].Rows[0][1].ToString();
                    Session["UserType"] = ds.Tables[0].Rows[0][3].ToString();
                    Response.Redirect("~/student/StudentAdmin.aspx");
                }
            }
           // Response.Redirect("~/student/StudentAdmin.aspx");
        }
    }
    
}
