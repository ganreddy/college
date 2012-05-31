<%@ Page Title="Scholastic Wise Students Percentage Report" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportScholasticWiseStudentsPercentage.aspx.cs" Inherits="CCE_ReportScholasticWiseStudentsPercentage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() {
            if (!DropdownValidate('<%=ddlBatch.ClientID%>', "Please Select Year")) return false;
            if (!DropdownValidate('<%=ddlClass.ClientID%>', "Please Select Class")) return false;
            if (!DropdownValidate('<%=ddlExamType.ClientID%>', "Please Select Exam")) return false;
            if (!DropdownValidate('<%=ddlSubject.ClientID%>', "Please Select Subject")) return false;
            if (!DropdownValidate('<%=ddlScholastisarea.ClientID%>', "Please Select ScholasticArea")) return false;
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
          
        }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <table align="center" class="tdcls" width="60%">
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
            </td>
        </tr>
        <tr>
            <td style="width: 261px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="2" style="text-align: center">
                Scholastic Wise Students Percentage Report
            </td>
        </tr>
        
        <tr>
            <td class="subhead" style="width: 261px">
                Year <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlBatch" runat="server" Width="154px" 
                    OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged" 
                    style="margin-left: 0px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead" style="width: 261px">
                Class <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlClass" runat="server" Width="154px" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead" style="width: 261px">
                Exam Name <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlExamType" runat="server" Width="154px" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlExamType_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead" style="width: 261px">
                Subject <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubject" runat="server" Width="154px" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead" style="width: 261px">
                ScholasticArea <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlScholastisarea" runat="server" Width="154px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead" style="width: 261px">
                Report Type <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td >
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
                    </asp:DropDownList>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td style="width: 261px" >
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 261px">
            </td>
            <td>
                <asp:Button Text="Get Report" ID="btnReport" runat="server" OnClick="btnReport_Click"
                    Style="height: 26px" />
            </td>
        </tr>
    </table>
    <table width="90%" align="center" class="tdcls">
        <tr>
            <td class="heading"  style="text-align: center">
                Scholastic Wise Students Percentage Report Form
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" >
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>
