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
public partial class StaffQualifications : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.CommonDataBL objCommon = new CommonDataBL();
    BusinessLayer.StaffBL objStaff = new StaffBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        btnSave.Attributes.Add("onclick", "javascript:return validation();");
        if (!IsPostBack)
        {
            ds = objStaff.GetStaffDetails(0);
            ddlStaffId.DataSource = ds.Tables[0];
            ddlStaffId.DataTextField = "StaffID";
            ddlStaffId.DataValueField = "StaffID";
            ddlStaffId.DataBind();
            
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            int staffid, Degree, Subject,Yearofpassing,Percentage;
            string University;
            staffid = Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value);
            Degree = Convert.ToInt32(ddlNameOfDegree.Items[ddlNameOfDegree.SelectedIndex].Value);
            Subject = Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value);
            Yearofpassing = Convert.ToInt32(ddlPassingYear1.Items[ddlPassingYear1.SelectedIndex].Value);
            Percentage = Convert.ToInt32(txtPersent.Text);
            University = txtNameOfUniversity.Text;

           int i= objStaff.AddStaffQualification(staffid, Degree, Subject, University, Yearofpassing, Percentage);
           if (i > 0)
           {
               Response.Write(@"<script language='javascript'>alert('Update is successful.')</script>");

           }
  
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void ddlStaffId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ds = objStaff.GetStaffDetails(Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value) );
            lblName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();    
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}
