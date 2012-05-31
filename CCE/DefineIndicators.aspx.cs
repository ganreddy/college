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

public partial class CCE_DefineIndicators : System.Web.UI.Page
{
    BusinessLayer.CCEBL objCCE = new CCEBL();
    DataSet ds;
    string Msg, s = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        btnClear.Attributes.Add("onclick", "javascript:return Clear();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = objCCE.GetCoScholasticArea(0);
            ddlCoscholastic.DataSource = ds.Tables[0];
            ddlCoscholastic.DataTextField = "CoScholasticArea";
            ddlCoscholastic.DataValueField = "CoScholasticID";
            ddlCoscholastic.DataBind();
            ddlCoscholastic.Items.Insert(0, new ListItem("---Select---", "0"));
            //bindIndicators(0);
            btnAdd.Visible = false; 
        }
    }
    public void bindIndicators(int CoScholasticID,int AssesmentID)
    {
        ds = new DataSet();
        ds = objCCE.GetCoScholasticIndicators(CoScholasticID,AssesmentID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnAdd.Visible = true;
        }
        gdvIndicators.DataSource = ds.Tables[0];
        gdvIndicators.DataBind();

        //bindIndicators();
        //gdvIndicators.DataBind();
    }
    public void bindAssesmentArea(int CoScholasticID)
    {
        ds = new DataSet();
        ds = objCCE.GetAssesmentArea(CoScholasticID);
        ddlSkills.DataSource = ds.Tables[0];
        ddlSkills.DataTextField = "AssesmentArea";
        ddlSkills.DataValueField = "AssesmentID";
        ddlSkills.DataBind();
        ddlSkills.Items.Insert(0, new ListItem("---Select---", "0"));
            
        //bindIndicators();
        //gdvIndicators.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objCCE.AddCoScholasticIndicators(txtIndicator.Text, Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtIndicator.Text + " Indicator Added Successfully";
                //s = " Indicator Added Successfully";
                txtIndicator.Text = "";
                ddlCoscholastic.SelectedValue = "0";
                ddlSkills.SelectedValue = "0";  
                //ddlCoscholastic.SelectedIndex = 0;
                bindIndicators(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
            }
            else
            {
                //lblMessage.Visible = true;
                //lblMessage.Text = txtIndicator.Text + "  Indicator already Exists";
                s = "  Indicator Already Exists";
            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objCCE.EditCoScholasticIndicators(Convert.ToInt32(hdnAccountHeadID.Value), txtIndicator.Text, Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtIndicator.Text + "   Modified Successfully";
                //s = "   Modified Successfully";
                txtIndicator.Text = "";
                ddlCoscholastic.SelectedValue = "0";
                ddlSkills.SelectedValue = "0";  
                //ddlCoscholastic.SelectedIndex = 0;
                btnAdd.Text = "Add";
                bindIndicators(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtIndicator.Text + "   Already Exists";
                //s = "   Already Exists";
            }
        }
        //Msg = "alert('" + s + "');";
       // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
    }
    protected void gdvIndicators_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtIndicator.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnAccountHeadID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            ddlCoscholastic.SelectedValue = e.CommandArgument.ToString().Split('@')[2].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnAccountHeadID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objCCE.DeleteCoScholasticIndicators(Convert.ToInt32(hdnAccountHeadID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtIndicator.Text + " Indicator Deleted Successfully";
                //s = " Indicator Deleted Successfully";
                //Msg = "alert('" + s + "');";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                txtIndicator.Text = "";
                bindIndicators(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
            }
        }
    }
    protected void gdvIndicators_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvIndicators.Rows)
        {
            Label lblIndicatorID = new Label();
            Label lblIndicator = new Label();
            Label lblCoScholasticID = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblIndicatorID = (Label)gvr.Cells[0].FindControl("lblIndicatorID");
            lblIndicator = (Label)gvr.Cells[1].FindControl("lblIndicator");
            lblCoScholasticID = (Label)gvr.Cells[2].FindControl("lblCoScholasticID");


            lnkEdit = (LinkButton)gvr.Cells[3].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[4].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblIndicatorID.Text + "@" + lblIndicator.Text + "@" + lblCoScholasticID.Text;
            lnkDelete.CommandArgument = lblIndicatorID.Text + "@" + lblIndicator.Text + "@" + lblCoScholasticID.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    protected void gdvIndicators_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvIndicators.PageIndex = e.NewPageIndex;
        bindIndicators(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
    }
    protected void ddlCoscholastic_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindAssesmentArea(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value));
        bindIndicators(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
    }
    protected void ddlSkills_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindIndicators(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
    }
}
