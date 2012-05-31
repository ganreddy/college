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

public partial class Accounts_AccBudgetAlloc : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {  
            bindBudgetAllocation();
            for (int i = 2009; i < 2050; i++)
            {
                ddlFinancialYear.Items.Add(new ListItem(i.ToString()+"-"+Convert.ToString(Convert.ToInt32(i.ToString().Substring(2,2))+1),i.ToString()));
            }
           
        }
    }
    public void bindBudgetAllocation()
    {
        ds = new DataSet();
        ds = objComm.GetBudgetAllocation();
        gdvBudgetAllocation.DataSource = ds.Tables[0];
        gdvBudgetAllocation.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       int i = 0;
       if (btnSave.Text == "Save")
        {

            i = objComm.AddBudgetAllocation(Convert.ToInt32(ddlFinancialYear.Items[ddlFinancialYear.SelectedIndex].Value), Convert.ToInt32(txtBudget.Text), Convert.ToInt32(txtImprest.Text));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text =  "  Budget Allocation Added Successfully";
                bindBudgetAllocation();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "  Budget Allocation Already Exists";

            }
        }
       if (btnSave.Text == "Update")
        {
            i = objComm.EditBudgetAllocation(Convert.ToInt32(hdnBudgetAllocation.Value), Convert.ToInt32(ddlFinancialYear.Items[ddlFinancialYear.SelectedIndex].Value), Convert.ToDecimal(txtBudget.Text),Convert.ToDecimal(txtImprest.Text));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "  Budget Allocation Modified Successfully";
                btnSave.Text = "Add";
                bindBudgetAllocation();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "  Budget Allocation Already Exists";

            }
        }
    }
    protected void gdvBudgetAllocation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtBudget.Text = e.CommandArgument.ToString().Split('@')[2].ToString();
            hdnBudgetAllocation.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            ddlFinancialYear.SelectedValue = e.CommandArgument.ToString().Split('@')[1].ToString();
            txtImprest.Text = e.CommandArgument.ToString().Split('@')[3].ToString();
            btnSave.Text = "Update";

        }
        if (e.CommandName == "del")
        {
            hdnBudgetAllocation.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteBudgetAllocation(Convert.ToInt32(hdnBudgetAllocation.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "  Budget Allocation Deleted Successfully"; 
                bindBudgetAllocation();
            }
            btnSave.Text = "Add";
        }
    }
    protected void gdvBudgetAllocation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvBudgetAllocation.Rows)
        {
            Label lblYearID = new Label();
            Label lblFinancialYear = new Label();
            Label lblBudgetAmount = new Label();
            Label lblImprest = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblYearID = (Label)gvr.Cells[0].FindControl("lblYearID");
            lblFinancialYear = (Label)gvr.Cells[1].FindControl("lblFinancialYear");
            lblBudgetAmount = (Label)gvr.Cells[2].FindControl("lblBudgetAmount");
            lblImprest = (Label)gvr.Cells[3].FindControl("lblImprest");
            lnkEdit = (LinkButton)gvr.Cells[4].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[5].FindControl("lnkDelete");
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");

            lnkEdit.CommandArgument = lblYearID.Text + "@" + lblFinancialYear.Text + "@" + lblBudgetAmount.Text + "@" + lblImprest.Text ;
            lnkDelete.CommandArgument = lblYearID.Text + "@" + lblFinancialYear.Text + "@" + lblBudgetAmount.Text + "@" + lblImprest.Text;

        }
    }
}
