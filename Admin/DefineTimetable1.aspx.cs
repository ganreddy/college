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
public partial class Admin_DefineTimetable1 : System.Web.UI.Page
{
    CommonDataBL ObjBL = new CommonDataBL();
    StaffBL ObjStaff = new StaffBL();
    DataSet ds = new DataSet();
    public class MyTemplate : ITemplate
    {
        private string colname;
        public MyTemplate(string colname)
        {
            this.colname = colname;
        }
        public void InstantiateIn(Control container)
        {
            CheckBox ch = new CheckBox();
            ch.ID = "Checkbox" + colname;
            ch.Checked = false;
            ch.DataBinding += new EventHandler(this.OnDataBinding);
            ch.Text = colname;
            container.Controls.Add(ch);
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
            CheckBox ch = (CheckBox)sender;
            GridViewRow container = (GridViewRow)ch.NamingContainer;
            ch.Text = ((DataRowView)container.DataItem)[colname].ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("onclick", "javascript:return validation();");
        if (ViewState["Rows"] != null && ViewState["cols"] != null)
        {
            BuildDataGrid();
        }
        if (!IsPostBack)
        {
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
            ds = ObjBL.GetSubject();
            ddlSubject.DataSource = ds.Tables[0];
            ddlSubject.DataTextField = "SubjectName";
            ddlSubject.DataValueField = "SubjectId";
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(0, new ListItem("---Select---", "0"));

            ds = ObjStaff.GetTeachingStaff(0);
            ddlTeacher.DataSource = ds.Tables[0];
            ddlTeacher.DataTextField = "FullName";
            ddlTeacher.DataValueField = "StaffID";
            ddlTeacher.DataBind();
            ddlTeacher.Items.Insert(0, new ListItem("---Select---", "0"));
            lblMessage.Visible = false;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            int TeacherId, DayId, PeriodId = 0, ClassId, SectionId, SubjectId, YearId;
            string id, id1;
            TeacherId = Convert.ToInt16(ddlTeacher.SelectedValue);
            ClassId = Convert.ToInt16(ddlClass.SelectedValue);
            SectionId = Convert.ToInt16(ddlSection.SelectedValue);
            SubjectId = Convert.ToInt16(ddlSubject.SelectedValue);
            YearId = Convert.ToInt16(ddlYear.SelectedValue);
            int row = 0, k, f = 0;
            id = ddlTeacher.SelectedItem.ToString();
            id1 = "";
            foreach (GridViewRow gvr in Gv.Rows)
            {
                for (int i = 1; i < Gv.Columns.Count; i++)
                {
                    CheckBox ch = (CheckBox)gvr.Cells[i].FindControl("CheckBoxPeriod" + i.ToString());

                    //id1= GvTable.DataKeys[row].Value.ToString(); 
                    DayId = row + 1;
                    if ((ch.Checked) && (ch.Enabled == true))
                    {
                        PeriodId = i;
                        k = ObjStaff.AddTimetable(TeacherId, DayId, PeriodId, ClassId, SectionId, SubjectId, YearId);
                        if (k > 0)
                        {

                        }
                        else
                        {

                            //this.ClientScript.RegisterStartupScript(this.GetType(), "abc", "<script>alert('Added Successfully')</script>");
                            f = 1;

                            //break; ;
                            id1 = id1 + id + "Period"+ PeriodId.ToString()+" \n";
                        }


                    }
                }
                //if (f == 1)
                //{
                //    break;
                //}
                row++;
            }
            if (f == 1)
            {
                id1 = id1 + "Already Engaed Another Class";
                lblMessage.Visible = true;
                lblMessage.Text = id1.ToString();
                // this.ClientScript.RegisterStartupScript(this.GetType(), "abc", "<script>alert('Added Successfully')</script>");


                //Page.ClientScript.RegisterStartupScript(typeof(Page), "abc", "<script>alert('" + PeriodId + " Added Successfully')</script>");
                // this.RegisterStartupScript("MyScript", "<script language=javascript>function AlertHello() { alert('Hello ASP.NET'); }</script>");
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Added Successfully";
            }
            Datafilled();
        }
        catch (Exception)
        {

            throw;
        }   
    }
    public void BuildDataGrid()
    {
        try
        {
            //int row, col;

            //row = Convert.ToInt16(TextBox1.Text);
            //col = Convert.ToInt16(TextBox2.Text);
            Gv.Columns.Clear();
            Hashtable Ht = new Hashtable();
            Ht.Add(0, "Days");
            Ht.Add(1, "Monday");
            Ht.Add(2, "Tuesday");
            Ht.Add(3, "Wensday");
            Ht.Add(4, "Thursday");
            Ht.Add(5, "Friday");
            Ht.Add(6, "Saturday");
            Ht.Add(7, "Sunday");
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

            //Gv.Columns.Clear(); 
            DataTable dt = new DataTable();
            for (int colCnt = 0; colCnt <= Convert.ToInt16(ViewState["cols"]); colCnt++)
            {

                DataColumn dc = new DataColumn();
                if (colCnt == 0)
                {
                    dc.ColumnName = Ht[0].ToString();
                    dt.Columns.Add(dc);

                }
                else
                {
                    dc.ColumnName = Htp[0].ToString() + colCnt.ToString();
                    dt.Columns.Add(dc);
                }
            }

            for (int rows = 1; rows <=Convert.ToInt16(ViewState["Rows"]); rows++)
            {
                DataRow dr = dt.NewRow();
                dr["Days"] = Ht[rows];
                for (int cols = 1; cols < dt.Columns.Count; cols++)
                {
                    dr["Period" + cols] = Htp[cols].ToString();
                }
                dt.Rows.Add(dr);
            }

            //int k=  dt.Rows.Count;


            //DataRow dr1 in dt.Rows
//            string str;

            //foreach (DataRow dr4 in dt.Rows)
            //{


            //foreach(DataColumn dc4 in dt.Columns)
            ////for (int i = 1; i < dt.Columns.Count; i++)
            //{

            BoundField bfield = new BoundField();
            bfield.DataField = "Days";
            bfield.HeaderText = "Days";
            Gv.Columns.Add(bfield);
            for (int colCnt = 1; colCnt <= Convert.ToInt16(ViewState["cols"]); colCnt++)
            {

                //        TemplateField Tfield = new TemplateField();
                //        Tfield.HeaderTemplate = new CheckBoxTemplate(ListItemType.Header, "Period" + colCnt.ToString());
                //str= dr4[colCnt].ToString();
                //        Tfield.ItemTemplate = new CheckBoxTemplate(ListItemType.Item,str);
                //        Gv.Columns.Add(Tfield);
                //        Gv.DataSource = dt;
                //        Gv.DataBind();

                // str= dr4[colCnt].ToString();
                TemplateField tf = new TemplateField();
                MyTemplate ta = new MyTemplate("Period" + colCnt.ToString());
                tf.HeaderText = "Period" + colCnt.ToString();
                tf.ItemTemplate = ta;
                Gv.Columns.Add(tf);
                Gv.DataSource = dt;
                Gv.DataBind();
            }
            // }

            // Gv.DataBind();  
            // }


            //for (int j = 1; j <dt.Rows.Count; j++)
            //{



            //}

            //foreach (DataColumn col1 in dt.Columns)
            //{
            //    TemplateField bfield = new TemplateField();

            //    //Initalize the DataField value.
            //   // bfield.HeaderTemplate = new CheckBoxTemplate(ListItemType.Header, col1.ColumnName);

            //    //Initialize the HeaderText field value.
            //    bfield.ItemTemplate = new CheckBoxTemplate(ListItemType.Item, col1.ColumnName);
            //    Gv.Columns.Add(bfield);
            //    //Add the newly created bound field to the GridVie

            //    //// TemplateField tf = new TemplateField();

            //    ////Declare the bound field and allocate memory for the bound field.
            //    //BoundField bfield = new BoundField();

            //    ////Initalize the DataField value.
            //    //bfield.DataField = col1.ColumnName;

            //    ////Initialize the HeaderText field value.
            //    //bfield.HeaderText = col1.ColumnName;

            //    ////Add the newly created bound field to the GridView.
            //    //Gv.Columns.Add(bfield);
            //}
            //Gv.DataSource = dt;
            //Gv.DataBind(); 
            ViewState["Rows"] = ddlDays.SelectedValue.ToString()  ;
            ViewState["cols"] = ddlPeriods.SelectedValue.ToString();  

        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void Datafilled()
    {

        int ClassId, SectionId, YearId, row = 0, DayId;
        DataSet ds = new DataSet();
        try
        {

            ClassId = Convert.ToInt16(ddlClass.SelectedValue);
            SectionId = Convert.ToInt16(ddlSection.SelectedValue);
            YearId = Convert.ToInt16(ddlYear.SelectedValue);
            if ((ClassId != 0) && (SectionId != 0) && (YearId != 0))
            {
                ds = ObjStaff.GetClassTimetable(ClassId, SectionId, YearId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {

                        for (row = 0; row < Convert.ToInt16(ViewState["Rows"]); row++)
                        {

                            for (int i = 1; i < Gv.Columns.Count ; i++)
                            {


                                //id1= GvTable.DataKeys[row].Value.ToString(); 
                                DayId = row + 1;
                                if (((Convert.ToInt16(ds.Tables[0].Rows[j]["DayId"].ToString())) == DayId) && (Convert.ToInt16(ds.Tables[0].Rows[j]["PeriodId"].ToString()) == i))
                                {
                                    CheckBox ch = (CheckBox)Gv.Rows[row].Cells[i].FindControl("CheckBoxPeriod" + i.ToString());
                                    ch.Checked = false;
                                    ch.Enabled = false;
                                }
                            }

                        }

                    }
                }
                else
                {
                    foreach (GridViewRow gvr in Gv.Rows)
                    {
                        for (int i = 1; i < Gv.Columns.Count ; i++)
                        {
                            CheckBox ch = (CheckBox)gvr.Cells[i].FindControl("CheckBoxPeriod" + i.ToString());
                            if ((ch.Checked)&& (ch.Enabled)) 
                            {
                                ch.Enabled = true;
                                ch.Checked = false;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception)
        {

            throw;
        }



    }
    protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        Datafilled();
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        Datafilled();
    }
    protected void ddlPeriods_SelectedIndexChanged(object sender, EventArgs e)
    {
        BuildDataGrid();
    }
}
