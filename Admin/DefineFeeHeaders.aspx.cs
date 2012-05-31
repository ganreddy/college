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
public partial class Admin_DefineFeeHeaders : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        btnClear.Attributes.Add("onclick", "javascript:return Clear();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = objComm.GetFeeType(0);
            ddlFeeType.DataSource = ds.Tables[0];
            ddlFeeType.DataTextField = "FeeType";
            ddlFeeType.DataValueField = "FeeTypeID";
            ddlFeeType.DataBind();
            ddlFeeType.Items.Insert(0, new ListItem("---Select---", "0"));
            bindFeeHead(0);
        }
    }
    public void bindFeeHead(int FeeType)
    {
        ds = new DataSet();
        ds = objComm.GetFeeHeader(FeeType);
        gdvFeeHead.DataSource = ds.Tables[0];
        gdvFeeHead.DataBind();

       
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        string Msg, s = "";
       
      
        if (btnAdd.Text == "Add")
        {

            i = objComm.AddFeeHeader(Convert.ToInt32(ddlFeeType.Items[ddlFeeType.SelectedIndex].Value), txtHead.Text);
            if (i > 0)
            {
                //lblMessage.Visible = true;
                //lblMessage.Text = txtHead.Text + " Fee Head added Successfully";
                s = txtHead.Text + " Fee Header Added Successfully";
                txtHead.Text = "";
                ddlFeeType.SelectedIndex = 0;
                bindFeeHead(0);
            }
            else
            {
                //lblMessage.Visible = true;
                //lblMessage.Text = txtHead.Text + "  Fee Head already Exists";
                s = txtHead.Text + "  Fee Head Already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditFeeHeaders(Convert.ToInt32(hdnAccountHeadID.Value), Convert.ToInt32(ddlFeeType.Items[ddlFeeType.SelectedIndex].Value), txtHead.Text);
            if (i > 0)
            {
                //lblMessage.Visible = true;
                //lblMessage.Text = txtHead.Text + "  Fee Header Modified Successfully";
                s = txtHead.Text + "  Fee Header Modified Successfully";
                txtHead.Text = "";
                ddlFeeType.SelectedIndex = 0;
                btnAdd.Text = "Add";
                bindFeeHead(0);
            }
            else
            {
                //lblMessage.Visible = true;
                //lblMessage.Text = txtHead.Text + " Fee Header Already Exists";
                s = txtHead.Text + " Fee Header Already Exists";

            }
        }
        Msg = "alert('" + s + "');";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
    }

    protected void gdvFeeHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtHead.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnAccountHeadID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            ddlFeeType.SelectedValue = e.CommandArgument.ToString().Split('@')[2].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            txtHead.Text = e.CommandArgument.ToString().Split('@')[1].ToString();

            hdnAccountHeadID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteFeeHeader(Convert.ToInt32(hdnAccountHeadID.Value));
            if (i != 0)
            {
                //lblMessage.Visible = true;
                //lblMessage.Text = txtHead.Text + "  Fee Header Deleted Successfully";
                string Msg, s;
                s = txtHead.Text + "  Fee Header Deleted Successfully";
                Msg = "alert('" + s + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                txtHead.Text = "";
                ddlFeeType.SelectedIndex = 0;
                bindFeeHead(0);
            }
        }
    }

    protected void gdvFeeHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvFeeHead.Rows)
        {
            Label lblHeadID = new Label();
            Label lblHeaderName = new Label();
            Label lblFeeTypeID = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblHeadID = (Label)gvr.Cells[0].FindControl("lblHeadID");
            lblHeaderName = (Label)gvr.Cells[1].FindControl("lblHeaderName");
            lblFeeTypeID = (Label)gvr.Cells[5].FindControl("lblFeeTypeID");


            lnkEdit = (LinkButton)gvr.Cells[3].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[4].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblHeadID.Text + "@" + lblHeaderName.Text + "@" + lblFeeTypeID.Text;
            lnkDelete.CommandArgument = lblHeadID.Text + "@" + lblHeaderName.Text + "@" + lblFeeTypeID.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    protected void gdvFeeHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvFeeHead.PageIndex = e.NewPageIndex;
        bindFeeHead(0);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add"; 
    }
}
