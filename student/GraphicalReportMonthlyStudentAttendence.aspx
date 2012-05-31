<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="GraphicalReportMonthlyStudentAttendence.aspx.cs" Inherits="student_GraphicalStudentYearlyAttendenceReport"
    Title="Student Monthly Attendence Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validation() {
//            if (!DropdownValidate('<%=ddlBatch.ClientID%>', "Please Select Batch")) return false;
//            if (!DropdownValidate('<%=ddlClasses.ClientID%>', "Please Select Class")) return false;
//            if (!DropdownValidate('<%=ddlSections.ClientID%>', "Please Select Section")) return false;
//            if (!DropdownValidate('<%=ddlStudID.ClientID%>', "Please Select Student")) return false;
           // if (!DropdownValidate('<%=ddlYear.ClientID%>', "Please Select Year")) return false;
            var Tabular = document.getElementById('<%=rbtnTabularReport.ClientID%>').checked;
            var Graphical = document.getElementById('<%=rbtnGraphical.ClientID%>').checked;
            if ((Tabular == false) && (Graphical == false)) {
                alert("Please Select Radio Button (Either Tabular or Graphical)");
                return false;
            }
            if (document.getElementById('<%=rbtnTabularReport.ClientID%>').checked) {
                if (!DropdownValidate('<%=ddlMonth.ClientID%>', "Please Select Month")) return false;
                if (!DropdownValidate('<%=ddlYear.ClientID%>', "Please Select Year")) return false;
            }
            if (document.getElementById('<%=rbtnGraphical.ClientID%>').checked) {
                if (!DropdownValidate('<%=ddlChartType.ClientID%>', "Please Select Chart Type")) return false;
                }
                if (document.getElementById('<%=rbtnGraphical.ClientID%>').checked) {
                    if (document.getElementById('<%=ddlChartType.ClientID%>').selectedIndex == 1 || document.getElementById('<%=ddlChartType.ClientID%>').selectedIndex == 2) {
                        if (!DropdownValidate('<%=ddlBatch.ClientID%>', "Please Select Batch")) return false;
                        if (!DropdownValidate('<%=ddlClasses.ClientID%>', "Please Select Class")) return false;
                        if (!DropdownValidate('<%=ddlSections.ClientID%>', "Please Select Section")) return false;
                        if (!DropdownValidate('<%=ddlStudID.ClientID%>', "Please Select Student")) return false;
                        if (!DropdownValidate('<%=ddlYear.ClientID%>', "Please Select Year")) return false;
                    }
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
   <%-- <asp:UpdatePanel runat="server" ID="updStdAttendance">
        <ContentTemplate>--%>
            <div>
                <table align="center" class="tdcls" width="60%">
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 14%" >
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="heading" colspan="2" style="text-align: center">
                            TABULAR/GRAPHICAL STUDENT MONTHLY ATTENDENCE 
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="subhead" style="width: 14%">
                            Batch<span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBatch" runat="server" Width="154px" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            <%--<asp:DropDownList ID="ddlBatch" runat="server" Width="154px">
                    </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 14%">
                            Branch<span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlClasses" runat="server" Width="154px" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            <%-- <asp:DropDownList ID="ddlClasses" runat="server" Width="154px">
                    </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 14%">
                            Section<span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSections" runat="server" Width="154px" OnSelectedIndexChanged="ddlSections_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            <%--<asp:DropDownList ID="ddlSections" runat="server" Width="154px">
                    </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 14%">
                            Student<span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td >
                            <asp:DropDownList ID="ddlStudID" runat="server" Width="154px" OnSelectedIndexChanged="ddlStudID_SelectedIndexChanged"
                            
                                AutoPostBack="true">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:DropDownList ID="ddlStudID" runat="server" Width="154px">
                    </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 14%; height: 27px;" align="left">
                            Month 
                        </td>
                        <td >
                            <asp:DropDownList ID="ddlMonth" runat="server" Height="16px" Width="154px">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
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
                        <td class="subhead" style="width: 14%">
                            Year <span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td >
                            <asp:DropDownList ID="ddlYear" runat="server" Height="16px" Width="154px" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 14%">
                            Report Type <span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td class="tdcls" width="20%">
                            <span style="vertical-align: super; color: #ff0000"><span style=""></span>
                                <asp:RadioButton ID="rbtnTabularReport" runat="server" CssClass="subhead" ForeColor="Black"
                                    GroupName="rburban" Text="Tabular Report" />
                                <asp:RadioButton ID="rbtnGraphical" runat="server" CssClass="subhead" ForeColor="Black"
                                    GroupName="rburban" Text="Graphical Report" /></span>
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
                            <td style="width: 14%"></td>
                            <td width="30" align="center">
                            <asp:Button Text="Get Report" ID="btnReport" runat="server" OnClick="btnReport_Click" />
                        </td>
                    </tr>
                </table>
                <table width="90%"  align="center">
                    <tr>
                        <td class="heading" style="text-align: center">
                            TABULAR/GRAPHICAL STUDENT MONTHLY ATTENDENCE REPORT FORM
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <rsweb:ReportViewer ID="ReportStuYearlyAttendence" runat="server" 
                                Width="100%">
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </div>
      <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
