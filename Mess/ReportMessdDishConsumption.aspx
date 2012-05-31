<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportMessdDishConsumption.aspx.cs" 
Inherits="Mess_MessdDishConsumption" Title="Mess Dish Consumption Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

 <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() 
        {
            if (document.getElementById('<%=txtFromDate.ClientID%>').value != "")
                if (!isDateFormat('<%=txtFromDate.ClientID%>', "Please Enter valid From Date")) return false;
                if (document.getElementById('<%=txtToDate.ClientID%>').value != "")
                    if (!isDateFormat('<%=txtToDate.ClientID%>', "Please Enter valid To Date")) return false;
                    if (!DateFormat12('<%=txtFromDate.ClientID%>', '<%=txtToDate.ClientID%>', "To Date Cannot Be Less Than From Date")) return false;
        }
    </script>

    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
        
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
                    MESS DISH CONSUMPTION REPORT
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
           
            <tr>
                <td class="subhead">
                      Dish Name
                </td>
                <td>
                    <asp:DropDownList ID="ddlDishId" runat="server" Width="154px" >
                       
                       
                        
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead" style="height: 20px">
                    Meal Type                 </td>
                <td style="height: 20px">
                    <asp:DropDownList ID="ddlMealType" runat="server" Width="154px" >
                        
                       
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    From Date
                </td>
                <td>
                    <asp:TextBox ID="txtFromDate" runat="server">
                    </asp:TextBox>
                    <%--<img id="Img1" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                        width="16">--%>
                        <asp:ImageButton runat="server" id="Img1" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                        width="16"/>
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
                        <asp:TextBox ID="txtToDate" runat="server">
                        </asp:TextBox>
                       <%-- <img id="Img2" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                        width="16">--%>
                        <asp:ImageButton runat="server" id="Img2" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                        width="16"/>
                        <asp:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="Img2"
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
                <td width="30">
                </td>
                <td width="30">
                
                
                    <asp:Button Text="GetReport" ID="btnReport" runat="server" 
                        onclick="btnReport_Click" />
                       
                </td>
            </tr>
        </table>
        <table width="90%" align="center">
        <tr>
                <td colspan="2" class="heading" style="height: 18px">
                    MESS DISH CONSUMPTION REPORT FORM
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%">
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
    </div>
   
</asp:Content>

