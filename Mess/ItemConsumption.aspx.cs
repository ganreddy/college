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

public partial class MessConsumption : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.MessBL objMess = new BusinessLayer.MessBL();
    BusinessLayer.CommonDataBL objComm = new BusinessLayer.CommonDataBL();
    DataTable dt = new DataTable();
    DataRow dRow;

    static int dtCount = 0;
    
       
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        if (!IsPostBack)
        {
            txtDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            ds = objComm.GetItem();
            ddlItemName.DataSource = ds.Tables[0];
            ddlItemName.DataTextField = "ItemName";
            ddlItemName.DataValueField = "ItemId";
            ddlItemName.DataBind();
            ddlItemName.Items.Insert(0, new ListItem("--Select--", "0"));
            ds = objComm.GetUOM();
            ddlUOM.DataSource = ds.Tables[0];
            ddlUOM.DataTextField = "UOMName";
            ddlUOM.DataValueField = "UOMID";
            ddlUOM.DataBind();
            ddlUOM.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    public void bindItemConsumption()
    {
            ds = new DataSet();
            ds = objMess.GetItemConsumption();
            gdvItemConsumption.DataSource = ds.Tables[0];
            gdvItemConsumption.DataBind();
        }
               
    
        protected void  gdvItemConsumption_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           // int i = 0;
                string strDate = txtDate.Text;
                if (e.CommandName == "del")
                {
                    int deleteRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                    //gdvItemConsumption.DeleteRow(deleteRowIndex);
                    dt = (DataTable)ViewState["table"]; 
                    dt.Rows[deleteRowIndex].Delete();
                    dtCount = dtCount - 1;
                    ViewState["table"] = dt;
                    gdvItemConsumption.DataSource = dt;
                    gdvItemConsumption.DataBind();
                   // i = objMess.DeleteItemConsumption(Convert.ToDateTime(ChangeDateFormat(strDate)), Convert.ToInt32(ddlItemName.Items[ddlItemName.SelectedIndex].Value), Convert.ToDecimal(e.CommandArgument.ToString().Split('@')[2]));
                 //   bindItemConsumption();
                }
        }
    protected void gdvItemConsumption_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int count = 0;
        foreach (GridViewRow gvr in gdvItemConsumption.Rows)
        {
            Label lblItemID = new Label();
            Label lblItemName = new Label();
            Label lblQuantity = new Label();
            Label UOM = new Label();
            Label UOMID = new Label();
            LinkButton lnkDelete = new LinkButton();
            lblItemID = (Label)gvr.Cells[0].FindControl("lblItemID");
            lblItemName = (Label)gvr.Cells[1].FindControl("lblItemName");
            UOMID = (Label)gvr.Cells[2].FindControl("UOMID");
            UOM = (Label)gvr.Cells[3].FindControl("UOMName");
            lblQuantity=(Label)gvr.Cells[4].FindControl("lblQuantity");
            lnkDelete = (LinkButton)gvr.Cells[5].FindControl("lnkDelete");
            lnkDelete.CommandArgument = count.ToString();;
           // lnkDelete.CommandArgument = lblItemID.Text + "@" + lblItemName.Text + "@" + lblQuantity.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
           // count = count + 1;
        }
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int i = 0;
        string strDate = txtDate.Text;
        try
        {
            foreach (GridViewRow gvr in gdvItemConsumption.Rows)
            {
                Label lblItemID = new Label();
                lblItemID = (Label)gvr.Cells[0].FindControl("lblItemID");
                Label lblQuantity = new Label();
                lblQuantity = (Label)gvr.Cells[4].FindControl("lblQuantity");
                Label UOMID = new Label();
                UOMID = (Label)gvr.Cells[2].FindControl("lblUOMID");
                Label lblUOM = new Label();
                lblUOM = (Label)gvr.Cells[3].FindControl("UOMName");

                i = objMess.AddItemConsumption(Convert.ToDateTime(ChangeDateFormat(strDate)), Convert.ToInt32(lblItemID.Text), Convert.ToDecimal(lblQuantity.Text), Convert.ToInt32(UOMID.Text));

            }
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Item Consumption Added Successfully";
                ddlItemName.SelectedIndex = 0;
                txtQuantity.Text = "";
                ddlUOM.SelectedIndex = 0;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataColumn ItemID = new DataColumn("ItemID", typeof(int));
        DataColumn ItemName = new DataColumn("ItemName", typeof(string));
        DataColumn UOMID = new DataColumn("UOMID", typeof(int));
        DataColumn UOMName = new DataColumn("UOMName", typeof(string));
        DataColumn Quantity = new DataColumn("Quantity", typeof(decimal));

        if (ViewState["table"] == null)
        {
            dt.Columns.Add(ItemID);
            dt.Columns.Add(ItemName);
            dt.Columns.Add(UOMID);
            dt.Columns.Add(UOMName);
            dt.Columns.Add(Quantity);
            dRow = dt.NewRow();
            dt.Rows.Add(dRow);

        }
        else
        {
            dt = (DataTable)ViewState["table"];
            dRow = dt.NewRow();
            dt.Rows.Add(dRow);
        }

        dt.Rows[dtCount][0] = ddlItemName.SelectedValue;
        dt.Rows[dtCount][1] = ddlItemName.SelectedItem.Text;
        dt.Rows[dtCount][2] = ddlUOM.SelectedValue;
        dt.Rows[dtCount][3] = ddlUOM.SelectedItem.Text;
        dt.Rows[dtCount][4] = Convert.ToDecimal(txtQuantity.Text);
        dtCount = dtCount + 1;
        ViewState["table"] = dt;
        gdvItemConsumption.DataSource = dt;
        gdvItemConsumption.DataBind();

    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }

    
}
  
     
