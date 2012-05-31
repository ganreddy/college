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
public partial class CCE_ReportCCECasteGenderUrbanRuralBySubjectWise : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.CCEBL objCCE = new CCEBL();
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnReport.Attributes.Add("onclick", "javascript:return validate();");
        if (!IsPostBack)
        {
            ds = objComm.GetBatch();
            ddlBatch.DataSource = ds.Tables[0];
            ddlBatch.DataTextField = "BatchNo";
            ddlBatch.DataValueField = "BatchID";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCCE.GetExam(0);
            ddlExamID.DataSource = ds.Tables[0];
            ddlExamID.DataTextField = "ExamName";
            ddlExamID.DataValueField = "ExamID";
            ddlExamID.DataBind();
            ddlExamID.Items.Insert(0, new ListItem("---Select---", "0"));
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
        string Batch = string.Empty,Exam=string.Empty,Subject=string.Empty;
        Batch = ddlBatch.Items[ddlBatch.SelectedIndex].Value;
        Exam = ddlExamID.Items[ddlExamID.SelectedIndex].Value;
        Subject = ddlSubject.Items[ddlSubject.SelectedIndex].Value;

        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "CCEReportStudentCountOnExamAppearedBySubjectWise"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;
        MyReportViewer.SizeToReportContent = true;
        // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.
        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[3];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
        reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("ExamName", Exam);
        reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Subject", Subject);
        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);
        MyReportViewer.ServerReport.Refresh();
    }
}
