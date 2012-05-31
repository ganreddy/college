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
using System.Data.SqlClient;
using BusinessLayer;
public partial class Staff_ReportTimetable1 : System.Web.UI.Page
{
    CommonDataBL ObjBL = new CommonDataBL();
    StaffBL ObjStaff = new StaffBL();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Prtbtn.Attributes.Add("onclick", "javascript:return printSpecial();");
        Prtbtn.Attributes.Add("onclick", "javascript:return validation();");
        if (!IsPostBack)
        {
            try
            {
                DataSet ds = new DataSet();


                ds = ObjBL.GetClasses();
                ddlClass.DataSource = ds.Tables[0];
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassID";
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
                ds = ObjBL.GetSection();
                ddlSection.DataSource = ds.Tables[0];
                ddlSection.DataTextField = "SectionName";
                ddlSection.DataValueField = "SectionID";


                ddlSection.DataBind();
                ddlSection.Items.Insert(0, new ListItem("---Select---", "0"));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void  DataBind()
    {
        int ClassId = Convert.ToInt16(ddlClass.SelectedValue);
        int SectionId = Convert.ToInt16(ddlSection.SelectedValue);
        Hashtable Htp = new Hashtable();
        Htp.Add(0, "Period");
        Htp.Add(1, "I");
        Htp.Add(2, "II");
        Htp.Add(3, "III");
        Htp.Add(4, "IV");
        Htp.Add(5, "V");
        Htp.Add(6, "VI");
        Htp.Add(7, "VII");
        Htp.Add(8, "VIII");

        Htp.Add(9, "IX");
        Htp.Add(10, "X");

        Htp.Add(11, "XI");

        Htp.Add(12, "XII");

        GridView1.Columns.Clear();   
        if ((ClassId != 0) && (SectionId != 0))
        {
            DataSet ds1 = new DataSet();
            ds1 = ObjStaff.GetTimetableClasswise(Convert.ToInt16(ddlClass.SelectedValue.ToString()), Convert.ToInt16(ddlSection.SelectedValue.ToString()),Convert.ToInt16(ddlYear.SelectedValue)  );

            if (ds1.Tables.Count > 0)
            {
                GvPanel.Visible = true;
                lblText.Visible = false;
                DataView dv1 = new DataView(ds1.Tables[0]);
                DataTable dt = new DataTable();
                for (int colCnt = 0; colCnt <= Convert.ToInt16(ViewState["Cols"] ); colCnt++)
                {

                    DataColumn dc = new DataColumn();
                    if (colCnt == 0)
                    {
                        dc.ColumnName = "days";
                        dt.Columns.Add(dc);
                    }
                    else
                    {
                        dc.ColumnName = "Period" + colCnt.ToString();
                        dt.Columns.Add(dc);
                    }



                }
                int k = 1;
               
                for (int j = 1; j <= Convert.ToInt16(ViewState["Rows"]); j++)
                {

                    dv1.RowFilter = "DayId =" + j.ToString();
                    DataRow dr = dt.NewRow();
                    if (dv1.Count > 0)
                    {

                        dr["Days"] = dv1[0][2];
                        for (int i = 0; i < dv1.Count; i++)
                        {
                            k = i + 1;
                            for (int b = 1; b < Htp.Count; b++)
                            {
                                if (Htp[b].ToString() == dv1[i]["Period"].ToString())
                                {
                                    dr["Period" + b] = dv1[i]["FullName"].ToString();
                                    break;
                                }
                            }
                        }
                        dt.Rows.Add(dr);
                    }
                }
                 BoundField bfield = new BoundField();
                bfield.DataField = "Days";
                bfield.HeaderText = "Days";
                //bfield.ItemStyle.BackColor  = System.Drawing.Color.SkyBlue; 
                GridView1.Columns.Add(bfield); 
                for (int colCnt = 1; colCnt <= Convert.ToInt16(ViewState["Cols"]); colCnt++)
                {BoundField tf = new BoundField();
                    tf.DataField = "Period" + colCnt.ToString();
                    tf.HeaderText = "Period" + colCnt.ToString();
                  
                    GridView1.Columns.Add(tf);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
                //string str = "<center><div><table border='2'><tr><td></td><td>I</td><td>II</td><td>III</td><td>IV</td><td>V</td><td>VI</td><td>VII</td><td>VIII</td></tr>";



                //for (int j = 1; j <= 6; j++)
                //{

                //    dv1.RowFilter = "DayId =" + j.ToString();
                //    if (dv1.Count > 0)
                //    {
                //        str += "<tr><td>" + dv1[0][2].ToString() + "</td>";

                //        for (int i = 0; i < dv1.Count; i++)
                //        {
                //            str += "<td>" + dv1[i][5].ToString() + "</td>";
                //        }
                //        str += "</tr>";
                //    }
                //}

                //str += "</table></div></center>";
                //Divtag.InnerHtml  = str;

                // liTabl.Text = str;

            }
            else
            {
                GvPanel.Visible = false;
                lblText.Visible = true;
                lblText.Text = "Data Is Not Available";
                lblText.Font.Bold = true;
                //Divtag.InnerHtml = "Data is not aviable"; 
            }



        }

    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();
        ds1 = ObjStaff.GetDaysPeriods(Convert.ToInt16(ddlClass.SelectedValue), Convert.ToInt16(ddlSection.SelectedValue), Convert.ToInt16(ddlYear.SelectedValue));
        if (ds1.Tables.Count > 0)
        {
            ViewState["Rows"] = ds1.Tables[0].Rows[0]["Days"].ToString();
            ViewState["Cols"] = ds1.Tables[0].Rows[0]["Periods"].ToString();
            DataBind();
        }
       
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();
        ds1 = ObjStaff.GetDaysPeriods(Convert.ToInt16(ddlClass.SelectedValue), Convert.ToInt16(ddlSection.SelectedValue), Convert.ToInt16(ddlYear.SelectedValue));
        if (ds1.Tables.Count > 0)
        {
            ViewState["Rows"] = ds1.Tables[0].Rows[0]["Days"].ToString();
            ViewState["Cols"] = ds1.Tables[0].Rows[0]["Periods"].ToString();
            DataBind();
        }
        
    }
    protected void Prtbtn_Click(object sender, EventArgs e)
    {

    }
}
