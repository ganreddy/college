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

public partial class Admin_DefineMotherTounge : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindMotherTounge();
        }

    }
    public void bindMotherTounge()
    {
        ds = new DataSet();
        ds = objcomm.GetMotherTounge();
       gdvMotherTounge.DataSource = ds.Tables[0];
        gdvMotherTounge.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objcomm.AddMotherTounge(txtLanguage.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtLanguage.Text + "  Language Added Successfully";
                txtLanguage.Text = "";
                bindMotherTounge();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtLanguage.Text + "  Language Already Exists";

            }
        }
            if (btnAdd.Text == "Update")
            {
                i = objcomm.EditMotherTounge(Convert.ToInt32(hdnMotherID.Value), txtLanguage.Text);
                if (i > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtLanguage.Text + "  Language Modified Successfully";
                    txtLanguage.Text = "";
                    btnAdd.Text = "Add";
                    bindMotherTounge();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtLanguage.Text + "  Language Already Exists";

                }
            }

        
    }
    
    protected void gdvMotherTounge_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtLanguage.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnMotherID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";

        }
        if (e.CommandName == "del")
        {
            hdnMotherID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objcomm.DeleteMotherTounge(Convert.ToInt32(hdnMotherID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtLanguage.Text + " Language Deleted Successfully";
                txtLanguage.Text = "";
                bindMotherTounge();
            }
            btnAdd.Text = "Add";
        }


    }
    protected void gdvMotherTounge_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvMotherTounge.Rows)
        {
            Label lblMTID = new Label();
            Label lblLanguage = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblMTID = (Label)gvr.Cells[0].FindControl("lblMTID");
            lblLanguage = (Label)gvr.Cells[1].FindControl("lblLanguage");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblMTID.Text + "@" + lblLanguage.Text;
            lnkDelete.CommandArgument = lblMTID.Text + "@" + lblLanguage.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }

    }
}
