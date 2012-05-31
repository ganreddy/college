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

public partial class DefineMessDish : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.MessBL objMess = new MessBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            ds = objMess.GetMealType();
            ddlMeal.DataSource = ds.Tables[0];
            ddlMeal.DataTextField = "MealType";
            ddlMeal.DataValueField = "MealID";
            ddlMeal.DataBind();
            ddlMeal.Items.Insert(0, new ListItem("---Select---", "0"));
            bindMessDish();

               
        }


    }
        public void bindMessDish()
    {
        ds = new DataSet();
        ds = objMess.GetMessDish();     
        gdvMessDish.DataSource = ds.Tables[0];
        gdvMessDish.DataBind();
    }
  
     
protected void  btnAdd_Click(object sender, EventArgs e)
 {
        

        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objMess.AddMessDish(txtDishName.Text, Convert.ToInt32(ddlMeal.Items[ddlMeal.SelectedIndex].Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtDishName.Text + "  DishName added Successfully";
                txtDishName.Text = "";
                bindMessDish();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtDishName.Text + "  DishName already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objMess.EditMessDish(Convert.ToInt32(hdnMessDish.Value), txtDishName.Text, Convert.ToInt32(ddlMeal.Items[ddlMeal.SelectedIndex].Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtDishName.Text + "  DishName Modified Successfully";
                txtDishName.Text = "";
                btnAdd.Text = "Add";
                bindMessDish();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtDishName.Text + "  DishName already Exists";

            }
        }


    }
    
  protected void  gdvMessDish_RowDataBound(object sender, GridViewRowEventArgs e)
{
      foreach (GridViewRow gvr in  gdvMessDish.Rows)
        {
            Label lblDishID = new Label();
            Label lblDishName = new Label();
            Label lblMealType = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblDishID = (Label)gvr.Cells[0].FindControl("lblDishID");
            lblDishName = (Label)gvr.Cells[1].FindControl("lblDishName");
            lblMealType = (Label)gvr.Cells[2].FindControl("lblMealType");
            lnkEdit = (LinkButton)gvr.Cells[3].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[4].FindControl("lnkDelete");
           lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
           if (lblMealType.Text == "1") lblMealType.Text = "Morning Snacks";
           if (lblMealType.Text == "2") lblMealType.Text = "Breakfast";
           if (lblMealType.Text == "3") lblMealType.Text = "Lunch";
           if (lblMealType.Text == "4") lblMealType.Text = "Evenin Snacks";
           if (lblMealType.Text == "5") lblMealType.Text = "Dinner";

            
            lnkEdit.CommandArgument = lblDishID.Text + "@" + lblDishName.Text + "@" + lblMealType.Text;
            lnkDelete.CommandArgument = lblDishID.Text + "@" + lblDishName.Text + "@" + lblMealType.Text;
            
        }


}
protected void  gdvMessDish_RowCommand(object sender, GridViewCommandEventArgs e)
  {
      int i = 0;
      if (e.CommandName == "editing")
      {
          txtDishName.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
          hdnMessDish.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
          if (e.CommandArgument.ToString().Split('@')[2].ToString() == "Morning Snacks")
              ddlMeal.SelectedIndex = 1;
          if (e.CommandArgument.ToString().Split('@')[2].ToString() == "Breakfast")
              ddlMeal.SelectedIndex = 2;
          if (e.CommandArgument.ToString().Split('@')[2].ToString() == "Lunch")
              ddlMeal.SelectedIndex = 3;
          if (e.CommandArgument.ToString().Split('@')[2].ToString() == "Evenin Snacks")
              ddlMeal.SelectedIndex = 4;
          if (e.CommandArgument.ToString().Split('@')[2].ToString() == "Dinner")
              ddlMeal.SelectedIndex = 5;
          btnAdd.Text = "Update";

      }
      if (e.CommandName == "del")
      {
          hdnMessDish.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
          i = objMess.DeleteMessDish(Convert.ToInt32(hdnMessDish.Value));
          if (i > 0)
          {
              lblMessage.Visible = true;
              lblMessage.Text = txtDishName.Text + "  DishName Deleted Successfully";
              txtDishName.Text = "";
              bindMessDish();
          }
          btnAdd.Text = "Add";
      }
  }



protected void gdvMessDish_PageIndexChanging1(object sender, GridViewPageEventArgs e)
{
    gdvMessDish.PageIndex = e.NewPageIndex;
    bindMessDish();
}
}
