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

public partial class Mess_ItemCalculation : System.Web.UI.Page
{
    BusinessLayer.MessBL objMess = new MessBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStud = new StudentAdmissionBL(); 
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        btnSave.Attributes.Add("onclick", "javascript:return validate();");
        txtQuantity1.Attributes.Add("onkeyup", "javascript:return calculation()");
        txtUnitCost1.Attributes.Add("onkeyup", "javascript:return calculation()");
        txtQuantity2.Attributes.Add("onkeyup", "javascript:return calculation()");
        txtUnitCost2.Attributes.Add("onkeyup", "javascript:return calculation()");
        txtQuantity3.Attributes.Add("onkeyup", "javascript:return calculation()");
        txtUnitCost3.Attributes.Add("onkeyup", "javascript:return calculation()");
        txtQuantity4.Attributes.Add("onkeyup", "javascript:return calculation()");
        txtUnitCost4.Attributes.Add("onkeyup", "javascript:return calculation()");
        txtLabourCost.Attributes.Add("onkeyup", "javascript:return calculation()");
        txtMisccellaneousCost.Attributes.Add("onkeyup", "javascript:return calculation()");
        if (!IsPostBack)
        { 
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ds = objMess.GetMessDishItemCalc();
            ddlDishName.DataSource = ds.Tables[0];
            ddlDishName.DataTextField = "DishName";
            ddlDishName.DataValueField = "DishID";
            ddlDishName.DataBind();
            ddlDishName.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objMess.GetItemByCategory(2);
            ddlItem1.DataSource = ds.Tables[0];
            ddlItem1.DataTextField = "ItemName";
            ddlItem1.DataValueField = "ItemId";
            ddlItem1.DataBind();
            ddlItem1.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objMess.GetItemByCategory(2);
            ddlItem2.DataSource = ds.Tables[0];
            ddlItem2.DataTextField = "ItemName";
            ddlItem2.DataValueField = "ItemId";
            ddlItem2.DataBind();
            ddlItem2.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objMess.GetItemByCategory(2);
            ddlItem3.DataSource = ds.Tables[0];
            ddlItem3.DataTextField = "ItemName";
            ddlItem3.DataValueField = "ItemId";
            ddlItem3.DataBind();
            ddlItem3.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objMess.GetItemByCategory(2);
            ddlItem4.DataSource = ds.Tables[0];
            ddlItem4.DataTextField = "ItemName";
            ddlItem4.DataValueField = "ItemId";
            ddlItem4.DataBind();
            ddlItem4.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objStud.GetStudentCount();
            lblAvailability.Visible = true;
            lblAvailability.Text = "Total Number Of Students:" + ds.Tables[0].Rows[0][0].ToString();
            lblAvailLeaves.Style.Add("display", "none");
            lblAvailLeaves.Text = ds.Tables[0].Rows[0][0].ToString();
            
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        int i=0;
        int DishName, ItemName = 0, Quantity;
        DateTime Date;
        decimal UnitPerCost, TotalCost, LabourCost, MiscellaneousCost, EntireTotalCost;
        Date = Convert.ToDateTime(ChangeDateFormat(txtDate.Text));
        DishName = Convert.ToInt32(ddlDishName.Items[ddlDishName.SelectedIndex].Value);
        LabourCost = Convert.ToDecimal(txtLabourCost.Text);
        MiscellaneousCost = Convert.ToDecimal(txtMisccellaneousCost.Text);
        EntireTotalCost = Convert.ToDecimal(txtEntireTotalCost.Text);
        try
        {
            if (txtQuantity1.Text != "")
            {
                ItemName = Convert.ToInt32(ddlItem1.Items[ddlItem1.SelectedIndex].Value);
                Quantity = Convert.ToInt32(txtQuantity1.Text);
                UnitPerCost = Convert.ToDecimal(txtUnitCost1.Text);
                TotalCost = Convert.ToDecimal(txtTotalCost1.Text);
                i = objMess.AddItemCalculation(Date, DishName, ItemName, Quantity, UnitPerCost, TotalCost, LabourCost, MiscellaneousCost, EntireTotalCost);
            }
            if (txtQuantity2.Text != "")
            {
                ItemName = Convert.ToInt32(ddlItem2.Items[ddlItem2.SelectedIndex].Value);
                Quantity = Convert.ToInt32(txtQuantity2.Text);
                UnitPerCost = Convert.ToDecimal(txtUnitCost2.Text);
                TotalCost = Convert.ToDecimal(txtTotalCost2.Text);
                i = objMess.AddItemCalculation(Date, DishName, ItemName, Quantity, UnitPerCost, TotalCost, LabourCost, MiscellaneousCost, EntireTotalCost);
            }
            if (txtQuantity3.Text != "")
            {
                ItemName = Convert.ToInt32(ddlItem3.Items[ddlItem3.SelectedIndex].Value);
                Quantity = Convert.ToInt32(txtQuantity3.Text);
                UnitPerCost = Convert.ToDecimal(txtUnitCost3.Text);
                TotalCost = Convert.ToDecimal(txtTotalCost3.Text);
                i = objMess.AddItemCalculation(Date, DishName, ItemName, Quantity, UnitPerCost, TotalCost, LabourCost, MiscellaneousCost, EntireTotalCost);
            }
            if (txtQuantity4.Text != "")
            {
                ItemName = Convert.ToInt32(ddlItem4.Items[ddlItem4.SelectedIndex].Value);
                Quantity = Convert.ToInt32(txtQuantity4.Text);
                UnitPerCost = Convert.ToDecimal(txtUnitCost4.Text);
                TotalCost = Convert.ToDecimal(txtTotalCost4.Text);
                i = objMess.AddItemCalculation(Date, DishName, ItemName, Quantity, UnitPerCost, TotalCost, LabourCost, MiscellaneousCost, EntireTotalCost);
            }
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Mess Item Added Successfully";
                ddlDishName.SelectedIndex = 0;
                ddlItem1.SelectedIndex = 0;
                ddlItem2.SelectedIndex = 0;
                ddlItem3.SelectedIndex = 0;
                ddlItem4.SelectedIndex = 0;
                txtQuantity1.Text = "";
                txtQuantity2.Text = "";
                txtQuantity3.Text = "";
                txtQuantity4.Text = "";
                txtUnitCost1.Text = "";
                txtUnitCost2.Text = "";
                txtUnitCost3.Text = "";
                txtUnitCost4.Text = "";
                txtTotalCost1.Text = "";
                txtTotalCost2.Text = "";
                txtTotalCost3.Text = "";
                txtTotalCost4.Text = "";
                txtLabourCost.Text = "";
                txtMisccellaneousCost.Text = "";
                txtEntireTotalCost.Text = "";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
}
