using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using BusinessLayer;
using System.IO;
public partial class Staffmaster : System.Web.UI.Page
{
    int StaffID;
    DataSet ds = new DataSet();
    BusinessLayer.CommonDataBL objCommon = new CommonDataBL();
    BusinessLayer.StaffBL objStaff = new StaffBL();       
    protected void Page_Load(object sender, EventArgs e)
    {
        
        btnSaveStaffDetails.Attributes.Add("onclick ", "javascript:return validate(); ");
        fudStaffPhoto.Attributes.Add("onchange", "javascript:return AddPhoto('" + fudStaffPhoto.ClientID + "','" + imgStaff.ClientID + "');");
        ddlDateofStaffDetails.Attributes.Add("onchange", "javascript:Retirement();");
        if (!IsPostBack)
        {
            txtDate.Text =DateTime.Today.ToString("dd/MM/yyyy");
             
            //txtDateofJoiningInJNVStaffDetails.Text = DateTime.Today.ToString("dd/MM/yyyy");
            ds = objCommon.GetMotherTounge();
            ddlMotherToungeStaffDetails.DataSource = ds.Tables[0];
            ddlMotherToungeStaffDetails.DataTextField = "Language";
            ddlMotherToungeStaffDetails.DataValueField = "MTID";
            ddlMotherToungeStaffDetails.DataBind();
            ddlMotherToungeStaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetNationality();
            ddlNationalityStaffDetails.DataSource = ds.Tables[0];
            ddlNationalityStaffDetails.DataTextField = "Nation";
            ddlNationalityStaffDetails.DataValueField = "NationalityID";
            ddlNationalityStaffDetails.DataBind();
            ddlNationalityStaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));

            ds = objCommon.GetPhysicallyChallenged();
            ddlPhysicallyChallangedStaffDetails.DataSource = ds.Tables[0];
            ddlPhysicallyChallangedStaffDetails.DataTextField = "PHType";
            ddlPhysicallyChallangedStaffDetails.DataValueField = "PHId";
            ddlPhysicallyChallangedStaffDetails.DataBind();
            ddlPhysicallyChallangedStaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetCaste();
            ddlcasteStaffDetails.DataSource = ds.Tables[0];
            ddlcasteStaffDetails.DataTextField = "Caste";
            ddlcasteStaffDetails.DataValueField = "CasteID";
            ddlcasteStaffDetails.DataBind();
            ddlcasteStaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));


            ds = objCommon.GetMartialStatus();
            ddlMartialStatusStaffDetails.DataSource = ds.Tables[0];
            ddlMartialStatusStaffDetails.DataTextField = "Status";
            ddlMartialStatusStaffDetails.DataValueField = "MartialID";
            ddlMartialStatusStaffDetails.DataBind();
            ddlMartialStatusStaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetAppointmentMode();
            ddlModeofAppointMent.DataSource = ds.Tables[0];
            ddlModeofAppointMent.DataTextField = "Mode";
            ddlModeofAppointMent.DataValueField = "AppointmentID";
            ddlModeofAppointMent.DataBind();
            ddlModeofAppointMent.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.spGetPostType();
            ddlTypeofPostStaffDetails.DataSource = ds.Tables[0];
            ddlTypeofPostStaffDetails.DataTextField = "PostType";
            ddlTypeofPostStaffDetails.DataValueField = "PostID";
            ddlTypeofPostStaffDetails.DataBind();
            ds = objCommon.GetSanctionOfPost();
            ddlTypeofPostStaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlSanctionofpostStaffDetails.DataSource = ds.Tables[0];
            ddlSanctionofpostStaffDetails.DataTextField = "SanctionType";
            ddlSanctionofpostStaffDetails.DataValueField = "SanctionID";
            ddlSanctionofpostStaffDetails.DataBind();
            ddlSanctionofpostStaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));

            ds = objStaff.GetStaffType();
            ddlTeachindNonRTeachingStaffDetails.DataSource = ds.Tables[0];

            ddlTeachindNonRTeachingStaffDetails.DataTextField = "Type";
            ddlTeachindNonRTeachingStaffDetails.DataValueField = "StaffTypeID";
            ddlTeachindNonRTeachingStaffDetails.DataBind();
            ddlTeachindNonRTeachingStaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));

            ds = objCommon.GetCader();
            ddlCaderStaffDetails.DataSource = ds.Tables[0];
            ddlCaderStaffDetails.DataTextField = "CaderType";
            ddlCaderStaffDetails.DataValueField = "CaderID";
            ddlCaderStaffDetails.DataBind();
            ddlCaderStaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));

            ds = objCommon.GetPhysicallyChallenged();
            ddlPhysicallyChallangedStaffDetails.DataSource = ds.Tables[0];
            ddlPhysicallyChallangedStaffDetails.DataTextField = "PHType";
            ddlPhysicallyChallangedStaffDetails.DataValueField = "PHId";
            ddlPhysicallyChallangedStaffDetails.DataBind();
            ddlPhysicallyChallangedStaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));

            ds = objCommon.GetQualification();
            ddlDegree1StaffDetails.DataSource = ds.Tables[0];
            ddlDegree1StaffDetails.DataTextField = "QualificationDetails";
            ddlDegree1StaffDetails.DataValueField = "QualificationID";
            ddlDegree1StaffDetails.DataBind();
            ddlDegree1StaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));

            ddlDegree2StaffDetails.DataSource = ds.Tables[0];
            ddlDegree2StaffDetails.DataTextField = "QualificationDetails";
            ddlDegree2StaffDetails.DataValueField = "QualificationID";
            ddlDegree2StaffDetails.DataBind();
            ddlDegree2StaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));

            ddlDegree3StaffDetails.DataSource = ds.Tables[0];
            ddlDegree3StaffDetails.DataTextField = "QualificationDetails";
            ddlDegree3StaffDetails.DataValueField = "QualificationID";
            ddlDegree3StaffDetails.DataBind();
            ddlDegree3StaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));

            ds = objCommon.GetSubject();
            ddlSubject1StaffDetails.DataSource = ds.Tables[0];
            ddlSubject1StaffDetails.DataTextField = "SubjectName";
            ddlSubject1StaffDetails.DataValueField = "SubjectId";
            ddlSubject1StaffDetails.DataBind();
            ddlSubject1StaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));

            ds = objCommon.GetSubject();
            ddlSubject2StaffDetails.DataSource = ds.Tables[0];
            ddlSubject2StaffDetails.DataTextField = "SubjectName";
            ddlSubject2StaffDetails.DataValueField = "SubjectId";
            ddlSubject2StaffDetails.DataBind();
            ddlSubject2StaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));

            ds = objCommon.GetSubject();
            ddlSubject3StaffDetails.DataSource = ds.Tables[0];
            ddlSubject3StaffDetails.DataTextField = "SubjectName";
            ddlSubject3StaffDetails.DataValueField = "SubjectId";
            ddlSubject3StaffDetails.DataBind();
            ddlSubject3StaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));

            for (int i = 1950; i < 2050; i++)
            {
                ddlPassingYear1StaffDetails.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlPassingYear2StaffDetails.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlPassingYear3StaffDetails.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlPassingYear1StaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlPassingYear2StaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlPassingYear3StaffDetails.Items.Insert(0, new ListItem("---Select---", "0"));
           


            if (Request.QueryString["ID"] != null)
            {
                StaffID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                ds = objStaff.GetStaffDetailsData(StaffID);
                string path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StaffImg"] + "\\") + StaffID.ToString() + "_M.jpeg";
                if (File.Exists(path))
                {
                    imgStaff.ImageUrl = "~\\" + ConfigurationManager.AppSettings["StaffImg"] + "\\" + StaffID.ToString() + "_M.jpeg";
                }
                txtStaffNo.Text = ds.Tables[0].Rows[0]["StaffNo"].ToString();
                txtDate.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["AdmissionDate"].ToString()).ToShortDateString());
                txtFullNameStaffDetails.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                txtDOBStaffDetails.Text = ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).ToShortDateString());
                ddlMotherToungeStaffDetails.SelectedValue = ds.Tables[0].Rows[0]["MTID"].ToString();
                if (ds.Tables[0].Rows[0]["Gender"].ToString() == "Male")
                {
                    rbmaleStaffDetails.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["Gender"].ToString() == "Female")
                {
                    rbnFemaleStaffDetails.Checked = true;
                }

                ddlNationalityStaffDetails.SelectedValue = ds.Tables[0].Rows[0]["NationalityID"].ToString();
                ddlTeachindNonRTeachingStaffDetails.SelectedValue = ds.Tables[0].Rows[0]["StaffTypeID"].ToString();
                txtReligion.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
                txtHomeTownStaffDetails.Text = ds.Tables[0].Rows[0]["HomeDistrict"].ToString();
                ddlPhysicallyChallangedStaffDetails.SelectedValue = ds.Tables[0].Rows[0]["PHId"].ToString();
                ddlcasteStaffDetails.SelectedValue = ds.Tables[0].Rows[0]["CasteID"].ToString();
                ddlMartialStatusStaffDetails.SelectedValue = ds.Tables[0].Rows[0]["MartialID"].ToString();
                ddlModeofAppointMent.SelectedValue = ds.Tables[0].Rows[0]["AppointmentID"].ToString();
                txtPostNameStaffDetails.Text = ds.Tables[0].Rows[0]["PostName"].ToString();
                ddlCaderStaffDetails.SelectedValue = ds.Tables[0].Rows[0]["CaderID"].ToString();
                ddlTypeofPostStaffDetails.SelectedValue = ds.Tables[0].Rows[0]["PostID"].ToString();
                ddlSanctionofpostStaffDetails.SelectedValue = ds.Tables[0].Rows[0]["SanctionID"].ToString();
                txtBasicPayGradePayStaffDetails.Text = ds.Tables[0].Rows[0]["BasicSalary"].ToString();
                txtPerminantAddress.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
                txtPresentAddress.Text = ds.Tables[0].Rows[0]["PresentAddress"].ToString();
                txtTelephone.Text = ds.Tables[0].Rows[0]["Telephone"].ToString();
                txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                txtDateofJoiningInJNVStaffDetails.Text =ChangeDateFormat(Convert.ToDateTime( ds.Tables[0].Rows[0]["DateOfJoining"].ToString()).ToShortDateString());
                txtDateofInitialjoinginJNVSStaffDetails.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["CurrJD"].ToString()).ToShortDateString());
                //Identification Marks 
                ds = objStaff.GetStaff_Identification(StaffID); 
                    txtIdentificationmole1StaffDetails.Text = ds.Tables[0].Rows[0]["Mole1"].ToString();             
                    txtIdentificationMole2.Text = ds.Tables[0].Rows[0]["Mole2"].ToString();
                
                //Staff Qualification
                ds = objStaff.GetStaff_Qualifiaction(StaffID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                ddlDegree1StaffDetails.SelectedValue = ds.Tables[0].Rows[i]["Degree"].ToString();
                                ddlSubject1StaffDetails.SelectedValue = ds.Tables[0].Rows[i]["SubjectId"].ToString();
                                txtUniversity1StaffDetails.Text = ds.Tables[0].Rows[i]["University"].ToString();
                                ddlPassingYear1StaffDetails.SelectedValue = ds.Tables[0].Rows[i]["Yearofpassing"].ToString();
                                txtPersent1StaffDetails.Text = ds.Tables[0].Rows[i]["Percentage"].ToString();
                            }
                            if (i == 1)
                            {
                                ddlDegree2StaffDetails.SelectedValue = ds.Tables[0].Rows[i]["Degree"].ToString();
                                ddlSubject2StaffDetails.SelectedValue = ds.Tables[0].Rows[i]["SubjectId"].ToString();
                                txtUniversity2StaffDetails.Text = ds.Tables[0].Rows[i]["University"].ToString();
                                ddlPassingYear2StaffDetails.SelectedValue = ds.Tables[0].Rows[i]["Yearofpassing"].ToString();
                                txtPersent2StaffDetails.Text = ds.Tables[0].Rows[i]["Percentage"].ToString();
                            }
                            if (i == 2)
                            {
                                ddlDegree3StaffDetails.SelectedValue = ds.Tables[0].Rows[i]["Degree"].ToString();
                                ddlSubject3StaffDetails.SelectedValue = ds.Tables[0].Rows[i]["SubjectId"].ToString();
                                txtUniversity3StaffDetails.Text = ds.Tables[0].Rows[i]["University"].ToString();
                                ddlPassingYear3StaffDetails.SelectedValue = ds.Tables[0].Rows[i]["Yearofpassing"].ToString();
                                txtPersent3StaffDetails.Text = ds.Tables[0].Rows[i]["Percentage"].ToString();
                            }
                        }

                    }
                    
                }
                //StaffAccounts
                ds = objStaff.GetStaffAccount(StaffID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtNomineeStaffDetails.Text = ds.Tables[0].Rows[0]["Nominee"].ToString();
                        txtGpfaccountstaffDetails.Text = ds.Tables[0].Rows[0]["GPFAccountNo"].ToString();
                        txtGSLIS.Text = ds.Tables[0].Rows[0]["GslisRecordNO"].ToString();  
                        txtYearsOfExperianceStaffDetails.Text = ds.Tables[0].Rows[0]["YearsOfExperience"].ToString();
                        if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "1")
                        {
                            chkPFStaffDetails.Checked = true;
                        }
                         if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "2")
                        {
                            chkLICStaffDetails.Checked = true;
                        }
                         if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "3")
                        {
                            chkGratuityStaffDetails.Checked = true;
                        }
                         if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "4")
                         {
                             chkPFStaffDetails.Checked = true;
                             chkLICStaffDetails.Checked = true;
                         }

                         if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "5")
                         {
                             chkLICStaffDetails.Checked = true;
                             chkGratuityStaffDetails.Checked = true;
                         }
                         if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "6")
                         {
                             chkPFStaffDetails.Checked = true;
                             chkGratuityStaffDetails.Checked = true;
                         }
                         if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "7") 
                         {
                             chkPFStaffDetails.Checked = true;
                             chkLICStaffDetails.Checked = true;
                             chkGratuityStaffDetails.Checked = true;
                         }

                       // txtNativePlaceStaffDetails.Text = ds.Tables[0].Rows[0]["NativePlace"].ToString();
                        ddlDateofStaffDetails.SelectedValue = ds.Tables[0].Rows[0]["DateOfRetirement"].ToString();
                        txtDateOfStaffDetails.Text = ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["RetirementDate"].ToString()).ToShortDateString());
                        if (ds.Tables[0].Rows[0]["TerminalBenifits"].ToString() == "1") chkPFStaffDetails.Checked = true;
                    }
                }
                //Staff Family
                ds = objStaff.GetStaff_Family(StaffID);
                txtSpouseNameStaffDetails.Text = ds.Tables[0].Rows[0]["SpouseName"].ToString();
                txtSpouseContectNoStaffDetails.Text = ds.Tables[0].Rows[0]["SpouseContactNo"].ToString();
                txtSPlaceStaffDetails.Text = ds.Tables[0].Rows[0]["SpousePlace"].ToString();
                txtSEmpStatusStaffDetails.Text = ds.Tables[0].Rows[0]["SpouseEmpStatus"].ToString();
                txtNameChildrenStaffDetails.Text = ds.Tables[0].Rows[0]["ChildName"].ToString();
                txtcontactChiStaffDetails.Text = ds.Tables[0].Rows[0]["ChildContactNo"].ToString();
                txtChildrenPlaceStaffDetails.Text = ds.Tables[0].Rows[0]["ChildPlace"].ToString();
                txtChildrenEmpstatusStaffDetails.Text = ds.Tables[0].Rows[0]["ChildEmpStatus"].ToString();
                txtParentsNameStaffDetails.Text = ds.Tables[0].Rows[0]["ParentName"].ToString();
                txtParentsContectNoStaffDetails.Text = ds.Tables[0].Rows[0]["ParentContactNo"].ToString();
                txtParentsPlaceStaffDetails.Text = ds.Tables[0].Rows[0]["ParentPlace"].ToString();
                txtParentsEmpStatusStaffDetails.Text =ds.Tables[0].Rows[0]["ParentEmpStatus"].ToString();

                btnSaveStaffDetails.Text = "Update";
            }
        }
    }



    protected void btnSaveStaffDetails_Click(object sender, EventArgs e)
    {
        
        string FullName,strAdmissionDate,StaffNo,Religion,HomeDistrict,PostName,PermanentAddress,PresentAddress,Telephone,Mobile;
        int MotherTounge,Gender,Nationality,StaffType,PhysicallyChallenged,Caste,MartialStatus,AppointmentMode,PostType,PostSanction,Cader;
        decimal BasicSalary;
        DateTime DOB,DateOfJoining,CurrJD;
        BusinessLayer.StaffBL ObjStaffBl = new StaffBL();


            StaffNo = txtStaffNo.Text;
            FullName = txtFullNameStaffDetails.Text;
            
             strAdmissionDate = txtDate.Text;
            
            MotherTounge = Int16.Parse(ddlMotherToungeStaffDetails.Items[ddlMotherToungeStaffDetails.SelectedIndex].Value);
            if (rbmaleStaffDetails.Checked)
                Gender = 1;
            else
                Gender = 2;
            Cader = Int16.Parse(ddlCaderStaffDetails.Items[ddlCaderStaffDetails.SelectedIndex].Value);
            Nationality = Int16.Parse(ddlNationalityStaffDetails.Items[ddlNationalityStaffDetails.SelectedIndex].Value);
            PhysicallyChallenged = Int16.Parse(ddlPhysicallyChallangedStaffDetails.Items[ddlPhysicallyChallangedStaffDetails.SelectedIndex].Value);
            Caste = Int16.Parse(ddlcasteStaffDetails.Items[ddlcasteStaffDetails.SelectedIndex].Value);
            MartialStatus = Int16.Parse(ddlMartialStatusStaffDetails.Items[ddlMartialStatusStaffDetails.SelectedIndex].Value);
            AppointmentMode = Int16.Parse(ddlModeofAppointMent.Items[ddlModeofAppointMent.SelectedIndex].Value);
            PostType = Int16.Parse(ddlTypeofPostStaffDetails.Items[ddlModeofAppointMent.SelectedIndex].Value);
            PostSanction = Int16.Parse(ddlSanctionofpostStaffDetails.Items[ddlSanctionofpostStaffDetails.SelectedIndex].Value);
            BasicSalary = Convert.ToDecimal(txtBasicPayGradePayStaffDetails.Text);
           // strAdmissionDate = Convert.ToDateTime(ChangeDateFormat(txtDate.Text));
            DOB = Convert.ToDateTime(ChangeDateFormat(txtDOBStaffDetails.Text));
            Religion = txtReligion.Text;
            HomeDistrict = txtHomeTownStaffDetails.Text;
            PostName = txtPostNameStaffDetails.Text;
            DateOfJoining = Convert.ToDateTime(ChangeDateFormat(txtDateofJoiningInJNVStaffDetails.Text));
            CurrJD = Convert.ToDateTime(ChangeDateFormat(txtDateofInitialjoinginJNVSStaffDetails.Text));
            PermanentAddress = txtPerminantAddress.Text;
            PresentAddress = txtPresentAddress.Text;
            Telephone = txtTelephone.Text;
            Mobile = txtMobile.Text;
            StaffType = Int16.Parse(ddlTeachindNonRTeachingStaffDetails.Items[ddlTeachindNonRTeachingStaffDetails.SelectedIndex].Value);
            int staffid = 0;
            if (Request.QueryString["ID"]==null)
            {
                staffid = ObjStaffBl.AddStaff(StaffNo, Convert.ToDateTime(ChangeDateFormat(strAdmissionDate)), FullName, DOB, MotherTounge, Gender, Nationality, StaffType, Religion, HomeDistrict, PhysicallyChallenged, Caste, MartialStatus, AppointmentMode, PostName, Cader, PostType, PostSanction, BasicSalary, DateOfJoining, CurrJD, PermanentAddress, PresentAddress, Telephone, Mobile);
            }
            else
            {
                staffid = Convert.ToInt32(Request.QueryString["ID"].ToString());
                staffid = ObjStaffBl.UpdateStaff(staffid, StaffNo, Convert.ToDateTime(ChangeDateFormat(strAdmissionDate)), FullName, DOB, MotherTounge, Gender, Nationality, StaffType, Religion, HomeDistrict, PhysicallyChallenged, Caste, MartialStatus, AppointmentMode, PostName, Cader, PostType, PostSanction, BasicSalary, DateOfJoining, CurrJD, PermanentAddress, PresentAddress, Telephone, Mobile);
            }
            int Degree, Subject, Yearofpassing, Percentage=0;
            string University;
            StaffNo = (txtStaffNo.Text);
            Degree = Int16.Parse(ddlDegree1StaffDetails.Items[ddlDegree1StaffDetails.SelectedIndex].Value);
            Subject = Int16.Parse(ddlSubject1StaffDetails.Items[ddlSubject1StaffDetails.SelectedIndex].Value);
            Yearofpassing = Int16.Parse(ddlPassingYear1StaffDetails.Items[ddlPassingYear1StaffDetails.SelectedIndex].Value);
             Percentage = Convert.ToInt32(txtPersent1StaffDetails.Text);
           
            University = txtUniversity1StaffDetails.Text;
            if (Request.QueryString["ID"] == null)
            {
              
              int j=ObjStaffBl.AddStaffQualification(staffid, Degree, Subject, University, Yearofpassing, Percentage);
            }
            else
            {
                staffid = Convert.ToInt32(Request.QueryString["ID"].ToString());
                int j = ObjStaffBl.UpdateStaffQualification(staffid, Degree, Subject, University, Yearofpassing, Percentage);
            }
            if (ddlDegree2StaffDetails.SelectedValue != "0")
            {
                Degree = Int16.Parse(ddlDegree2StaffDetails.Items[ddlDegree2StaffDetails.SelectedIndex].Value);
                Subject = Int16.Parse(ddlSubject2StaffDetails.Items[ddlSubject2StaffDetails.SelectedIndex].Value);
                Yearofpassing = Int16.Parse(ddlPassingYear2StaffDetails.Items[ddlPassingYear2StaffDetails.SelectedIndex].Value);
                Percentage = Int16.Parse(txtPersent2StaffDetails.Text);
                University = txtUniversity2StaffDetails.Text;
                if (Request.QueryString["ID"] == null)
                {
                   //s StaffID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    int j = ObjStaffBl.AddStaffQualification(staffid, Degree, Subject, University, Yearofpassing, Percentage);
                }
                else
                {
                    staffid = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    int j = ObjStaffBl.UpdateStaffQualification(staffid, Degree, Subject, University, Yearofpassing, Percentage);
                }
               
            }
            if (ddlDegree3StaffDetails.SelectedValue != "0")
            {
                Degree = Int16.Parse(ddlDegree3StaffDetails.Items[ddlDegree3StaffDetails.SelectedIndex].Value);
                Subject = Int16.Parse(ddlSubject3StaffDetails.Items[ddlSubject3StaffDetails.SelectedIndex].Value);
                Yearofpassing = Int16.Parse(ddlPassingYear3StaffDetails.Items[ddlPassingYear3StaffDetails.SelectedIndex].Value);
                Percentage = Int16.Parse(txtPersent3StaffDetails.Text);
                University = txtUniversity3StaffDetails.Text;
                if (Request.QueryString["ID"] == null)
                {
                   // StaffID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    int j = ObjStaffBl.AddStaffQualification(staffid, Degree, Subject, University, Yearofpassing, Percentage);
                }
                else
                {
                    staffid = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    int j = ObjStaffBl.UpdateStaffQualification(staffid, Degree, Subject, University, Yearofpassing, Percentage);
                }
            }
           string strMole1 = txtIdentificationmole1StaffDetails.Text;
           string strMole2 = txtIdentificationMole2.Text;
          
               if (Request.QueryString["ID"] == null)
               {
                 int j= ObjStaffBl.AddStaffIdentification(staffid, strMole1, strMole2);
               }
               else
               {
                   staffid = Convert.ToInt32(Request.QueryString["ID"].ToString());
                   staffid = ObjStaffBl.UpdateStaffIdentification(staffid, strMole1, strMole2);
               }
              
               string Nominee, GPFAccountNo, GslisRecordNO;
               int TerminalBenifits = 0, CertificateSubmit = 0, YearsOfExperience=0,DateOfretirement;
               DateTime RetirementDate;
               Nominee = txtNomineeStaffDetails.Text;
               GPFAccountNo = txtGpfaccountstaffDetails.Text;
               GslisRecordNO = txtGSLIS.Text;
               YearsOfExperience =Convert.ToInt32(txtYearsOfExperianceStaffDetails.Text);
               //NativePlace = txtNativePlaceStaffDetails.Text;
               DateOfretirement = Int32.Parse(ddlDateofStaffDetails.Items[ddlDateofStaffDetails.SelectedIndex].Value);
               RetirementDate = Convert.ToDateTime(ChangeDateFormat(txtDateOfStaffDetails.Text));
                if (chkPFStaffDetails.Checked)
                    TerminalBenifits = 1;
                if (chkLICStaffDetails.Checked)
                    TerminalBenifits = 2;
                if (chkGratuityStaffDetails.Checked)
                    TerminalBenifits = 3;
                if (chkPFStaffDetails.Checked && chkLICStaffDetails.Checked)
                    TerminalBenifits = 4;
                if (chkLICStaffDetails.Checked && chkGratuityStaffDetails.Checked)
                    TerminalBenifits = 5;
                if (chkPFStaffDetails.Checked && chkGratuityStaffDetails.Checked)
                    TerminalBenifits = 6;
                if (chkPFStaffDetails.Checked && chkLICStaffDetails.Checked && chkGratuityStaffDetails.Checked)               
                    TerminalBenifits = 7;         
               if (rbtnMedicalYes.Checked)
                   CertificateSubmit = 1;
               if (rbtnMedicalNo.Checked)
                   CertificateSubmit = 2;
//               int M;
               if (Request.QueryString["ID"] == null)
               {
                  int j= ObjStaffBl.AddStaffAccount(staffid, Nominee, TerminalBenifits, GPFAccountNo, GslisRecordNO, CertificateSubmit, YearsOfExperience, DateOfretirement, RetirementDate);
               }
               else
               {
                   staffid = Convert.ToInt32(Request.QueryString["ID"].ToString());
                   staffid = ObjStaffBl.UpdateStaffAccount(staffid, Nominee, TerminalBenifits, GPFAccountNo, GslisRecordNO, CertificateSubmit, YearsOfExperience, DateOfretirement, RetirementDate);
               }
               
            //Staff Family
            string SpouseName=String.Empty, SpousePlace=String.Empty, SpouseContactNo=String.Empty, ChildName, ChildPlace, ChildContactNo, ParentName, ParentPlace, ParentContactNo;
            int SpouseEmpStatus, ChildEmpStatus, ParentEmpStatus;
            if (txtSpouseNameStaffDetails.Text != "")
            {
                SpouseName = txtSpouseNameStaffDetails.Text;
            }
            if (txtSPlaceStaffDetails.Text != "")
            {
                SpousePlace = txtSPlaceStaffDetails.Text;
            }
            if (txtSpouseContectNoStaffDetails.Text != "")
            {
                SpouseContactNo = txtSpouseContectNoStaffDetails.Text;
            }
            SpouseEmpStatus = 1;
            ChildName = txtNameChildrenStaffDetails.Text;
            ChildPlace = txtChildrenPlaceStaffDetails.Text;
            ChildContactNo = txtcontactChiStaffDetails.Text;
            ChildEmpStatus = 1;
            ParentName = txtParentsNameStaffDetails.Text;
            ParentPlace = txtParentsPlaceStaffDetails.Text;
            ParentContactNo = txtParentsContectNoStaffDetails.Text;
            ParentEmpStatus = 1;
            int k;
            if (Request.QueryString["ID"] == null)
            {
                k = ObjStaffBl.AddStaff_Family(staffid, SpouseName, SpousePlace, SpouseContactNo, SpouseEmpStatus, ChildName, ChildPlace, ChildContactNo, ChildEmpStatus, ParentName, ParentPlace, ParentContactNo, ParentEmpStatus);
            }
            else
            {
                staffid = Convert.ToInt32(Request.QueryString["ID"].ToString());
                k = ObjStaffBl.UpdateStaff_Family(staffid, SpouseName, SpousePlace, SpouseContactNo, SpouseEmpStatus, ChildName, ChildPlace, ChildContactNo, ChildEmpStatus, ParentName, ParentPlace, ParentContactNo, ParentEmpStatus);
            }
            string filename, path;
            filename = fudStaffPhoto.PostedFile.FileName;
            if (filename != "")
            {
                path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StaffImg"] + "\\") + staffid.ToString() + "_M.jpeg";
                fudStaffPhoto.PostedFile.SaveAs(path);
            }
            if (k > 0)
            {
                Response.Write(@"<script language='javascript'>alert('Employee added successful.')</script>");
            }

            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("StaffDetails.aspx?ID=" + staffid.ToString());
            }
            else
            {
                Response.Redirect("StaffDetails.aspx?ID=" + staffid.ToString());
            }
          
    }

    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }


    //protected void ddlDateofStaffDetails_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlDateofStaffDetails.SelectedIndex == 1)
    //    {
    //        txtDateOfStaffDetails.Text =DateTime.Now.AddYears(60).ToString("dd/MM/yyyy");
    //    }
    //}
   
}
