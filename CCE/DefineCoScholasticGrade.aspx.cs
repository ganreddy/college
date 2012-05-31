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
public partial class CCE_DefineCoScholasticGrade : System.Web.UI.Page
{
    BusinessLayer.CCEBL objCCE = new CCEBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        btnClear.Attributes.Add("onclick", "javascript:return clearform();");
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
        }
    }
    public void bindIndicators(int CoScholasticID, int AssesmentID)
    {
        ds = new DataSet();
        ds = objCCE.GetCoScholasticIndicators(CoScholasticID, AssesmentID);
        if (ds.Tables.Count > 0)
        {
            chkIndicators.DataSource = ds.Tables[0];
            chkIndicators.DataValueField = "IndicatorId";
            chkIndicators.DataTextField = "Indicator";
            chkIndicators.DataBind();
        }
        else
            chkIndicators.Items.Clear();
        if (CoScholasticID == 0 && AssesmentID == 0)
        {
            chkIndicators.Items.Clear();
        }
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
    public void bindGrades(int CoScholasticID, int AssesmentID)
    {
        ds = new DataSet();
        ds = objCCE.GetCoscholasticGrades(CoScholasticID, AssesmentID);
        if (ds.Tables.Count > 0)
        {
            gdvGrades.DataSource = ds.Tables[0];
            gdvGrades.DataBind();
        }
        //bindIndicators();
        //gdvIndicators.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0,cnt=0; string Comma = "",s,Msg;
        for (int j = 0; j < chkIndicators.Items.Count; j++)
        {
            if (chkIndicators.Items[j].Selected)
            {
                if (Comma == "")
                {
                    Comma = Comma + chkIndicators.Items[j].Value;
                }
                else
                {
                    Comma = Comma + "," + chkIndicators.Items[j].Value;
                }
            }
        }
        for (int m = 0; m < chkIndicators.Items.Count; m++)
        {
            if (chkIndicators.Items[m].Selected)
            {
                cnt++;
                break;
            }

        }
        if (cnt == 0)
        {
            Msg = "alert('Please Select Atleast One Indicator');";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);

        }
        else
        {


            if (btnAdd.Text == "Add")
            {

                i = objCCE.AddCoscholasticGrades(ddlGrade.SelectedValue, Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value), Comma);
                if (i > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = ddlGrade.SelectedValue + " Grade Added Successfully";
                    //s = ddlGrade.SelectedValue + " Grade Added Successfully";
                    ddlGrade.SelectedValue = "";
                    //ddlCoscholastic.SelectedIndex = 0;
                    bindGrades(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = ddlGrade.SelectedValue + "  Grade Already Exists";
                    //s = ddlGrade.SelectedValue + "  Grade Already Exists";
                }
                //Msg = "alert('" + s + "');";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
            }
            if (btnAdd.Text == "Update")
            {
                i = objCCE.EditCoscholasticGrades(Convert.ToInt32(hdnAccountHeadID.Value), ddlGrade.SelectedValue, Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value), Comma);
                if (i > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text =  "Grade Modified Successfully";
                    //s = "Grade Modified Successfully";
                    ddlGrade.SelectedValue = "";
                    //ddlCoscholastic.SelectedIndex = 0;
                    btnAdd.Text = "Add";
                    bindGrades(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = ddlGrade.SelectedValue + "   Already Exists";
                    //s = ddlGrade.SelectedValue + "   Already Exists";
                }
                //Msg = "alert('" + s + "');";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
            }
        }
    }
    protected void ddlCoscholastic_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindAssesmentArea(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value));
        bindIndicators(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
    }
    protected void ddlSkills_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindIndicators(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
        bindGrades(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
    }

    protected void gdvGrades_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string strr = "",s,Msg;
        int i = 0;
        if (e.CommandName == "editing")
        {
            hdnAccountHeadID.Value = e.CommandArgument.ToString().Split('@')[7].ToString();
            ddlCoscholastic.SelectedValue =e.CommandArgument.ToString().Split('@')[2].ToString();
            ddlSkills.SelectedValue = e.CommandArgument.ToString().Split('@')[4].ToString();
            if (e.CommandArgument.ToString().Split('@')[6].ToString() == "A")
            {
                ddlGrade.SelectedValue = "A";
            }
            if (e.CommandArgument.ToString().Split('@')[6].ToString() == "B")
            {
                ddlGrade.SelectedValue = "B";
            }
            if (e.CommandArgument.ToString().Split('@')[6].ToString() == "C")
            {
                ddlGrade.SelectedValue = "C";
            }
            if (e.CommandArgument.ToString().Split('@')[6].ToString() == "D")
            {
                ddlGrade.SelectedValue = "D";
            }
            if (e.CommandArgument.ToString().Split('@')[6].ToString() == "E")
            {
                ddlGrade.SelectedValue = "E";
            }
            
            strr = e.CommandArgument.ToString().Split('@')[0].ToString();
            int k;
            chkIndicators.ClearSelection();
            for (k = 0; k < strr.Split(',').Length; k++)
            {
                foreach (ListItem lst in chkIndicators.Items)
                {

                    if (lst.Value == strr.Split(',')[k].ToString())
                    {
                        lst.Selected = true;

                        break;
                    }
                }
            }
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnAccountHeadID.Value = e.CommandArgument.ToString().Split('@')[7].ToString();
            i = objCCE.DeleteCoScholasticGrades(Convert.ToInt32(hdnAccountHeadID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Grade Deleted Successfully";
                //s = "Grade Deleted Successfully";
                //Msg = "alert('" + s + "');";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                bindGrades(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
            }
        }



    }
    protected void gdvGrades_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ds = new DataSet();
        string Comma=string.Empty;
        
        foreach (GridViewRow gvr in gdvGrades.Rows)
        {

            Label lblIndicator = new Label();
            lblIndicator = (Label)gvr.Cells[3].FindControl("lblIndicators");
            Label lblIndi = new Label();
            lblIndi = (Label)gvr.Cells[3].FindControl("lblIndi");
            lblIndi.Text = "";
            Label lblCoScholasticID = new Label();
            lblCoScholasticID = (Label)gvr.Cells[2].FindControl("lblCoScholasticID");
            Label lblCoScholasticArea = new Label();
            lblCoScholasticArea = (Label)gvr.Cells[2].FindControl("lblCoscholasticArea");
            Label lblAssesmentID = new Label();
            lblAssesmentID = (Label)gvr.Cells[3].FindControl("lblAssesmentID");
            Label lblAssesmentArea = new Label();
            lblAssesmentArea = (Label)gvr.Cells[3].FindControl("lblAssesmentArea");
            
            LinkButton lnkEdit = new LinkButton();
            lnkEdit = (LinkButton)gvr.Cells[4].FindControl("lnkEdit");
            Label lblGradeID = new Label();
            lblGradeID = (Label)gvr.Cells[0].FindControl("lblGradeID");
            Label lblGrade=new Label();
            lblGrade = (Label)gvr.Cells[1].FindControl("lblGrade");
            LinkButton lnkDelete = new LinkButton();
            lnkDelete = (LinkButton)gvr.Cells[8].FindControl("lnkDelete");
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
            lnkEdit.CommandArgument = lblIndicator.Text + "@" + lblIndi.Text + "@" + lblCoScholasticID.Text + "@" + lblCoScholasticArea.Text + "@" + lblAssesmentID.Text + "@" + lblAssesmentArea.Text + "@" + lblGrade.Text + "@" + lblGradeID.Text;
            lnkDelete.CommandArgument = lblIndicator.Text + "@" + lblIndi.Text + "@" + lblCoScholasticID.Text + "@" + lblCoScholasticArea.Text + "@" + lblAssesmentID.Text + "@" + lblAssesmentArea.Text + "@" + lblGrade.Text + "@" + lblGradeID.Text;
            if (lblIndicator.Text != "")
            {
                for (int i = 0; i < lblIndicator.Text.Split(',').Length; i++)
                {
                    ds = objCCE.GetIndicatorsByID(Convert.ToInt32(lblIndicator.Text.Split(',')[i]));
                    if (i == lblIndicator.Text.Split(',').Length - 1)
                        lblIndi.Text += ds.Tables[0].Rows[0]["Indicator"].ToString();
                    else
                        lblIndi.Text += ds.Tables[0].Rows[0]["Indicator"].ToString() + ",";
                }
            }
            for (int j = 0; j < chkIndicators.Items.Count; j++)
            {
                if (chkIndicators.Items[j].Selected)
                {
                    if (Comma == "")
                    {
                        Comma = Comma + chkIndicators.Items[j].Value;

                    }
                    else
                    {
                        Comma = Comma + "," + chkIndicators.Items[j].Value;
                    }
                }
            }
            
            
        }
            
    }
    protected void gdvGrades_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
    }
}
