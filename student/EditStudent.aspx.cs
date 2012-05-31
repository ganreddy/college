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

public partial class student_EditStudent : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStud = new StudentAdmissionBL();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        rdbAdminNo.Attributes.Add("onclick", "javascript:return ShowHide();");
        rdbName.Attributes.Add("onclick", "javascript:return ShowHide();");
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
            //ds = objcomm.GetSection();
            //ddlSections.DataSource = ds.Tables[0];
            //ddlSections.DataTextField = "SectionName";
            //ddlSections.DataValueField = "SectionID";
            //ddlSections.DataBind();
            //ddlSections.Items.Insert(0, new ListItem("---Select---", "0"));


        }
        if (rdbAdminNo.Checked)
        {
            pnlAdmSearch.Style.Add("display", "inline");
            pnlSearchName.Style.Add("display", "none");
        }
        else
        {
            pnlSearchName.Style.Add("display", "inline");
            pnlAdmSearch.Style.Add("display", "none");
        }

    }
    public void fillStudent(int ClassID, int BatchID, int SectionID)
    {
        ds = new DataSet();
        ds = objStud.GetStudentData1(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), 1);
        if (ds.Tables.Count > 0)
        {
            gdvStud.DataSource = ds.Tables[0];
            gdvStud.DataBind();
        }

    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ds = objStud.GetStudentDetailsByAdmissionNo(txtAdmissionNo.Text);
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
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), 1);

    }
    protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbName.Checked)
        {
            pnlAdmSearch.Style.Add("display", "none");
            pnlSearchName.Style.Add("display", "inline");
        }
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), 1);

    }
    protected void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbName.Checked)
        {
            pnlAdmSearch.Style.Add("display", "none");
            pnlSearchName.Style.Add("display", "inline");
        }
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value),1);
    }
    protected void gdvStud_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Label lblStudId = new Label();
        lblStudId = (Label)gdvStud.Rows[e.NewEditIndex].Cells[0].FindControl("lblStudentID");
        Response.Redirect("../Student/StudentAdmin.aspx?ID=" + lblStudId.Text);
    }


    protected void gdvStud_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvStud.PageIndex = e.NewPageIndex;
        ds = objStud.GetStudentDetailsByAdmissionNo(txtAdmissionNo.Text);
        gdvStud.DataSource = ds.Tables[0];
        gdvStud.DataBind();
    }
}
