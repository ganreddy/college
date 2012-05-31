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


public partial class DefineClass : System.Web.UI.Page
{


    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {

       btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindClass();
        }
        
    }

    public void bindClass()
    {
        ds = new DataSet();
        ds = objcomm.GetClasses();
        gdvClass.DataSource = ds.Tables[0];
        gdvClass.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {
            i = objcomm.AddClasses(txtClass.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtClass.Text + "  Class Added Successfully";
                txtClass.Text = "";
                bindClass();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtClass.Text + "  Class Already Exists";

            }
        }

        if (btnAdd.Text == "Update")
        {
            i = objcomm.EditClass(Convert.ToInt32(hdnClassID.Value),txtClass.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtClass.Text + "Class Updated Successfully";
                txtClass.Text = "";
                btnAdd.Text = "Add";
                bindClass();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtClass.Text + "  Class Already Exists";
            }
        }
    }




    protected void gdvClass_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtClass.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnClassID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnClassID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objcomm.DeleteClass(Convert.ToInt32(hdnClassID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtClass.Text + "  Class Deleted Successfully";
                txtClass.Text = "";
                bindClass();
            }
            
        }
    }


    protected void gdvClass_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvClass.Rows)
          {
              Label lblClassID = new Label();
              Label lblClassName = new Label();
              LinkButton lnkSelect = new LinkButton();
              LinkButton lnkEdit = new LinkButton();
              LinkButton lnkDelete = new LinkButton();
              lblClassID = (Label)gvr.Cells[0].FindControl("lblClassID");
              lblClassName = (Label)gvr.Cells[1].FindControl("lblClassName");
              lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
              lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
              lnkEdit.CommandArgument = lblClassID.Text + "@" + lblClassName.Text;
             lnkDelete.CommandArgument = lblClassID.Text + "@" + lblClassName.Text;
              lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");

          }
    }

}
