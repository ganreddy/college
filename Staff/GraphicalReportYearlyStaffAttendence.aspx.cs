﻿using System;
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

public partial class Staff_GraphicalYearlyStaffAttendence : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BusinessLayer.StaffBL objStaff = new StaffBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnGetReport.Attributes.Add("onclick", "javascript:return validation();");
        rbtnTabularReport.Attributes.Add("onclick", "javascript:return Display();");
        rbtnGraphical.Attributes.Add("onclick", "javascript:return Display();");
        if (!IsPostBack)
        {
            ds = objStaff.GetStaffDetails(0);
            ddlStaff.DataSource = ds.Tables[0];
            ddlStaff.DataTextField = "FullName";
            ddlStaff.DataValueField = "StaffID";
            ddlStaff.DataBind();
            ddlStaff.Items.Insert(0, new ListItem("---Select---", "0"));
            for (int i = 1990; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));

            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void btnGetReport_Click(object sender, EventArgs e)
    {
        string Staff = String.Empty, Year = String.Empty;
        Staff = ddlStaff.Items[ddlStaff.SelectedIndex].Value;
        //Month = ddlMonth.Items[ddlMonth.SelectedIndex].Value;
        Year = ddlYear.Items[ddlYear.SelectedIndex].Value;

        if (rbtnGraphical.Checked)
        {
            if (ddlChartType.SelectedIndex == 1)
            {
                StaffMonthlyAttendanceReportViewer.Visible = true;
                StaffMonthlyAttendanceReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                StaffMonthlyAttendanceReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
                StaffMonthlyAttendanceReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "BarChartYearlyStaffAttendance";
                StaffMonthlyAttendanceReportViewer.ShowParameterPrompts = false;
                StaffMonthlyAttendanceReportViewer.ShowPrintButton = true;
                StaffMonthlyAttendanceReportViewer.ShowToolBar = true;
                StaffMonthlyAttendanceReportViewer.SizeToReportContent = true;
                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.
                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[2];
                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("StaffID", Staff);
                //reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Month", Month);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Year", Year);
                StaffMonthlyAttendanceReportViewer.ServerReport.SetParameters(reportParameterCollection);
                StaffMonthlyAttendanceReportViewer.ServerReport.Refresh();
            }
            if (ddlChartType.SelectedIndex == 2)
            {
                StaffMonthlyAttendanceReportViewer.Visible = true;
                StaffMonthlyAttendanceReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                StaffMonthlyAttendanceReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
                StaffMonthlyAttendanceReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "LineChartYearlyStaffAttendance";
                StaffMonthlyAttendanceReportViewer.ShowParameterPrompts = false;
                StaffMonthlyAttendanceReportViewer.ShowPrintButton = true;
                StaffMonthlyAttendanceReportViewer.ShowToolBar = true;
                StaffMonthlyAttendanceReportViewer.SizeToReportContent = true;
                // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.
                Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[2];
                reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("StaffID", Staff);
                //reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Month", Month);
                reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Year", Year);
                StaffMonthlyAttendanceReportViewer.ServerReport.SetParameters(reportParameterCollection);
                StaffMonthlyAttendanceReportViewer.ServerReport.Refresh();
            }
        }
        if (rbtnTabularReport.Checked)
        {
            StaffMonthlyAttendanceReportViewer.Visible = true;
            StaffMonthlyAttendanceReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            StaffMonthlyAttendanceReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
            StaffMonthlyAttendanceReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "YearlyStaffAttendance";
            StaffMonthlyAttendanceReportViewer.ShowParameterPrompts = false;
            StaffMonthlyAttendanceReportViewer.ShowPrintButton = true;
            StaffMonthlyAttendanceReportViewer.ShowToolBar = true;
            StaffMonthlyAttendanceReportViewer.SizeToReportContent = true;
            // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.
            Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[2];
            reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("StaffID", Staff);
            //reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Month", Month);
            reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("Year", Year);
            StaffMonthlyAttendanceReportViewer.ServerReport.SetParameters(reportParameterCollection);
            StaffMonthlyAttendanceReportViewer.ServerReport.Refresh();
        }
    }
}
