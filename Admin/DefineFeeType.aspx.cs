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
public partial class Admin_DefineFeeType : System.Web.UI.Page
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
            bindFeeType();
        }
    }
    public void bindFeeType()
    {
        ds = new DataSet();
        ds = objComm.GetFeeType(0);
        gdvAccountsHead.DataSource = ds.Tables[0];
        gdvAccountsHead.DataBind();

        //bindAccountHead();
        //gdvAccountsHead.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        string Msg, s = "";
        string date;
        if (btnAdd.Text == "Add")
        {
            date=ChangeDateFormat(txtDate.Text);
            i = objComm.AddFeeType(txtFeetype.Text, date);
            if (i > 0)
            {
                //lblMessage.Visible = true;
                //lblMessage.Text = txtFeetype.Text + " Fee Type Added Successfully";
                s = txtFeetype.Text + " Fee Type Added Successfully";
               
                Msg = "alert('" + s + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                txtFeetype.Text = "";
                txtDate.Text = "";
                bindFeeType();
            }
            else
            {
                //lblMessage.Visible = true;
                //lblMessage.Text = txtFeetype.Text + "  Fee Type Already Exists";
                s = txtFeetype.Text + "  Fee Type Already Exists";
                Msg = "alert('" + s + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);

            }
        }
        if (btnAdd.Text == "Update")
        {
            date = ChangeDateFormat(txtDate.Text);
            i = objComm.EditFeeType(Convert.ToInt32(hdnAccountHeadID.Value), txtFeetype.Text, date);
            if (i > 0)
            {
                //lblMessage.Visible = true;
                //lblMessage.Text = txtFeetype.Text + " Fee Type Modified Successfully";
                s = txtFeetype.Text + " Fee Type Modified Successfully";
                Msg = "alert('" + s + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                txtFeetype.Text = "";
                txtDate.Text = "";
                btnAdd.Text = "Add";
                bindFeeType();
            }
            else
            {
                s = txtFeetype.Text + "  Fee Type Already Exists";
                Msg = "alert('" + s + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                //lblMessage.Visible = true;
                //lblMessage.Text = txtFeetype.Text + "  Fee Type Already Exists";

            }
        }
    }

    protected void gdvAccountsHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtFeetype.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnAccountHeadID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            txtDate.Text = e.CommandArgument.ToString().Split('@')[2].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            txtFeetype.Text = e.CommandArgument.ToString().Split('@')[1].ToString();

            hdnAccountHeadID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteFeeType(Convert.ToInt32(hdnAccountHeadID.Value));
            if (i > 0)
            {
                //lblMessage.Visible = true;
                //lblMessage.Text = txtHead.Text + "  Fee Header Deleted Successfully";
                string Msg, s;
                s = txtFeetype.Text + "  Fee Type Deleted Successfully";
                Msg = "alert('" + s + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                txtFeetype.Text = "";
                txtDate.Text = "";
                bindFeeType();
                //ddlFeeType.SelectedIndex = 0;
                //bindFeeHead(0);
            }
        }
        
    }

    protected void gdvAccountsHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvAccountsHead.Rows)
        {
            Label lblHeadID = new Label();
            Label lblHeadName = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();
            Label lblLastDate=new Label();
            lblHeadID = (Label)gvr.Cells[0].FindControl("lblHeadID");
            lblHeadName = (Label)gvr.Cells[1].FindControl("lblHeadName");
            lblLastDate = (Label)gvr.Cells[2].FindControl("lblLastDate");
            lnkEdit = (LinkButton)gvr.Cells[3].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[4].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblHeadID.Text + "@" + lblHeadName.Text+"@"+lblLastDate.Text;
            lnkDelete.CommandArgument = lblHeadID.Text + "@" + lblHeadName.Text + "@" + lblLastDate.Text; 
           
            
        }
    }
    protected void gdvAccountsHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvAccountsHead.PageIndex = e.NewPageIndex;
        bindFeeType();
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add"; 
    }
}
