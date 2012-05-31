using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using BusinessLayer;


public partial class DefineSubjects : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;



    protected void Page_Load(object sender, EventArgs e)
    {

        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindSubjects();
        }
    }
    public void bindSubjects()
    {
        ds = new DataSet();
        ds = objComm.GetSubject();
        gdvSubjects.DataSource = ds.Tables[0];
        gdvSubjects.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objComm.AddSubject(txtSubject.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSubject.Text + "  Subject Name Added Successfully";
                txtSubject.Text = "";
                bindSubjects();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSubject.Text + "  Subject Name Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditSubject(Convert.ToInt32(hdnSubjectID.Value), txtSubject.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSubject.Text + "  Subject Name Modified Successfully";
                txtSubject.Text = "";
                btnAdd.Text = "Add";
                bindSubjects();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSubject.Text + "  Subject Name Already Exists";

            }
        }

    }
    protected void gdvSubjects_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtSubject.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnSubjectID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnSubjectID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteSubject(Convert.ToInt32(hdnSubjectID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSubject.Text + "  Subject Name Deleted Successfully";
                txtSubject.Text = "";
                bindSubjects();
            }
        }

    }
    protected void gdvSubjects_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvSubjects.Rows)
        {
            Label lblSubjectId = new Label();
            Label lblSubjectName = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblSubjectId = (Label)gvr.Cells[0].FindControl("lblSubjectId");
            lblSubjectName = (Label)gvr.Cells[1].FindControl("lblSubjectName");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblSubjectId.Text + "@" + lblSubjectName.Text;
            lnkDelete.CommandArgument = lblSubjectId.Text + "@" + lblSubjectName.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    protected void gdvSubjects_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvSubjects.PageIndex = e.NewPageIndex;
        bindSubjects();
    }
}