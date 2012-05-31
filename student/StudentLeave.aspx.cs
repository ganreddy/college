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

public partial class StudentLeave : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new BusinessLayer.CommonDataBL();
    BusinessLayer.StudentAdmissionBL studAdm = new BusinessLayer.StudentAdmissionBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        //txtFrom.Text = ChangeDateFormat(DateTime.Now.ToShortDateString());
        if (!IsPostBack)
        {
            ds = objComm.GetBatch();
            ddlBatch.DataSource = ds.Tables[0];
            ddlBatch.DataTextField = "batchNo";
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
            ddlSection.DataSource = ds.Tables[0];
            ddlSection.DataTextField = "SectionName";
            ddlSection.DataValueField = "SectionID";
            ddlSection.DataBind();
            ddlSection.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = studAdm.GetHouseMaster();
            ddlhousemaster.DataSource=ds.Tables[0];
            ddlhousemaster.DataTextField="FullName";
            ddlhousemaster.DataValueField="StaffID";
            ddlhousemaster.DataBind();
            ddlhousemaster.Items.Insert(0,new ListItem("---Select---","0"));
            string  dt = DateTime.Now.Date.ToShortDateString().ToString()  ;
            txtFrom.Text = ChangeDateFormat(dt);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int i = 0;
        string strFromDate = txtFrom.Text;
        string strToDate = txtTo.Text;
        BusinessLayer.StudentAdmissionBL objStudComm = new BusinessLayer.StudentAdmissionBL();
        i = objStudComm.AddStudLeaves(Convert.ToInt32(ddlStudent.Items[ddlStudent.SelectedIndex].Value), Convert.ToDateTime(ChangeDateFormat(strFromDate)), Convert.ToDateTime(ChangeDateFormat(strToDate)), Convert.ToInt32(ddlhousemaster.Items[ddlhousemaster.SelectedIndex].Value), Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value), txtReason.Text);
        if (i > 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Student Leave Added Successfully";
            ddlStudent.SelectedIndex = 0;
            txtTo.Text = "";
            ddlhousemaster.SelectedIndex = 0;
            txtReason.Text = "";
            ddlBatch.SelectedIndex = 0;
            ddlClasses.SelectedIndex = 0;
            ddlSection.SelectedIndex = 0;
            ddlStudent.SelectedIndex = 0;
        }
    }
   
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
    }
    public void fillStudent(int ClassID, int BatchID, int SectionID)
    {
        BusinessLayer.StudentAdmissionBL objStudComm = new BusinessLayer.StudentAdmissionBL();
        ds = new DataSet();
        ds = objStudComm.GetStudData(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            ddlStudent.DataSource = ds.Tables[0];
            ddlStudent.DataTextField = "FullName";
            ddlStudent.DataValueField = "StudID";
            ddlStudent.DataBind();
            ddlStudent.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }


    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
    
    }
    protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
    
    }
}
