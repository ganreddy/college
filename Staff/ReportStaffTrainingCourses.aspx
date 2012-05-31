<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportStaffTrainingCourses.aspx.cs" Inherits="Staff_ReportStaffTrainingCourses"
    Title=" Staff Training Courses Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() {
            if (document.getElementById('<%=txtFromDate.ClientID %>').value != "")
                if (!isDateFormat('<%=txtFromDate.ClientID %>', "Please Enter From Date In The Format Of DD/MM/YYYY")) return false;
            if (document.getElementById('<%=txtToDate.ClientID %>').value != "")
                if (!isDateFormat('<%=txtToDate.ClientID %>', "Please Enter To Date In The Format Of DD/MM/YYYY")) return false;
        }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%--<asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>--%>
            <table align="center" class="tdcls" width="60%">
                <tr>
                    <td colspan="2" class="heading">
                        STAFF TRAINING COURSES REPORT
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="width: 39%; height: 27px;" align="left">
                        Staff 
                    </td>
                    <td style="height: 27px">
                        <asp:DropDownList ID="ddlStaff" runat="server" Height="16px" Width="154px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="subhead">
                        Course Name 
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 39%" class="subhead" align="left">
                        FromDate 
                    </td>
                    <td style="height: 25px">
                        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                        <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="imgcal"
                            style="margin-top: 0px">--%>
                        <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                            ID="imgcal" Style="margin-top: 0px" />
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                            PopupButtonID="imgcal" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 39%" class="subhead" align="left">
                        ToDate 
                    </td>
                    <td style="height: 25px">
                        <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                        <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="img1" style="margin-top: 0px">--%>
                        <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                            ID="img1" Style="margin-top: 0px" />
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img1"
                            TargetControlID="txtToDate" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
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
                        <asp:Button ID="btnGetReport" runat="server" Text="GetReport" OnClick="btnGetReport_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <table align="center" class="tdcls" width="90%">
                    <tr>
                        <td colspan="2" class="heading" style="height: 18px">
                            STAFF TRAINING COURSES REPORT FORM
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
            </table>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
