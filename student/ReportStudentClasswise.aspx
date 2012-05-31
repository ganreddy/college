<%@ Page MasterPageFile="~/MasterPage.master" Language="C#" AutoEventWireup="true"
    CodeFile="ReportStudentClasswise.aspx.cs" Inherits="ReportStudentClasswise" Title="Student Branch Wise Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
function validate()
{
// var count=0;
// if (document.getElementById('<%=ddlBatch.ClientID%>').selectedIndex==0)
//              count=count+1;
// if(count==5)
//  alert("Please Select atleast one Option");
//  
//  if (document.getElementById('<%=ddlClasses.ClientID%>').selectedIndex==0)
//              count=count+1;
// if(count==5)
//  alert("Please Select atleast one Option");
//  
//  if (document.getElementById('<%=ddlSections.ClientID%>').selectedIndex==0)
//              count=count+1;
// 
// if(count==5)
//  alert("Please Select atleast one Option");
//  
//  if (document.getElementById('<%=ddlCaste.ClientID%>').selectedIndex==0)
//              count=count+1;
// if(count==5)
//  alert("Please Select atleast one Option");
//  
//  if (document.getElementById('<%=ddlGender.ClientID%>').selectedIndex==0)
//              count=count+1;
// if(count==5)
//  alert("Please Select atleast one Option");
  
}

    </script>

    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>--%>
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
                            STUDENT BRANCH WISE REPORT
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
                            <asp:DropDownList ID="ddlBatch" runat="server" Width="154px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Branch
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlClasses" runat="server" Width="154px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Section
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSections" runat="server" Width="154px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Caste
                        </td>
                        <td width="30">
                            <asp:DropDownList ID="ddlCaste" runat="server" Width="154px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Gender
                        </td>
                        <td width="30">
                            <asp:DropDownList ID="ddlGender" runat="server" Width="154px">
                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                <asp:ListItem Value="1">Male</asp:ListItem>
                                <asp:ListItem Value="2">Female</asp:ListItem>
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
                        <td >
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button Text="Get Report" ID="btnReport" runat="server" OnClick="btnReport_Click" />
                        </td>
                    </tr>
                </table>
                <table align="center" class="tdcls" width="90%">
                    <tr>
                        <td class="heading" colspan="4" style="text-align: center">
                            STUDENT BRANCH WISE REPORT FORM
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" >
                            </rsweb:ReportViewer>
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
