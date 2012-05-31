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

public partial class Admin_DefineActivities : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
           
            ds = objComm.GetClub();
            ddlClube.DataSource = ds.Tables[0];
            ddlClube.DataTextField = "ClubName";
            ddlClube.DataValueField = "ClubID";
           
 
            ddlClube.DataBind();
            ddlClube.Items.Insert(0, new ListItem("---Select---", "0"));
            bindActivities();
        }
    }
    public void bindActivities()
    {
        ds = new DataSet();
        //int type = Convert.ToInt32(ddlType.SelectedValue);
        ds = objComm.GetActivities((Convert.ToInt16(ddlType.SelectedValue)),(Convert.ToInt16(ddlClube.SelectedValue)));
        gdvActivities.DataSource = ds.Tables[0];
        gdvActivities.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {
            i = objComm.AddActivities(txtActivities.Text,Convert.ToInt32(ddlType.Items[ddlType.SelectedIndex].Value),Convert.ToInt16(ddlClube.SelectedValue));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtActivities.Text + "  Activities Added Successfully";
                txtActivities.Text = "";
                bindActivities();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtActivities.Text + "  Activities Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditActivities(Convert.ToInt32(hdnActivitiesID.Value), txtActivities.Text,Convert.ToInt32(ddlType.Items[ddlType.SelectedIndex].Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtActivities.Text + "  Activities Modified Successfully";
                txtActivities.Text = "";
                ddlType.SelectedValue = "0";
                btnAdd.Text = "Add";
                bindActivities();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtActivities.Text + "  Activities Already Exists";

            }
        }
        
    }

    protected void gdvActivities_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvActivities.Rows)
        {
            Label lblActid = new Label();
            Label lblActivities = new Label();
            Label lblType = new Label();
            Label lblClub = new Label();
            Label lblClubName = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblActid = (Label)gvr.Cells[0].FindControl("lblActid");
            lblActivities = (Label)gvr.Cells[1].FindControl("lblActivities");
            lblType = (Label)gvr.Cells[2].FindControl("lblType");
            lblClub = (Label)gvr.Cells[3].FindControl("lblClub");
            lblClubName = (Label)gvr.Cells[4].FindControl("lblClubName");
            lnkEdit = (LinkButton)gvr.Cells[5].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[6].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblActid.Text + "@" + lblActivities.Text + "@" + lblType.Text+"@"+lblClub.Text+"@"+lblClubName.Text  ;
            lnkDelete.CommandArgument = lblActid.Text + "@" + lblActivities.Text + "@" + lblType.Text + "@" + lblClub.Text + "@" + lblClubName.Text; 
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
            if (lblType.Text == "1") lblType.Text = "Individual";
            if (lblType.Text == "2") lblType.Text = "Group";
        }
    }
    protected void gdvActivities_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtActivities.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnActivitiesID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            if(e.CommandArgument.ToString().Split('@')[2].ToString()=="Individual")
            {
                ddlType.SelectedValue="1";  
            }
            if (e.CommandArgument.ToString().Split('@')[2].ToString() == "Group")
            {
                ddlType.SelectedValue = "2";
            }

            ddlClube.SelectedValue = e.CommandArgument.ToString().Split('@')[3].ToString(); 
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnActivitiesID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteActivities(Convert.ToInt32(hdnActivitiesID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtActivities.Text + "  Activities Deleted Successfully";
                txtActivities.Text = "";
                bindActivities();
            }
            btnAdd.Text = "Add";
        }
    }
    protected void gdvActivities_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvActivities.PageIndex = e.NewPageIndex;
        bindActivities();
    }
    protected void ddlClube_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindActivities();
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindActivities();
    }
}
