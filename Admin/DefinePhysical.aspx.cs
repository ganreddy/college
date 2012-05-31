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

public partial class Admin_DefinePhysical : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindPH();
        }
    }
    public void bindPH()
    {
        ds = new DataSet();
        ds = objComm.GetPhysicallyChallenged();
        gdvPH.DataSource = ds.Tables[0];
        gdvPH.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objComm.AddPhysicallyChallenged(txtPH.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtPH.Text + " Physical  Challenges Added Successfully";
                txtPH.Text = "";
                bindPH();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtPH.Text + " Physical  Challenges Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditPhysicallychallenged(Convert.ToInt32(hdnPH.Value), txtPH.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtPH.Text + "  Physical  Challenges Modified Successfully";
                txtPH.Text = "";
                btnAdd.Text = "Add";
                bindPH();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtPH.Text + "  Physical  Challenges Already Exists";

            }
        }

    }
    protected void gdvPH_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtPH.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnPH.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnPH.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.Deletephysicallychallenged(Convert.ToInt32(hdnPH.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtPH.Text + " Physical  Challenges Deleted Successfully";
                txtPH.Text = "";
                bindPH();
            }
        }

    }
    protected void gdvPH_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvPH.Rows)
        {
            Label lblPHId = new Label();
            Label lblPHName = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblPHId = (Label)gvr.Cells[0].FindControl("lblPHId");
            lblPHName = (Label)gvr.Cells[1].FindControl("lblPHName");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblPHId.Text + "@" + lblPHName.Text;
            lnkDelete.CommandArgument = lblPHId.Text + "@" + lblPHName.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    
}
