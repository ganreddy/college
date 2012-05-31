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
using BusinessLayer;
using System.IO;

public partial class Default2 : System.Web.UI.Page
{
    BusinessLayer.StudentAdmissionBL objStud = new StudentAdmissionBL();
    DataSet ds;
    int StudID;
    protected void Page_Load(object sender, EventArgs e)
    {
        ds = new DataSet();
        if (Request.QueryString["ID"] != null)
        {
             StudID = Convert.ToInt32(Request.QueryString["ID"].ToString());
            //Personal Information
            ds = objStud.GetStudent(StudID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblAdmissionNo.Text = ds.Tables[0].Rows[0]["AdmissionNo"].ToString();
                lblHallTicketNo.Text = ds.Tables[0].Rows[0]["HallTicketNo"].ToString();
                lblRank.Text = ds.Tables[0].Rows[0]["Rank"].ToString();
                lblRegion.Text = ds.Tables[0].Rows[0]["Region"].ToString();
                lblAdmissionDate.Text =ChangeDateFormat( Convert.ToDateTime(ds.Tables[0].Rows[0]["AdmissionDate"].ToString()).ToShortDateString());
                string  path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\") + StudID.ToString() + ".jpeg";
                if (File.Exists(path))
                {
                    imgStud.ImageUrl = "~\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\" + StudID.ToString() + ".jpeg";
                }
                lblFullName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                lblDOB.Text = ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).ToShortDateString());
                lblMotherTounge.Text = ds.Tables[0].Rows[0]["Language"].ToString();
                if (ds.Tables[0].Rows[0]["Gender"].ToString() == "1")
                    lblGender.Text = "Male";
                if (ds.Tables[0].Rows[0]["Gender"].ToString() == "2")
                    lblGender.Text = "Female";
                if (ds.Tables[0].Rows[0]["UrbanRural"].ToString() == "1")
                    lblUrbanRural.Text = "Urban";
                if (ds.Tables[0].Rows[0]["UrbanRural"].ToString() == "2")
                    lblUrbanRural.Text = "Rural";
                lblMandal.Text = ds.Tables[0].Rows[0]["Mandal"].ToString();
                lblNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                lblYear.Text = ds.Tables[0].Rows[0]["Year"].ToString();
                lblState.Text = ds.Tables[0].Rows[0]["StateName"].ToString();
                lblBloodGroup.Text = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                lblReligion.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
                lblJoiningType.Text = ds.Tables[0].Rows[0]["JTName"].ToString();
                lblPhysicalChallenged.Text = ds.Tables[0].Rows[0]["PHType"].ToString();
                lblCaste.Text = ds.Tables[0].Rows[0]["CasteName"].ToString();
                lblPrevTCNo.Text = ds.Tables[0].Rows[0]["PreviousSchoolTCNo"].ToString();
                lblTCIssueDate.Text = ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["TCIssuedDate"].ToString()).ToShortDateString());
                

                //Admitted In Information
                lblClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                lblSection.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
                lblBatch.Text = ds.Tables[0].Rows[0]["BatchNo"].ToString();
               // lblMedium.Text = ds.Tables[0].Rows[0]["MediumName"].ToString();
                lblGroup.Text = ds.Tables[0].Rows[0]["GroupName"].ToString();
                lblHouse.Text = ds.Tables[0].Rows[0]["HouseAlloted"].ToString();
                lblAlphaCode.Text = ds.Tables[0].Rows[0]["AlphaCode"].ToString();
                lblRollNo.Text = ds.Tables[0].Rows[0]["RollNoAlloted"].ToString();
                
                //Contact Information
                               
                path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\") + StudID.ToString() + "_F.jpeg";
                //if (File.Exists(path))
                //{
                //    imgFather.ImageUrl = "~\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\" + StudID.ToString() + "_F.jpeg";
                //}
                //path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\") + StudID.ToString() + "_M.jpeg";
                //if (File.Exists(path))
                //{
                //    imgMother.ImageUrl = "~\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\" + StudID.ToString() + "_M.jpeg";
                //}
                //path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\") + StudID.ToString() + "_G.jpeg";
                //if (File.Exists(path))
                //{
                //    imgGuardian.ImageUrl = "~\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\" + StudID.ToString() + "_G.jpeg";
                //}
                
                ds = objStud.GetStud_ContactInfo(StudID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblFather.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                        lblAddr1.Text = ds.Tables[0].Rows[0]["FatherAddress"].ToString();
                        //lblMother.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
                        //lblAddr2.Text = ds.Tables[0].Rows[0]["MotherAddress"].ToString();
                        if (ds.Tables[0].Rows[0]["FatherQual"].ToString() == "1")
                            lblFatherQual.Text = "Illiterate";
                        if (ds.Tables[0].Rows[0]["FatherQual"].ToString() == "2")
                            lblFatherQual.Text = "Middle";
                        if (ds.Tables[0].Rows[0]["FatherQual"].ToString() == "3")
                            lblFatherQual.Text = "HighSchool";
                        if (ds.Tables[0].Rows[0]["FatherQual"].ToString() == "4")
                            lblFatherQual.Text = "Graduate";
                        if (ds.Tables[0].Rows[0]["FatherQual"].ToString() == "5")
                            lblFatherQual.Text = "Post Graduate";
                        if (ds.Tables[0].Rows[0]["FatherQual"].ToString() == "6")
                            lblFatherQual.Text = "Under Graduate";
                        lblFatherOccup.Text = ds.Tables[0].Rows[0]["FatherOccup"].ToString();
                        if(ds.Tables[0].Rows[0]["FatherAnnualIncome"].ToString()=="1")
                        lblFatherIncome.Text = "3000-6000";
                        if (ds.Tables[0].Rows[0]["FatherAnnualIncome"].ToString() == "2")
                            lblFatherIncome.Text = "6000-12000";
                        if (ds.Tables[0].Rows[0]["FatherAnnualIncome"].ToString() == "3")
                            lblFatherIncome.Text = "12000-18000";
                        if (ds.Tables[0].Rows[0]["FatherAnnualIncome"].ToString() == "4")
                            lblFatherIncome.Text = "18000-24000";
                        if (ds.Tables[0].Rows[0]["FatherAnnualIncome"].ToString() == "5")
                            lblFatherIncome.Text = "24000-30000";
                        if (ds.Tables[0].Rows[0]["FatherAnnualIncome"].ToString() == "6")
                            lblFatherIncome.Text = "30000-36000";
                        if (ds.Tables[0].Rows[0]["FatherAnnualIncome"].ToString() == "7")
                            lblFatherIncome.Text = "36000-50000";
                        if (ds.Tables[0].Rows[0]["FatherAnnualIncome"].ToString() == "8")
                            lblFatherIncome.Text = "50000 & Above";

                        lblTeleOffice.Text = ds.Tables[0].Rows[0]["FatherPhone"].ToString();
                        //if (ds.Tables[0].Rows[0]["MotherQual"].ToString() == "1")
                        //    lblMotherQual.Text = "Illiterate";
                        //if (ds.Tables[0].Rows[0]["MotherQual"].ToString() == "2")
                        //    lblMotherQual.Text = "Middle";
                        //if (ds.Tables[0].Rows[0]["MotherQual"].ToString() == "3")
                        //    lblMotherQual.Text = "HighSchool";
                        //if (ds.Tables[0].Rows[0]["MotherQual"].ToString() == "4")
                        //    lblMotherQual.Text = "Graduate";
                        //if (ds.Tables[0].Rows[0]["MotherQual"].ToString() == "5")
                        //    lblMotherQual.Text = "Post Graduate";
                        //if (ds.Tables[0].Rows[0]["MotherQual"].ToString() == "6")
                        //    lblMotherQual.Text = "Under Graduate";
                        //lblMotherOccup.Text = ds.Tables[0].Rows[0]["MotherOccup"].ToString();
                        //if(ds.Tables[0].Rows[0]["MotherAnnualIncome"].ToString()=="1")
                        //lblMotherIncome.Text = "3000-6000";
                        //if(ds.Tables[0].Rows[0]["MotherAnnualIncome"].ToString()=="2")
                        //lblMotherIncome.Text = "6000-12000";
                        //if(ds.Tables[0].Rows[0]["MotherAnnualIncome"].ToString()=="3")
                        //lblMotherIncome.Text = "12000-18000";
                        //if(ds.Tables[0].Rows[0]["MotherAnnualIncome"].ToString()=="4")
                        //lblMotherIncome.Text = "18000-24000";
                        //if(ds.Tables[0].Rows[0]["MotherAnnualIncome"].ToString()=="5")
                        //lblMotherIncome.Text = "24000-30000";
                        //if(ds.Tables[0].Rows[0]["MotherAnnualIncome"].ToString()=="6")
                        //lblMotherIncome.Text = "30000-36000";
                        //if(ds.Tables[0].Rows[0]["MotherAnnualIncome"].ToString()=="7")
                        //lblMotherIncome.Text = "36000-50000";
                        //if(ds.Tables[0].Rows[0]["MotherAnnualIncome"].ToString()=="8")
                        //lblMotherIncome.Text = "50000 & Above";
                        
                        //lblResiTele.Text = ds.Tables[0].Rows[0]["MotherPhone"].ToString();
                        //lblGuardianName.Text = ds.Tables[0].Rows[0]["GuardianName"].ToString();
                        //lblGuardianAddr.Text = ds.Tables[0].Rows[0]["GuardianAddress"].ToString();
                        //lblGuardianMobile.Text = ds.Tables[0].Rows[0]["GuardianPhone"].ToString();
                        //lblGuardianTele.Text = ds.Tables[0].Rows[0]["GuardianMobile"].ToString();
                    }
                }
                //Identification Details
                ds = objStud.GetStud_Identification(StudID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)     
                    {
                        lblMole1.Text = ds.Tables[0].Rows[0]["Mole1"].ToString();
                        lblMole2.Text = ds.Tables[0].Rows[0]["Mole2"].ToString();
                        lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    }
                }
                ds = objStud.GetStud_Extra(StudID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblExtraCircullar.Text = ds.Tables[0].Rows[0]["Activity"].ToString();
                        lblTcIssuedByJnv.Text = ds.Tables[0].Rows[0]["TcIssuedByJnv"].ToString();
                        lblDateOfIssue.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfIssue"].ToString()).ToShortDateString());
                    }
                }

                //Education History information
                ds = objStud.GetStud_EducHistory(StudID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            HtmlTableRow tblRow = new HtmlTableRow();
                            HtmlTableCell tblCellSchool=new HtmlTableCell();
                            tblCellSchool.InnerText = ds.Tables[0].Rows[i]["PrevSchoolName"].ToString();
                            tblCellSchool.Align = "center";
                            HtmlTableCell tblCellFrom = new HtmlTableCell();
                            tblCellFrom.InnerText = ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[i]["Fromdate"].ToString()).ToShortDateString());
                            tblCellFrom.Align = "center";
                            HtmlTableCell tblCellTo = new HtmlTableCell();
                            tblCellTo.InnerText = ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[i]["Todate"].ToString()).ToShortDateString());
                            tblCellTo.Align = "center";
                            HtmlTableCell tblCellMedium = new HtmlTableCell();
                            tblCellMedium.InnerText = ds.Tables[0].Rows[i]["Language"].ToString();
                            tblCellMedium.Align = "center";
                            HtmlTableCell tblCellRemarks = new HtmlTableCell();
                            tblCellRemarks.InnerText = ds.Tables[0].Rows[i]["Remarks"].ToString();
                            tblCellRemarks.Align = "center";
                            tblRow.Cells.Add(tblCellSchool);
                            tblRow.Cells.Add(tblCellFrom);
                            tblRow.Cells.Add(tblCellTo);
                            tblRow.Cells.Add(tblCellMedium);
                            tblRow.Cells.Add(tblCellRemarks);
                            tblEduHis.Rows.Add(tblRow);
                        }
                    }
                }

            }
        }
        
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
    
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentAdmin.aspx?ID=" + StudID + "");
    }
}
 
