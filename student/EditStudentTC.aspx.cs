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

public partial class student_EditStudentTC : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStud = new StudentAdmissionBL();
    int StudId;
    protected void Page_Load(object sender, EventArgs e)
    {
        ds = new DataSet();

        if (Request.QueryString["ID"] != null)
        {


            StudId = Convert.ToInt32(Request.QueryString["ID"].ToString());
            ds = objStud.GetStdPersonaldetail(StudId);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    StudId = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    //lblBatch.Text = ds.Tables[0].Rows[0]["Batch"].ToString();
                    //lblClasses.Text = ds.Tables[0].Rows[0]["Class"].ToString();
                    //lblSections.Text = ds.Tables[0].Rows[0]["Section"].ToString();
                    //lblStudentID.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                    lblAdmNo.Text = ds.Tables[0].Rows[0]["AdmissionNo"].ToString();
                    lblName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                    lblFatherName.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                    lblMotherName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
                    if (ds.Tables[0].Rows[0]["CasteName"].ToString().ToUpper() == "ST" || ds.Tables[0].Rows[0]["CasteName"].ToString().ToUpper() == "SC")
                    {
                        lblScheduled.Text = "Yes";
                    }
                    else 
                    {
                        lblScheduled.Text = "No";
                    }
                    lblDob.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
                    lblLastStudied.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                    lblTcNo.Text = ds.Tables[0].Rows[0]["TCNO"].ToString();
                    lblSubjetStud.Text = ds.Tables[0].Rows[0]["Subjects"].ToString();
                    //lblLastStudied.Text = ds.Tables[0].Rows[0]["Subjects"].ToString();
                    lblAnnualExam.Text = ds.Tables[0].Rows[0]["BoardExam"].ToString();
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Failed"].ToString()) == 0)
                    {
                        lblFailed.Text = "No";
                    }
                    else if (Convert.ToInt32(ds.Tables[0].Rows[0]["Failed"].ToString()) == 1)
                    {
                        lblFailed.Text = "Once";
                    }
                    else if (Convert.ToInt32(ds.Tables[0].Rows[0]["Failed"].ToString()) == 2)
                    {
                        lblFailed.Text = "Twice";
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["QualifiedforPromotion"].ToString()) == 0)
                    {
                        lblQualifiedPromotion.Text = "No";
                    }
                    else if (Convert.ToInt32(ds.Tables[0].Rows[0]["QualifiedforPromotion"].ToString()) == 1)
                    {
                        lblQualifiedPromotion.Text = "Yes";
                    }
                    lblMnthPaid.Text = ds.Tables[0].Rows[0]["FeePaidMonth"].ToString();
                    //lblPupilReceipt.Text = ds.Tables[0].Rows[0]["FeeConcession"].ToString();
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["FeeConcession"].ToString()) == 0)
                    {
                        lblPupilReceipt.Text = "No";
                    }
                    else if (Convert.ToInt32(ds.Tables[0].Rows[0]["FeeConcession"].ToString()) == 1)
                    {
                        lblPupilReceipt.Text = "Yes";
                    }
                    lblDOfAttendance.Text = ds.Tables[0].Rows[0]["LastAttendDate"].ToString();

                    lblNofSchoolDays.Text = ds.Tables[0].Rows[0]["NoofSchoolDays"].ToString();
                    lblnofPupilAttended.Text = ds.Tables[0].Rows[0]["NoofDaysAttended"].ToString();
                    lblDateofApplication.Text = ds.Tables[0].Rows[0]["DateofApply"].ToString();
                    lblDofIssue.Text = ds.Tables[0].Rows[0]["DateofIssue"].ToString();
                    lblReasons.Text = ds.Tables[0].Rows[0]["Reason"].ToString();
                    //lblReasons.Text = ds.Tables[0].Rows[0]["Reasion"].ToString();
                    lblNcc.Text = ds.Tables[0].Rows[0]["Ncc"].ToString();
                    lblExtraactivities.Text = ds.Tables[0].Rows[0]["Games"].ToString();
                    lblConduct.Text = ds.Tables[0].Rows[0]["Conduct"].ToString();
                    lblRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                  }
            }
        }
                    
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }




    protected void btnEditLibBookDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentTC.aspx?ID=" + StudId + "");
    }
}
