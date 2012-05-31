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


public partial class DefineLoans : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
 protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");

        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindStaffLoanMaster();
        }
    }
    public void bindStaffLoanMaster()
    {
        ds = new DataSet();
        ds = objComm.GetStaffLoansMaster();
        gdvStaffLoanMaster.DataSource = ds.Tables[0];
        gdvStaffLoanMaster.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
{
        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objComm.AddStaffLoansMaster(txtName.Text,Convert.ToInt32(txtMaxAmount.Text), Convert.ToInt32(txtMaxNoofInstallments.Text),txtRemarks.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtName.Text + " Loan Added Successfully";
                txtName.Text = "";
                txtMaxAmount.Text = "";
                txtMaxAmount.Text="";
                txtRemarks.Text="";
                bindStaffLoanMaster();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtName.Text + "  Loan Name Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditStaffLoansMaster(Convert.ToInt32(hdnStaffLoanId.Value), txtName.Text,Convert.ToInt32(txtMaxAmount.Text),Convert.ToInt32(txtMaxNoofInstallments.Text),txtRemarks.Text);
                
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtName.Text + "  Loan Name  Modified Successfully";
                txtMaxAmount.Text = "";
                txtRemarks.Text = "";


                btnAdd.Text = "Add";
                bindStaffLoanMaster();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtName.Text + "  Loan Name Already Exists";

            }
        }
}

protected void  gdvStaffLoanMaster_RowCommand(object sender, GridViewCommandEventArgs e)
{
       // int i = 0;
        if (e.CommandName == "editing")
        {
            hdnStaffLoanId.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            txtName.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            txtMaxAmount.Text = e.CommandArgument.ToString().Split('@')[2].ToString();
            txtMaxNoofInstallments.Text = e.CommandArgument.ToString().Split('@')[3].ToString();
            txtRemarks.Text = e.CommandArgument.ToString().Split('@')[4].ToString();
            
           btnAdd.Text = "Update";
        }

}
    protected void  gdvStaffLoanMaster_RowDataBound(object sender, GridViewRowEventArgs e)
{
    foreach (GridViewRow gvr in gdvStaffLoanMaster.Rows)
    {
        Label lblLoanId = new Label();
        Label lblLoanName = new Label();
        Label lblMaxAmount = new Label();
        Label lblMaxNoofinstallments = new Label();
        Label lblRemarks = new Label();
        LinkButton lnkEdit = new LinkButton();
        LinkButton lnkDelete = new LinkButton();

        lblLoanId = (Label)gvr.Cells[0].FindControl("lblLoanId");
        lblLoanName = (Label)gvr.Cells[1].FindControl("lblLoanName");
        lblMaxAmount = (Label)gvr.Cells[2].FindControl("lblMaxAmount");
        lblMaxNoofinstallments = (Label)gvr.Cells[3].FindControl("lblMaxNoofinstallments");
        lblRemarks = (Label)gvr.Cells[4].FindControl("lblRemarks");
        lnkEdit = (LinkButton)gvr.Cells[5].FindControl("lnkEdit");
       
        lnkEdit.CommandArgument = lblLoanId.Text + "@" + lblLoanName.Text + "@"+ lblMaxAmount.Text + "@" + lblMaxNoofinstallments.Text + "@" + lblRemarks.Text;
      

       
    }
}

    
}