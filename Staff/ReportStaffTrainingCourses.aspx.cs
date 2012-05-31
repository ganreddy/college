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
public partial class Staff_ReportStaffTrainingCourses : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.StaffBL objStaff = new StaffBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnGetReport.Attributes.Add("onclick", "javascript:return validate();");
        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = objStaff.GetStaffDetails(0);
            ddlStaff.DataSource = ds.Tables[0];
            ddlStaff.DataTextField = "FullName";
            ddlStaff.DataValueField = "StaffID";
            ddlStaff.DataBind();
            ddlStaff.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void btnGetReport_Click(object sender, EventArgs e)
    {
        string Staff = string.Empty;
        string FromDate = string.Empty;
        string ToDate = string.Empty;
        string strCourseName = string.Empty;

        Staff = ddlStaff.Items[ddlStaff.SelectedIndex].Value;
        if(txtFromDate.Text!="")
        FromDate =ChangeDateFormat(txtFromDate.Text);
        if(txtToDate.Text!="")
        ToDate =ChangeDateFormat(txtToDate.Text);
        strCourseName = txtCourseName.Text;

        StaffTrainingReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        StaffTrainingReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
        StaffTrainingReportViewer.ServerReport.ReportPath =ConfigurationManager.AppSettings["ReportsFolder"].ToString()+ "StaffTrainingCourses";
        StaffTrainingReportViewer.ShowParameterPrompts = false;
        StaffTrainingReportViewer.ShowPrintButton = true;
        StaffTrainingReportViewer.ShowToolBar = true;
        StaffTrainingReportViewer.SizeToReportContent = true;
        Microsoft.Reporting.WebForms.ReportParameter[] StaffTrainingCourseParam = new Microsoft.Reporting.WebForms.ReportParameter[4];
        StaffTrainingCourseParam[0] = new Microsoft.Reporting.WebForms.ReportParameter("Staff", Staff);
        StaffTrainingCourseParam[1] = new Microsoft.Reporting.WebForms.ReportParameter("CourseName",strCourseName);
        StaffTrainingCourseParam[2] = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", FromDate);
        StaffTrainingCourseParam[3] = new Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate);
        StaffTrainingReportViewer.ServerReport.SetParameters(StaffTrainingCourseParam);
        StaffTrainingReportViewer.ServerReport.Refresh();
        
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
}
