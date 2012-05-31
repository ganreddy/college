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

public partial class Admin_DefineBookCategory : System.Web.UI.Page
{
    BusinessLayer.LibraryBL objLibrary = new LibraryBL();
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindBookCategory();
        }
    }

    public void bindBookCategory()
    {
        ds = new DataSet();
        ds = objLibrary.GetLibBookCategory();
        gdvBookCategory.DataSource = ds.Tables[0];
        gdvBookCategory.DataBind();
    }
    protected void  btnAdd_Click(object sender, EventArgs e)
{
        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objLibrary.AddLibBookCategory(txtCategory.Text, txtCategoryNumber.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtCategory.Text + "  Category Added Successfully";
                txtCategory.Text = "";
                txtCategoryNumber.Text = "";
                bindBookCategory();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtCategory.Text + "  Category or Category Number already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objLibrary.EditLibBookCategory(Convert.ToInt32(hdnBookCategory.Value), txtCategory.Text, txtCategoryNumber.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtCategory.Text + "  Category Or Category Number  Modified Successfully";

                txtCategory.Text = "";
                txtCategoryNumber.Text = "";
                btnAdd.Text = "Add";
                bindBookCategory();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtCategory.Text + "  Category Or Category Number  Already Exists";
                

            }
        }

    }
    protected void gdvBookCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtCategory.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            txtCategoryNumber.Text = e.CommandArgument.ToString().Split('@')[2].ToString();
            hdnBookCategory.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnBookCategory.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objLibrary.DeleteLibBookCategory(Convert.ToInt32(hdnBookCategory.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtCategory.Text + "Category Or Category Number Deleted Successfully";

                txtCategory.Text = "";
                txtCategoryNumber.Text = "";
                bindBookCategory();
            }
        }
    }
        
        protected void  gdvBookCategory_RowDataBound(object sender, GridViewRowEventArgs e)
 {
     foreach (GridViewRow gvr in gdvBookCategory.Rows)
        {
            Label lblCategoryID = new Label();
            Label lblCategory = new Label();
            Label lblCategoryNumber = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblCategoryID = (Label)gvr.Cells[0].FindControl("lblCategoryID");
            lblCategory = (Label)gvr.Cells[1].FindControl("lblCategory");
            lblCategoryNumber = (Label)gvr.Cells[2].FindControl("lblCategoryNumber");
            lnkEdit = (LinkButton)gvr.Cells[3].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[4].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblCategoryID.Text + "@" + lblCategory.Text + "@" + lblCategoryNumber.Text;
            lnkDelete.CommandArgument = lblCategoryID.Text + "@" + lblCategory.Text + "@" + lblCategoryNumber.Text;

            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }

        protected void gdvBookCategory_PageIndexChanged(object sender, EventArgs e)
        {


        }
        protected void gdvBookCategory_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
        }
        protected void gdvBookCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvBookCategory.PageIndex = e.NewPageIndex;
            bindBookCategory();
        }
}
