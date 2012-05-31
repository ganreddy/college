<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportScholasticMarks.aspx.cs" Inherits="CCE_ReportScholasticMarks"
    Title="Report Scholastic Marks" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function validation()
    {
        if(!DropdownValidate('<%=ddlSubject.ClientID%>',"Please Select Subject"))return false;
        if(!DropdownValidate('<%=ddlExamType.ClientID%>',"Please Select Exam Type"))return false;
        if(!DropdownValidate('<%=ddlBatch.ClientID%>',"Please Select Batch"))return false;
        if(!DropdownValidate('<%=ddlClass.ClientID%>',"Please Select Class"))return false;
        if(!DropdownValidate('<%=ddlSection.ClientID%>',"Please Select Section"))return false;
        }
    </script>
    
    
   
    <table align="center" class="tdcls" width="60%">
        <tr>
            <td colspan="2" class="heading">
                Scholastic Marks Report
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <%--<tr>
                <td class="subhead">
                    Year<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server" Width="154px" 
                        >
                    </asp:DropDownList>
                </td>
            </tr>--%>
        <tr>
            <td class="subhead">
                Subject<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubject" runat="server" Width="154px" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Exam Type<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlExamType" runat="server" Width="154px" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Batch<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlBatch" runat="server" Width="154px" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Class<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlClass" runat="server" Width="154px" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Section <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlSection" runat="server" Width="154px" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Table ID="tb" runat="server" BorderWidth="1">
                </asp:Table>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 15px;" colspan="2">
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Get Report" Width="80px" 
                    onclick="btnAdd_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="90%" align="center">
    <tr>
                        <td class="heading" colspan="4" style="text-align: center">
                            Scholastic Marks Report Form
                        </td>
                    </tr>
        <tr>
            <td colspan="4" align="center">
                <rsweb:reportviewer runat="server" id="MyReportViewer" width="100%" >
                    </rsweb:reportviewer>
            </td>
        </tr>
    </table>
   
</asp:Content>
