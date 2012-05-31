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

public partial class student_EditStdSelectionApplication : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    DataSet ds = new DataSet();
    string RollNo;
    protected void Page_Load(object sender, EventArgs e)
    
    {
        if (Request.QueryString["ID"] != null)
        {

            int year;
            RollNo = Request.QueryString["ID"].ToString();
            DateTime date = DateTime.Now;
            year = date.Year;
            int mnth = date.Month;
            DataSet dsd = new DataSet();
            if (mnth > 5)
            {
                year++;

            }
            ds = objcomm.GetSelectionApplication(RollNo,year);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblRollNo.Text = ds.Tables[0].Rows[0]["RollNo"].ToString();
                    lblFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    lblMiddleName.Text = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                    lblLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                    if (ds.Tables[0].Rows[0]["Category"].ToString() == "1")
                        lblCategory.Text = "OC";
                    if (ds.Tables[0].Rows[0]["Category"].ToString() == "2")
                        lblCategory.Text = "OBC";

                    lbldob.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
                    if (ds.Tables[0].Rows[0]["Nationality"].ToString() == "1")
                        lblNationality1.Text = "Indian";
                    if (ds.Tables[0].Rows[0]["Nationality"].ToString() == "2")
                        lblNationality1.Text = "NRI";

                    lblreligion1.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
                    lblMoles1.Text = ds.Tables[0].Rows[0]["Mole1"].ToString();
                    lblMoles2.Text = ds.Tables[0].Rows[0]["Mole2"].ToString();
                    if (ds.Tables[0].Rows[0]["Gender"].ToString() == "1")
                    {
                        lblGender.Text = "Boy";
                    }
                     if (ds.Tables[0].Rows[0]["Gender"].ToString() == "0")
                    {
                        lblGender.Text = "Girl";
                    }

                    if (ds.Tables[0].Rows[0]["UrbnRural"].ToString() == "0")
                    {
                        lblUrbanRural.Text = "Rural";
                    }
                     if (ds.Tables[0].Rows[0]["UrbnRural"].ToString() == "1")
                    {
                        lblUrbanRural.Text = "Urban";
                    }
                    if (ds.Tables[0].Rows[0]["DisabledPH"].ToString() == "0")
                    {
                        lblPH.Text = "";
                    }
                    string gg = ",";
                     if (ds.Tables[0].Rows[0]["DisabledPH"].ToString() == "1")
                    {
                        lblPH.Text = "Physically handicapped";
                    }
                    if (ds.Tables[0].Rows[0]["DisabledVI"].ToString() == "0")
                    {
                        lblVm.Text = "";
                    }
                     if (ds.Tables[0].Rows[0]["DisabledVI"].ToString() == "1")
                    {
                        lblVm.Text = gg+"Visually Impaired";
                    }
                    if (ds.Tables[0].Rows[0]["DisabledHI"].ToString() == "0")
                    {
                        lblHI.Text = " ";
                    }
                    if (ds.Tables[0].Rows[0]["DisabledHI"].ToString() == "1")
                    {
                        lblHI.Text = gg+"Hearing Impaired";
                    }
                    lblfathername.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                    lblMotherName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
                    lblguardname.Text = ds.Tables[0].Rows[0]["GuardianName"].ToString();
                    lblRelvthguard.Text = ds.Tables[0].Rows[0]["RelationshipWithCandidate"].ToString();
                    lblpresentadd.Text = ds.Tables[0].Rows[0]["PersentPostalAddress"].ToString();
                    lblPincode1.Text = ds.Tables[0].Rows[0]["PinCode1"].ToString();
                    lblpremenentAdd1.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
                    lblPinCode2.Text = ds.Tables[0].Rows[0]["Pincode2"].ToString();
                    lbltelephone.Text = ds.Tables[0].Rows[0]["TelephoneNo"].ToString();
                    lblEmailID.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                    lblNameoftheSchoolClassIII.Text = ds.Tables[0].Rows[0]["NameoftheSchoolIII"].ToString();
                    LblNameoftheSchoolClassIV.Text = ds.Tables[0].Rows[0]["NameoftheSchoolIV"].ToString();
                    lblNameoftheSchoolClassV.Text = ds.Tables[0].Rows[0]["NameoftheSchoolV"].ToString();
                    if (ds.Tables[0].Rows[0]["CategoryofSchoolIII"].ToString() == "0")
                    {
                        lblRecSchoolYesNoClassIII.Text = "No";
                    }
                     if (ds.Tables[0].Rows[0]["CategoryofSchoolIII"].ToString() == "1")
                    {
                        lblRecSchoolYesNoClassIII.Text = "Yes";
                    }
                    if (ds.Tables[0].Rows[0]["CategoryofSchoolIV"].ToString() == "0")
                    {
                        lblRecSchoolYesNoClassIV.Text = "No";
                    }
                    if (ds.Tables[0].Rows[0]["CategoryofSchoolIV"].ToString() == "1")
                    {
                        lblRecSchoolYesNoClassIV.Text = "Yes";
                    }
                    if (ds.Tables[0].Rows[0]["CategoryofSchoolV"].ToString() == "0")
                    {
                        lblRecSchoolYesNoClassV.Text = "No";
                    }
                     if (ds.Tables[0].Rows[0]["CategoryofSchoolV"].ToString() == "1")
                    {
                        lblRecSchoolYesNoClassV.Text = "Yes";
                    }
                     string[] arr1 = new string[] { "Jan", "Feb", "March", "April", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
                     

                         lblMnthJoiningClassIII.Text = arr1[Convert.ToInt32(ds.Tables[0].Rows[0]["MonthofjoiningIII"].ToString())-1].ToString();
                    
                    lblYearJoiningClassIII.Text = ds.Tables[0].Rows[0]["YearofjoingIII"].ToString();
                    lblMnthJoiningClassIV.Text = arr1[Convert.ToInt32(ds.Tables[0].Rows[0]["MonthofjoiningIV"].ToString()) - 1].ToString();
                        
                    lblYearJoiningClassIV.Text = ds.Tables[0].Rows[0]["YearofjoiningIV"].ToString();
                    lblMnthJoiningClassV.Text = arr1[Convert.ToInt32(ds.Tables[0].Rows[0]["MonthofjoiningV"].ToString()) - 1].ToString();
                        
                    lblYearJoiningClassV.Text = ds.Tables[0].Rows[0]["YearofjoiningV"].ToString();
                    lblMnthPassingClassIII.Text = arr1[Convert.ToInt32(ds.Tables[0].Rows[0]["MonthofpassingIII"].ToString()) - 1].ToString();
                        
                    lblYearPassingClassIII.Text = ds.Tables[0].Rows[0]["YearofpassingIII"].ToString();
                    lblMnthPassingClassIV.Text = arr1[Convert.ToInt32(ds.Tables[0].Rows[0]["MonthofpassingIV"].ToString()) - 1].ToString();
                        
                    lblYearPassingClassIV.Text = ds.Tables[0].Rows[0]["YearofpassingIV"].ToString();
                    lblMnthPassingClassV.Text = arr1[Convert.ToInt32(ds.Tables[0].Rows[0]["MonthofpassingV"].ToString()) - 1].ToString();
                        
                    lblYearPassingClassV.Text = ds.Tables[0].Rows[0]["YearofpassingV"].ToString();
                    lblNameoftheVillageClassIII.Text = ds.Tables[0].Rows[0]["NameofthevillageorTownIII"].ToString();
                    lblNameoftheVillageClassIV.Text = ds.Tables[0].Rows[0]["NameofthevillageorTownIV"].ToString();
                    lblNameoftheVillageClassV.Text = ds.Tables[0].Rows[0]["NameofthevillageorTownV"].ToString();
                    lblNameOfBlockClassIII.Text = ds.Tables[0].Rows[0]["NameoftheBlockIII"].ToString();
                    lblNameOfBlockClassIV.Text = ds.Tables[0].Rows[0]["NameoftheBlockIV"].ToString();
                    lblNameOfBlockClassV.Text = ds.Tables[0].Rows[0]["NameoftheBlockV"].ToString();
                    if (ds.Tables[0].Rows[0]["NameoftheDistrictIII"].ToString() == "1")
                    {
                        lblNameOfDistrictClassIII.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    }
                    else
                    {
                        lblNameOfDistrictClassIII.Text = "Others";
                    }
                    if (ds.Tables[0].Rows[0]["NameoftheDistrictIV"].ToString() == "1")
                    {
                        lblNameOfDistrictClassIV.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    }
                    else
                    {
                        lblNameOfDistrictClassIV.Text = "Others";
                    }
                    if (ds.Tables[0].Rows[0]["NameoftheDistrictV"].ToString() == "1")
                    {
                        lblNameOfDistrictClassV.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    }
                    else
                    {
                        lblNameOfDistrictClassV.Text = "Others";
                    }

                    //lblNameOfDistrictClassIII.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    //lblNameOfDistrictClassIV.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    //lblNameOfDistrictClassV.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    if (ds.Tables[0].Rows[0]["SchoollLocUrbanOrRuralIII"].ToString() == "0")
                    {
                        lblSchoolLocUrbanRuralClassIII.Text = "Rural";
                    }
                     if (ds.Tables[0].Rows[0]["SchoollLocUrbanOrRuralIII"].ToString() == "1")
                    {
                        lblSchoolLocUrbanRuralClassIII.Text = "Urban";
                    }
                    if (ds.Tables[0].Rows[0]["SchoollLocUrbanOrRuralIV"].ToString() == "0")
                    {
                        lblSchoolLocUrbanRuralClassIV.Text = "Rural";
                    }
                     if (ds.Tables[0].Rows[0]["SchoollLocUrbanOrRuralIV"].ToString() == "1")
                    {
                        lblSchoolLocUrbanRuralClassIV.Text = "Urban";
                    }
                    if (ds.Tables[0].Rows[0]["SchoollLocUrbanOrRuralV"].ToString() == "0")
                    {
                        lblSchoolLocUrbanRuralClassV.Text = "Rural";
                    }
                    if (ds.Tables[0].Rows[0]["SchoollLocUrbanOrRuralV"].ToString() == "1")
                    {
                        lblSchoolLocUrbanRuralClassV.Text = "Urban";
                    }
                }

            }
        }
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("SelectionApplicationForm.aspx?ID=" + RollNo + "");

    }
}
