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
public partial class Staff_DefineStaffSal : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.StaffBL objStaff = new StaffBL();
    //int Header;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindStaffSalary();
            ds = objStaff.GetStaffHeader();
            ddlHeader.DataSource = ds.Tables[0];
            ddlHeader.DataTextField = "HeadName";
            ddlHeader.DataValueField = "HeadID";
            ddlHeader.DataBind();
            ddlHeader.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    public void bindStaffSalary()
    {
        ds = new DataSet();
        ds=objStaff.GetStaffSal();
        gdvStaffSalary.DataSource = ds.Tables[0];
        gdvStaffSalary.DataBind();
  
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int i = 0;
        try
        {           
            int Type, CalculationType,Header;
             
            string HeaderName;
            if (rdbAddition.Checked)            // In this Addition=1,Deduction=0   
                Type = 1;
            else
                Type = 0;
            if (rdbDirect.Checked)              // In this Direct Amount(Fixed Amount)=1,Percentage=0
                CalculationType = 1;
            else
                CalculationType = 0;
            HeaderName = txtHeadName.Text;
            Header = Convert.ToInt32(ddlHeader.Items[ddlHeader.SelectedIndex].Value);
            
            if (btnSave.Text == "Save")
            {
                if (rdbDirect.Checked==true)
                {
                    ddlHeader.Visible = false;
                    i = objStaff.AddStaffSalary(HeaderName, Type, CalculationType, 0, 0,1);                   
                }
                if (rdbPercentage.Checked==true)
                {

                    i = objStaff.AddStaffSalary(HeaderName, Type, CalculationType, Header, Convert.ToDecimal(txtPercentage.Text),1);   
                }
                if (i != 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Staff Salary Added Successfully";
                    txtPercentage.Text = "";
                    txtHeadName.Text = "";
                    ddlHeader.SelectedIndex = 0;
                    rdbAddition.Checked = false;
                    rdbDeduction.Checked = false;
                    rdbPercentage.Checked = false;
                    rdbDirect.Checked = false;
                    bindStaffSalary();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text =txtHeadName.Text + "Staff Head Name Already Exists";
                }
                
            }
            if (btnSave.Text == "Update")
            {
                if (rdbDirect.Checked == true)
                {

                    i = objStaff.UpdateStaffSalary(Convert.ToInt32(hdnHeadID.Value), HeaderName, Type, CalculationType, Header, 0);
                    
                }
                if (rdbPercentage.Checked == true)
                {
                   
                    i = objStaff.UpdateStaffSalary(Convert.ToInt32(hdnHeadID.Value), HeaderName, Type, CalculationType, Header, Convert.ToDouble (txtPercentage.Text));
                    
                }
                if (i > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Staff Salary Updated Successfully";
                    txtPercentage.Text = "";
                    txtHeadName.Text = "";
                    ddlHeader.SelectedIndex = 0;
                    rdbAddition.Checked = false;
                    rdbDeduction.Checked = false;
                    rdbPercentage.Checked = false;
                    rdbDirect.Checked = false;
                    bindStaffSalary();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text =txtHeadName.Text+ " Header Name Already Exixts";
                    
                }
                
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void rdbDirect_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbDirect.Checked)
        {
            ddlHeader.Visible = false;
            panel1.Visible = false;
        }
    }
    protected void rdbPercentage_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbPercentage.Checked == true)
        {
            ddlHeader.Visible = true;
            panel1.Visible = true;
        }
    }
    protected void gdvStaffSalary_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            panel1.Visible = true;
            
            hdnHeadID.Value =e.CommandArgument.ToString().Split('@')[0].ToString();
            txtHeadName.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            if (e.CommandArgument.ToString().Split('@')[2].ToString() == "Addition")
            {
                rdbAddition.Checked = true;
                rdbDeduction.Checked = false;
            }
            if (e.CommandArgument.ToString().Split('@')[2].ToString() == "Deduction")
            {
                rdbDeduction.Checked = true;
                rdbAddition.Checked = false;
            }
            if (e.CommandArgument.ToString().Split('@')[3].ToString() == "Percentage")
            {
                rdbPercentage.Checked = true;
                rdbDirect.Checked = false;
                ddlHeader.Visible = true;
            }
            if (e.CommandArgument.ToString().Split('@')[3].ToString() == "DirectAmount")
            {
                panel1.Visible = false;
                ddlHeader.Visible = false;
                rdbDirect.Checked = true;
                
            }
            txtPercentage.Text =e.CommandArgument.ToString().Split('@')[4].ToString();
            ddlHeader.SelectedValue = e.CommandArgument.ToString().Split('@')[5].ToString();
            btnSave.Text = "Update";
            lblMessage.Visible = false;
        }
        if (e.CommandName == "del")
        {
            //hdnHeadID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            //i = objStaff.DeleteStaffSalary(Convert.ToInt32(hdnHeadID.Value));
            hdnHeadID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            //ddlHeader.SelectedIndex =Convert.ToInt32(e.CommandArgument.ToString().Split('@')[5].ToString());
            ds = objStaff.GetStaffSalHeadByHeadID(Convert.ToInt32(hdnHeadID.Value));
            string HeadIds = getHeadids(ds);
            if (HeadIds != "")
            {
                HeadIds = HeadIds + "," + hdnHeadID.Value;
            }
            else
            {
                HeadIds = hdnHeadID.Value;
            }
            i = objStaff.DeleteStaffSalary(HeadIds);
                if (i != 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Staff Salary Deleted Successfully";
                    bindStaffSalary();
                }
        }

    }
    public string getHeadids(DataSet ds)
    {
        string Ids = String.Empty;
        int count = 0;
        DataSet dsTemp=new DataSet();
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (count == 0)
                    {
                        Ids = ds.Tables[0].Rows[i][0].ToString();
                        count++;
                    }
                    else
                    {
                        Ids = Ids + "," + ds.Tables[0].Rows[i][0].ToString();
                    }
                    dsTemp =  objStaff.GetStaffSalHeadByHeadID(Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString()));
                    if (dsTemp.Tables.Count > 0)
                    {
                        if (dsTemp.Tables[0].Rows.Count > 0)
                        {
                            Ids = Ids + "," + getHeadids(dsTemp);
                        }
                    }
                }
              
                

            }
        }
        return Ids;
    }
    protected void gdvStaffSalary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach(GridViewRow gvr in gdvStaffSalary.Rows)
        {
        Label lblHeadID = new Label();
        Label lblHeadName = new Label();
        Label lblType = new Label();
        Label lblCalculationType = new Label();
        Label lblPercentage = new Label();
        Label lblHeaderID = new Label();
       // Label lblHeaderName = new Label();
        LinkButton lnkEdit = new LinkButton();
        LinkButton lnkDelete = new LinkButton();
        lblHeadID = (Label)gvr.Cells[0].FindControl("lblHeadID");
        lblHeadName = (Label)gvr.Cells[1].FindControl("lblHeadName");
        lblType = (Label)gvr.Cells[2].FindControl("lblType");
        lblCalculationType = (Label)gvr.Cells[3].FindControl("lblCalculationType");
        lblPercentage = (Label)gvr.Cells[4].FindControl("lblPercentage");
        lblHeaderID = (Label)gvr.Cells[5].FindControl("lblHeaderID");
       // lblHeaderName = (Label)gvr.Cells[5].FindControl("lblHeaderName");
        lnkEdit = (LinkButton)gvr.Cells[6].FindControl("lnkEdit");
        lnkDelete = (LinkButton)gvr.Cells[7].FindControl("lnkDelete");
        //lnkEdit.CommandArgument = lblHeadID.Text + "@" + lblHeadName.Text + "@" + lblType.Text + "@" + lblCalculationType.Text + "@" + lblPercentage.Text + "@" + lblHeaderID.Text + "@" + lblHeaderName.Text;  
        lnkEdit.CommandArgument = lblHeadID.Text + "@" + lblHeadName.Text + "@" + lblType.Text + "@" + lblCalculationType.Text + "@" + lblPercentage.Text + "@" + lblHeaderID.Text;
        lnkDelete.CommandArgument = lblHeadID.Text + "@" + lblHeadName.Text + "@" + lblType.Text + "@" + lblCalculationType.Text + "@" + lblPercentage.Text + "@" + lblHeaderID.Text;
        lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");

        if (lblPercentage.Text == "0")
        {
            lblPercentage.Text = "NA";
        }
        }
    }
    protected void gdvStaffSalary_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvStaffSalary.PageIndex = e.NewPageIndex;
        bindStaffSalary();
    }
}
