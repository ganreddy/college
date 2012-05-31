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

public partial class student_ReportAlumniInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 1980; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string AdmissionNo = string.Empty, Year = string.Empty;
        if (txtAdmissionNo.Text != "")
            AdmissionNo = txtAdmissionNo.Text;
        
        Year= ddlYear.Items[ddlYear.SelectedIndex].Value;
        
        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "StudentAlumni"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;
        MyReportViewer.SizeToReportContent = true;
        // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[2];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("AdmissionNo", AdmissionNo);
        reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("YearOfPassing", Year);
        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

        MyReportViewer.ServerReport.Refresh();
    }
}
