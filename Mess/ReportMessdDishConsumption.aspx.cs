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

public partial class Mess_MessdDishConsumption : System.Web.UI.Page
{
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    
    BusinessLayer.MessBL objMess = new MessBL();
    DataSet ds;


    protected void Page_Load(object sender, EventArgs e)
    {
       // btnReport.Attributes.Add("onclick", "javascript:return validate();");
        ds = new DataSet();
        if (!IsPostBack)
        {
            ds = objMess.GetMessDish();
            ddlDishId.DataSource = ds.Tables[0];
            ddlDishId.DataTextField = "DishName";
            ddlDishId.DataValueField = "DishID";
            ddlDishId.DataBind();
            ddlDishId.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objMess.GetMealType();
            ddlMealType.DataSource = ds.Tables[0];
            ddlMealType.DataTextField = "MealType";
            ddlMealType.DataValueField = "MealID";
            ddlMealType.DataBind();
            ddlMealType.Items.Insert(0, new ListItem("---Select---", "0"));
            
        }

    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        string DishName = string.Empty, MealType = string.Empty, FromDate = string.Empty, ToDate = string.Empty;
        DishName = ddlDishId.Items[ddlDishId.SelectedIndex].Value;
        MealType = ddlMealType.Items[ddlMealType.SelectedIndex].Value;
        if (txtFromDate.Text != "")
            FromDate =ChangeDateFormat(txtFromDate.Text);
        if (txtToDate.Text != "")
            ToDate = ChangeDateFormat(txtToDate.Text);


        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "MessDishConsumption"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;
        MyReportViewer.SizeToReportContent = true;
        // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[4];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("dishid", DishName);
        reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("mealType", MealType);
        reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", FromDate);
        reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate);
        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

        MyReportViewer.ServerReport.Refresh();
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
}
