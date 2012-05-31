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
public partial class StaffTrainingCourses : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.CommonDataBL objCommon = new CommonDataBL();
    BusinessLayer.StaffBL objStaff = new StaffBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        lblMessage1.Attributes.Add("style", "color:red;font-weight:bold;");
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
        try
        {
            int StaffId;
            string CourseName, PlaceHeld;
            DateTime FromDate = DateTime.Today, toDate = DateTime.Today;
            StaffId = (Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value));
            CourseName = txtTrainingCourseName.Text;
            PlaceHeld = txtPlaceHeldAt.Text;
            if (btnSave.Text == "Save")
            {

            if (txtFrom.Text != "")
                FromDate = Convert.ToDateTime(ChangeDateFormat(txtFrom.Text));
            if (txtTo.Text != "")
                toDate = Convert.ToDateTime(ChangeDateFormat(txtTo.Text));
            //int i = objStaff.AddStaffTrainingsures(StaffId,CourseName,PlaceHeld,FromDate,toDate);
            
                int i = objStaff.AddStaffTrainingCourses(StaffId, CourseName, PlaceHeld, FromDate, toDate);
                if (i > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage1.Text = "";
                    lblMessage.Text = "Staff Training Added Successfully";
                    ddlStaffId.SelectedIndex = 0;
                    txtTrainingCourseName.Text = "";
                    txtPlaceHeldAt.Text = "";
                    txtFrom.Text = "";
                    txtTo.Text = "";
                    bindTrainingCourses();
                    //Response.Write(@"<script language='javascript'>alert('Update is successful.')</script>");
                }

            }
             if (btnSave.Text == "Update")
            {
                 if (txtFrom.Text != "")
                FromDate = Convert.ToDateTime(ChangeDateFormat(txtFrom.Text));
            if (txtTo.Text != "")
                toDate = Convert.ToDateTime(ChangeDateFormat(txtTo.Text));
                int i = objStaff.UpdateStaffTrainingCourses(StaffId, CourseName, PlaceHeld, FromDate, toDate);
                if (i > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage1.Text = "";
                    lblMessage.Text = "Staff Training Modified Successfully";
                    ddlStaffId.SelectedIndex = 0;
                    txtTrainingCourseName.Text = "";
                    txtPlaceHeldAt.Text = "";
                    txtFrom.Text = "";
                    txtTo.Text = "";
                    bindTrainingCourses();
                    btnSave.Text = "Save";
                }
            }
        }
        catch (Exception)
        {

            throw;
        }

    }
    
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void ddlStaffId_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindTrainingCourses();
    }
    public void bindTrainingCourses()
    {
        ds = new DataSet();
        ds = objStaff.GetStaff_TrainingCourses(Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvTrainingCourses.DataSource = ds.Tables[0];
                gdvTrainingCourses.DataBind();
                lblMessage1.Visible = false;
            }
            else
            {
                ds = objStaff.GetStaff_TrainingCourses(Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value));
                gdvTrainingCourses.DataSource = ds.Tables[0];
                gdvTrainingCourses.DataBind();
                lblMessage1.Visible = true;
            }
        }
    }
    protected void gdvTrainingCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvTrainingCourses.PageIndex = e.NewPageIndex;
        bindTrainingCourses();
    }
    protected void gdvTrainingCourses_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i;
        if (e.CommandName == "editing")
        {
            ddlStaffId.SelectedValue = e.CommandArgument.ToString().Split('@')[0].ToString();   
           txtTrainingCourseName.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
           txtPlaceHeldAt.Text = e.CommandArgument.ToString().Split('@')[2].ToString();
           txtFrom.Text = e.CommandArgument.ToString().Split('@')[3].ToString();
           txtTo.Text = e.CommandArgument.ToString().Split('@')[4].ToString();  
           Message.Value= e.CommandArgument.ToString().Split('@')[0].ToString();
           btnSave.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            i = 0;
            string TraingCoursName = "";
            Message.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            TraingCoursName = e.CommandArgument.ToString().Split('@')[1].ToString();
            i = objStaff.DeleteStaffTrainingCourses(Convert.ToInt32(Message.Value), TraingCoursName);
            if (i != 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = " Staff Training Courses Deleted Successfully";
                bindTrainingCourses();
            }
        }
    }
    protected void gdvTrainingCourses_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvTrainingCourses.Rows)
        {
            Label lblStaffID = new Label();
            Label lblCourseName = new Label();
            Label lblPlaceHeld = new Label();
            Label lblFromDate = new Label();
            Label lblToDate = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblStaffID = (Label)gvr.Cells[0].FindControl("lblStaffID");
            lblCourseName = (Label)gvr.Cells[1].FindControl("lblCourseName");
            lblPlaceHeld = (Label)gvr.Cells[2].FindControl("lblPlaceHeld");
            lblFromDate = (Label)gvr.Cells[3].FindControl("lblFromDate");
            lblToDate = (Label)gvr.Cells[4].FindControl("lblToDate");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblStaffID.Text + "@" + lblCourseName.Text+"@"+lblPlaceHeld.Text+"@"+lblFromDate.Text+"@"+lblToDate.Text;
            lnkDelete.CommandArgument = lblStaffID.Text + "@" + lblCourseName.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
}
