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

public partial class Stores_StrStudentProductIss : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.StoresBL objStores = new StoresBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick ", "javascript:return validation(); ");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        txtQuantity.Attributes.Add("onkeyup","javascript:return calc()");
        txtRate.Attributes.Add("onkeyup","javascript:return calc()");
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
        string dt =ChangeDateFormat( DateTime.Now.ToShortDateString());
        txtDateOfIsuue.Text = dt;  
        
    }
    protected void  ddlCategoryNewProcirement_SelectedIndexChanged(object sender, EventArgs e)
      {
            ds = new DataSet();
            ds = objStores.GetItemsbyType(1, Convert.ToInt32(ddlPeriodicityNewProcirement.Items[ddlPeriodicityNewProcirement.SelectedIndex].Value), Convert.ToInt32(ddlCategoryNewProcirement.Items[ddlCategoryNewProcirement.SelectedIndex].Value));
            ddlProductNewProcirement.DataSource = ds.Tables[0];
            ddlProductNewProcirement.DataTextField = "ItemName";
            ddlProductNewProcirement.DataValueField = "ItemID";
            ddlProductNewProcirement.DataBind();
            ddlProductNewProcirement.Items.Insert(0,new ListItem("---Select---","0"));
        if (ddlCategoryNewProcirement.SelectedIndex == 1)
        {
            trPurpose.Visible = false;
        }
        if (ddlCategoryNewProcirement.SelectedIndex == 2)
        {
            trPurpose.Visible = true;
            if (ddlPurposeNewProcirement.Items.Count > 0)   
            ddlPurposeNewProcirement.Items.Clear();
            ddlPurposeNewProcirement.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlPurposeNewProcirement.Items.Insert(1, new ListItem("Clothing", "1"));
            ddlPurposeNewProcirement.Items.Insert(2, new ListItem("OtherItems", "2"));  
        }
        if (ddlCategoryNewProcirement.SelectedIndex == 3)
        {
            trPurpose.Visible = true;
            if (ddlPurposeNewProcirement.Items.Count > 0)
            ddlPurposeNewProcirement.Items.Clear();
            ddlPurposeNewProcirement.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlPurposeNewProcirement.Items.Insert(1, new ListItem("Examination", "1"));
            ddlPurposeNewProcirement.Items.Insert(2, new ListItem("Office", "2"));
        }
      }

    protected void ddlPeriodicityNewProcirement_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = new DataSet();
        ds = objStores.GetItemsbyType(1, Convert.ToInt32(ddlPeriodicityNewProcirement.Items[ddlPeriodicityNewProcirement.SelectedIndex].Value), Convert.ToInt32(ddlCategoryNewProcirement.Items[ddlCategoryNewProcirement.SelectedIndex].Value));
        ddlProductNewProcirement.DataSource = ds.Tables[0];
        ddlProductNewProcirement.DataTextField = "ItemName";
        ddlProductNewProcirement.DataValueField = "ItemID";
        ddlProductNewProcirement.DataBind();
        ddlProductNewProcirement.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStudData();
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStudData();
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = new DataSet();
        ds = objStudComm.GetStudData(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value),
            Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value),
            Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvStuData.Visible = true;
                gdvStuData.DataSource = ds.Tables[0];
                gdvStuData.DataBind();
                CheckSelectAll.Visible = true;
                lblMessage.Visible = false;
                lblMessage.Text = "";
            }
            else
            {
                CheckSelectAll.Visible = false;
                gdvStuData.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = "No More Students In This Batch,Class,Section";
            }
        }
        //ds = new DataSet();
        //ds = objStudComm.GetStudData(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value),
        //    Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value),
        //    Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    CheckSelectAll.Visible = true;
        //    BindStudData();
        //    lblMessage.Text = "";
        //}
        //else
        //{
        //    CheckSelectAll.Checked = false;
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "No More Students in this Batch,Class,Section";
        //}
        
    }
    public void BindStudData()
    {
        ds = new DataSet();
        ds = objStudComm.GetStudData(Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value),
            Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value),
            Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value));
        gdvStuData.DataSource = ds.Tables[0];
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvStuData.Visible = true;
                gdvStuData.DataSource = ds.Tables[0];
                gdvStuData.DataBind();
                CheckSelectAll.Visible = true;
                lblMessage.Visible = false;
                lblMessage.Text = "";
            }
            else
            {
                CheckSelectAll.Visible = false;
                gdvStuData.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = "No More Students In This Batch,Class,Section";
            }
        }
        
       // gdvStuData.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        decimal j = 0;
        int count = 0;
        int Item = Convert.ToInt32(ddlProductNewProcirement.Items[ddlProductNewProcirement.SelectedIndex].Value); 
        j = objStores.GetAvailableItems(Item);
        lblAvailableItems.Visible = true;
        lblAvailableItems.Text = "Available Items:";
        lblAvailability.Text = Convert.ToString(objStores.GetAvailableItems(Item));
        int quantity = Convert.ToInt32(txtQuantity.Text);       
        foreach (GridViewRow gvrs in gdvStuData.Rows)
           {
                int i;
                string strDateOfIssue = txtDateOfIsuue.Text;
                Label lblStudID = new Label();             
                Label lblFullName = new Label();
                CheckBox ChkAll = new CheckBox();
                ChkAll = (CheckBox)gvrs.Cells[0].FindControl("ChkAll");               
                lblStudID = (Label)gvrs.Cells[1].FindControl("lblStudID");
                lblFullName = (Label)gvrs.Cells[2].FindControl("lblFullName");
                if (ChkAll.Checked)
                    {
                        count = count + 1;
                        i = objStores.AddStudProductIssue(Convert.ToInt32(ddlProductNewProcirement.Items[ddlProductNewProcirement.SelectedIndex].Value), Convert.ToInt32(ddlPurposeNewProcirement.Items[ddlPurposeNewProcirement.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value), Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value), Convert.ToInt32(lblStudID.Text), Convert.ToDecimal(txtRate.Text), Convert.ToInt32(txtQuantity.Text), Convert.ToDecimal(txtAmount.Text), Convert.ToDateTime(ChangeDateFormat(strDateOfIssue)));
                    }
                }
         
              if (count > 0)
              {
                  lblMessage.Visible = true;
                  lblMessage.Text = "Student Product Issue Record Added Successfully";
                  //BindStudData();
                  ddlPeriodicityNewProcirement.SelectedIndex = 0;
                  ddlCategoryNewProcirement.SelectedIndex = 0;
                  ddlProductNewProcirement.SelectedIndex = 0;
                  ddlPurposeNewProcirement.SelectedIndex = 0;
                  ddlBatch.SelectedIndex = 0;
                  ddlClass.SelectedIndex = 0;
                  ddlSection.SelectedIndex = 0;
                  txtDateOfIsuue.Text = "";
                  txtQuantity.Text = "";
                  txtRate.Text = "";
                  txtAmount.Text = "";
                  
              }       
    }   
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void CheckSelectAll_CheckedChanged(object sender, EventArgs e)
    {     
        if (CheckSelectAll.Checked==true)
        {
            foreach (GridViewRow gvr in gdvStuData.Rows)
            {              
                 CheckBox chk = new CheckBox();
                 CheckBox CheckAll = new CheckBox();
                 CheckAll = (CheckBox)gvr.Cells[0].FindControl("ChkAll");
                 CheckAll.Checked = CheckSelectAll.Checked;             
            }
        }
        if (CheckSelectAll.Checked==false)
        {
            foreach (GridViewRow gvr in gdvStuData.Rows)
            {
                CheckBox chk = new CheckBox();
                CheckBox CheckAll = new CheckBox();
                CheckAll = (CheckBox)gvr.Cells[0].FindControl("ChkAll");
                CheckAll.Checked = CheckSelectAll.Checked;
            }
        }       
    }
    protected void ddlProductNewProcirement_SelectedIndexChanged(object sender, EventArgs e)
    {
//        int i = 0;
        int Item = Convert.ToInt32(ddlProductNewProcirement.Items[ddlProductNewProcirement.SelectedIndex].Value);  
        DataSet ds1 = new DataSet();
        ds1 = objStores.GetQuantityProcurred(Item);
        lblAvailableItems.Visible = true;
        lblAvailableItems.Text = "Available Items:";
        lblAvailability.Text = Convert.ToString(objStores.GetAvailableItems(Item));      
        if (ds1.Tables.Count > 0)
        {
            if (ds1.Tables[0].Rows.Count > 0)
            {
                lblMeasurements.Visible=true;
                lblMeasurements.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
        }
    }
    protected void gdvStuData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvStuData.PageIndex = e.NewPageIndex;
        BindStudData();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }
}

