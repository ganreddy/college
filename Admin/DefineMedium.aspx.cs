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
public partial class Admin_DefineMedium : System.Web.UI.Page
{

    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
          {
              bindMedium();
          }
     
    }
    public void bindMedium()
    {
        ds = new DataSet();
        ds = objcomm.GetMedium();
        gdvMedium.DataSource = ds.Tables[0];
        gdvMedium.DataBind();
    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
           {
               i = objcomm.AddMedium(txtMedium.Text);
               if (i > 0)
               {
                   lblMessage.Visible = true;
                   lblMessage.Text = txtMedium.Text + "  Medium Added Successfully";
                   txtMedium.Text = "";
                   bindMedium();
               }
               else
               {
                   lblMessage.Visible = true;
                   lblMessage.Text = txtMedium.Text + "  Medium Already Exists";
               }
           }

        if (btnAdd.Text == "Update")
        {
            i = objcomm.EditMedium(Convert.ToInt32(hdnMediumID.Value), txtMedium.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtMedium.Text + "  Medium Updated Successfully";
                txtMedium.Text = "";
                btnAdd.Text = "Add";
                bindMedium();
            }
            else
              {
                  lblMessage.Visible = true;
                  lblMessage.Text = txtMedium.Text + "  Medium Already Exists";
              }
        }

    }


    protected void gdvMedium_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
          {
              txtMedium.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
              hdnMediumID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
              btnAdd.Text = "Update";
          }
        if (e.CommandName == "del")
          {
              hdnMediumID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
              i = objcomm.DeleteMedium(Convert.ToInt32(hdnMediumID.Value));
              if (i > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtMedium.Text + "  Medium Deleted Successfully";
                    txtMedium.Text = "";
                    bindMedium();
                }
          }
    }


    protected void gdvMedium_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvMedium.Rows)
         {
             Label lblMediumID = new Label();
             Label lblLanguage = new Label();
             LinkButton lnkEdit = new LinkButton();
             LinkButton lnkDelete = new LinkButton();
             lblMediumID = (Label)gvr.Cells[0].FindControl("lblMediumID");
             lblLanguage = (Label)gvr.Cells[1].FindControl("lblLanguage");
             lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
             lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
             lnkEdit.CommandArgument = lblMediumID.Text + "@" + lblLanguage.Text;
             lnkDelete.CommandArgument = lblMediumID.Text + "@" + lblLanguage.Text;
             lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");

         }
    }
}
