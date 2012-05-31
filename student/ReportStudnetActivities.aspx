<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportStudnetActivities.aspx.cs" Inherits="student_ReportStudnetActivities"
    Title="Student Activities Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validation() {
            if (!DropdownValidate('<%=ddlMonth.ClientID%>', "Please Select Month")) return false;
            if (!DropdownValidate('<%=ddlclub.ClientID%>', "Please Select Club Name")) return false;
            
            if (!DropdownValidate('<%=ddlactivtytype.ClientID%>', "Please Select Activity Type")) return false;
            if (!DropdownValidate('<%=ddlprize.ClientID%>', "Please Select Prize")) return false;
        }
    </script>

    <asp:ToolkitScriptManager ID="toolkit" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <table align="center" class="tdcls" width="90%">
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
                    STUDENT
                    ACTIVITIES REPORT
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Month<span style="font-size: 17px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMonth" runat="server" Width="154px" Height="16%">
                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                        <asp:ListItem Value="1">Jan</asp:ListItem>
                        <asp:ListItem Value="2">Feb</asp:ListItem>
                        <asp:ListItem Value="3">Mar</asp:ListItem>
                        <asp:ListItem Value="4">Apr</asp:ListItem>
                        <asp:ListItem Value="5">May</asp:ListItem>
                        <asp:ListItem Value="6">June</asp:ListItem>
                        <asp:ListItem Value="7">July</asp:ListItem>
                        <asp:ListItem Value="8">Aug</asp:ListItem>
                        <asp:ListItem Value="9">Sep</asp:ListItem>
                        <asp:ListItem Value="10">Oct</asp:ListItem>
                        <asp:ListItem Value="11">Nov</asp:ListItem>
                        <asp:ListItem Value="12">Dec</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Club Name<span style="font-size: 17px; color: Red">*</span></td>
                <td>
                    <asp:DropDownList ID="ddlclub" runat="server" Width="154px" 
                        Height="16%">
                        
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Activity Type <span style="font-size: 17px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlactivtytype" runat="server" Width="154px" Height="16%">
                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                        <asp:ListItem Value="1">Individual</asp:ListItem>
                        <asp:ListItem Value="2">Group</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Prize<span style="font-size: 17px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlprize" runat="server" Width="154px" Height="16%">
                        <asp:ListItem Value="-1">---Select---</asp:ListItem>
                        <asp:ListItem Value="0">ALL</asp:ListItem>
                        <asp:ListItem Value="1">I</asp:ListItem>
                        <asp:ListItem Value="2">II</asp:ListItem>
                        <asp:ListItem Value="3">III</asp:ListItem>
                        <asp:ListItem Value="4">IV</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <center>
                        <asp:Button ID="btnReport" runat="server" Text="Get Report" OnClick="btnReport_Click" /></center>
                </td>
            </tr>
        </table>
        <table align="center" class="tdcls" width="90%">
            <tr>
                <td class="heading" colspan="4" style="text-align: center">
                    STUDENT
                    ACTIVITIES REPORT FORM
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <rsweb:ReportViewer ID="StudntActivityReport" runat="server" Width="100%">
                    </rsweb:ReportViewer>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>
