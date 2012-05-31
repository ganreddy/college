<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="GraphicalStudentYearlyclasswiseAttendenceReport.aspx.cs" Inherits="student_GraphicalStudentYearlyAttendenceReport"
    Title="Graphical Student Yearly Class Wise Attendance Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validation() {

            if (!DropdownValidate('<%=ddlYear.ClientID%>', "Please Select Year")) return false;
            var Tabular = document.getElementById('<%=rbtnTabularReport.ClientID%>').checked;
            var Graphical = document.getElementById('<%=rbtnGraphical.ClientID%>').checked;
            if ((Tabular == false) && (Graphical == false)) {
                alert("Please Select  Radio Button (Either Tabular or Graphical)");
                return false;
            }
            if (document.getElementById('<%=rbtnGraphical.ClientID%>').checked) {
                if (!DropdownValidate('<%=ddlChartType.ClientID%>', "Please Select Chart Type")) return false;
            }

        }
        function window.onload() {
            Display();
        }
        function Display() {
            if (document.getElementById('<%=rbtnTabularReport.ClientID%>').checked) {
                document.getElementById('<%=trname.ClientID%>').style.display = "none";

            }
            if (document.getElementById('<%=rbtnGraphical.ClientID%>').checked) {
                document.getElementById('<%=trname.ClientID%>').style.display = "inline";

            }
            //return;
        }
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updStdAttendance">
        <ContentTemplate>
            <div>
                <table align="center" class="tdcls" width="60%">
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 14%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="heading" colspan="2" style="text-align: center">
                            TABULAR/GRAPHICAL STUDENT CLASSWISE YEARLY ATTENDENCE 
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 14%">
                            Year <span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td style="height: 27px">
                            <asp:DropDownList ID="ddlYear" runat="server" Height="16px" Width="154px" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 14%">
                            Class
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlClasses" runat="server" Width="154px" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="subhead" style="width: 14%">
                            Report Type <span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td class="tdcls" width="20%" valign="top">
                            <span style="vertical-align: super; color: #ff0000"><span style=""></span>
                                <asp:RadioButton ID="rbtnTabularReport" runat="server" CssClass="subhead" ForeColor="Black"
                                    GroupName="rburban" Text="TabularReport" />
                                <asp:RadioButton ID="rbtnGraphical" runat="server" CssClass="subhead" ForeColor="Black"
                                    GroupName="rburban" Text="GraphicalReport" /></span>
                        </td>
                    </tr>
                    <asp:Panel ID="panel1" runat="server">
                        <tr id="trname" runat="server">
                            <td class="subhead">
                                Chart Type <span style="font-size: 14px; color: Red">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlChartType" runat="server" Width="154px">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="1">Column Chart</asp:ListItem>
                                    <asp:ListItem Value="2">Line Chart</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </asp:Panel>
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
                        <td class="heading" colspan="4" style="text-align: center">
                            TABULAR/GRAPHICAL STUDENT CLASSWISE YEARLY ATTENDENCE REPORT FORM</td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <rsweb:ReportViewer ID="ReportStuYearlyAttendence" runat="server" 
                                Width="100%">
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
