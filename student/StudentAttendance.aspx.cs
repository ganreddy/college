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

public partial class StudentAttendance : System.Web.UI.Page
{

    DataSet ds;
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", "javascript:return validation();");
        btnAttendance.Attributes.Add("onclick", "javascript:return Checkvalidation();"); 
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            ds = objcomm.GetBatch();
            ddlBatch.DataSource=ds.Tables[0];
            ddlBatch.DataTextField = "BatchNo";
            ddlBatch.DataValueField = "BatchID";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objcomm.GetClasses();
            ddlClasses.DataSource = ds.Tables[0];
            ddlClasses.DataTextField = "ClassName";
            ddlClasses.DataValueField = "ClassID";
            ddlClasses.DataBind();
            ddlClasses.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objcomm.GetSection();
            ddlSections.DataSource = ds.Tables[0];
            ddlSections.DataTextField = "SectionName";
            ddlSections.DataValueField = "SectionID";
            ddlSections.DataBind();
            ddlSections.Items.Insert(0, new ListItem("---Select---", "0"));
            for (int i = 2005; i <= 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                
            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlYear.SelectedValue = DateTime.Today.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Today.Month.ToString();
           // ddlMonth.Items.Insert(0, new ListItem("---Select---", "0"));
            //ddlYear.SelectedIndex = 0;
            //ddlMonth.SelectedIndex = 0;
        }
    }





    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindAttendance();
    }
    protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindAttendance();
    }
    protected void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindAttendance();

    }
    public void bindAttendance()
    {
        ds = new DataSet();
        ds = objStudComm.GetStudData(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), 
            Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), 
            Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));

        gdvStuAttenance.DataSource = ds.Tables[0];
            gdvStuAttenance.DataBind();
        
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        int count=0;
        int Noofworkingdays;
        int month = Convert.ToInt32(ddlMonth.Items[ddlMonth.SelectedIndex].Value);
        int year = Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
        DataSet dsDuplicates = new DataSet();
        Label studid = new Label();
        foreach (GridViewRow gvr in gdvStuAttenance.Rows)
        {
            studid = (Label)gvr.Cells[0].FindControl("lblStudID");
            dsDuplicates = objStudComm.CheckDuplicatesStudentAttendance(Convert.ToInt32(studid.Text), month, year);
        }
        if (dsDuplicates.Tables.Count > 0)
        {
            if (dsDuplicates.Tables[0].Rows.Count > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Student Attendance Already Exists For This Month And Year";
            }
        }
        else
        {
            foreach (GridViewRow gvr in gdvStuAttenance.Rows)
            {
                Label lblStudID = new Label();
                Label lblFullName = new Label();
                TextBox txtNoOfDaysPresents = new TextBox();

                lblStudID = (Label)gvr.Cells[0].FindControl("lblStudID");
                lblFullName = (Label)gvr.Cells[1].FindControl("lblFullName");
                txtNoOfDaysPresents = (TextBox)gvr.Cells[2].FindControl("txtNoOfDaysPresents");
                Noofworkingdays = Convert.ToInt32(txtnoofworkingdays.Text);

                int i = objStudComm.AddStudentAttendance(Convert.ToInt32(lblStudID.Text), month, year, Convert.ToInt32(txtNoOfDaysPresents.Text), Noofworkingdays);
                if (i > 0)
                {
                    count = count + 1;
                }

            }
            if (count > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Student Attendance Added Successfully";
                txtnoofworkingdays.Text = "";
                ddlBatch.SelectedIndex = 0;
                ddlClasses.SelectedIndex = 0;
                ddlSections.SelectedIndex = 0;
                ddlMonth.SelectedIndex = 0;
                ddlYear.SelectedIndex = 0;
                bindAttendance();
            }
            lblMessage.Visible = true;
            lblMessage.Text = "Student Attendance Added Successfully";
            txtnoofworkingdays.Text = "";
            ddlBatch.SelectedIndex = 0;
            ddlClasses.SelectedIndex = 0;
            ddlSections.SelectedIndex = 0;
            ddlMonth.SelectedIndex = 0;
            ddlYear.SelectedIndex = 0;
            bindAttendance();
        }
    }
    //protected void chkFullance_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chkFullance.Checked)
    //    {
    //        foreach (GridViewRow gvr in gdvStuAttenance.Rows)
    //        {
    //            TextBox txtNoOfDaysPresents = new TextBox();
    //            txtNoOfDaysPresents = (TextBox)gvr.Cells[2].FindControl("txtNoOfDaysPresents");
    //            txtNoOfDaysPresents.Text = txtnoofworkingdays.Text;
               

    //        }
    //    }
    //    if (chkFullance.Checked == false)
    //    {
    //        foreach (GridViewRow gvr in gdvStuAttenance.Rows)
    //        {
    //            TextBox txtNoOfDaysPresents = new TextBox();
    //            TextBox txtnoofworkingdays = new TextBox();
    //            txtNoOfDaysPresents = (TextBox)gvr.Cells[2].FindControl("txtNoOfDaysPresents");
    //            txtNoOfDaysPresents.Text = txtnoofworkingdays.Text;
    //        }
    //    }
    //}
    protected void btnAttendance_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gdvStuAttenance.Rows)
        {
            DataSet ds1 = new DataSet();
            Label lblStudID = new Label();
            lblStudID = (Label)gvr.Cells[0].FindControl("lblStudID");
            int month = Convert.ToInt32(ddlMonth.Items[ddlMonth.SelectedIndex].Value);
            int year = Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
            int noofWorkingdays = Convert.ToInt32(txtnoofworkingdays.Text);
            TextBox txtNoOfDaysPresents = new TextBox();
            txtNoOfDaysPresents = (TextBox)gvr.Cells[2].FindControl("txtNoOfDaysPresents");
            int leavedays;
            ds1 = objStudComm.GetStudentAttendanceByLeaves(Convert.ToInt32(lblStudID.Text), month, year);
            if (ds1.Tables.Count > 0)
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    leavedays = Convert.ToInt32(ds1.Tables[0].Rows[0][3].ToString());
                    txtNoOfDaysPresents.Text = Convert.ToString((noofWorkingdays - leavedays));
                }
                else 
                {
                    txtNoOfDaysPresents.Text = txtnoofworkingdays.Text;
                }
            }
            txtNoOfDaysPresents.Enabled = false;

        }
    }
}

