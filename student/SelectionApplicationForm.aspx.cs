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

public partial class student_SelectionApplicationForm : System.Web.UI.Page
{
    BusinessLayer.StudentAdmissionBL StudAdm = new StudentAdmissionBL();
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    DataSet ds = new DataSet();
    DataSet dsEg = new DataSet();
    int i, j;
    int year;
    string RollNo;


    protected void Page_Load(object sender, EventArgs e)
    {
        btnSubmit.Attributes.Add("onclick", "javascript:return validate();");
        DateTime date = DateTime.Now;
        year = date.Year;
        int mnth = date.Month;
        DataSet dsd = new DataSet();
        if (mnth > 5)
        {
            year++;

        }
        if (!IsPostBack)
        {
            
            ds = objcomm.GetEligibleCriteria(year);
            ddlClassIII7.DataSource = ds.Tables[0];
            ddlClassIII7.Items.Add(new ListItem("---Select---", "0"));
            ddlClassIII7.Items.Add(new ListItem(ds.Tables[0].Rows[0]["District"].ToString(), "1"));
            ddlClassIII7.Items.Add(new ListItem("Others", "2"));



            ddlClassIV7.DataSource = ds.Tables[0];
            ddlClassIV7.Items.Add(new ListItem("---Select---", "0"));
            ddlClassIV7.Items.Add(new ListItem(ds.Tables[0].Rows[0]["District"].ToString(), "1"));
            ddlClassIV7.Items.Add(new ListItem("Others", "2"));



            ddlClassV7.DataSource = ds.Tables[0];
            ddlClassV7.Items.Add(new ListItem("---Select---", "0"));
            ddlClassV7.Items.Add(new ListItem(ds.Tables[0].Rows[0]["District"].ToString(), "1"));
            ddlClassV7.Items.Add(new ListItem("Others", "2"));


            for (int j = 2000; j < 2050; j++)
            {
                ddlYearClassIII3.Items.Add(new ListItem(j.ToString(), j.ToString()));

            }
            //ddlYearClassIII3.Items.Insert(0, new ListItem("---Select---", "0"));

            for (int j = 2000; j < 2050; j++)
            {
                ddlYearClassIV3.Items.Add(new ListItem(j.ToString(), j.ToString()));

            }
            //ddlYearClassIV3.Items.Insert(0, new ListItem("---Select---", "0"));


            for (int j = 2000; j < 2050; j++)
            {
                ddlYearClassV3.Items.Add(new ListItem(j.ToString(), j.ToString()));

            }
            //ddlYearClassV3.Items.Insert(0, new ListItem("---Select---", "0"));

            for (int j = 2000; j < 2050; j++)
            {
                ddlYearClassIII4.Items.Add(new ListItem(j.ToString(), j.ToString()));

            }
           // ddlYearClassIV4.Items.Insert(0, new ListItem("---Select---", "0"));

            for (int j = 2000; j < 2050; j++)
            {
                ddlYearClassIV4.Items.Add(new ListItem(j.ToString(), j.ToString()));

            }
            //ddlYearClassIV4.Items.Insert(0, new ListItem("---Select---", "0"));

            for (int j = 2000; j < 2050; j++)
            {
                ddlYearClassV4.Items.Add(new ListItem(j.ToString(), j.ToString()));

            }
            //ddlYearClassV4.Items.Insert(0, new ListItem("---Select---", "0"));

            if (Request.QueryString["ID"] != null)
            {
                RollNo = Request.QueryString["ID"].ToString();
                //RollNo = Request.QueryString["ID"].ToString();
                year = date.Year;
                mnth = date.Month;
                if (mnth > 5)
                {
                    year++;

                }
                ds = objcomm.GetSelectionApplication(RollNo,year);

                txtRollNo.Text = ds.Tables[0].Rows[0]["RollNo"].ToString();
                txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtMiddleName.Text = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                ddlCategory.SelectedValue = ds.Tables[0].Rows[0]["Category"].ToString();
                
                txtdob.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
                ddlNationality1.SelectedValue = ds.Tables[0].Rows[0]["Nationality"].ToString();
                

                txtreligion1.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
                txtMoles1.Text = ds.Tables[0].Rows[0]["Mole1"].ToString();
                txtMoles2.Text = ds.Tables[0].Rows[0]["Mole2"].ToString();
                if (ds.Tables[0].Rows[0]["Gender"].ToString() == "0")
                {
                    rbfemale.Checked = true;
                }
                 if (ds.Tables[0].Rows[0]["Gender"].ToString() == "1")
                {
                    rbmale.Checked = true;
                }

                if (ds.Tables[0].Rows[0]["UrbnRural"].ToString() == "0")
                {
                    rbtnRural.Checked = true;
                }
                 if (ds.Tables[0].Rows[0]["UrbnRural"].ToString() == "1")
                {
                    rbtnUrban.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["DisabledPH"].ToString() == "0")
                {
                    chkPH.Checked = false;
                }
                if (ds.Tables[0].Rows[0]["DisabledPH"].ToString() == "1")
                {
                    chkPH.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["DisabledVI"].ToString() == "0")
                {
                    chkVm.Checked = false;
                }
                 if (ds.Tables[0].Rows[0]["DisabledVI"].ToString() == "1")
                {
                    chkVm.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["DisabledHI"].ToString() == "0")
                {
                    chkHI.Checked = false;
                }
                if (ds.Tables[0].Rows[0]["DisabledHI"].ToString() == "1")
                {
                    chkHI.Checked = true;
                }
                txtfathername.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                txtMotherName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
                txtguardname.Text = ds.Tables[0].Rows[0]["GuardianName"].ToString();
                txtRelvthguard.Text = ds.Tables[0].Rows[0]["RelationshipWithCandidate"].ToString();
                txtpresentadd.Text = ds.Tables[0].Rows[0]["PersentPostalAddress"].ToString();
                txtPincode1.Text = ds.Tables[0].Rows[0]["PinCode1"].ToString();
                txtpremenentAdd1.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
                txtPinCode2.Text = ds.Tables[0].Rows[0]["Pincode2"].ToString();
                txttelephone.Text = ds.Tables[0].Rows[0]["TelephoneNo"].ToString();
                txtEmailID.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();

                txtClassIII1.Text = ds.Tables[0].Rows[0]["NameoftheSchoolIII"].ToString();
                txtClassIV1.Text = ds.Tables[0].Rows[0]["NameoftheSchoolIV"].ToString();
                txtClassV1.Text = ds.Tables[0].Rows[0]["NameoftheSchoolV"].ToString();
                if (ds.Tables[0].Rows[0]["CategoryofSchoolIII"].ToString() == "0")
                {
                    rbRecSchoolNo.Checked = true;
                }
                 if (ds.Tables[0].Rows[0]["CategoryofSchoolIII"].ToString() == "1")
                {
                    rbRecSchoolYes.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["CategoryofSchoolIV"].ToString() == "0")
                {
                    rbRecSchoolNo1.Checked = true;
                }
                 if (ds.Tables[0].Rows[0]["CategoryofSchoolIV"].ToString() == "1")
                {
                    rbRecSchoolYes1.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["CategoryofSchoolV"].ToString() == "0")
                {
                    rbRecSchoolNo2.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["CategoryofSchoolV"].ToString() == "1")
                {
                    rbRecSchoolYes2.Checked = true;
                }
                ddlMnthClassIII3.SelectedValue  = ds.Tables[0].Rows[0]["MonthofjoiningIII"].ToString();
                ddlYearClassIII3.SelectedValue = ds.Tables[0].Rows[0]["YearofjoingIII"].ToString();
                ddlMnthClassIV3.SelectedValue = ds.Tables[0].Rows[0]["MonthofjoiningIV"].ToString();
                ddlYearClassIV3.SelectedValue = ds.Tables[0].Rows[0]["YearofjoiningIV"].ToString();
                ddlMnthClassV3.SelectedValue = ds.Tables[0].Rows[0]["MonthofjoiningV"].ToString();
                ddlYearClassV3.SelectedValue = ds.Tables[0].Rows[0]["YearofjoiningV"].ToString();
                ddlMnthClassIII4.SelectedValue = ds.Tables[0].Rows[0]["MonthofpassingIII"].ToString();
                ddlYearClassIII4.SelectedValue = ds.Tables[0].Rows[0]["YearofpassingIII"].ToString();
                ddlMnthClassIV4.SelectedValue = ds.Tables[0].Rows[0]["MonthofpassingIV"].ToString();
                ddlYearClassIV4.SelectedValue = ds.Tables[0].Rows[0]["YearofpassingIV"].ToString();
                ddlMnthClassV4.SelectedValue = ds.Tables[0].Rows[0]["MonthofpassingV"].ToString();
                ddlYearClassV4.SelectedValue = ds.Tables[0].Rows[0]["YearofpassingV"].ToString();
                txtClassIII5.Text = ds.Tables[0].Rows[0]["NameofthevillageorTownIII"].ToString();
                txtClassIV5.Text = ds.Tables[0].Rows[0]["NameofthevillageorTownIV"].ToString();
                txtClassV5.Text = ds.Tables[0].Rows[0]["NameofthevillageorTownV"].ToString();
                txtClassIII6.Text = ds.Tables[0].Rows[0]["NameoftheBlockIII"].ToString();
                txtClassIV6.Text = ds.Tables[0].Rows[0]["NameoftheBlockIV"].ToString();
                txtClassV6.Text = ds.Tables[0].Rows[0]["NameoftheBlockV"].ToString();
                ddlClassIII7.SelectedValue = ds.Tables[0].Rows[0]["NameoftheDistrictIII"].ToString();
                ddlClassIV7.SelectedValue = ds.Tables[0].Rows[0]["NameoftheDistrictIV"].ToString();
                ddlClassV7.SelectedValue = ds.Tables[0].Rows[0]["NameoftheDistrictV"].ToString();
                if (ds.Tables[0].Rows[0]["SchoollLocUrbanOrRuralIII"].ToString() == "0")
                {
                    rbSchoolLocRural.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["SchoollLocUrbanOrRuralIII"].ToString() == "1")
                {
                    rbSchoolLocUrban.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["SchoollLocUrbanOrRuralIV"].ToString() == "0")
                {
                    rbSchoolLocRural1.Checked = true;
                }
                 if (ds.Tables[0].Rows[0]["SchoollLocUrbanOrRuralIV"].ToString() == "1")
                {
                    rbSchoolLocUrban1.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["SchoollLocUrbanOrRuralV"].ToString() == "0")
                {
                    rbSchoolLocRural2.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["SchoollLocUrbanOrRuralV"].ToString() == "1")
                {
                    rbSchoolLocUrban2.Checked = true;
                }
                btnSubmit.Text = "Update";
                txtRollNo.Enabled = false;
              
            }

        }
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int i = 0, j = 0;
        int MonthofjoiningIII=0, YearofjoingIII=0, MonthofpassingIII=0, YearofpassingIII=0, MonthofjoiningIV=0, YearofjoiningIV=0, MonthofpassingIV=0, YearofpassingIV=0, MonthofjoiningV=0, YearofjoiningV=0, MonthofpassingV=0, YearofpassingV=0, DisabledPH,  DisabledVI,  DisabledHI; 
        int Category, Nationality, Gender, UrbnRural, Disabled = 0, CategoryofSchoolIII, SchoollLocUrbanOrRuralIII, CategoryofSchoolIV, SchoollLocUrbanOrRuralIV = 0, CategoryofSchoolV = 0, SchoollLocUrbanOrRuralV = 0, NameoftheDistrictV, NameoftheDistrictIV, NameoftheDistrictIII;
        string RollNo=String.Empty, FirstName, MiddleName, LastName, DOB=String.Empty, Religion, Mole1, Mole2, FatherName, MotherName, GuardianName, RelationshipWithCandidate, PersentPostalAddress, PinCode1, PermanentAddress, Pincode2, TelephoneNo, EmailId;
        string NameoftheSchoolIII,  NameofthevillageorTownIII, NameoftheBlockIII,  NameoftheSchoolIV, NameofthevillageorTownIV, NameoftheBlockIV,  NameoftheSchoolV,  NameofthevillageorTownV, NameoftheBlockV;
        RollNo = txtRollNo.Text;
        FirstName = txtFirstName.Text;
        MiddleName = txtMiddleName.Text;
        LastName = txtLastName.Text;
        
        if (txtdob.Text != "")
        DOB = txtdob.Text;
        Religion = txtreligion1.Text;
        Mole1 = txtMoles1.Text;
        Mole2 = txtMoles2.Text;
        FatherName = txtfathername.Text;
        MotherName = txtMotherName.Text;
        GuardianName = txtguardname.Text;
        RelationshipWithCandidate = txtRelvthguard.Text;
        PersentPostalAddress = txtpresentadd.Text;
        PinCode1 = txtPincode1.Text;
        PermanentAddress = txtpremenentAdd1.Text;
        Pincode2 = txtPinCode2.Text;
        TelephoneNo = txttelephone.Text;
        EmailId = txtEmailID.Text;
        NameoftheSchoolIII=txtClassIII1.Text;

        MonthofjoiningIII = Convert.ToInt32(ddlMnthClassIII3.Items[ddlMnthClassIII3.SelectedIndex].Value);
        YearofjoingIII = Convert.ToInt32(ddlYearClassIII3.Items[ddlYearClassIII3.SelectedIndex].Value);
        MonthofpassingIII = Convert.ToInt32(ddlMnthClassIII4.Items[ddlMnthClassIII4.SelectedIndex].Value);
        YearofpassingIII = Convert.ToInt32(ddlYearClassIII4.Items[ddlYearClassIII4.SelectedIndex].Value);

        NameofthevillageorTownIII=txtClassIII5.Text;
        NameoftheBlockIII=txtClassIII6.Text;

        NameoftheDistrictIII = Convert.ToInt32(ddlClassIII7.Items[ddlClassIII7.SelectedIndex].Value);

        NameoftheSchoolIV = txtClassIV1.Text;

        MonthofjoiningIV = Convert.ToInt32(ddlMnthClassIV3.Items[ddlMnthClassIV3.SelectedIndex].Value);
        YearofjoiningIV = Convert.ToInt32(ddlYearClassIV3.Items[ddlYearClassIV3.SelectedIndex].Value);
        MonthofpassingIV = Convert.ToInt32(ddlMnthClassIV4.Items[ddlMnthClassIV4.SelectedIndex].Value);
        YearofpassingIV = Convert.ToInt32(ddlYearClassIV4.Items[ddlYearClassIV4.SelectedIndex].Value);


        NameofthevillageorTownIV = txtClassIV5.Text;
        NameoftheBlockIV = txtClassIV6.Text;
        NameoftheDistrictIV = Convert.ToInt32(ddlClassIV7.Items[ddlClassIV7.SelectedIndex].Value);

        NameoftheSchoolV = txtClassV1.Text;

        MonthofjoiningV = Convert.ToInt32(ddlMnthClassV3.Items[ddlMnthClassV3.SelectedIndex].Value);
        YearofjoiningV = Convert.ToInt32(ddlYearClassV3.Items[ddlYearClassV3.SelectedIndex].Value);
        MonthofpassingV = Convert.ToInt32(ddlMnthClassV4.Items[ddlMnthClassV4.SelectedIndex].Value);
        YearofpassingV = Convert.ToInt32(ddlYearClassV4.Items[ddlYearClassV4.SelectedIndex].Value);


        NameofthevillageorTownV = txtClassV5.Text;
        NameoftheBlockV = txtClassV6.Text;
        NameoftheDistrictV = Convert.ToInt32(ddlClassV7.Items[ddlClassV7.SelectedIndex].Value);
        Category = Convert.ToInt32(ddlCategory.Items[ddlCategory.SelectedIndex].Value);
        Nationality = Convert.ToInt32(ddlNationality1.Items[ddlCategory.SelectedIndex].Value);
        if (rbmale.Checked == true)
        {
            Gender = 1;
        }
        else
        {
            Gender = 0;
        }

        if (rbtnUrban.Checked == true)
        {
            UrbnRural = 1;
        }
        else
        {
            UrbnRural = 0;
        }

        if (rbSchoolLocUrban.Checked == true)
        {
            SchoollLocUrbanOrRuralIII = 1;
        }
        else
        {
            SchoollLocUrbanOrRuralIII = 0;
        }

        if (rbSchoolLocUrban1.Checked == true)
        {
            SchoollLocUrbanOrRuralIV = 1;
        }
        else
        {
            SchoollLocUrbanOrRuralIV = 0;
        }

        if (rbSchoolLocUrban2.Checked == true)
        {
            SchoollLocUrbanOrRuralV = 1;
        }
        else
        {
            SchoollLocUrbanOrRuralV = 0;
        }

        if (rbRecSchoolYes.Checked == true)
        {
            CategoryofSchoolIII = 1;
        }
        else
        {
            CategoryofSchoolIII = 0;
        }

        if (rbRecSchoolYes1.Checked == true)
        {
            CategoryofSchoolIV = 1;
        }
        else
        {
            CategoryofSchoolIV = 0;
        }

        if (rbRecSchoolYes2.Checked == true)
        {
            CategoryofSchoolV = 1;
        }
        else
        {
            CategoryofSchoolV = 0;
        }



        if (chkPH.Checked == true)
        {
            DisabledPH = 1;
        }
        else
        {
            DisabledPH = 0;
        }
        if (chkVm.Checked == true)
        {
            DisabledVI = 1;
        }
        else
        {
            DisabledVI = 0;
        }
        if (chkHI.Checked == true)
        {
            DisabledHI = 1;
        }
        else
        {
            DisabledHI = 0;
        }
       

        i = StudAdm.AddSelectionApplication1(RollNo, FirstName, MiddleName, LastName, Category, DOB, Nationality, Religion, Mole1, Mole2, Gender, UrbnRural, DisabledPH,  DisabledVI,  DisabledHI, FatherName, MotherName, GuardianName, RelationshipWithCandidate, PersentPostalAddress, PinCode1, PermanentAddress, Pincode2, TelephoneNo, EmailId);
        if (i == 1)
        {
            j = StudAdm.AddSelectionApplication2(RollNo, NameoftheSchoolIII, CategoryofSchoolIII, MonthofjoiningIII, YearofjoingIII, MonthofpassingIII, YearofpassingIII, NameofthevillageorTownIII, NameoftheBlockIII, NameoftheDistrictIII, SchoollLocUrbanOrRuralIII, NameoftheSchoolIV, CategoryofSchoolIV, MonthofjoiningIV, YearofjoiningIV, MonthofpassingIV, YearofpassingIV, NameofthevillageorTownIV, NameoftheBlockIV, NameoftheDistrictIV, SchoollLocUrbanOrRuralIV, NameoftheSchoolV, CategoryofSchoolV, MonthofjoiningV, YearofjoiningV, MonthofpassingV, YearofpassingV, NameofthevillageorTownV, NameoftheBlockV, NameoftheDistrictV, SchoollLocUrbanOrRuralV);
        }
        else
        {
            RollNo = Request.QueryString["ID"].ToString();
            i = objcomm.EditSelectionApplication1(RollNo, FirstName, MiddleName, LastName, Category, DOB, Nationality, Religion, Mole1, Mole2, Gender, UrbnRural, DisabledPH, DisabledVI, DisabledHI, FatherName, MotherName, GuardianName, RelationshipWithCandidate, PersentPostalAddress, PinCode1, PermanentAddress, Pincode2, TelephoneNo, EmailId);
            if (i == 1)
            {
              j = objcomm.EditSelectionApplication2(RollNo, NameoftheSchoolIII,CategoryofSchoolIII, MonthofjoiningIII, YearofjoingIII, MonthofpassingIII, YearofpassingIII, NameofthevillageorTownIII, NameoftheBlockIII, NameoftheDistrictIII, SchoollLocUrbanOrRuralIII, NameoftheSchoolIV, CategoryofSchoolIV, MonthofjoiningIV, YearofjoiningIV, MonthofpassingIV, YearofpassingIV, NameofthevillageorTownIV, NameoftheBlockIV, NameoftheDistrictIV, SchoollLocUrbanOrRuralIV, NameoftheSchoolV, CategoryofSchoolV, MonthofjoiningV, YearofjoiningV, MonthofpassingV, YearofpassingV, NameofthevillageorTownV, NameoftheBlockV, NameoftheDistrictV, SchoollLocUrbanOrRuralV);
            }

        }
        
        RollNo = txtRollNo.Text;
        ds = objcomm.GetSelectionApplication(RollNo,year);
        DataSet dsEg = new DataSet();
        string gg = ",";
        int count = 0;
        string res="";
        dsEg = objcomm.GetEligibleCriteria(year);
        if ((Convert.ToDateTime(ChangeDateFormat(ds.Tables[0].Rows[0]["DOB"].ToString()))) < (Convert.ToDateTime(ChangeDateFormat(dsEg.Tables[0].Rows[0]["DOBFromDate"].ToString()))) && (Convert.ToDateTime(ChangeDateFormat(ds.Tables[0].Rows[0]["DOB"].ToString()))) < (Convert.ToDateTime(ChangeDateFormat(dsEg.Tables[0].Rows[0]["DOBToDate"].ToString()))))
        {

             //i = objcomm.AddEligible(RollNo, year, 1, " Date of birth not between " + (dsEg.Tables[0].Rows[0]["DOBFromDate"].ToString()) + " and " + (dsEg.Tables[0].Rows[0]["DOBToDate"].ToString()));
             count++;
             res = " Date of birth not between " + (dsEg.Tables[0].Rows[0]["DOBFromDate"].ToString()) + " and " + (dsEg.Tables[0].Rows[0]["DOBToDate"].ToString());
        }
          if ((ddlClassIII7.SelectedIndex != 1) || (ddlClassIV7.SelectedIndex != 1) || (ddlClassV7.SelectedIndex != 1))
        {
            //i = objcomm.AddEligible(RollNo, year, 1, "Not Studied in The Local Distict ");
            count++;
            res = res + gg + "Not Studied in The Local Distict";
        }
         if ((rbRecSchoolNo.Checked == true) || (rbRecSchoolNo1.Checked == true) || (rbRecSchoolNo2.Checked == true))
        {
            //i = objcomm.AddEligible(RollNo, year, 1, "Not Recognized ");
            count++;
             res = res + gg + "Not Recognized";
        }
         if ((ddlYearClassV4.SelectedValue != (dsEg.Tables[0].Rows[0]["YearOfStudyingVClass"].ToString())))
        {
           // i = objcomm.AddEligible(RollNo, year, 1, "Not 5th class ");
            count++;
            res = res + gg + "Not Studying 5th class In The year" + " " + (dsEg.Tables[0].Rows[0]["YearOfStudyingVClass"].ToString());
        }
         if ((ddlYearClassIV4.SelectedValue != ddlYearClassIII4.SelectedValue + 1) || (ddlYearClassV4.SelectedValue != ddlYearClassIV4.SelectedValue + 1))
         {
             //  i = objcomm.AddEligible(RollNo, year, 1, "aaa");
             count++;
             res = res + gg + " No Continuity in Studies Between 3rd and 5th Classes";
         }

         if (count > 0)
         {
             i = objcomm.AddEligible(RollNo, year, 1, res);

         }
         else
         {
             i = objcomm.AddEligible(RollNo, year, 2, "Eligible");
         }

        if (btnSubmit.Text == "Update")
        {
            dsEg = objcomm.GetEligibleCriteria(year);
            if ((Convert.ToDateTime(ChangeDateFormat(ds.Tables[0].Rows[0]["DOB"].ToString()))) < (Convert.ToDateTime(ChangeDateFormat(dsEg.Tables[0].Rows[0]["DOBFromDate"].ToString()))) && (Convert.ToDateTime(ChangeDateFormat(ds.Tables[0].Rows[0]["DOB"].ToString()))) < (Convert.ToDateTime(ChangeDateFormat(dsEg.Tables[0].Rows[0]["DOBToDate"].ToString()))))
            {

                //i = objcomm.EditEligible(RollNo, year, 1, " Date of birth not between " + (dsEg.Tables[0].Rows[0]["DOBFromDate"].ToString()) + " and " + (dsEg.Tables[0].Rows[0]["DOBToDate"].ToString()));
                count++;
                res = " Date of birth not between " + (dsEg.Tables[0].Rows[0]["DOBFromDate"].ToString()) + " and " + (dsEg.Tables[0].Rows[0]["DOBToDate"].ToString());
            }
             if ((ddlClassIII7.SelectedIndex != 1) || (ddlClassIV7.SelectedIndex != 1) || (ddlClassV7.SelectedIndex != 1))
            {
                //i = objcomm.EditEligible(RollNo, year, 1, "Not Studied in The Local Distict ");
                count++;
                res = res + gg + "Not Studied in The Local Distict";
            }
             if ((rbRecSchoolNo.Checked == true) || (rbRecSchoolNo1.Checked == true) || (rbRecSchoolNo2.Checked == true))
            {
                //i = objcomm.EditEligible(RollNo, year, 1, "Not Recognized ");
                count++;
                res = res + gg + "Not Recognized";
            }
           
             if ((ddlYearClassV4.SelectedValue != (dsEg.Tables[0].Rows[0]["YearOfStudyingVClass"].ToString())))
            {
                //i = objcomm.EditEligible(RollNo, year, 1, "Not 5th class ");
                count++;
                res = res + gg + "Not Studying 5th class In The year"  + " " +  (dsEg.Tables[0].Rows[0]["YearOfStudyingVClass"].ToString());
            }
             if ((ddlYearClassIV4.SelectedValue != ddlYearClassIII4.SelectedValue + 1) || (ddlYearClassV4.SelectedValue != ddlYearClassIV4.SelectedValue + 1))
             {
                 //  i = objcomm.AddEligible(RollNo, year, 1, "aaa");
                 count++;
                 res = res + gg + " No Continuity in Studies Between 3rd and 5th Classes";
             }
             if (count > 0)
             {
                 i = objcomm.EditEligible(RollNo, year, 1, res);

             }
             else
             {
                 i = objcomm.EditEligible(RollNo, year, 2, "Eligible");
             }
        }

        if (Request.QueryString["ID"] == null)
        {
            Response.Redirect("EditStdSelectionApplication.aspx?ID=" + RollNo);
        }
        else
        {
            Response.Redirect("EditStdSelectionApplication.aspx?ID=" + Request.QueryString["ID"].ToString());
        }
       }
          public string ChangeDateFormat(string Date)
        {
            return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
        }
}