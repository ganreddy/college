<%@ Page Title=" CashBook Report" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportCashBook.aspx.cs" Inherits="Accounts_ReportCashBook" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

<script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() 
        {
            if (document.getElementById('<%=txtFromDate.ClientID%>').value != "")
                if (!isDateFormat('<%=txtFromDate.ClientID%>', "Please Enter valid From Date")) return false;
                if (document.getElementById('<%=txtToDate.ClientID%>').value != "") {
                    if (!isDateFormat('<%=txtToDate.ClientID%>', "Please Enter valid To Date")) return false;
                    if (!DateFormat12('<%=txtFromDate.ClientID%>', '<%=txtToDate.ClientID%>', "To Date Cannot Be Less Than From Date")) return false;
                }
                    
        }
    </script>

<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    
        <ContentTemplate>
            <table align="center" class="tdcls" width="60%">
                <tr>
                    <td colspan="2" class="heading">
                        CASH &nbsp;BOOK &nbsp;REPORT
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="width: 39%; height: 27px;" align="left">
                        Transaction Type 
                    </td>
                    <td style="height: 27px">
                        <asp:DropDownList ID="ddlTransaction" runat="server" Height="16px" Width="154px" AutoPostBack="true">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">Reciept</asp:ListItem>
                        <asp:ListItem Value="2">Payment</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="subhead" style="width: 39%">
                        Planned / Non-Planned
                    </td>
                    <td align="left">
                        <%--<asp:TextBox ID="txtWorkPlace" runat="server"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddlPlanNon" runat="server" Height="16px" Width="154px" >
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Planned</asp:ListItem>
                            <asp:ListItem Value="2">Non-Planned</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 39%" class="subhead" align="left">
                        From Date 
                    </td>
                    <td style="height: 25px">
                        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                        <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="imgcal"
                            style="margin-top: 0px">--%>
                        <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                            ID="imgcal" Style="margin-top: 0px" />
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                            PopupButtonID="imgcal" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 39%" class="subhead" align="left">
                        To Date 
                    </td>
                    <td style="height: 25px">
                        <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                        <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="img1" style="margin-top: 0px">--%>
                        <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                            ID="img1" Style="margin-top: 0px" />
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img1"
                            TargetControlID="txtToDate" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                </tr>
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
                        <asp:Button ID="btnGetReport" runat="server" Text="Get Report" OnClick="btnGetReport_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 39%">
                    </td>
                    <td>
                    </td>
                </tr>
                <table align="center" class="tdcls" width="90%">
                    <tr>
                        <td colspan="2" class="heading" style="height: 18px">
                            CASH BOOK REPORT FORM
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <rsweb:ReportViewer ID="cashBookReportViewer" runat="server"
                                Width="100%">
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </table>
        </ContentTemplate>
    
</asp:Content>

