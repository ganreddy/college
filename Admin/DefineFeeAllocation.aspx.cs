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
using System.Data.SqlClient;
using BusinessLayer;

public partial class Admin_DefineFeeAllocation : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds;
    //HtmlTableRow tblRow;
    //HtmlTableCell tblCell;
    CheckBox chk;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        chklist.Attributes.Add("onclick", "javascript:return Show();");
        if (!IsPostBack)
        {
            for (int i = 1990; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = new DataSet();
            ds = objComm.GetClasses();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    chklist.RepeatColumns = 4;
                    chklist.DataSource = ds.Tables[0];
                    chklist.DataTextField = "ClassName";
                    chklist.DataValueField = "ClassID";
                    chklist.DataBind();
                    chklist.RepeatDirection = RepeatDirection.Horizontal;
                }
            }
            ds = objComm.GetFeeType(0);
            ddlFeeType.DataSource = ds.Tables[0];
            ddlFeeType.DataTextField = "FeeType";
            ddlFeeType.DataValueField = "FeeTypeID";
            ddlFeeType.DataBind();
            ddlFeeType.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetFeeCategory();
            ddlCategory.DataSource = ds.Tables[0];
            ddlCategory.DataTextField = "FeeCategory";
            ddlCategory.DataValueField = "FeeCategoryID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetGroups();
            ddlGropu.DataSource = ds.Tables[0];
            ddlGropu.DataTextField = "GroupName";
            ddlGropu.DataValueField = "GroupId";
            ddlGropu.DataBind();
            ddlGropu.Items.Insert(0, new ListItem("---Select---", "0"));  
            pnl.Style.Add("display", "none");
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        CheckBox chk;
        Label lblHeadID;
        TextBox txtAmount;
        int i = 0;
        foreach (ListItem litem in chklist.Items)
        {
            if (litem.Selected)
            {
                foreach (GridViewRow gvr in gdvFeeAlloc.Rows)
                {
                    chk = (CheckBox)gvr.Cells[0].FindControl("chkSelect");
                    lblHeadID = (Label)gvr.Cells[1].FindControl("lblHeadID");
                    txtAmount = (TextBox)gvr.Cells[2].FindControl("txtAmount");
                    if (chk.Checked)
                    {
                        i = objComm.AddFeeAllocation(Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value), Convert.ToInt32(litem.Value), Convert.ToInt32(ddlGropu.Items[ddlGropu.SelectedIndex].Value), Convert.ToInt32(lblHeadID.Text), Convert.ToDouble(txtAmount.Text), Convert.ToInt16(ddlCategory.Items[ddlCategory.SelectedIndex].Value), Convert.ToInt16(ddlFeeType.Items[ddlFeeType.SelectedIndex].Value));
                    }
                }
            }
        }
        if (i > 0)
        {
            string Msg, s = "";
            s = "Fee Added Successfully";
            Msg = "alert('" + s + "');";
            Msg = Msg = Msg + "location.href='../Admin/DefineFeeAllocation.aspx'";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);  
            //lblMessage.Visible = true;
            //lblMessage.Text="Fee Added Successfully";
        }
        else
        {
            string Msg, s = "";
            s = "Fee Already Exists";
            Msg = "alert('" + s + "');";
            Msg = Msg = Msg + "location.href='../Admin/DefineFeeAllocation.aspx'";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);

        }
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = objComm.GetFeeHeader(Convert.ToInt32(ddlFeeType.Items[ddlFeeType.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            gdvFeeAlloc.DataSource = ds.Tables[0];
            gdvFeeAlloc.DataBind();
        }
    }
}
