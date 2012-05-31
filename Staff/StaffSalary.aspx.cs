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

public partial class Staff_StaffSalary : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.StaffBL objStaff = new StaffBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", "javascript:return validate();");
       lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
       if (!IsPostBack)
       {
           ds = objStaff.GetStaffDetails(0);
           ddlStaffId.DataSource = ds.Tables[0];
           ddlStaffId.DataTextField = "FullName";
           ddlStaffId.DataValueField = "StaffID";
           ddlStaffId.DataBind();
           ddlStaffId.Items.Insert(0, new ListItem("---Select---", "0"));
           bindStaffSal();
           
       }
    }
    
    private void bindStaffSal()
    {
        ds = new DataSet();
        ds = objStaff.GetStaffSal();
        gdvStaffSal.DataSource = ds.Tables[0];
        gdvStaffSal.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        int i = 0, j = 0, count = 0; string Msg, s = "";
        int StaffID;
        StaffID = Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value);
        DataSet dsDuplicates = new DataSet();
        CheckBox ChkAll = new CheckBox();
        Label lblHeadID = new Label();
        Label lblHeadName = new Label();
        Label lblCalculationType = new Label();
        Label lblPercentage = new Label();
        dsDuplicates = objStaff.GetDuplicateStaffSalaryByHeads(StaffID);
        TextBox txtAmt = new TextBox();
        if (dsDuplicates.Tables.Count > 0)
        {
            if (dsDuplicates.Tables[0].Rows.Count > 0)
            {
                foreach (GridViewRow gvr in gdvStaffSal.Rows)
                {
                    ChkAll = (CheckBox)gvr.Cells[0].FindControl("ChkAll");
                    lblHeadID = (Label)gvr.Cells[1].FindControl("lblHeadID");
                    lblHeadName = (Label)gvr.Cells[2].FindControl("lblHeadName");
                    lblCalculationType = (Label)gvr.Cells[3].FindControl("lblCalculationType");
                    lblPercentage = (Label)gvr.Cells[4].FindControl("lblPercentage");


                    if (ChkAll.Checked)
                    {
                        if (lblCalculationType.Text == "DirectAmount")
                        {

                            txtAmt = (TextBox)gvr.FindControl("txtAmount");
                            txtAmt.ID = "txtAmount";
                            txtAmt.Attributes.Add("onkeypress", "javascript:return validfloat(this,event);");
                            j = objStaff.UpdateStaffSalaryByHeads(StaffID, Convert.ToInt32(lblHeadID.Text), Convert.ToDecimal(txtAmt.Text));
                        }
                        else
                        {
                            j = objStaff.UpdateStaffSalaryByHeads(StaffID, Convert.ToInt32(lblHeadID.Text), -1);
                        }
                    }

                }
                if (j > 0)
                {
                    //s = "Staff Salary Updated Successfully";
                    lblMessage.Visible = true;
                    lblMessage.Text = "Staff Salary Updated Successfully";
                    ddlStaffId.SelectedIndex = 0;
                    txtAmt.Text = "";
                    ///Msg = "alert('" + s + "');";
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                }

            }
        }

        else
        {
            foreach (GridViewRow gvr in gdvStaffSal.Rows)
            {

                ChkAll = (CheckBox)gvr.Cells[0].FindControl("ChkAll");

                lblHeadID = (Label)gvr.Cells[1].FindControl("lblHeadID");

                lblHeadName = (Label)gvr.Cells[2].FindControl("lblHeadName");

                lblCalculationType = (Label)gvr.Cells[3].FindControl("lblCalculationType");

                lblPercentage = (Label)gvr.Cells[4].FindControl("lblPercentage");

                if (ChkAll.Checked)
                {
                    //if (dsDuplicates.Tables.Count > 0)
                    //{
                    //    if (dsDuplicates.Tables[0].Rows.Count > 0)
                    //    {
                    //        s = "Salary Already Exists To This Staff";
                    //    }
                    //}
                    //else
                    //{
                    if (lblCalculationType.Text == "DirectAmount")
                    {
                        txtAmt = (TextBox)gvr.FindControl("txtAmount");
                        txtAmt.ID = "txtAmount";
                        txtAmt.Attributes.Add("onkeypress", "javascript:return validfloat(this,event);");
                        i = objStaff.AddStaffSalaryByHead(StaffID, Convert.ToInt32(lblHeadID.Text), Convert.ToDecimal(txtAmt.Text));
                    }
                    else
                    {
                        i = objStaff.AddStaffSalaryByHead(StaffID, Convert.ToInt32(lblHeadID.Text), -1);
                    }
                }
            }
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Added Successfully";
                //s = "Staff Salary Added Successfully";
                ddlStaffId.SelectedIndex = 0;
                txtAmt.Text = "";
                //Msg = "alert('" + s + "');";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
            }

        }

        // }    

    }
    protected void dgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvStaffSal.Rows)
        {
            Label lblHeadID = new Label();
            lblHeadID = (Label)gvr.Cells[1].FindControl("lblHeadID");
            Label lblHeaderID = new Label();
            lblHeaderID = (Label)gvr.Cells[5].FindControl("lblHeaderID");
            Label lblHeaderName = new Label();
            lblHeaderName = (Label)gvr.Cells[5].FindControl("lblHeaderName");
            Label lblPercentage = new Label();
            lblPercentage = (Label)gvr.Cells[4].FindControl("lblPercentage");
            Label lblCalculationType = new Label();
            lblCalculationType = (Label)gvr.Cells[3].FindControl("lblCalculationType");
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (lblCalculationType.Text == "Percentage")
                {
                    lblPercentage.Text = lblPercentage.Text + "% of" + lblHeaderName.Text;
                }
            }
        }
        //TextBox txtAmt = (TextBox)e.Row.FindControl("txtAmount");
        //Label lblCalculationType = new Label();
        //lblCalculationType = (Label)e.Row.FindControl("lblCalculationType");
        //Label lblPer = (Label)e.Row.FindControl("lblPercentage");
        //if (lblCalculationType.Text == "DirectAmount")
        //{
        //    lblPer.Visible = false;
        //    txtAmt.Visible = true;
        //}
        //else
        //{
        //    txtAmt.Visible = false;
        //    lblPer.Visible = true;
        //}    

    }
    protected void gdvStaffSal_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvStaffSal.PageIndex = e.NewPageIndex;
        bindStaffSal();
    }
}
