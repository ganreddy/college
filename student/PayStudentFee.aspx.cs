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


public partial class PayStudentFee : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL studAdm = new StudentAdmissionBL();
   
    DataSet ds;
    string Msg, s = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        rdbAdminNo.Attributes.Add("onclick", "javascript:return ShowHide();");
        rdbName.Attributes.Add("onclick", "javascript:return ShowHide();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
       // ddlFeeType.Attributes.Add("onclick", "javascript:return SelectStudent();");
        btnPaid.Attributes.Add("onclick", "javascript:return Validate();");
        btnPaid.Attributes.Add("onclick", "javascript:return validations();");
        btnClear.Attributes.Add("onclick", "javascript:return Clear();");
         if (!IsPostBack)
        {
            rdbAdminNo.Checked = true;
            ds = objComm.getbatch();
            ddlBatch.DataSource = ds.Tables[0];
            ddlBatch.DataTextField = "BatchNo";
            ddlBatch.DataValueField = "BatchID";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetClasses();
            ddlClasses.DataSource = ds.Tables[0];
            ddlClasses.DataTextField = "ClassName";
            ddlClasses.DataValueField = "ClassID";
            ddlClasses.DataBind();
            ddlClasses.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetSection();
            ddlSections.DataSource = ds.Tables[0];
            ddlSections.DataTextField = "SectionName";
            ddlSections.DataValueField = "SectionID";
            ddlSections.DataBind();
            ddlSections.Items.Insert(0, new ListItem("---Select---", "0"));

            ds = objComm.GetFeeType(0);
            ddlFeeType.DataSource = ds.Tables[0];
            ddlFeeType.DataTextField = "FeeType";
            ddlFeeType.DataValueField = "FeeTypeID";
            ddlFeeType.DataBind();
            ddlFeeType.Items.Insert(0, new ListItem("---Select---", "0"));
            txtPaymentDate.Text =ChangeDateFormat(DateTime.Now.ToShortDateString());
            ds = objComm.GetFeeCategory();
            ddlCategory.DataSource = ds.Tables[0];
            ddlCategory.DataTextField = "FeeCategory";
            ddlCategory.DataValueField = "FeeCategoryID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objComm.GetClasses();
          ddltype.DataSource = ds.Tables[0];
          ddltype.DataTextField = "ClassName";
          ddltype.DataValueField = "ClassID";
          ddltype.DataBind();
          ddltype.Items.Insert(0, new ListItem("---Select---", "0"));
            txtTotal.Text = "0.0";  
        }
        if (rdbAdminNo.Checked)
        {
            pnlAdmSearch.Style.Add("display", "inline");

        }
        else
        {
            pnlSearchName.Style.Add("display", "inline");
        }

    }

    public void fillStudent(int ClassID, int BatchID, int SectionID)
    {
        ds = new DataSet();
        ds=studAdm.GetStudentData1(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
        if (ds.Tables.Count > 0)
        {
            ddlStudentID.DataSource = ds.Tables[0];
            ddlStudentID.DataTextField = "StdName";
            ddlStudentID.DataValueField = "StdId";
            ddlStudentID.DataBind();
            ddlStudentID.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        
    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbName.Checked)
        {
            pnlAdmSearch.Style.Add("display", "none");
            pnlSearchName.Style.Add("display", "inline");
        }
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
    }
    protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbName.Checked)
        {
            pnlAdmSearch.Style.Add("display", "none");
            pnlSearchName.Style.Add("display", "inline");
        }
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
    }
    protected void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbName.Checked)
        {
            pnlAdmSearch.Style.Add("display", "none");
            pnlSearchName.Style.Add("display", "inline");
        }
        fillStudent(Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value));
    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gdvStud.Visible = true;
         pnlSearchName.Style.Add("display","none");
        ds = studAdm.GetStudentDetailsByAdmissionNo(txtAdmSearch.Text);
        gdvStud.DataSource = ds.Tables[0];
        gdvStud.DataBind();
    }
    protected void gdvStud_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow gvr in gdvStud.Rows)
        {
            RadioButton rdb = new RadioButton();
            rdb = (RadioButton)gvr.Cells[1].FindControl("rdbSelect");
            //rdb.Attributes.Add("onclick", "javascript:return CheckRadio(" + gvr.RowIndex.ToString()+");");
           // rdb.CheckedChanged += new EventHandler(rdb_CheckedChanged);
           
        }

    }
    public void rdb_CheckedChanged(object sender, EventArgs e)
    {
        
        RadioButton rdb = new RadioButton();
        foreach (GridViewRow gvr in gdvStud.Rows)
        {
            
            rdb = (RadioButton)gvr.Cells[1].FindControl("rdbSelect");
            //rdb.Attributes.Add("onclick", "javascript:return CheckRadio(" + gvr.RowIndex.ToString()+");");
            // rdb.CheckedChanged += new EventHandler(rdb_CheckedChanged);
            rdb.Checked = false;

        }
        rdb = (RadioButton)sender;
        rdb.Checked = true;
        ddlCategory.SelectedValue = "0";
        ddlFeeType.SelectedValue = "0";
        ddltype.SelectedValue = "0";
        txtCast.Text = "";
        txtCon.Text = ""; 
        GetFee();
       
    }
    public void GetFeeDetails(DataSet ds)
    {
        decimal TotAmount = 0;
        //tblFee.Rows.Clear();
        if (ds.Tables.Count > 0)
        {
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                FeeDetails.DataSource = ds.Tables[0];
               FeeDetails.DataBind();
            }
            //{
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        CheckBox chk = new CheckBox();

            //        chk.ID = "chk" + Convert.ToString(i + 1);
            //        //chk.Attributes.Add("onclick", "javascript:return Check();");
            //        //chk.CheckedChanged += new EventHandler(this.checkChanged);

            //        chk.AutoPostBack = true;
            //        chk.Checked = true;
            //        chk.CheckedChanged += new EventHandler(chk_CheckedChanged);

            //        TextBox txtAmt = new TextBox();
            //        txtAmt.ID = "txtAmt" + Convert.ToString(i + 1);
            //        HiddenField hdn = new HiddenField();
            //        hdn.ID = "Header" + Convert.ToString(i + 1);
            //        hdn.Value = ds.Tables[0].Rows[i]["HeaderId"].ToString();
            //        HtmlTableRow tblRow = new HtmlTableRow();
            //        HtmlTableCell tblSrno = new HtmlTableCell();
            //        HtmlTableCell tblFeetype = new HtmlTableCell();
            //        HtmlTableCell tblAmount = new HtmlTableCell();
            //        tblSrno.InnerText = Convert.ToString(i + 1) + ")";
            //        tblSrno.Controls.Add(chk);
            //        tblFeetype.InnerText = ds.Tables[0].Rows[i]["HeaderName"].ToString();
            //        tblFeetype.Controls.Add(hdn);
            //        txtAmt.Text = ds.Tables[0].Rows[i]["Amount"].ToString();
            //        txtAmt.Style.Add("text-align", "right");
            //        txtAmt.Width = 60;
            //        tblAmount.Controls.Add(txtAmt);
            //        txtAmt.Enabled = false;
            //        //tblAmount.InnerText = ds.Tables[0].Rows[i]["Amount"].ToString();
            //        tblAmount.Align = "Right";
            //        TotAmount = TotAmount + Convert.ToDecimal(ds.Tables[0].Rows[i]["Amount"].ToString());
            //        int chked = 0;
            //        if (chk.Checked)
            //            chked = 1;

            //        chk.Attributes.Add("onclick", "javascript:return Check('" + txtAmt.Text + "','" + chked.ToString() + "' );");

            //        tblRow.Cells.Add(tblSrno);
            //        tblRow.Cells.Add(tblFeetype);
            //        tblRow.Cells.Add(tblAmount);
            //        tblFee.Rows.Add(tblRow);

            //    }
            //}
        }

        //HtmlTableRow rowTot1 = new HtmlTableRow();
        //HtmlTableCell cellTotal1 = new HtmlTableCell();
        //cellTotal1.InnerHtml = "<hr/>";
        //cellTotal1.ColSpan = 3;
        //rowTot1.Cells.Add(cellTotal1);
        //tblFee.Rows.Add(rowTot1);
        //HtmlTableRow rowTot = new HtmlTableRow();
        //HtmlTableCell cellTotal = new HtmlTableCell();
        //HtmlTableCell cellTot = new HtmlTableCell();
        //cellTotal.InnerText = "Total";

        //cellTot.ColSpan = 2;
        //cellTot.Align = "Right";
        //cellTot.InnerText = TotAmount.ToString();
        //rowTot.Cells.Add(cellTotal);
        //rowTot.Cells.Add(cellTot);
        //tblFee.Rows.Add(rowTot);
    }

    void chk_CheckedChanged(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
    protected void ddlFeeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FeeDetails.Visible = true; 
        GetFee();
    }
    protected void ddlStudentID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbName.Checked)
        {
            pnlAdmSearch.Style.Add("display", "none");
            pnlSearchName.Style.Add("display", "inline");
            ds = studAdm.GetStudent(Convert.ToInt32(ddlStudentID.Items[ddlStudentID.SelectedIndex].Value));
            int f = 0;
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtAdmNo.Text = ds.Tables[0].Rows[0]["AdmissionNo"].ToString();
                    txtAdmSearch.Text = ds.Tables[0].Rows[0]["AdmissionNo"].ToString();
                    if (ds.Tables[0].Rows[0]["Caste"].ToString() != "General")
                    {
                        f = 1;

                    }
                    txtCast.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
                    //if (ds.Tables[0].Rows[0]["ScheduledCaste"].ToString() == "1")
                    //{
                    //    f = 1;
                    //    //rdbSC.Checked = true; 
                    //}
                    //if (ds.Tables[0].Rows[0]["ScheduledCaste"].ToString() == "2")
                    //{
                    //    f = 1;
                    //    //rdbST.Checked = true;
                    //}
                    //if (ds.Tables[0].Rows[0]["ScheduledCaste"].ToString() == "3")
                    //{
                    //    f = 1;
                    //    //rdbOBC.Checked = true; 
                       
                    //}
                    //if (ds.Tables[0].Rows[0]["BrotherInKvsrNot"].ToString() == "1")
                    //{
                    //    //chkYoungerBrother.Checked = true;
                    //    txtCon.Text = "Brother in KVS"; 
                    //    f = 1;
                    //}
                    //if (ds.Tables[0].Rows[0]["familyMeminKvrNot"].ToString() == "1")
                    //{
                    //   //chkKVS.Checked = true;
                    //    txtCon.Text = "Family Member in KVS"; 
                    //   f = 1;
                    //}
                    //if (ds.Tables[0].Rows[0]["OnlyGirlChild"].ToString() == "1")
                    //{
                    //    //chkSGC.Checked = true;
                    //    txtCon.Text = "Single Giral Child "; 
                    //    f = 1;
                    //}
                    if (f == 1)
                    {
                        ddlCategory.SelectedValue = "1";
  

                    }
                    if(f==0)
                    {
                         ddlCategory.SelectedValue = "2";
                    }
                    ddltype.SelectedValue = ds.Tables[0].Rows[0]["CurrentClass"].ToString();
                    ddltype.Enabled = false;
                   
                    ddlCategory.Enabled = false;
                    txtCon.Enabled = false;
                    txtCast.Enabled = false;
             // lblFather.Text = ds.Tables[0].Rows[0]["fathername"].ToString();
                    //lblCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                    //hdnFee.Value = ds.Tables[0].Rows[0]["Categoryid"].ToString();
                    //ddlFeeType.SelectedValue=ds.Tables[0].Rows[0][""].ToString();
                    //ddltype.SelectedValue=ds.Tables[0].Rows[0][""].ToString();
                    //ddlCategory.SelectedValue= ds.Tables[0].Rows[0]["Categoryid"].ToString();
                }
            }
        }
    }
    protected void btnPaid_Click(object sender, EventArgs e)
    {
        string str = string.Empty,date1,date2;
      
        int j = 0,n;
        decimal Fine = 0,Total;
        hdnPaid.Value = "";
        //DataSet ds1 = new DataSet();
        //ds = objComm.GetFeeType();
        if (ddlFeeType.SelectedIndex == 1)
        {
            foreach (GridViewRow gvr in FeeDetails.Rows)
            {
                CheckBox chk = (CheckBox)gvr.FindControl("CheHeader");
                TextBox txt = (TextBox)gvr.FindControl("txtAmount");
                Label lbl = (Label)gvr.FindControl("lblHeader");
                if (chk.Checked)
                {

                    if (rdbAdminNo.Checked)
                    {
                        Total = Convert.ToDecimal(txtTotal.Text);
                        j = studAdm.AddStudFee1(Convert.ToInt32(hdnFee.Value.Split('@')[3]), Convert.ToInt32(hdnFee.Value.Split('@')[1]), Convert.ToInt32(hdnFee.Value.Split('@')[2]), Convert.ToInt32(hdnFee.Value.Split('@')[0]), Convert.ToInt32(ddlFeeType.Items[ddlFeeType.SelectedIndex].Value), Convert.ToInt32(lbl.Text), Convert.ToDecimal(txt.Text), (ChangeDateFormat(txtPaymentDate.Text)), txtFeeSlipNo.Text,Fine,Total);
                        
                    }
                    if (rdbName.Checked)
                    {
                        Total = Convert.ToDecimal(txtTotal.Text);
                        j = studAdm.AddStudFee1(Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value), Convert.ToInt32(ddlStudentID.Items[ddlStudentID.SelectedIndex].Value), Convert.ToInt32(ddlFeeType.Items[ddlFeeType.SelectedIndex].Value), Convert.ToInt32(lbl.Text), Convert.ToDecimal(txt.Text), ChangeDateFormat(txtPaymentDate.Text),txtFeeSlipNo.Text,Fine,Total);

                    }
                    //str = str + lbl.Text + "@" + txt.Text + "@";
                    //str = str + "$";
                }

            }
            //if (str != string.Empty)
            //{
            //    for (int i = 0; i < str.Split('$').Length-1; i++)
            //    {
            //        if (rdbAdminNo.Checked)
            //        {
            //            j = studAdm.AddStudFee(Convert.ToInt32(hdnFee.Value.Split('@')[3]), Convert.ToInt32(hdnFee.Value.Split('@')[1]), Convert.ToInt32(hdnFee.Value.Split('@')[2]), Convert.ToInt32(hdnFee.Value.Split('@')[0]), Convert.ToInt32(ddlFeeType.Items[ddlFeeType.SelectedIndex].Value), Convert.ToInt32(str.Split('$')[i].Split('@')[0].ToString()),Convert.ToDecimal(str.Split('$')[i].Split('@')[1].ToString()),Convert.ToDateTime(ChangeDateFormat(txtPaymentDate.Text)), txtFeeSlipNo.Text);

            //        }
            //        if (rdbName.Checked)
            //        {
            //            j = studAdm.AddStudFee(Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value), Convert.ToInt32(ddlStudentID.Items[ddlStudentID.SelectedIndex].Value), Convert.ToInt32(ddlFeeType.Items[ddlFeeType.SelectedIndex].Value), Convert.ToInt32(str.Split('$')[i].Split('@')[0].ToString()), Convert.ToDecimal(str.Split('$')[i].Split('@')[1].ToString()), Convert.ToDateTime(ChangeDateFormat(txtPaymentDate.Text)), txtFeeSlipNo.Text);

            //        }
            //    }
            //}

            if (j > 0)
            {
                //lblMessage.Text = "Student Fee Added Successfully";
                s = "Student Fee Added Successfully";
                Msg = "alert('" + s + "');";
               Msg=Msg+ "location.href='../Student/PayStudentFee.aspx'";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                gdvStud.Visible = false;
                FeeDetails.Visible = false;
                ddltype.SelectedValue = "0";
                ddlFeeType.SelectedValue = "0";
                ddlCategory.SelectedValue = "0";
                txtCast.Text = "";
                txtCon.Text = "";
                txtFeeSlipNo.Text = "";
                txtAdmNo.Text = "";
            }
            else
            {
                s = "Student Fee Already Exists";
                Msg = "alert('" + s + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
            }
        }
        else
        {
            ds = objComm.GetFeeType(Convert.ToInt32(ddlFeeType.Items[ddlFeeType.SelectedIndex - 1].Value));
            date1 = ds.Tables[0].Rows[0]["LastDate"].ToString();
            date2 = DateTime.Now.ToShortDateString(); 
            DateTime da1 = DateTime.Parse(date1);
            DateTime da2 = DateTime.Parse(date2);
            TimeSpan ts = da2.Subtract(da1);
            Fine = Convert.ToDecimal(ts.Days.ToString()) * 5;
            Total = Convert.ToDecimal(txtTotal.Text);
            Total = Total + Fine; 
          //Convert.ToInt16( ts.Days.ToString());
            ds = studAdm.GetStudentFee(Convert.ToInt32(hdnFee.Value.Split('@')[0]), Convert.ToInt32(ddlFeeType.Items[ddlFeeType.SelectedIndex - 1].Value));

            //else
            //{
            //    ds = studAdm.GetStudentFee(Convert.ToInt32(hdnFee.Value.Split('@')[0]), Convert.ToInt32(ddlFeeType.Items[ddlFeeType.SelectedIndex].Value));
            //}
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (GridViewRow gvr in FeeDetails.Rows)
                {
                    CheckBox chk = (CheckBox)gvr.FindControl("CheHeader");
                    TextBox txt = (TextBox)gvr.FindControl("txtAmount");
                    Label lbl = (Label)gvr.FindControl("lblHeader");
                    if (chk.Checked)
                    {

                        if (rdbAdminNo.Checked)
                        {
                           
                            j = studAdm.AddStudFee1(Convert.ToInt32(hdnFee.Value.Split('@')[3]), Convert.ToInt32(hdnFee.Value.Split('@')[1]), Convert.ToInt32(hdnFee.Value.Split('@')[2]), Convert.ToInt32(hdnFee.Value.Split('@')[0]), Convert.ToInt32(ddlFeeType.Items[ddlFeeType.SelectedIndex].Value), Convert.ToInt32(lbl.Text), Convert.ToDecimal(txt.Text), (ChangeDateFormat(txtPaymentDate.Text)), txtFeeSlipNo.Text, Fine, Total);

                        }
                        if (rdbName.Checked)
                        {
                          
                            j = studAdm.AddStudFee1(Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value), Convert.ToInt32(ddlStudentID.Items[ddlStudentID.SelectedIndex].Value), Convert.ToInt32(ddlFeeType.Items[ddlFeeType.SelectedIndex].Value), Convert.ToInt32(lbl.Text), Convert.ToDecimal(txt.Text), ChangeDateFormat(txtPaymentDate.Text), txtFeeSlipNo.Text, Fine, Total);

                        }
                        //str = str + lbl.Text + "@" + txt.Text + "@";
                        //str = str + "$";
                    }

                }
                //if (str != string.Empty)
                //{
                //    for (int i = 0; i < str.Split('$').Length-1; i++)
                //    {
                //        if (rdbAdminNo.Checked)
                //        {
                //            j = studAdm.AddStudFee(Convert.ToInt32(hdnFee.Value.Split('@')[3]), Convert.ToInt32(hdnFee.Value.Split('@')[1]), Convert.ToInt32(hdnFee.Value.Split('@')[2]), Convert.ToInt32(hdnFee.Value.Split('@')[0]), Convert.ToInt32(ddlFeeType.Items[ddlFeeType.SelectedIndex].Value), Convert.ToInt32(str.Split('$')[i].Split('@')[0].ToString()),Convert.ToDecimal(str.Split('$')[i].Split('@')[1].ToString()),Convert.ToDateTime(ChangeDateFormat(txtPaymentDate.Text)), txtFeeSlipNo.Text);

                //        }
                //        if (rdbName.Checked)
                //        {
                //            j = studAdm.AddStudFee(Convert.ToInt32(ddlBatch.Items[ddlBatch.SelectedIndex].Value), Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlSections.Items[ddlSections.SelectedIndex].Value), Convert.ToInt32(ddlStudentID.Items[ddlStudentID.SelectedIndex].Value), Convert.ToInt32(ddlFeeType.Items[ddlFeeType.SelectedIndex].Value), Convert.ToInt32(str.Split('$')[i].Split('@')[0].ToString()), Convert.ToDecimal(str.Split('$')[i].Split('@')[1].ToString()), Convert.ToDateTime(ChangeDateFormat(txtPaymentDate.Text)), txtFeeSlipNo.Text);

                //        }
                //    }
                //}

                if (j > 0)
                {
                    //lblMessage.Text = "Student Fee Added Successfully";
                    s = "Student Fee Added Successfully";
                    Msg = "alert('" + s + "');";
                    Msg = Msg + "location.href='../Student/PayStudentFee.aspx'";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                    gdvStud.Visible = false;
                    FeeDetails.Visible = false;
                    ddltype.SelectedValue = "0";
                    ddlFeeType.SelectedValue = "0";
                    ddlCategory.SelectedValue = "0";
                    txtCast.Text = "";
                    txtCon.Text = "";
                    txtFeeSlipNo.Text = "";
                    txtAdmNo.Text = "";
                }
                else
                {
                    s = "Student Fee Already Exists";
                    Msg = "alert('" + s + "');";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
                }
            }
            else
            {
                string Dt1 = DateTime.Now.ToShortDateString();
                //string D2=("1/14
                s = "Please Pay  " + ddlFeeType.Items[ddlFeeType.SelectedIndex - 1].Text + "  Fees With " + Fine + " Fine ";
                Msg = "alert('" + s + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Msg, true);
            }
        }
    
  
        
    }
   
    public void GetFee()
    {
        int f=0;
        if (rdbAdminNo.Checked)
        {
            foreach (GridViewRow gvr in gdvStud.Rows)
            {
                RadioButton rdb = new RadioButton();
                Label lblClass = new Label();
                Label lblCategory = new Label();
                Label lblStudentID = new Label();
                Label lblSection = new Label();
                Label lblBatch = new Label();
                Label lblAdmisNo = new Label();
                rdb = (RadioButton)gvr.Cells[1].FindControl("rdbSelect");
                lblAdmisNo = (Label)gvr.Cells[3].FindControl("lblAdmisNo");
                lblClass = (Label)gvr.Cells[8].FindControl("lblClassid");
                lblCategory = (Label)gvr.Cells[9].FindControl("lblCategoryid");
                lblStudentID = (Label)gvr.Cells[0].FindControl("lblStudentID");
                lblSection = (Label)gvr.Cells[10].FindControl("lblSectionid");
                lblBatch = (Label)gvr.Cells[10].FindControl("lblBatchId");
                if (rdb.Checked)
                 {
                    hdnFee.Value = lblStudentID.Text + "@" + lblClass.Text + "@" + lblSection.Text + "@" + lblBatch.Text;
                    ds = studAdm.GetStudent(Convert.ToInt32(lblStudentID.Text));
                    txtAdmNo.Text = lblAdmisNo.Text;
                    txtAdmSearch.Text = lblAdmisNo.Text;
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtAdmNo.Text = ds.Tables[0].Rows[0]["AdmissionNo"].ToString();
                            if (ds.Tables[0].Rows[0]["Caste"].ToString() != "General")
                            {
                                f = 1;
                            }
                            txtCast.Text=ds.Tables[0].Rows[0]["Caste"].ToString();  
                            //if (ds.Tables[0].Rows[0]["ScheduledCaste"].ToString() == "1")
                            //{
                            //    f = 1;
                            //    //rdbSC.Checked = true;
                            //}
                            //if (ds.Tables[0].Rows[0]["ScheduledCaste"].ToString() == "2")
                            //{
                            //    f = 1;
                            //    //rdbST.Checked = true;
                            //}
                            //if (ds.Tables[0].Rows[0]["ScheduledCaste"].ToString() == "3")
                            //{
                            //    f = 1;
                            //    //rdbOBC.Checked = true;

                            //}
                            //if (ds.Tables[0].Rows[0]["BrotherInKvsrNot"].ToString() == "1")
                            //{
                            //    //chkYoungerBrother.Checked = true;
                            //    txtCon.Text = " Brother In KVS ";  
                            //    f = 1;
                            //}
                            //if (ds.Tables[0].Rows[0]["familyMeminKvrNot"].ToString() == "1")
                            //{
                            //    //chkKVS.Checked = true;
                            //    f = 1;
                            //    txtCon.Text = "Family Member in KVR";
                            //}
                            //if (ds.Tables[0].Rows[0]["OnlyGirlChild"].ToString() == "1")
                            //{
                            //    //chkSGC.Checked = true;
                            //    txtCon.Text = "Single Giral Child";
                            //    f = 1;
                            //}
                            if (f == 1)
                            {
                                ddlCategory.SelectedValue = "1";


                            }
                            if (f == 0)
                            {
                                ddlCategory.SelectedValue = "2";
                            }
                            ddltype.SelectedValue = ds.Tables[0].Rows[0]["CurrentClass"].ToString();
                        }
                    }
                    ddltype.Enabled = false;
                    
                    ddlCategory.Enabled = false;
                    txtCon.Enabled = false;
                    txtCast.Enabled = false;
                    
             ds = studAdm.GetFeeDetails(Convert.ToInt32(ddlCategory.SelectedValue), Convert.ToInt32(lblClass.Text), Convert.ToInt32(ddlFeeType.SelectedValue),Convert.ToInt16(ddltype.SelectedValue));
                    ViewState["ds"] = ds;
                    GetFeeDetails(ds);
                }
            }
        }
        if (rdbName.Checked)
        {
            //hdnFee.Value = lblStudentID.Text + "@" + lblClass.Text + "@" + lblSection.Text + "@" + lblBatch.Text;
            ds = studAdm.GetFeeDetails(Convert.ToInt32(ddlCategory.SelectedValue), Convert.ToInt32(ddlClasses.Items[ddlClasses.SelectedIndex].Value), Convert.ToInt32(ddlFeeType.SelectedValue), Convert.ToInt16(ddltype.SelectedValue));
            ViewState["ds"] = ds;
            GetFeeDetails(ds);
        }
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void gdvStud_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvStud.PageIndex = e.NewPageIndex;
        ds = studAdm.GetStudentDetailsByAdmissionNo(txtAdmSearch.Text);
        gdvStud.DataSource = ds.Tables[0];
        gdvStud.DataBind();

    }
    protected void checkChanged(object sender, EventArgs e)
    {
        //Some code goes here which never seems to execute... grrr
    }
    protected void FeeDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        double total = 0;
        foreach (GridViewRow Gvr in FeeDetails.Rows)
        {
            CheckBox chk = (CheckBox)Gvr.FindControl("CheHeader");
            TextBox txt = (TextBox)Gvr.FindControl("txtAmount");
            txt.Enabled = false;
            chk.Checked = true;
            chk.Attributes.Add("onclick", "javascript:return Check('" + txt.ClientID + "','" + chk.ClientID + "','"+txtTotal.ClientID+"');");
            total =total+ Convert.ToDouble (txt.Text); 
        }
        txtTotal.Text = total.ToString();
        txtTotal.Enabled = false;


    }
    protected void FeeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}
