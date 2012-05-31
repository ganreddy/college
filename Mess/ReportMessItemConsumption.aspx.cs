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

public partial class Mess_MessItemConsumption : System.Web.UI.Page
{
    BusinessLayer.StoresBL objCon = new StoresBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnReport.Attributes.Add("onclick", "javascript:return validate();");
        ds = new DataSet();
        if (!IsPostBack)
        {
            ds = objCon.GetItemsbyType(2,0,0);
            ddlMessItem.DataSource = ds.Tables[0];
            ddlMessItem.DataSource = ds.Tables[0];
            ddlMessItem.DataTextField = "ItemName";
            ddlMessItem.DataValueField = "ItemId";
            ddlMessItem.DataBind();
            ddlMessItem.Items.Insert(0, new ListItem("---Select---", "0"));

        }

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string Item = string.Empty, Fromdate = string.Empty,Todate=string.Empty;
        Item = ddlMessItem.Items[ddlMessItem.SelectedIndex].Value;
        if (txtFromDate.Text != "")
            Fromdate = ChangeDateFormat(txtFromDate.Text);
        if (txtToDate.Text != "")
            Todate = ChangeDateFormat(txtToDate.Text);
        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "MessItemConsumption"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;
        MyReportViewer.SizeToReportContent = true;
        
        // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[3];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("ItemName", Item);
        reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Fromdate", Fromdate);
        reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("ToDate", Todate);
       
        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

        MyReportViewer.ServerReport.Refresh();
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
}
