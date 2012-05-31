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
using System.Data.SqlClient;

public partial class Admin_DefineAccFunds : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindAccountFund();
        }

    }
    public void bindAccountFund()
    {
        ds = new DataSet();
        ds = objComm.GetAccFundsI();
        gdvAccountFund.DataSource = ds.Tables[0];
        gdvAccountFund.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        try
        {
            if (btnAdd.Text == "Add")
            {
                i = objComm.AddAccFundsI(txtFund.Text);
                if (i > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtFund.Text + "  AccountFund added Successfully";
                    txtFund.Text = "";
                    bindAccountFund();
                }

                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtFund.Text + "  AccountFund already Exists";

                }
            }
            if (btnAdd.Text == "Update")
            {
                i = objComm.EditAccFundsI(Convert.ToInt32(hdnAccountFundID.Value), txtFund.Text);
                if (i > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtFund.Text + "  AccountFund Modified Successfully";
                    txtFund.Text = "";
                    btnAdd.Text = "Add";
                    bindAccountFund();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtFund.Text + "  AccountFund already Exists";

                }
            }
        }
        catch (Exception Ex)
        {
            ErrHandler.WriteError(Ex.Message);
        }
        
    }
    protected void gdvAccountFund_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtFund.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnAccountFundID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnAccountFundID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteAccFundsI(Convert.ToInt32(hdnAccountFundID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtFund.Text + "  AccountFund Deleted Successfully";
                txtFund.Text = "";
                bindAccountFund();
            }
        }
    }
    protected void gdvAccountFund_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvAccountFund.Rows)
        {
            Label lblFundID = new Label();
            Label lblFundName = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblFundID = (Label)gvr.Cells[0].FindControl("lblFundID");
            lblFundName = (Label)gvr.Cells[1].FindControl("lblFundName");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblFundID.Text + "@" + lblFundName.Text;
            lnkDelete.CommandArgument = lblFundID.Text + "@" + lblFundName.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
}
