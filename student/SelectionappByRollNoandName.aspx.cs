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

public partial class student_SelectionappByRollNoandName : System.Web.UI.Page
{
    BusinessLayer.StudentAdmissionBL StudAdm = new StudentAdmissionBL();
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        rdbAdminNo.Attributes.Add("onclick", "javascript:return ShowHide();");
        rdbName.Attributes.Add("onclick", "javascript:return ShowHide();");
        if (rdbAdminNo.Checked)
        {
            pnlAdmSearch.Style.Add("display", "inline");
            pnlSearchName.Style.Add("display", "none");
        }
        else
        {
            pnlSearchName.Style.Add("display", "inline");
            pnlAdmSearch.Style.Add("display", "none");
        }


    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ds = StudAdm.GetSelectionApplicationUsingGrid(txtAdmissionNo.Text);
        gdvStud.DataSource = ds.Tables[0];
        gdvStud.DataBind();
    }
    protected void btnNmeSearch_Click(object sender, EventArgs e)
    {
        ds = StudAdm.GetSelectionApplicationByName(txtName.Text);
        gdvStud.DataSource = ds.Tables[0];
        gdvStud.DataBind();
    }
    protected void gdvStud_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Label lblStudId = new Label();
        lblStudId = (Label)gdvStud.Rows[e.NewEditIndex].Cells[0].FindControl("lblStudentID");
        Response.Redirect("../Student/SelectionApplicationForm.aspx?ID=" + lblStudId.Text);
    }
}
