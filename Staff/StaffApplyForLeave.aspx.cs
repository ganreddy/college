using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using BusinessLayer;


public partial class StaffApplyForLeave : System.Web.UI.Page
{

    BusinessLayer.StaffBL objStaff = new StaffBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        btnSave.Attributes.Add("onclick", "javascript:return validate(); ");
        //ddlStaffName.Attributes.Add("onchange","javascript:return ShowHide();");
        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = objStaff.GetStaffDetails(0);
            ddlStaffName.DataSource = ds.Tables[0];
            ddlStaffName.DataTextField = "FullName";
            ddlStaffName.DataValueField = "StaffID";
            ddlStaffName.DataBind();
            ddlStaffName.Items.Insert(0, new ListItem("---Select---", "0"));
            //ddlAuthority.DataSource = ds.Tables[0];
            //ddlAuthority.DataTextField = "FullName";
            //ddlAuthority.DataValueField = "StaffID";
            //ddlAuthority.DataBind();
            //ddlAuthority.Items.Insert(0, new ListItem("---Select---", "0"));
            //ds = objComm.GetLeaves();
            //ddlLeaveType.DataSource = ds.Tables[0];
            //ddlLeaveType.DataTextField = "LeaveType";
            //ddlLeaveType.DataValueField = "LeaveTypeId";
            //ddlLeaveType.DataBind();
            ddlLeaveType.Items.Insert(0, new ListItem("---Select---", "0"));
            txtFromDate.Text = ChangeDateFormat(DateTime.Today.ToShortDateString());
            pnlEmpDetails.Style.Add("display","none");
        }
    }

    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int StaffID, LeaveID, Authority,RecordID=0;
        DateTime From, To;
        string Purpose;
        StaffID = Convert.ToInt32(ddlStaffName.Items[ddlStaffName.SelectedIndex].Value);
        LeaveID = Convert.ToInt32(ddlLeaveType.Items[ddlLeaveType.SelectedIndex].Value);
        From = Convert.ToDateTime(ChangeDateFormat(txtFromDate.Text));
        To = Convert.ToDateTime(ChangeDateFormat(txtToDate.Text));
        Purpose = txtDescrption.Text;
        Authority = Convert.ToInt32(ddlAuthority.Items[ddlAuthority.SelectedIndex].Value);
        if (hdnLeave.Value != "")
            RecordID = Convert.ToInt32(hdnLeave.Value);
        int i = 0;   
        if (btnSave.Text == "Save")
        {            
            i = objStaff.AddStaffLeaves(StaffID, LeaveID, From, To, Purpose, Authority);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Leave Added Successfully.";
                bindStaffLeaves();
                bindStaffAvailableLeaves();
                ddlLeaveType.SelectedIndex = 0;
                ddlAuthority.SelectedIndex = 0;
                txtFromDate.Text = "";
                txtToDate.Text = "";
                txtDescrption.Text = "";
                pnlEmpDetails.Style.Add("display", "none");
               
            }
        }
        if (btnSave.Text == "Update")
        {
            i = objStaff.UpdateStaffLeaves(RecordID, LeaveID, From, To, Purpose, Authority);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Leave Updated Successfully.";
                bindStaffLeaves();
                ddlLeaveType.SelectedIndex = 0;
                ddlAuthority.SelectedIndex = 0;
                txtFromDate.Text = "";
                txtToDate.Text = "";
                txtDescrption.Text = "";
                pnlEmpDetails.Style.Add("display", "none");
                btnSave.Text = "Save";
            }
        }


    }
    protected void ddlStaffName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsTemp = new DataSet();
        if (ddlStaffName.SelectedIndex != 0)
        {
            pnlEmpDetails.Style.Add("display", "inline");
            ds = objStaff.GetStaffDetails(Convert.ToInt32(ddlStaffName.Items[ddlStaffName.SelectedIndex].Value));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblDob.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).ToShortDateString());
                    if (ds.Tables[0].Rows[0]["StaffType"].ToString() == "1")
                    {
                        lblStaffType.Text = "Teaching";
                    }
                    if (ds.Tables[0].Rows[0]["StaffType"].ToString() == "2")
                    {
                        lblStaffType.Text = "Non-Teaching";
                    }
                }
            }
            dsTemp = objStaff.GetLeavesbyStaffType(Convert.ToInt32(ds.Tables[0].Rows[0]["StaffType"].ToString()));
            if (dsTemp.Tables.Count > 0)
            {
                if (dsTemp.Tables[0].Rows.Count > 0)
                {
                    ddlLeaveType.DataSource = dsTemp.Tables[0];
                    ddlLeaveType.DataTextField = "LeaveType";
                    ddlLeaveType.DataValueField = "LeaveTypeId";
                    ddlLeaveType.DataBind();
                }
            }
            ddlLeaveType.Items.Insert(0, new ListItem("---Select---", "0"));
            bindStaffAvailableLeaves();
            bindStaffLeaves();
        }
        else
        {
            pnlEmpDetails.Style.Add("display", "none");
        }
    }
    public void bindStaffAvailableLeaves()
    {
        ds = objStaff.GetStaffAvailableLeaves(Convert.ToInt32(ddlStaffName.Items[ddlStaffName.SelectedIndex].Value));
        gdvAvailLeaves.DataSource = ds.Tables[0];
        gdvAvailLeaves.DataBind();
    }
    public void bindStaffLeaves()
    {
        ds = objStaff.GetStaffLeaves(Convert.ToInt32(ddlStaffName.Items[ddlStaffName.SelectedIndex].Value));
        gdvLeaves.DataSource = ds.Tables[0];
        gdvLeaves.DataBind();
    }
    protected void gdvLeaves_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvLeaves.Rows)
        {
            Label lblLeaveType = new Label();
            Label lblFrom = new Label();
            Label lblTo = new Label();
            Label lblPurpose = new Label();
            Label lblAuthorityID = new Label();
            Label lblRecordID = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblLeaveType = (Label)gvr.FindControl("lblLeaveId");
            lblFrom = (Label)gvr.Cells[2].FindControl("lblFrom");
            lblTo = (Label)gvr.Cells[3].FindControl("lblTo");
            lblPurpose = (Label)gvr.Cells[4].FindControl("lblPurpose");
            lblAuthorityID = (Label)gvr.Cells[5].FindControl("lblAuthorityID");
            lblRecordID = (Label)gvr.Cells[5].FindControl("lblRecordID");
            lnkEdit = (LinkButton)gvr.Cells[6].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[7].FindControl("lnkDelete");
            //lblFrom.Text = ChangeDateFormat(Convert.ToDateTime(lblFrom.Text).ToShortDateString());
            //lblTo.Text = ChangeDateFormat(Convert.ToDateTime(lblTo.Text).ToShortDateString());
            lnkEdit.CommandArgument = lblLeaveType.Text + "@" + lblFrom.Text + "@" + lblTo.Text + "@" + lblPurpose.Text + "@" + lblAuthorityID.Text+"@"+lblRecordID.Text;
            lnkDelete.CommandArgument = lblRecordID.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    protected void gdvLeaves_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i=0;

        if (e.CommandName == "editing")
        {
            ddlLeaveType.SelectedValue = e.CommandArgument.ToString().Split('@')[0].ToString();
            txtFromDate.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            txtToDate.Text = e.CommandArgument.ToString().Split('@')[2].ToString();
            txtDescrption.Text = e.CommandArgument.ToString().Split('@')[3].ToString();
            ddlAuthority.SelectedValue = e.CommandArgument.ToString().Split('@')[4].ToString();
            hdnLeave.Value = e.CommandArgument.ToString().Split('@')[5].ToString();
            btnSave.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            i = objStaff.DeleteStaffLeaves(Convert.ToInt32(e.CommandArgument));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = " Leave  Deleted Successfully";
                bindStaffLeaves();
                
            }
        }

    }
    protected void gdvLeaves_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvLeaves.PageIndex = e.NewPageIndex;
        bindStaffLeaves();
    }
}
