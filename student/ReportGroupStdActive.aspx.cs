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
using System.Data.Sql;
using BusinessLayer;
public partial class student_GroupStdActive : System.Web.UI.Page
{
    //BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnReport.Attributes.Add("onclick", "javascript:return validation();");
            ds = objComm.GetClub();
            ddlClub.DataSource = ds.Tables[0];
            ddlClub.DataTextField = "ClubName";
            ddlClub.DataValueField = "ClubID";

            ddlClub.DataBind();
            ddlClub.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string Date1 = String.Empty;
        string Date2 = String.Empty;
        string Activitytype = String.Empty;
        string prize,Club;
        
            Date1 = ChangeDateFormat(txtFromDate.Text);
            Date2 = ChangeDateFormat(txtToDate.Text);
            Activitytype = (ddlactivtytype.SelectedValue);
            prize = ddlprize.SelectedItem.ToString();
            Club = ddlClub.SelectedValue.ToString();  
            if (ddlactivtytype.SelectedValue == "1")
            {
                StudntActivityReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                StudntActivityReport.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
                StudntActivityReport.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "stdActive"; // Report Name
                StudntActivityReport.ShowParameterPrompts = false;
                StudntActivityReport.ShowPrintButton = true;
                
                StudntActivityReport.ShowToolBar = true;
                StudntActivityReport.SizeToReportContent = true;
                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[5];
                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Fromdate", Date1);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Todate", Date2);
                reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Activitytype", Activitytype);
                reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("Prize", prize);
                reportParameterCollection[4] = new Microsoft.Reporting.WebForms.ReportParameter("Club", Club);


                StudntActivityReport.ServerReport.SetParameters(reportParameterCollection);

                StudntActivityReport.ServerReport.Refresh();
            }
            else if (ddlactivtytype.SelectedValue == "2")
            {
                StudntActivityReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                StudntActivityReport.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
                StudntActivityReport.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "StudentActivitybwd"; // Report Name
                StudntActivityReport.ShowParameterPrompts = false;
                StudntActivityReport.ShowPrintButton = true;
                StudntActivityReport.ShowToolBar = true;
                StudntActivityReport.SizeToReportContent = true;
                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[5];
                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Fromdate", Date1);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Todate", Date2);
                reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Activitytype", Activitytype);
                reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("Prize", prize);
                reportParameterCollection[4] = new Microsoft.Reporting.WebForms.ReportParameter("Club", Club);


                StudntActivityReport.ServerReport.SetParameters(reportParameterCollection);

                StudntActivityReport.ServerReport.Refresh();
            }
        
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
}
