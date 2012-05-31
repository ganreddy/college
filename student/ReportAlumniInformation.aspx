<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportAlumniInformation.aspx.cs" Inherits="student_ReportAlumniInformation" Title="Report Alumni Information" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
        <table align="center" class="tdcls" width="60%">
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="heading" colspan="4" style="text-align: center">
                   STUDENT ALUMNI REPORT
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Admission No
                </td>
                <td>
                    <asp:TextBox ID="txtAdmissionNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Year of Passing
                </td>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server" Width="154px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button Text="Get Report" ID="btnReport" runat="server" OnClick="btnReport_Click" />
                </td>
            </tr>
        </table>
        <table align="center" class="tdcls" width="90%">
            <tr>
                <td class="heading" colspan="4" style="text-align: center">
                    STUDENT ALUMNI REPORT FORM
                </td>
            </tr>
            <tr>
                <td>
                    <td colspan="2" align="center">
                    <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" >
                    </rsweb:ReportViewer>
                </td>
                </td>
            </tr>
        </table>
       <%-- <table width="90%" align="center">
            <tr>
                <td colspan="4" align="center">
                    <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" Height="700px">
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>--%>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

