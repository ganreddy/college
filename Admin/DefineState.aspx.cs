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

public partial class Admin_DefineState : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindState();
        }
       

    }
    public void bindState()
    {
        ds = new DataSet();
        ds = objcomm.GetState();
        gdvState.DataSource = ds.Tables[0];
        gdvState.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
      
            int i = 0;
            if (btnAdd.Text == "Add")
            {

                i = objcomm.AddState(txtState.Text);
                if (i > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtState.Text + "  State added Successfully";
                    txtState.Text = "";
                    bindState();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtState.Text + " State already Exists";

                }
            }
            if (btnAdd.Text == "Update")
            {
                i = objcomm.EditState(Convert.ToInt32(hdnStateID.Value), txtState.Text);
                if (i > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtState.Text + "  State Modified Successfully";
                    txtState.Text = "";
                    btnAdd.Text = "Add";
                    bindState();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = txtState.Text + "  State already Exists";

                }
            }


        }
  
    
    protected void gdvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtState.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnStateID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";

        }
        if (e.CommandName == "del")
        {
            hdnStateID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objcomm.DeleteState(Convert.ToInt32(hdnStateID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtState.Text + "  State Deleted Successfully";
                txtState.Text = "";
                btnAdd.Text = "Add";
                bindState();
            }
           
        }
    }

    protected void gdvState_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvState.Rows)
        {
            Label lblStateID = new Label();
            Label lblStateName = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblStateID = (Label)gvr.Cells[0].FindControl("lblStateID");
            lblStateName = (Label)gvr.Cells[1].FindControl("lblStateName");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblStateID.Text + "@" + lblStateName.Text;
            lnkDelete.CommandArgument = lblStateID.Text + "@" + lblStateName.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }

    }
    protected void gdvState_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvState.PageIndex = e.NewPageIndex;
        bindState();
    }
}
