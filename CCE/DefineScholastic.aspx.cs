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

public partial class CCE_DefineScholastic : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.CCEBL objCCE = new CCEBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    
    protected void Page_Load(object sender, EventArgs e)
    {
         btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            ds = objCCE.GetExam(0);
            chklExam.DataSource = ds.Tables[0];
            chklExam.DataTextField = "ExamName";
            chklExam.DataValueField = "ExamID";
            chklExam.DataBind();
            for (int i = 1990; i < 2050; i++)
            {
                string j = i.ToString() + "-" + Convert.ToString(i + 1);
                ddlYear.Items.Add(new ListItem(j.ToString(), i.ToString()));
            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = new DataSet();
            ds = objComm.GetClasses();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    chklClass.RepeatColumns = 4;
                    chklClass.DataSource = ds.Tables[0];
                    chklClass.DataTextField = "ClassName";
                    chklClass.DataValueField = "ClassID";
                    chklClass.DataBind();
                    chklClass.RepeatDirection = RepeatDirection.Horizontal;
                }
            }
            ds = objComm.GetSubject();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlSubject.DataSource = ds.Tables[0];
                    ddlSubject.DataTextField = "SubjectName";
                    ddlSubject.DataValueField = "SubjectID";
                    ddlSubject.DataBind();
                    ddlSubject.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
        }
    }
    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        BusinessLayer.CCEBL objCCE = new CCEBL();
        int i = 0;
        foreach (ListItem lstExam in chklExam.Items)
        {
            if (lstExam.Selected)
            {
                foreach (ListItem lstClass in chklClass.Items)
                {
                    if (lstClass.Selected)
                    {
                         i = objCCE.AddScholasticArea(txtScholasticArea.Text, Convert.ToInt32(lstExam.Value), Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(lstClass.Value), Convert.ToInt32(txtMaxMarks.Text), Convert.ToInt32(ddlSubject.SelectedValue));

                    }
                }
            }
        }
        if (i > 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Scholastic Area Added successfully";
            txtScholasticArea.Text = "";
            txtMaxMarks.Text = "";
        }
    }


    
}
