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
public partial class Mess_ReportMessPurchase : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ds = objComm.GetStoreItem();
            ddlItemName.DataSource = ds.Tables[0];
            ddlItemName.DataTextField = "ItemName";
            ddlItemName.DataValueField = "ItemId";
            ddlItemName.DataBind();
            ddlItemName.Items.Insert(0, new ListItem("---Select---", "0"));

            for (int i = 1990; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void btnGetReport_Click(object sender, EventArgs e)
    {
        try
        {

       
        string Month = string.Empty;    
        string Year = string.Empty;        
        string ItemName = string.Empty;

        Month = ddlMonth.Items[ddlMonth.SelectedIndex].Value;
        Year = ddlYear.Items[ddlYear.SelectedIndex].Value;
        ItemName= ddlItemName.Items[ddlItemName.SelectedIndex].Value;


        MessPurchaseReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MessPurchaseReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
        MessPurchaseReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "StorePurchases";
        MessPurchaseReportViewer.ShowParameterPrompts = false;
        MessPurchaseReportViewer.ShowPrintButton = true;
        MessPurchaseReportViewer.ShowToolBar = true;
        MessPurchaseReportViewer.SizeToReportContent = true;
        Microsoft.Reporting.WebForms.ReportParameter[] MessPurchaseParam = new Microsoft.Reporting.WebForms.ReportParameter[3];
        MessPurchaseParam[0] = new Microsoft.Reporting.WebForms.ReportParameter("Month", Month);
        MessPurchaseParam[1] = new Microsoft.Reporting.WebForms.ReportParameter("Year", Year);
        MessPurchaseParam[2] = new Microsoft.Reporting.WebForms.ReportParameter("ItemName", ItemName);
        MessPurchaseReportViewer.ServerReport.SetParameters(MessPurchaseParam);
        MessPurchaseReportViewer.ServerReport.Refresh();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
