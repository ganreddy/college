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

public partial class Staff_Delete_Staff : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.CommonDataBL objCommon = new CommonDataBL();
    BusinessLayer.StaffBL objStaff = new StaffBL(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        btnSave.Attributes.Add("onclick", "javascript:return validation();");
        if (!IsPostBack)
        {
            ds = objStaff.GetStaffDetails(0);
            ddlStaffId.DataSource = ds.Tables[0];
            ddlStaffId.DataTextField = "FullName";
            ddlStaffId.DataValueField = "StaffID";
            ddlStaffId.DataBind();
            ddlStaffId.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ds = objStaff.DeleteStaffDetails(Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value));
        lblMessage.Visible = true;
        lblMessage.Text = "Staff Deleted Successfully";
    }
}
