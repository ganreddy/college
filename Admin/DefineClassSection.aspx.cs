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


public partial class DefineClassSection : System.Web.UI.Page
{


    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindSection();
        }
    }
    public void bindSection()
    {
        ds = new DataSet();
        ds = objComm.GetSection();
        gdvBatch.DataSource = ds.Tables[0];
        gdvBatch.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objComm.AddSection(txtSection.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSection.Text + "  Section Added Successfully";
                txtSection.Text = "";
                bindSection();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSection.Text + "  Section Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditSection(Convert.ToInt32(hdnSection.Value), txtSection.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSection.Text + "  Section Modified Successfully";
                txtSection.Text = "";
                btnAdd.Text = "Add";
                bindSection();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSection.Text + "  Section Already Exists";

            }
        }

    }
    protected void gdvBatch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtSection.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnSection.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnSection.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteSection(Convert.ToInt32(hdnSection.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSection.Text + "  Section Deleted Successfully";
                txtSection.Text = "";
                bindSection();
            }
        }

    }
    protected void gdvBatch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvBatch.Rows)
        {
            Label lblSectionID = new Label();
            Label lblSectionName = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblSectionID = (Label)gvr.Cells[0].FindControl("lblSectionID");
            lblSectionName = (Label)gvr.Cells[1].FindControl("lblSectionName");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblSectionID.Text + "@" + lblSectionName.Text;
            lnkDelete.CommandArgument = lblSectionID.Text + "@" + lblSectionName.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    
}
