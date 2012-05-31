<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportCCENormal.aspx.cs" Inherits="CCE_ReportCCENormal" Title="General CCE REPORT" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
   
        <ContentTemplate>
            <div>
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
                            General CCE REPORT
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
                            <asp:DropDownList ID="ddlBatch" runat="server" Width="154px" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged">
                            </asp:DropDownList>
                            <%--<asp:DropDownList ID="ddlBatch" runat="server" Width="154px">
                    </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Class
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlClass" runat="server" Width="154px" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged">
                            </asp:DropDownList>
                            <%-- <asp:DropDownList ID="ddlClasses" runat="server" Width="154px">
                    </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Section
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSection" runat="server" Width="154px" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlSections_SelectedIndexChanged">
                            </asp:DropDownList>
                            <%--<asp:DropDownList ID="ddlSections" runat="server" Width="154px">
                    </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Student
                        </td>
                        <td width="30">
                            <asp:DropDownList ID="ddlStudID" runat="server" Width="154px" AutoPostBack="true">
                            </asp:DropDownList>
                            <%--<asp:DropDownList ID="ddlStudID" runat="server" Width="154px">
                    </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="30">
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
                           ExamWise Student Marks Percentage Count Report Form
                        </td>
                    </tr>
                    <tr>
                    <asp:Label ID="lblMessage" runat="server" Visible="false">
                    </asp:Label>
                    </tr>
                    <tr>
                        <td align="center">
                            <rsweb:ReportViewer ID="MyReportViewer" runat="server" Width="100%">
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    
</asp:Content>
