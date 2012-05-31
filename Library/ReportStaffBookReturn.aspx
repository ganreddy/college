<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportStaffBookReturn.aspx.cs" Inherits="student_ReportStaffBookReturn"
    Title="Staff Book Return Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/jscript" language="javascript">
    function RequiredValidate()
    {
     
     if(! isDateFormat('<%=txtReturnFromDate.ClientID%>',"pls enter dd/mm/yyyy format of ReturnFromDate"))return false;
     if(! isDateFormat('<%=txtReturnToDate.ClientID%>',"pls enter dd/mm/yyyy format of ReturnToDate"))return false;
     if(! isDateFormat('<%=txtPaymentFromDate.ClientID%>',"pls enter dd/mm/yyyy format of PaymentFromDate"))return false;
     if(! isDateFormat('<%=txtPaymentToDate.ClientID%>',"pls enter dd/mm/yyyy format of PaymentToDate"))return false;
    }
    
    </script>
    
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <table align="center" class="tdcls" width="60%">
        <tr>
            <td colspan="2" class="heading">
                STAFF BOOK RETURN REPORT
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        
        <tr>
            <td class="subhead" style="width: 39%; height: 27px;" align="left">
                Staff 
            </td>
            <td style="height: 27px">
                <asp:DropDownList ID="ddlStaff" runat="server" Height="160px" Width="154px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 39%" class="subhead" align="left">
                Return From Date 
            </td>
            <td style="height: 25px">
                <asp:TextBox ID="txtReturnFromDate" runat="server"></asp:TextBox>
                <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="imgcal"
                    style="margin-top: 0px">--%>
                    <asp:ImageButton runat="server" alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="imgcal"
                    style="margin-top: 0px"/>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtReturnFromDate"
                    PopupButtonID="imgcal" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 39%" class="subhead" align="left">
                Return TO Date 
            </td>
            <td style="height: 25px">
                <asp:TextBox ID="txtReturnToDate" runat="server"></asp:TextBox>
                <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="img1" style="margin-top: 0px">--%>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="img1" style="margin-top: 0px"/>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img1"
                    TargetControlID="txtReturnToDate" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 39%" class="subhead" align="left">
                Payment From Date 
            </td>
            <td style="height: 25px">
                <asp:TextBox ID="txtPaymentFromDate" runat="server"></asp:TextBox>
                <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="img2" style="margin-top: 0px">--%>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="img2" style="margin-top: 0px"/>
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="img2"
                    TargetControlID="txtPaymentFromDate" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 39%" class="subhead" align="left">
                Payment To Date 
            </td>
            <td style="height: 25px">
                <asp:TextBox ID="txtPaymentToDate" runat="server"></asp:TextBox>
                <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="img3" style="margin-top: 0px">--%>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="img3" style="margin-top: 0px"/>
                <asp:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="img3"
                    TargetControlID="txtPaymentToDate" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td style="height: 19px">
            </td>
            <td style="height: 19px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnGetReport" runat="server" Text="GetReport" OnClick="btnGetReport_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <table align="center" class="tdcls" width="90%">
            <tr>
                <td colspan="2" class="heading" style="height: 18px">
                   STAFF BOOK RETURN REPORT FORM
                </td>
            </tr>
            </tr>
            <tr>
                <td>
                    <rsweb:ReportViewer ID="StaffBookReturnReportViewer" runat="server"
                        Width="100%">
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
</asp:Content>
