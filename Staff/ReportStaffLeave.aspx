<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportStaffLeave.aspx.cs" Inherits="Staff_ReportStaffLeave" Title="Staff Leaves Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() {
            if (document.getElementById('<%=txtFromDate.ClientID %>').value != "")
                if (!isDateFormat('<%=txtFromDate.ClientID %>', "Please Enter FromDate:Date Format Should Be DD/MM/YYYY")) return false;
            if (document.getElementById('<%=txtToDate.ClientID %>').value != "")
                if (!isDateFormat('<%=txtToDate.ClientID %>', "Please Enter ToDate:Date Format Should Be DD/MM/YYYY")) return false;
        }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%--<asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>--%>
            <div align="center">
                <table align="center" class="tdcls" align="center" width="60%">
                    <tr>
                        <td class="heading" colspan="2" style="text-align: center">
                            STAFF LEAVES REPORT
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            Staff Name
                        </td>
                        <td style="width: 39%">
                            <asp:DropDownList ID="ddlStaffName" runat="server" CssClass="txtcls" Height="19px"
                                Width="154px">
                                <asp:ListItem>select</asp:ListItem>
                                <asp:ListItem>Vani</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            Leave Type
                        </td>
                        <td style="width: 39%">
                            <asp:DropDownList ID="ddlLeaveType" runat="server" CssClass="txtcls" Height="23px"
                                Width="154px">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>qqq</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="heading" colspan="2">
                            LEAVE DURATION
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            From Date
                        </td>
                        <td class="tdcls" valign="top" nowrap style="width: 39%">
                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtcls" Width="134px"></asp:TextBox>
                            <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        runat="server" id="imgcal">--%>
                            <asp:ImageButton alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                                Width="16" runat="server" ID="imgcal" />
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                PopupButtonID="imgcal" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            To Date
                        </td>
                        <td class="tdcls" valign="top" style="width: 39%" nowrap>
                            <asp:TextBox ID="txtToDate" runat="server" CssClass="txtcls" Width="134px"></asp:TextBox>
                            <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        id="imgcal1">--%>
                            <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                                Width="16" ID="imgcal1" />
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                                PopupButtonID="imgcal1" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                </table>
                <table align="center" class="tdcls">
                    <tr>
                        <td style="text-align: center;" colspan="2">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;" colspan="2">
                            <asp:Button ID="btnGetReport" runat="server" Text="Get Report" OnClick="btnReport_Click" />
                        </td>
                    </tr>
                </table>
                <table width="90%" align="center">
                 <tr>
                        <td colspan="4" class="heading" style="height: 18px">
                            STAFF LEAVES REPORT FORM
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" >
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </div>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
