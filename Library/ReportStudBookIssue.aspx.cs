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
public partial class Library_ReportStudentBookIssue : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnReport.Attributes.Add("onclick", "javascript:return validate();");
        ds = new DataSet();
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
            ddlStudent.Items.Insert(0, new ListItem("---Select---", "0"));
        }

    }
    public void fillStudent(int ClassID, int BatchID, int SectionID)
    {
        BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
        ds = new DataSet();
        ds = objStudComm.GetStudData(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            ddlStudent.DataSource = ds.Tables[0];
            ddlStudent.DataTextField = "FullName";
            ddlStudent.DataValueField = "StudID";
            ddlStudent.DataBind();
            ddlStudent.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string Batch = string.Empty, Class = string.Empty, Section = string.Empty, Student = string.Empty, From = string.Empty, To = string.Empty,DueFromDate=string.Empty, DueToDate = string.Empty;
        Batch = ddlBatch.Items[ddlBatch.SelectedIndex].Value;
        Class = ddlClasses.Items[ddlClasses.SelectedIndex].Value;
        Section = ddlSections.Items[ddlSections.SelectedIndex].Value;
        Student = ddlStudent.Items[ddlStudent.SelectedIndex].Value;
        if (txtFromDate.Text != "")
            From = ChangeDateFormat(txtFromDate.Text);
        else
            From = " ";
        if (txtToDate.Text != "")
            To = ChangeDateFormat(txtToDate.Text);
        else
            To = " ";
        if (txtDueFromDate.Text != "")
            DueFromDate = ChangeDateFormat(txtDueFromDate.Text);
        else
            DueFromDate = "";
        if (txtDueToDate.Text != "")
            DueToDate = ChangeDateFormat(txtDueToDate.Text);
        else
            DueToDate = "";
        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString()+"StudentBookIssu"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;
        MyReportViewer.SizeToReportContent = true;
         //Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[8];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
        reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
        reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Section", Section);
        reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("Student", Student);
        reportParameterCollection[4] = new Microsoft.Reporting.WebForms.ReportParameter("IssueFromDate", From);
        reportParameterCollection[5] = new Microsoft.Reporting.WebForms.ReportParameter("IssueToDate", To);
        reportParameterCollection[6] = new Microsoft.Reporting.WebForms.ReportParameter("DueFromDate", DueFromDate);
        reportParameterCollection[7] = new Microsoft.Reporting.WebForms.ReportParameter("DueToDate", DueToDate);

        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

        MyReportViewer.ServerReport.Refresh();
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
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
}
