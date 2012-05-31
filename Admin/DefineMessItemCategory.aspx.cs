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

public partial class DefineMessItemCategory : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    protected void Page_Load(object sender, EventArgs e)
    {
         
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        ddlCategory.Attributes.Add("onchange","javascript:return Show();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            ds = objcomm.GetUnitOfMeasurement();
            ddlUom.DataSource = ds.Tables[0];
            ddlUom.DataTextField = "UOMName";
            ddlUom.DataValueField = "UOMID";
            ddlUom.DataBind();
            ddlUom.Items.Insert(0, new ListItem("---Select---", "0"));
            bindItem();
        }
    }
    public void bindItem()
    {
        ds = new DataSet();
        ds = objcomm.GetItem();
        gdvItem.DataSource = ds.Tables[0];
        gdvItem.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        int i = 0;
        if (btnAdd.Text == "Add")
        {

            if (ddlCategory.Items[ddlCategory.SelectedIndex].Value == "1")
            {
                i = objcomm.AddItem(txtItemName.Text, Convert.ToInt32(ddlCategory.Items[ddlCategory.SelectedIndex].Value), Convert.ToInt32(ddlPeriod.Items[ddlPeriod.SelectedIndex].Value), Convert.ToInt32(ddlSubCat.Items[ddlSubCat.SelectedIndex].Value),Convert.ToInt32(ddlUom.Items[ddlUom.SelectedIndex].Value));
            }
            else
            {
                i = objcomm.AddItem(txtItemName.Text, Convert.ToInt32(ddlCategory.Items[ddlCategory.SelectedIndex].Value), 0, 0, Convert.ToInt32(ddlUom.Items[ddlUom.SelectedIndex].Value));
                
            }
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtItemName.Text + "  Item added Successfully";
                txtItemName.Text = "";
                ddlCategory.SelectedIndex = 0;
                ddlPeriod.SelectedIndex = 0;
                ddlSubCat.SelectedIndex = 0;
                ddlUom.SelectedIndex = 0;
                bindItem();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtItemName.Text + "  Item already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            if (ddlCategory.Items[ddlCategory.SelectedIndex].Value == "1")
            {
                i = objcomm.EditItem(Convert.ToInt32(hdnItemID.Value), txtItemName.Text, Convert.ToInt32(ddlCategory.Items[ddlCategory.SelectedIndex].Value), Convert.ToInt32(ddlPeriod.Items[ddlPeriod.SelectedIndex].Value), Convert.ToInt32(ddlSubCat.Items[ddlSubCat.SelectedIndex].Value),Convert.ToInt32(ddlUom.Items[ddlUom.SelectedIndex].Value));           
            }
            else
            {
                i = objcomm.EditItem(Convert.ToInt32(hdnItemID.Value), txtItemName.Text, Convert.ToInt32(ddlCategory.Items[ddlCategory.SelectedIndex].Value), 0, 0, Convert.ToInt32(ddlUom.Items[ddlUom.SelectedIndex].Value));           
            }
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtItemName.Text + "  Item Modified Successfully";
                txtItemName.Text = "";
                ddlCategory.SelectedIndex = 0;
                ddlPeriod.SelectedIndex = 0;
                ddlSubCat.SelectedIndex = 0;
                ddlUom.SelectedIndex = 0;
                btnAdd.Text = "Add";
                bindItem();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtItemName.Text + "  Item already Exists";

            }
        }


    }

    protected void gdvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvItem.Rows)
        {
            Label lblItemID = new Label();
            Label lblItemName = new Label();
            Label lblType = new Label();
            Label lblPeriod = new Label();
            Label lblSubCat = new Label();
            Label lblUOMID = new Label();

            Label lblUOM = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblItemID = (Label)gvr.Cells[0].FindControl("lblItemID");
            lblItemName = (Label)gvr.Cells[1].FindControl("lblItemName");
            lblType = (Label)gvr.Cells[2].FindControl("lblType");
            lblPeriod = (Label)gvr.Cells[3].FindControl("lblPeriod");
            lblSubCat = (Label)gvr.Cells[4].FindControl("lblSubCat");
            lblUOMID = (Label)gvr.Cells[6].FindControl("lblUOMID");
            lblUOM = (Label)gvr.Cells[6].FindControl("lblUOM");
            lnkEdit = (LinkButton)gvr.Cells[7].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[8].FindControl("lnkDelete");
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
            if (lblType.Text == "1") lblType.Text = "Store";
            if (lblType.Text == "2") lblType.Text = "Mess";
            if (lblPeriod.Text == "0") lblPeriod.Text = "NA";
            if (lblPeriod.Text == "1") lblPeriod.Text = "Daily";
            if (lblPeriod.Text == "2") lblPeriod.Text = "Monthly";
            if (lblPeriod.Text == "3") lblPeriod.Text = "Yearly";
            if (lblSubCat.Text == "0") lblSubCat.Text = "NA";
            if (lblSubCat.Text == "1") lblSubCat.Text = "Toileteries";
            if (lblSubCat.Text == "2") lblSubCat.Text = "Uniform";
            if (lblSubCat.Text == "3") lblSubCat.Text = "Stationary";
            lnkEdit.CommandArgument = lblItemID.Text + "@" + lblItemName.Text + "@" + lblType.Text + "@" + lblPeriod.Text + "@" + lblSubCat.Text + "@" + lblUOMID.Text + "@" +lblUOM.Text;
            lnkDelete.CommandArgument = lblItemID.Text + "@" + lblItemName.Text + "@" + lblType.Text + "@" + lblPeriod.Text + "@" + lblSubCat.Text + "@" + lblUOMID.Text + "@" + lblUOM.Text;
            
        }

    }
    protected void gdvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtItemName.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnItemID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            ddlUom.SelectedValue = e.CommandArgument.ToString().Split('@')[5].ToString();
            if (e.CommandArgument.ToString().Split('@')[2].ToString() == "Mess")
            {
                ddlCategory.SelectedIndex = 2;
                trPeriod.Style.Add("display", "hidden");
                trSubCat.Style.Add("display","hidden");
            }
            if (e.CommandArgument.ToString().Split('@')[2].ToString() == "Store")
            {
                ddlCategory.SelectedIndex = 1;
                trPeriod.Style.Add("display","inline");
                trSubCat.Style.Add("display", "inline");
                if (e.CommandArgument.ToString().Split('@')[3].ToString() == "Daily")
                    ddlPeriod.SelectedIndex = 1;
                if (e.CommandArgument.ToString().Split('@')[3].ToString() == "Monthly")
                    ddlPeriod.SelectedIndex = 2;
                if (e.CommandArgument.ToString().Split('@')[3].ToString() == "Yearly")
                    ddlPeriod.SelectedIndex = 3;
                if (e.CommandArgument.ToString().Split('@')[4].ToString() == "Toileteries")
                    ddlSubCat.SelectedIndex = 1;
                if (e.CommandArgument.ToString().Split('@')[4].ToString() == "Uniform")
                    ddlSubCat.SelectedIndex = 2;
                if (e.CommandArgument.ToString().Split('@')[4].ToString() == "Stationary")
                    ddlSubCat.SelectedIndex = 3;
               
            }
            btnAdd.Text = "Update";

        }
        if (e.CommandName == "del")
        {
            hdnItemID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objcomm.DeleteItem(Convert.ToInt32(hdnItemID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtItemName.Text + "  Item Type Deleted Successfully";
                txtItemName.Text = "";
                ddlCategory.SelectedIndex = 0;
                ddlPeriod.SelectedIndex = 0;
                ddlSubCat.SelectedIndex = 0;
                ddlUom.SelectedIndex = 0;
                bindItem();
            }
            btnAdd.Text = "Add";
        }
    }
    protected void gdvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvItem.PageIndex = e.NewPageIndex;
        bindItem();
    }
}
