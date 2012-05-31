using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BusinessLayer;

public partial class Admin_DefineStudentHouse : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindHouse();
        }
    }
    public void bindHouse() 
    {
        ds = new DataSet();
        ds = objComm.GetHouse();
        gdvHouse.DataSource = ds.Tables[0];
        gdvHouse.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {
            i = objComm.AddHouse(txtHouse.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtHouse.Text + " House Added Successfully ";
                txtHouse.Text = "";
                bindHouse();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtHouse.Text + " House Allready Exists ";
            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditHouse(Convert.ToInt32(hdnHouseID.Value), txtHouse.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = lblMessage.Text + "House Name Modified Successfully";
                txtHouse.Text = "";
                btnAdd.Text = "Add";
                bindHouse();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = lblMessage.Text + "House Allready Exists";
            }
        }
    }
    protected void gdvHouse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvHouse.Rows)
        {
            Label lblHouseID = new Label();
            Label lblHouseName = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblHouseID = (Label)gvr.Cells[0].FindControl("lblHouseID");
            lblHouseName = (Label)gvr.Cells[1].FindControl("lblHouseName");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblHouseID.Text + "@" + lblHouseName.Text;
            lnkDelete.CommandArgument = lblHouseID.Text + "@" + lblHouseName.Text;
        }
    }
    protected void gdvHouse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtHouse.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnHouseID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnHouseID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteHouse(Convert.ToInt32(hdnHouseID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = lblMessage.Text + "House Name Deleted successfully";
                txtHouse.Text = "";
                bindHouse();
            }
            btnAdd.Text = "Add";
        }
    }
}
