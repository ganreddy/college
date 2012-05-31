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

public partial class LibraryModule_LibStaffBookReturn : System.Web.UI.Page
{
    BusinessLayer.LibraryBL objLib = new LibraryBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    BusinessLayer.StaffBL objStaff = new StaffBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", "javascript:return RequiredValidate();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        lblmsg.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = objStaff.GetStaffDetails(0);
            ddlStaff.DataSource = ds.Tables[0];
            ddlStaff.DataTextField = "FullName";
            ddlStaff.DataValueField = "StaffID";
            ddlStaff.DataBind();
            ddlStaff.Items.Insert(0,new ListItem("---Select---","0"));
            trReturnDate.Visible = false;
            trFine.Visible = false;
            txtDateOfReturn.Text =ChangeDateFormat(DateTime.Today.ToShortDateString());
        }

    }
    
    protected void gdvLibBook_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int id;
        DataSet ds = new DataSet();
        foreach (GridViewRow gvr in gdvLibBook.Rows)
        {
            CheckBox chk = new CheckBox();
            Label lblBookID = new Label();
            Label lblReturnStatus = new Label();
            Label lblIssuedTo = new Label();
            Label lblRecieverId = new Label();
            Label lblName = new Label();
            Label lblClass = new Label();
            lblBookID = (Label)gvr.Cells[0].FindControl("lblBookID");
            chk = (CheckBox)gvr.Cells[1].FindControl("chkBook");
            lblIssuedTo = (Label)gvr.Cells[4].FindControl("lblIssuedTo");
            lblRecieverId = (Label)gvr.Cells[5].FindControl("lblRecieverID");
            lblName = (Label)gvr.Cells[6].FindControl("lblName");
            lblClass = (Label)gvr.Cells[7].FindControl("lblClass");
            lblReturnStatus = (Label)gvr.Cells[8].FindControl("lblBookStatus");

            if (lblIssuedTo.Text == "1")
            {
                lblIssuedTo.Text = "Student";
                id = Convert.ToInt32(lblRecieverId.Text);
                ds = objStudComm.GetStudent(id);
                lblName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                lblClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
            }
            if (lblIssuedTo.Text == "2")
            {
                lblIssuedTo.Text = "Staff";
                id = Convert.ToInt32(lblRecieverId.Text);
                ds = objStaff.GetStaffDetails(id);
                lblName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                lblClass.Text = "NA";
            }

        }

    }
    protected void ddlStaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindBooks();
    }

    public void bindBooks()
    {
        ds = new DataSet();
        ds = objLib.GetBookDetailsbyTypeandID(2, Convert.ToInt32(ddlStaff.Items[ddlStaff.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvLibBook.DataSource = ds.Tables[0];
                gdvLibBook.DataBind();
                trFine.Visible = true;
                trReturnDate.Visible = true;
                lblmsg.Visible = false;
            }
            else
            {
                ds = objLib.GetBookDetailsbyTypeandID(2, Convert.ToInt32(ddlStaff.Items[ddlStaff.SelectedIndex].Value));
                gdvLibBook.DataSource = ds.Tables[0];
                gdvLibBook.DataBind();
                trFine.Visible = false;
                trReturnDate.Visible = false;
                lblmsg.Visible = true;
            }
            
        }
        
    }
    protected void ddlFine_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFine.SelectedIndex == 2 || ddlFine.SelectedIndex == 3)
        {
            pnlFine.Visible = true;
        }
        else
        {
            pnlFine.Visible = false;
        }

    }

    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int BookID, RecieverID = 0;
        DateTime PaymentDate = DateTime.Today;
        decimal FineAmt = 0;
        int i = 0, Count = 0;
        foreach (GridViewRow gvr in gdvLibBook.Rows)
        {
            CheckBox chk = new CheckBox();
            Label lblBookID = new Label();
            Label lblRecieverID = new Label();
            lblBookID = (Label)gvr.Cells[0].FindControl("lblBookID");
            lblRecieverID = (Label)gvr.Cells[5].FindControl("lblRecieverID");
            RecieverID = Convert.ToInt32(lblRecieverID.Text);
            chk = (CheckBox)gvr.Cells[1].FindControl("chkBook");
            if (txtDateOfPayment.Text != "")
                PaymentDate = Convert.ToDateTime(ChangeDateFormat(txtDateOfPayment.Text));
            if (txtAmount.Text != "")
                FineAmt = Convert.ToDecimal(txtAmount.Text);
            if (chk.Checked)
            {
                BookID = Convert.ToInt32(lblBookID.Text);
                i = objLib.LibraryBookReturn(BookID, 2, RecieverID, Convert.ToDateTime(ChangeDateFormat(txtDateOfReturn.Text)), Convert.ToInt32(ddlFine.Items[ddlFine.SelectedIndex].Value),FineAmt, txtReceiptno.Text,PaymentDate);
                if (i > 0)
                {
                    Count = Count + 1;
                    lblMessage.Visible = true;
                    lblMessage.Text = "Staff Book Returned Successfully";
                    
                }
            }
        }
        if (Count > 0)
        {
            bindBooks();
            ddlFine.SelectedIndex = 0;
            txtAmount.Text = "";
            txtDateOfPayment.Text = "";
            txtReceiptno.Text = "";
            
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlStaff.SelectedIndex = 0;
        ddlFine.SelectedIndex = 0;
        txtAmount.Text = "";
        txtDateOfPayment.Text = "";
        txtReceiptno.Text = "";
    }
}
