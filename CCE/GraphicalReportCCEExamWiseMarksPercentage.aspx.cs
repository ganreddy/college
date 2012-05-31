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
public partial class CCE_ReportCCEExamWiseMarksPercentage : System.Web.UI.Page
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
            ds = objComm.GetClasses();
            ddlClasses.DataSource = ds.Tables[0];
            ddlClasses.DataTextField = "ClassName";
            ddlClasses.DataValueField = "ClassID";
            ddlClasses.DataBind();
            ddlClasses.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetSection();
            ddlSections.DataSource = ds.Tables[0];
            ddlSections.DataTextField = "SectionName";
            ddlSections.DataValueField = "SectionID";
            ddlSections.DataBind();
            ddlSections.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCCE.GetExam(0);
            ddlExamID.DataSource = ds.Tables[0];
            ddlExamID.DataTextField = "ExamName";
            ddlExamID.DataValueField = "ExamID";
            ddlExamID.DataBind();
            ddlExamID.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string Batch = string.Empty, Class = string.Empty, Section = string.Empty, Caste = string.Empty, Stud = string.Empty, Exam = string.Empty;
        Batch = ddlBatch.Items[ddlBatch.SelectedIndex].Value;
        Class = ddlClasses.Items[ddlClasses.SelectedIndex].Value;
        Section = ddlSections.Items[ddlSections.SelectedIndex].Value;
        Stud = ddlStudID.Items[ddlStudID.SelectedIndex].Value;
        Exam = ddlExamID.Items[ddlExamID.SelectedIndex].Value;

        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "GraphicalCCEBarchartReportExamwisePercentage"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;
        MyReportViewer.SizeToReportContent = true;

        // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[5];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
        reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
        reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Section", Section);
        reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("ExamID", Exam);
        reportParameterCollection[4] = new Microsoft.Reporting.WebForms.ReportParameter("StudID", Stud);
        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

        MyReportViewer.ServerReport.Refresh();
    }
    public void fillStudent(int ClassID, int BatchID, int SectionID)
    {
        BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
        ds = new DataSet();
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
}
