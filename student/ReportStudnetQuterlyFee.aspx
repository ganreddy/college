<%@ Page Title="Quarterly Fee Collection Report" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportStudnetQuterlyFee.aspx.cs" Inherits="student_ReportStudnetQuterlyFee" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <%--<asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>--%>
        <table align="center" class="tdcls" width="60%">
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="heading" colspan="2" style="text-align: center">
                    STUDENT QUARTERLY FEE REPORT
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
                    <asp:DropDownList ID="ddlBatch" runat="server" Width="154px" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Branch
                </td>
                <td>
                    <asp:DropDownList ID="ddlClasses" runat="server" Width="154px" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Section
                </td>
                <td>
                    <asp:DropDownList ID="ddlSections" runat="server" Width="154px" OnSelectedIndexChanged="ddlSections_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Student
                </td>
                <td>
                    <asp:DropDownList ID="ddlStudent" runat="server" Width="154px" 
                        onselectedindexchanged="ddlStudent_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td class="subhead">
                    Quarterly</td>
                <td>
                    <asp:DropDownList ID="ddlQuterList" runat="server" 
                        onselectedindexchanged="ddlStudent_SelectedIndexChanged" Width="154px">
                     <asp:ListItem Value="0">---Select---</asp:ListItem> 
                     <asp:ListItem Value="1">1st Quarter</asp:ListItem> 
                     <asp:ListItem Value="2">2nd Quarter</asp:ListItem>
                     <asp:ListItem Value="3">3ed Quarter</asp:ListItem>
                     <asp:ListItem Value="4">4th Quarter</asp:ListItem>   
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
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button Text="Get Report" ID="btnReport" runat="server" OnClick="btnReport_Click" />
                </td>
            </tr>
        </table>
         <table align="center" class="tdcls" width="90%">
            <tr>
                <td class="heading" colspan="4" style="text-align: center">
                 STUDENT QUARTERLY FEE REPORT FORM
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
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>

</asp:Content>

