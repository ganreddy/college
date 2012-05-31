<%@ Page Title="Yearly Dish Calculation Report" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="GraphicalYearlyMessItemCalculationReport.aspx.cs" Inherits="Mess_GraphicalYearlyMessItemCalculationReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() {
            if (!DropdownValidate('<%=ddlYear.ClientID%>', "Please Select Year")) return false;
            var Tabular = document.getElementById('<%=rbtnTabularReport.ClientID%>').checked;
            var Graphical = document.getElementById('<%=rbtnGraphical.ClientID%>').checked;
            if ((Tabular == false) && (Graphical == false)) {
                alert("Please Select  Radio Button (Either Tabular Or Graphical)");
                return false;
            }
            if (document.getElementById('<%=rbtnGraphical.ClientID%>').checked) {
                if (!DropdownValidate('<%=ddlChartType.ClientID%>', "Please Select Chart Type")) return false;
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
            //return;
        }
    
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <table align="center" class="tdcls" width="60%">
        <tr>
            <td colspan="2" class="heading">
                TABULAR/GRAPHICAL YEARLY DISH CALCULATION REPORT
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Dish Name
            </td>
            <td>
                <asp:DropDownList ID="ddlDishId" runat="server" Width="154px">
                </asp:DropDownList>
            </td>
        </tr>
        <%--<tr>
            <td class="subhead" style="width: 39%; height: 27px;" align="left">
                Month
            </td>
            <td style="height: 27px">
                <asp:DropDownList ID="ddlMonth" runat="server" Height="16px" Width="154px" AutoPostBack="true">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Jan</asp:ListItem>
                    <asp:ListItem Value="2">Feb</asp:ListItem>
                    <asp:ListItem Value="3">Mar</asp:ListItem>
                    <asp:ListItem Value="4">Apr</asp:ListItem>
                    <asp:ListItem Value="5">May</asp:ListItem>
                    <asp:ListItem Value="6">June</asp:ListItem>
                    <asp:ListItem Value="7">July</asp:ListItem>
                    <asp:ListItem Value="8">Aug</asp:ListItem>
                    <asp:ListItem Value="9">Sep</asp:ListItem>
                    <asp:ListItem Value="10">Oct</asp:ListItem>
                    <asp:ListItem Value="11">Nov</asp:ListItem>
                    <asp:ListItem Value="12">Dec</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>--%>
        <tr>
            <td class="subhead" style="width: 39%; height: 27px;" align="left">
                Year <span style="font-size: 14px; color: Red">*</span>
            </td>
            <td style="height: 27px">
                <asp:DropDownList ID="ddlYear" runat="server" Height="16px" Width="154px" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead" width="30%" valign="top">
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
                    </asp:DropDownList>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td style="height: 19px; width: 39%;">
            </td>
            <td style="height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 39%">
            </td>
            <td>
                <asp:Button ID="btnGetReport" runat="server" Text="GetReport" OnClick="btnGetReport_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 39%">
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table align="center" class="tdcls" width="90%">
        <tr>
            <td colspan="2" class="heading" style="height: 18px">
                TABULAR/GRAPHICAL YEARLY DISH CALCULATION REPORT FORM
            </td>
        </tr>
        <tr>
            <td>
                <%--<rsweb:ReportViewer ID="StaffPrevPostingsReportViewer" runat="server" Height="700px" Width="100%">
                            </rsweb:ReportViewer>--%>
                <rsweb:ReportViewer ID="MonthlyMessItemCalculation" runat="server" Visible="false"
                     Width="100%">
                </rsweb:ReportViewer>
            </td>
        </tr>
        <tr>
            <td>
                <rsweb:ReportViewer ID="YearlyMessItemCalculation" runat="server" Visible="false"
                     Width="100%">
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
