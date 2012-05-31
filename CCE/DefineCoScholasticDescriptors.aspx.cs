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

public partial class CCE_DefineCoScholasticDescriptors : System.Web.UI.Page
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
            //bindDescriptors(0);
        }
    }
    public void bindDescriptors(int CoScholasticID, int AssesmentID)
    {
        ds = new DataSet();
        ds = objCCE.GetCoscholasticDescriptors(CoScholasticID, AssesmentID);
        gdvGrades.DataSource = ds.Tables[0];
        gdvGrades.DataBind();
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

        bindDescriptors(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
        //gdvIndicators.DataBind();
    }
    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0; string Comma = "";
        if (btnAdd.Text == "Add")
        {
            
            i = objCCE.AddCoscholasticDescriptors(txtDescriptor.Text, Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
            if (i > 0)
            {
                //lblMessage.Visible = true;
                //lblMessage.Text = txtDescriptor.Text + "  Added Successfully";
                s = "Added Successfully";
                Msg = "alert('" + s + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                txtDescriptor.Text = "";
                //ddlCoscholastic.SelectedIndex = 0;
                bindDescriptors(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
            }
            else
            {
                //lblMessage.Visible = true;
                //lblMessage.Text = txtDescriptor.Text + "  Already Exists";
                s = "Already Exists";
            }
            Msg = "alert('" + s + "');";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
        }
        if (btnAdd.Text == "Update")
        {
           // i = objCCE.EditCoScholasticIndicators(Convert.ToInt32(hdnAccountHeadID.Value), txtGrade.Text, Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value));
            i = objCCE.EditCoscholasticDescriptors(Convert.ToInt32(hdnsecriptors.Value), txtDescriptor.Text, Convert.ToInt32(ddlCoscholastic.SelectedValue), Convert.ToInt32(ddlSkills.SelectedValue));   
            if (i > 0)
            {
                //lblMessage.Visible = true;
                //lblMessage.Text = txtDescriptor.Text + "   Modified Successfully";
                //ddlCoscholastic.SelectedIndex = 0;
                s = txtDescriptor.Text + "   Modified Successfully";
                Msg = "alert('" + s + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                ddlSkills.SelectedValue = "0";
                ddlCoscholastic.SelectedValue = "0";
                txtDescriptor.Text = "";
                btnAdd.Text = "Add";
                bindDescriptors(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
            }
            else
            {
                lblMessage.Visible = true;
                //lblMessage.Text = txtGrade.Text + "   already Exists";

            }
        }
    }
    protected void ddlCoscholastic_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindAssesmentArea(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value));
        bindDescriptors(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
    }
    protected void ddlSkills_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDescriptors(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
        
    }

    protected void gdvGrades_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            hdnsecriptors.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            ddlCoscholastic.SelectedValue = e.CommandArgument.ToString().Split('@')[2].ToString();
            ddlSkills.SelectedValue = e.CommandArgument.ToString().Split('@')[4].ToString();
            txtDescriptor.Text = e.CommandArgument.ToString().Split('@')[1].ToString(); 
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnsecriptors.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i =objCCE.DeleteCoscholasticDescriptors(Convert.ToInt32(hdnsecriptors.Value));
            
            if (i > 0)
            {
                //lblMessage.Visible = true;
                //////lblMessage.Text = "   Co-Scholastic Descriptor Deleted Successfully";
                s = " Co-Scholastic Descriptor Deleted Successfully";
                Msg = "alert('" + s + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                bindDescriptors(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
            
            }
            btnAdd.Text = "Add";
        }
    }
    protected void gdvGrades_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ds = new DataSet();
        foreach (GridViewRow gvr in gdvGrades.Rows)
        {
            Label lblDescriptorID = new Label();
            Label lblDescriptor = new Label();
            Label lblCoScholasticID = new Label();
            Label lblCoscholasticArea = new Label();
            Label lblAssesmentID = new Label();
            Label lblAssesmentArea = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblDescriptorID = (Label)gvr.FindControl("lblDescriptorID");
            lblDescriptor = (Label)gvr.FindControl("lblDescriptor");
            lblCoScholasticID = (Label)gvr.FindControl("lblCoScholasticID");
            lblCoscholasticArea = (Label)gvr.FindControl("lblCoscholasticArea");
            lblAssesmentID = (Label)gvr.FindControl("lblAssesmentID");
            lblAssesmentArea = (Label)gvr.FindControl("lblAssesmentArea");
            lnkEdit = (LinkButton)gvr.FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.FindControl("lnkDelete"); 
            lnkEdit.CommandArgument = lblDescriptorID.Text + "@" + lblDescriptor.Text + "@" + lblCoScholasticID.Text + "@" + lblCoscholasticArea.Text + "@" + lblAssesmentID.Text + "@" + lblAssesmentArea.Text; ;
            lnkDelete.CommandArgument = lblDescriptorID.Text + "@" + lblDescriptor.Text + "@" + lblCoScholasticID.Text + "@" + lblCoscholasticArea.Text + "@" + lblAssesmentID.Text + "@" + lblAssesmentArea.Text;

            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    protected void gdvGrades_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}
