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

public partial class student_EditStudentAttendance : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAttendance.Attributes.Add("onclick", "javascript:return validation();");
       // btnAttendance.Attributes.Add("onclick", "javascript:return Checkvalidation();");
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
            for (int i = 2005; i <= 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));

            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
            //ddlYear.SelectedValue = DateTime.Today.Year.ToString();
           // ddlMonth.SelectedValue = DateTime.Today.Month.ToString();
        }
    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindAttendance();
    }
    protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindAttendance();
    }
    protected void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindAttendance();

    }
    public void bindAttendance()
    {
        ds = new DataSet();
        int month=Convert.ToInt32(ddlMonth.Items[ddlMonth.SelectedIndex].Value);
        int year=Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
        ds = objStudComm.GetStudentAttendanceData(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value),
            Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value),
            Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value),month,year);

        gdvStuAttenance.DataSource = ds.Tables[0];
        gdvStuAttenance.DataBind();

    }
    protected void btnAttendance_Click(object sender, EventArgs e)
    {
        bindAttendance();
    }
    protected void gdvStuAttenance_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gdvStuAttenance.EditIndex = e.NewEditIndex;
        bindAttendance();
    }
    protected void gdvStuAttenance_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int i = 0;
        Label lblStudID = new Label();
        lblStudID = (Label)gdvStuAttenance.Rows[e.RowIndex].Cells[0].FindControl("lblStudID");
        Label lblNoOfDaysPresents = new Label();
        lblNoOfDaysPresents = (Label)gdvStuAttenance.Rows[e.RowIndex].Cells[2].FindControl("lblNoOfDaysPresents");
        TextBox txtNoOfDaysPresents = new TextBox();
        txtNoOfDaysPresents = (TextBox)gdvStuAttenance.Rows[e.RowIndex].Cells[2].FindControl("txtNoOfDaysPresents");
        i = objStudComm.UpdateStudentAttendance(Convert.ToInt32(lblStudID.Text), Convert.ToInt32(txtNoOfDaysPresents.Text));
        lblMessage.Visible = true;
        lblMessage.Text = "Student Attendance Updated Successfully";
        gdvStuAttenance.EditIndex = -1;
        bindAttendance();

    }
    protected void gdvStuAttenance_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gdvStuAttenance.EditIndex = -1;
        bindAttendance();
    }
    protected void gdvStuAttenance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvStuAttenance.PageIndex = e.NewPageIndex;
        bindAttendance();
    }
}
