using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BusinessLayer;

public partial class Admin_DefineClub : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindClub();
        }
    }
    public void bindClub()
    {
        ds = new DataSet();
        ds = objComm.GetClub();
        gdvClub.DataSource = ds.Tables[0];
        gdvClub.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {
            i = objComm.AddClub(txtClub.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtClub.Text + " Club Name Added Successfully";
                txtClub.Text = "";
                bindClub();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtClub.Text + "  Club Name Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditClub(Convert.ToInt32(hdnClubID.Value), txtClub.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtClub.Text + "  Club Name Modified Successfully";
                txtClub.Text = "";
                btnAdd.Text = "Add";
                bindClub();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtClub.Text + "  Club Name Already Exists";

            }
        }
    }
    protected void gdvClub_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvClub.Rows)
        {
            Label lblClubID = new Label();
            Label lblClub = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblClubID = (Label)gvr.Cells[0].FindControl("lblClubID");
            lblClub = (Label)gvr.Cells[1].FindControl("lblClub");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblClubID.Text + "@" + lblClub.Text;
            lnkDelete.CommandArgument = lblClubID.Text + "@" + lblClub.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    protected void gdvClub_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtClub.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnClubID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnClubID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteClub(Convert.ToInt32(hdnClubID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtClub.Text + "  Club Name Deleted Successfully";
                txtClub.Text = "";
                bindClub();
            }
            btnAdd.Text = "Add";
        }
    }
}
