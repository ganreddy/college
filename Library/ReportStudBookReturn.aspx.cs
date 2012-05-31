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
public partial class student_ReportStudentBookReturn : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL studAdm = new StudentAdmissionBL();
    DataSet ds;
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
            ddlStudent.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
    }
     public void fillStudent(int ClassID, int BatchID, int SectionID)
    {
        ds = new DataSet();
        ds = studAdm.GetStudData(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            ddlStudent.DataSource = ds.Tables[0];
            ddlStudent.DataTextField = "FullName";
            ddlStudent.DataValueField = "StudID";
            ddlStudent.DataBind();
            ddlStudent.Items.Insert(0, new ListItem("---Select---", "0"));
        }

    }
     protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
     {
         fillStudent(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
     }
     protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
     {
         fillStudent(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
     }
     protected void btnGetReport_Click(object sender, EventArgs e)
     {
         string Batch = string.Empty;
         string Class = string.Empty;
         string Section = string.Empty;
         string Student = string.Empty;
         string ReturnFromDate = string.Empty;
         string ReturnToDate = string.Empty;
         string PaymentFromDate = string.Empty;
         string PaymentToDate = string.Empty;

         Batch = ddlBatch.Items[ddlBatch.SelectedIndex].Value;
         Class=ddlClass.Items[ddlClass.SelectedIndex].Value;
         Section = ddlSection.Items[ddlSection.SelectedIndex].Value;
         Student = ddlStudent.Items[ddlStudent.SelectedIndex].Value;
         if (txtReturnFromDate.Text != "")
             ReturnFromDate = ChangeDateFormat(txtReturnFromDate.Text);
         if (txtReturnToDate.Text != "")
             ReturnToDate = ChangeDateFormat(txtReturnToDate.Text);
         if (txtPaymentFromDate.Text != "")
             PaymentFromDate = ChangeDateFormat(txtPaymentFromDate.Text);
         if (txtPaymentToDate.Text != "")
             PaymentToDate = ChangeDateFormat(txtPaymentToDate.Text);

         StuBookReturnReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
         StuBookReturnReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
         StuBookReturnReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString()+"StudentBookReturn";
         StuBookReturnReportViewer.ShowParameterPrompts = false;
         StuBookReturnReportViewer.ShowPrintButton = true;
         StuBookReturnReportViewer.ShowToolBar = true;
         StuBookReturnReportViewer.SizeToReportContent = true;
         Microsoft.Reporting.WebForms.ReportParameter[] StuBookReturnParam = new Microsoft.Reporting.WebForms.ReportParameter[8];
         StuBookReturnParam[0] = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch);
         StuBookReturnParam[1] = new Microsoft.Reporting.WebForms.ReportParameter("Class", Class);
         StuBookReturnParam[2] = new Microsoft.Reporting.WebForms.ReportParameter("Section", Section);
         StuBookReturnParam[3] = new Microsoft.Reporting.WebForms.ReportParameter("Student", Student);
         StuBookReturnParam[4] = new Microsoft.Reporting.WebForms.ReportParameter("ReturnFromDate", ReturnFromDate);
         StuBookReturnParam[5] = new Microsoft.Reporting.WebForms.ReportParameter("ReturnToDate", ReturnToDate);
         StuBookReturnParam[6] = new Microsoft.Reporting.WebForms.ReportParameter("PaymentFromDate", PaymentFromDate);
         StuBookReturnParam[7] = new Microsoft.Reporting.WebForms.ReportParameter("PaymentToDate", PaymentToDate);
         StuBookReturnReportViewer.ServerReport.SetParameters(StuBookReturnParam);
         StuBookReturnReportViewer.ServerReport.Refresh();


     }
     public string ChangeDateFormat(string Date)
     {
         return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
     }
     
}