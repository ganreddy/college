<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportLibiraryBooks.aspx.cs" Inherits="Library_ReportLibiraryBooks" Title="Library Books Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <div>
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
                    LIBRARY BOOK REPORT
                </td>
            </tr>
           
            <tr>
                <td class="subhead">
                      Subject
                </td>
                <td>
                    <asp:DropDownList ID="ddlSubject" runat="server" Width="154px" >
                       
                       
                        
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Category                 </td>
                <td>
                    <asp:DropDownList ID="ddlCategory" runat="server" Width="154px" >
                        
                       
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Accession No
                </td>
                <td>
                    <asp:TextBox ID="txtAcessionNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Author
                </td>
                <td>
                    <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="subhead">
                    Year
                </td>
                <td width="30">
                    <asp:DropDownList ID="ddlLibYear" runat="server" Width="154px">
                        
                    </asp:DropDownList>
                </td>
            </tr>
            
            <tr>
            <td class="subhead">
            Language
            </td>
            <td width="30">
                    <asp:DropDownList ID="ddlLanguage" runat="server" Width="154px">
                        
                    </asp:DropDownList>
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
                             BOOK DETAILS REPORT FORM
                        </td>
                    </tr>
            <tr>
                <td colspan="4" align="center">
                    <rsweb:ReportViewer runat="server" ID="MessPurchaseReportViewer" Width="100%" >
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

