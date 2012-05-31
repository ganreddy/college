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

public partial class Staff_ReportStaffLeave : System.Web.UI.Page
{
    BusinessLayer.StaffBL objStaff = new StaffBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnGetReport.Attributes.Add("onclick", "javascript:return validate(); ");
        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = objStaff.GetStaffDetails(0);
            ddlStaffName.DataSource = ds.Tables[0];
            ddlStaffName.DataTextField = "FullName";
            ddlStaffName.DataValueField = "StaffID";
            ddlStaffName.DataBind();
            ddlStaffName.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetLeaves(0);
            ddlLeaveType.DataSource = ds.Tables[0];
            ddlLeaveType.DataTextField = "LeaveType";
            ddlLeaveType.DataValueField = "LeaveTypeId";
            ddlLeaveType.DataBind();
            ddlLeaveType.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string FullName = string.Empty, LeaveName = string.Empty, FromDate = string.Empty, ToDate = string.Empty;
        FullName = ddlStaffName.Items[ddlStaffName.SelectedIndex].Value;
        LeaveName = ddlLeaveType.Items[ddlLeaveType.SelectedIndex].Value;
        if (txtFromDate.Text != "")
        FromDate = ChangeDateFormat(txtFromDate.Text);
        else
            FromDate = " ";
        if (txtToDate.Text != "")
        ToDate = ChangeDateFormat(txtToDate.Text);
        else
            ToDate = " ";


        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
        MyReportViewer.ServerReport.ReportPath =ConfigurationManager.AppSettings["ReportsFolder"].ToString()+ "StaffLeaves"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;
        MyReportViewer.SizeToReportContent = true;
        // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[4];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Staffid", FullName);
        reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Leaveid", LeaveName);
        reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("from", FromDate);
        reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("To", ToDate);

        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

        MyReportViewer.ServerReport.Refresh();
    }
   
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
}
