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
public partial class Staff_EditStaffAttendance : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CommonDataBL objcomm = new BusinessLayer.CommonDataBL();
    BusinessLayer.StaffBL objStaff = new BusinessLayer.StaffBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAttendance.Attributes.Add("onclick", "javascript:return validate(); ");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            for (int i = 1990; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));

            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));

            //ddlYear.SelectedValue = DateTime.Today.Year.ToString();
           // ddlMonth.SelectedValue = DateTime.Today.Month.ToString();
            bindAttendance();
        }

    }
    private void bindAttendance()
    {
        ds = new DataSet();
        ds = objStaff.GetEditStaffAttendance(Convert.ToInt32(ddlMonth.Items[ddlMonth.SelectedIndex].Value), Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value));
        dgrid.DataSource = ds.Tables[0];
        dgrid.DataBind();
    }
    protected void dgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        dgrid.EditIndex = e.NewEditIndex;
        bindAttendance();
    }
    protected void dgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int i = 0;
        Label lblStaffID = new Label();
        lblStaffID = (Label)dgrid.Rows[e.RowIndex].Cells[0].FindControl("lblStaffID");
        Label lblDays = new Label();
        lblDays = (Label)dgrid.Rows[e.RowIndex].Cells[2].FindControl("lblDays");
        TextBox txtNoOfDays = new TextBox();
        txtNoOfDays = (TextBox)dgrid.Rows[e.RowIndex].Cells[2].FindControl("txtNoOfdays");
        i = objStaff.UpdateStaffAttendance(Convert.ToInt32(lblStaffID.Text), Convert.ToInt32(txtNoOfDays.Text));
        lblMessage.Visible = true;
        lblMessage.Text = "Staff Attendance Updated Successfully";
        dgrid.EditIndex = -1;
        bindAttendance();

    }
    protected void dgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgrid.PageIndex = e.NewPageIndex;
        bindAttendance();
    }
    protected void dgrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        dgrid.EditIndex = -1;
        bindAttendance();
    }
    protected void btnAttendance_Click(object sender, EventArgs e)
    {
        bindAttendance();
    }
}
