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
public partial class Admin_DefineAccHeads : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = objComm.GetAccountFund();
            ddlFund.DataSource = ds.Tables[0];
            ddlFund.DataTextField = "FundName";
            ddlFund.DataValueField = "FundID";
            ddlFund.DataBind();
            ddlFund.Items.Insert(0, new ListItem("---Select---", "0"));
            bindAccountHead();
        }
    }
    public void bindAccountHead()
    {
        ds = new DataSet();
        ds = objComm.GetAccountHead(0);
        gdvAccountsHead.DataSource = ds.Tables[0];
        gdvAccountsHead.DataBind();
        
        //bindAccountHead();
        //gdvAccountsHead.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {
            i = objComm.AddAccountHead(Convert.ToInt32(ddlFund.Items[ddlFund.SelectedIndex].Value), txtHead.Text, Convert.ToDecimal(txtFundAmt.Text));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtHead.Text + " Account Head Added Successfully";
                txtHead.Text = "";
                ddlFund.SelectedIndex = 0;
                txtFundAmt.Text = "";
                bindAccountHead();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtHead.Text + "  Account Head Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditAccountHeads(Convert.ToInt32(hdnAccountHeadID.Value), Convert.ToInt32(ddlFund.Items[ddlFund.SelectedIndex].Value), txtHead.Text, Convert.ToDecimal(txtFundAmt.Text));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtHead.Text + "  Account Head Modified Successfully";
                txtHead.Text = "";
                ddlFund.SelectedIndex = 0;
                txtFundAmt.Text = "";
                btnAdd.Text = "Add";
                bindAccountHead();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtHead.Text + "  Account Head Already Exists";
            }
        }
    }

    protected void gdvAccountsHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtHead.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnAccountHeadID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            ddlFund.SelectedItem.Text= e.CommandArgument.ToString().Split('@')[2].ToString();
            txtFundAmt.Text = e.CommandArgument.ToString().Split('@')[3].ToString();
            //hdnSubAccountHead.Value = e.CommandArgument.ToString().Split('@')[4].ToString();
            ddlFund.SelectedValue = e.CommandArgument.ToString().Split('@')[4].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnAccountHeadID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteAccountHead(Convert.ToInt32(hdnAccountHeadID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtHead.Text + "  Account Head Deleted Successfully";
                txtHead.Text = "";
                ddlFund.SelectedIndex = 0;
                txtFundAmt.Text = "";
                bindAccountHead();
            }
        }
    }

    protected void gdvAccountsHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvAccountsHead.Rows)
        {
            Label lblHeadID = new Label();
            Label lblHeadName = new Label();
            Label lblAccountFund = new Label();
            Label lblAmountFund = new Label();
            Label lblFundId = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblHeadID = (Label)gvr.Cells[0].FindControl("lblHeadID");
            lblHeadName = (Label)gvr.Cells[1].FindControl("lblHeadName");
            lblAccountFund = (Label)gvr.Cells[2].FindControl("lblAccountFund");
            lblAmountFund = (Label)gvr.Cells[3].FindControl("lblAmountFund");
            lblFundId = (Label)gvr.Cells[4].FindControl("lblFundId");
            lnkEdit = (LinkButton)gvr.Cells[4].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[5].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblHeadID.Text + "@" + lblHeadName.Text + "@" + lblAccountFund.Text + "@" + lblAmountFund.Text + "@" + lblFundId.Text;
            lnkDelete.CommandArgument = lblHeadID.Text + "@" + lblHeadName.Text + "@" + lblAccountFund.Text + "@" + lblAmountFund.Text + "@" + lblFundId.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    protected void gdvAccountsHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvAccountsHead.PageIndex = e.NewPageIndex;
        bindAccountHead();
    }
}
