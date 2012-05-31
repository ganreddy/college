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


public partial class DefineStaffSal : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();


    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindSalary();
        }
    }
        public void bindSalary()
    {
        ds = new DataSet();
        ds = objcomm.GetSalary();
        gdvSalary.DataSource = ds.Tables[0];
        gdvSalary.DataBind();
    }
        protected void btnAdd_Click(object sender, EventArgs e)
         {

        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objcomm.AddSalary(txtnameoffield.Text, Convert.ToInt32(ddlType.Items[ddlType.SelectedIndex].Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtnameoffield.Text + "  Field Added Successfully";
                txtnameoffield.Text = "";
                bindSalary();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtnameoffield.Text + "  Field Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objcomm.EditSalary(Convert.ToInt32(hdnSalaryID.Value), txtnameoffield.Text, Convert.ToInt32(ddlType.Items[ddlType.SelectedIndex].Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtnameoffield.Text + "  Field Modified Successfully";
                txtnameoffield.Text = "";
                btnAdd.Text = "Add";
                bindSalary();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtnameoffield.Text + "  Field Already Exists";

            }
        }


    }


    
   

protected void  gdvSalary_RowDataBound(object sender, GridViewRowEventArgs e)
{
        foreach (GridViewRow gvr in gdvSalary.Rows)
        {
            Label lblFieldId = new Label();
            Label lblNameOfTheField = new Label();
            Label lblType = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblFieldId = (Label)gvr.Cells[0].FindControl("lblFieldId");
            lblNameOfTheField = (Label)gvr.Cells[1].FindControl("lblNameOfTheField");
            lblType = (Label)gvr.Cells[2].FindControl("lblType");
            lnkEdit = (LinkButton)gvr.Cells[3].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[4].FindControl("lnkDelete");
           lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
            if (lblType.Text == "1") lblType.Text = "Addition";
            if (lblType.Text == "2") lblType.Text = "Deduction";
            lnkEdit.CommandArgument = lblFieldId.Text + "@" + lblNameOfTheField.Text + "@" + lblType.Text;
            lnkDelete.CommandArgument = lblFieldId.Text + "@" + lblNameOfTheField.Text + "@" + lblType.Text;
            
        }

    }
    
    protected void  gdvSalary_RowCommand(object sender, GridViewCommandEventArgs e)
{
    int i = 0;
    if (e.CommandName == "editing")
    {
        txtnameoffield.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
        hdnSalaryID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
        if (e.CommandArgument.ToString().Split('@')[2].ToString() == "Mess")
            ddlType.SelectedIndex = 2;
        if (e.CommandArgument.ToString().Split('@')[2].ToString() == "Store")
            ddlType.SelectedIndex = 1;
        btnAdd.Text = "Update";

    }
    if (e.CommandName == "del")
    {
        hdnSalaryID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
        i = objcomm.DeleteSalary(Convert.ToInt32(hdnSalaryID.Value));
        if (i > 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = txtnameoffield.Text + "  Field Type Deleted Successfully";
            txtnameoffield.Text = "";
            bindSalary();
        }
        btnAdd.Text = "Add";
    }
}

    protected void gdvSalary_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvSalary.PageIndex = e.NewPageIndex;
        bindSalary();
    }
}
