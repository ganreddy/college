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

public partial class Admin_DefineCaste : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
       lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindCaste();
        }
    }
    public void bindCaste()
    {
        ds = new DataSet();
        ds = objComm.GetCaste();
        gdvCaste.DataSource = ds.Tables[0];
        gdvCaste.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
         int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objComm.AddCaste(txtCaste.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtCaste.Text + "  Caste Added Successfully";
                txtCaste.Text = "";
                bindCaste();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtCaste.Text + "  Caste Already Exists";

            }
        }
         if (btnAdd.Text == "Update")
            {
                i = objComm.EditCaste(Convert.ToInt32(hdnCasteID.Value), txtCaste.Text);
                if (i > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtCaste.Text + "  Caste Modified Successfully";
                    txtCaste.Text = "";
                    btnAdd.Text = "Add";
                    bindCaste();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtCaste.Text + "  Caste Already Exists";

                }
            }
    }
           

        

    
    protected void gdvCaste_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvCaste.Rows)
        {
            Label lblCasteID = new Label();
            Label lblCaste = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblCasteID = (Label)gvr.Cells[0].FindControl("lblCasteID");
            lblCaste = (Label)gvr.Cells[1].FindControl("lblCaste");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblCasteID.Text + "@" + lblCaste.Text;
            lnkDelete.CommandArgument = lblCasteID.Text + "@" + lblCaste.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    protected void gdvCaste_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtCaste.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnCasteID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnCasteID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteCaste(Convert.ToInt32(hdnCasteID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtCaste.Text + "  Caste Deleted Successfully";
                txtCaste.Text = "";
                bindCaste();
            }
            btnAdd.Text = "Add";
        }
    }
}
