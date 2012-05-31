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

using System.Data.SqlClient; 

public partial class student_ReportStudnetActivities : System.Web.UI.Page
{
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnReport.Attributes.Add("onclick", "javascript:return validation();");
        if (!IsPostBack)
        {
            ds = objComm.GetClub();
            ddlclub.DataSource = ds.Tables[0];
            ddlclub.DataTextField = "ClubName";
            ddlclub.DataValueField = "ClubID";

            ddlclub.DataBind();
            ddlclub.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
      string Date;
       string Activitytype=String.Empty;
       string prize,club;
        try
        {
            Date = ddlMonth.SelectedValue;
            Activitytype = (ddlactivtytype.SelectedValue);
            prize = ddlprize.SelectedItem.ToString();
            club = ddlclub.SelectedValue;  
            if (ddlactivtytype.SelectedValue == "1")
            {

              

                StudntActivityReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                StudntActivityReport.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
                StudntActivityReport.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "StudnetActivitiesindividualreport"; // Report Name
                StudntActivityReport.ShowParameterPrompts = false;
                StudntActivityReport.ShowPrintButton = true;
                StudntActivityReport.ShowToolBar = true;
                StudntActivityReport.SizeToReportContent = true;
               // StudntActivityReport.ShowPageNavigationControls = true;

                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[4];
                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Date", Date);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Activitytype", Activitytype);
                reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Prize", prize);
                reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("Club", club);


                StudntActivityReport.ServerReport.SetParameters(reportParameterCollection);

                StudntActivityReport.ServerReport.Refresh();
            }
            else if (ddlactivtytype.SelectedValue == "2")
            {
                StudntActivityReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                StudntActivityReport.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
                StudntActivityReport.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "StudnetGroupactivities"; // Report Name
                StudntActivityReport.ShowParameterPrompts = false;
                StudntActivityReport.ShowPrintButton = true;
                StudntActivityReport.ShowToolBar = true;
                StudntActivityReport.SizeToReportContent = true;
                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[4];
                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Date", Date);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Activitytype", Activitytype);
                reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Prize", prize);
                reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("Club", club);


                StudntActivityReport.ServerReport.SetParameters(reportParameterCollection);

                StudntActivityReport.ServerReport.Refresh();
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
}
