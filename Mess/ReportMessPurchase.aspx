<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportMessPurchase.aspx.cs" Inherits="Mess_ReportMessPurchase" Title="Mess Purchase Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <table align="center" class="tdcls" width="60%">
                <tr>
                    <td colspan="2" class="heading">
                        MESS PURCHASE REPORT
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="subhead" align="left">
                        Month Of Purchase
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="ddlcls" Width="155px">
                            <asp:ListItem Text="Select" Value="0">---Select---</asp:ListItem>
                            <asp:ListItem Text="Jan" Value="1">Jan</asp:ListItem>
                            <asp:ListItem Text="Feb" Value="2">Feb</asp:ListItem>
                            <asp:ListItem Text="Mar" Value="3">Mar</asp:ListItem>
                            <asp:ListItem Text="Apr" Value="4">Apr</asp:ListItem>
                            <asp:ListItem Text="May" Value="5">May</asp:ListItem>
                            <asp:ListItem Text="Jun" Value="6">jun</asp:ListItem>
                            <asp:ListItem Text="Jul" Value="7">Jul</asp:ListItem>
                            <asp:ListItem Text="Aug" Value="8">Aug</asp:ListItem>
                            <asp:ListItem Text="Sept" Value="9">Sept</asp:ListItem>
                            <asp:ListItem Text="Oct" Value="10">Oct</asp:ListItem>
                            <asp:ListItem Text="Nov" Value="11">Nov</asp:ListItem>
                            <asp:ListItem Text="Dec" Value="12">Dec</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" align="left">
                        Year Of Purchase 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="ddlcls" Width="155px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" align="left">
                        Item Name
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlItemName" runat="server" CssClass="ddlcls" Width="155px">
                        </asp:DropDownList>
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
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
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
                </table>
                <table align="center" class="tdcls" width="90%">
                    <tr>
                        <td colspan="2" class="heading" style="height: 18px">
                            MESS PURCHASE REPORT FORM
                        </td>
                    </tr>
                    </tr>
                    <tr>
                        <td>
                            <rsweb:ReportViewer ID="MessPurchaseReportViewer" runat="server" Width="100%">
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                
            </table>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
