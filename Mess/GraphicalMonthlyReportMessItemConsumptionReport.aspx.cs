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

public partial class Mess_ReportMessItemConsumptionReport : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.StaffBL objStaff = new StaffBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnGetReport.Attributes.Add("onclick", "javascript:return validate();");
        rbtnTabularReport.Attributes.Add("onclick", "javascript:return Display();");
        rbtnGraphical.Attributes.Add("onclick", "javascript:return Display();");
        if (!IsPostBack)
        {
            ds = objComm.GetItem();
            ddlItemName.DataSource = ds.Tables[0];
            ddlItemName.DataTextField = "ItemName";
            ddlItemName.DataValueField = "ItemId";
            ddlItemName.DataBind();
            ddlItemName.Items.Insert(0, new ListItem("---select---", "0"));
            for (int i = 1990; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));

            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void btnGetReport_Click(object sender, EventArgs e)
    {
        string Item=String.Empty, Month = String.Empty, Year = String.Empty;
        Item = ddlItemName.Items[ddlItemName.SelectedIndex].Value;
        Month = ddlMonth.Items[ddlMonth.SelectedIndex].Value;
        Year = ddlYear.Items[ddlYear.SelectedIndex].Value;

        if (rbtnGraphical.Checked)
        {
            MonthlyMessItemCalculation.Visible = true;
            MonthlyMessItemCalculation.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            MonthlyMessItemCalculation.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
            MonthlyMessItemCalculation.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "GraphicallyMonthlyMessItemConsumptionReport";
            MonthlyMessItemCalculation.ShowParameterPrompts = false;
            MonthlyMessItemCalculation.ShowPrintButton = true;
            MonthlyMessItemCalculation.ShowToolBar = true;
            MonthlyMessItemCalculation.SizeToReportContent = true;
            // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.
            Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[3];
            reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Item", Item);
            reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Month", Month);
            reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Year", Year);
            MonthlyMessItemCalculation.ServerReport.SetParameters(reportParameterCollection);
            MonthlyMessItemCalculation.ServerReport.Refresh();
        }
        if (rbtnTabularReport.Checked)
        {
            MonthlyMessItemCalculation.Visible = true;
            MonthlyMessItemCalculation.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            MonthlyMessItemCalculation.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
            MonthlyMessItemCalculation.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "MessItemMonthlyItemConsumptionReport";
            MonthlyMessItemCalculation.ShowParameterPrompts = false;
            MonthlyMessItemCalculation.ShowPrintButton = true;
            MonthlyMessItemCalculation.ShowToolBar = true;
            MonthlyMessItemCalculation.SizeToReportContent = true;
            // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.
            Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[3];
            reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Item", Item);
            reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Month", Month);
            reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Year", Year);
            MonthlyMessItemCalculation.ServerReport.SetParameters(reportParameterCollection);
            MonthlyMessItemCalculation.ServerReport.Refresh();
        }
       
    }
}
