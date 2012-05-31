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

public partial class Admin_DefineNationality : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindNationality();
        }
    }
    public void bindNationality()
    {
        ds = new DataSet();
        ds = objComm.GetNationality();
        gdvNation.DataSource = ds.Tables[0];
        gdvNation.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objComm.AddNationality(txtNationality.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtNationality.Text + "   Added Successfully";
                txtNationality.Text = "";
                bindNationality();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtNationality.Text + "   Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditNationality(Convert.ToInt32(hdnNation.Value), txtNationality.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtNationality.Text + "  Modified Successfully";
                txtNationality.Text = "";
                btnAdd.Text = "Add";
                bindNationality();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtNationality.Text + " Already Exists";

            }
        }

    }
    protected void gdvNation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtNationality.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnNation.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnNation.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteNationality(Convert.ToInt32(hdnNation.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtNationality.Text + "  Deleted Successfully";
                txtNationality.Text = "";
                bindNationality();
            }
        }

    }
    protected void gdvNation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvNation.Rows)
        {
            Label lblNationalityID = new Label();
            Label lblNation = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblNationalityID = (Label)gvr.Cells[0].FindControl("lblNationalityID");
            lblNation = (Label)gvr.Cells[1].FindControl("lblNation");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblNationalityID.Text + "@" + lblNation.Text;
            lnkDelete.CommandArgument = lblNationalityID.Text + "@" + lblNation.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    

}
