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
using BusinessLayer;
public partial class MessCreateMenu : System.Web.UI.Page
{
    BusinessLayer.MessBL objMess = new MessBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    BusinessLayer.StudentAdmissionBL objStud = new StudentAdmissionBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", "javascript:return validation();");
        lblMessage.Attributes.Add("style", "color:red;font-weight:bold;");
        if (!IsPostBack)
        {
            
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");       
            ds = objMess.GetMessDishConsumption(1);
            ddlDishName.DataSource = ds.Tables[0];
            ddlDishName.DataTextField = "DishName";
            ddlDishName.DataValueField = "DishID";
            ddlDishName.DataBind();
            ddlDishName.Items.Insert(0, new ListItem("--Select--", "0"));
            ds = objMess.GetMessDishConsumption(2);
            ddlDishName2.DataSource = ds.Tables[0];
            ddlDishName2.DataTextField = "DishName";
            ddlDishName2.DataValueField = "DishID";
            ddlDishName2.DataBind();
            ddlDishName2.Items.Insert(0, new ListItem("--Select--", "0"));
            ds = objMess.GetMessDishConsumption(3);
            ddlDishName3.DataSource = ds.Tables[0];
            ddlDishName3.DataTextField = "DishName";
            ddlDishName3.DataValueField = "DishID";
            ddlDishName3.DataBind();
            ddlDishName3.Items.Insert(0, new ListItem("--Select--", "0"));
            ds = objMess.GetMessDishConsumption(4);
            ddlDishName4.DataSource = ds.Tables[0];
            ddlDishName4.DataTextField = "DishName";
            ddlDishName4.DataValueField = "DishID";
            ddlDishName4.DataBind();
            ddlDishName4.Items.Insert(0, new ListItem("--Select--", "0"));
            ds = objMess.GetMessDishConsumption(5);
            ddlDishName5.DataSource = ds.Tables[0];
            ddlDishName5.DataTextField = "DishName";
            ddlDishName5.DataValueField = "DishID";
            ddlDishName5.DataBind();
            ddlDishName5.Items.Insert(0, new ListItem("--Select--", "0"));
          
            ds = objStud.GetStudentCount();
            lblAvailDisplay.Style.Add("display", "none");
            lblAvailDisplay.Text = ds.Tables[0].Rows[0][0].ToString();
            lblAvailability.Visible = true;

            lblAvailability.Text = ds.Tables[0].Rows[0][0].ToString();
            int a = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            lblAvailability.Text ="Total Number Of Students:"+ ds.Tables[0].Rows[0][0].ToString();
            ds = objStud.GetStudentLeavesCount(Convert.ToDateTime(ChangeDateFormat(txtDate.Text)));
            lblAvailLeaves.Style.Add("display", "none");
            lblAvailLeaves.Visible = true;
            lblAvailLeaves.Text = "</br>" + "Total Number Of Leaves To This Date:" + ds.Tables[0].Rows[0][0].ToString();
            lblAvailLeaves.Text = ds.Tables[0].Rows[0][0].ToString();
           
            lblTotalStudents.Visible = true;
            lblTotalStudents.Text = "</br>" + "Total Number Of Leaves To This Date:" + ds.Tables[0].Rows[0][0].ToString();
            int b =Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            lblAvilablestd.Visible = true;
            lblAvilablestd.Text = "</br>" + "Total Number Of Students Present On This Date:" + (a - b).ToString();

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strDate=txtDate.Text;
        ds = new DataSet();
        ds = objMess.CheckDuplicatesDishItems(Convert.ToDateTime(ChangeDateFormat(strDate)));
        try
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Already Dish Provided For Students To This Date";
                }
            }
            else
            {
                if (ddlDishName.SelectedIndex != 0)
                {
                    objMess.AddMessDishConsumption(Convert.ToDateTime(ChangeDateFormat(strDate)), Convert.ToInt32(ddlDishName.Items[ddlDishName.SelectedIndex].Value), 1, Convert.ToInt32(txtNameofStu.Text));
                }
                if (ddlDishName2.SelectedIndex != 0)
                {
                    objMess.AddMessDishConsumption(Convert.ToDateTime(ChangeDateFormat(strDate)), Convert.ToInt32(ddlDishName2.Items[ddlDishName2.SelectedIndex].Value), 2, Convert.ToInt32(txtNameofStu2.Text));
                }
                if (ddlDishName3.SelectedIndex != 0)
                {
                    objMess.AddMessDishConsumption(Convert.ToDateTime(ChangeDateFormat(strDate)), Convert.ToInt32(ddlDishName3.Items[ddlDishName3.SelectedIndex].Value), 3, Convert.ToInt32(txtNameofStu3.Text));
                }
                if (ddlDishName4.SelectedIndex != 0)
                {
                    objMess.AddMessDishConsumption(Convert.ToDateTime(ChangeDateFormat(strDate)), Convert.ToInt32(ddlDishName4.Items[ddlDishName4.SelectedIndex].Value), 4, Convert.ToInt32(txtNameofStu4.Text));
                }
                if (ddlDishName5.SelectedIndex != 0)
                {
                    objMess.AddMessDishConsumption(Convert.ToDateTime(ChangeDateFormat(strDate)), Convert.ToInt32(ddlDishName5.Items[ddlDishName5.SelectedIndex].Value), 5, Convert.ToInt32(txtNameofStu5.Text));
                }
                lblMessage.Visible = true;
                lblMessage.Text = "Mess Dish Consumption Added Successfully";
                txtNameofStu.Text = "";
                ddlDishName.SelectedIndex = 0;
                txtNameofStu2.Text = "";
                ddlDishName2.SelectedIndex = 0;
                txtNameofStu3.Text = "";
                ddlDishName3.SelectedIndex = 0;
                txtNameofStu4.Text = "";
                ddlDishName4.SelectedIndex = 0;
                txtNameofStu5.Text = "";
                ddlDishName5.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
        }
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }



    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        ds = objStud.GetStudentLeavesCount(Convert.ToDateTime(ChangeDateFormat(txtDate.Text)));
        lblAvailLeaves.Visible = true;
        //lblAvailLeaves.Text = "</br>" + "Total Number Of Leaves To This Date:" + ds.Tables[0].Rows[0][0].ToString();
        lblAvailLeaves.Text = ds.Tables[0].Rows[0][0].ToString();
    }
}
 
             

  
     
