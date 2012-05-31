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
using System.Globalization;
using System.Text;
public partial class Stores_StrStaffProductIssue : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.StoresBL objStores = new StoresBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    BusinessLayer.StaffBL objStaff = new StaffBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", "javascript:return validation();");
        txtQuantity.Attributes.Add("onkeyup", "javascript:return calc()");
        txtRate.Attributes.Add("onkeyup", "javascript:return calc()");
        lblMsg.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = objStaff.GetStaffDetails(0);
            //ddlStaff.DataSource = ds.Tables[0];
            //ddlStaff.DataTextField = "FullName";
            //ddlStaff.DataValueField = "StaffID";
            //ddlStaff.DataBind();
            //ddlStaff.Items.Insert(0, new ListItem("---Select---", "0"));
            //ddlPurposeNewProcirement.Items.Insert(0, new ListItem("---Select---","0"));
            BindStaffData();
        }
        string dt = ChangeDateFormat(DateTime.Now.ToShortDateString());
        txtDateOfIsuue.Text  = dt.ToString(); 
    }
    protected void ddlCategoryNewProcirement_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = new DataSet();
        ds = objStores.GetItemsbyType(1, Convert.ToInt32(ddlPeriodicityNewProcirement.Items[ddlPeriodicityNewProcirement.SelectedIndex].Value), Convert.ToInt32(ddlCategoryNewProcirement.Items[ddlCategoryNewProcirement.SelectedIndex].Value));
        ddlProductNewProcirement.DataSource = ds.Tables[0];
        ddlProductNewProcirement.DataTextField = "ItemName";
        ddlProductNewProcirement.DataValueField = "ItemID";
        ddlProductNewProcirement.DataBind();
        ddlProductNewProcirement.Items.Insert(0, new ListItem("---Select---", "0"));
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
    public void BindStaffData()
    {
        ds = new DataSet();
        ds = objStaff.GetStaffDetails(0);
        gdvStaffData.DataSource = ds.Tables[0];
        gdvStaffData.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {         
        int count = 0;
        foreach (GridViewRow gvr in gdvStaffData.Rows)
        {
            int i;
            string strDateOfIssue = txtDateOfIsuue.Text;
            Label lblStaffID = new Label();
            Label lblFullName = new Label();
            CheckBox ChkAll = new CheckBox();
            ChkAll = (CheckBox)gvr.Cells[0].FindControl("ChkAll");
            lblStaffID = (Label)gvr.Cells[1].FindControl("lblStaffID");
            lblFullName = (Label)gvr.Cells[2].FindControl("lblFullName");
            if (ChkAll.Checked)
            {
                count = count + 1;
                i = objStores.AddStaffProductIssue(Convert.ToInt32(ddlProductNewProcirement.Items[ddlProductNewProcirement.SelectedIndex].Value), Convert.ToInt32(ddlPurposeNewProcirement.Items[ddlPurposeNewProcirement.SelectedIndex].Value), Convert.ToInt32(lblStaffID.Text), Convert.ToDecimal(txtRate.Text), Convert.ToDecimal(txtQuantity.Text), Convert.ToDecimal(txtAmount.Text), Convert.ToDateTime(ChangeDateFormat(strDateOfIssue)));
            }
        }
        if (count > 0)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Product Issue Added Successfully";
            BindStaffData();
            
            txtQuantity.Text = "";
            txtRate.Text = "";
            txtAmount.Text = "";
        }
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void gdvStaffData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvStaffData.PageIndex = e.NewPageIndex;
        BindStaffData();
    }
    protected void CheckSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckSelectAll.Checked == true)
        {
            foreach (GridViewRow gvr in gdvStaffData.Rows)
            {
                CheckBox chk = new CheckBox();
                CheckBox CheckAll = new CheckBox();
                CheckAll = (CheckBox)gvr.Cells[0].FindControl("ChkAll");
                CheckAll.Checked = CheckSelectAll.Checked;
            }
        }
        if (CheckSelectAll.Checked == false)
        {
            foreach (GridViewRow gvr in gdvStaffData.Rows)
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
        decimal i = 0;
        int Item = Convert.ToInt32(ddlProductNewProcirement.Items[ddlProductNewProcirement.SelectedIndex].Value);
        i = objStores.GetAvailableItems(Item);
        DataSet ds1 = new DataSet();
        ds1 = objStores.GetQuantityProcurred(Item);
        lblAvailableItems.Visible = true;
        lblAvailableItems.Text = "Available Items:";
        lblAvailability.Text = Convert.ToString(objStores.GetAvailableItems(Item));
        lblMeasurements.Visible = true;
        if (ds1.Tables.Count > 0)
        {
            if (ds1.Tables[0].Rows.Count > 0)
            {
                lblMeasurements.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
        }
    }
}
