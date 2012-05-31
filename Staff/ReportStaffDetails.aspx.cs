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

public partial class Staff_ReportStaffDetails : System.Web.UI.Page
{
    BusinessLayer.StaffBL objStaff = new StaffBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        //btnReport.Attributes.Add("onclick", "javascript:return validate();");
        ds = new DataSet();
        if (!IsPostBack)
        {    
            ds = objStaff.GetStaffDetails(0);
            ddlStaffId.DataSource = ds;
            ddlStaffId.DataTextField = "FullName";
            ddlStaffId.DataValueField = "StaffID";
            ddlStaffId.DataBind();
            ddlStaffId.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objStaff.GetStaffType();
            ddlTeachingandNonTeaching.DataSource = ds;
            ddlTeachingandNonTeaching.DataTextField = "Type";
            ddlTeachingandNonTeaching.DataValueField = "StaffTypeID";
            ddlTeachingandNonTeaching.DataBind();
            ddlTeachingandNonTeaching.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetAppointmentMode();
            ddlModeOfAppointment.DataSource = ds;
            ddlModeOfAppointment.DataTextField = "Mode";
            ddlModeOfAppointment.DataValueField = "AppointmentID";
            ddlModeOfAppointment.DataBind();
            ddlModeOfAppointment.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.spGetPostType();
            ddlTypeOfPost.DataSource=ds;
            ddlTypeOfPost.DataTextField = "PostType";
            ddlTypeOfPost.DataValueField = "PostID";
            ddlTypeOfPost.DataBind();
            ddlTypeOfPost.Items.Insert(0, new ListItem("---Select---", "0"));
            ds=objComm.GetCader();
            ddlCader.DataSource = ds;
            ddlCader.DataTextField = "CaderType";
            ddlCader.DataValueField = "CaderID";
            ddlCader.DataBind();
            ddlCader.Items.Insert(0, new ListItem("---Select---", "0"));     
            
        }

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {

        string Staff = string.Empty, Gender = string.Empty, Teach = string.Empty, AppMode = string.Empty, PostType = string.Empty,Cader=string.Empty;
       

        Staff = ddlStaffId.Items[ddlStaffId.SelectedIndex].Value;
        Gender = ddlGender.Items[ddlGender.SelectedIndex].Value;
        Teach = ddlTeachingandNonTeaching.Items[ddlTeachingandNonTeaching.SelectedIndex].Value;
        AppMode = ddlModeOfAppointment.Items[ddlModeOfAppointment.SelectedIndex].Value;
        PostType = ddlTypeOfPost.Items[ddlTypeOfPost.SelectedIndex].Value;
        Cader = ddlCader.Items[ddlCader.SelectedIndex].Value;

        StaffTrainingReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        StaffTrainingReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
        StaffTrainingReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "StaffDetails";
        StaffTrainingReportViewer.ShowParameterPrompts = false;
        StaffTrainingReportViewer.ShowPrintButton = true;
        StaffTrainingReportViewer.ShowToolBar = true;
        StaffTrainingReportViewer.SizeToReportContent = true;
        Microsoft.Reporting.WebForms.ReportParameter[] StaffTrainingCourseParam = new Microsoft.Reporting.WebForms.ReportParameter[6];
        StaffTrainingCourseParam[0] = new Microsoft.Reporting.WebForms.ReportParameter("StaffId", Staff);
        StaffTrainingCourseParam[1] = new Microsoft.Reporting.WebForms.ReportParameter("Gender",Gender);
        StaffTrainingCourseParam[2] = new Microsoft.Reporting.WebForms.ReportParameter("TeachingandNonTeaching", Teach);
        StaffTrainingCourseParam[3] = new Microsoft.Reporting.WebForms.ReportParameter("ModeOfAppointment", AppMode);
        StaffTrainingCourseParam[4] = new Microsoft.Reporting.WebForms.ReportParameter("TypeOfPost", PostType);
        StaffTrainingCourseParam[5] = new Microsoft.Reporting.WebForms.ReportParameter("Cader", Cader);
        StaffTrainingReportViewer.ServerReport.SetParameters(StaffTrainingCourseParam);
        StaffTrainingReportViewer.ServerReport.Refresh();


    }
}
