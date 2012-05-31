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

public partial class CCE_DefineExam : System.Web.UI.Page
{
    BusinessLayer.CCEBL objComm = new CCEBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            bindExam();
        }
    }
    public void bindExam()
    {
        ds = new DataSet();
        ds = objComm.GetExam(0);
        gdvExam.DataSource = ds.Tables[0];
        gdvExam.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (btnAdd.Text == "Add")
        {

            i = objComm.AddExam(Convert.ToInt32(ddlTerm.SelectedValue),txtExam.Text,Convert.ToInt32(txtWeightage.Text));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtExam.Text + "   Added Successfully";
                txtExam.Text = "";
                bindExam();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtExam.Text + "  Exam already Exists";

            }
        }
        if (btnAdd.Text == "Update")
        {
            i = objComm.EditExam(Convert.ToInt32(hdnCasteID.Value), Convert.ToInt32(ddlTerm.SelectedValue), txtExam.Text, Convert.ToInt32(txtWeightage.Text));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtExam.Text + "   Modified Successfully";
                txtExam.Text = "";
                btnAdd.Text = "Add";
                bindExam();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtExam.Text + "  Exam already Exists";

            }
        }
    }

    protected void gdvExam_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvExam.Rows)
        {
            Label lblExamID = new Label();
            Label lblExam = new Label();
            Label lblTerm = new Label();
            Label lblWeightage = new Label();
            LinkButton lnkEdit = new LinkButton();
            LinkButton lnkDelete = new LinkButton();

            lblExamID = (Label)gvr.Cells[0].FindControl("lblExamID");
            lblExam = (Label)gvr.Cells[1].FindControl("lblExam");
            lblTerm = (Label)gvr.Cells[2].FindControl("lblTermID");
            lblWeightage = (Label)gvr.Cells[3].FindControl("lblWeightage");
            lnkEdit = (LinkButton)gvr.Cells[3].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[4].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblExamID.Text + "@" + lblExam.Text + "@" + lblTerm.Text + "@" + lblWeightage.Text;
            lnkDelete.CommandArgument = lblExamID.Text + "@" + lblExam.Text + "@" + lblTerm.Text;
            
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    protected void gdvExam_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtExam.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnCasteID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            ddlTerm.SelectedValue = e.CommandArgument.ToString().Split('@')[2].ToString();
            txtWeightage.Text = e.CommandArgument.ToString().Split('@')[3].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnCasteID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objComm.DeleteExam(Convert.ToInt32(hdnCasteID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtExam.Text + "   Deleted Successfully";
                txtExam.Text = "";
                bindExam();
            }
            btnAdd.Text = "Add";
        }
    }
}
