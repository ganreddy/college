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

public partial class student_GraphicalStudentYearlyAttendenceReport : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnReport.Attributes.Add("onclick", "javascript:return validation();");
        rbtnTabularReport.Attributes.Add("onclick", "javascript:return Display();");
        rbtnGraphical.Attributes.Add("onclick", "javascript:return Display();");
        if (!IsPostBack)
        {
            ds = objStudComm.GetPromotionClasses();
            ddlClasses.DataSource = ds.Tables[0];
            ddlClasses.DataTextField = "ClassName";
            ddlClasses.DataValueField = "Class";
            ddlClasses.DataBind();
            ddlClasses.Items.Insert(0, new ListItem("---Select---", "0"));
            
            for (int i = 1990; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));

            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));

        }
    }
    
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string  Class = string.Empty, Year=string.Empty;
        //Batch = ddlBatch.Items[ddlBatch.SelectedIndex].Value;
        Class = ddlClasses.Items[ddlClasses.SelectedIndex].Value;
        //Section = ddlSections.Items[ddlSections.SelectedIndex].Value;
        //Stud = ddlStudID.Items[ddlStudID.SelectedIndex].Value;
        Year = ddlYear.Items[ddlYear.SelectedIndex].Value;
        if (rbtnGraphical.Checked)
        {
            if (ddlChartType.SelectedIndex == 1)
            {
                ReportStuYearlyAttendence.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportStuYearlyAttendence.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
                ReportStuYearlyAttendence.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "BarChartYearlyClassWiseStudentAttendance"; // Report Name
                ReportStuYearlyAttendence.ShowParameterPrompts = false;
                ReportStuYearlyAttendence.ShowPrintButton = true;
                ReportStuYearlyAttendence.ShowToolBar = true;
                ReportStuYearlyAttendence.SizeToReportContent = true;
                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[2];

                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Year", Year);
                ReportStuYearlyAttendence.ServerReport.SetParameters(reportParameterCollection);

                ReportStuYearlyAttendence.ServerReport.Refresh();
            }
            if (ddlChartType.SelectedIndex == 2)
            {
                ReportStuYearlyAttendence.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportStuYearlyAttendence.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
                ReportStuYearlyAttendence.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "LineChartClassWiseYearlyStudentAttendance"; // Report Name
                ReportStuYearlyAttendence.ShowParameterPrompts = false;
                ReportStuYearlyAttendence.ShowPrintButton = true;
                ReportStuYearlyAttendence.ShowToolBar = true;
                ReportStuYearlyAttendence.SizeToReportContent = true;
                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[2];

                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Year", Year);
                ReportStuYearlyAttendence.ServerReport.SetParameters(reportParameterCollection);

                ReportStuYearlyAttendence.ServerReport.Refresh();
            }
        }
        if (rbtnTabularReport.Checked)
        {
            ReportStuYearlyAttendence.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportStuYearlyAttendence.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
            ReportStuYearlyAttendence.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "ClassWiseYearlyStudentAttendance"; // Report Name
            ReportStuYearlyAttendence.ShowParameterPrompts = false;
            ReportStuYearlyAttendence.ShowPrintButton = true;
            ReportStuYearlyAttendence.ShowToolBar = true;
            ReportStuYearlyAttendence.SizeToReportContent = true;
            // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

            Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[2];

            reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
            reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Year", Year);
            ReportStuYearlyAttendence.ServerReport.SetParameters(reportParameterCollection);

            ReportStuYearlyAttendence.ServerReport.Refresh();
        }
    }
}
