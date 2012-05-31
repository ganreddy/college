using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SSRSReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri("http://localhost/reportserver"); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = "/Report Project1/ReportSample"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;

        // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.
        
        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[5];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", "49");
        reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Class", "0");
        reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("section", "0");
        reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("Caste", "0");
        reportParameterCollection[4] = new Microsoft.Reporting.WebForms.ReportParameter("Gender", "0");
       
        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

        MyReportViewer.ServerReport.Refresh();
        
    }
   
}
