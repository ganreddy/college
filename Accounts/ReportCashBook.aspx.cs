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

public partial class Accounts_ReportCashBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnGetReport.Attributes.Add("onclick", "javascript:return validate();");
        if (!IsPostBack)
        { 
        
        }
    }
    protected void btnGetReport_Click(object sender, EventArgs e)
    {
        string Transaction = string.Empty;
        string FromDate = string.Empty;
        string ToDate = string.Empty;
        string Planned = string.Empty;

        Transaction = ddlTransaction.Items[ddlTransaction.SelectedIndex].Value;
        if (txtFromDate.Text != "")
            FromDate =ChangeDateFormat(txtFromDate.Text);
        if (txtToDate.Text != "")
            ToDate = ChangeDateFormat(txtToDate.Text);
        Planned = ddlPlanNon.Items[ddlPlanNon.SelectedIndex].Value;

        cashBookReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        cashBookReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
        cashBookReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "AccountCashBookReport";
        cashBookReportViewer.ShowParameterPrompts = false;
        cashBookReportViewer.ShowPrintButton = true;
        cashBookReportViewer.ShowToolBar = true;
        cashBookReportViewer.SizeToReportContent = true;
        Microsoft.Reporting.WebForms.ReportParameter[] cashBookParam = new Microsoft.Reporting.WebForms.ReportParameter[4];
        cashBookParam[0] = new Microsoft.Reporting.WebForms.ReportParameter("TransactionType", Transaction);
        cashBookParam[1] = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", FromDate);
        cashBookParam[2] = new Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate);
        cashBookParam[3] = new Microsoft.Reporting.WebForms.ReportParameter("PlanNonPlan", Planned);
        cashBookReportViewer.ServerReport.SetParameters(cashBookParam);
        cashBookReportViewer.ServerReport.Refresh();
        
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    
}
