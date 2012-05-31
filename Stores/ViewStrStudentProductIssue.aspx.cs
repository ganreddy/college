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
public partial class Stores_ViewStrStudentProductIssue : System.Web.UI.Page
{


    DataSet ds;
    BusinessLayer.StoresBL objStores = new StoresBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    BusinessLayer.StaffBL objStaff = new StaffBL();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
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
            ddlClass.DataSource = ds.Tables[0];
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetSection();
            ddlSection.DataSource = ds.Tables[0];
            ddlSection.DataTextField = "SectionName";
            ddlSection.DataValueField = "SectionID";
            ddlSection.DataBind();
            ddlSection.Items.Insert(0, new ListItem("---Select---", "0"));
           
        }
    }
    
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
        
    }
    public void fillStudent(int ClassID, int BatchID, int SectionID)
    {
        BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
        ds = new DataSet();
        ds = objStudComm.GetStudData(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            ddlStudent.DataSource = ds.Tables[0];
            ddlStudent.DataTextField = "FullName";
            ddlStudent.DataValueField = "StudID";
            ddlStudent.DataBind();
            ddlStudent.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
        
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
        
    }


    public void BindStudData()
    {
        ds = new DataSet();
        ds = objStores.GetStudentProductIssue(Convert.ToInt32(ddlStudent.Items[ddlStudent.SelectedIndex].Value));
        gdvStuData.DataSource = ds.Tables[0];
        gdvStuData.DataBind();
    }
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStudData();
    }
    protected void gdvStuData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;


        if (e.CommandName == "del")
        {

            i = objStores.DeleteStudentProductIssue(Convert.ToInt32(e.CommandArgument.ToString().Split('@')[0].ToString()), Convert.ToInt32(ddlStudent.Items[ddlStudent.SelectedIndex].Value), Convert.ToDateTime(e.CommandArgument.ToString().Split('@')[3].ToString()));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Student Product Issue deleted Successfully";
                BindStudData();
            }

        }
    }
    protected void gdvStuData_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gdvStuData.Rows)
        {
            Label lblProduct = new Label();
            Label lblItemName = new Label();
            Label lblQuantity = new Label();
            Label lblDateofIssue = new Label();
            LinkButton lnkDelete = new LinkButton();
            lblProduct = (Label)gvr.Cells[0].FindControl("lblProduct");
            lblItemName = (Label)gvr.Cells[1].FindControl("lblItemName");
            lblQuantity = (Label)gvr.Cells[2].FindControl("lblQuantity");
            lblDateofIssue = (Label)gvr.Cells[3].FindControl("lblDateofIssue");
            lnkDelete = (LinkButton)gvr.Cells[4].FindControl("lnkDelete");
            lnkDelete.CommandArgument =lblProduct.Text+"@"+ lblItemName.Text + "@" + lblQuantity.Text + "@" + lblDateofIssue.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm()");
        }
    }
}
