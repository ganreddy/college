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

public partial class StaffAttendance : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CommonDataBL objcomm = new BusinessLayer.CommonDataBL(); 
    BusinessLayer.StaffBL objStaff = new BusinessLayer.StaffBL();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        btnSave.Attributes.Add("onclick", "javascript:return validate(); ");
        btnAttendance.Attributes.Add("onclick", "javascript:return Checkvalidate(); ");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            for (int i = 1990; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(),i.ToString()));

            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
           
            ddlYear.SelectedValue = DateTime.Today.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Today.Month.ToString();
            bindAttendance();
        }

        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int count = 0;
        int Noofworkingdays;
        int i=0;
        int month = Convert.ToInt32(ddlMonth.Items[ddlMonth.SelectedIndex].Value);
        int year = Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
        DataSet dsDuplicates = new DataSet();
        Label studid = new Label();
        foreach (GridViewRow gvr in dgrid.Rows)
        {
            studid = (Label)gvr.Cells[0].FindControl("lblStaffID");
            dsDuplicates = objStaff.CheckDuplicatesStaffAttendance(Convert.ToInt32(studid.Text), month, year);
        }
        if (dsDuplicates.Tables.Count > 0)
        {
            if (dsDuplicates.Tables[0].Rows.Count > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Staff Attendance Already Exists for This Month,Year";
            }
        }
        else
        {
            foreach (GridViewRow gvr in dgrid.Rows)
            {
                DataSet ds1 = new DataSet();
                Label lblStudID = new Label();
                Label lblFullName = new Label();
                TextBox txtNoOfDaysPresents = new TextBox();
                Label lbltotaldays = new Label();
                lblStudID = (Label)gvr.Cells[0].FindControl("lblStaffID");
                lblFullName = (Label)gvr.Cells[1].FindControl("lblStaffName");
                txtNoOfDaysPresents = (TextBox)gvr.Cells[2].FindControl("txtDaysPresent");
                Noofworkingdays = Convert.ToInt32(txtnoofworkingdays.Text);
                //int month = Convert.ToInt32(ddlMonth.Items[ddlMonth.SelectedIndex].Value);
                //int year = Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
                ds1 = objStaff.GetStaffAttendanceByLeaves(Convert.ToInt32(lblStudID.Text), month, year);
                //  int i =objStaff.AddStaffAttendance(Convert.ToInt32(lblStudID.Text),month,year,Convert.ToInt32(txtNoOfDaysPresents.Text));    

                if (txtnoofworkingdays.Text != "")
                {
                    i = objStaff.AddStaffAttendance(Convert.ToInt32(lblStudID.Text), month, year, Convert.ToInt32(txtNoOfDaysPresents.Text), Noofworkingdays);
                    count = count + 1;
                }

            }
            if (count > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Staff Attendance Added Successfully";
                txtnoofworkingdays.Text = "";
            }
        }


    }
    

    public void bindAttendance()
    {
        ds = new DataSet();
        ds =objStaff.GetStaffDetails(0);
        dgrid.DataSource = ds.Tables[0];
        dgrid.DataBind(); 
        
    }

    protected void dgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgrid.PageIndex = e.NewPageIndex;
       
        bindAttendance();
    }
    //protected void chkFullance_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chkFullance.Checked)
    //    {
    //        foreach (GridViewRow gvr in dgrid.Rows)
    //        {
    //            Label lblStudID = new Label();
    //            lblStudID = (Label)gvr.Cells[0].FindControl("lblStaffID");
    //            DataSet ds1 = new DataSet();
    //            int month = Convert.ToInt32(ddlMonth.Items[ddlMonth.SelectedIndex].Value);
    //            int year = Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
    //            int noofWorkingdays = Convert.ToInt32(txtnoofworkingdays.Text);
    //            TextBox txtNoOfDaysPresents = new TextBox();
    //            txtNoOfDaysPresents = (TextBox)gvr.Cells[2].FindControl("txtDaysPresent");
    //            int leavedays;
    //            ds1 = objStaff.GetStaffAttendanceByLeaves(Convert.ToInt32(lblStudID.Text), month, year);
    //            leavedays =Convert.ToInt32(ds1.Tables[0].Rows[0][2].ToString());
    //            txtNoOfDaysPresents.Text = Convert.ToString((noofWorkingdays - leavedays));

                 
    //        }
    //    }
    //    if (chkFullance.Checked==false)
    //    {
    //        foreach (GridViewRow gvr in dgrid.Rows)
    //        {
    //            TextBox txtNoOfDaysPresents = new TextBox();
    //            TextBox txtnoofworkingdays = new TextBox();
    //            txtNoOfDaysPresents = (TextBox)gvr.Cells[2].FindControl("txtDaysPresent");
    //            txtNoOfDaysPresents.Text = txtnoofworkingdays.Text;
    //        }
    //    }
    //}
    protected void btnAttendance_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in dgrid.Rows)
        {
            Label lblStudID = new Label();
            lblStudID = (Label)gvr.Cells[0].FindControl("lblStaffID");
            DataSet ds1 = new DataSet();
            int month = Convert.ToInt32(ddlMonth.Items[ddlMonth.SelectedIndex].Value);
            int year = Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
            int noofWorkingdays = Convert.ToInt32(txtnoofworkingdays.Text);
            TextBox txtNoOfDaysPresents = new TextBox();
            txtNoOfDaysPresents = (TextBox)gvr.Cells[2].FindControl("txtDaysPresent");
            int leavedays;
            ds1 = objStaff.GetStaffAttendanceByLeaves(Convert.ToInt32(lblStudID.Text), month, year);
            if (ds1.Tables.Count > 0)
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    leavedays = Convert.ToInt32(ds1.Tables[0].Rows[0][2].ToString());
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

