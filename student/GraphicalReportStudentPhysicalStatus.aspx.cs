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
public partial class student_GraphicalReportStudentPhysicalStatus : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnReport.Attributes.Add("onclick", "javascript:return validate();");
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
            //ds = objStudComm.GetPromotionSection();
            ds = objComm.GetSection();
            ddlSections.DataSource = ds.Tables[0];
            ddlSections.DataTextField = "SectionName";
            ddlSections.DataValueField = "SectionID";
            ddlSections.DataBind();
            ddlSections.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objStudComm.GetStudent(0);
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
    public void fillStudent(int ClassID, int BatchID, int SectionID)
    {
        BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
        ds = objStudComm.GetStudPromotionData(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
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
        ds = objStudComm.GetStud_PhysicalState(Convert.ToInt32(ddlBatch.SelectedValue), Convert.ToInt32(ddlClasses.SelectedValue), Convert.ToInt32(ddlSections.SelectedValue), Convert.ToInt32(ddlStudID.SelectedValue));
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string Batch = string.Empty, Class = string.Empty, Section = string.Empty, Caste = string.Empty, Stud = string.Empty, Gender=string.Empty;
        Batch = ddlBatch.Items[ddlBatch.SelectedIndex].Value;
        Class = ddlClasses.Items[ddlClasses.SelectedIndex].Value;
        Section = ddlSections.Items[ddlSections.SelectedIndex].Value;
        Stud = ddlStudID.Items[ddlStudID.SelectedIndex].Value;
        Gender = ddlGender.Items[ddlGender.SelectedIndex].Value;
        if (rbtnTabularReport.Checked)
        {

            ReportStudPhysicalState.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportStudPhysicalState.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
            ReportStudPhysicalState.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "StudentPhysicalState"; // Report Name
            ReportStudPhysicalState.ShowParameterPrompts = false;
            ReportStudPhysicalState.ShowPrintButton = true;
            ReportStudPhysicalState.ShowToolBar = true;
            ReportStudPhysicalState.SizeToReportContent = true;
            // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

            Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[4];
            reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
            reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
            reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Section", Section);
            reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("Gender", Gender);

            ReportStudPhysicalState.ServerReport.SetParameters(reportParameterCollection);

            ReportStudPhysicalState.ServerReport.Refresh();
        }
        if (rbtnGraphical.Checked)
        {
            if (ddlChartType.SelectedIndex == 1)
            {
                ReportStudPhysicalState.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportStudPhysicalState.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
                ReportStudPhysicalState.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "BarChartStudentPhysicalstateReport"; // Report Name
                ReportStudPhysicalState.ShowParameterPrompts = false;
                ReportStudPhysicalState.ShowPrintButton = true;
                ReportStudPhysicalState.ShowToolBar = true;
                ReportStudPhysicalState.SizeToReportContent = true;
                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[4];
                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
                reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Section", Section);
                reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("StudID", Stud);
                ReportStudPhysicalState.ServerReport.SetParameters(reportParameterCollection);

                ReportStudPhysicalState.ServerReport.Refresh();
            }
            if (ddlChartType.SelectedIndex == 2)
            {
                ReportStudPhysicalState.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportStudPhysicalState.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
                ReportStudPhysicalState.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "LineChartStudentPhysicalstateReport"; // Report Name
                ReportStudPhysicalState.ShowParameterPrompts = false;
                ReportStudPhysicalState.ShowPrintButton = true;
                ReportStudPhysicalState.ShowToolBar = true;
                ReportStudPhysicalState.SizeToReportContent = true;
                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[4];
                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
                reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("Section", Section);
                reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("StudID", Stud);
                ReportStudPhysicalState.ServerReport.SetParameters(reportParameterCollection);

                ReportStudPhysicalState.ServerReport.Refresh();
            }
        }
    }
}
