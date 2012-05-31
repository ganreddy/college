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
public partial class Stores_ReportNewProcurement : System.Web.UI.Page
{
    BusinessLayer.StoresBL objStores = new StoresBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnGetReport.Attributes.Add("onclick", "javascript:return validate();");
        if (!IsPostBack)
        {
            ddlItem.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlPurposeNewProcirement.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void ddlCategoryNewProcirement_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = new DataSet();
        ds = objStores.GetItemsbyType(1, Convert.ToInt32(ddlPeriodicityNewProcirement.Items[ddlPeriodicityNewProcirement.SelectedIndex].Value), Convert.ToInt32(ddlCategoryNewProcirement.Items[ddlCategoryNewProcirement.SelectedIndex].Value));
        ddlItem.DataSource = ds.Tables[0];
        ddlItem.DataTextField = "ItemName";
        ddlItem.DataValueField = "ItemID";
        ddlItem.DataBind();
        ddlItem.Items.Insert(0, new ListItem("---Select---", "0"));
        if (ddlCategoryNewProcirement.SelectedIndex == 1)
        {
            trPurpose.Visible = false;
        }
        if (ddlCategoryNewProcirement.SelectedIndex == 2)
        {
            trPurpose.Visible = true;
            if (ddlPurposeNewProcirement.Items.Count > 0)
                ddlPurposeNewProcirement.Items.Clear();
            ddlPurposeNewProcirement.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlPurposeNewProcirement.Items.Insert(1, new ListItem("Clothing", "1"));
            ddlPurposeNewProcirement.Items.Insert(2, new ListItem("Other Items", "2"));
        }
        if (ddlCategoryNewProcirement.SelectedIndex == 3)
        {
            trPurpose.Visible = true;
            if (ddlPurposeNewProcirement.Items.Count > 0)
                ddlPurposeNewProcirement.Items.Clear();
            ddlPurposeNewProcirement.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlPurposeNewProcirement.Items.Insert(1, new ListItem("Examination", "1"));
            ddlPurposeNewProcirement.Items.Insert(2, new ListItem("Office", "2"));
        }
        ddlPurposeNewProcirement.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    protected void ddlPeriodicityNewProcirement_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = new DataSet();
        ds = objStores.GetItemsbyType(1, Convert.ToInt32(ddlPeriodicityNewProcirement.Items[ddlPeriodicityNewProcirement.SelectedIndex].Value), Convert.ToInt32(ddlCategoryNewProcirement.Items[ddlCategoryNewProcirement.SelectedIndex].Value));
        ddlItem.DataSource = ds.Tables[0];
        ddlItem.DataTextField = "ItemName";
        ddlItem.DataValueField = "ItemID";
        ddlItem.DataBind();
        ddlItem.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    protected void btnGetReport_Click(object sender, EventArgs e)
    {
        string Periodicity = string.Empty;
        string Category = string.Empty;
        string Purpose = string.Empty;
        string Item = string.Empty;
        string SupplyFromDate = string.Empty;
        string SupplyToDate = string.Empty;
        string DeliveryFromDate = string.Empty;
        string DeliveryToDate = string.Empty;

        Periodicity = ddlPeriodicityNewProcirement.Items[ddlPeriodicityNewProcirement.SelectedIndex].Value;
        Category = ddlCategoryNewProcirement.Items[ddlCategoryNewProcirement.SelectedIndex].Value;
        Purpose = ddlPurposeNewProcirement.Items[ddlPurposeNewProcirement.SelectedIndex].Value;
        Item = ddlItem.Items[ddlItem.SelectedIndex].Value;
        SupplyFromDate = txtSupplyFromDate.Text;
        SupplyToDate = txtSupplyToDate.Text;
        DeliveryFromDate = txtDeliveryFromDate.Text;
        DeliveryToDate = txtDeliveryToDate.Text;

        NewProcurementReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        NewProcurementReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
        NewProcurementReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString()+"StoresProcurement";
        NewProcurementReportViewer.ShowParameterPrompts = false;
        NewProcurementReportViewer.ShowPrintButton = true;
        NewProcurementReportViewer.ShowToolBar = true;
        NewProcurementReportViewer.SizeToReportContent = true;
        Microsoft.Reporting.WebForms.ReportParameter[] NewProcurementParam = new Microsoft.Reporting.WebForms.ReportParameter[8];
        NewProcurementParam[0] = new Microsoft.Reporting.WebForms.ReportParameter("Periodicity", Periodicity);
        NewProcurementParam[1] = new Microsoft.Reporting.WebForms.ReportParameter("Category", Category);
        NewProcurementParam[2] = new Microsoft.Reporting.WebForms.ReportParameter("Purpose", Purpose);
        NewProcurementParam[3] = new Microsoft.Reporting.WebForms.ReportParameter("Item", Item);
        NewProcurementParam[4] = new Microsoft.Reporting.WebForms.ReportParameter("SpplyFromdate", SupplyFromDate);
        NewProcurementParam[5] = new Microsoft.Reporting.WebForms.ReportParameter("SpplyToDate", SupplyToDate);
        NewProcurementParam[6] = new Microsoft.Reporting.WebForms.ReportParameter("OrderFromdate", DeliveryFromDate);
        NewProcurementParam[7] = new Microsoft.Reporting.WebForms.ReportParameter("OrderToDate", DeliveryToDate);
        NewProcurementReportViewer.ServerReport.SetParameters(NewProcurementParam);
        NewProcurementReportViewer.ServerReport.Refresh();
    }
}
