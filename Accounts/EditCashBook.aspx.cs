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

public partial class Accounts_EditCashBook : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    AccountsBL objAcc = new AccountsBL();
    CommonDataBL objComm = new CommonDataBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnUpdate.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
           // txtDate.Text =ChangeDateFormat(DateTime.Today.ToShortDateString());
            txtDate.Text =DateTime.Today.ToString("dd/MM/yyyy");
            bindFund();
            bindHeads(0);
            bindSubHeads(0);
        }       

    }
    public void bindFund()
    {
        ds = objComm.GetAccFundsI();
        ddlFund.DataSource = ds.Tables[0];
        ddlFund.DataTextField = "FundName";
        ddlFund.DataValueField = "FundID";
        ddlFund.Items.Insert(0, new ListItem("---Select---", "0"));
        ddlFund.DataBind();
        
    }
    public void bindHeads(int i)
    {
        ds = objComm.GetAccountHead(i);
        ddlHead.DataSource = ds.Tables[0];
        ddlHead.DataTextField = "HeadName";
        ddlHead.DataValueField = "HeadID";
        ddlHead.DataBind();
        ddlHead.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    public void bindSubHeads(int i)
    {
        ds = objComm.GetAccountSubHead(i);
        ddlSubhead.DataSource = ds.Tables[0];
        ddlSubhead.DataTextField = "SubHeadName";
        ddlSubhead.DataValueField = "SubHeadID";
        ddlSubhead.DataBind();
        ddlSubhead.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    public void bindEditAccountCash()
    {
        ds = new DataSet();
        ds = objAcc.GetAccountCashBook(Convert.ToDateTime(ChangeDateFormat(txtDate.Text)));
        gdvEditCashBook.DataSource = ds.Tables[0];
        gdvEditCashBook.DataBind();
    }
    
    protected void Search_Click(object sender, EventArgs e)
    {
        gdvEditCashBook.Visible = true;
        bindEditAccountCash();
    }
    protected void gdvEditCashBook_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        if (e.CommandName == "editing")
        {
            lblMessage.Visible = false;
            btnUpdate.Visible = true;
            panel1.Visible = true;
            gdvEditCashBook.Visible = false;
            hdnEditAccountCashBook.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            txtVoucherNo.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
           // hdnFundType.Value = e.CommandArgument.ToString().Split('@')[2].ToString();
            ddlFund.SelectedValue = e.CommandArgument.ToString().Split('@')[2].ToString();
         //  hdnHead.Value = e.CommandArgument.ToString().Split('@')[4].ToString();
            ddlHead.SelectedValue = e.CommandArgument.ToString().Split('@')[4].ToString();
         //   hdnSubHead.Value = e.CommandArgument.ToString().Split('@')[6].ToString();
            ddlSubhead.SelectedValue = e.CommandArgument.ToString().Split('@')[6].ToString();
            if (e.CommandArgument.ToString().Split('@')[8].ToString() == "Reciept")
            {
                rdbReciept.Checked = true;
            }
            else if (e.CommandArgument.ToString().Split('@')[8].ToString() == "Payment")
            {
                rdbPayment.Checked = true;
            }
            if (e.CommandArgument.ToString().Split('@')[9].ToString() == "Planned")
            {
                rdbPlan.Checked = true;
            }
            else if (e.CommandArgument.ToString().Split('@')[9].ToString() == "NonPlanned")
            {
                rdbNPlan.Checked = true;
            }
            txtParticulars.Text = e.CommandArgument.ToString().Split('@')[10].ToString();
            txtLedgerFolio.Text = e.CommandArgument.ToString().Split('@')[11].ToString();
            if (e.CommandArgument.ToString().Split('@')[12].ToString() == "Bank")
            {
                rdbBank.Checked = true;
            }
            else if (e.CommandArgument.ToString().Split('@')[12].ToString() == "Imprest")
            {
                rdbImprest.Checked = true;
            }
            txtCash.Text = e.CommandArgument.ToString().Split('@')[13].ToString();
            txtRemarks.Text = e.CommandArgument.ToString().Split('@')[14].ToString(); 
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnUpdate.Text == "Update")
        {
            gdvEditCashBook.Visible = true;
            panel1.Visible = false;
            if (rdbReciept.Checked == true)
            {
                if (rdbPlan.Checked == true)
                {
                    if (rdbBank.Checked == true)
                    {  
                        i = objAcc.EditCashBookEntry(Convert.ToInt32(hdnEditAccountCashBook.Value), Convert.ToDateTime(ChangeDateFormat(txtDate.Text)), txtVoucherNo.Text, Convert.ToInt32(ddlFund.Items[ddlFund.SelectedIndex].Value), Convert.ToInt32(ddlHead.Items[ddlHead.SelectedIndex].Value), Convert.ToInt32(ddlSubhead.Items[ddlSubhead.SelectedIndex].Value), 1, 1, txtParticulars.Text, txtLedgerFolio.Text, 1, Convert.ToDecimal(txtCash.Text), txtRemarks.Text);   
                    }
                    
                }
            }
            if (rdbReciept.Checked == true)
            {
                if (rdbPlan.Checked == true)
                {
                    if (rdbImprest.Checked == true)
                    {
                        i = objAcc.EditCashBookEntry(Convert.ToInt32(hdnEditAccountCashBook.Value), Convert.ToDateTime(ChangeDateFormat(txtDate.Text)), txtVoucherNo.Text, Convert.ToInt32(ddlFund.Items[ddlFund.SelectedIndex].Value), Convert.ToInt32(ddlHead.Items[ddlHead.SelectedIndex].Value), Convert.ToInt32(ddlSubhead.Items[ddlSubhead.SelectedIndex].Value), 1, 1, txtParticulars.Text, txtLedgerFolio.Text, 2, Convert.ToDecimal(txtCash.Text), txtRemarks.Text);
                    }

                }
            }



            if (rdbReciept.Checked == true)
            {
                if (rdbNPlan.Checked == true)
                {
                    if (rdbBank.Checked == true)
                    {
                        i = objAcc.EditCashBookEntry(Convert.ToInt32(hdnEditAccountCashBook.Value), Convert.ToDateTime(ChangeDateFormat(txtDate.Text)), txtVoucherNo.Text, Convert.ToInt32(ddlFund.Items[ddlFund.SelectedIndex].Value), Convert.ToInt32(ddlHead.Items[ddlHead.SelectedIndex].Value), Convert.ToInt32(ddlSubhead.Items[ddlSubhead.SelectedIndex].Value), 1, 2, txtParticulars.Text, txtLedgerFolio.Text, 1, Convert.ToDecimal(txtCash.Text), txtRemarks.Text);
                    }
                }
            }
            if (rdbReciept.Checked == true)
            {
                if (rdbNPlan.Checked == true)
                {
                    if (rdbImprest.Checked == true)
                    {
                        i = objAcc.EditCashBookEntry(Convert.ToInt32(hdnEditAccountCashBook.Value), Convert.ToDateTime(ChangeDateFormat(txtDate.Text)), txtVoucherNo.Text, Convert.ToInt32(ddlFund.Items[ddlFund.SelectedIndex].Value), Convert.ToInt32(ddlHead.Items[ddlHead.SelectedIndex].Value), Convert.ToInt32(ddlSubhead.Items[ddlSubhead.SelectedIndex].Value), 1, 2, txtParticulars.Text, txtLedgerFolio.Text, 2, Convert.ToDecimal(txtCash.Text), txtRemarks.Text);
                    }
                }
            }


            if (rdbPayment.Checked == true)
            {
                if (rdbPlan.Checked == true)
                {
                    if (rdbBank.Checked == true)
                    {
                        i = objAcc.EditCashBookEntry(Convert.ToInt32(hdnEditAccountCashBook.Value), Convert.ToDateTime(ChangeDateFormat(txtDate.Text)), txtVoucherNo.Text, Convert.ToInt32(ddlFund.Items[ddlFund.SelectedIndex].Value), Convert.ToInt32(ddlHead.Items[ddlHead.SelectedIndex].Value), Convert.ToInt32(ddlSubhead.Items[ddlSubhead.SelectedIndex].Value), 2, 1, txtParticulars.Text, txtLedgerFolio.Text, 1, Convert.ToDecimal(txtCash.Text), txtRemarks.Text);
                    }
                }
            }
            if (rdbPayment.Checked == true)
            {
                if (rdbPlan.Checked == true)
                {
                    if (rdbImprest.Checked == true)
                    {
                        i = objAcc.EditCashBookEntry(Convert.ToInt32(hdnEditAccountCashBook.Value), Convert.ToDateTime(ChangeDateFormat(txtDate.Text)), txtVoucherNo.Text, Convert.ToInt32(ddlFund.Items[ddlFund.SelectedIndex].Value), Convert.ToInt32(ddlHead.Items[ddlHead.SelectedIndex].Value), Convert.ToInt32(ddlSubhead.Items[ddlSubhead.SelectedIndex].Value), 2, 1, txtParticulars.Text, txtLedgerFolio.Text, 2, Convert.ToDecimal(txtCash.Text), txtRemarks.Text);
                    }
                }
            }

            if (rdbPayment.Checked == true)
            {
                if (rdbNPlan.Checked == true)
                {
                    if (rdbBank.Checked == true)
                    {
                        i = objAcc.EditCashBookEntry(Convert.ToInt32(hdnEditAccountCashBook.Value), Convert.ToDateTime(ChangeDateFormat(txtDate.Text)), txtVoucherNo.Text, Convert.ToInt32(ddlFund.Items[ddlFund.SelectedIndex].Value), Convert.ToInt32(ddlHead.Items[ddlHead.SelectedIndex].Value), Convert.ToInt32(ddlSubhead.Items[ddlSubhead.SelectedIndex].Value), 2, 2, txtParticulars.Text, txtLedgerFolio.Text, 1, Convert.ToDecimal(txtCash.Text), txtRemarks.Text);
                    }
                }
            }

            if (rdbPayment.Checked == true)
            {
                if (rdbNPlan.Checked == true)
                {
                    if (rdbImprest.Checked == true)
                    {
                        i = objAcc.EditCashBookEntry(Convert.ToInt32(hdnEditAccountCashBook.Value), Convert.ToDateTime(ChangeDateFormat(txtDate.Text)), txtVoucherNo.Text, Convert.ToInt32(ddlFund.Items[ddlFund.SelectedIndex].Value), Convert.ToInt32(ddlHead.Items[ddlHead.SelectedIndex].Value), Convert.ToInt32(ddlSubhead.Items[ddlSubhead.SelectedIndex].Value), 2, 2, txtParticulars.Text, txtLedgerFolio.Text, 2, Convert.ToDecimal(txtCash.Text), txtRemarks.Text);
                    }
                }
            }
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "  Account Cash Book Updated Successfully";
                txtVoucherNo.Text = "";
               // ddlFund.SelectedItem.Text = "";
              //  ddlHead.SelectedItem.Text = "";
              //  ddlSubhead.SelectedItem.Text = "";
                txtParticulars.Text = "";
                txtLedgerFolio.Text = "";
                txtCash.Text = "";
                txtRemarks.Text = "";
                btnUpdate.Visible = false;
                bindEditAccountCash();
                
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text =  "  Account Cash Book Updated Already Exists";

            }
        }
    }
    protected void gdvEditCashBook_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvEditCashBook.Rows)
        {
            Label lblTransactionID = new Label();
            Label lblVoucherNo = new Label();
            Label lblFundTypeID = new Label();
            Label lblFundType = new Label();
            Label lblHeadID = new Label();
            Label lblHead = new Label();
            Label lblSubHeadID = new Label();
            Label lblSubHead = new Label();
            Label lblTransactionType=new Label();
            Label lblPlanNonPlan = new Label();
            Label lblParticulars = new Label();
            Label lblLedgerFolio = new Label();
            Label lblCashType = new Label();
            Label lblCash = new Label();
            Label lblRemarks = new Label();
            LinkButton lnkEdit = new LinkButton();
           // LinkButton lnkDelete = new LinkButton();

            lblTransactionID = (Label)gvr.Cells[0].FindControl("lblTransactionID");
            lblVoucherNo = (Label)gvr.Cells[1].FindControl("lblVoucherNo");
            lblFundTypeID = (Label)gvr.Cells[2].FindControl("lblFundTypeID");
            lblFundType = (Label)gvr.Cells[2].FindControl("lblFundType");
            //lblFundType = (Label)gvr.Cells[2].FindControl("lblFundType");
            lblHeadID = (Label)gvr.Cells[4].FindControl("lblHeadID");
            lblHead = (Label)gvr.Cells[4].FindControl("lblHead");
            //lblHead = (Label)gvr.Cells[3].FindControl("lblHead");
            lblSubHeadID = (Label)gvr.Cells[6].FindControl("lblSubHeadID");
            lblSubHead = (Label)gvr.Cells[6].FindControl("lblSubHead");
            //lblSubHead = (Label)gvr.Cells[4].FindControl("lblSubHead");
            lblTransactionType=(Label)gvr.Cells[8].FindControl("lblTransactionType");
            lblPlanNonPlan = (Label)gvr.Cells[9].FindControl("lblPlanNonPlan");
            lblParticulars = (Label)gvr.Cells[10].FindControl("lblParticulars");
            lblLedgerFolio = (Label)gvr.Cells[11].FindControl("lblLedgerFolio");
            lblCashType = (Label)gvr.Cells[12].FindControl("lblCashType"); 
            lblCash = (Label)gvr.Cells[13].FindControl("lblCash");
            lblRemarks = (Label)gvr.Cells[14].FindControl("lblRemarks");
            lnkEdit = (LinkButton)gvr.Cells[15].FindControl("lnkEdit");
           // lnkDelete = (LinkButton)gvr.Cells[4].FindControl("lnkDelete");
            //lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");

            lnkEdit.CommandArgument = lblTransactionID.Text + "@" + lblVoucherNo.Text + "@" + lblFundTypeID.Text + "@" + lblFundType.Text + "@" + lblHeadID.Text + "@" + lblHead.Text  + "@" + lblSubHeadID.Text + "@" +lblSubHead.Text + "@" + lblTransactionType.Text + "@" + lblPlanNonPlan.Text + "@" + lblParticulars.Text + "@" + lblLedgerFolio.Text + "@" + lblCashType.Text + "@" + lblCash.Text + "@" + lblRemarks.Text;
           // lnkDelete.CommandArgument = lblSubHeadID.Text + "@" + lblSubHeadName.Text + "@" + lblHeadID.Text;
            if (lblTransactionType.Text == "1")
            { 
            lblTransactionType.Text="Reciept";
            }
            if (lblTransactionType.Text == "2")
            {
                lblTransactionType.Text = "Payment";
            }
            if (lblPlanNonPlan.Text == "1")
            {
                lblPlanNonPlan.Text = "Planned";
            }
            if (lblPlanNonPlan.Text == "2")
            {
                lblPlanNonPlan.Text = "NonPlanned";
            }
            if (lblCashType.Text == "1")
            {
                lblCashType.Text = "Bank";
            }
            if (lblCashType.Text == "2")
            {
                lblCashType.Text = "Imprest";
            }
            
        }
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void ddlFund_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindHeads(Convert.ToInt32(ddlFund.Items[ddlFund.SelectedIndex].Value));
    }
    protected void ddlHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindSubHeads(Convert.ToInt32(ddlHead.Items[ddlHead.SelectedIndex].Value));
    }
}
