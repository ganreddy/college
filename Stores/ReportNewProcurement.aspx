<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportNewProcurement.aspx.cs" Inherits="Stores_ReportNewProcurement"
    Title="Report New Procument" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    function validate() {

        
//      if (!isEmpty('<%= txtSupplyFromDate.ClientID%>', "Please Enter Expected Delivery From Date")) return false;
//      if (!isEmpty('<%= txtSupplyToDate.ClientID%>', "Please Enter Expected Delivery To Date")) return false;
     if(document.getElementById('<%=txtSupplyFromDate.ClientID%>').value!="")
     {
         if(! isDateFormat('<%=txtSupplyFromDate.ClientID %>',"Please Enter Supply From Date:Date Format Should Be DD/MM/YYYY")) return false;
     }
      if(document.getElementById('<%=txtSupplyToDate.ClientID%>').value!="")
     {
         if (!isDateFormat('<%=txtSupplyToDate.ClientID %>', "Please Enter Supply To Date:Date Format Should Be DD/MM/YYYY")) return false;
     
 }
// if (!isEmpty('<%= txtDeliveryFromDate.ClientID%>', "Please Enter Actual Delivery From Date")) return false;
// if (!isEmpty('<%= txtDeliveryToDate.ClientID%>', "Please Enter Actual Delivery To Date")) return false;
     if(document.getElementById('<%=txtDeliveryFromDate.ClientID%>').value!="")
     {
     if(! isDateFormat('<%=txtDeliveryFromDate.ClientID %>',"Please Enter Delivery From Date:Date Format Should Be DD/MM/YYYY")) return false;
     }
     if(document.getElementById('<%=txtDeliveryToDate.ClientID%>').value!="")
     {
     if(! isDateFormat('<%=txtDeliveryToDate.ClientID %>',"Please Enter Delivery To Date:Date Format Should Be DD/MM/YYYY")) return false;
 }
 if (document.getElementById('<%=txtSupplyToDate.ClientID%>').value != "") {
     if (!DateFormat12('<%=txtSupplyFromDate.ClientID%>', '<%=txtSupplyToDate.ClientID%>', "Expected Delivery From Date Cannot Be Less Than Expected Delivery To Date")) return false;
     document.getElementById('<%=txtSupplyToDate.ClientID%>').focus();
     return false;
     
 }
 
if (document.getElementById('<%=txtDeliveryToDate.ClientID%>').value != "") {
     if (!DateFormat12('<%=txtDeliveryFromDate.ClientID%>', '<%=txtDeliveryToDate.ClientID%>', "Actual Delivery To Date Cannot Be Less Than Actual Delivery From Date")) return false;
     document.getElementById('<%=txtDeliveryToDate.ClientID%>').focus();
     return false;
     
}
 
     
    }
    
    
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <table align="center" class="tdcls" width="70%">
        <tr>
            <td colspan="2" class="heading">
                NEW PROCUREMENT
            </td>
        </tr>
        <tr>
            <td class="subhead" style="width: 39%" align="left">
                Periodicity
            </td>
            <td>
                <asp:DropDownList ID="ddlPeriodicityNewProcirement" runat="server" Style="margin-left: 0px"
                    Height="18px" Width="154px" AutoPostBack="true" OnSelectedIndexChanged="ddlPeriodicityNewProcirement_SelectedIndexChanged">
                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                    <asp:ListItem Value="1">Daily</asp:ListItem>
                    <asp:ListItem Value="2">Monthly</asp:ListItem>
                    <asp:ListItem Value="3">Yearly</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead" style="width: 39%; height: 27px;" align="left">
                Category
            </td>
            <td style="height: 27px">
                <asp:DropDownList ID="ddlCategoryNewProcirement" runat="server" Height="16px" Width="154px"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlCategoryNewProcirement_SelectedIndexChanged">
                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                    <asp:ListItem Value="1">Toiletries</asp:ListItem>
                    <asp:ListItem Value="2">Uniform</asp:ListItem>
                    <asp:ListItem Value="3">Stationary</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr id="trPurpose" runat="server">
            <td class="subhead" nowrap style="width: 39%" align="left">
                Purpose
            </td>
            <td>
                <asp:DropDownList ID="ddlPurposeNewProcirement" runat="server" Width="154px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr id="tr1" runat="server">
            <td class="subhead" nowrap style="width: 39%" align="left">
                Item
            </td>
            <td>
                <asp:DropDownList ID="ddlItem" runat="server" Width="154px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 39%" class="subhead" align="left">
                Expected Delivery From Date
            </td>
            <td style="height: 25px">
                <asp:TextBox ID="txtSupplyFromDate" runat="server"></asp:TextBox>
                <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="imgcal"
                    style="margin-top: 0px">--%>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                    ID="imgcal" Style="margin-top: 0px" />
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgcal"
                    TargetControlID="txtSupplyFromDate" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="subhead" style="width: 39%" align="left">
                Expected Delivery To Date
            </td>
            <td>
                <asp:TextBox ID="txtSupplyToDate" runat="server"></asp:TextBox>
                <%--<img alt="Pick a date" border="0" src="../images/cal.gif" id="imgcal0">--%>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" src="../images/cal.gif"
                    ID="imgcal0" />
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtSupplyToDate"
                    PopupButtonID="imgcal0" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="subhead" style="width: 39%" align="left">
                Actual Delivery From Date
            </td>
            <td>
                <asp:TextBox ID="txtDeliveryFromDate" runat="server"></asp:TextBox>
                <%-- <img alt="Pick a date" border="0" src="../images/cal.gif" id="imgcal1">--%>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" src="../images/cal.gif"
                    ID="imgcal1" />
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDeliveryFromDate"
                    PopupButtonID="imgcal1" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 39%" class="subhead" align="left">
                Actual Delivery To Date
            </td>
            <td>
                <asp:TextBox ID="txtDeliveryToDate" runat="server"></asp:TextBox>
                <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                    id="imgcal2">--%>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                    Width="16" ID="imgcal2" />
                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDeliveryToDate"
                    PopupButtonID="imgcal2" Format="dd/MM/yyyy">
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
                <asp:Button ID="btnGetReport" runat="server" Text="Get Report" OnClick="btnGetReport_Click"  />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
         </table>
        <table align="center" class="tdcls" width="90%">
            <tr>
                <td colspan="2" class="heading" style="height: 18px">
                    NEW PROCUREMENT REPORT FORM
                </td>
            </tr>
            <tr>
                <td>
                    <rsweb:ReportViewer ID="NewProcurementReportViewer" runat="server" 
                        Width="100%">
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
        <%--</ContentTemplate>
   </asp:UpdatePanel>--%>
</asp:Content>
