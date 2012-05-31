<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentSeltionReport.aspx.cs" Inherits="student_StudentSeltionReport" Title="Student Selection Process Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
     <script type="text/javascript" language="javascript">
    function validate()
    {
      //if(! DropdownValidate('<%=ddlYear.ClientID %>',"Please Select Year")) return false;
    
      
     if(! DropdownValidate('<%=ddlYear.ClientID %>',"Please Select Year")) return false;
    
     
     
    }
    </script>
    <div>
        <table align="center" class="tdcls" width="70%">
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
                </td>
            </tr>
            <tr>
                <td style="width: 246px">
                    
                </td>
            </tr>
            <tr>
                <td class="heading" colspan="4" style="text-align: center">
                    STUDENT SELECTION REPORT
                </td>
            </tr>
            <tr>
                <td style="width: 246px">
                   
                </td>
            </tr>
            <tr>
                <td class="subhead" style="width: 246px">
                    Year<span style="font-size: 17px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server" Width="154px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead" style="width: 246px">
                    Eligible
                </td>
                <td>
                    <asp:DropDownList ID="ddlEligible" runat="server" Width="154px">
                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                    <asp:ListItem Value="1">Not Eligible</asp:ListItem>
                    <asp:ListItem Value="2">Eligible</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
             <tr>
                <td style="width: 246px">
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button Text="Get Report" ID="btnReport" runat="server" 
                        onclick="btnReport_Click"  />
                </td>
            </tr>
        </table>
       
        <table width="90%" align="center">
         <tr>
                <td class="heading" colspan="4" style="text-align: center">
                   STUDENT SELECTION REPORT FORM
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" >
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

