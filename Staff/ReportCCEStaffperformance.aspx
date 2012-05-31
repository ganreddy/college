<%@ Page Title="Staff Performance Report" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportCCEStaffperformance.aspx.cs" Inherits="Staff_ReportCCEStaffperformance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() {
            var Tabular = document.getElementById('<%=rbtnTabularReport.ClientID%>').checked;
            var Graphical = document.getElementById('<%=rbtnGraphical.ClientID%>').checked;
            if ((Tabular == false) && (Graphical == false)) {
                alert("Please Select Radio Button (Either Tabular Or Graphical)");
                return false;
            }
            if (document.getElementById('<%=rbtnGraphical.ClientID%>').checked ) {
                if (!DropdownValidate('<%=ddlChartType.ClientID%>', "Please Select Chart Type")) return false;
            }
            if (document.getElementById('<%=rbtnGraphical.ClientID%>').checked || document.getElementById('<%=rbtnTabularReport.ClientID%>').checked) {
                if (!DropdownValidate('<%=ddlStaff.ClientID%>', "Please Select Staff")) return false;
                if (!DropdownValidate('<%=ddlExam.ClientID%>', "Please Select Exam")) return false;
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

        }
    </script>

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
                    STAFF PERFORMANCE REPORT
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="subhead" align="left">
                    Batch <span style="font-size: 11px; color: Red">*</span>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlBatch" runat="server" 
                        Width="155px" Height="16%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead" align="left">
                    Class <span style="font-size: 11px; color: Red">*</span>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlClasses" runat="server" 
                        Width="155px" Height="16%">
                    </asp:DropDownList>
                </td>
            </tr>
          
            <tr>
                <td class="subhead" align="left">
                    Exam
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlExam" runat="server" 
                        Width="155px" Height="16%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead" align="left">
                   Subject
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlSubject" runat="server" 
                        Width="155px" Height="16%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead" align="left">
                    Staff
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlStaff" runat="server" 
                        Width="155px" Height="16%">
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                        <td class="subhead" style="width: 243px">
                            Report Type <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td class="tdcls">
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
                                Chart Type <span style="font-size: 10px; color: Red">*</span>
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
                <td width="30">
                </td>
                <td width="30">
                    <asp:Button Text="Get Report" ID="btnReport" runat="server" OnClick="btnReport_Click" />
                </td>
            </tr>
        </table>
        <table width="90%" align="center">
            <tr>
                <td colspan="4" align="center">
                    <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" Height="700px">
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
