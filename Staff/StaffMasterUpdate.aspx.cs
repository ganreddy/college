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
using System.Data.SqlClient;
using BusinessLayer;
public partial class Staff_StaffMasterUpdate : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.CommonDataBL objCommon = new CommonDataBL();
    BusinessLayer.StaffBL objStaff = new StaffBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ds = objStaff.GetStaffDetails(0);
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
