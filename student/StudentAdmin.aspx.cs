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
using System.IO;
using BusinessLayer;

public partial class StudentModule_StudentAdmin : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objCommon = new CommonDataBL();
    StudentAdmissionBL objStud = new StudentAdmissionBL();
 
    DataSet ds;
    int StudID;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnreset.Attributes.Add("onclick", "javascript:return ResetForm();");
        btnsave.Attributes.Add("onclick", "javascript:return RequiredValidate();");
        fudStudent.Attributes.Add("onchange", "javascript:return AddPhoto('" + fudStudent.ClientID + "','" + imgStud.ClientID + "');");
        //fudFatherPhoto.Attributes.Add("onchange", "javascript:return AddPhoto('" + fudFatherPhoto.ClientID + "','" + imgFather.ClientID + "');");
        //fudMother.Attributes.Add("onchange", "javascript:return AddPhoto('" + fudMother.ClientID + "','" + imgMother.ClientID + "');");
       // fudGuardian.Attributes.Add("onchange", "javascript:return AddPhoto('" + fudGuardian.ClientID + "','" + imgGuardian.ClientID + "');");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        BusinessLayer.CommonDataBL objCommon = new CommonDataBL();
        StudentAdmissionBL objStud = new StudentAdmissionBL();
        ds = new DataSet();
        if (!IsPostBack)
        {
            for (int i = 2005; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlYear.SelectedValue = "2012";
            
            txtAdmissionmDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            Message.Value = DateTime.Today.ToString("dd/MM/yyyy");
            ds = objCommon.GetMotherTounge();
            ddlMotherTounge.DataSource = ds.Tables[0];
            ddlMotherTounge.DataTextField = "Language";
            ddlMotherTounge.DataValueField = "MTID";
            ddlMotherTounge.DataBind();
            ddlMotherTounge.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetJoiningType();
            ddlJoinType.DataSource = ds.Tables[0];
            ddlJoinType.DataTextField = "JTName";
            ddlJoinType.DataValueField = "JTID";
            ddlJoinType.DataBind();
            ddlJoinType.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetPhysicallyChallenged();
            ddlPhysicallyChallanged.DataSource = ds.Tables[0];
            ddlPhysicallyChallanged.DataTextField = "PHType";
            ddlPhysicallyChallanged.DataValueField = "PHId";
            ddlPhysicallyChallanged.DataBind();
            ddlPhysicallyChallanged.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetCaste();
            ddlcaste.DataSource = ds.Tables[0];
            ddlcaste.DataTextField = "Caste";
            ddlcaste.DataValueField = "CasteID";
            ddlcaste.DataBind();
            ddlcaste.Items.Insert(0, new ListItem("---Select---", "0"));
            
            ds = objCommon.GetExtraCurricular();
            ddlECA.DataSource = ds.Tables[0];
            ddlECA.DataTextField = "Activity";
            ddlECA.DataValueField = "ExtraCurricularID";
            ddlECA.DataBind();
            ddlECA.Items.Insert(0, new ListItem("---Select---", "0"));
            //ds = objCommon.GetQualification();
            //ddlQualFather.DataSource = ds.Tables[0];
            //ddlQualFather.DataTextField = "QualificationDetails";
            //ddlQualFather.DataValueField = "QualificationID";
            //ddlQualFather.DataBind();
            //ddlQualFather.Items.Insert(0, new ListItem("---Select---", "0"));
            //ds = objCommon.GetQualification();
            //ddlQualMother.DataSource = ds.Tables[0];
            //ddlQualMother.DataTextField = "QualificationDetails";
            //ddlQualMother.DataValueField = "QualificationID";
            //ddlQualMother.DataBind();
            //ddlQualMother.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetClasses();
            ddlClass.DataSource = ds.Tables[0];
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetSection();
            ddlSection.DataSource = ds.Tables[0];
            ddlSection.DataTextField = "SectionName";
            ddlSection.DataValueField = "SectionId";
            ddlSection.DataBind();
            ddlSection.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetMedium();
            ddlMedium.DataSource = ds.Tables[0];
            ddlMedium.DataTextField = "Language";
            ddlMedium.DataValueField = "MediumID";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetMedium();
            ddlMed1.DataSource = ds.Tables[0];
            ddlMed1.DataTextField = "Language";
            ddlMed1.DataValueField = "MediumID";
            ddlMed1.DataBind();
            ddlMed1.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetMedium();
            ddlMed2.DataSource = ds.Tables[0];
            ddlMed2.DataTextField = "Language";
            ddlMed2.DataValueField = "MediumID";
            ddlMed2.DataBind();
            ddlMed2.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetMedium();
            ddlMed3.DataSource = ds.Tables[0];
            ddlMed3.DataTextField = "Language";
            ddlMed3.DataValueField = "MediumID";
            ddlMed3.DataBind();
            ddlMed3.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetBatch();
            ddlBatch.DataSource = ds.Tables[0];
            ddlBatch.DataTextField = "BatchNo";
            ddlBatch.DataValueField = "BatchID";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
            //ds = objCommon.GetGroups();
            //ddlGroup.DataSource = ds.Tables[0];
            //ddlGroup.DataTextField = "GroupName";
            //ddlGroup.DataValueField = "GroupId";
            //ddlGroup.DataBind();
            //ddlGroup.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objCommon.GetState();
            ddlstate.DataSource = ds.Tables[0];
            ddlstate.DataTextField = "StateName";
            ddlstate.DataValueField = "StateID";
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("---Select---", "0"));
            trCurHead.Style.Add("display", "none");
            trCurBatch.Style.Add("display", "none");
            trCurSection.Style.Add("display", "none");
            if (Request.QueryString["ID"] != null)
            {
                ds = objCommon.GetBatch();
                ddlCurBatch.DataSource = ds.Tables[0];
                ddlCurBatch.DataTextField = "BatchNo";
                ddlCurBatch.DataValueField = "BatchID";
                ddlCurBatch.DataBind();
                ddlCurBatch.Items.Insert(0, new ListItem("---Select---", "0"));
                ds = objCommon.GetGroups();
                ddlCurGroup.DataSource = ds.Tables[0];
                ddlCurGroup.DataTextField = "GroupName";
                ddlCurGroup.DataValueField = "GroupId";
                ddlCurGroup.DataBind();
                ddlCurGroup.Items.Insert(0, new ListItem("---Select---", "0"));
                ds = objCommon.GetClasses();
                ddlCurClass.DataSource = ds.Tables[0];
                ddlCurClass.DataTextField = "ClassName";
                ddlCurClass.DataValueField = "ClassID";
                ddlCurClass.DataBind();
                ddlCurClass.Items.Insert(0, new ListItem("---Select---", "0"));
                ds = objCommon.GetSection();
                ddlCurSection.DataSource = ds.Tables[0];
                ddlCurSection.DataTextField = "SectionName";
                ddlCurSection.DataValueField = "SectionId";
                ddlCurSection.DataBind();
                ddlCurSection.Items.Insert(0, new ListItem("---Select---", "0"));
                trCurHead.Style.Add("display", "inline");
                trCurBatch.Style.Add("display", "inline");
                trCurSection.Style.Add("display", "inline");

                StudID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                string path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\") + StudID.ToString() + ".jpeg";
                if (File.Exists(path))
                {
                    imgStud.ImageUrl = "~\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\" + StudID.ToString() + ".jpeg";
                }
                path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\") + StudID.ToString() + "_F.jpeg";
                //if (File.Exists(path))
                //{
                //    imgFather.ImageUrl = "~\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\" + StudID.ToString() + "_F.jpeg";
                //}
                path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\") + StudID.ToString() + "_M.jpeg";
                //if (File.Exists(path))
                //{
                //    imgMother.ImageUrl = "~\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\" + StudID.ToString() + "_M.jpeg";
                //}
                path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\") + StudID.ToString() + "_G.jpeg";
                //if (File.Exists(path))
                //{
                //    imgGuardian.ImageUrl = "~\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\" + StudID.ToString() + "_G.jpeg";
                //}
                //Student Data
                ds = objStud.GetStudent(StudID);
                txtAdmissionNo.Text = ds.Tables[0].Rows[0]["AdmissionNo"].ToString();
                txtHallTicket.Text = ds.Tables[0].Rows[0]["HallTicketNo"].ToString();
                txtRank.Text = ds.Tables[0].Rows[0]["Rank"].ToString();
                txtRegion.Text = ds.Tables[0].Rows[0]["Region"].ToString();
                txtAdmissionmDate.Text = ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["AdmissionDate"].ToString()).ToShortDateString());
                txtfullname.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                txtdob.Text = ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).ToShortDateString());
                ddlMotherTounge.SelectedValue = ds.Tables[0].Rows[0]["MotherTounge"].ToString();
                txtMandal.Text = ds.Tables[0].Rows[0]["Mandal"].ToString();
                txtNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                ddlstate.SelectedValue = ds.Tables[0].Rows[0]["State"].ToString();
                txtreligion.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
                ddlJoinType.SelectedValue = ds.Tables[0].Rows[0]["JoiningType"].ToString();
                ddlPhysicallyChallanged.SelectedValue = ds.Tables[0].Rows[0]["PhysicallyChallenged"].ToString();
                ddlcaste.SelectedValue = ds.Tables[0].Rows[0]["Caste"].ToString();
                txtGamesPlayed.Text = ds.Tables[0].Rows[0]["Games"].ToString();
                txtPrevSchoolTc.Text = ds.Tables[0].Rows[0]["PreviousSchoolTCNo"].ToString();
                txtTcDate.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["TCIssuedDate"].ToString()).ToShortDateString());
                ddlClass.SelectedValue = ds.Tables[0].Rows[0]["AdmittedInClass"].ToString();
                ddlMedium.SelectedValue = ds.Tables[0].Rows[0]["Medium"].ToString();
                txtRollNo.Text = ds.Tables[0].Rows[0]["RollNoAlloted"].ToString();
                ddlHouseAlloted.SelectedValue = ds.Tables[0].Rows[0]["HouseAlloted"].ToString();
                ddlSection.SelectedValue = ds.Tables[0].Rows[0]["Section"].ToString();
                ddlBatch.SelectedValue = ds.Tables[0].Rows[0]["BatchId"].ToString();
                //ddlGroup.SelectedValue= ds.Tables[0].Rows[0]["Group"].ToString();
                //txtAlphaCode.Text = ds.Tables[0].Rows[0]["AlphaCode"].ToString();
                ddlCurBatch.SelectedValue = ds.Tables[0].Rows[0]["CurrentBatch"].ToString();
                ddlCurClass.SelectedValue = ds.Tables[0].Rows[0]["CurrentClass"].ToString();
                ddlCurSection.SelectedValue = ds.Tables[0].Rows[0]["CurrentSection"].ToString();
                ddlCurGroup.SelectedValue = ds.Tables[0].Rows[0]["CurrentGroup"].ToString(); 
                if (ds.Tables[0].Rows[0]["Gender"].ToString() == "1")
                    rbmale.Checked = true;
                else
                    rbfemale.Checked = true;

                //Student Identification
                ds = objStud.GetStud_Identification(StudID);
                txtMoles1.Text = ds.Tables[0].Rows[0]["Mole1"].ToString();
                txtMoles2.Text = ds.Tables[0].Rows[0]["Mole2"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                //Student Contact Information
                ds = objStud.GetStud_ContactInfo(StudID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtfathername.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                        txtaddr1.Text = ds.Tables[0].Rows[0]["FatherAddress"].ToString();
                        txtteloffice.Text = ds.Tables[0].Rows[0]["FatherPhone"].ToString();
                        ddlQualFather.SelectedValue = ds.Tables[0].Rows[0]["FatherQual"].ToString();
                        txtoccupation.Text = ds.Tables[0].Rows[0]["FatherOccup"].ToString();
                        //txtAnnualIncome.Text = ds.Tables[0].Rows[0]["FatherAnnualIncome"].ToString();
                        ddlFatherAnnualIncome.SelectedValue = ds.Tables[0].Rows[0]["FatherAnnualIncome"].ToString();
                       // txtMotherName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
                       // txtAddress2.Text = ds.Tables[0].Rows[0]["MotherAddress"].ToString();
                       // txtPhoneMother.Text = ds.Tables[0].Rows[0]["MotherPhone"].ToString();
                       // ddlQualMother.SelectedValue = ds.Tables[0].Rows[0]["MotherQual"].ToString();
                       // txtOccupationMother.Text = ds.Tables[0].Rows[0]["MotherOccup"].ToString();
                       //// txtMotherAnnualIncome.Text = ds.Tables[0].Rows[0]["MotherAnnualIncome"].ToString();
                       // ddlMotherAnnualIncome.SelectedValue = ds.Tables[0].Rows[0]["MotherAnnualIncome"].ToString();
                        //txtguardname.Text = ds.Tables[0].Rows[0]["GuardianName"].ToString();
                        //txtguardaddress.Text = ds.Tables[0].Rows[0]["GuardianAddress"].ToString();
                        //txtguardtel.Text = ds.Tables[0].Rows[0]["GuardianPhone"].ToString();
                        //txtguardmobile.Text = ds.Tables[0].Rows[0]["GuardianMobile"].ToString();
                    }
                }
                //Student_Extra
                ds = objStud.GetStud_Extra(StudID);
                ddlECA.SelectedValue = ds.Tables[0].Rows[0]["ExtraCurricularID"].ToString();
                txtJnvIssue.Text = ds.Tables[0].Rows[0]["TcIssuedByJnv"].ToString();
                txtDateOfIssue.Text =ChangeDateFormat(Convert.ToDateTime( ds.Tables[0].Rows[0]["DateOfIssue"].ToString()).ToShortDateString());

                //Student Education History
                ds = objStud.GetStud_EducHistory(StudID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                txtPrevSchool1.Text = ds.Tables[0].Rows[i]["PrevSchoolName"].ToString();
                                txtFrom1.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[i]["Fromdate"].ToString()).ToShortDateString());
                                txtTo1.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[i]["Todate"].ToString()).ToShortDateString());
                                ddlMed1.SelectedValue = ds.Tables[0].Rows[i]["Medium"].ToString();
                                txtrem1.Text = ds.Tables[0].Rows[i]["Remarks"].ToString();
                            }
                            if (i == 1)
                            {
                                txtPrevSchool2.Text = ds.Tables[0].Rows[i]["PrevSchoolName"].ToString();
                                txtFrom2.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[i]["Fromdate"].ToString()).ToShortDateString());
                                txtto2.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[i]["Todate"].ToString()).ToShortDateString());
                                ddlMed2.SelectedValue = ds.Tables[0].Rows[i]["Medium"].ToString();
                                txtrem2.Text = ds.Tables[0].Rows[i]["Remarks"].ToString();
                            }
                            if (i == 2)
                            {
                                txtPrevSchool3.Text = ds.Tables[0].Rows[i]["PrevSchoolName"].ToString();
                                txtFrom3.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[i]["Fromdate"].ToString()).ToShortDateString());
                                txtto3.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[i]["Todate"].ToString()).ToShortDateString());
                                ddlMed3.SelectedValue = ds.Tables[0].Rows[i]["Medium"].ToString();
                                txtrem3.Text = ds.Tables[0].Rows[i]["Remarks"].ToString();
                            }
                        }
                    }
                }
                btnsave.Text = "Update";
                btnreset.Visible = false;
            }
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        string strAdmissionNo, strAdmissionDate, strFullname, strDob, strMandal = "", strReligion, strMole1, strMole2, strEmail, strGames, strRollNo, strPreviousTCNo, strTcIssuedDate, strAlphaCode, HallTicketNo, Region, Nationality;
        int MotherTounge, Gender = 0, UrbanRural = 0, State, JoiningType, PHType, Caste, ExtraCir, Class, Section, Medium = 0, Batch, Group, Rank, BloodGroup, Year, strHouseAlloted;
        strAdmissionNo = txtAdmissionNo.Text;
        strAdmissionDate = txtAdmissionmDate.Text;
        strFullname = txtfullname.Text;
        strDob = txtdob.Text;
        MotherTounge = Convert.ToInt32(ddlMotherTounge.Items[ddlMotherTounge.SelectedIndex].Value);
        if (rbfemale.Checked) Gender = 2;
        if (rbmale.Checked) Gender = 1;
        if (rbtnRural.Checked) UrbanRural = 2;
        if (rbtnUrban.Checked) UrbanRural = 1;
        strMandal = txtMandal.Text;
        Nationality = txtNationality.Text;
        State = Convert.ToInt32(ddlstate.Items[ddlstate.SelectedIndex].Value);
        strReligion = txtreligion.Text;
        JoiningType = Convert.ToInt32(ddlJoinType.Items[ddlJoinType.SelectedIndex].Value);
        PHType = Convert.ToInt32(ddlPhysicallyChallanged.Items[ddlPhysicallyChallanged.SelectedIndex].Value);
        Caste = Convert.ToInt32(ddlcaste.Items[ddlcaste.SelectedIndex].Value);
        strPreviousTCNo = txtPrevSchoolTc.Text;
        strTcIssuedDate = txtTcDate.Text;
        Class = Convert.ToInt32(ddlClass.Items[ddlClass.SelectedIndex].Value);
        Medium = Convert.ToInt32(ddlMedium.Items[ddlMedium.SelectedIndex].Value);
        strRollNo = txtRollNo.Text;
        strHouseAlloted = Convert.ToInt32(ddlHouseAlloted.SelectedValue);
        Section = Convert.ToInt32(ddlSection.Items[ddlSection.SelectedIndex].Value);
        Batch = Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value);
        //Group = Convert.ToInt32(ddlGroup.Items[ddlGroup.SelectedIndex].Value);
        //strAlphaCode = txtAlphaCode.Text;
        strMole1 = txtMoles1.Text;
        strMole2 = txtMoles2.Text;
        strEmail = txtEmail.Text;
        ExtraCir = Convert.ToInt32(ddlECA.Items[ddlECA.SelectedIndex].Value);
        strGames = txtGamesPlayed.Text;
        HallTicketNo = txtHallTicket.Text;
        Rank = Convert.ToInt32(txtRank.Text);
        Region = txtRegion.Text;
        BloodGroup = Convert.ToInt32(ddlBloodGroup.Items[ddlBloodGroup.SelectedIndex].Value);
        Year = Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
        int Studid = 0;
        if (Request.QueryString["ID"] == null)
        {
            Studid = objStud.AddStudent(strAdmissionNo, Convert.ToDateTime(ChangeDateFormat(strAdmissionDate)), strFullname, Convert.ToDateTime(ChangeDateFormat(strDob)), MotherTounge, Gender, UrbanRural, strMandal, Nationality, State, strReligion, JoiningType, PHType, Caste, strGames, strPreviousTCNo, Convert.ToDateTime(ChangeDateFormat(strTcIssuedDate)), Class, Medium, strRollNo, strHouseAlloted, "", Section, Batch,HallTicketNo,Rank,Region,BloodGroup,Year);
            objStud.AddStudentPromotion(Studid, Batch, Class, Section);
        }
        else
        {
            Studid = Convert.ToInt32(Request.QueryString["ID"].ToString());
            objStud.UpdateStudent(Studid, strAdmissionNo, Convert.ToDateTime(ChangeDateFormat(strAdmissionDate)), strFullname, Convert.ToDateTime(ChangeDateFormat(strDob)), MotherTounge, Gender, UrbanRural, strMandal, Nationality, State, strReligion, JoiningType, PHType, Caste, strGames, strPreviousTCNo, Convert.ToDateTime(ChangeDateFormat(strTcIssuedDate)), Class, Medium, strRollNo, strHouseAlloted, "", Section, Batch,HallTicketNo,Rank,Region,BloodGroup,Year);
        }
        if (Studid != 0)
        {
            string strFather,  strAddr1,  strFatherOccup,  strOfficeTele;
            int FatherQual,  FatherIncome;
            strFather = txtfathername.Text;
            //strMother = txtMotherName.Text;
            strAddr1 = txtaddr1.Text;
            //strAddr2 = txtAddress2.Text;
            strFatherOccup = txtoccupation.Text;
           // strMotherOccup = txtOccupationMother.Text;
            strOfficeTele = txtteloffice.Text;
           // strResTele = txtPhoneMother.Text;
            //strGuardianname = txtguardname.Text;
            //strGuardianAddr = txtguardaddress.Text;
            //strGuardianMobile = txtguardmobile.Text;
            //strGuardianTele = txtguardtel.Text;
            FatherQual = Convert.ToInt32(ddlQualFather.Items[ddlQualFather.SelectedIndex].Value);
            //MotherQual = Convert.ToInt32(ddlQualMother.Items[ddlQualMother.SelectedIndex].Value);
            // FatherIncome = Convert.ToInt32(txtAnnualIncome.Text);
            //if (txtMotherAnnualIncome.Text != "")
            //   MotherIncome = Convert.ToInt32(txtMotherAnnualIncome.Text);
            FatherIncome = Convert.ToInt32(ddlFatherAnnualIncome.Items[ddlFatherAnnualIncome.SelectedIndex].Value);
           // MotherIncome = Convert.ToInt32(ddlMotherAnnualIncome.Items[ddlMotherAnnualIncome.SelectedIndex].Value);
            int i;
            if (Request.QueryString["ID"] == null)
            {
                objStud.AddStudentContactInfo(Studid, strFather, strAddr1, strOfficeTele, FatherQual, strFatherOccup, FatherIncome);
            }
            else
            {
                i = objStud.UpdateStudentContactInfo(Studid, strFather, strAddr1, strOfficeTele, FatherQual, strFatherOccup, FatherIncome);
            }
            string strSchool, strFrom, strTo, strRemarks;
            int Medium1;
            if (txtPrevSchool1.Text != "")
            {

                strSchool = txtPrevSchool1.Text;
                strFrom = txtFrom1.Text;
                strTo = txtTo1.Text;
                Medium1 = Convert.ToInt32(ddlMed1.Items[ddlMed1.SelectedIndex].Value);
                strRemarks = txtrem1.Text;
                if (Request.QueryString["ID"] == null)
                {
                    objStud.AddStudEduHistory(Studid, strSchool, Convert.ToDateTime(ChangeDateFormat(strFrom)), Convert.ToDateTime(ChangeDateFormat(strTo)), Medium1, strRemarks);
                }
                else
                {
                    i = objStud.UpdateStudEduHistory(Studid, strSchool, Convert.ToDateTime(ChangeDateFormat(strFrom)), Convert.ToDateTime(ChangeDateFormat(strTo)), Medium1, strRemarks);
                }
            }
            if (txtPrevSchool2.Text != "")
            {
                strSchool = txtPrevSchool2.Text;
                strFrom = txtFrom2.Text;
                strTo = txtto2.Text;
                Medium1 = Convert.ToInt32(ddlMed2.Items[ddlMed2.SelectedIndex].Value);
                strRemarks = txtrem2.Text;
                if (Request.QueryString["ID"] == null)
                {
                    objStud.AddStudEduHistory(Studid, strSchool, Convert.ToDateTime(ChangeDateFormat(strFrom)), Convert.ToDateTime(ChangeDateFormat(strTo)), Medium1, strRemarks);
                }
                else
                {
                    i = objStud.UpdateStudEduHistory(Studid, strSchool, Convert.ToDateTime(ChangeDateFormat(strFrom)), Convert.ToDateTime(ChangeDateFormat(strTo)), Medium1, strRemarks);
                }
            }
            if (txtPrevSchool3.Text != "")
            {
                strSchool = txtPrevSchool3.Text;
                strFrom = txtFrom3.Text;
                strTo = txtto3.Text;
                Medium1 = Convert.ToInt32(ddlMed3.Items[ddlMed3.SelectedIndex].Value);
                strRemarks = txtrem3.Text;
                if (Request.QueryString["ID"] == null)
                {
                    objStud.AddStudEduHistory(Studid, strSchool, Convert.ToDateTime(ChangeDateFormat(strFrom)), Convert.ToDateTime(ChangeDateFormat(strTo)), Medium1, strRemarks);
                }
                else
                {
                    i = objStud.UpdateStudEduHistory(Studid, strSchool, Convert.ToDateTime(ChangeDateFormat(strFrom)), Convert.ToDateTime(ChangeDateFormat(strTo)), Medium1, strRemarks);
                }
            }
            strMole1 = txtMoles1.Text;
            strMole2 = txtMoles2.Text;
            strEmail = txtEmail.Text;
            if (Request.QueryString["ID"] == null)
            {
                objStud.AddStudIdentification(Studid, strMole1, strMole2,strEmail);
            }
            else
            {
                i = objStud.UpdateStudIdentification(Studid, strMole1, strMole2,strEmail);
            }


            string TcIssuedByJnv="";
            int ExtraCurricular;
            DateTime DateOfIssue = DateTime.Now; 
            TcIssuedByJnv = txtJnvIssue.Text;
            if (txtDateOfIssue.Text != "")
                DateOfIssue = Convert.ToDateTime(ChangeDateFormat(txtDateOfIssue.Text));
            ExtraCurricular = Convert.ToInt32(ddlECA.Items[ddlECA.SelectedIndex].Value);
            if (Request.QueryString["ID"] == null)
            {
                objStud.AddStud_Extra(Studid, ExtraCurricular, TcIssuedByJnv, DateOfIssue);
            }
            else
            {
                i = objStud.UpdateStud_Extra(Studid, ExtraCurricular, TcIssuedByJnv, DateOfIssue);
            }



            string filename, path;
            filename = fudStudent.PostedFile.FileName;
            if (filename != "")
            {
                path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\") + Studid.ToString() + ".jpeg";
                fudStudent.PostedFile.SaveAs(path);
            }
            //filename = fudFatherPhoto.PostedFile.FileName;
            //if (filename != "")
            //{
            //    path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\") + Studid.ToString() + "_F.jpeg";
            //    fudFatherPhoto.PostedFile.SaveAs(path);
            //}
            //filename = fudMother.PostedFile.FileName;
            //if (filename != "")
            //{
            //    path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\") + Studid.ToString() + "_M.jpeg";
            //    fudMother.PostedFile.SaveAs(path);
            //}
            //filename = fudGuardian.PostedFile.FileName;
            //if (filename != "")
            //{
            //    path = Server.MapPath("..\\" + ConfigurationManager.AppSettings["StudentImg"] + "\\") + Studid.ToString() + "_G.jpeg";
            //    fudGuardian.PostedFile.SaveAs(path);
            //}
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("~/student/StudentDetails.aspx?ID=" + Studid.ToString());
            }
            else
            {
                Response.Redirect("~/student/StudentDetails.aspx?ID=" + Studid.ToString());
            }

        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Admission Number Already Exists";
        }
    }
    

    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void txtAdmissionNo_TextChanged(object sender, EventArgs e)
    {
        int count=0;
        count = objStud.CheckStudAdmissionNo(txtAdmissionNo.Text);
        if (count !=0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Admission Number Already Exists";
        }
        else
        {
            lblMessage.Visible = false;
        }
    }
}
