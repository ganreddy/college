using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Web.UI.WebControls;
using BusinessLayer;

public partial class student_StudentPromotion : System.Web.UI.Page
{
    BusinessLayer.StudentAdmissionBL objCon = new StudentAdmissionBL();
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnPromote.Attributes.Add("Onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            ds = objcomm.GetBatch();
            ddlBatch.DataSource = ds.Tables[0];
            ddlBatch.DataTextField = "BatchNo";
            ddlBatch.DataValueField = "BatchID";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objcomm.GetClasses();
            ddlClass.DataSource = ds.Tables[0];
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objcomm.GetSection();
            ddlSection.DataSource = ds.Tables[0];
            ddlSection.DataTextField = "SectionName";
            ddlSection.DataValueField = "SectionID";
            ddlSection.DataBind();
            ddlSection.Items.Insert(0, new ListItem("---Select---", "0"));
        }

    }
    public void fillStudent(int ClassID, int BatchID, int SectionID)
    {
        ds = new DataSet();
        ds = objCon.GetStudentData(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            gdvStudent.DataSource = ds.Tables[0];
            gdvStudent.DataBind();
        }
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }

    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStudent();
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStudent();
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = new DataSet();
        ds = objCon.GetStudentData(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value),
            Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value),
            Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
        gdvStudent.DataSource = ds.Tables[0];
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvStudent.Visible = true;
                gdvStudent.DataSource = ds.Tables[0];
                gdvStudent.DataBind();
                //CheckSelectAll.Visible = true;
                lblMessage.Visible = false;
                lblMessage.Text = "";
            }
            else
            {
                //CheckSelectAll.Visible = false;
                gdvStudent.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = "No More Students In This Batch,Class,Section";
            }
        }
    }
    protected void gdvStudent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ds = objcomm.GetSection();
        if (e.Row.RowType == DataControlRowType.Header)
        {
            CheckBox chkAll = new CheckBox();
            chkAll = (CheckBox)e.Row.FindControl("chkAll");
            chkAll.Attributes.Add("onclick", "javascript:return CheckAllClick(" + chkAll.ClientID + ");");
        }
        foreach (GridViewRow gvr in gdvStudent.Rows)
        {
            DropDownList ddlSections = new DropDownList();
            ddlSections = (DropDownList)gvr.FindControl("ddlSections");
            ddlSections.DataSource = ds.Tables[0];
            ddlSections.DataTextField = "SectionName";
            ddlSections.DataValueField = "SectionID";
            ddlSections.DataBind();
            ddlSections.SelectedValue = ddlSection.Items[ddlSection.SelectedIndex].Value;
        }
    }
    protected void btnPromote_Click(object sender, EventArgs e)
    {
        int i = 0;
       foreach (GridViewRow gvr in gdvStudent.Rows)
       {
           CheckBox chk = new CheckBox();
           DropDownList ddlSections = new DropDownList();
           Label lblStudID = new Label();
           lblStudID = (Label)gvr.FindControl("lblStudID");
           ddlSections = (DropDownList)gvr.FindControl("ddlSections");
           chk = (CheckBox)gvr.FindControl("chk");
           if (chk.Checked)
           {
               i = objCon.AddStudentPromotion(Convert.ToInt32(lblStudID.Text), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex + 1].Value), Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex + 1].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
           }
       }
       fillStudent(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
       if (i != 0)
       {
           lblMessage.Visible = true;
           lblMessage.Text = "Students Promoted Successfully";
       }
    }
    public void BindStudent()
    {
        ds = new DataSet();
        ds = objCon.GetStudentData(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value),
            Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), 
            Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
        gdvStudent.DataSource = ds.Tables[0];
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvStudent.Visible = true;
                gdvStudent.DataSource = ds.Tables[0];
                gdvStudent.DataBind();
                //CheckSelectAll.Visible = true;
                lblMessage.Visible = false;
                lblMessage.Text = "";
            }
            else
            {
                //CheckSelectAll.Visible = false;
                gdvStudent.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = "";
            }
        }
    }
}
