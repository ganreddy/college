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

public partial class StaffApplyForLoan : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.StaffBL objStaff = new StaffBL();
  protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", "javascript:return validate(); ");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        
        txtFirstInstallment.Attributes.Add("onkeyup", "javascript:return Calculation(); ");
        txtSecondInstallment.Attributes.Add("onkeyup", "javascript:return Calculation(); ");
        txtNoOfInstallments.Attributes.Add("onkeyup", "javascript:return Calculation(); ");
        txtRemainingInstallments.Attributes.Add("readonly", "readonly");
        lblMessage.Visible = false;
        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = objStaff.GetStaffDetails(0);
            ddlStaffName.DataSource = ds.Tables[0];
            ddlStaffName.DataTextField = "FullName";
            ddlStaffName.DataValueField = "StaffID";
            ddlStaffName.DataBind();
            ddlStaffName.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objStaff.GetLoanType();
            ddlLoanType.DataSource = ds.Tables[0];
            ddlLoanType.DataTextField = "LoanName";
            ddlLoanType.DataValueField = "LoanId";
            ddlLoanType.DataBind();
            ddlLoanType.Items.Insert(0, new ListItem("---Select---", "0"));    
            ds = objStaff.GetStaffDetails(0);
            //ddlAuthorizedBy.DataSource = ds.Tables[0];
            //ddlAuthorizedBy.DataTextField = "FullName";
            //ddlAuthorizedBy.DataValueField = "StaffID";
            //ddlAuthorizedBy.DataBind();
            //ddlAuthorizedBy.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }


  protected void btnSave_Click(object sender, EventArgs e)
  {
      int i=0;
     
      string Date = txtDate.Text;
      string strAmtRecovery = txtAmountRecoveryStartingDate.Text;
      ds = new DataSet();
      if (rbtnLoanFullyPaid.Checked)
      {
         i= objStaff.AddStaffApplyForLoan(Convert.ToInt32(ddlStaffName.Items[ddlStaffName.SelectedIndex].Value), Convert.ToInt32(ddlLoanType.Items[ddlLoanType.SelectedIndex].Value), Convert.ToDateTime(ChangeDateFormat(Date)), Convert.ToDecimal(txtAmountSanctioned.Text), Convert.ToInt32(txtNoOfInstallments.Text), Convert.ToDecimal(txtFirstInstallment.Text), Convert.ToDecimal(txtSecondInstallment.Text), Convert.ToDecimal(txtRemainingInstallments.Text), Convert.ToDateTime(ChangeDateFormat(strAmtRecovery)), Convert.ToInt32(ddlAuthorizedBy.Items[ddlAuthorizedBy.SelectedIndex].Value), 1, txtRemarksDescrption.Text,Convert.ToDateTime(ChangeDateFormat(txtAmountPaidDate.Text)));
         
      }
      if (rbtnNotfullypaid.Checked)
      {
         i= objStaff.AddStaffApplyForLoan(Convert.ToInt32(ddlStaffName.Items[ddlStaffName.SelectedIndex].Value), Convert.ToInt32(ddlLoanType.Items[ddlLoanType.SelectedIndex].Value), Convert.ToDateTime(ChangeDateFormat(Date)), Convert.ToDecimal(txtAmountSanctioned.Text), Convert.ToInt32(txtNoOfInstallments.Text), Convert.ToDecimal(txtFirstInstallment.Text), Convert.ToDecimal(txtSecondInstallment.Text), Convert.ToDecimal(txtRemainingInstallments.Text), Convert.ToDateTime(ChangeDateFormat(strAmtRecovery)), Convert.ToInt32(ddlAuthorizedBy.Items[ddlAuthorizedBy.SelectedIndex].Value), 3, txtRemarksDescrption.Text,Convert.ToDateTime(ChangeDateFormat(txtAmountPaidDate.Text)));
         
      }
      if (rbtnPartlypaid.Checked)
      {
          i = objStaff.AddStaffApplyForLoan(Convert.ToInt32(ddlStaffName.Items[ddlStaffName.SelectedIndex].Value), Convert.ToInt32(ddlLoanType.Items[ddlLoanType.SelectedIndex].Value), Convert.ToDateTime(ChangeDateFormat(Date)), Convert.ToDecimal(txtAmountSanctioned.Text), Convert.ToInt32(txtNoOfInstallments.Text), Convert.ToDecimal(txtFirstInstallment.Text), Convert.ToDecimal(txtSecondInstallment.Text), Convert.ToDecimal(txtRemainingInstallments.Text), Convert.ToDateTime(ChangeDateFormat(strAmtRecovery)), Convert.ToInt32(ddlAuthorizedBy.Items[ddlAuthorizedBy.SelectedIndex].Value), 2, txtRemarksDescrption.Text,Convert.ToDateTime(ChangeDateFormat(txtAmountPaidDate.Text)));
      }
      if (i > 0)
      {
          lblMessage.Visible = true;
          lblMessage.Text = "Staff Loan Added Successfully";
          ddlStaffName.SelectedIndex = 0;
          ddlLoanType.SelectedIndex = 0;
          txtDate.Text = "";
          txtAmountRecoveryStartingDate.Text = "";
          txtNoOfInstallments.Text = "";
          txtFirstInstallment.Text = "";
          txtSecondInstallment.Text = "";
          txtRemainingInstallments.Text = "";
          txtAmountSanctioned.Text = "";
          ddlAuthorizedBy.SelectedIndex = 0;
          rbtnLoanFullyPaid.Checked = false;
          rbtnNotfullypaid.Checked = false;
          rbtnPartlypaid.Checked = false;

      }
  }
  public string ChangeDateFormat(string Date)
  {
      return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
  }
}