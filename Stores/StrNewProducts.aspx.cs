using System;
using System.Data;
using System.Data.SqlClient ;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BusinessLayer;

public partial class StrNewProducts : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.StoresBL objStores = new StoresBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", "javascript:return validate(); ");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        txtProductItemRateNewProcirement.Attributes.Add("onkeyup","javascript:return CalcAmount();");
        txtQuantityProcurredNewProcirement.Attributes.Add("onkeyup", "javascript:return CalcAmount();");     
    }
    protected void ddlCategoryNewProcirement_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = new DataSet();
        ds = objStores.GetItemsbyType(1, Convert.ToInt32(ddlPeriodicityNewProcirement.Items[ddlPeriodicityNewProcirement.SelectedIndex].Value), Convert.ToInt32(ddlCategoryNewProcirement.Items[ddlCategoryNewProcirement.SelectedIndex].Value));
        ddlProductNewProcirement.DataSource = ds.Tables[0];
        ddlProductNewProcirement.DataTextField = "ItemName";
        ddlProductNewProcirement.DataValueField = "ItemID";
        ddlProductNewProcirement.DataBind();
        ddlProductNewProcirement.Items.Insert(0,new ListItem("---Select---","0"));
        if (ddlCategoryNewProcirement.SelectedIndex == 1 || ddlCategoryNewProcirement.SelectedIndex == 0)
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
            ddlPurposeNewProcirement.Items.Insert(2, new ListItem("Other Items", "2"));
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int Periodicity,Category,Purpose=0,Item,i=0;
        decimal ItemRate, Quant, Amt;
        DateTime Supdate, DateofOrder, DateofDel, PACDate;
        Periodicity = Convert.ToInt32(ddlPeriodicityNewProcirement.Items[ddlPeriodicityNewProcirement.SelectedIndex].Value);
        Category = Convert.ToInt32(ddlCategoryNewProcirement.Items[ddlCategoryNewProcirement.SelectedIndex].Value);
        if(Category==2 || Category==3)
        Purpose = Convert.ToInt32(ddlPurposeNewProcirement.Items[ddlPurposeNewProcirement.SelectedIndex].Value);
        Item = Convert.ToInt32(ddlProductNewProcirement.Items[ddlProductNewProcirement.SelectedIndex].Value);
        ItemRate = Convert.ToDecimal(txtProductItemRateNewProcirement.Text);
        Quant = Convert.ToDecimal(txtQuantityProcurredNewProcirement.Text);
        Amt = Convert.ToDecimal(txtAmountNewProcirement.Text);
        Supdate = Convert.ToDateTime(ChangeDateFormat(txtSupplyDelveryDateNewProcirement.Text));
        DateofOrder = Convert.ToDateTime(ChangeDateFormat(txtDateOfOrderNewProcirement.Text));
        DateofDel = Convert.ToDateTime(ChangeDateFormat(txtDateOfDeliveryatJNVNewProcirement.Text));
        PACDate = Convert.ToDateTime(ChangeDateFormat(txtPurchaseAdvisoryCommitteeNewProcirement.Text));
        i = objStores.AddStoreNewProcurement(Item,Purpose, ItemRate, Quant, Amt, Supdate, DateofOrder, DateofDel, PACDate);
        if (i > 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "New Procurement Record Added Successfully";
            ddlPeriodicityNewProcirement.SelectedIndex =0;
            ddlCategoryNewProcirement.SelectedIndex = 0;
            ddlPurposeNewProcirement.SelectedIndex = 0;
            ddlProductNewProcirement.SelectedIndex = 0;
            txtProductItemRateNewProcirement.Text = " ";
            txtQuantityProcurredNewProcirement.Text = " ";
            txtAmountNewProcirement.Text = " ";
            txtSupplyDelveryDateNewProcirement.Text = " ";
            txtDateOfOrderNewProcirement.Text = " ";
            txtDateOfDeliveryatJNVNewProcirement.Text = " ";
            txtPurchaseAdvisoryCommitteeNewProcirement.Text = " ";
        }
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void ddlProductNewProcirement_SelectedIndexChanged1(object sender, EventArgs e)
    {
        decimal i = 0;
        ds = new DataSet();
        int Item = Convert.ToInt32(ddlProductNewProcirement.Items[ddlProductNewProcirement.SelectedIndex].Value);
        i = objStores.GetAvailableItems(Item);
        ds = objStores.GetQuantityProcurred(Convert.ToInt32(ddlProductNewProcirement.Items[ddlProductNewProcirement.SelectedIndex].Value));
        lblAvailableItems.Visible = true;
        lblAvailableItems.Text = "Available Items:";
        lblAvailability.Text = Convert.ToString(objStores.GetAvailableItems(Item));
        lblMeasurements.Visible = true;       
         if (ds.Tables.Count > 0)
          {
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMeasurement.Text = ds.Tables[0].Rows[0]["UOMName"].ToString();
                lblMeasurements.Text = ds.Tables[0].Rows[0]["UOMName"].ToString();
            }
           
         }   
    }
    
}
