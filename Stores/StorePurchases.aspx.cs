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
using System.Collections.Generic;
using BusinessLayer;

public partial class MessPurchases : System.Web.UI.Page
{
    BusinessLayer.StoresBL objStore = new StoresBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        btnCatSave.Attributes.Add("onclick", "javascript:return validation();");
        txtQuantityOpen.Attributes.Add("onkeyup", "javascript:return Calculation();");
        txtRateOpening.Attributes.Add("onkeyup", "javascript:return Calculation();");
        txtQuantityPurchase.Attributes.Add("onkeyup", "javascript:return Calculation();");
        txtAmountPurchase.Attributes.Add("onkeyup", "javascript:return Calculation();");
        txtQuantityConsumption.Attributes.Add("onkeyup", "javascript:return Calculation();");
        txtAmountConsumption.Attributes.Add("onkeyup", "javascript:return Calculation();");
        txtRatePurchase.Attributes.Add("onkeyup", "javascript:return Calculation();");
        txtRateTotal.Attributes.Add("onkeyup", "javascript:return Calculation();");
        txtRateConsumption.Attributes.Add("onkeyup", "javascript:return Calculation();");
        txtAmountConsumption.Attributes.Add("onkeyup", "javascript:return Calculation();");
        txtRateClosing.Attributes.Add("onkeyup", "javascript:return Calculation();");
        
        if (!IsPostBack)
        {
            for (int i = 1990; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            
            ds = objComm.GetStoreItem();
            ddlItem.DataSource = ds.Tables[0];
            ddlItem.DataTextField = "ItemName";
            ddlItem.DataValueField = "ItemId";
            ddlItem.DataBind();
            ddlItem.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlYear.Items.Insert(0, new ListItem("--Select--", "0"));  
        }
        
    
    }
    protected void btnCatSave_Click(object sender, EventArgs e)
    {
        int i = 0;
        int strMonth=Convert.ToInt32(ddlMonth.Items[ddlMonth.SelectedIndex].Value);
        int strYear=Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
        int strItemID=Convert.ToInt32(ddlItem.Items[ddlItem.SelectedIndex].Value);
        ds = new DataSet();
        if (txtQuantityClosing.Text != Convert.ToString(0) && txtAmountClosing.Text != Convert.ToString(0))
        {
             i = objStore.AddStorePurchases(Convert.ToInt32(strMonth), Convert.ToInt32(strYear), Convert.ToInt32(strItemID), Convert.ToDecimal(txtQuantityOpen.Text), Convert.ToDecimal(txtRateOpening.Text), Convert.ToDecimal(txtAmountOpening.Text), Convert.ToDecimal(txtQuantityPurchase.Text), Convert.ToDecimal(txtRatePurchase.Text), Convert.ToDecimal(txtAmountPurchase.Text), Convert.ToDecimal(txtQuantityConsumption.Text), Convert.ToDecimal(txtRateConsumption.Text), Convert.ToDecimal(txtAmountConsumption.Text), Convert.ToDecimal(txtQuantityClosing.Text), Convert.ToDecimal(txtRateClosing.Text), Convert.ToDecimal(txtAmountClosing.Text));
        }
        if (txtQuantityClosing.Text == Convert.ToString(0) && txtAmountClosing.Text == Convert.ToString(0))
        {
           i = objStore.AddStorePurchases(Convert.ToInt32(strMonth), Convert.ToInt32(strYear), Convert.ToInt32(strItemID), Convert.ToDecimal(txtQuantityOpen.Text), Convert.ToDecimal(txtRateOpening.Text), Convert.ToDecimal(txtAmountOpening.Text), Convert.ToDecimal(txtQuantityPurchase.Text), Convert.ToDecimal(txtRatePurchase.Text), Convert.ToDecimal(txtAmountPurchase.Text), Convert.ToDecimal(txtQuantityConsumption.Text), Convert.ToDecimal(txtRateConsumption.Text), Convert.ToDecimal(txtAmountConsumption.Text), Convert.ToDecimal(txtQuantityClosing.Text),  Convert.ToDecimal(0), Convert.ToDecimal(txtAmountClosing.Text));
        }
        if (i > 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Stores Purchases Added Successfully";
            ddlMonth.SelectedIndex = 0;
            ddlYear.SelectedIndex = 0;
            ddlItem.SelectedIndex = 0;
            txtQuantityOpen.Text = "";
            txtQuantityPurchase.Text = "";
            txtQuantityTotal.Text = "";
            txtQuantityConsumption.Text = "";
            txtQuantityClosing.Text = "";
            txtRateOpening.Text = "";
            txtRatePurchase.Text = "";
            txtRateTotal.Text = "";
            txtRateClosing.Text = "";
            txtAmountOpening.Text = "";
            txtAmountotal.Text = "";
            txtAmountPurchase.Text = "";
            txtAmountConsumption.Text = "";
            txtAmountClosing.Text = "";
            txtRateConsumption.Text = "";
        }
        


    }
    private void bindBalance()
    {
        ds = new DataSet();
        
        if (ddlMonth.SelectedIndex == 1)
        {
            int strMonth = Convert.ToInt32(ddlMonth.Items[ddlMonth.SelectedIndex].Value) + 11;
            int strYear = Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value) - 1;
            int strItemID = Convert.ToInt32(ddlItem.Items[ddlItem.SelectedIndex].Value);
            ds = objStore.GetStoreClosingBalance(strMonth, strYear, strItemID);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtQuantityOpen.Text = ds.Tables[0].Rows[0]["ClosingQuantity"].ToString();
                    txtRateOpening.Text = ds.Tables[0].Rows[0]["ClosingRate"].ToString();
                    txtAmountOpening.Text = ds.Tables[0].Rows[0]["ClosingAmt"].ToString();
                }
            }
        }
        else
        {
            int strMonth = Convert.ToInt32(ddlMonth.Items[ddlMonth.SelectedIndex].Value) - 1;
            int strYear = Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
            int strItemID = Convert.ToInt32(ddlItem.Items[ddlItem.SelectedIndex].Value);
            ds = objStore.GetStoreClosingBalance(strMonth, strYear, strItemID);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtQuantityOpen.Text = ds.Tables[0].Rows[0]["ClosingQuantity"].ToString();
                    txtRateOpening.Text = ds.Tables[0].Rows[0]["ClosingRate"].ToString();
                    txtAmountOpening.Text = ds.Tables[0].Rows[0]["ClosingAmt"].ToString();
                }
            }
        }
        
    }
    protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindBalance();
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindBalance();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindBalance();           
    }
}
  
     
