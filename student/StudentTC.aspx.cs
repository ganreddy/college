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

public partial class student_StudentTC : System.Web.UI.Page
{

    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStud = new StudentAdmissionBL();
    DataSet ds = new DataSet();
    int StudId;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            
            ds = objcomm.GetBatch();
            ddlBatch.DataSource = ds.Tables[0];
            ddlBatch.DataTextField = "BatchNo";
            ddlBatch.DataValueField = "BatchID";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objcomm.GetClasses();
            ddlClasses.DataSource = ds.Tables[0];
            ddlClasses.DataTextField = "ClassName";
            ddlClasses.DataValueField = "ClassID";
            ddlClasses.DataBind();
            ddlClasses.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objcomm.GetSection();
            ddlSections.DataSource = ds.Tables[0];
            ddlSections.DataTextField = "SectionName";
            ddlSections.DataValueField = "SectionID";
            ddlSections.DataBind();
            ddlSections.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objcomm.GetClasses();
            ddllastClassStudied.DataSource = ds.Tables[0];
            ddllastClassStudied.DataTextField = "ClassName";
            ddllastClassStudied.DataValueField = "ClassID";
            ddllastClassStudied.DataBind();
            ddllastClassStudied.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objcomm.GetReasion();
            ddlReasion.DataSource = ds.Tables[0];
            ddlReasion.DataTextField = "Reason";
            ddlReasion.DataValueField = "ReasonID";
            ddlReasion.DataBind();
            ddlReasion.Items.Insert(0, new ListItem("---Select---", "0"));

            if (Request.QueryString["ID"] != null)
            {
                hdntransfer.Value = "1";
                StudId = Convert.ToInt32(Request.QueryString["ID"].ToString());
                ds = objStud.GetStdPersonaldetail(StudId);
                ddlBatch.SelectedValue = ds.Tables[0].Rows[0]["BatchID"].ToString();
                ddlClasses.SelectedValue = ds.Tables[0].Rows[0]["ClassID"].ToString();
                ddlSections.SelectedValue = ds.Tables[0].Rows[0]["SectionID"].ToString();
                ddlStudentID.SelectedValue = ds.Tables[0].Rows[0]["FullName"].ToString();
                txtAdmNo.Text = ds.Tables[0].Rows[0]["AdmissionNo"].ToString();
                txtName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                txtFatherName.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                //txtMotherName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
                if (ds.Tables[0].Rows[0]["CasteName"].ToString().ToUpper() == "ST" || ds.Tables[0].Rows[0]["CasteName"].ToString().ToUpper() == "SC")
                {
                    txtScheduled.Text = "Yes";
                }
                else
                {
                    txtScheduled.Text = "No";
                }
                txtDob.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
                ddllastClassStudied.SelectedValue = ds.Tables[0].Rows[0]["LastStudied"].ToString();
                txtSubjetStud.Text = ds.Tables[0].Rows[0]["Subjects"].ToString();
                txtTCNo.Text = ds.Tables[0].Rows[0]["TCNO"].ToString();
                //txtAnnualExam.Text = ds.Tables[0].Rows[0]["BoardExam"].ToString();
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Failed"].ToString()) == 0)
                {
                    rdbFailNo.Checked = true;
                }
                else if (Convert.ToInt32(ds.Tables[0].Rows[0]["Failed"].ToString()) == 1)
                {
                    rdbOnce.Checked = true;
                }
                else if (Convert.ToInt32(ds.Tables[0].Rows[0]["Failed"].ToString()) == 2)
                {
                    rdbTwice.Checked = true;
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["QualifiedforPromotion"].ToString()) == 0)
                {
                    RadioYes.Checked = true;
                }
                else if (Convert.ToInt32(ds.Tables[0].Rows[0]["QualifiedforPromotion"].ToString()) == 1)
                {
                    RadioNo.Checked = true;
                }
                txtmonthlypaid.Text = ds.Tables[0].Rows[0]["FeePaidMonth"].ToString();
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["FeeConcession"].ToString()) == 0)
                {
                    rdbFeeYes.Checked = true;
                }
                else if (Convert.ToInt32(ds.Tables[0].Rows[0]["FeeConcession"].ToString()) == 1)
                {
                    rdbFeeNo.Checked = true;
                }
                txtDateofAttendence.Text = ds.Tables[0].Rows[0]["LastAttendDate"].ToString();

                //txtnoofdays.Text = ds.Tables[0].Rows[0]["NoofSchoolDays"].ToString();
                //txtStuattendence.Text = ds.Tables[0].Rows[0]["NoofDaysAttended"].ToString();
                txtDateofapplication.Text = ds.Tables[0].Rows[0]["DateofApply"].ToString();
                txtdateofissuecer.Text = ds.Tables[0].Rows[0]["DateofIssue"].ToString();
                ddlReasion.SelectedValue = ds.Tables[0].Rows[0]["ReasonID"].ToString();
                //ddlReasion.SelectedValue = ds.Tables[0].Rows[0]["Reasion"].ToString();
                txtNcc.Text = ds.Tables[0].Rows[0]["Ncc"].ToString();
                txtExtraactivities.Text = ds.Tables[0].Rows[0]["Games"].ToString();
                txtConduct.Text = ds.Tables[0].Rows[0]["Conduct"].ToString();
                txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                pnlSearch.Visible = false;
                btnSave.Text = "Update";
            }
            else
            {
                hdntransfer.Value = "0";
            }


        }

    }
    public void fillStudent(int ClassID, int BatchID, int SectionID)
    {
        ds = new DataSet();
        ds = objStud.GetStudData(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            ddlStudentID.DataSource = ds.Tables[0];
            ddlStudentID.DataTextField = "FullName";
            ddlStudentID.DataValueField = "StudID";
            ddlStudentID.DataBind();
            ddlStudentID.Items.Insert(0, new ListItem("---Select---", "0"));
        }

    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }


    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {

        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
    }
    protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {

        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
    }
    protected void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
    {

        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
    }
    protected void ddlStudentID_SelectedIndexChanged(object sender, EventArgs e)
    {

        ds = objStud.GetStudent(Convert.ToInt32(ddlStudentID.Items[ddlStudentID.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtAdmNo.Text = ds.Tables[0].Rows[0]["AdmissionNo"].ToString();
                txtFatherName.Text = ds.Tables[0].Rows[0]["fathername"].ToString();
                txtDob.Text = ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).ToShortDateString());
                txtName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                txtAdmNo.Text = ds.Tables[0].Rows[0]["AdmissionNo"].ToString();
                //txtMotherName.Text = ds.Tables[0].Rows[0]["mothername"].ToString();
                //txtLastStudied.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                if (ds.Tables[0].Rows[0]["CasteName"].ToString().ToUpper() == "ST" || ds.Tables[0].Rows[0]["CasteName"].ToString().ToUpper() == "SC")
                    txtScheduled.Text = "Yes";
                else
                    txtScheduled.Text = "No";
            }
        }
        txtAdmNo.Enabled = false;
        txtFatherName.Enabled = false;
        txtDob.Enabled = false;
        txtName.Enabled = false;
        //txtMotherName.Enabled = false;
        txtScheduled.Enabled = false;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        int StudId, Failed = 0, QualifiedforPromotion = 0, FeeConcession = 0, NoofSchoolDays = 0, NoofDaysAttended = 0, LastStudied, Reason=0;
        string BoardExam, Subjects, FeePaidMonth,  Ncc, Games, Conduct, Remarks, TCNO;
        string LastAttendDate=string.Empty, DateofApply=string.Empty, DateofIssue=string.Empty;
       
            //LastAttendDate = txtDateofAttendence.Text;
        
           // DateofApply = txtDateofapplication.Text;
       
           // DateofIssue = txtdateofissuecer.Text;

        StudId = Convert.ToInt32(ddlStudentID.Items[ddlStudentID.SelectedIndex].Value);
        LastStudied = Convert.ToInt32(ddllastClassStudied.Items[ddllastClassStudied.SelectedIndex].Value);
        if (rdbFailNo.Checked) Failed = 0;
        if (rdbOnce.Checked) Failed = 1;
        if (rdbTwice.Checked) Failed = 2;
        if (RadioYes.Checked) QualifiedforPromotion = 1;
        if (RadioNo.Checked) QualifiedforPromotion = 0;
        if (rdbFeeNo.Checked) FeeConcession = 0;
        if (rdbFeeYes.Checked) FeeConcession = 1;
       // NoofSchoolDays = Convert.ToInt32(txtnoofdays.Text);
        //NoofDaysAttended = Convert.ToInt32(txtStuattendence.Text);
        TCNO = txtTCNo.Text;
        //BoardExam = txtAnnualExam.Text;
        Subjects = txtSubjetStud.Text;
        FeePaidMonth = txtmonthlypaid.Text;
        Reason = Convert.ToInt32(ddlReasion.Items[ddlReasion.SelectedIndex].Value);
        Ncc = txtNcc.Text;
        Games = txtExtraactivities.Text;
        Conduct = txtConduct.Text;
        
        Remarks = txtRemarks.Text;


        if (txtDateofAttendence.Text != "")
        {
            LastAttendDate = txtDateofAttendence.Text;
        }
        if (txtDateofapplication.Text != "")
        {
            DateofApply = ChangeDateFormat(ChangeDateFormat(txtDateofapplication.Text));
        }
        if (txtdateofissuecer.Text != "")
        {
            DateofIssue = ChangeDateFormat(ChangeDateFormat(txtdateofissuecer.Text));
        }

        if (Request.QueryString["ID"] == null)
        {

            int i = objStud.AddStudentTC(StudId, LastStudied,  Subjects, Failed, QualifiedforPromotion, FeePaidMonth, FeeConcession, LastAttendDate, DateofApply, DateofIssue, Reason, Ncc, Games, Conduct, Remarks, TCNO);

            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("EditStudentTC.aspx?ID=" + StudId.ToString());
            }
            else
            {
            Response.Redirect("EditStudentTC.aspx?ID=" + StudId + "");
            }

           // pnlSearch.Visible = true;

        }
        else
        {

            StudId = Convert.ToInt32(Request.QueryString["ID"].ToString());

            objStud.EditStudentTC(StudId, LastStudied,  Subjects, Failed, QualifiedforPromotion, FeePaidMonth, FeeConcession, LastAttendDate,  DateofApply, DateofIssue, Reason, Ncc, Games, Conduct, Remarks, TCNO);
            Response.Redirect("EditStudentTC.aspx?ID=" + StudId + "");
          //Response.Redirect("EditStaff.aspx?ID=" + StudId.ToString());
      

        }
        

        //if (i > 0)
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "Student Transfer Certificate Issued Successfully";
        //}
        //else
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "Student Transfer Certificate Already Exists";
        //}


    }
    
}

