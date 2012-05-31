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
using System.Text;

public partial class student_Studentactiviti : System.Web.UI.Page
{
    BusinessLayer.StudentAdmissionBL objStudComm = new StudentAdmissionBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnShow.Attributes.Add("onclick", "javascript:return validation();");
        Button1.Attributes.Add("onclick", "javascript:return val2();");
        Button2.Attributes.Add("onclick", "javascript:return val1();");
        //btnShow.Attributes.Add("onclick", "javascript:return val3();");
        lblMassage.Attributes.Add("style", "color:red;font-weight:bold;");
        tbList.Visible = true;
        if (!IsPostBack)
        {
            try
            {
                ddlactivittype.Items.Insert(0, new ListItem("---Select---", "0"));
                ddlActivites.Items.Insert(0, new ListItem("---Select---", "0"));

                ds = objStudComm.GetHouse();
                ddlHouse.DataSource = ds.Tables[0];
                ddlHouse.DataTextField = "HouseName";
                ddlHouse.DataValueField = "HouseID";
                ddlHouse.DataBind();
                ddlHouse.Items.Insert(0, new ListItem("---Select---", "0"));
                ds = objComm.GetClub();
                ddlClub.DataSource = ds.Tables[0];
                ddlClub.DataTextField = "ClubName";
                ddlClub.DataValueField = "ClubID";

                ddlClub.DataBind();
                ddlClub.Items.Insert(0, new ListItem("---Select---", "0"));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    protected void ddlHouse_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id;
        try
        {
            id = Convert.ToInt16(ddlHouse.SelectedValue);
            ds = objStudComm.GetStudentdataHousewise(id);
            House.DataSource = ds.Tables[0];
            House.DataTextField = "FullName";
            House.DataValueField = "StudID";
            House.DataBind();
            for (int count = 0; count < House.Items.Count; count++)
            {
                House.Items[count].Text += "," + ds.Tables[0].Rows[count]["ClassName"].ToString() + "," + ds.Tables[0].Rows[count]["SectionName"].ToString();
            }

            if (ddlactivittype.SelectedValue.ToString() == "1")
            {
                SinglePnl.Visible = true;
                GroupPnl.Visible = false;
                ds1 = objStudComm.GetStudentActivities(ChangeDateFormat(txtFrom.Text), Convert.ToInt16(ddlactivittype.SelectedValue.ToString()), Convert.ToInt16(ddlClub.SelectedValue));


                GvSingle.DataSource = ds1.Tables[0];
                GvSingle.DataBind();
            }
            else if (ddlactivittype.SelectedValue.ToString() == "2")
            {
                SinglePnl.Visible = false;
                GroupPnl.Visible = true;
                ds1 = objStudComm.GetGroupStudentactivities(ChangeDateFormat(txtFrom.Text), Convert.ToInt16(ddlactivittype.SelectedValue.ToString()), Convert.ToInt16(ddlClub.SelectedValue));
                GvGroup.DataSource = ds1.Tables[0];
                GvGroup.DataBind();
            }
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {


            for (int count = 0; count < House.Items.Count; count++)
            {
                if (House.Items[count].Selected == true)
                {
                    SelList.Items.Add(new ListItem(House.Items[count].Text, House.Items[count].Value));

                }

            }
            for (int count = House.Items.Count - 1; count >= 0; count--)
            {
                if (House.Items[count].Selected == true)
                {
                    //SelList.Items.Add(new ListItem(House.Items[count].Text, House.Items[count].Value));
                    House.Items.RemoveAt(count);
                }

            }


        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void ddlactivittype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ds = objStudComm.GetActivities(Convert.ToInt16(ddlactivittype.SelectedValue), Convert.ToInt16(ddlClub.SelectedValue));
            ddlActivites.DataSource = ds.Tables[0];
            ddlActivites.DataTextField = "Activities";
            ddlActivites.DataValueField = "ActivitiID";
            ddlActivites.DataBind();
            ddlActivites.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {

        int i;
        tbList.Visible = false;
        try
        {
            //ds = objstu.GetStudentdataHousewise(0);
            //for (int r = 0; r< ds.Tables[0].Rows.Count; r++)
            //{
            for (int col = 0; col < SelList.Items.Count; col++)
            {
                if (SelList.Items[col].Selected == true)
                {
                    i = objStudComm.AddStudentActivities(Convert.ToInt16(SelList.Items[col].Value), Convert.ToInt16(ddlactivittype.SelectedValue.ToString()), Convert.ToInt16(ddlActivites.SelectedValue.ToString()), ChangeDateFormat(txtFrom.Text), Convert.ToInt16(ddlClub.SelectedValue));
                    //if (ds.Tables[0].Rows[r]["StudID"].ToString() == SelList.Items[col].Value.ToString())
                    //{
                    //i=objstu.AddStudentActivities(Convert.ToInt16(ds.Tables[0].Rows[r]["StudID"].ToString()),Convert.ToInt16(ds.Tables[0].Rows[r]["AdmittedInClass"].ToString()),Convert.ToInt16(ds.Tables[0].Rows[r]["Section"].ToString()),Convert.ToInt16(ds.Tables[0].Rows[r]["HouseAlloted"].ToString()),Convert.ToInt16(ddlactivittype.SelectedValue),ddlActivites.SelectedItem.ToString(),txtFrom.Text);     
                    //}

                    if (i > 0)
                    {
                        lblMassage.Text = "Data Added Successfully";
                    }
                }

            }
            if (ddlactivittype.SelectedValue.ToString() == "1")
            {
                SinglePnl.Visible = true;
                GroupPnl.Visible = false;
                ds1 = objStudComm.GetStudentActivities(ChangeDateFormat(txtFrom.Text), Convert.ToInt16(ddlactivittype.SelectedValue.ToString()), Convert.ToInt16(ddlClub.SelectedValue));


                GvSingle.DataSource = ds1.Tables[0];
                GvSingle.DataBind();
            }
            else if (ddlactivittype.SelectedValue.ToString() == "2")
            {
                SinglePnl.Visible = false;
                GroupPnl.Visible = true;
                ds1 = objStudComm.GetGroupStudentactivities(ChangeDateFormat(txtFrom.Text), Convert.ToInt16(ddlactivittype.SelectedValue.ToString()), Convert.ToInt16(ddlClub.SelectedValue));
                GvGroup.DataSource = ds1.Tables[0];
                GvGroup.DataBind();
            }
            SelList.Items.Clear();


            //}
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void GvSingle_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "Update")
        {
            int index = Convert.ToInt16(e.CommandArgument);

            GridViewRow row = GvSingle.Rows[index];
            int id = Convert.ToInt16(GvSingle.DataKeys[row.RowIndex].Value);
            //string Activity = row.Cells[6].Text;
            string Date = row.Cells[8].Text;
            Label lblClub = (Label)row.FindControl("lblClub");
            Label lblActivity = (Label)row.FindControl("lblActivity");
            DropDownList ddl = (DropDownList)row.FindControl("ddlPrize");
            string Prize = ddl.SelectedItem.ToString();
            i = objStudComm.UpdateIndividualStudentActivities(id, Convert.ToInt16(lblActivity.Text), Date, Prize, Convert.ToInt16(lblClub.Text));

            if (i > 0)
            {
                lblMassage.Visible = true;
                lblMassage.Text = "Data Is Updated";
                //  Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "javascript", "<script type='text/javascript' language='javascript'>alert('Student Prize is Updated')</script>");  
            }
            else
            {
                lblMassage.Text = "data";
            }

        }
    }

    protected void GvGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = 0;
        if (e.CommandName == "Update")
        {
            int index = Convert.ToInt16(e.CommandArgument);

            GridViewRow row = GvGroup.Rows[index];
            string HouseName = row.Cells[0].Text;
            //string Activity = row.Cells[2].Text;
            Label lblClub = (Label)row.FindControl("lblClub");
            Label lblActivity = (Label)row.FindControl("lblActivity");
            string Date = row.Cells[4].Text;
            DropDownList ddl = (DropDownList)row.FindControl("ddlPrize1");
            string Prize = ddl.SelectedItem.ToString();
            i = objStudComm.UpdateGroupStudentActivities(HouseName, Convert.ToInt16(lblActivity.Text), Date, Prize, Convert.ToInt16(lblClub.Text));

            if (i > 0)
            {
                lblMassage.Visible = true;
                lblMassage.Text = "Data Is Updated";
                // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "javascript", "<script type=\"text/javascript\">alert('Student Prize is Updated')</script>");  
            }

        }






    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void GvSingle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            // DataSet ds3 = (DataSet)GvSingle.DataSource;
            DataTable Dt = (DataTable)GvSingle.DataSource;
            foreach (GridViewRow gvr in GvSingle.Rows)
            {
                //Status
                DropDownList ddl = (DropDownList)gvr.FindControl("ddlPrize");
                //string = ds3.Tables[0].;
                string id = Dt.Rows[gvr.RowIndex]["Prize"].ToString();

                if (id == "I")
                {
                    ddl.SelectedValue = "1";
                }
                else if (id == "II")
                {
                    ddl.SelectedValue = "2";
                }
                else if (id == "III")
                {
                    ddl.SelectedValue = "3";
                }
                else if (id == "IV")
                {
                    ddl.SelectedValue = "4";
                }
                else
                {
                    ddl.SelectedValue = "0";
                }


            }
        }
        catch (Exception)
        {
        }
    }
    protected void GvGroup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataTable Dt = (DataTable)GvGroup.DataSource;
            foreach (GridViewRow gvr in GvGroup.Rows)
            {
                //Status
                DropDownList ddl = (DropDownList)gvr.FindControl("ddlPrize1");
                //string = ds3.Tables[0].;
                string id = Dt.Rows[gvr.RowIndex]["Prize"].ToString();

                if (id == "I")
                {
                    ddl.SelectedValue = "1";
                }
                else if (id == "II")
                {
                    ddl.SelectedValue = "2";
                }
                else if (id == "III")
                {
                    ddl.SelectedValue = "3";
                }
                else if (id == "IV")
                {
                    ddl.SelectedValue = "4";
                }
                else
                {
                    ddl.SelectedValue = "0";
                }


            }
        }
        catch (Exception)
        {
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {


            for (int count = 0; count < SelList.Items.Count; count++)
            {
                if (SelList.Items[count].Selected == true)
                {
                    House.Items.Add(new ListItem(SelList.Items[count].Text, SelList.Items[count].Value));
                    //SelList.Items.RemoveAt(count);
                }

            }
            for (int count = SelList.Items.Count - 1; count >= 0; count--)
            {
                if (SelList.Items[count].Selected == true)
                {

                    SelList.Items.RemoveAt(count);
                }

            }


        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void GvSingle_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GvGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
}
