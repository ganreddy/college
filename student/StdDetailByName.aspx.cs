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

public partial class student_StdDetailByName : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStud = new StudentAdmissionBL();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        btnReport.Attributes.Add("onclick ", "javascript:return gridvalidatio(); ");
        rdbAdminNo.Attributes.Add("onclick", "javascript:return ShowHide();");
        rdbName.Attributes.Add("onclick", "javascript:return ShowHide();");
        btnReport.Attributes.Add("onclick ", "javascript:return validation(); ");
        
        if (!IsPostBack)
        {
            rdbAdminNo.Checked = true;
            ds = objcomm.GetBatch();
            ddlBatch.DataSource = ds.Tables[0];
            ddlBatch.DataTextField = "BatchNo";
            ddlBatch.DataValueField = "BatchID";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objcomm.GetClasses();
            ddlClasses.DataSource = ds.Tables[0];
            ddlClasses.DataTextField = "ClassName";
            ddlClasses.DataValueField = "ClassID";
            ddlClasses.DataBind();
            ddlClasses.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objcomm.GetSection();
            ddlSections.DataSource = ds.Tables[0];
            ddlSections.DataTextField = "SectionName";
            ddlSections.DataValueField = "SectionID";
            ddlSections.DataBind();
            ddlSections.Items.Insert(0, new ListItem("---Select---", "0"));


        }
        if (rdbAdminNo.Checked)
        {
            hdntransfer.Value = "1";
            pnlAdmSearch.Style.Add("display", "inline");
            pnlSearchName.Style.Add("display", "none");
        }
        else
        {
            hdntransfer.Value = "0";
            pnlSearchName.Style.Add("display", "inline");
            pnlAdmSearch.Style.Add("display", "none");
        }

    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    public void fillStudent(int ClassID, int BatchID, int SectionID)
    {
        ds = new DataSet();
        ds = objStud.GetStudentDataTC(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            gdvStud.DataSource = ds.Tables[0];
            gdvStud.DataBind();
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ds = objStud.GetStudentDetailsByName(txtAdmissionNo.Text);
        gdvStud.DataSource = ds.Tables[0];
        gdvStud.DataBind();
    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbName.Checked)
        {
            pnlAdmSearch.Style.Add("display", "none");
            pnlSearchName.Style.Add("display", "inline");
        }
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
    }
    protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbName.Checked)
        {
            pnlAdmSearch.Style.Add("display", "none");
            pnlSearchName.Style.Add("display", "inline");
        }
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
    }
    protected void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbName.Checked)
        {
            pnlAdmSearch.Style.Add("display", "none");
            pnlSearchName.Style.Add("display", "inline");
        }
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gdvStud.Rows)
        {
            Label lblStudId = new Label();
            RadioButton rdb = new RadioButton();
            rdb = (RadioButton)gvr.Cells[1].FindControl("rdbSelect");
            if (rdb.Checked)
            {
                lblStudId = (Label)gvr.Cells[0].FindControl("lblStudId");
                MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
                MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "StudentIDReport"; // Report Name
                MyReportViewer.ShowParameterPrompts = false;
                MyReportViewer.ShowPrintButton = true;
                MyReportViewer.ShowToolBar = true;

                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[1];
                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("StudId", lblStudId.Text);

                MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

                MyReportViewer.ServerReport.Refresh();
                break;
            }
        }
    }
    protected void gdvStud_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gdvStud.Rows)
        {
            Label lblStudId = new Label();
            lblStudId = (Label) (gvr.Cells[2].FindControl("lblFullName"));
            RadioButton rdb = new RadioButton();
            rdb = (RadioButton)gvr.Cells[1].FindControl("rdbSelect");
            rdb.Attributes.Add("onclick", "javascript:return Check('" + rdb.ClientID + "','" + lblStudId.Text + "','" + txtAdmissionNo.ClientID + "');");

        }
    }
    protected void gdvStud_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
    }
    protected void gdvStud_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        
    }
}
