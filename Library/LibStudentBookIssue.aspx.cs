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

public partial class LibraryModule_LibStudentBookIssue : System.Web.UI.Page
{
    BusinessLayer.LibraryBL objLib = new LibraryBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    BusinessLayer.StaffBL objStaff = new StaffBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        btnSave.Attributes.Add("onclick", "javascript:return RequiredValidate();");
        if (!IsPostBack)
        {
            ds = new DataSet();
            
            ds = objComm.GetBatch();
            ddlBatch.DataSource = ds.Tables[0];
            ddlBatch.DataTextField = "BatchNo";
            ddlBatch.DataValueField = "BatchID";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetClasses();
            ddlClasses.DataSource = ds.Tables[0];
            ddlClasses.DataTextField = "ClassName";
            ddlClasses.DataValueField = "ClassID";
            ddlClasses.DataBind();
            ddlClasses.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetSection();
            ddlSections.DataSource = ds.Tables[0];
            ddlSections.DataTextField = "SectionName";
            ddlSections.DataValueField = "SectionID";
            ddlSections.DataBind();
            ddlSections.Items.Insert(0, new ListItem("---Select---", "0"));
            txtIssueDate.Text =ChangeDateFormat(DateTime.Today.ToShortDateString());

        }
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        bindBooks();
    }
    public void bindBooks()
    {
        ds = new DataSet();
        ds = objLib.GetLibBooksbyAcessionNo(txtAccessionNo.Text);
        gdvLibBook.DataSource = ds.Tables[0];
        gdvLibBook.DataBind();
    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStudData();
    }
    protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStudData();
    }
    protected void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStudData();
    }
    public void BindStudData()
    {
        ds = new DataSet();
        ds = objStudComm.GetStudData(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value),
            Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value),
            Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
        ddlStudent.DataSource = ds.Tables[0];
        ddlStudent.DataTextField = "FullName";
        ddlStudent.DataValueField = "StudID";
        ddlStudent.DataBind();
        ddlStudent.Items.Insert(0,new ListItem("---Select---","0"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int BookID, RecieverID;
        DateTime IssueDate, DueDate;
        int i=0;
        RecieverID = Convert.ToInt32(ddlStudent.Items[ddlStudent.SelectedIndex].Value);
        IssueDate = Convert.ToDateTime(ChangeDateFormat(txtIssueDate.Text));
        DueDate = Convert.ToDateTime(ChangeDateFormat(txtDueDate.Text));
        foreach (GridViewRow gvr in gdvLibBook.Rows)
        {
            CheckBox chk = new CheckBox();
            Label lblBookID=new Label();
            lblBookID=(Label)gvr.Cells[0].FindControl("lblBookID");
            chk = (CheckBox)gvr.Cells[1].FindControl("chkBook");
            if (chk.Checked)
            {
                BookID = Convert.ToInt32(lblBookID.Text);
                i = objLib.LibraryBookIssue(BookID, 1, RecieverID, IssueDate, DueDate, 0);
                
            }
        }
        if (i > 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Book Issued Successfully";
            txtDueDate.Text = "";
            bindBooks();
        }
        //ddlBatch.SelectedIndex = 0;
        //ddlClasses.SelectedIndex = 0;
        //ddlSections.SelectedIndex = 0;
        //ddlStudent.SelectedIndex = 0;
        //txtAccessionNo.Text = "";
        //txtDueDate.Text = "";


     
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void gdvLibBook_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int id;
        DataSet ds = new DataSet();
        foreach (GridViewRow gvr in gdvLibBook.Rows)
        {
            CheckBox chk = new CheckBox();
            Label lblBookID = new Label();
            Label lblReturnStatus = new Label();
            Label lblIssuedTo = new Label();
            Label lblRecieverId = new Label();
            Label lblName=new Label();
            Label lblClass = new Label();
            lblBookID = (Label)gvr.Cells[0].FindControl("lblBookID");
            chk = (CheckBox)gvr.Cells[1].FindControl("chkBook");
            lblIssuedTo = (Label)gvr.Cells[4].FindControl("lblIssuedTo");
            lblRecieverId = (Label)gvr.Cells[5].FindControl("lblRecieverID");
            lblName = (Label)gvr.Cells[6].FindControl("lblName");
            lblClass = (Label)gvr.Cells[7].FindControl("lblClass");
            lblReturnStatus = (Label)gvr.Cells[8].FindControl("lblBookStatus");
            
            if (lblReturnStatus.Text == "0")
            {
                chk.Enabled = false;
                lblReturnStatus.Text = "Out of Library";
                if (lblIssuedTo.Text == "1")
                {
                    lblIssuedTo.Text = "Student";
                    id = Convert.ToInt32(lblRecieverId.Text);
                    ds = objStudComm.GetStudent(id);
                    lblName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                    lblClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                }
                if (lblIssuedTo.Text == "2")
                {
                    lblIssuedTo.Text = "Staff";
                    id = Convert.ToInt32(lblRecieverId.Text);
                    ds = objStaff.GetStaffDetails(id);
                    lblName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                    lblClass.Text = "NA";
                }
            }
            if (lblReturnStatus.Text == "1" || lblReturnStatus.Text == "")
            {
                chk.Enabled = true;
                lblReturnStatus.Text = "In Library";
                lblIssuedTo.Text = "NA";
                lblName.Text = "";
                lblClass.Text = "";
            }
            

        }

    }

    protected void gdvLibBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvLibBook.PageIndex = e.NewPageIndex;
        bindBooks();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlBatch.SelectedIndex = 0;
        ddlClasses.SelectedIndex = 0;
        ddlSections.SelectedIndex = 0;
        ddlStudent.SelectedIndex = 0;
        txtAccessionNo.Text = "";
        txtDueDate.Text = "";
    }
}
