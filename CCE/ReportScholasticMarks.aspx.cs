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

public partial class CCE_ReportScholasticMarks : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.CCEBL objCCE = new CCEBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStud = new StudentAdmissionBL();
//    DataSet dsExam;
    string strValues = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");

        if (!IsPostBack)
        {
            ds = objCCE.GetExam(0);
            ddlExamType.DataSource = ds.Tables[0];
            ddlExamType.DataTextField = "ExamName";
            ddlExamType.DataValueField = "ExamID";
            ddlExamType.DataBind();
            ddlExamType.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = new DataSet();
            ds = objComm.GetClasses();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlClass.DataSource = ds.Tables[0];
                    ddlClass.DataTextField = "ClassName";
                    ddlClass.DataValueField = "ClassID";
                    ddlClass.DataBind();
                    ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
            ds = objComm.GetBatch();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlBatch.DataSource = ds.Tables[0];
                    ddlBatch.DataTextField = "BatchNo";
                    ddlBatch.DataValueField = "BatchID";
                    ddlBatch.DataBind();
                    ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
            ds = objComm.GetSubject();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlSubject.DataSource = ds.Tables[0];
                    ddlSubject.DataTextField = "SubjectName";
                    ddlSubject.DataValueField = "SubjectID";
                    ddlSubject.DataBind();
                    ddlSubject.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
            ds = objComm.GetSection();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlSection.DataSource = ds.Tables[0];
                    ddlSection.DataTextField = "SectionName";
                    ddlSection.DataValueField = "SectionID";
                    ddlSection.DataBind();
                    ddlSection.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }

        }
        
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string Batch = string.Empty, Class = string.Empty, Section = string.Empty, Subject = string.Empty, ExamType = string.Empty;
        Batch = ddlBatch.Items[ddlBatch.SelectedIndex].Value;
        Class = ddlClass.Items[ddlClass.SelectedIndex].Value;
        Section = ddlSection.Items[ddlSection.SelectedIndex].Value;
        Subject = ddlSubject.Items[ddlSubject.SelectedIndex].Value;
        ExamType = ddlExamType.Items[ddlExamType.SelectedIndex].Value;

        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "CCEStudentScholasticMarks"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;
        MyReportViewer.SizeToReportContent = true;
        // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[5];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
        reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
        reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Section", Section);
        reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("Subject", Subject);
        reportParameterCollection[4] = new Microsoft.Reporting.WebForms.ReportParameter("ExamType", ExamType);
        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

        MyReportViewer.ServerReport.Refresh();
    }
}
