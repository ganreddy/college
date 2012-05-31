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

public partial class Staff_ReportCCEStaffperformance : System.Web.UI.Page
{
    BusinessLayer.StaffBL objStaff = new StaffBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.CCEBL objCCE = new CCEBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnReport.Attributes.Add("onclick", "javascript:return validate();");
        rbtnTabularReport.Attributes.Add("onclick", "javascript:return Display();");
        rbtnGraphical.Attributes.Add("onclick", "javascript:return Display();");
        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = objStaff.GetStaffDetails(0);
            ddlStaff.DataSource = ds.Tables[0];
            ddlStaff.DataTextField = "FullName";
            ddlStaff.DataValueField = "StaffID";
            ddlStaff.DataBind();
            ddlStaff.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetClasses();
            ddlClasses.DataSource = ds.Tables[0];
            ddlClasses.DataTextField = "ClassName";
            ddlClasses.DataValueField = "ClassID";
            ddlClasses.DataBind();
            ddlClasses.Items.Insert(0, new ListItem("---Select---", "0"));
            //ds = objComm.GetSection();
            //ddlSections.DataSource = ds.Tables[0];
            //ddlSections.DataTextField = "SectionName";
            //ddlSections.DataValueField = "SectionID";
            //ddlSections.DataBind();
            //ddlSections.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCCE.GetExam(0);
            ddlExam.DataSource = ds.Tables[0];
            ddlExam.DataTextField = "ExamName";
            ddlExam.DataValueField = "ExamID";
            ddlExam.DataBind();
            ddlExam.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetBatch();
            ddlBatch.DataSource = ds.Tables[0];
            ddlBatch.DataTextField = "BatchNo";
            ddlBatch.DataValueField = "BatchID";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetSubject();
            ddlSubject.DataSource = ds.Tables[0];
            ddlSubject.DataTextField = "SubjectName";
            ddlSubject.DataValueField = "SubjectID";
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(0, new ListItem("---Select---", "0"));

        }


    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string Batch = string.Empty, Class = string.Empty, Section = string.Empty, Caste = string.Empty, Staff = string.Empty, Exam = string.Empty, Subject = string.Empty;
        Batch = ddlBatch.Items[ddlBatch.SelectedIndex].Value;
        Class = ddlClasses.Items[ddlClasses.SelectedIndex].Value;
        // Section = ddlSections.Items[ddlSections.SelectedIndex].Value;
        Staff = ddlStaff.Items[ddlStaff.SelectedIndex].Value;
        Exam = ddlExam.Items[ddlExam.SelectedIndex].Value;
        Subject = ddlSubject.Items[ddlSubject.SelectedIndex].Value;
        if (rbtnGraphical.Checked)
        {
            if (ddlChartType.SelectedIndex == 1)
            {
                MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
                MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "CCEBarChartStaffPerformance"; // Report Name
                MyReportViewer.ShowParameterPrompts = false;
                MyReportViewer.ShowPrintButton = true;
                MyReportViewer.ShowToolBar = true;
                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.
                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[5];
                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("StaffID", Staff);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
                reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
                reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("Exam", Exam);
                reportParameterCollection[4] = new Microsoft.Reporting.WebForms.ReportParameter("Subject", Subject);


                MyReportViewer.ServerReport.SetParameters(reportParameterCollection);
                MyReportViewer.ServerReport.Refresh();
            }
            if (ddlChartType.SelectedIndex == 2)
            {
                MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
                MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "CCELineChartStaffPerformance"; // Report Name
                MyReportViewer.ShowParameterPrompts = false;
                MyReportViewer.ShowPrintButton = true;
                MyReportViewer.ShowToolBar = true;
                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.
                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[5];
                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("StaffID", Staff);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
                reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
                reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("Exam", Exam);
                reportParameterCollection[4] = new Microsoft.Reporting.WebForms.ReportParameter("Subject", Subject);
                MyReportViewer.ServerReport.SetParameters(reportParameterCollection);
                MyReportViewer.ServerReport.Refresh();
            }
        }
        if (rbtnTabularReport.Checked)
        {
            MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
            MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "CCEReportStaffPerformance"; // Report Name
            MyReportViewer.ShowParameterPrompts = false;
            MyReportViewer.ShowPrintButton = true;
            MyReportViewer.ShowToolBar = true;
            // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.
            Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[6];
            reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("StaffID", Staff);
            reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
            reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
            reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("Exam", Exam);
            reportParameterCollection[4] = new Microsoft.Reporting.WebForms.ReportParameter("Subject", Subject);
            MyReportViewer.ServerReport.SetParameters(reportParameterCollection);
            MyReportViewer.ServerReport.Refresh();
        }
    }
}
