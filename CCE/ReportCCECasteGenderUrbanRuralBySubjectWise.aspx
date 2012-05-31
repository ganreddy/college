<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportCCECasteGenderUrbanRuralBySubjectWise.aspx.cs" Inherits="CCE_ReportCCECasteGenderUrbanRuralBySubjectWise"
    Title="Student Gender/Caste/UrbanRural REPORT" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
     <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    function validate()
    {
    if(! DropdownValidate('<%=ddlBatch.ClientID%>',"Please Select Year"))return false; 
    if(! DropdownValidate('<%=ddlExamID.ClientID%>',"Please Select Exam"))return false;  
    }
    </script>
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
                            SUBJECT WISE STUDENT CATEGORY REPORT
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                     <tr>
                        <td class="subhead">
                            Year<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBatch" runat="server" Width="154px" >
                            </asp:DropDownList>
                            <%--<asp:DropDownList ID="ddlBatch" runat="server" Width="154px">
                    </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Exam Name<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td width="30">
                            <asp:DropDownList ID="ddlExamID" runat="server" Width="154px" AutoPostBack="true">
                            </asp:DropDownList>
                            <%--<asp:DropDownList ID="ddlStudID" runat="server" Width="154px">
                    </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Subject
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubject" runat="server" Width="154px">
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
                            <asp:Button Text="Get Report" ID="btnReport" runat="server" OnClick="btnReport_Click" />
                        </td>
                    </tr>
                </table>
                <table width="90%" align="center">
                <tr>
                        <td colspan="4" class="heading" style="height: 18px">
                          SUBJECT WISE STUDENT CATEGORY REPORT FORM
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
