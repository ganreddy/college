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
public partial class Admin_ModifyTimetable : System.Web.UI.Page
{
    public class MyTemplate : ITemplate
    {
        private string colname;
        public MyTemplate(string colname)
        {
            this.colname = colname;
        }
        public void InstantiateIn(Control container)
        {
            DropDownList ddl = new DropDownList();
            ddl.ID = "ddl" + colname;
            ddl.DataBinding += new EventHandler(this.OnDataBinding);
            //ch.Text = colname;
            container.Controls.Add(ddl);
        }
        protected void insert_button_Click(Object sender, EventArgs e)
        {
            new Page().Session["InsertFlag"] = 1;
        }
        //just sets the insert flag OFF so that we ll be able to decide in OnRowUpdating event whether to insert or update 
        protected void edit_button_Click(Object sender, EventArgs e)
        {
            new Page().Session["InsertFlag"] = 0;
        }
        public void OnDataBinding(object sender, EventArgs e)
        {
            Admin_ModifyTimetable ob = new Admin_ModifyTimetable();
            DataSet ds2=new DataSet();
            ds2=ob.GetDataSource(); 
            DropDownList ddl = (DropDownList)sender;
            GridViewRow container = (GridViewRow)ddl.NamingContainer;
            ddl.DataSource = ds2.Tables[0];
            ddl.DataTextField = "FullName";
            ddl.DataValueField = "StaffID";
            //ddl.Items.Add(new ListItem("---Select---", "0")); 
          // ddl.SelectedValue  = ((DataRowView)container.DataItem)[colname].ToString();
           //ddl.Enabled = false;
        }
    }
    CommonDataBL ObjBL = new CommonDataBL();
    StaffBL ObjStaff = new StaffBL();
    protected void Page_Load(object sender,EventArgs e)
    {
        if (ViewState["Rows"] != null && ViewState["Cols"] != null )
        {
            DataBind1();
            if (ViewState["But"] != null)
            {
                int j = Convert.ToInt16(ViewState["But"]);
                GridViewRow row = GridView1.Rows[j];
                int col5 = Convert.ToInt16(ViewState["Cols"]);
                Button bt = (Button)row.Cells[col5 + 1].Controls[0];
                bt.Text = "Update"; 
                for (int i = 1; i <= col5; i++)
                {
                    DropDownList ddl = (DropDownList)row.Cells[i].FindControl("ddlPeriod" + i.ToString());//GridView1.Rows[index].Cells[i].FindControl("ddlPeriod" + i.ToString());
                    if ((ddl.Enabled == false))
                    {
                        ddl.Enabled = true;
                    }
                }
            }
        }
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

             
             

                ds = ObjStaff.GetTeachingStaff(0);



            }
            catch (Exception)
            {

                throw;
            }
        }

    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();
        ds1 = ObjStaff.GetDaysPeriods(Convert.ToInt16(ddlClass.SelectedValue), Convert.ToInt16(ddlSection.SelectedValue), Convert.ToInt16(ddlYear.SelectedValue));
        if (ds1.Tables.Count  > 0)
        {
            ViewState["Rows"] = ds1.Tables[0].Rows[0]["Days"].ToString();
            ViewState["Cols"] = ds1.Tables[0].Rows[0]["Periods"].ToString();
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
        }
    }
    protected void DataBind1()
    {
        int ClassId = Convert.ToInt16(ddlClass.SelectedValue);
        int SectionId = Convert.ToInt16(ddlSection.SelectedValue);
        int YearId = Convert.ToInt16(ddlYear.SelectedValue);
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
        if ((ClassId != 0) && (SectionId != 0) && (YearId!=0))
        {
            DataSet ds1 = new DataSet();
            ds1 = ObjStaff.GetTimetableClasswise(Convert.ToInt16(ddlClass.SelectedValue.ToString()), Convert.ToInt16(ddlSection.SelectedValue.ToString()),Convert.ToInt16(ddlYear.SelectedValue) );

            if (ds1.Tables.Count > 0)
            {
                GvPanel.Visible = true;
                //lblText.Visible = false;
                DataView dv1 = new DataView(ds1.Tables[0]);
                DataTable dt = new DataTable();
                for (int colCnt = 0; colCnt <=Convert.ToInt16( ViewState["Cols"]); colCnt++)
                {

                    DataColumn dc = new DataColumn();
                    if (colCnt == 0)
                    {
                        dc.ColumnName = "Days";
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
                                    dr["Period" + b] = dv1[i]["TeacherId"].ToString();
                                   
                                }
                                
                            }
                            //dr["Period" + k] = dv1[i][4].ToString();
                        }
                        dt.Rows.Add(dr);
                    }
                }
                GridView1.Columns.Clear();   
                BoundField bfield = new BoundField();
                bfield.DataField = "Days";
                bfield.HeaderText = "Days";
                bfield.ControlStyle.CssClass = "gridviewheader";  
                GridView1.Columns.Add(bfield);  
                for (int colCnt = 1; colCnt <= Convert.ToInt16(ViewState["Cols"]); colCnt++)
                {
                    TemplateField tf = new TemplateField();
                    MyTemplate ta = new MyTemplate("Period" + colCnt.ToString());
                    tf.HeaderText = "Period" + colCnt.ToString();
                    tf.ItemTemplate = ta;
                    GridView1.Columns.Add(tf);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
              
                ButtonField btfiled = new ButtonField();
                btfiled.ButtonType = ButtonType.Button;
                
                    btfiled.Text = "Edit";
               
                btfiled.HeaderText = "Edit";
                btfiled.CommandName = "Editing";
                GridView1.Columns.Add(btfiled);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    for (int j = 1; j <= Convert.ToInt16(ViewState["Cols"]); j++)
                    {

                        DropDownList ddl = (DropDownList)GridView1.Rows[i].Cells[j].FindControl("ddlPeriod" + j); ;
                        ddl.Items.Insert(0, new ListItem("---Select---", "0"));  
                        ddl.SelectedValue = dt.Rows[i][j].ToString();  
                        //ddl.Enabled = false;


                    }
                }
                datafiled();
                //GridView1.DataSource = dt;
                //GridView1.DataBind();
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
                lblText.Text = "Data is not aviable";
                lblText.Font.Bold = true;
                //Divtag.InnerHtml = "Data is not aviable"; 
            }

            

        }

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{
        //    DataTable dt = (DataTable)GridView1.DataSource;
        //    foreach (GridViewRow gvr in GridView1.Rows)
        //    {
        //        //Status
        //        for (int i = 1; i <= Convert.ToInt16(ViewState["Cols"]); i++)
        //        {
        //            DropDownList ddl = (DropDownList)gvr.Cells[i].Controls[1];


        //            ddl.SelectedValue = dt.Rows[gvr.RowIndex][i].ToString();
        //            ddl.Enabled = false;
        //        }
        //    }

        //}
        //catch (Exception ex)
        //{
        //}
    }
    public DataSet GetDataSource()
    {
        DataSet ds = ObjStaff.GetTeachingStaff(0);
        return ds;
    }
    public DataSet GetSubject()
    {
        DataSet ds = ObjBL.GetSubject();
        return ds;
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
 //GridViewRow row1 = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        //GridViewRow row1 = ((GridViewRow)(((Button)(((WebControl)(e.CommandSource)).Parent)).Parent));
        //GridView gv = (GridView)(e.CommandSource);
        int r,f;
        string name="",period;
        Hashtable Ht = new Hashtable();
        Ht.Add(0, "Days");
        Ht.Add(1, "Monday");
        Ht.Add(2, "Tuesday");
        Ht.Add(3, "Wednesday");
        Ht.Add(4, "Thursday");
        Ht.Add(5, "Friday");
        Ht.Add(6, "Saturday");
        Ht.Add(7, "Sunday");
        if (e.CommandName == "Editing")
        {
            int index1 = Convert.ToInt16(e.CommandArgument);
            GridViewRow row1 = GridView1.Rows[index1];
            row1.Enabled = true;
            int index = Convert.ToInt16(row1.RowIndex);
            int count = row1.Cells.Count; 
            int col5 = Convert.ToInt16(ViewState["Cols"]);
            Button bt = (Button)row1.Cells[col5 + 1].Controls[0]; 
            //Button bt = (Button)GridView1.Rows[index].Cells[col5+1].Controls[1];
            int k = 0, YearId, ClassId, SectionId, DayId=0;
            YearId = Convert.ToInt16(ddlYear.SelectedValue);
            ClassId = Convert.ToInt16(ddlClass.SelectedValue);
            SectionId = Convert.ToInt16(ddlSection.SelectedValue);
            if (bt.Text == "Edit")
            {
                bt.Text = "Update";
                ViewState["But"] = index.ToString(); ; 
                GridViewRow row = GridView1.Rows[index];
               
                for (int i = 1; i <= col5; i++)
                {
                    DropDownList ddl =  (DropDownList)row1.Cells[i].FindControl("ddlPeriod" + i.ToString());//GridView1.Rows[index].Cells[i].FindControl("ddlPeriod" + i.ToString());
                    if ((ddl.Enabled == false))
                    {
                        ddl.Enabled = true;
                        Session[k.ToString()] = ddl.SelectedValue.ToString();
                        k++;
                    }

                }
               

            }
            else
            {
                if (bt.Text == "Update")
                {
                    k = 0;
                    f = 0;
                    name = "";
                   // lblText.Text = "";
                    GridViewRow row = GridView1.Rows[index];
                    string Day = GridView1.DataKeys[index].Value.ToString();
                    for (int x = 1; x < Ht.Count; x++)
                    {
                        if (Ht[x].ToString() == Day)
                        {
                            DayId = x;
                        }
                    }
                    //DayId = index + 1;
                    k = 0;
                    for (int i = 1; i < GridView1.Columns.Count - 1; i++)
                    {

                        DropDownList ddl = (DropDownList)GridView1.Rows[index].Cells[i].FindControl("ddlPeriod" + i.ToString());

                        period = Session[k.ToString()].ToString();
                        if ((ddl.Enabled == true) && (ddl.SelectedValue != period)) 
                        {
                           r= ObjStaff.UpdateTimetable(Convert.ToInt16(ddl.SelectedValue), DayId, i, ClassId, SectionId, YearId);

                           if (r > 0)
                           {
                             
                           }
                           else
                           {

                               name = name + ddl.SelectedItem.ToString() + " Already Allotted" +  " Peroid"+"&nbsp;"+i+","+"&nbsp;";
                               
                               f = 1;
                           }
                        }
                        k++;
                    }

                    bt.Text = "Edit";
                    ViewState["But"] = null;
                    if (f == 0)
                    {
                        lblText.Text = "Updated Successfully";
                    }
                    else
                    {
                        lblText.Text = name.ToString();
                    }
                    datafiled(); 

                }
            }
            
            
        }
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();
        ds1 = ObjStaff.GetDaysPeriods(Convert.ToInt16(ddlClass.SelectedValue), Convert.ToInt16(ddlSection.SelectedValue), Convert.ToInt16(ddlYear.SelectedValue));
        if ( ds1.Tables.Count>0)
        {
            ViewState["Rows"] = ds1.Tables[0].Rows[0]["Days"].ToString();
            ViewState["Cols"] = ds1.Tables[0].Rows[0]["Periods"].ToString();
        }
        DataBind1();

    }
    public void datafiled()
    {
       
     
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                for (int j = 1; j <= Convert.ToInt16(ViewState["Cols"]); j++)
                {

                    DropDownList ddl = (DropDownList)GridView1.Rows[i].Cells[j].FindControl("ddlPeriod" + j); ;
                    ddl.Enabled = false;


                }
            }
              
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
