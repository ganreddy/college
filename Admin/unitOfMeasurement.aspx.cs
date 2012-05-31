using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BusinessLayer;

public partial class Admin_unitOfMeasurement : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        if (!IsPostBack)
        {
            bindMeasurement();
        }
    }
    public void bindMeasurement()
    {
        ds = new DataSet();
        ds = objcomm.GetUnitOfMeasurement();
        gdvUnit.DataSource = ds.Tables[0];
        gdvUnit.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {
            i = objcomm.AddUnitOfMeasurement(txtUnit.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtUnit.Text + "  Measurement added Successfully";
                txtUnit.Text = "";
                bindMeasurement();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtUnit.Text + "  Measurement already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objcomm.EditUnitOfMeasurement(Convert.ToInt32(hdnUomID.Value), txtUnit.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtUnit.Text + "  Measurement Modified Successfully";
                txtUnit.Text = "";
                btnAdd.Text = "Add";
                bindMeasurement();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtUnit.Text + "  Measurement already Exists";

            }
        }
    }
    protected void gdvUnit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvUnit.Rows)
        {
            Label lblUomId = new Label();
            Label lblUom = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblUomId = (Label)gvr.Cells[0].FindControl("lblUomId");
            lblUom = (Label)gvr.Cells[1].FindControl("lblUom");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblUomId.Text + "@" + lblUom.Text;
            lnkDelete.CommandArgument = lblUomId.Text + "@" + lblUom.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    protected void gdvUnit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtUnit.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnUomID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnUomID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objcomm.DeleteUnitMeasurement(Convert.ToInt32(hdnUomID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtUnit.Text + "  Measurement Deleted Successfully";
                txtUnit.Text = "";
                bindMeasurement();
            }
            btnAdd.Text = "Add";
        }
    }
    protected void gdvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvUnit.PageIndex = e.NewPageIndex;
        bindMeasurement();
    }
}
