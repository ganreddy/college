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
using System.Collections.Generic;


public partial class SetMonthlySal : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.StaffBL objstff = new BusinessLayer.StaffBL(); 
    BusinessLayer.CommonDataBL objcomm = new BusinessLayer.CommonDataBL();
    HtmlTableRow tblRow;
//    HtmlTableRow trItem;
    HtmlTableCell tblCell;
    TextBox txt;
    
        
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", "javascript:return validation(); ");
        int k = 0;
        txtadd.Text = k.ToString();
        txtDel.Text = k.ToString(); ;  
  
        if (!IsPostBack)
        {
            ds = objstff.GetStaffDetails(0);
            ddlStaffName.DataSource = ds.Tables[0];
            ddlStaffName.DataTextField = "FullName";
            ddlStaffName.DataValueField = "StaffID";
            ddlStaffName.DataBind();

            for (int i = 2005; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlStaffName.Items.Insert(0, new ListItem("---Select---", "0"));
        
        }
        
        int temp = 0;
        int add = 1, ded = 1;
        ds = objstff.GetSalary();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            if ((Convert.ToInt32(dr["type"].ToString())) == 1)
            {

                tblRow = new HtmlTableRow();
                tblCell = new HtmlTableCell();
                tblCell.InnerHtml = dr["NameOfTheField"].ToString();
                tblCell.Attributes.Add("class", "tblboldcol");
                tblCell.Width = "130";
                tblRow.Cells.Add(tblCell);
                tblCell = new HtmlTableCell();
                txt = new TextBox();
                txt.ID = "txtAdd" + add.ToString();
                txt.Attributes.Add("onkeyup","javascript:return calc();");
                txt.Attributes.Add("onkeypress", "javascript:return allowNum();");
                tblCell.Controls.Add(txt);
                tblCell.Attributes.Add("class", "tblboldcol");
                tblCell.Width = "130";
                tblRow.Cells.Add(tblCell);
                tblAdd.Rows.Add(tblRow);
                add = add + 1;

            }
            else
            {
                if (temp == 1)
                {
                    temp = 0;
                }
                tblRow = new HtmlTableRow();
                tblCell = new HtmlTableCell();
                tblCell.InnerHtml = dr["NameOfTheField"].ToString();
                tblCell.Attributes.Add("class", "tblboldcol");
                tblCell.Width = "130";
                tblRow.Cells.Add(tblCell);
                tblCell = new HtmlTableCell();
                txt = new TextBox();
                txt.ID = "txtDed" + ded.ToString();
                txt.Attributes.Add("onkeyup", "javascript:return calc();");
                txt.Attributes.Add("onkeypress", "javascript:return allowNum();");
                tblCell.Controls.Add(txt);
                tblCell.Attributes.Add("class", "tblboldcol");
                tblCell.Width = "130";
                tblRow.Cells.Add(tblCell);
                tblDed.Rows.Add(tblRow);
                ded = ded + 1;
            }
        }
        hdn.Value = Convert.ToString(add - 1) + "@" + Convert.ToString(ded - 1);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ds = objstff.GetSalary();
        int staffid, month, year, i,add=1,ded=1;
        float AddTotal = 0, DelTotal = 0;
        staffid = Convert.ToInt32(ddlStaffName.Items[ddlStaffName.SelectedIndex].Value);
        month = Convert.ToInt32(ddlMnth.Items[ddlMnth.SelectedIndex].Value);
        year = Convert.ToInt32(ddlYear.Items[ddlYear.SelectedIndex].Value);
        TextBox txtSal;

        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            if ((Convert.ToInt16(dr["type"].ToString())) == 1)
            {

                txtSal = (TextBox)tblAdd.FindControl("txtAdd" + add.ToString());

                if (txtSal.Text != "")
                {
                    AddTotal = AddTotal + Convert.ToSingle(txtSal.Text);
                    i = objstff.AddStaffMontlysalary(staffid, month, year, (Convert.ToInt16(dr["type"].ToString())), Convert.ToInt32(dr["FieldId"].ToString()), Convert.ToSingle(txtSal.Text));
                }
                add = add + 1;
            }
            else
            {
                txtSal = (TextBox)tblAdd.FindControl("txtDed" + ded.ToString());

                if (txtSal.Text != "")
                {
                    DelTotal = DelTotal + Convert.ToSingle(txtSal.Text);
                    i = objstff.AddStaffMontlysalary(staffid, month, year, (Convert.ToInt16(dr["type"].ToString())), Convert.ToInt32(dr["FieldId"].ToString()), Convert.ToSingle(txtSal.Text));
                }
                ded = ded + 1;
            }

        }
        txtadd.Text = AddTotal.ToString();
        txtDel.Text = DelTotal.ToString();
        txtGrand.Text = Convert.ToString(AddTotal + DelTotal);
        i = objstff.AddStaffGrandsalary(staffid, month, year, AddTotal, DelTotal, (float)(AddTotal + DelTotal));
        //if (i > 0)
        //{
        //    Response.Write(@"<script language='javascript'>alert('Update is successful.')</script>");

        //}
 
    }


}
