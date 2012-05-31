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

public partial class CCE_CoScholasticMarks : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CCEBL objCCE = new CCEBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStud = new StudentAdmissionBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        if (!IsPostBack)
        {
            ds = objComm.GetClasses();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlClass.DataSource = ds.Tables[0];
                    ddlClass.DataTextField = "ClassName";
                    ddlClass.DataValueField = "ClassID";
                    ddlClass.DataBind();
                    ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
            ds = objComm.GetBatch();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlBatch.DataSource = ds.Tables[0];
                    ddlBatch.DataTextField = "BatchNo";
                    ddlBatch.DataValueField = "BatchID";
                    ddlBatch.DataBind();
                    ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
            ds = objComm.GetSection();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlSection.DataSource = ds.Tables[0];
                    ddlSection.DataTextField = "SectionName";
                    ddlSection.DataValueField = "SectionID";
                    ddlSection.DataBind();
                    ddlSection.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
            ds = objCCE.GetCoScholasticArea(0);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlCoScholasticArea.DataSource = ds.Tables[0];
                    ddlCoScholasticArea.DataTextField = "CoScholasticArea";
                    ddlCoScholasticArea.DataValueField = "CoScholasticID";
                    ddlCoScholasticArea.DataBind();
                    ddlCoScholasticArea.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
            



        }
        //if (ViewState["count"] != null)
        //{
        //    gdvCoScholastic.Visible = false;
        //    gdvDisplayCoScholastic.Visible = true;
        //    ds = objCCE.GetCoScholasticMarksDisplay();
        //    gdvDisplayCoScholastic.DataSource = ds.Tables[0];
        //    gdvDisplayCoScholastic.DataBind();
        //}
    }
    public void bindMarks()
    {
        ds = new DataSet();
        ds = objStud.GetStudData(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value),
           Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value),
           Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
        gdvCoScholastic.DataSource = ds.Tables[0];
        gdvCoScholastic.DataBind();


    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindMarks();
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindMarks();
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindMarks();
    }
    protected void ddlCoScholasticArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsIndicators = new DataSet();
        dsIndicators = objCCE.GetCoScholasticIndicators(Convert.ToInt32(ddlCoScholasticArea.SelectedValue));
        foreach (GridViewRow gvr in gdvCoScholastic.Rows)
        {
            CheckBoxList chkIndicators = new CheckBoxList();
            chkIndicators = (CheckBoxList)gvr.Cells[3].FindControl("chkIndicators");

            for (int i = 0; i < dsIndicators.Tables[0].Rows.Count; i++)
            {
                chkIndicators.DataSource = dsIndicators.Tables[0];
                chkIndicators.DataValueField = "IndicatorId";
                chkIndicators.DataTextField = "Indicator";
                chkIndicators.DataBind();
            }

        }


    }
    protected void gdvCoScholastic_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int count = 0;
        int batch, Class, section, coScholasticArea;
        batch = Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value);
        Class = Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value);
        section = Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value);
        coScholasticArea = Convert.ToInt32(ddlCoScholasticArea.Items[ddlCoScholasticArea.SelectedIndex].Value);
        foreach (GridViewRow gvr in gdvCoScholastic.Rows)
        {
            int i;
            int Gender = 0;
            string Comma = "";
            Label lblStudID = new Label();
            lblStudID = (Label)gvr.Cells[0].FindControl("lblStudID");
            CheckBox chkSelect = new CheckBox();
            chkSelect = (CheckBox)gvr.Cells[1].FindControl("chkSelect");
            Label lblCaste = new Label();
            lblCaste = (Label)gvr.Cells[3].FindControl("lblCaste");
            Label lblCasteID = new Label();
            lblCasteID = (Label)gvr.Cells[3].FindControl("lblCasteID");
            Label lblGender = new Label();
            lblGender = (Label)gvr.Cells[4].FindControl("lblGender");
            CheckBoxList chkIndicators = new CheckBoxList();
            chkIndicators = (CheckBoxList)gvr.Cells[5].FindControl("chkIndicators");
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
            TextBox txtGrade = new TextBox();
            txtGrade = (TextBox)gvr.Cells[6].FindControl("txtGrade");
            if (lblGender.Text == "Boy")
            {
                Gender = 1;
            }
            else
            {
                Gender = 2;
            }
            if (chkSelect.Checked)
            {
                count = count + 1;
               // ViewState["count"] = 1;
                i = objCCE.AddCoScholasticMarks(Convert.ToInt32(lblStudID.Text), Convert.ToInt32(lblCasteID.Text), Gender, Comma, txtGrade.Text, batch, Class, section, coScholasticArea);
            }

        }
        if (count > 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Co-Scholastic Marks Added Successfully";
        }
    }
    
}
