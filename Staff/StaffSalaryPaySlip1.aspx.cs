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
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using BusinessLayer;
using System.Text;

public partial class Staff_StaffSalaryPaySlip : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.StaffBL objStaff = new StaffBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnPrint.Attributes.Add("onclick", "javascript:return printDiv();");
        btnSave.Attributes.Add("onclick", "javascript:return validate();");
        btnGetPaySlip.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            ds = objStaff.GetStaff(0);
            ddlStaffId.DataSource = ds.Tables[0];
            ddlStaffId.DataTextField = "FullName";
            ddlStaffId.DataValueField = "StaffID";
            ddlStaffId.DataBind();
            ddlStaffId.Items.Insert(0, new ListItem("---Select---", "0"));
            for (int i = 2000; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlYear.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    //protected void ddlStaffId_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataSet dsData = new DataSet();
    //    int staffid =Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value);
    //    decimal basic = 0;
    //    int NoOfWorkingDays;

    //    dsData = objStaff.GetStaffSalaryPaySlip(staffid);
    //    decimal netAmt=0;
    //    decimal BasicAmount=0;
    //    if (dsData.Tables.Count > 0)
    //    {
    //        if (dsData.Tables[0].Rows.Count > 0)
    //        {
    //            basic = Convert.ToDecimal(dsData.Tables[0].Rows[0]["Amount"]);
    //            NoOfWorkingDays = Convert.ToInt32(dsData.Tables[0].Rows[0]["NoOfWorkingDays"]);
    //            BasicAmount = (basic) / 30 * NoOfWorkingDays;
    //           // netAmt = Convert.ToDecimal(netAmt) + (BasicAmount);
    //            System.Text.StringBuilder strPaySlip = new System.Text.StringBuilder();
    //            System.Text.StringBuilder strNetAmount = new System.Text.StringBuilder();
    //            strPaySlip.Append("<table border='1' align='center' width='50%'>");
    //            //strPaySlip.Append("<tr><td colspan='2' align='center'>" + staffid.ToString() + "</td></tr>");
    //            strPaySlip.Append("<tr><th>Name</th><th>Addtion/Deduction</th><th>BasicPay</th><th>Rate Of Pay</th><th>Gross</th><th>Net Payable</th><th>Basic+DA</th></tr>");
    //            strNetAmount.Append("<table border='1' align='center'>"); 
    //            strNetAmount.Append("<tr><td colspan='2' align='center'>" + "Net Amount" + "</td></tr>");
           
    //            foreach (DataRow dr in dsData.Tables[0].Rows)
    //            {
                    
    //              //  strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>" + ((Convert.ToDecimal(dr["Percentage"]) / 100) * basic) + "</td></tr>");

    //                if (dr["HeaderID"].ToString() == "0" && dr["Type"].ToString() == "1" )
    //                {
    //                    //strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>Addition</td><td>" +Convert.ToDecimal(Convert.ToDecimal(dr["Amount"]).ToString()) + "</td><td>"+dr["Amount"].ToString()+"</td></tr>");                        
    //                    strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>Addition</td><td>" + ((Convert.ToDecimal(dr["Amount"]) / 30) * Convert.ToInt32(dr["NoOfWorkingDays"])) + "</td><td>" + dr["Amount"].ToString() + "</td><td>" + (BasicAmount) + "</td><td>" + (BasicAmount) + "</td><td>" + (BasicAmount) + "</td></tr>");                        
    //                   //strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>" + "Addition" + "</td><td>" + dr["Amount"].ToString() + "</td></tr>");
    //                    //netAmt =Convert.ToDecimal(netAmt) + Convert.ToDecimal(Convert.ToDecimal(dr["Amount"]).ToString());
    //                    netAmt = Convert.ToDecimal(netAmt) + (BasicAmount);      
    //                }
    //                else
    //                {
    //                    if (dr["Type"].ToString() == "1")
    //                    {
    //                        strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>Addition</td><td>" + ((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount) + "</td><td>" + (basic) + "</td><td>" + ((netAmt) + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount)) + "</td><td>" + ((netAmt) + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount)) + "</td><td>" + (netAmt) + "</td></tr>");
    //                       // netAmt = Convert.ToDecimal(netAmt) + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount);
    //                        //netAmt = Convert.ToDecimal(netAmt) + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount);
    //                        netAmt = (netAmt) + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount);

    //                    }
    //                    else
    //                    {
    //                        strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>Deduction</td><td>" + ((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount) + "</td><td>" + (basic) + "</td><td>" + "---" + "</td><td>" + ((netAmt) - Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount)) + "</td><td>" + "---" + "</td></tr>");
    //                      // netAmt = Convert.ToDecimal(netAmt) - Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount);
                            
    //                    }
    //                    //strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>" + "Deduction" + "</td><td>" + ((Convert.ToDecimal(dr["Percentage"]) / 100) * basic) + "</td></tr>");
    //                }
                    
    //            }
    //            strNetAmount.Append("<tr><td>" +Convert.ToDecimal(netAmt) + "</td></tr>");
                
    //            strPaySlip.Append("</table>");
    //            strPaySlip.Append("</br>");
    //            strNetAmount.Append("</table>");
    //            dvNetAmount.InnerHtml = strNetAmount.ToString();
    //           // dvNetAmount.InnerHtml = netAmt.ToString();
    //            dvPaySlip.InnerHtml = strPaySlip.ToString();
    //        }
    //    }
        
    //    //finally write the content into div        
       
    //}
    protected void btnSave_Click(object sender, EventArgs e)
    {
      int i;
      int j = 0;
      decimal basic = 0;
      int NoOfWorkingDays;
      int staffid = Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value);
      int Month=Convert.ToInt32(ddlMonth.Items[ddlMonth.SelectedIndex].Value);
      int Year = Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
      DataSet dsData = new DataSet();
      decimal netAmt = 0;
      decimal BasicAmount = 0;
      dsData = objStaff.GetStaffSalaryPaySlip(staffid);
      
     
      if (dsData.Tables.Count > 0)
      {
          if (dsData.Tables[0].Rows.Count > 0)
          {
              basic = Convert.ToDecimal(dsData.Tables[0].Rows[0]["Amount"]);
              NoOfWorkingDays =Convert.ToInt32(txtNoOfWorkingDays.Text);
              BasicAmount = (basic) / 30 * NoOfWorkingDays;
              System.Text.StringBuilder strPaySlip = new System.Text.StringBuilder();
              
                  foreach (DataRow dr in dsData.Tables[0].Rows)
                  {
                      if (dr["HeaderID"].ToString() == "0" && dr["Type"].ToString() == "1")
                      {
                          netAmt = Convert.ToDecimal(netAmt) + (BasicAmount);
                          i = objStaff.TotalStaffSalPaySlip(staffid, Month, Year, Convert.ToInt32(dr["HeadID"]), Convert.ToInt32(dr["Type"]), BasicAmount, NoOfWorkingDays);
                      }

                      else
                      {
                          if (dr["Type"].ToString() == "1")
                          {
                              strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>" + ((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount) + "</td><td>" + (basic) + "</td><td>" + ((netAmt) + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount)) + "</td><td>" + ((netAmt) + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount)) + "</td></tr>");
                              netAmt = (netAmt) + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount);
                              i = objStaff.TotalStaffSalPaySlip(staffid, Month, Year, Convert.ToInt32(dr["HeadID"]), Convert.ToInt32(dr["Type"]), (Convert.ToDecimal(dr["Percentage"]) / 100 * BasicAmount), NoOfWorkingDays);
                          }

                          else
                          {
                              if (((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount) > 780)
                              {
                                  strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>" + ((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount) + "</td><td>" + (basic) + "</td><td>" + "---" + "</td><td>" + ((netAmt) - Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount)) + "</td></tr>");
                                  netAmt = Convert.ToDecimal(netAmt) - Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount);
                                  i = objStaff.TotalStaffSalPaySlip(staffid, Month, Year, Convert.ToInt32(dr["HeadID"]), Convert.ToInt32(dr["Type"]), 780, NoOfWorkingDays);
                              }
                              else
                              {
                                  strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>" + ((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount) + "</td><td>" + (basic) + "</td><td>" + "---" + "</td><td>" + ((netAmt) - Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount)) + "</td></tr>");
                                  netAmt = Convert.ToDecimal(netAmt) - Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount);
                                  i = objStaff.TotalStaffSalPaySlip(staffid, Month, Year, Convert.ToInt32(dr["HeadID"]), Convert.ToInt32(dr["Type"]), (Convert.ToDecimal(dr["Percentage"]) / 100 * BasicAmount), NoOfWorkingDays);
                              }
                          }
                          lblMessage.Visible = true;
                          lblMessage.Text = "Staff PaySlip Added Successfully";
                          // i = objStaff.TotalStaffSalPaySlip(staffid, Month, Year, Convert.ToInt32(dr["HeadID"]), Convert.ToInt32(dr["Type"]), (Convert.ToDecimal(dr["Percentage"]) / 100 * BasicAmount), NoOfWorkingDays);
                      }
                 
              }
             
          }
      }


     
    }
    protected void btnGetPaySlip_Click(object sender, EventArgs e)
    {
        
        
        DataSet dsData = new DataSet();
        int staffid = Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value);
        decimal basic = 0;
        int NoOfWorkingDays = Convert.ToInt32(txtNoOfWorkingDays.Text); 

        dsData = objStaff.GetStaffSalaryPaySlip(staffid);
        Session["Dataset"] = dsData;
        Session["NoOfWorkingDays"] = txtNoOfWorkingDays.Text;
        //Response.Redirect("Sessioninpayslip.aspx");
       
        decimal netAmt = 0;
        decimal netAmt1 = 0;
        
        int Val = 780;
        string Const = Val.ToString("N2");
         
        decimal BasicAmount = 0;
        if (dsData.Tables.Count > 0)
        {
            if (dsData.Tables[0].Rows.Count > 0)
            {
                basic = Convert.ToDecimal(dsData.Tables[0].Rows[0]["Amount"]);
                NoOfWorkingDays = Convert.ToInt32(txtNoOfWorkingDays.Text);
                BasicAmount = (basic) / 30 * NoOfWorkingDays;
                // netAmt = Convert.ToDecimal(netAmt) + (BasicAmount);
                System.Text.StringBuilder strPaySlip = new System.Text.StringBuilder();

                System.Text.StringBuilder strPaySlip1 = new System.Text.StringBuilder();
                System.Text.StringBuilder strGrossSalaryForAddition = new System.Text.StringBuilder();
                System.Text.StringBuilder strGrossSalaryForDeduction = new System.Text.StringBuilder();
                System.Text.StringBuilder strNetAmount = new System.Text.StringBuilder();
                strPaySlip.Append("<table border='0' align='center' width='100%' cellspacing='2'>");
                strPaySlip1.Append("<table border='0'  align='center' width='100%' cellspacing='2'>");
                strNetAmount.Append("<table border='0' align='center' width='100%' cellspacing='2'>");
                strGrossSalaryForAddition.Append("<table border='0' align='center' width='100%'>");
                strGrossSalaryForAddition.Append("<tr><td colspan='1' align='left' style='font-weight:bold'>" + "<u>Gross Salary</u>" + "</td> ");
                strGrossSalaryForDeduction.Append("<table border='0' align='center' width='100%'>");
                strGrossSalaryForDeduction.Append("<tr><td colspan='1' align='left' style='font-weight:bold'>" + "<u>Total Deductions</u>" + "</td>");
                strNetAmount.Append("<table border='0' align='center' width='60%' >");
                strNetAmount.Append("<tr><td colspan='2' align='center' style='font-weight:bold'>" + "<u>Net Amount</u>" + "</td></tr>");

                foreach (DataRow dr in dsData.Tables[0].Rows)
                {


                    if (dr["HeaderID"].ToString() == "0" && dr["Type"].ToString() == "1")
                    {
                        strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td align='right'>" + Convert.ToDecimal((Convert.ToDecimal(dr["Amount"]) / 30) * NoOfWorkingDays).ToString("N2") + "</td><tr>");
                        netAmt = Convert.ToDecimal(netAmt) + Convert.ToDecimal(BasicAmount);
                    }
                    else
                    {
                        if (dr["Type"].ToString() == "1")
                        {
                            strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td align='right'>" + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount).ToString("N2") + "</td><tr>");
                            netAmt = Convert.ToDecimal(netAmt) + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount);
                        }
                        else
                        {
                            if (dr["Type"].ToString() == "0" && ((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount) > 780)
                            {
                                strPaySlip1.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td align='right'>" + Convert.ToDecimal(Const) + "</td><td>");
                                netAmt1 = Convert.ToDecimal(netAmt1) + Convert.ToDecimal(Const);
                            }
                            else
                            {
                                strPaySlip1.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td align='right'>" + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount).ToString("N2") + "</td><td>");
                                netAmt1 = Convert.ToDecimal(netAmt1) + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount);

                            }
                        }

                    }
                }
                strGrossSalaryForAddition.Append("<td align='right'>" + (netAmt).ToString("N2") + "</td><tr>");
                //foreach (DataRow dr in dsData.Tables[0].Rows)
                //{

                //    if (dr["Type"].ToString() == "0")
                //    {
                //        strPaySlip1.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>" + ((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount) + "</td><td>");
                //        netAmt1 = Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount);
                //    }


                //}
                strGrossSalaryForDeduction.Append("<td align='right'>" + (netAmt1).ToString("N2") + "</td><tr>");
                strNetAmount.Append("<tr><td align='center'>" + (netAmt - netAmt1).ToString("N2") + "</td><tr>");
                strPaySlip.Append("</table>");
                strPaySlip.Append("</br>");
                strPaySlip1.Append("</table>");
                strPaySlip1.Append("</br>");
                strGrossSalaryForAddition.Append("</table>");
                strGrossSalaryForDeduction.Append("</table>");
                strNetAmount.Append("</table>");
                dvPaySlip.InnerHtml = strPaySlip.ToString();
                dvPayslip1.InnerHtml = strPaySlip1.ToString();
                dvGrossAddition.InnerHtml = strGrossSalaryForAddition.ToString();
                dvGrossDeduction.InnerHtml = strGrossSalaryForDeduction.ToString();
                dvGrossDeduction.Style.Add("valign", "top");
                dvNetAmount.InnerHtml = strNetAmount.ToString();
            }

        }
    }
}
