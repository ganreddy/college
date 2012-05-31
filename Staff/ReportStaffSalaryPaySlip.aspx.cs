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
public partial class Staff_ReportStaffSalaryPaySlip : System.Web.UI.Page
{
    BusinessLayer.StaffBL objStaff = new StaffBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnReport.Attributes.Add("onclick", "javascript:return validate();");
        ds = new DataSet();
        if (!IsPostBack)
        {
            ds = objStaff.GetStaffDetails(0);
            ddlStaff.DataSource = ds.Tables[0];
            ddlStaff.DataTextField = "FullName";
            ddlStaff.DataValueField = "StaffID";
            ddlStaff.DataBind();
            ddlStaff.Items.Insert(0, new ListItem("---Select---", "0"));
            for (int i = 1990; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));

        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string FullName = string.Empty, Month = string.Empty, Year = string.Empty;
        FullName = ddlStaff.Items[ddlStaff.SelectedIndex].Value;
        Month = ddlMonth.Items[ddlMonth.SelectedIndex].Value;
        Year = ddlYear.Items[ddlYear.SelectedIndex].Value;



        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "StaffPayslipReport"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;

        // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[3];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("StaffID", FullName);
        reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Month", Month);
        reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Years", Year);

        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

        MyReportViewer.ServerReport.Refresh();
    }
}
