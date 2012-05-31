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
using BusinessLayer;

public partial class Admin_DefineAccSubHeads : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            ds = objComm.GetAccountHead(0);
            ddlHeads.DataSource = ds.Tables[0];
            ddlHeads.DataTextField = "HeadName";
            ddlHeads.DataValueField = "HeadID";
            ddlHeads.DataBind();
            ddlHeads.Items.Insert(0, new ListItem("---Select---", "0"));
            bindAccountSubHead();
        }
    }
    public void bindAccountSubHead()
    {
        ds = new DataSet();
        ds = objComm.GetAccountSubHead(0);
        gdvAccountSubHead.DataSource = ds.Tables[0];
        gdvAccountSubHead.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objComm.AddAccountSubHead(Convert.ToInt32(ddlHeads.Items[ddlHeads.SelectedIndex].Value), txtSubHead.Text, Convert.ToDecimal(txtFundAmnt.Text));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSubHead.Text + "  Account SubHead Added Successfully";
                txtSubHead.Text = "";
                txtFundAmnt.Text = "";
                ddlHeads.SelectedIndex = 0;
                bindAccountSubHead();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSubHead.Text + "  Account SubHead Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditAccountSubHead(Convert.ToInt32(hdnSubAccountHeadID.Value), txtSubHead.Text, Convert.ToInt32(ddlHeads.Items[ddlHeads.SelectedIndex].Value), Convert.ToDecimal(txtFundAmnt.Text));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSubHead.Text + "  Account SubHead Modified Successfully";
                txtSubHead.Text = "";
                ddlHeads.SelectedIndex = 0;
                txtFundAmnt.Text = "";
                btnAdd.Text = "Add";
                bindAccountSubHead();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSubHead.Text + "  Account SubHead Already Exists";

            }
        }
    }


    protected void gdvAccountSubHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvAccountSubHead.Rows)
        {
            Label lblSubHeadID = new Label();
            Label lblSubHeadName = new Label();
            Label lblHeadID = new Label();
            Label lblFundAmt = new Label();
            Label lblHead = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblSubHeadID = (Label)gvr.Cells[0].FindControl("lblSubHeadID");
            lblSubHeadName = (Label)gvr.Cells[1].FindControl("lblSubHeadName");
           
            lblHeadID = (Label)gvr.Cells[2].FindControl("lblHeadID");
            lblFundAmt = (Label)gvr.Cells[3].FindControl("lblFundAmt");
            lblHead = (Label)gvr.Cells[4].FindControl("lblHead");
            lnkEdit = (LinkButton)gvr.Cells[5].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[6].FindControl("lnkDelete");
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");

            lnkEdit.CommandArgument = lblSubHeadID.Text + "@" + lblSubHeadName.Text + "@" + lblHeadID.Text + "@" + lblFundAmt.Text + "@" + lblHead.Text;
            lnkDelete.CommandArgument = lblSubHeadID.Text + "@" + lblSubHeadName.Text + "@" + lblHeadID.Text + "@" + lblFundAmt.Text + "@" + lblHead.Text;

        }
    }
    protected void gdvAccountSubHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtSubHead.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnSubAccountHeadID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            ddlHeads.SelectedValue = e.CommandArgument.ToString().Split('@')[4].ToString();
            ddlHeads.SelectedItem.Text = e.CommandArgument.ToString().Split('@')[2].ToString();
            txtFundAmnt.Text = e.CommandArgument.ToString().Split('@')[3].ToString();
            hdnSubAccountHead.Value = e.CommandArgument.ToString().Split('@')[4].ToString();
            btnAdd.Text = "Update";

        }
        if (e.CommandName == "del")
        {
            hdnSubAccountHeadID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteAccountSubHead(Convert.ToInt32(hdnSubAccountHeadID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtSubHead.Text + "  Account SubHead Deleted Successfully";
                txtSubHead.Text = "";
                ddlHeads.SelectedIndex = 0;
                txtFundAmnt.Text = "";
                bindAccountSubHead();
            }
            btnAdd.Text = "Add";
        }
    }
    protected void gdvAccountSubHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvAccountSubHead.PageIndex = e.NewPageIndex;
        bindAccountSubHead();
    }
}
