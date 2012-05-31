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

public partial class Alumni_Information : System.Web.UI.Page
{
    BusinessLayer.StudentAdmissionBL objStud = new StudentAdmissionBL();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnsave.Attributes.Add("onclick", "javascript:return validateSave();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            for (int i = 1950; i <= 2050; i++)
            {
                ddlYearOfPassing.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlYearOfPassing.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        int i = 0;
        string strDOB=String.Empty;
        strDOB = ChangeDateFormat(txtDateOfBirth.Text);
        string strQualificationDate=String.Empty;
        string strStatusDate=String.Empty;
        if (txtQualificationDate.Text != "")
            strQualificationDate = ChangeDateFormat(txtQualificationDate.Text);
        if(txtStatusDate.Text!="")
        strStatusDate = ChangeDateFormat(txtStatusDate.Text);
           if (rbEngineer.Checked == true)
           {
               if (ddlEngineers.SelectedIndex != 0)
               {
                       i = objStud.AddStudAlumniInfo(txtAdmissionNo.Text, txtAlumniName.Text, Convert.ToDateTime(strDOB), txtFathersName.Text, txtPermanentAddress.Text, txtCorrespondingAddress.Text, txtTelephoneNo.Text, txtEmailId.Text, txtPresentAddress.Text, txtPresentTelephNo.Text, txtQualification.Text, Convert.ToDateTime(strQualificationDate), Convert.ToInt32(ddlYearOfPassing.Items[ddlYearOfPassing.SelectedIndex].Value), txtJobStatus.Text, Convert.ToDateTime(strStatusDate), 1, Convert.ToInt32(ddlEngineers.Items[ddlEngineers.SelectedIndex].Value), txtJobStatus1.Text, true, txtDesign.Text, txtOfficeAddress.Text, txtRemarks.Text);
                   
               }
           }
       
        if (rbMedicos.Checked == true)
        {
            if (ddlMedicos.SelectedIndex != 0)
            {

                i = objStud.AddStudAlumniInfo(txtAdmissionNo.Text, txtAlumniName.Text, Convert.ToDateTime(strDOB), txtFathersName.Text, txtPermanentAddress.Text, txtCorrespondingAddress.Text,txtTelephoneNo.Text, txtEmailId.Text, txtPresentAddress.Text, txtPresentTelephNo.Text, txtQualification.Text, Convert.ToDateTime(strQualificationDate), Convert.ToInt32(ddlYearOfPassing.Items[ddlYearOfPassing.SelectedIndex].Value), txtJobStatus.Text, Convert.ToDateTime(strStatusDate), 2, Convert.ToInt32(ddlMedicos.Items[ddlMedicos.SelectedIndex].Value), txtJobStatus1.Text, true, txtDesign.Text, txtOfficeAddress.Text, txtRemarks.Text);
                
            }
        }
        if (rbAdministrators.Checked == true)
        {
            if (ddlAdministrator.SelectedIndex != 0)
            {

                i = objStud.AddStudAlumniInfo(txtAdmissionNo.Text, txtAlumniName.Text, Convert.ToDateTime(strDOB), txtFathersName.Text, txtPermanentAddress.Text, txtCorrespondingAddress.Text, txtTelephoneNo.Text, txtEmailId.Text, txtPresentAddress.Text, txtPresentTelephNo.Text, txtQualification.Text, Convert.ToDateTime(strQualificationDate), Convert.ToInt32(ddlYearOfPassing.Items[ddlYearOfPassing.SelectedIndex].Value), txtJobStatus.Text, Convert.ToDateTime(strStatusDate), 3, Convert.ToInt32(ddlAdministrator.Items[ddlAdministrator.SelectedIndex].Value), txtJobStatus1.Text, true, txtDesign.Text, txtOfficeAddress.Text, txtRemarks.Text);
                
            }
        }
        if (rbManager.Checked == true)
        {
            if (ddlManager.SelectedIndex != 0)
            {

                i = objStud.AddStudAlumniInfo(txtAdmissionNo.Text, txtAlumniName.Text, Convert.ToDateTime(strDOB), txtFathersName.Text, txtPermanentAddress.Text, txtCorrespondingAddress.Text, txtTelephoneNo.Text, txtEmailId.Text, txtPresentAddress.Text, txtPresentTelephNo.Text, txtQualification.Text, Convert.ToDateTime(strQualificationDate), Convert.ToInt32(ddlYearOfPassing.Items[ddlYearOfPassing.SelectedIndex].Value), txtJobStatus.Text, Convert.ToDateTime(strStatusDate), 4, Convert.ToInt32(ddlManager.Items[ddlManager.SelectedIndex].Value), txtJobStatus1.Text, true, txtDesign.Text, txtOfficeAddress.Text, txtRemarks.Text);
                
            }
        }
        if (rbDefence.Checked == true)
        {
            if (ddlDefence.SelectedIndex != 0)
            {

                i = objStud.AddStudAlumniInfo(txtAdmissionNo.Text, txtAlumniName.Text, Convert.ToDateTime(strDOB), txtFathersName.Text, txtPermanentAddress.Text, txtCorrespondingAddress.Text, txtTelephoneNo.Text, txtEmailId.Text, txtPresentAddress.Text,txtPresentTelephNo.Text, txtQualification.Text, Convert.ToDateTime(strQualificationDate), Convert.ToInt32(ddlYearOfPassing.Items[ddlYearOfPassing.SelectedIndex].Value), txtJobStatus.Text, Convert.ToDateTime(strStatusDate), 5, Convert.ToInt32(ddlDefence.Items[ddlDefence.SelectedIndex].Value), txtJobStatus1.Text, true, txtDesign.Text, txtOfficeAddress.Text, txtRemarks.Text);
                
            }
        }
        if (rbMainLiners.Checked == true)
        {
            if (ddMainLiners.SelectedIndex != 0)
            {

                i = objStud.AddStudAlumniInfo(txtAdmissionNo.Text, txtAlumniName.Text, Convert.ToDateTime(strDOB), txtFathersName.Text, txtPermanentAddress.Text, txtCorrespondingAddress.Text, txtTelephoneNo.Text, txtEmailId.Text, txtPresentAddress.Text, txtPresentTelephNo.Text, txtQualification.Text, Convert.ToDateTime(strQualificationDate), Convert.ToInt32(ddlYearOfPassing.Items[ddlYearOfPassing.SelectedIndex].Value), txtJobStatus.Text, Convert.ToDateTime(strStatusDate), 6, Convert.ToInt32(ddMainLiners.Items[ddMainLiners.SelectedIndex].Value), txtJobStatus1.Text, true, txtDesign.Text, txtOfficeAddress.Text, txtRemarks.Text);
               
            }
        }
        if (rbProfessional.Checked == true)
        {
            if (ddlProfessionals.SelectedIndex != 0)
            {

                i = objStud.AddStudAlumniInfo(txtAdmissionNo.Text, txtAlumniName.Text, Convert.ToDateTime(strDOB), txtFathersName.Text, txtPermanentAddress.Text, txtCorrespondingAddress.Text, txtTelephoneNo.Text, txtEmailId.Text, txtPresentAddress.Text, txtPresentTelephNo.Text, txtQualification.Text, Convert.ToDateTime(strQualificationDate), Convert.ToInt32(ddlYearOfPassing.Items[ddlYearOfPassing.SelectedIndex].Value), txtJobStatus.Text, Convert.ToDateTime(strStatusDate), 7, Convert.ToInt32(ddlProfessionals.Items[ddlProfessionals.SelectedIndex].Value), txtJobStatus1.Text, true, txtDesign.Text, txtOfficeAddress.Text, txtRemarks.Text);
               
            }
        }
        if (rbIntegratedCourses.Checked == true)
        {
            i = objStud.AddStudAlumniInfo(txtAdmissionNo.Text, txtAlumniName.Text, Convert.ToDateTime(strDOB), txtFathersName.Text, txtPermanentAddress.Text, txtCorrespondingAddress.Text, txtTelephoneNo.Text, txtEmailId.Text, txtPresentAddress.Text,txtPresentTelephNo.Text, txtQualification.Text, Convert.ToDateTime(strQualificationDate), Convert.ToInt32(ddlYearOfPassing.Items[ddlYearOfPassing.SelectedIndex].Value), txtJobStatus.Text, Convert.ToDateTime(strStatusDate), 8, Convert.ToInt32(ddlProfessionals.Items[ddlProfessionals.SelectedIndex].Value), txtJobStatus1.Text, true, txtDesign.Text, txtOfficeAddress.Text, txtRemarks.Text);
        }
        if (rbOthers.Checked == true)
        {
            
            i = objStud.AddStudAlumniInfo(txtAdmissionNo.Text, txtAlumniName.Text, Convert.ToDateTime(strDOB), txtFathersName.Text, txtPermanentAddress.Text, txtCorrespondingAddress.Text, txtTelephoneNo.Text, txtEmailId.Text, txtPresentAddress.Text, txtPresentTelephNo.Text, txtQualification.Text, Convert.ToDateTime(strQualificationDate), Convert.ToInt32(ddlYearOfPassing.Items[ddlYearOfPassing.SelectedIndex].Value), txtJobStatus.Text, Convert.ToDateTime(strStatusDate), 9, 0, txtJobStatus1.Text, true, txtDesign.Text, txtOfficeAddress.Text, txtRemarks.Text);
        }
        if (i > 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Alumni Data Added Successfully";
        }
        txtAdmissionNo.Text = "";
        txtAlumniName.Text = "";
        txtDateOfBirth.Text = "";
        txtFathersName.Text = "";
        txtPermanentAddress.Text = "";
        txtCorrespondingAddress.Text = "";
        txtTelephoneNo.Text = "";
        txtEmailId.Text = "";
        txtPresentAddress.Text = "";
        txtPresentTelephNo.Text = "";
        txtQualification.Text = "";
        txtQualificationDate.Text = "";
        ddlYearOfPassing.SelectedIndex = 0;
        txtJobStatus.Text = "";
        txtStatusDate.Text = "";
        ddlEngineers.SelectedIndex = 0;
        ddlMedicos.SelectedIndex = 0;
        ddlAdministrator.SelectedIndex = 0;
        ddlManager.SelectedIndex = 0;
        ddlDefence.SelectedIndex = 0;
        ddMainLiners.SelectedIndex = 0;
        ddlProfessionals.SelectedIndex = 0;
        txtJobStatus1.Text = "";
        rbEngineer.Checked = false;
        rbMedicos.Checked = false;
        rbAdministrators.Checked = false;
        rbManager.Checked = false;
        rbDefence.Checked = false;
        rbMainLiners.Checked = false;
        rbProfessional.Checked = false;
        rbIntegratedCourses.Checked = false;
        rbOthers.Checked = false;
        rbYes.Checked = false;
        rbNo.Checked = false;
        txtDesign.Text = "";
        txtOfficeAddress.Text = "";
        txtRemarks.Text = "";
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void rbYes_CheckedChanged(object sender, EventArgs e)
    {
        if (rbYes.Checked == true)
        {  
            Panel1.Visible = true;
        }
    }
    protected void rbNo_CheckedChanged(object sender, EventArgs e)
    {
        if (rbNo.Checked == true)
        {
            Panel1.Visible = false;
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtAdmissionNo.Text = "";
        txtAlumniName.Text = "";
        txtDateOfBirth.Text = "";
        txtFathersName.Text = "";
        txtPermanentAddress.Text = "";
        txtCorrespondingAddress.Text = "";
        txtTelephoneNo.Text = "";
        txtEmailId.Text = "";
        txtPresentAddress.Text = "";
        txtPresentTelephNo.Text = "";
        txtQualification.Text = "";
        txtQualificationDate.Text = "";
        ddlYearOfPassing.SelectedIndex = 0;
        txtJobStatus.Text = "";
        txtStatusDate.Text = "";
        ddlEngineers.SelectedIndex = 0;
        ddlMedicos.SelectedIndex = 0;
        ddlAdministrator.SelectedIndex = 0;
        ddlManager.SelectedIndex = 0;
        ddlDefence.SelectedIndex = 0;
        ddMainLiners.SelectedIndex = 0;
        ddlProfessionals.SelectedIndex = 0;
        txtJobStatus1.Text = "";
        rbEngineer.Checked = false;
        rbMedicos.Checked = false;
        rbAdministrators.Checked = false;
        rbManager.Checked = false;
        rbDefence.Checked = false;
        rbMainLiners.Checked = false;
        rbProfessional.Checked = false;
        rbIntegratedCourses.Checked = false;
        rbOthers.Checked = false;
        rbYes.Checked = false;
        rbNo.Checked = false;
        txtDesign.Text = "";
        txtOfficeAddress.Text = "";
        txtRemarks.Text = "";
    }
}
