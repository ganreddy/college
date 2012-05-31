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

public partial class CCE_ReportCCENormal : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.CCEBL objCCE = new CCEBL();
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ds = objComm.GetBatch();
            ddlBatch.DataSource = ds.Tables[0];
            ddlBatch.DataTextField = "BatchNo";
            ddlBatch.DataValueField = "BatchID";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetClasses();
            ddlClass.DataSource = ds.Tables[0];
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetSection();
            ddlSection.DataSource = ds.Tables[0];
            ddlSection.DataTextField = "SectionName";
            ddlSection.DataValueField = "SectionID";
            ddlSection.DataBind();
            ddlSection.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objStudComm.GetStudent(0);
            ddlStudID.DataSource = ds.Tables[0];
            ddlStudID.DataTextField = "FullName";
            ddlStudID.DataValueField = "StudID";
            ddlStudID.DataBind();
            ddlStudID.Items.Insert(0, new ListItem("---Select---", "0"));
        }

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
         string Stud = string.Empty,Batch=string.Empty,Class=string.Empty,Section=string.Empty;
        Stud = ddlStudID.Items[ddlStudID.SelectedIndex].Value;
        Batch = ddlBatch.Items[ddlBatch.SelectedIndex].Value;
        Class = ddlClass.Items[ddlClass.SelectedIndex].Value;
        Section = ddlSection.Items[ddlSection.SelectedIndex].Value;
        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "CCEReportNormal"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;
        MyReportViewer.SizeToReportContent = true;
        // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[4];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
        reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
        reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Section", Section);
        reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("StudID", Stud);
        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

        MyReportViewer.ServerReport.Refresh();
        //if (Batch != "0")
        //{
        //    if (Class != "0")
        //    {
        //        if (Section != "0")
        //        {
        //            if (Stud != "0")
        //            {
        //                lblMessage.Visible = true;
        //                lblMessage.Text = "Batch=" + ddlBatch.SelectedItem.Text;
        //            }
        //        }
        //    }
        //}

    }
    public void fillStudent(int ClassID, int BatchID, int SectionID)
    {
        BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
        ds = new DataSet();
        ds = objStudComm.GetStudData(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
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
        fillStudent(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
    }
    protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
    }
    protected void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
    }
}
