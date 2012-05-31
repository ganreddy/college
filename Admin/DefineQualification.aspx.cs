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

public partial class Admin_DefineQualification : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;fonr-weight:bold;");
        if (!IsPostBack)
        {
            bindQualification();
        }
    }
    public void bindQualification()
    {
        ds = new DataSet();
        ds = objcomm.GetQualification();
        gdvQualification.DataSource = ds.Tables[0];
        gdvQualification.DataBind();
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {
            i = objcomm.AddQualification(txtQual.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtQual.Text + "  Qualification Added Successfully";
                txtQual.Text = "";
                bindQualification();
            }
            else
            {
               lblMessage.Visible=true;
                lblMessage.Text=txtQual.Text + " Qualification Already Exists";
            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objcomm.EditQualification(Convert.ToInt32(hdnQualificationID.Value), txtQual.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtQual.Text + "  Qualification Updated Successfully";
                txtQual.Text = "";
                btnAdd.Text = "Add";
                bindQualification();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtQual.Text + " Qualification Already Exists";
            }
            
        }
    }


    protected void gdvQualification_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtQual.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnQualificationID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnQualificationID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objcomm.DeleteQualification(Convert.ToInt32(hdnQualificationID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtQual.Text + "  Qualification Deleted Successfully";
                txtQual.Text = "";
                bindQualification();
            }
        }


    }

    protected void gdvQualification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvQualification.Rows)
        {
            Label lblQualificationID = new Label();
            Label lblQualificationDetails = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();
            lblQualificationID = (Label)gvr.Cells[0].FindControl("lblQualificationID");
            lblQualificationDetails = (Label)gvr.Cells[1].FindControl("lblQualificationDetails");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblQualificationID.Text + "@" + lblQualificationDetails.Text;
            lnkDelete.CommandArgument = lblQualificationID.Text + "@" + lblQualificationDetails.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
}
