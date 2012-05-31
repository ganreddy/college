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
            ds = objStaff.GetStaffDetails(0);
            ddlStaffId.DataSource = ds.Tables[0];
            ddlStaffId.DataTextField = "FullName";
            ddlStaffId.DataValueField = "StaffID";
            ddlStaffId.DataBind();
            ddlStaffId.Items.Insert(0, new ListItem("---Select---", "0"));
            for (int i = 2000; i < 2013; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlYear.Items.Insert(0, new ListItem("--Select--", "0"));
            panel1.Visible = false;
            btnPrint.Enabled = false;
            btnSave.Enabled = false;
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
        int i = 0;
        decimal basic = 0;
        int NoOfWorkingDays;
        int staffid = Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value);
        int Month = Convert.ToInt32(ddlMonth.Items[ddlMonth.SelectedIndex].Value);
        int Year = Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
        DataSet dsData = new DataSet();
        DataSet duplicats = new DataSet();
        decimal netAmt = 0;
        decimal BasicAmount = 0;
        decimal cal = 0;
        Hashtable ht = new Hashtable();
        dsData = objStaff.GetStaffSalaryPaySlip(staffid);
        duplicats = objStaff.AddTotalStaffSalPaySlipDuplicates(staffid, Month, Year);
        if (duplicats.Tables.Count > 0)
        {
            if (duplicats.Tables[0].Rows.Count > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Staff payslip allready Exist for This Month and Year";
            }
        }
        else
        {
            if (dsData.Tables.Count > 0)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    if (dsData.Tables[0].Rows[0]["Type"].ToString() == "1" && dsData.Tables[0].Rows[0]["CalculationType"].ToString() == "1")
                    {
                        basic = Convert.ToDecimal(dsData.Tables[0].Rows[0]["Amount"]);
                    }

                    //basic = Convert.ToDecimal(dsData.Tables[0].Rows[0]["Amount"]);
                    NoOfWorkingDays = Convert.ToInt32(txtNoOfWorkingDays.Text);
                    BasicAmount = (basic) / 30 * NoOfWorkingDays;
                    System.Text.StringBuilder strPaySlip = new System.Text.StringBuilder();
                    foreach (DataRow dr in dsData.Tables[0].Rows)
                    {
                        string strData = dr["HeaderID"].ToString();

                        if (!strData.Contains(','))
                        {
                            if (dr["Type"].ToString() == "1" && dr["CalculationType"].ToString() == "1" && dr["HeaderID"].ToString() == "0")
                            {
                                cal = Convert.ToDecimal(dr["Amount"]);
                            }
                            else
                                if (dr["Type"].ToString() == "0" && dr["CalculationType"].ToString() == "1" && dr["HeaderID"].ToString() == "0")
                                {
                                    cal = Convert.ToDecimal(dr["Amount"]);
                                }
                                else
                                {
                                    cal = (Convert.ToDecimal(dr["Percentage"].ToString()) / 100) * basic;

                                }
                            ht[dr["HeadID"].ToString()] = cal.ToString();
                        }

                    }
                    cal = 0;
                    foreach (DataRow dr1 in dsData.Tables[0].Rows)
                    {
                        string strData = dr1["HeaderID"].ToString();

                        if (strData.Contains(','))
                        {
                            for (int j = 0; j < strData.Split(',').Length; j++)
                            {

                                string Data = Convert.ToString(strData.Split(',')[j]);


                                cal = cal + Convert.ToDecimal(ht[Data]);
                            }
                            cal = (Convert.ToDecimal(dr1["Percentage"].ToString()) / 100) * cal;
                            ht[dr1["HeadID"].ToString()] = cal.ToString();
                        }

                    }






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
                                //strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>" + ((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount) + "</td><td>" + (basic) + "</td><td>" + ((netAmt) + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount)) + "</td><td>" + ((netAmt) + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount)) + "</td></tr>");
                                strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>" + (Convert.ToDecimal(ht[dr["HeadID"].ToString()])) + "</td><td>" + (basic) + "</td><td>" + ((netAmt) + Convert.ToDecimal(ht[dr["HeadID"].ToString()])) + "</td><td>" + ((netAmt) + Convert.ToDecimal(ht[dr["HeadID"].ToString()])) + "</td></tr>");
                                netAmt = (netAmt) + Convert.ToDecimal(ht[dr["HeadID"].ToString()]);
                                i = objStaff.TotalStaffSalPaySlip(staffid, Month, Year, Convert.ToInt32(dr["HeadID"]), Convert.ToInt32(dr["Type"]), (Convert.ToDecimal(ht[dr["HeadID"].ToString()])), NoOfWorkingDays);
                            }

                            else
                            {
                                //if (((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount) > 780)
                                //{
                                //    strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>" + ((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount) + "</td><td>" + (basic) + "</td><td>" + "---" + "</td><td>" + ((netAmt) - Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount)) + "</td></tr>");
                                //    netAmt = Convert.ToDecimal(netAmt) - Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount);
                                //    i = objStaff.TotalStaffSalPaySlip(staffid, Month, Year, Convert.ToInt32(dr["HeadID"]), Convert.ToInt32(dr["Type"]), 780, NoOfWorkingDays);
                                //}
                                //else
                                //{
                                strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td>" + Convert.ToDecimal(ht[dr["HeadID"].ToString()]) + "</td><td>" + (basic) + "</td><td>" + "---" + "</td><td>" + ((netAmt) - Convert.ToDecimal(ht[dr["HeadID"].ToString()])) + "</td></tr>");
                                netAmt = Convert.ToDecimal(netAmt) - Convert.ToDecimal(ht[dr["HeadID"].ToString()]);
                                i = objStaff.TotalStaffSalPaySlip(staffid, Month, Year, Convert.ToInt32(dr["HeadID"]), Convert.ToInt32(dr["Type"]), (Convert.ToDecimal(ht[dr["HeadID"].ToString()])), NoOfWorkingDays);
                                //}
                            }
                            if (i == 1)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "Staff PaySlip Added Successfully";
                                //s = "Staff PaySlip Added Successfully";
                                ddlMonth.SelectedIndex = 0;
                                ddlYear.SelectedIndex = 0;
                                ddlStaffId.SelectedIndex = 0;
                                txtNoOfWorkingDays.Text = "";
                            }
                            else
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "Staff PaySlip Exists";
                                //s = "Staff PaySlip Exists";
                                //Msg = "alert('" + s + "');";
                                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);

                            }


                            // i = objStaff.TotalStaffSalPaySlip(staffid, Month, Year, Convert.ToInt32(dr["HeadID"]), Convert.ToInt32(dr["Type"]), (Convert.ToDecimal(dr["Percentage"]) / 100 * BasicAmount), NoOfWorkingDays);
                        }


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
        //int NoOfWorkingDays = Convert.ToInt32(txtNoOfWorkingDays.Text);
        decimal NoOfWorkingDays = Convert.ToDecimal(txtNoOfWorkingDays.Text);
        dsData = objStaff.GetStaffSalaryPaySlip(staffid);


        Session["Dataset"] = dsData;
        Session["NoOfWorkingDays"] = txtNoOfWorkingDays.Text;
        //Response.Redirect("Sessioninpayslip.aspx");

        decimal netAmt = 0;
        decimal netAmt1 = 0;

        int Val = 780;
        string Const = Val.ToString("N2");

        decimal BasicAmount = 0;
        decimal cal = 0;
        Hashtable ht = new Hashtable();
        if (dsData.Tables.Count > 0)
        {
            if (dsData.Tables[0].Rows.Count > 0)
            {
                panel1.Visible = true;
                btnPrint.Enabled = true;
                btnSave.Enabled = true;
                //lblMessage1.Visible = false;
                lblName.Text = "NAME : ";
                lblDes.Text = "DESIGNATION : ";
                lblName.Text = lblName.Text + dsData.Tables[0].Rows[0]["FullName"].ToString().ToUpper();
                lblMonth.Text = ddlMonth.SelectedItem.ToString().ToUpper() + " " + ddlYear.SelectedItem.ToString().ToUpper();
                lblDes.Text = lblDes.Text + dsData.Tables[0].Rows[0]["PostName"].ToString();
                if (dsData.Tables[0].Rows[0]["Type"].ToString() == "1" && dsData.Tables[0].Rows[0]["CalculationType"].ToString() == "1")
                {
                    basic = Convert.ToDecimal(dsData.Tables[0].Rows[0]["Amount"]);
                }

                //NoOfWorkingDays = Convert.ToInt32(txtNoOfWorkingDays.Text);
                NoOfWorkingDays = Convert.ToDecimal(txtNoOfWorkingDays.Text);
                BasicAmount = (basic); // 30 * NoOfWorkingDays;
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
                foreach (DataRow dr1 in dsData.Tables[0].Rows)
                {
                    string strData = dr1["HeaderID"].ToString();

                    if (!strData.Contains(','))
                    {

                        if (dr1["Type"].ToString() == "1" && dr1["CalculationType"].ToString() == "1" && dr1["HeaderID"].ToString() == "0")
                        {
                            cal = Convert.ToDecimal(dr1["Amount"]);
                        }
                        else
                            if (dr1["Type"].ToString() == "0" && dr1["CalculationType"].ToString() == "1" && dr1["HeaderID"].ToString() == "0")
                            {
                                cal = Convert.ToDecimal(dr1["Amount"]);
                            }
                            else
                            {

                                cal = (Convert.ToDecimal(dr1["Percentage"].ToString()) / 100) * basic;

                            }

                        ht[dr1["HeadID"].ToString()] = cal.ToString();
                    }

                }
                cal = 0;
                foreach (DataRow dr1 in dsData.Tables[0].Rows)
                {
                    string strData = dr1["HeaderID"].ToString();

                    if (strData.Contains(','))
                    {
                        for (int i = 0; i < strData.Split(',').Length; i++)
                        {

                            string Data = Convert.ToString(strData.Split(',')[i]);


                            cal = cal + Convert.ToDecimal(ht[Data]);
                        }
                        cal = (Convert.ToDecimal(dr1["Percentage"].ToString()) / 100) * cal;
                        ht[dr1["HeadID"].ToString()] = cal.ToString();
                    }

                }
                foreach (DataRow dr in dsData.Tables[0].Rows)
                {

                    if (dr["HeaderID"].ToString() == "0" && dr["Type"].ToString() == "1")
                    {
                        //strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td align='right'>" + ((Convert.ToDecimal(ht[dr["HeadID"].ToString()])) / 30 * NoOfWorkingDays).ToString("N2") + "</td><tr>");
                        strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td align='right'>" + ((Convert.ToDecimal(ht[dr["HeadID"].ToString()]))).ToString("N2") + "</td><tr>");
                        netAmt = Convert.ToDecimal(netAmt) + Convert.ToDecimal(BasicAmount);
                    }
                    else
                    {
                        if (dr["Type"].ToString() == "1")
                        {
                            strPaySlip.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td align='right'>" + (Convert.ToDecimal(ht[dr["HeadID"].ToString()])).ToString("N2") + "</td><tr>");
                            netAmt = Convert.ToDecimal(netAmt) + (Convert.ToDecimal(ht[dr["HeadID"].ToString()]));
                        }
                        else
                        {
                            //if (dr["Type"].ToString() == "0" && ((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount) > 780)
                            //{
                            if (dr["Type"].ToString() == "0")
                            {
                                //strPaySlip1.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td align='right'>" + Convert.ToDecimal(Const) + "</td><td>");
                                //netAmt1 = Convert.ToDecimal(netAmt1) + Convert.ToDecimal(Const);
                                strPaySlip1.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td align='right'>" + (Convert.ToDecimal(ht[dr["HeadID"].ToString()])).ToString("N2") + "</td><td>");
                                netAmt1 = Convert.ToDecimal(netAmt1) + (Convert.ToDecimal(ht[dr["HeadID"].ToString()]));

                            }
                            //else
                            //{
                            //    strPaySlip1.Append("<tr><td>" + dr["HeadName"].ToString() + "</td><td align='right'>" + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount).ToString("N2") + "</td><td>");
                            //    netAmt1 = Convert.ToDecimal(netAmt1) + Convert.ToDecimal((Convert.ToDecimal(dr["Percentage"]) / 100) * BasicAmount);

                            //}
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
            else
            {
                panel1.Visible = false;
                btnPrint.Enabled = false;
                btnSave.Enabled = false;
                //lblMessage1.Visible = true;
                //lblMessage1.Text = "Employee Salary Not Available";  
                // = "Employee Salary Not Available";
                //g = "alert('" + s + "');";
                //criptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);

            }
        }


    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = new DataSet();
        int staffid = Convert.ToInt32(ddlStaffId.Items[ddlStaffId.SelectedIndex].Value);
        int Month = Convert.ToInt32(ddlMonth.Items[ddlMonth.SelectedIndex].Value);
        int Year = Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
        ds = objStaff.GetStaffPayslipByLeaves(staffid, Month, Year);
        if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    int NoOfWorkingDays = 30;
                    txtNoOfWorkingDays.Text = Convert.ToString(NoOfWorkingDays - Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString()));
                }
                else
                {
                    txtNoOfWorkingDays.Text = Convert.ToString(30);
                }
            }

        }

        if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    int NoOfWorkingDays = 31;
                    txtNoOfWorkingDays.Text = Convert.ToString(NoOfWorkingDays - Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString()));
                }
                else
                {
                    txtNoOfWorkingDays.Text = Convert.ToString(31);
                }
            }

        }
        if (Month == 2)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    if (Year % 4 == 0)
                    {
                        bool flag = false;
                        if (Year % 100 != 0) flag = true;
                        else if (Year % 400 == 0) flag = true;
                        if (flag)
                        {
                            int NoOfWorkingDays = 29;
                            txtNoOfWorkingDays.Text = Convert.ToString(NoOfWorkingDays - Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString()));
                        }

                    }
                    else
                    {
                        int NoOfWorkingDays = 28;
                        txtNoOfWorkingDays.Text = Convert.ToString(NoOfWorkingDays - Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString()));
                    }
                }
                else
                {
                    txtNoOfWorkingDays.Text = Convert.ToString(29);
                }
            }
        }


    }
}

