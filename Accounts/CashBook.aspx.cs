using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
public partial class Accounts_CashBook : System.Web.UI.Page
{
    CommonDataBL objComm = new CommonDataBL();
    DataSet ds = new DataSet();
    AccountsBL objAcc = new AccountsBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", "javascript:return validate();");
        txtCash.Attributes.Add("onkeyup", "javascript:return calc();");
        rdbReciept.Attributes.Add("onclick", "javascript:return calc();");
        rdbPayment.Attributes.Add("onclick", "javascript:return calc();");
        rdbBank.Attributes.Add("onclick", "javascript:return calc();");
        rdbImprest.Attributes.Add("onclick", "javascript:return calc();");

        if (!IsPostBack)
        {
            txtDate.Text = ChangeDateFormat(DateTime.Today.ToShortDateString());
            bindFund();
            bindHeads(0);
            bindSubHeads(0);
            bindOpeningBalance();
        }

    }
    public void bindOpeningBalance()
    {
        ds = objAcc.GetOpeningBalance(DateTime.Now.Year.ToString());
        if (ds.Tables.Count > 0)
        {
            lblBankOB.Text = ds.Tables[0].Rows[0][0].ToString();
            lblImprestOB.Text = ds.Tables[1].Rows[0][0].ToString();
            lblTotalOB.Text = Convert.ToString(Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString()) + Convert.ToDecimal(ds.Tables[1].Rows[0][0].ToString()));
            lblTotalOB.Style.Add("align", "right");
            lblBankOB.Style.Add("align", "right");
            lblImprestOB.Style.Add("align", "right");
            
        }
    }
    public void bindFund()
    {
        ds = objComm.GetAccFundsI();
        ddlFund.DataSource = ds.Tables[0];
        ddlFund.DataTextField = "FundName";
        ddlFund.DataValueField = "FundID";
        ddlFund.DataBind();
        ddlFund.Items.Insert(0, new ListItem("---Select---", "0"));
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
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DateTime date;
        string strVoucher = string.Empty, strParticulars = string.Empty,strLedger=string.Empty,strRemarks=string.Empty;
        int Fund = 0, Head = 0, SubHead = 0, TransType = 0, Plan = 0, CashType = 0;
        decimal Cash = 0;
        date = Convert.ToDateTime(ChangeDateFormat(txtDate.Text));
        strVoucher = txtVoucherNo.Text;
        strParticulars = txtParticulars.Text;
        strLedger = txtLedgerFolio.Text;
        strRemarks = txtRemarks.Text;
        Fund = Convert.ToInt32(ddlFund.Items[ddlFund.SelectedIndex].Value);
        Head = Convert.ToInt32(ddlHead.Items[ddlHead.SelectedIndex].Value);
        SubHead = Convert.ToInt32(ddlSubhead.Items[ddlSubhead.SelectedIndex].Value);
        if (rdbReciept.Checked) TransType = 1;
        if (rdbPayment.Checked) TransType = 2;
        if (rdbPlan.Checked) Plan = 1;
        if (rdbNPlan.Checked) Plan = 2;
        if (rdbBank.Checked) CashType = 1;
        if (rdbImprest.Checked) CashType = 2;
        Cash = Convert.ToDecimal(txtCash.Text);
        int i = objAcc.AddCashBookEntry(date,strVoucher,Fund,Head,SubHead,TransType,Plan,strParticulars,strLedger,CashType,Cash,strRemarks);
        if (i > 0)
        {
            lblMessage.Text = "Cash Book Entry Made Successfully";
            lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
            txtVoucherNo.Text = "";
            txtParticulars.Text = "";
            txtLedgerFolio.Text = "";
            txtRemarks.Text = "";
            ddlFund.SelectedIndex = 0;
            ddlHead.SelectedIndex = 0;
            ddlSubhead.SelectedIndex = 0;
            txtCash.Text = "";
            bindOpeningBalance();
        }
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
