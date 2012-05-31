using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using BusinessLayer;

public partial class CCE_DefineScholasticArea : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CCEBL objCCE = new CCEBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    string Msg, s = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        btnClear.Attributes.Add("onclick", "javascript:return Clear();");
        if (!IsPostBack)
        {
            ds = objCCE.GetExam(0);
            ddlExamType.DataSource = ds.Tables[0];
            ddlExamType.DataTextField = "ExamName";
            ddlExamType.DataValueField = "ExamID";
            ddlExamType.DataBind();
            ddlExamType.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.getbatch();
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string j = ds.Tables[0].Rows[i]["BatchNo"].ToString() + "-" + Convert.ToString(Convert.ToInt32(ds.Tables[0].Rows[i]["BatchNo"].ToString()) + 1);
                ddlYear.Items.Add(new ListItem(j.ToString(), ds.Tables[0].Rows[i]["BatchID"].ToString()));
            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetSubject();
            ddlSubject.DataSource = ds.Tables[0];
            ddlSubject.DataTextField = "SubjectName";
            ddlSubject.DataValueField = "SubjectID";
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetClasses(0);
            ddlClass.DataSource = ds.Tables[0];
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    public void bindScholasticArea(int year,int Subject,int Exam,int Classes)
    {
        ds = new DataSet();
        ds = objCCE.GetScholasticArea1(year, Subject,Exam,Classes);
        gdvArea.DataSource = ds.Tables[0];
        gdvArea.DataBind();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindScholasticArea(Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value),Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value),Convert.ToInt32(ddlExamType.Items[ddlExamType.SelectedIndex].Value),Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value));
    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindScholasticArea(Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value), Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value), Convert.ToInt32(ddlExamType.Items[ddlExamType.SelectedIndex].Value), Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value));
    }
    protected void gdvArea_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvArea.PageIndex=e.NewPageIndex;
        bindScholasticArea(Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value), Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value), Convert.ToInt32(ddlExamType.Items[ddlExamType.SelectedIndex].Value), Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value));
    }
    protected void ddlExamType_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindScholasticArea(Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value), Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value), Convert.ToInt32(ddlExamType.Items[ddlExamType.SelectedIndex].Value), Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value));
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindScholasticArea(Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value), Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value), Convert.ToInt32(ddlExamType.Items[ddlExamType.SelectedIndex].Value), Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value));
    }
    protected void gdvArea_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtScholasticArea.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnSubAccountHeadID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            ddlExamType.SelectedValue = e.CommandArgument.ToString().Split('@')[2].ToString();
            ddlSubject.SelectedValue = e.CommandArgument.ToString().Split('@')[4].ToString();
            ddlClass.SelectedValue = e.CommandArgument.ToString().Split('@')[6].ToString();
            txtMaxMarks.Text = e.CommandArgument.ToString().Split('@')[8].ToString();
            ddlYear.SelectedValue = e.CommandArgument.ToString().Split('@')[9].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnSubAccountHeadID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objCCE.DeleteScholasticAreas1(Convert.ToInt32(hdnSubAccountHeadID.Value));
            if (i != 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "  Scholastic Area Deleted Successfully";
                //s = "Scholastic Area Deleted Successfully";
                //Msg = "alert('" + s + "');";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                bindScholasticArea(Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value), Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value), Convert.ToInt32(ddlExamType.Items[ddlExamType.SelectedIndex].Value), Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value));
                ddlYear.SelectedIndex = 0;
                ddlSubject.SelectedIndex = 0;
                ddlExamType.SelectedIndex = 0;
                ddlClass.SelectedIndex = 0;
                txtScholasticArea.Text = "";
                txtMaxMarks.Text = "";
                
            }
            
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        string ScholasticArea;
        int ExamID,AcadYear,ClassID,MaxMarks,SubjectID;
        ScholasticArea=txtScholasticArea.Text;
        ExamID=Convert.ToInt32(ddlExamType.Items[ddlExamType.SelectedIndex].Value);
        AcadYear=Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
        ClassID=Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value);
        MaxMarks = Convert.ToInt32(txtMaxMarks.Text);
        SubjectID=Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value);
        //ScholasticID=Convert.ToInt32(hdnSubAccountHeadID.Value);
        if (btnAdd.Text == "Add")
        {
            i = objCCE.AddScholasticArea(ScholasticArea, ExamID, AcadYear, ClassID, MaxMarks, SubjectID);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtScholasticArea.Text + "  Scholastic Area Added Successfully";
               // s = "Scholastic Area Added Successfully";
                bindScholasticArea(Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value), Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value), Convert.ToInt32(ddlExamType.Items[ddlExamType.SelectedIndex].Value), Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value));
                ddlYear.SelectedIndex = 0;
                ddlSubject.SelectedIndex = 0;
                ddlExamType.SelectedIndex = 0;
                ddlClass.SelectedIndex = 0;
                txtScholasticArea.Text = "";
                txtMaxMarks.Text = "";
                //ddlCoscholastic.SelectedIndex = 0;
                
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtScholasticArea.Text + "  Scholastic Area Already Exists";
                //s = "Scholastic Area Already Exists";
               // bindScholasticArea(0, 0, 0, 0);
            }
            //Msg = "alert('" + s + "');";
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
        }
        if (btnAdd.Text == "Update")
        {
            i = objCCE.EditScholasticArea1(Convert.ToInt32(hdnSubAccountHeadID.Value), ScholasticArea, MaxMarks);
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "  Scholastic Area Modified Successfully";
               // s = "Scholastic Area Modified Successfully";
                //Msg = "alert('" + s + "');";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                bindScholasticArea(Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value), Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value), Convert.ToInt32(ddlExamType.Items[ddlExamType.SelectedIndex].Value), Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value));
                ddlYear.SelectedIndex = 0;
                ddlSubject.SelectedIndex = 0;
                ddlExamType.SelectedIndex = 0;
                ddlClass.SelectedIndex = 0;
                txtScholasticArea.Text = "";
                txtMaxMarks.Text = "";
                btnAdd.Text = "Add";
                
            }

        }
    }
    protected void gdvArea_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvArea.Rows)
        {
            Label lblScholasticID = new Label();
            Label lblScholasticArea = new Label();
            Label lblExamID = new Label();
            Label lblExamName = new Label();
            Label lblSubjectID = new Label();
            Label lblSubjectName = new Label();
            Label lblClassID = new Label();
            Label lblClassName = new Label();
            Label lblMarks = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();
            Label lblYear = new Label();

            lblScholasticID = (Label)gvr.Cells[0].FindControl("lblScholasticID");
            lblScholasticArea = (Label)gvr.Cells[1].FindControl("lblScholasticArea");
            lblExamID = (Label)gvr.Cells[2].FindControl("lblExamID");
            lblExamName = (Label)gvr.Cells[3].FindControl("lblExamName");
            lblSubjectID = (Label)gvr.Cells[4].FindControl("lblSubjectID");
            lblSubjectName = (Label)gvr.Cells[5].FindControl("lblSubjectName");
            lblClassID = (Label)gvr.Cells[6].FindControl("lblClassID");
            lblClassName = (Label)gvr.Cells[7].FindControl("lblClassName");
            lblMarks = (Label)gvr.Cells[8].FindControl("lblMarks");
            lnkEdit = (LinkButton)gvr.Cells[9].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[10].FindControl("lnkDelete");
            lblYear = (Label)gvr.Cells[11].FindControl("lblYear");

            lnkEdit.CommandArgument = lblScholasticID.Text + "@" + lblScholasticArea.Text + "@" + lblExamID.Text + "@" +
                                    lblExamName.Text + "@" + lblSubjectID.Text + "@" + lblSubjectName.Text + "@" +
                                    lblClassID.Text + "@" + lblClassName.Text + "@" + lblMarks.Text + "@" + lblYear.Text;
            lnkDelete.CommandArgument = lblScholasticID.Text + "@" + lblScholasticArea.Text + "@" + lblExamID.Text + "@" +
                                    lblExamName.Text + "@" + lblSubjectID.Text + "@" + lblSubjectName.Text + "@" +
                                    lblClassID.Text + "@" + lblClassName.Text + "@" + lblMarks.Text + "@" + lblYear.Text; ;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
    }
}
