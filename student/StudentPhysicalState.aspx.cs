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

public partial class StudentModule_StudentPhysicalState : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblDelete.Attributes.Add("style", "color:red;font-weight:bold;");
        lblSave.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            ds = objcomm.GetBatch();
           // ds = objStudComm.GetPromotionBatch();
            ddlBatch.DataSource = ds.Tables[0];
            ddlBatch.DataTextField = "batchNo";
            ddlBatch.DataValueField = "BatchID";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objcomm.GetClasses();
           // ds = objStudComm.GetPromotionClasses();
            ddlClasses.DataSource = ds.Tables[0];
            ddlClasses.DataTextField = "ClassName";
            ddlClasses.DataValueField = "ClassID";
            ddlClasses.DataBind();
            ddlClasses.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objcomm.GetSection();
            //ds = objStudComm.GetPromotionSection();
            ddlSections.DataSource = ds.Tables[0];
            ddlSections.DataTextField = "SectionName";
            ddlSections.DataValueField = "SectionID";
            ddlSections.DataBind();
            ddlSections.Items.Insert(0, new ListItem("---Select---", "0"));           
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
      {
        BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
        int Batch = Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value);
        int Class = Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value);
        int Section = Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value);
        int i=objStudComm.AddStudPhysicalState(Convert.ToInt32(ddlStudent.Items[ddlStudent.SelectedIndex].Value), DateTime.Now, Convert.ToInt32(txtHeight.Text), Convert.ToInt32(txtWeight.Text), txtChest.Text, txtEyesight.Text, txtBloodgroup.Text, txtDietPreferred.Text, txtAilments.Text, txtAllergies.Text, txtChronocDisease.Text, txtMedicalOPenion.Text,Batch,Class,Section);
        if (i > 0)
        {
            lblSave.Visible = true;
            lblSave.Text = "Physical State Added Successfully";
            
        }
       
        
        ddlBatch.SelectedIndex = 0;
        ddlClasses.SelectedIndex = 0;
        ddlSections.SelectedIndex = 0;
        ddlStudent.SelectedIndex = 0;
        txtHeight.Text = "";
        txtWeight.Text = "";
        txtChest.Text = "";
        txtEyesight.Text = "";
        txtBloodgroup.Text = "";
        txtDietPreferred.Text = "";
        txtAilments.Text = "";
        txtAllergies.Text = "";
        txtChronocDisease.Text = "";
        txtMedicalOPenion.Text = "";
      }
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
     {
        BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
        ds = new DataSet();
        ds = objStudComm.GetStud_PhysicalState(Convert.ToInt32(ddlBatch.SelectedValue),Convert.ToInt32(ddlClasses.SelectedValue),Convert.ToInt32(ddlSections.SelectedValue), Convert.ToInt32(ddlStudent.SelectedValue));

        if (ds.Tables[0].Rows.Count > 0)
         {
            txtHeight.Text = ds.Tables[0].Rows[0]["height"].ToString();
            txtWeight.Text = ds.Tables[0].Rows[0]["weight"].ToString();
            txtChest.Text = ds.Tables[0].Rows[0]["ChestMeasurement"].ToString();
            txtEyesight.Text = ds.Tables[0].Rows[0]["eyesight"].ToString();
            txtBloodgroup.Text = ds.Tables[0].Rows[0]["bloodGroup"].ToString();
            txtDietPreferred.Text = ds.Tables[0].Rows[0]["dietPreferred"].ToString();
            txtAilments.Text = ds.Tables[0].Rows[0]["ailments"].ToString();
            txtAllergies.Text = ds.Tables[0].Rows[0]["allergies"].ToString();
            txtChronocDisease.Text = ds.Tables[0].Rows[0]["ChronicDiseases"].ToString();
            txtMedicalOPenion.Text = ds.Tables[0].Rows[0]["MedicalOpinion"].ToString();
            btnAdd.Text = "Update";
         }
        else
         {
            txtHeight.Text = "";
            txtWeight.Text = "";
            txtChest.Text = "";
            txtEyesight.Text = "";
            txtBloodgroup.Text = "";
            txtDietPreferred.Text = "";
            txtAilments.Text = "";
            txtAllergies.Text = "";
            txtChronocDisease.Text = "";
            txtMedicalOPenion.Text = "";
            btnAdd.Text = "Save";
        }      
    }   
    protected void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
      {
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
        if (ddlSections.SelectedIndex > 0)
        {
            txtHeight.Text = "";
            txtWeight.Text = "";
            txtChest.Text = "";
            txtEyesight.Text = "";
            txtBloodgroup.Text = "";
            txtDietPreferred.Text = "";
            txtAilments.Text = "";
            txtAllergies.Text = "";
            txtChronocDisease.Text = "";
            txtMedicalOPenion.Text = "";
        }
      }
    public void fillStudent(int ClassID, int BatchID, int SectionID)
      {
        BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
        ds = new DataSet();
        ds = objStudComm.GetStudData(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
       // ds = objStudComm.GetStudData(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
          {
            ddlStudent.DataSource = ds.Tables[0];
            ddlStudent.DataTextField = "FullName";
            ddlStudent.DataValueField = "StudID";
            ddlStudent.DataBind();
            ddlStudent.Items.Insert(0, new ListItem("---Select---", "0"));            
         }
     }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
      { 
       fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
       if (ddlBatch.SelectedIndex > 0)
       {
           txtHeight.Text = "";
           txtWeight.Text = "";  
           txtChest.Text = "";
           txtEyesight.Text = "";
           txtBloodgroup.Text = "";
           txtDietPreferred.Text = "";
           txtAilments.Text = "";
           txtAllergies.Text = "";
           txtChronocDisease.Text = "";
           txtMedicalOPenion.Text = "";
       }
      }
    protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
     {
       fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
       if (ddlClasses.SelectedIndex > 0)
       {

           txtHeight.Text = "";
           txtWeight.Text = "";
           txtChest.Text = "";
           txtEyesight.Text = "";
           txtBloodgroup.Text = "";
           txtDietPreferred.Text = "";
           txtAilments.Text = "";
           txtAllergies.Text = "";
           txtChronocDisease.Text = "";
           txtMedicalOPenion.Text = "";
       }
     }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        
        ddlBatch.SelectedIndex = 0;
        ddlClasses.SelectedIndex = 0;
        ddlSections.SelectedIndex = 0;
        ddlStudent.SelectedIndex = 0;
        txtHeight.Text = "";
        txtWeight.Text = "";
        txtChest.Text = "";
        txtEyesight.Text = "";
        txtBloodgroup.Text = "";
        txtDietPreferred.Text = "";
        txtAilments.Text = "";
        txtAllergies.Text = "";
        txtChronocDisease.Text = "";
        txtMedicalOPenion.Text = "";
        
    }
}
