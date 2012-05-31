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

public partial class CCE_ReportScholasticWiseStudentsPercentage : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.CCEBL objCCE = new CCEBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStud = new StudentAdmissionBL();
   // DataSet dsExam;
    string strValues = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnReport.Attributes.Add("onclick", "javascript:return validate();");
        rbtnTabularReport.Attributes.Add("onclick", "javascript:return Display();");
        rbtnGraphical.Attributes.Add("onclick", "javascript:return Display();");
        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = objCCE.GetExam(0);
            ddlExamType.DataSource = ds.Tables[0];
            ddlExamType.DataTextField = "ExamName";
            ddlExamType.DataValueField = "ExamID";
            ddlExamType.DataBind();
            ddlExamType.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetClasses();
            ddlClass.DataSource = ds.Tables[0];
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
            //ds = objComm.GetBatch();
            //ddlBatch.DataSource = ds.Tables[0];
            //ddlBatch.DataTextField = "BatchNo";
            //ddlBatch.DataValueField = "BatchID";
            //ddlBatch.DataBind();
            //ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.getbatch();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string j = ds.Tables[0].Rows[i]["BatchNo"].ToString() + "-" + Convert.ToString(Convert.ToInt32(ds.Tables[0].Rows[i]["BatchNo"].ToString()) + 1);
                ddlBatch.Items.Add(new ListItem(j.ToString(), ds.Tables[0].Rows[i]["BatchID"].ToString()));
            }
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
        string Batch = string.Empty, Class = string.Empty, Section = string.Empty, Subject = string.Empty, ExamType = string.Empty, ScholasticArea = string.Empty;
        Batch = ddlBatch.Items[ddlBatch.SelectedIndex].Value;
        Class = ddlClass.Items[ddlClass.SelectedIndex].Value;
        //Section = ddlSection.Items[ddlSection.SelectedIndex].Value;
        Subject = ddlSubject.Items[ddlSubject.SelectedIndex].Value;
        ExamType = ddlExamType.Items[ddlExamType.SelectedIndex].Value;
        ScholasticArea = ddlScholastisarea.Items[ddlScholastisarea.SelectedIndex].Value;
        if (rbtnGraphical.Checked)
        {
            if (ddlChartType.SelectedIndex == 1)
            {
                MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
                MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "CCEGraphicalReportScholasticWiseStudentsPercentage"; // Report Name
                MyReportViewer.ShowParameterPrompts = false;
                MyReportViewer.ShowPrintButton = true;
                MyReportViewer.ShowToolBar = true;
                MyReportViewer.SizeToReportContent = true;
                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.
                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[5];
                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Classid", Class);
                reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("ExamID", ExamType);
                reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("SubjectID", Subject);
                reportParameterCollection[4] = new Microsoft.Reporting.WebForms.ReportParameter("ScholasticID", ScholasticArea);
                MyReportViewer.ServerReport.SetParameters(reportParameterCollection);
                MyReportViewer.ServerReport.Refresh();
            }
        }
        if (rbtnTabularReport.Checked)
        {
            MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
            MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "CCEReportScholasticWiseStudentsPercentage"; // Report Name
            MyReportViewer.ShowParameterPrompts = false;
            MyReportViewer.ShowPrintButton = true;
            MyReportViewer.ShowToolBar = true;
            MyReportViewer.SizeToReportContent = true;
            // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.
            Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[5];
            reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
            reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Classid", Class);
            reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("ExamID", ExamType);
            reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("SubjectID", Subject);
            reportParameterCollection[4] = new Microsoft.Reporting.WebForms.ReportParameter("ScholasticID", ScholasticArea);
            MyReportViewer.ServerReport.SetParameters(reportParameterCollection);
            MyReportViewer.ServerReport.Refresh();
        }
    }
    public void fillScholastic(int ExamID, int Batch, int Subject, int Class)
    {
        BusinessLayer.CCEBL objCCE = new CCEBL();
        ds = objCCE.GetScholasticArea(Convert.ToInt32(ddlExamType.Items[ddlExamType.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value), Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value));
        ddlScholastisarea.DataSource = ds.Tables[0];
        ddlScholastisarea.DataTextField = "ScholasticArea";
        ddlScholastisarea.DataValueField = "ScholasticID";
        ddlScholastisarea.DataBind();
        ddlScholastisarea.Items.Insert(0, new ListItem("---Select---", "0"));
        ds = new DataSet();


    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillScholastic(Convert.ToInt32(ddlExamType.Items[ddlExamType.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value), Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value));
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillScholastic(Convert.ToInt32(ddlExamType.Items[ddlExamType.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value), Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value));
    }
    protected void ddlExamType_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillScholastic(Convert.ToInt32(ddlExamType.Items[ddlExamType.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value), Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value));
    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillScholastic(Convert.ToInt32(ddlExamType.Items[ddlExamType.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value), Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value));
    }
}
