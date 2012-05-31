<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportStaffSalaryPaySlip.aspx.cs" Inherits="Staff_ReportStaffSalaryPaySlip" Title="Staff Salary Report" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

   
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
 <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
     function validate()
     { 
            if(!DropdownValidate('<%=ddlMonth.ClientID%>',"Please Select Month"))return false;
            if(!DropdownValidate('<%=ddlYear.ClientID%>',"Please Select Year"))return false;
            
     }
    </script>
    
    
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
                    STAFF PAYSLIP REPORT
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Staff
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlStaff" runat="server" Width="154px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Month<span style="font-size: 14px; color: Red">*</span>
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlMonth" runat="server" Width="154px">
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
                <td class="subhead">
                    Year <span style="font-size: 14px; color: Red">*</span>
                </td>
                <td  align="center">
                    <asp:DropDownList ID="ddlYear" runat="server" Width="154px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 19px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="30">
                </td>
                <td  align="center">
                    <asp:Button Text="Get Report" ID="btnReport" runat="server" OnClick="btnReport_Click" />
                </td>
            </tr>
        </table>
        <table width="90%" align="center">
            <tr>
                <td colspan="4" class="heading" style="height: 18px">
                    STAFF PAYSLIP REPORT FORM
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

