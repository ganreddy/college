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
using BusinessLayer;

public partial class student_StudentSeltionReport : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnReport.Attributes.Add("onclick", "javascript:return validate();");
        ds = new DataSet();
        if (!IsPostBack)
        {
            for (int j = 2000; j < 2050; j++)
            {
                ddlYear.Items.Add(new ListItem(j.ToString(), j.ToString()));

            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
        }

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
       string Year = string.Empty, Eligible = string.Empty;
        Year = ddlYear.Items[ddlYear.SelectedIndex].Value;
        Eligible = ddlEligible.Items[ddlEligible.SelectedIndex].Value;

        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "StdSelectionReport"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;
        MyReportViewer.SizeToReportContent = true;
        // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[2];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Year",Year);
        reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Eligible", Eligible);
        

        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

        MyReportViewer.ServerReport.Refresh();
    }
}
