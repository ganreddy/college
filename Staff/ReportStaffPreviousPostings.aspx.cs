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

public partial class Staff_ReportStaffPreviousPostings : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.StaffBL objStaff = new StaffBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnGetReport.Attributes.Add("onclick", "javascript:return validate();");
        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = objStaff.GetStaffDetails(0);
            ddlStaff.DataSource = ds.Tables[0];
            ddlStaff.DataTextField = "FullName";
            ddlStaff.DataValueField = "StaffID";
            ddlStaff.DataBind();
            ddlStaff.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void btnGetReport_Click(object sender, EventArgs e)
    {

        string Staff = string.Empty;
        string FromDate = string.Empty;
        string ToDate = string.Empty;
        string strWorkPlace = string.Empty;

        Staff = ddlStaff.Items[ddlStaff.SelectedIndex].Value;
        if (txtFromDate.Text != "")
            FromDate =ChangeDateFormat(txtFromDate.Text);
        if (txtToDate.Text != "")
            ToDate = ChangeDateFormat(txtToDate.Text);
        strWorkPlace = txtWorkPlace.Text;

        StaffPrevPostingsReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        StaffPrevPostingsReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
        StaffPrevPostingsReportViewer.ServerReport.ReportPath =ConfigurationManager.AppSettings["ReportsFolder"].ToString()+ "StaffPreviousPostings";
        StaffPrevPostingsReportViewer.ShowParameterPrompts = false;
        StaffPrevPostingsReportViewer.ShowPrintButton = true;
        StaffPrevPostingsReportViewer.ShowToolBar = true;
        StaffPrevPostingsReportViewer.SizeToReportContent = true;
        Microsoft.Reporting.WebForms.ReportParameter[] StaffPrevPostingsParam = new Microsoft.Reporting.WebForms.ReportParameter[4];
        StaffPrevPostingsParam[0] = new Microsoft.Reporting.WebForms.ReportParameter("Staff", Staff);
        StaffPrevPostingsParam[1] = new Microsoft.Reporting.WebForms.ReportParameter("WorkPlace", strWorkPlace);
        StaffPrevPostingsParam[2] = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", FromDate);
        StaffPrevPostingsParam[3] = new Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate);
        StaffPrevPostingsReportViewer.ServerReport.SetParameters(StaffPrevPostingsParam);
        StaffPrevPostingsReportViewer.ServerReport.Refresh();
        
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
}
