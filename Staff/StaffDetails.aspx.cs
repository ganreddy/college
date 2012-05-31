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
using System.IO;
public partial class Staff_StaffDetails : System.Web.UI.Page
{
    StaffBL objStaff = new StaffBL();
    DataSet ds;
    int StaffID;
    protected void Page_Load(object sender, EventArgs e)
    {
         ds = new DataSet();
        
        if (Request.QueryString["ID"] != null)
        {
             StaffID = Convert.ToInt32(Request.QueryString["ID"].ToString());
             ds = objStaff.GetStaffDetailsData(StaffID);
             string path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StaffImg"] + "\\") + StaffID.ToString() + "_M.jpeg";
             if (File.Exists(path))
             {
                 imgStaff.ImageUrl = "~\\" + ConfigurationManager.AppSettings["StaffImg"] + "\\" + StaffID.ToString() + "_M.jpeg";
             }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblStaffNo.Text = ds.Tables[0].Rows[0]["StaffNo"].ToString();
                    lblDate.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["AdmissionDate"].ToString()).ToShortDateString());
                    lblFullNameStaffDetails.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                    lblDOBStaffDetails.Text = ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).ToShortDateString());
                    lblMotherToungeStaffDetails.Text = ds.Tables[0].Rows[0]["MotherTounge"].ToString();
                    lblmaleStaffDetails.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                    lblNation.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                    lblTeach.Text = ds.Tables[0].Rows[0]["StaffType"].ToString();
                    lblReligion.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
                    lblHomeTownStaffDetails.Text = ds.Tables[0].Rows[0]["HomeDistrict"].ToString();
                    lblPhysicallyChallangedStaffDetails.Text = ds.Tables[0].Rows[0]["PhysicallyChallenged"].ToString();
                    lblcasteStaffDetails.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
                    lblMartialStatusStaffDetails.Text = ds.Tables[0].Rows[0]["MartialStatus"].ToString();
                    lblModeofAppointMent.Text =ds.Tables[0].Rows[0]["AppointmentMode"].ToString();
                    lblBasicPayGradePayStaffDetails.Text = ds.Tables[0].Rows[0]["BasicSalary"].ToString();

                    //Recruitment Information
                    lblPostNameStaffDetails.Text = ds.Tables[0].Rows[0]["PostName"].ToString();
                    lblCaderStaffDetails.Text = ds.Tables[0].Rows[0]["Cader"].ToString();
                    lblTypeofPostStaffDetails.Text = ds.Tables[0].Rows[0]["PostType"].ToString();
                    lblSanctionofpostStaffDetails.Text = ds.Tables[0].Rows[0]["PostSanction"].ToString();
                    lblDateofJoiningInJNVStaffDetails.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfJoining"].ToString()).ToShortDateString());
                    lblDateofInitialjoinginJNVSStaffDetails.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["CurrJD"].ToString()).ToShortDateString());
                    lblPerminantAddress.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
                    lblPresentAddress.Text = ds.Tables[0].Rows[0]["PresentAddress"].ToString();
                    lblTelephone.Text = ds.Tables[0].Rows[0]["Telephone"].ToString();
                    lblMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                }
            }
                    ds = objStaff.GetStaffAccount(StaffID);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblNomineeStaffDetails.Text = ds.Tables[0].Rows[0]["Nominee"].ToString();
                            if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "1")
                                lblDischargeBenefits.Text = "PF";
                            if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "2")
                                lblDischargeBenefits.Text = "LIC";
                            if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "3")
                                lblDischargeBenefits.Text = "Gratuity";
                            if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "4" )
                                lblDischargeBenefits.Text = "PF And LIC";
                            if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "5")
                                lblDischargeBenefits.Text = "LIC And Gratuity";
                            if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "6")
                                lblDischargeBenefits.Text = "PF And Gratuity";
                            if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "7")
                                lblDischargeBenefits.Text = "PF,LIC And Gratuity";

                            lblGpfaccountstaffDetails.Text = ds.Tables[0].Rows[0]["GPFAccountNo"].ToString();
                            lblGSLIS.Text = ds.Tables[0].Rows[0]["GslisRecordNO"].ToString();
                            if (ds.Tables[0].Rows[0]["CertificateSubmit"].ToString() == "1")
                            {
                                lblCert.Text = "Yes";
                            }
                            if (ds.Tables[0].Rows[0]["CertificateSubmit"].ToString() == "2")
                            {
                                lblCert.Text = "No";
                            }
                            lblYearsOfExperianceStaffDetails.Text = ds.Tables[0].Rows[0]["YearsOfExperience"].ToString();
                            //lblNativePlaceStaffDetails.Text = ds.Tables[0].Rows[0]["NativePlace"].ToString();
                            if(ds.Tables[0].Rows[0]["DateOfRetirement"].ToString()== "1")
                            lblDateofRetire.Text = "Retirement";
                            if (ds.Tables[0].Rows[0]["DateOfRetirement"].ToString() == "2")
                                lblDateofRetire.Text = "Suspension";
                            if (ds.Tables[0].Rows[0]["DateOfRetirement"].ToString() == "3")
                                lblDateofRetire.Text = "Resignation";
                            lblDateOfStaffDetails.Text = ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["RetirementDate"].ToString()).ToShortDateString());
                        }
                    }
             

            ds = objStaff.GetStaff_Identification(StaffID);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblIdentificationmole1StaffDetails.Text = ds.Tables[0].Rows[0]["Mole1"].ToString();
                    lblIdentificationMole2.Text = ds.Tables[0].Rows[0]["Mole2"].ToString();
                }
            }
                       
                        // lblDate.Text = ds.Tables[0].Rows[0]["CurrJD"].ToString();
                ds = objStaff.GetStaff_Qualifiaction(StaffID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                        {
                            HtmlTableRow tblRow = new HtmlTableRow();
                            HtmlTableCell tblCellDegree = new HtmlTableCell();
                            tblCellDegree.InnerText = ds.Tables[0].Rows[0]["Degree"].ToString();
                            tblCellDegree.Align = "center";
                            HtmlTableCell tblCellSubject = new HtmlTableCell();
                            tblCellSubject.InnerText = ds.Tables[0].Rows[0]["Subject"].ToString();
                            tblCellSubject.Align = "center";
                            HtmlTableCell tblCellUniversity = new HtmlTableCell();
                            tblCellUniversity.InnerText = ds.Tables[0].Rows[0]["University"].ToString();
                            tblCellUniversity.Align = "center";
                            HtmlTableCell tblCellYearOfPassing = new HtmlTableCell();
                            tblCellYearOfPassing.InnerText = ds.Tables[0].Rows[0]["Yearofpassing"].ToString();
                            tblCellYearOfPassing.Align = "center";
                            HtmlTableCell tblCellPercentage = new HtmlTableCell();
                            tblCellPercentage.InnerText = "Percentage";
                            tblCellPercentage.InnerText = ds.Tables[0].Rows[0]["Percentage"].ToString();
                            tblCellPercentage.Align = "center";
                            tblRow.Cells.Add(tblCellDegree);
                            tblRow.Cells.Add(tblCellSubject);
                            tblRow.Cells.Add(tblCellUniversity);
                            tblRow.Cells.Add(tblCellYearOfPassing);
                            tblRow.Cells.Add(tblCellPercentage);
                            tblQualification.Rows.Add(tblRow);
                        }
                    }
                }


                //Family Details
                ds = objStaff.GetStaff_Family(StaffID);
               if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblSpouseNameStaffDetails.Text = ds.Tables[0].Rows[0]["SpouseName"].ToString();
                        lblNameChildrenStaffDetails.Text = ds.Tables[0].Rows[0]["ChildName"].ToString();
                        lblParentsNameStaffDetails.Text = ds.Tables[0].Rows[0]["ParentName"].ToString();
                        lblSpouseContectNoStaffDetails.Text = ds.Tables[0].Rows[0]["SpouseContactNo"].ToString();
                        lblcontactChiStaffDetails.Text = ds.Tables[0].Rows[0]["ChildContactNo"].ToString();
                        lblParentsContectNoStaffDetails.Text = ds.Tables[0].Rows[0]["ParentContactNo"].ToString();
                        lblSPlaceStaffDetails.Text = ds.Tables[0].Rows[0]["SpousePlace"].ToString();
                        lblChildrenPlaceStaffDetails.Text = ds.Tables[0].Rows[0]["ChildPlace"].ToString();
                        lblParentsPlaceStaffDetails.Text = ds.Tables[0].Rows[0]["ParentPlace"].ToString();
                        lblSEmpStatusStaffDetails.Text = ds.Tables[0].Rows[0]["SpouseEmpStatus"].ToString();
                        lblChildrenEmpstatusStaffDetails.Text = ds.Tables[0].Rows[0]["ChildEmpStatus"].ToString();
                        lblParentsEmpStatusStaffDetails.Text = ds.Tables[0].Rows[0]["ParentEmpStatus"].ToString();
                    }
            }

        }
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void btnSaveStaffDetails_Click(object sender, EventArgs e)
    {        
        Response.Redirect("Staffmaster.aspx?ID=" + StaffID + "");      
    }
}
