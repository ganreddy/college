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
using BusinessLayer;

public partial class StaffPrevPosts : System.Web.UI.Page
{
    #region Variable Declaration
    DataSet ds = new DataSet();
    BusinessLayer.CommonDataBL objCommon = new CommonDataBL();
    BusinessLayer.StaffBL objStaff = new StaffBL(); 
    #endregion   
    #region Page load 
    /// <summary>
    /// Page Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        lblMessage1.Attributes.Add("style", "color:red;font-weight:bold;");
        //lblMessage.Visible = false;
        btnSave.Attributes.Add("onclick", "javascript:return validation();");
        if (!IsPostBack)
        {
            ds = objStaff.GetStaffDetails(0);
            ddlStaffId.DataSource = ds.Tables[0];
            ddlStaffId.DataTextField = "FullName";
            ddlStaffId.DataValueField = "StaffID";
            ddlStaffId.DataBind();
            ddlStaffId.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetCader();
            ddlNameOfPost.DataSource = ds.Tables[0];
            ddlNameOfPost.DataTextField = "CaderType";
            ddlNameOfPost.DataValueField = "CaderID";
            ddlNameOfPost.DataBind();
            ddlNameOfPost.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        
    #endregion

    }

    public void bindPrevPostings()
    {
        ds = new DataSet();
       
        ds = objStaff.GetStaffPreviousPostings(Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvPrevPosts.DataSource = ds.Tables[0];
                gdvPrevPosts.DataBind();
                lblMessage1.Visible = false;
            }
            else
            {
                ds = objStaff.GetStaffPreviousPostings(Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value));
                gdvPrevPosts.DataSource = ds.Tables[0];
                gdvPrevPosts.DataBind();
                lblMessage1.Visible = true;
            }

        }
    }
    #region Button Save Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        int i = 0;
        int StaffId = 0, NameOfPost = 0, recordID=0;
        ds = objStaff.GetStaffPreviousPostings(Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value));
        //if (ds.Tables.Count > 0)
        //{
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        GridViewRow gvr = 
        //        //recordID = Convert.ToInt32(ds.Tables[0].Rows[1]["recordID"].ToString());
        //    }
        //}
        string  WorkPlace = "", ReasonForTransfer = "";
        DateTime FromDate = DateTime.Today, ToDate = DateTime.Today;
        //try
         //{
            StaffId = Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value);
            NameOfPost = ddlNameOfPost.SelectedIndex;
            if (txtFrom.Text != "")
                FromDate = Convert.ToDateTime(ChangeDateFormat(txtFrom.Text));
            if(txtTo.Text!="")
                ToDate = Convert.ToDateTime(ChangeDateFormat(txtTo.Text));
            WorkPlace = txtWorkPlace.Text;
            ReasonForTransfer = txtReasonForTransfer.Text;
            if (btnSave.Text == "Save")
            {
                i = objStaff.AddStaffPreviousPostings(StaffId, NameOfPost, WorkPlace, FromDate, ToDate, ReasonForTransfer);

                if (i > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage1.Text = "";
                    lblMessage.Text = "Staff Previous Posting Added Successfully";
                    ddlStaffId.SelectedIndex = 0;
                    ddlNameOfPost.SelectedIndex = 0;
                    txtWorkPlace.Text = "";
                    txtFrom.Text = "";
                    txtTo.Text = "";
                    txtReasonForTransfer.Text = "";
                    bindPrevPostings();
                }

                //}

                //catch (Exception Ex)
                //{
                //}
            }
            if (hdnRecordID.Value != "")
                recordID = Convert.ToInt32(hdnRecordID.Value);
        if (btnSave.Text == "Update")
        {
            i = objStaff.EditStaffPreviousPostings(Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value), Convert.ToInt32(ddlNameOfPost.Items[ddlNameOfPost.SelectedIndex].Value),
                                                   txtWorkPlace.Text, FromDate, ToDate, txtReasonForTransfer.Text, recordID);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage1.Text = "";
                lblMessage.Text = "Staff Previous Posting Modified Successfully";
                ddlStaffId.SelectedIndex = 0;
                ddlNameOfPost.SelectedIndex = 0;
                txtWorkPlace.Text = "";
                txtFrom.Text = "";
                txtTo.Text = "";
                txtReasonForTransfer.Text = "";
                btnSave.Text = "Save";
                bindPrevPostings();
            }
        }
    } 
    #endregion
    

    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void ddlStaffId_SelectedIndexChanged(object sender, EventArgs e)
    {  
        bindPrevPostings();   
    }
    protected void gdvPrevPosts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvPrevPosts.PageIndex = e.NewPageIndex;
        bindPrevPostings();
    }
    protected void gdvPrevPosts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvPrevPosts.Rows)
        {
             Label lblStaffID = new Label();
            Label lblcaderid = new Label();
            Label lblNameOfThePost = new Label();
            Label lblWorkPlace = new Label();
            Label lblFromDate = new Label();
            Label lblToDate = new Label();
            Label lblReasonForTransfer = new Label();
            Label lblRecordID = new Label();

            LinkButton lnkEdit = new LinkButton();
            lblStaffID = (Label)gvr.Cells[0].FindControl("lblStaffID");
            lblcaderid = (Label)gvr.Cells[1].FindControl("lblcaderid");
            lblNameOfThePost = (Label)gvr.Cells[1].FindControl("lblNameOfThePost");
            lblWorkPlace = (Label)gvr.Cells[2].FindControl("lblWorkPlace");
            lblFromDate = (Label)gvr.Cells[3].FindControl("lblFromDate");
            lblToDate = (Label)gvr.Cells[4].FindControl("lblToDate");
            lblReasonForTransfer = (Label)gvr.Cells[5].FindControl("lblReasonForTransfer");
            lblRecordID = (Label)gvr.Cells[6].FindControl("lblRecordID");
            lnkEdit = (LinkButton)gvr.Cells[7].FindControl("lnkEdit");
            lnkEdit.CommandArgument = lblStaffID.Text + "@" + lblcaderid.Text + "@" + lblNameOfThePost.Text + "@" + lblWorkPlace.Text + "@" + lblFromDate.Text + "@" + lblToDate.Text + "@" + lblReasonForTransfer.Text + "@" + lblRecordID.Text;
        }
    }

    protected void gdvPrevPosts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        if (e.CommandName == "editing")
        {
            hdnRecordID.Value = e.CommandArgument.ToString().Split('@')[7].ToString();
            hdnStaffPrvPosting.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            ddlNameOfPost.SelectedValue = e.CommandArgument.ToString().Split('@')[1].ToString();
            txtWorkPlace.Text = e.CommandArgument.ToString().Split('@')[3].ToString();
            txtFrom.Text =e.CommandArgument.ToString().Split('@')[4].ToString();
            txtTo.Text =e.CommandArgument.ToString().Split('@')[5].ToString();
            txtReasonForTransfer.Text = e.CommandArgument.ToString().Split('@')[6].ToString();
            btnSave.Text = "Update";
        }
    }
}
