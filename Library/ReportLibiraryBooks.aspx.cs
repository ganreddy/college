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

public partial class Library_ReportLibiraryBooks : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.LibraryBL objLibrary = new LibraryBL();

    DataSet ds;


    protected void Page_Load(object sender, EventArgs e)
    {
        //btnReport.Attributes.Add("onclick", "javascript:return validate();");
        ds = new DataSet();
        if (!IsPostBack)
        {
            ds = objComm.GetSubject();
            ddlSubject.DataSource = ds.Tables[0];
            ddlSubject.DataTextField = "SubjectName";
            ddlSubject.DataValueField = "SubjectId";
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(0, new ListItem("---Select---", "0"));
            ds=objLibrary.GetLibBookCategory();
            ddlCategory.DataSource = ds.Tables[0];
            ddlCategory.DataTextField = "Category";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("---Select---", "0"));
            for (int i = 1990; i < 2050; i++)
            {
                ddlLibYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlLibYear.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetMedium();
            ddlLanguage.DataSource = ds.Tables[0];
            ddlLanguage.DataTextField = "Language";
            ddlLanguage.DataValueField = "MediumID";
            ddlLanguage.DataBind();
            ddlLanguage.Items.Insert(0, new ListItem("---Select---", "0"));

        }

    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        string Subject = string.Empty, Category = string.Empty, AcessionNo = string.Empty, Author = string.Empty, Year = string.Empty, Language = string.Empty;
        Subject = ddlSubject.Items[ddlSubject.SelectedIndex].Value;
        Category = ddlCategory.Items[ddlCategory.SelectedIndex].Value;
        AcessionNo = txtAcessionNo.Text;
        Author = txtAuthor.Text;
        Year = ddlLibYear.Items[ddlLibYear.SelectedIndex].Value;
        Language = ddlLanguage.Items[ddlLanguage.SelectedIndex].Value;

        MessPurchaseReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MessPurchaseReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
        MessPurchaseReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "BookDetails";
        MessPurchaseReportViewer.ShowParameterPrompts = false;
        MessPurchaseReportViewer.ShowPrintButton = true;
        MessPurchaseReportViewer.ShowToolBar = true;
        MessPurchaseReportViewer.SizeToReportContent = true;
        Microsoft.Reporting.WebForms.ReportParameter[] MessPurchaseParam = new Microsoft.Reporting.WebForms.ReportParameter[6];
        MessPurchaseParam[0] = new Microsoft.Reporting.WebForms.ReportParameter("Subject", Subject);
        MessPurchaseParam[1] = new Microsoft.Reporting.WebForms.ReportParameter("Category", Category);
        MessPurchaseParam[2] = new Microsoft.Reporting.WebForms.ReportParameter("AcessionNo", AcessionNo);
        MessPurchaseParam[3] = new Microsoft.Reporting.WebForms.ReportParameter("Author", Author);
        MessPurchaseParam[4] = new Microsoft.Reporting.WebForms.ReportParameter("YearofPub", Year);
        MessPurchaseParam[5] = new Microsoft.Reporting.WebForms.ReportParameter("Language", Language);
        MessPurchaseReportViewer.ServerReport.SetParameters(MessPurchaseParam);
        MessPurchaseReportViewer.ServerReport.Refresh();
    }
}
