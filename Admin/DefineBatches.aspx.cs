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


public partial class DefineBatches : System.Web.UI.Page
{

    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style","color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindBatch();
        }
    }
    public void bindBatch()
    {
        ds = new DataSet();
        ds = objComm.GetBatch();
        gdvBatch.DataSource = ds.Tables[0];
        gdvBatch.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objComm.AddBatch(txtBatch.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtBatch.Text + "  Batch Added Successfully";
                txtBatch.Text = "";
                bindBatch();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtBatch.Text + "  Batch Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditBatch(Convert.ToInt32(hdnBatchID.Value), txtBatch.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtBatch.Text + "  Batch Modified Successfully";
                txtBatch.Text = "";
                btnAdd.Text = "Add";
                bindBatch();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtBatch.Text + "  Batch Already Exists";

            }
        }

    }
    protected void gdvBatch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtBatch.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnBatchID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnBatchID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteBatch(Convert.ToInt32(hdnBatchID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtBatch.Text + "  Batch Deleted Successfully";
                txtBatch.Text = "";
                bindBatch();
            }
        }

    }
    protected void gdvBatch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvBatch.Rows)
        {
            Label lblBatchID = new Label();
            Label lblBatchNo = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblBatchID = (Label)gvr.Cells[0].FindControl("lblBatchID");
            lblBatchNo = (Label)gvr.Cells[1].FindControl("lblBatchNo");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblBatchID.Text + "@" + lblBatchNo.Text;
            lnkDelete.CommandArgument = lblBatchID.Text + "@" + lblBatchNo.Text;
            lnkDelete.Attributes.Add("onclick","javascript:return Confirm();");
        }
    }

    protected void gdvBatch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvBatch.PageIndex = e.NewPageIndex;
        bindBatch();
    }
}
