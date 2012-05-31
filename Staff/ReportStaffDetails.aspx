<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportStaffDetails.aspx.cs" Inherits="Staff_ReportStaffDetails" Title="Staff Details Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                            STAFF DETAILS REPORT
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Staff
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStaffId" runat="server" Width="154px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Gender
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGender" runat="server" Width="154px">
                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                <asp:ListItem Value="1">Male</asp:ListItem>
                                <asp:ListItem Value="2">Female</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Teaching/NonTeaching
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTeachingandNonTeaching" runat="server" Width="154px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Mode Of Appointment
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlModeOfAppointment" runat="server" Width="154px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Type Of Post
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTypeOfPost" runat="server" Width="154px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Cader
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCader" runat="server" Width="154px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
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
                        <td class="heading" style="height: 18px">
                            STAFF DETAILS REPORT FORM
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <rsweb:ReportViewer ID="StaffTrainingReportViewer" runat="server"
                                Width="100%">
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
           <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
</asp:Content>
