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

public partial class DefineLeaves : System.Web.UI.Page
{
    StaffBL objStaff = new StaffBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindLeaves(0);
        }
    }
    public void bindLeaves(int LeaveType)
    {
        ds = objStaff.GetLeaves(LeaveType);
        gdvLeaves.DataSource = ds.Tables[0];
        gdvLeaves.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objStaff.AddLeaves(txtLeaveType.Text, Convert.ToInt32(ddlStaffType.Items[ddlStaffType.SelectedIndex].Value), Convert.ToInt32(txtNoofDays.Text), Convert.ToInt32(txtCummulative.Text));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtLeaveType.Text + " Staff Leave Added Successfully";
                txtLeaveType.Text = "";
                ddlStaffType.SelectedValue = "0";
                txtNoofDays.Text = "";
                txtCummulative.Text = "";
                bindLeaves(0);
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtLeaveType.Text + "Staff Leave Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objStaff.EditLeaves(Convert.ToInt32(hdnAccountFundID.Value),txtLeaveType.Text, Convert.ToInt32(ddlStaffType.Items[ddlStaffType.SelectedIndex].Value), Convert.ToInt32(txtNoofDays.Text), Convert.ToInt32(txtCummulative.Text));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtLeaveType.Text + " Staff Leave Modified Successfully";
                txtLeaveType.Text = "";
                ddlStaffType.SelectedValue = "0";
                txtNoofDays.Text = "";
                txtCummulative.Text = "";
                btnAdd.Text = "Add";
                bindLeaves(0);
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtLeaveType.Text + "Staff Leave Already Exists";

            }
        }
    }
    protected void gdvLeaves_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvLeaves.Rows)
        {
            Label lblLeaveTypeID = new Label();
            Label lblLeaveType = new Label();
            Label lblStaffTypeID = new Label();
            Label lblStaffType = new Label();
            Label lblNoofDays = new Label();
            Label lblCummulative = new Label();

            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblLeaveTypeID = (Label)gvr.Cells[0].FindControl("lblLeaveTypeID");
            lblLeaveType = (Label)gvr.Cells[1].FindControl("lblLeave");
            lblStaffTypeID = (Label)gvr.Cells[2].FindControl("lblStaffTypeID");
            lblStaffType = (Label)gvr.Cells[3].FindControl("lblStaffType");
            lblNoofDays = (Label)gvr.Cells[4].FindControl("lblNoofDays");
            lblCummulative = (Label)gvr.Cells[5].FindControl("lblCummulative");
            if (lblStaffTypeID.Text == "1")
                lblStaffType.Text = "Teaching";
            if (lblStaffTypeID.Text == "2")
                lblStaffType.Text = "Non-Teaching";
            lnkEdit = (LinkButton)gvr.Cells[6].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[7].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblLeaveTypeID.Text + "@" + lblLeaveType.Text + "@" + lblStaffTypeID.Text + "@" + lblNoofDays.Text + "@" + lblCummulative.Text;
            lnkDelete.CommandArgument = lblLeaveTypeID.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }

    }
    protected void gdvLeaves_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvLeaves.PageIndex = e.NewPageIndex;
        bindLeaves(0);
    }
    protected void gdvLeaves_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtLeaveType.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnAccountFundID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            ddlStaffType.SelectedValue = e.CommandArgument.ToString().Split('@')[2].ToString();
            txtNoofDays.Text = e.CommandArgument.ToString().Split('@')[3].ToString();
            txtCummulative.Text = e.CommandArgument.ToString().Split('@')[4].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnAccountFundID.Value = e.CommandArgument.ToString();
            i = objStaff.DeleteLeaves(Convert.ToInt32(hdnAccountFundID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtLeaveType.Text + " Staff Leave Deleted Successfully";
                txtLeaveType.Text = "";
                bindLeaves(0);
            }
        }
    }
}
