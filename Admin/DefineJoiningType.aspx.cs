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

public partial class Admin_DefineJoiningType : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
       
        lblMessage.Attributes.Add("style","color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindJoiningType();
        }
    

    }
    public void bindJoiningType()
    {
        ds = new DataSet();
        ds = objcomm.GetJoiningType();
        gdvJoiningType.DataSource = ds.Tables[0];
        gdvJoiningType.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
       
        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objcomm.AddJoiningType(txtJoinType.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtJoinType.Text + "  Joining Type Added Successfully";
                txtJoinType.Text = "";
                bindJoiningType();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtJoinType.Text + "  Joining Type Already Exists";

            }
        }

        if (btnAdd.Text == "Update")
        {
            i = objcomm.EditJoiningType(Convert.ToInt32(hdnBatchID.Value), txtJoinType.Text);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtJoinType.Text + "  Joining Type Modified Successfully";
                txtJoinType.Text = "";
                btnAdd.Text = "Add";
                bindJoiningType();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtJoinType.Text + "  Joining Type Already Exists";

            }
        }

    }
    protected void gdvJoiningType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtJoinType.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnBatchID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";

        }
        if (e.CommandName == "del")
        {
            hdnBatchID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objcomm.DeleteJoiningType(Convert.ToInt32(hdnBatchID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtJoinType.Text + "  Joining Type Deleted Successfully";
                txtJoinType.Text = "";
                bindJoiningType();
            }
            btnAdd.Text = "Add";
        }

    }
    protected void gdvJoiningType_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gdvJoiningType.Rows)
        {
            Label lblJTID = new Label();
            Label lblJTName = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblJTID = (Label)gvr.Cells[0].FindControl("lblJTID");
            lblJTName = (Label)gvr.Cells[1].FindControl("lblJTName");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblJTID.Text + "@" + lblJTName.Text;
            lnkDelete.CommandArgument = lblJTID.Text + "@" + lblJTName.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
}
