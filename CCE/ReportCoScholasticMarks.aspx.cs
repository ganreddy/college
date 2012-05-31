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

public partial class CCE_ReportCoScholasticMarks : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.CCEBL objCCE = new CCEBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
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
            ds = objCCE.GetCoScholasticArea(0);
            ddlCoScholastisarea.DataSource = ds.Tables[0];
            ddlCoScholastisarea.DataTextField = "CoScholasticArea";
            ddlCoScholastisarea.DataValueField = "CoScholasticID";
            ddlCoScholastisarea.DataBind();
            ddlCoScholastisarea.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlAssesmentName.Items.Insert(0, new ListItem("---Select---", "0"));
        }

    }
    public void bindAssesmentArea(int CoScholasticID)
    {
        ds = new DataSet();
        ds = objCCE.GetAssesmentArea(CoScholasticID);
        ddlAssesmentName.DataSource = ds.Tables[0];
        ddlAssesmentName.DataTextField = "AssesmentArea";
        ddlAssesmentName.DataValueField = "AssesmentID";
        ddlAssesmentName.DataBind();
        ddlAssesmentName.Items.Insert(0, new ListItem("---Select---", "0"));


    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string Batch = string.Empty, Class = string.Empty, Section = string.Empty, CoScholasticArea = string.Empty, AssesmentName = string.Empty; 
        Batch = ddlBatch.Items[ddlBatch.SelectedIndex].Value;
        Class = ddlClasses.Items[ddlClasses.SelectedIndex].Value;
        Section = ddlSections.Items[ddlSections.SelectedIndex].Value;
        CoScholasticArea = ddlCoScholastisarea.Items[ddlCoScholastisarea.SelectedIndex].Value;
        AssesmentName = ddlAssesmentName.Items[ddlAssesmentName.SelectedIndex].Value;

        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "CCECoScholasticMarks"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;
        MyReportViewer.SizeToReportContent = true;
        // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[5];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
        reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
        reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Section", Section);
        reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("CoScholasticArea", CoScholasticArea);
        reportParameterCollection[4] = new Microsoft.Reporting.WebForms.ReportParameter("AssesmentID", AssesmentName);
        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

        MyReportViewer.ServerReport.Refresh();
    }
    protected void ddlCoScholastisarea_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindAssesmentArea(Convert.ToInt32(ddlCoScholastisarea.Items[ddlCoScholastisarea.SelectedIndex].Value));
    }
}
