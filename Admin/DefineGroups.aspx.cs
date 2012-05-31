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


public partial class DefineGroups : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {

        btnAddGroup.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style","color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindGroups();
        }
    }
    public void bindGroups()
    {
        ds = new DataSet();
        ds = objComm.GetGroups();
        gdvGroups.DataSource = ds.Tables[0];
        gdvGroups.DataBind();
    }
    protected void btnAddGroup_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAddGroup.Text == "Add")
        {

            i = objComm.AddGroups(txtGroupName.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtGroupName.Text + "  Group Name Added Successfully";
                txtGroupName.Text = "";
                bindGroups();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtGroupName.Text + "  Group Name Already Exists";

            }
        }
        if (btnAddGroup.Text == "Update")
        {
            i = objComm.EditGroups(Convert.ToInt32(hdnGroup.Value), txtGroupName.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtGroupName.Text + "  Group Name Modified Successfully";
                txtGroupName.Text = "";
                btnAddGroup.Text = "Add";
                bindGroups();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtGroupName.Text + "  Group Name Already Exists";

            }
        }

    }
    protected void  gdvGroups_RowCommand(object sender, GridViewCommandEventArgs e)
{
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtGroupName.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnGroup.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAddGroup.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnGroup.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteGroups(Convert.ToInt32(hdnGroup.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtGroupName.Text + " Group Deleted Successfully";
                txtGroupName.Text = "";
                bindGroups();
            }
        }

    }
    protected void  gdvGroups_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvGroups.Rows)
        {
            Label lblGroupId = new Label();
            Label lblGroupName = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblGroupId = (Label)gvr.Cells[0].FindControl("lblGroupId");
            lblGroupName = (Label)gvr.Cells[1].FindControl("lblGroupName");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblGroupId.Text + "@" + lblGroupName.Text;
            lnkDelete.CommandArgument = lblGroupId.Text + "@" + lblGroupName.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }

   
   
}
