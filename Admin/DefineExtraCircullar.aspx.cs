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

public partial class Admin_DefineExtraCircullar : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objcomm = new CommonDataBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
       btnAdd.Attributes.Add("onclick", "javascript:return validate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
         {
             bindExtraCurricular();
         }
    }
    public void bindExtraCurricular()
    {
        ds = new DataSet();
        ds = objcomm.GetExtraCurricular();
        gdvECA.DataSource = ds.Tables[0];
        gdvECA.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int i = 0;
       
        if (btnAdd.Text == "Add")
          {
              i = objcomm.AddExtraCircular(txtExtraCircullar.Text);
              if (i > 0)
              {
                  lblMessage.Visible = true;
                  lblMessage.Text = txtExtraCircullar.Text + "  ExtraCurricular Activity Added Successfully";
                  txtExtraCircullar.Text = "";
                  bindExtraCurricular();
              }
              else
              {
                  lblMessage.Visible = true;
                  lblMessage.Text = txtExtraCircullar.Text + "  ExtraCurricular Activity Already Exists";
              }

          }
        if (btnAdd.Text == "Update")
          {
              i = objcomm.EditExtraCurricular(Convert.ToInt32(hdnExtraCurricularID.Value), txtExtraCircullar.Text);
              if (i > 0)
              {
                  lblMessage.Visible = true;
                  lblMessage.Text = txtExtraCircullar.Text + "  ExtraCurricular Activity Updated Successfully";
                  txtExtraCircullar.Text = "";
                  btnAdd.Text = "Add";
                  bindExtraCurricular();
              }
              else
              {
                  lblMessage.Visible = true;
                  lblMessage.Text = txtExtraCircullar.Text + "  ExtraCurricular Activity Already Exists";
              }
          }

    }



    protected void gdvECA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "editing")
        {
            txtExtraCircullar.Text = e.CommandArgument.ToString().Split('@')[1].ToString();
            hdnExtraCurricularID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            btnAdd.Text = "Update";
        }
        if (e.CommandName == "del")
        {
            hdnExtraCurricularID.Value = e.CommandArgument.ToString().Split('@')[0].ToString();
            i = objcomm.DeleteExtraCurricular(Convert.ToInt32(hdnExtraCurricularID.Value));
            if (i > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = txtExtraCircullar.Text + "  ExtraCurricular Activity Deleted Successfully";
                txtExtraCircullar.Text = "";
                bindExtraCurricular();
            }
        }
    }
    protected void gdvECA_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvECA.Rows)
        {
            Label lblExtraCurricularID = new Label();
            Label lblActivity = new Label();
            LinkButton lnkEdit=new LinkButton();
            LinkButton lnkDelete=new LinkButton();
            lblExtraCurricularID=(Label)gvr.Cells[0].FindControl("lblExtraCurricularID");
            lblActivity=(Label)gvr.Cells[1].FindControl("lblActivity");
            lnkEdit = (LinkButton)gvr.Cells[2].FindControl("lnkEdit");
            lnkDelete = (LinkButton)gvr.Cells[3].FindControl("lnkDelete");
            lnkEdit.CommandArgument = lblExtraCurricularID.Text + "@" + lblActivity.Text;
            lnkDelete.CommandArgument = lblExtraCurricularID.Text + "@" + lblActivity.Text;
            lnkDelete.Attributes.Add("onclick", "javascript:return Confirm();");
        }
    }
    protected void gdvECA_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvECA.PageIndex = e.NewPageIndex;
        bindExtraCurricular();
    }
}
