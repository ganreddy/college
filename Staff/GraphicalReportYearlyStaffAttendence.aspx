﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="GraphicalReportYearlyStaffAttendence.aspx.cs" Inherits="Staff_GraphicalYearlyStaffAttendence"
    Title="Staff Yearly Attendance Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validation() {
//            if (!DropdownValidate('<%=ddlStaff.ClientID%>', "Please Select Staff")) return false;
            var Tabular = document.getElementById('<%=rbtnTabularReport.ClientID%>').checked;
            var Graphical = document.getElementById('<%=rbtnGraphical.ClientID%>').checked;
            if ((Tabular == false) && (Graphical == false)) {
                alert("Please Select  Radio Button (Either Tabular Or Graphical)");
                return false;
            }
            if (document.getElementById('<%=rbtnTabularReport.ClientID%>').checked) {
                if (!DropdownValidate('<%=ddlYear.ClientID%>', "Please Select Year")) return false;
            }
            if (document.getElementById('<%=rbtnGraphical.ClientID%>').checked) {
                if (!DropdownValidate('<%=ddlChartType.ClientID%>', "Please Select Chart Type")) return false;
            }
            if (document.getElementById('<%=rbtnGraphical.ClientID%>').checked) {
                if (document.getElementById('<%=ddlChartType.ClientID%>').selectedIndex == 1 || document.getElementById('<%=ddlChartType.ClientID%>').selectedIndex == 2) {
                    if (!DropdownValidate('<%=ddlStaff.ClientID%>', "Please Select Staff")) return false;
                }
            }
        }
        function window.onload() {
            Display();
        }
        function Display() {
            if (document.getElementById('<%=rbtnTabularReport.ClientID%>').checked) {
                document.getElementById('<%=trname.ClientID%>').style.display = "none";

            }
            if (document.getElementById('<%=rbtnGraphical.ClientID%>').checked) {
                document.getElementById('<%=trname.ClientID%>').style.display = "inline";

            }

        }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <table align="center" class="tdcls" width="60%">
                <tr>
                    <td colspan="2" class="heading">
                        TABULAR / GRAPHICAL STAFF YEARLY ATTENDANCE REPORT
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="width: 18%; height: 27px;" align="left">
                        Staff <span style="font-size: 14px; color: Red">*</span>
                    </td>
                    <td style="height: 27px">
                        <asp:DropDownList ID="ddlStaff" runat="server" Height="16px" Width="154px" >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="width: 18%; height: 27px;" align="left">
                        Year <span style="font-size: 14px; color: Red">*</span>
                    </td>
                    <td style="height: 27px">
                        <asp:DropDownList ID="ddlYear" runat="server" Height="16px" Width="154px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" valign="top" style="width: 18%">
                        Report Type <span style="font-size: 14px; color: Red">*</span>
                    </td>
                    <td class="tdcls" width="20%" valign="top">
                        <span style="vertical-align: super; color: #ff0000"><span style=""></span>
                            <asp:RadioButton ID="rbtnTabularReport" runat="server" CssClass="subhead" ForeColor="Black"
                                GroupName="rburban" Text="TabularReport" />
                            <asp:RadioButton ID="rbtnGraphical" runat="server" CssClass="subhead" ForeColor="Black"
                                GroupName="rburban" Text="GraphicalReport" /></span>
                    </td>
                </tr>
                <asp:Panel ID="panel1" runat="server">
                    <tr id="trname" runat="server">
                        <td class="subhead">
                            Chart Type <span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlChartType" runat="server" Width="154px">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Column Chart</asp:ListItem>
                                <asp:ListItem Value="2">Line Chart</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td style="height: 19px; width: 18%;">
                    </td>
                    <td style="height: 19px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 18%">
                    </td>
                    <td>
                        <asp:Button ID="btnGetReport" runat="server" Text="Get Report" OnClick="btnGetReport_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 18%">
                    </td>
                    <td>
                    </td>
                </tr>
                <table align="center" class="tdcls" width="90%">
                    <tr>
                        <td class="heading" style="height: 18px">
                            TABULAR / GRAPHICAL STAFF YEARLY ATTENDANCE REPORT FORM
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <rsweb:ReportViewer ID="StaffMonthlyAttendanceReportViewer" runat="server"
                                Width="100%">
                            </rsweb:ReportViewer>
                            <%--<rsweb:ReportViewer ID="StaffMonthlyAttendanceReportViewer" Visible="false" Height="700px"
                                Width="100%" runat="server">
                            </rsweb:ReportViewer>--%>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>
                            <rsweb:ReportViewer ID="StaffYearlyAttendanceReportViewer" runat="server" Visible="false"
                                Height="700px" Width="100%">
                            </rsweb:ReportViewer>
                        </td>
                    </tr>--%>
                </table>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
