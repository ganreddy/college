<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportStudentProductIssue.aspx.cs" Inherits="Stores_ReportStudentProductIssue"
    Title="Report StudentProduct Issue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() {
            if (document.getElementById('<%=txtFromDate.ClientID%>').value != "") {
                if (!isDateFormat('<%=txtFromDate.ClientID %>', "Please Enter  FromDate:Date Format Should Be DD/MM/YYYY")) return false;
            }
            if (document.getElementById('<%=txtToDate.ClientID%>').value != "") {
                if (!isDateFormat('<%=txtToDate.ClientID %>', "Please Enter  ToDate:Date Format Should Be DD/MM/YYYY")) return false;
            }


        }
    </script>

    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
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
                            STUDENT PRODUCT ISSUE REPORT
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
                            <asp:DropDownList ID="ddlBatch" runat="server" Width="154px" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Branch
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlClasses" runat="server" Width="154px" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Section
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSections" runat="server" Width="154px" OnSelectedIndexChanged="ddlSections_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Student
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStudent" runat="server" Width="154px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            From Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                            <%--<img id="Img1" border="0" height="16" src="../images/cal.gif" width="16">--%>
                            <asp:ImageButton runat="server" ID="Img1" border="0" Height="16" src="../images/cal.gif"
                                Width="16" />
                            <asp:CalendarExtender ID="CalendarExtender10" runat="server" PopupButtonID="Img1"
                                TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            To Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                            <%--<img id="Img2" border="0" height="16" src="../images/cal.gif" width="16">--%>
                            <asp:ImageButton runat="server" ID="Img2" border="0" Height="16" src="../images/cal.gif"
                                Width="16" />
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Img2"
                                TargetControlID="txtToDate" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
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
                <table width="90%" align="center">
                    <tr>
                        <td colspan="2" class="heading" style="height: 18px">
                            STUDENT PRODUCT ISSUE REPORT FORM
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" >
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
                </div>
           <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
</asp:Content>
