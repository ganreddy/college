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

public partial class CCE_DefineCoScholastic : System.Web.UI.Page
{
    BusinessLayer.CCEBL objComm = new CCEBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindCoScholastic();
        }
    }
    public void bindCoScholastic()
    {
        ds = new DataSet();
        ds = objComm.GetCoScholasticArea(0);
        gdvCoScholastic.DataSource = ds.Tables[0];
        gdvCoScholastic.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objComm.AddCoScholasticArea(txtCoScholastic.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtCoScholastic.Text + "   Added Successfully";
                txtCoScholastic.Text = "";
                bindCoScholastic();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtCoScholastic.Text + "   Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditCoScholasticArea(Convert.ToInt32(hdnCasteID.Value), txtCoScholastic.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtCoScholastic.Text + "   Modified Successfully";
                txtCoScholastic.Text = "";
                btnAdd.Text = "Add";
                bindCoScholastic();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtCoScholastic.Text + "  Exam Already Exists";

            }
        }
    }

    protected void gdvCoScholastic_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvCoScholastic.Rows)
        {
            Label lblCoScholasticID = new Label();
            Label lblCoScholasticArea = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblCoScholasticID = (Label)gvr.FindControl("lblCoScholasticID");
            lblCoScholasticArea = (Label)gvr.FindControl("lblCoScholasticArea");
            lnkEdit = (LinkButton)gvr.FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblCoScholasticID.Text + "@" + lblCoScholasticArea.Text;
            lnkDelete.CommandArgument = lblCoScholasticID.Text + "@" + lblCoScholasticArea.Text ;

            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    protected void gdvCoScholastic_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtCoScholastic.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnCasteID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnCasteID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteCoScholasticArea(Convert.ToInt32(hdnCasteID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtCoScholastic.Text + "   Deleted Successfully";
                txtCoScholastic.Text = "";
                bindCoScholastic();
            }
            btnAdd.Text = "Add";
        }
    }
}
