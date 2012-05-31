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
public partial class Admin_LibSubCategory : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.LibraryBL objLibrary = new LibraryBL();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        //ddlLibSubCategory.Attributes.Add("onchange", "javascript:return Show();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            ds = objLibrary.GetLibBookCategory();
            ddlLibSubCategory.DataSource = ds.Tables[0];
            ddlLibSubCategory.DataTextField = "Category";
            ddlLibSubCategory.DataValueField = "CategoryID";
            ddlLibSubCategory.DataBind();
            ddlLibSubCategory.Items.Insert(0, new ListItem("---Select---", "0"));
            bindLibSubCategory();
        }
       

    }
    public void bindLibSubCategory()
    {
        ds = new DataSet();
        ds = objLibrary.GetLibBookSubCategory(0);
        gdvLibSubCategory.DataSource = ds.Tables[0];
        gdvLibSubCategory.DataBind();
    }

   
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objLibrary.AddLibBookSubCategory(txtLibSubCategory.Text,txtSCNo.Text, Convert.ToInt32(Convert.ToInt32(ddlLibSubCategory.Items[ddlLibSubCategory.SelectedIndex].Value)));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtLibSubCategory.Text + "  Sub Category Added Successfully";
                txtLibSubCategory.Text = "";
                txtSCNo.Text = "";
                ddlLibSubCategory.SelectedValue = "0"; 
                bindLibSubCategory();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtLibSubCategory.Text + "  Sub Category Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objLibrary.EditLibBookSubCategory(Convert.ToInt32(hdnLibSubCategoryID.Value), txtLibSubCategory.Text, txtSCNo.Text, Convert.ToInt32(ddlLibSubCategory.Items[ddlLibSubCategory.SelectedIndex].Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtLibSubCategory.Text + "  Sub Category Modified Successfully";
                txtLibSubCategory.Text = "";
                txtSCNo.Text = "";
                ddlLibSubCategory.SelectedValue = "0"; 
                btnAdd.Text = "Add";
                bindLibSubCategory();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtLibSubCategory.Text + "  Sub Category Already Exists";

            }
        }
    }

    protected void gdvLibSubCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtLibSubCategory.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnLibSubCategoryID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            ddlLibSubCategory.SelectedValue = e.CommandArgument.ToString().Split('@')[3].ToString();
            txtSCNo.Text = e.CommandArgument.ToString().Split('@')[2].ToString();
            btnAdd.Text = "Update";

        }
       
        if (e.CommandName == "del")
        {
            hdnLibSubCategoryID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objLibrary.DeleteLibBookSubCategory(Convert.ToInt32(hdnLibSubCategoryID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtLibSubCategory.Text + "  Sub Category Deleted Successfully";
                txtLibSubCategory.Text = "";
                txtSCNo.Text = "";
                ddlLibSubCategory.SelectedValue = "0"; 
                bindLibSubCategory();
            }
            btnAdd.Text = "Add";
        }
    }
    protected void gdvLibSubCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvLibSubCategory.Rows)
        {
            Label lblSubCategoryID = new Label();
            Label lblSubCategory = new Label();
            Label lblSubCategoryNumber = new Label();
            Label lblCategoryId = new Label();
            
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblSubCategoryID = (Label)gvr.Cells[0].FindControl("lblSubCategoryID");
            lblSubCategory = (Label)gvr.Cells[1].FindControl("lblSubCategory");
            lblSubCategoryNumber = (Label)gvr.Cells[2].FindControl("lblSubCategoryNumber");
            lblCategoryId = (Label)gvr.Cells[4].FindControl("lblCategoryId");
            lnkEdit = (LinkButton)gvr.Cells[5].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[6].FindControl("lnkDelete");
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");

            lnkEdit.CommandArgument = lblSubCategoryID.Text + "@" + lblSubCategory.Text + "@" + lblSubCategoryNumber.Text+ "@" + lblCategoryId.Text;
            lnkDelete.CommandArgument = lblSubCategoryID.Text + "@" + lblSubCategory.Text + "@" + lblSubCategoryNumber.Text + "@" + lblCategoryId.Text;

        }
    }
    protected void gdvLibSubCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvLibSubCategory.PageIndex = e.NewPageIndex;
        bindLibSubCategory();
    }
}
