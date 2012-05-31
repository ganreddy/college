<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportStaffBookIssue.aspx.cs" Inherits="Library_ReportStaffBookIssue" Title="Staff Book Issue Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
 
  <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/jscript" language="javascript">
    function RequiredValidate()
    {
     
     if(! isDateFormat('<%=txtIssueFromDate.ClientID%>',"pls enter dd/mm/yyyy format of IssueFromDate"))return false;
     if(! isDateFormat('<%=txtIssueToDate.ClientID%>',"pls enter dd/mm/yyyy format of IssueToDate"))return false;
     if(! isDateFormat('<%=txtDueFromDate.ClientID%>',"pls enter dd/mm/yyyy format of DueFromDate"))return false;
     if(! isDateFormat('<%=txtDueToDate.ClientID%>',"pls enter dd/mm/yyyy format of DueToDate"))return false;
    }
    
    </script>

    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <table align="center" class="tdcls" width="60%">
            <tr>
                <td class="heading" colspan="4" style="text-align: center">
                    STAFF BOOK ISSUE REPORT
                </td>
            </tr>
            <tr>
                <td style="width: 99px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="subhead" style="width: 99px">
                    Staff
                </td>
                <td>
                    <asp:DropDownList ID="ddlStaff" runat="server" Width="154px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead" style="width: 99px">
                    Issue From Date
                </td>
                <td>
                    <asp:TextBox ID="txtIssueFromDate" runat="server"></asp:TextBox>
                    <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        style="height: 16px" runat="server" id="imgcal">--%>
                        <asp:ImageButton alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        style="height: 16px" runat="server" id="imgcal" />
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtIssueFromDate"
                        PopupButtonID="imgcal" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="subhead" style="width: 99px">
                    Issue To Date
                </td>
                <td>
                    <asp:TextBox ID="txtIssueToDate" runat="server"></asp:TextBox>
                    <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        style="height: 16px" runat="server" id="img1">--%>
                        <asp:ImageButton alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        style="height: 16px" runat="server" id="img1"/>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtIssueToDate"
                        PopupButtonID="img1" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
             <tr>
                <td class="subhead" style="width: 99px">
                    Due From Date
                </td>
                <td>
                    <asp:TextBox ID="txtDueFromDate" runat="server"></asp:TextBox>
                    <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        style="height: 16px" runat="server" id="img2">--%>
                        <asp:ImageButton alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        style="height: 16px" runat="server" id="img2"/>
                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDueFromDate"
                        PopupButtonID="img2" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
             <tr>
                <td class="subhead" style="width: 99px">
                    Due To Date
                </td>
                <td>
                    <asp:TextBox ID="txtDueToDate" runat="server"></asp:TextBox>
                    <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        style="height: 16px" runat="server" id="img3">--%>
                        <asp:ImageButton alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        style="height: 16px" runat="server" id="img3"/>
                    <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDueToDate"
                        PopupButtonID="img3" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 99px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 99px">
                </td>
                <td width="30">
                    <asp:Button Text="Get Report" ID="btnReport" runat="server" 
                        onclick="btnReport_Click" />
                </td>
            </tr>
        </table>
         <table width="90%" align="center">
         <tr>
                        <td colspan="4" class="heading" style="height: 18px">
                            STAFF BOOK ISSUE REPORT FORM
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

</asp:Content>

