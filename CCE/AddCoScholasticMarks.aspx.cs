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

public partial class CCE_AddCoScholasticMarks : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CCEBL objCCE = new CCEBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStud = new StudentAdmissionBL();
    DataSet dsExam;
    string strValues = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        btnClear.Attributes.Add("onclick", "javascript:return Clear();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");

        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = new DataSet();
            ds = objCCE.GetCoScholasticArea(0);
            ddlCoscholastic.DataSource = ds.Tables[0];
            ddlCoscholastic.DataTextField = "CoScholasticArea";
            ddlCoscholastic.DataValueField = "CoScholasticID";
            ddlCoscholastic.DataBind();
            ddlCoscholastic.Items.Insert(0, new ListItem("---Select---", "0"));
            for (int i = 1990; i < 2050; i++)
            {
                string j = i.ToString() + "-" + Convert.ToString(i + 1);
                ddlYear.Items.Add(new ListItem(j.ToString(), i.ToString()));
            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlYear.SelectedValue = DateTime.Now.Year.ToString();

            ds = objComm.GetClasses(0);
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
            ds = objComm.GetBatch(0);
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
            ds = objComm.GetSection(0);
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

        }
        bindMarks();
        if (ViewState["Rows"] != null && ViewState["Columns"] != null)
            btnAdd.Attributes.Add("onclick", "javascript:return GetDetails(" + ViewState["Rows"].ToString() + "," + ViewState["Columns"].ToString() + ");");

    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindMarks();
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindMarks();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {

        bindMarks();
    }
    public void bindMarks()
    {
        DataSet dsCoScholastic = new DataSet();
        ds = new DataSet();
        dsExam = new DataSet();

        ds = objStud.GetStudData(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value),
           Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value),
           Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
       
        TableRow tr = new TableRow();
        TableCell tc;
        TextBox txt;
        dsCoScholastic = objCCE.GetCoscholasticDescriptors(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value), Convert.ToInt32(ddlSkills.Items[ddlSkills.SelectedIndex].Value));
        tb.Rows.Clear();
        if (dsCoScholastic.Tables.Count > 0)
        {
            if (dsCoScholastic.Tables[0].Rows.Count > 0)
            {
                lblMessage.Visible = false;
                ViewState["Columns"] = dsCoScholastic.Tables[0].Rows.Count;
                tc = new TableCell();
                tc.Text = "Name of Student";
                tc.Attributes.Add("style", "color:black;font-weight:bold;font-size:12px;");
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "Gender";
                tc.Attributes.Add("style", "color:black;font-weight:bold;font-size:12px;");
                tr.Cells.Add(tc);
                
                for (int i = 0; i < dsCoScholastic.Tables[0].Rows.Count; i++)
                {
                    tc = new TableCell();
                    HiddenField hdnScholasticID = new HiddenField();
                    hdnScholasticID.ID = "hdnScholasticID" + i.ToString();
                    hdnScholasticID.Value = dsCoScholastic.Tables[0].Rows[i][0].ToString();
                    tc.Controls.Add(hdnScholasticID);
                    HiddenField hdnMaxMarks = new HiddenField();
                    hdnMaxMarks.Value = "5";
                    hdnMaxMarks.ID = "hdnMaxMarks" + i.ToString();
                    tc.Controls.Add(hdnMaxMarks);
                    Label lblName = new Label();
                    //lblName.Attributes.Add( "style","layout-flow: vertical-ideographic;");
                    lblName.Text = dsCoScholastic.Tables[0].Rows[i][1].ToString() + "<br/>( 5 )";
                    tc.Controls.Add(lblName);
                    tc.BorderWidth = 1;
                    tc.Attributes.Add("style", "color:black;font-weight:bold;font-size:12px;border-color:black;");
                    tr.Cells.Add(tc);
                }

                tc = new TableCell();
                tc.Text = "Total";
                tc.BorderWidth = 1;
                tc.Attributes.Add("style", "color:black;font-weight:bold;font-size:12px;border-width:1px;border-color:black;");
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "Average";
                tc.BorderWidth = 1;
                tc.Attributes.Add("style", "color:black;font-weight:bold;font-size:12px;border-width:1px;border-color:black;");
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "Grade";
                tc.BorderWidth = 1;
                tc.Attributes.Add("style", "color:black;font-weight:bold;font-size:12px;border-width:1px;border-color:black;");
                tr.Cells.Add(tc);
                tb.Rows.Add(tr);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["Rows"] = ds.Tables[0].Rows.Count;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            tc = new TableCell();
                            TableRow trSt = new TableRow();
                            tc.Attributes.Add("style", "color:red;font-weight:bold;font-size:12px;");
                            HiddenField hdnStdID = new HiddenField();
                            hdnStdID.Value = ds.Tables[0].Rows[i][0].ToString();
                            hdnStdID.ID = "hdnStdID" + i.ToString();
                            tc.Controls.Add(hdnStdID);
                            Label lblName = new Label();
                            lblName.Text = ds.Tables[0].Rows[i][1].ToString();
                            tc.Controls.Add(lblName);
                            trSt.Cells.Add(tc);
                            tb.Rows.Add(trSt);
                            tc = new TableCell();
                            tc.Text = ds.Tables[0].Rows[i]["Gender"].ToString();
                            tc.Attributes.Add("style", "color:black;font-weight:bold;font-size:12px;");
                            trSt.Cells.Add(tc);
                            tb.Rows.Add(trSt);

                            for (int k = 0; k < dsCoScholastic.Tables[0].Rows.Count; k++)
                            {
                                tc = new TableCell();
                                txt = new TextBox();
                                txt.ID = "txtMarks" + i.ToString() + k.ToString();
                                txt.Width = 50;
                                txt.Attributes.Add("onchange", "javascript:return CalcMarks(" + i.ToString() + "," + k.ToString() + "," + dsCoScholastic.Tables[0].Rows.Count.ToString() + ");");
                                txt.Attributes.Add("onkeypress", "javascript:return Validate(" + i.ToString() + "," + k.ToString() + ");");
                                tc.Attributes.Add("style", "color:black;font-weight:bold;font-size:12px;");
                                tc.Controls.Add(txt);
                                //tc.HorizontalAlign = HorizontalAlign.Center;
                                trSt.Cells.Add(tc);
                                tb.Rows.Add(trSt);
                            }
                            tc = new TableCell();
                            txt = new TextBox();
                            txt.ID = "txtTotal" + i.ToString();
                            txt.Enabled = false;
                            txt.Width = 80;
                            tc.Attributes.Add("style", "color:black;font-weight:bold;font-size:12px;");
                            tc.Controls.Add(txt);
                            trSt.Cells.Add(tc);

                            tc = new TableCell();
                            txt = new TextBox();
                            txt.ID = "txtAverage" + i.ToString();
                            txt.Enabled = false;
                            txt.Width = 50;
                            tc.Attributes.Add("style", "color:black;font-weight:bold;font-size:12px;");
                            tc.Controls.Add(txt);
                            //tc.HorizontalAlign = HorizontalAlign.Center;
                            trSt.Cells.Add(tc);

                            tc = new TableCell();
                            txt = new TextBox();
                            txt.ID = "txtGrade" + i.ToString();
                            txt.Enabled = false;
                            txt.Width = 50;
                            tc.Attributes.Add("style", "color:black;font-weight:bold;font-size:12px;");
                            tc.Controls.Add(txt);
                            //tc.HorizontalAlign = HorizontalAlign.Center;
                            trSt.Cells.Add(tc);
                            tb.Rows.Add(trSt);
                        }
                    }
                }

            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "No Co-Scholastic Areas Defined For This Selection";
            }
        }
        
        




    }
    
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        string strVal = hdnValues.Value;
        string strTotal = hdnTotal.Value;
        int cnt = 0;
        for (int i = 0; i < strVal.Split('@').Length - 1; i++)
        {
            for (int j = 0; j < strVal.Split('@')[i].Split('#').Length; j++)
            {
                if (strVal.Split('@')[i].Split('#')[j].Split('~')[2].ToString() != "")
                {
                    cnt = objCCE.AddCoScholasticMarks(Convert.ToInt32(strVal.Split('@')[i].Split('#')[j].Split('~')[0].ToString()),Convert.ToInt32(ddlBatch.SelectedValue), Convert.ToInt32(ddlClass.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue),Convert.ToInt32(ddlCoscholastic.SelectedValue),Convert.ToInt32(ddlSkills.SelectedValue), Convert.ToInt32(strVal.Split('@')[i].Split('#')[j].Split('~')[1].ToString()), Convert.ToDecimal(strVal.Split('@')[i].Split('#')[j].Split('~')[2].ToString()));
                    for (int k = 0; k < strTotal.Split('#').Length; k++)
                    {
                        if (Convert.ToInt32(strVal.Split('@')[i].Split('#')[j].Split('~')[0].ToString()) == Convert.ToInt32(strTotal.Split('#')[k].Split('~')[0].ToString()))
                        {
                            cnt = objCCE.AddCoScholasticTotalMarks(Convert.ToInt32(strVal.Split('@')[i].Split('#')[j].Split('~')[0].ToString()), Convert.ToInt32(ddlBatch.SelectedValue), Convert.ToInt32(ddlClass.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlCoscholastic.SelectedValue), Convert.ToInt32(ddlSkills.SelectedValue), strTotal.Split('#')[k].Split('~')[2].ToString(), Convert.ToDecimal(strTotal.Split('#')[k].Split('~')[1].ToString()), Convert.ToDecimal(strTotal.Split('#')[k].Split('~')[3].ToString()));
                            break;
                        }
                    }
                }
            }
        }

        if (cnt != 0)
        {
            Response.Redirect("DisplayCoScholasticMarks.aspx?Year=" + ddlYear.Items[ddlYear.SelectedIndex].Value + "&sub=" + ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value + "&Ex=" + ddlSkills.Items[ddlSkills.SelectedIndex].Value + "&Bat=" + ddlBatch.Items[ddlBatch.SelectedIndex].Value + "&Cl=" + ddlClass.Items[ddlClass.SelectedIndex].Value + "&Sec=" + ddlSection.Items[ddlSection.SelectedIndex].Value);
        }

    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindMarks();
    }
    protected void ddlCoscholastic_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindAssesmentArea(Convert.ToInt32(ddlCoscholastic.Items[ddlCoscholastic.SelectedIndex].Value));
        
    }
    protected void ddlSkills_SelectedIndexChanged(object sender, EventArgs e)
    {

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

        
    }
}
