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
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnReport.Attributes.Add("onclick", "javascript:return validation();");
        rbtnTabularReport.Attributes.Add("onclick", "javascript:return Display();");
        rbtnGraphical.Attributes.Add("onclick", "javascript:return Display();");
        if (!IsPostBack)
        {
            //ds = objStudComm.GetPromotionBatch();
            ds = objComm.GetBatch();
            ddlBatch.DataSource = ds.Tables[0];
            ddlBatch.DataTextField = "BatchNo";
            ddlBatch.DataValueField = "BatchID";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
           // ds = objStudComm.GetPromotionClasses();
            ds = objComm.GetClasses();
            ddlClasses.DataSource = ds.Tables[0];
            ddlClasses.DataTextField = "ClassName";
            ddlClasses.DataValueField = "ClassID";
            ddlClasses.DataBind();
            ddlClasses.Items.Insert(0, new ListItem("---Select---", "0"));
           // ds = objStudComm.GetPromotionSection();
            ds = objComm.GetSection();
            ddlSections.DataSource = ds.Tables[0];
            ddlSections.DataTextField = "SectionName";
            ddlSections.DataValueField = "SectionID";
            ddlSections.DataBind();
            ddlSections.Items.Insert(0, new ListItem("---Select---", "0"));
            //ds = objStudComm.GetStudent(0);
            //ddlStudID.DataSource = ds.Tables[0];
            //ddlStudID.DataTextField = "FullName";
            //ddlStudID.DataValueField = "StudID";
            //ddlStudID.DataBind();
            //ddlStudID.Items.Insert(0, new ListItem("---Select---", "0"));
            //for (int i = 1990; i < 2050; i++)
            //{
            //    string j = i.ToString() + "-" + Convert.ToString(i + 1);
            //    ddlYear.Items.Add(new ListItem(j.ToString(), i.ToString()));
            //}
            //ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
            for (int i = 1990; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));

            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));

        }
    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));

    }
    protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));

    }
    protected void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));

    }
    public void fillStudent(int ClassID, int BatchID, int SectionID)
    {
        BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
        //ds = objStudComm.GetStudPromotionData(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
        ds = objStudComm.GetStudData(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            ddlStudID.DataSource = ds.Tables[0];
            ddlStudID.DataTextField = "FullName";
            ddlStudID.DataValueField = "StudID";
            ddlStudID.DataBind();
            ddlStudID.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void ddlStudID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = objStudComm.GetStud_PhysicalState(Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value), Convert.ToInt32(ddlStudID.Items[ddlStudID.SelectedIndex].Value));
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string Batch = string.Empty, Class = string.Empty, Section = string.Empty,Month=string.Empty, Stud = string.Empty,Year=string.Empty;
        Batch = ddlBatch.Items[ddlBatch.SelectedIndex].Value;
        Class = ddlClasses.Items[ddlClasses.SelectedIndex].Value;
        Section = ddlSections.Items[ddlSections.SelectedIndex].Value;
        Stud = ddlStudID.Items[ddlStudID.SelectedIndex].Value;
        Month = ddlMonth.Items[ddlMonth.SelectedIndex].Value;
        Year = ddlYear.Items[ddlYear.SelectedIndex].Value;

        if (rbtnGraphical.Checked)
        {
            if (ddlChartType.SelectedIndex == 1)
            {
                ReportStuYearlyAttendence.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportStuYearlyAttendence.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
                ReportStuYearlyAttendence.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "BarChartMonthlyStudentAttendance"; // Report Name
                ReportStuYearlyAttendence.ShowParameterPrompts = false;
                ReportStuYearlyAttendence.ShowPrintButton = true;
                ReportStuYearlyAttendence.ShowToolBar = true;
                ReportStuYearlyAttendence.SizeToReportContent = true;
                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[3];

                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("StudID", Stud);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Month", Month);
                reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("year", Year);
                ReportStuYearlyAttendence.ServerReport.SetParameters(reportParameterCollection);

                ReportStuYearlyAttendence.ServerReport.Refresh();
            }
            if (ddlChartType.SelectedIndex == 2)
            {
                ReportStuYearlyAttendence.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportStuYearlyAttendence.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
                ReportStuYearlyAttendence.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "LineChartMonthlyStudentAttendance"; // Report Name
                ReportStuYearlyAttendence.ShowParameterPrompts = false;
                ReportStuYearlyAttendence.ShowPrintButton = true;
                ReportStuYearlyAttendence.ShowToolBar = true;
                ReportStuYearlyAttendence.SizeToReportContent = true;
                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[3];

                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("StudID", Stud);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Month", Month);
                reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("year", Year);
                ReportStuYearlyAttendence.ServerReport.SetParameters(reportParameterCollection);

                ReportStuYearlyAttendence.ServerReport.Refresh();
            }
        }
        if (rbtnTabularReport.Checked)
        {
            ReportStuYearlyAttendence.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportStuYearlyAttendence.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
            ReportStuYearlyAttendence.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "MonthlyStudentAttendance"; // Report Name
            ReportStuYearlyAttendence.ShowParameterPrompts = false;
            ReportStuYearlyAttendence.ShowPrintButton = true;
            ReportStuYearlyAttendence.ShowToolBar = true;
            ReportStuYearlyAttendence.SizeToReportContent = true;
            // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

            Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[3];

            reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("StudID", Stud);
            reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Month", Month);
            reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("year", Year);
            ReportStuYearlyAttendence.ServerReport.SetParameters(reportParameterCollection);

            ReportStuYearlyAttendence.ServerReport.Refresh();
        }
    }
}
