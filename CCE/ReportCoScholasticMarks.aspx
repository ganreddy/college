<%@ Page Title="CO-SCHOLASTIC Marks  Report" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportCoScholasticMarks.aspx.cs" Inherits="CCE_ReportCoScholasticMarks" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
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
                    CO-SCHOLASTIC MARKS 
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Batch
                </td>
                <td>
                    <asp:DropDownList ID="ddlBatch" runat="server" Width="154px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Class
                </td>
                <td>
                    <asp:DropDownList ID="ddlClasses" runat="server" Width="154px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Section
                </td>
                <td>
                    <asp:DropDownList ID="ddlSections" runat="server" Width="154px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    CoScholasticArea
                </td>
                <td>
                    <asp:DropDownList ID="ddlCoScholastisarea" runat="server" Width="154px" onselectedindexchanged="ddlCoScholastisarea_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td class="subhead">
                    Assesment Name <span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAssesmentName" runat="server" Width="154px">
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
        <table width="90%" align="center">
            <tr>
                <td class="heading" colspan="4" style="text-align: center">
                    CO-SCHOLASTIC MARKS REPORT 
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%">
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
