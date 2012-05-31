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

public partial class Admin_DefineReasion : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindReasion();
        }
    }
    public void bindReasion()
    {
        ds = new DataSet();
        ds = objComm.GetReasion();
        gdvReasion.DataSource = ds.Tables[0];
        gdvReasion.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    
    {
        int i = 0;
        //try
        //{
            if (btnAdd.Text == "Add")
            {

                i = objComm.AddReasion(txtReasion.Text);
                if (i > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtReasion.Text + "  Reason Added Successfully";
                    txtReasion.Text = "";
                    bindReasion();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtReasion.Text + "  Reason Already Exists";

                }
            }
        //}
        //catch (Exception Ex)
        //{
         //   ErrHandler.WriteError(Ex.Message);
       // }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditReasion(Convert.ToInt32(hdnBatchID.Value), txtReasion.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtReasion.Text + "  Reason Modified Successfully";
                txtReasion.Text = "";
                btnAdd.Text = "Add";
                bindReasion();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtReasion.Text + "  Reason Already Exists";

            }
        }
    }
    protected void gdvReasion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtReasion.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnBatchID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnBatchID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteReasion(Convert.ToInt32(hdnBatchID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtReasion.Text + "  Reason Deleted Successfully";
                txtReasion.Text = "";
                bindReasion();
            }
        }
    }
    protected void gdvReasion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvReasion.Rows)
        {
            Label lblReasionID = new Label();
            Label lblReasion = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblReasionID = (Label)gvr.Cells[0].FindControl("lblReasionID");
            lblReasion = (Label)gvr.Cells[1].FindControl("lblReasion");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblReasionID.Text + "@" + lblReasion.Text;
            lnkDelete.CommandArgument = lblReasionID.Text + "@" + lblReasion.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    protected void gdvReasion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvReasion.PageIndex = e.NewPageIndex;
        bindReasion();
    }
}
