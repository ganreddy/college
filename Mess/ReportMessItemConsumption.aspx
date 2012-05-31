<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportMessItemConsumption.aspx.cs" Inherits="Mess_MessItemConsumption"
    Title="Mess Item Consumption Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() 
        { 
             if(document.getElementById('<%=txtFromDate.ClientID%>').value!="")
                   if (! isDateFormat('<%=txtFromDate.ClientID%>', "Please Enter valid From Date")) return false;
             if(document.getElementById('<%=txtToDate.ClientID%>').value!="")
                 if (!isDateFormat('<%=txtToDate.ClientID%>', "Please Enter valid To Date")) return false;
                 if (!DateFormat12('<%=txtFromDate.ClientID%>', '<%=txtToDate.ClientID%>', "To Date Cannot Be Less Than From Date")) return false;
        }
    </script>

    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
       <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>--%>
                <table align="center" class="tdcls" width="60%">
                    <tr>
                        <td class="heading" colspan="4" style="text-align: center">
                            MESS ITEM CONSUMPTION REPORT
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Mess Item
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMessItem" runat="server" Width="154px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            From Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                            <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        style="height: 16px" runat="server" id="imgcal">--%>
                            <asp:ImageButton alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                                Width="16" Style="height: 16px" runat="server" ID="imgcal" />
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                PopupButtonID="imgcal" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            To Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                            <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        style="height: 16px" runat="server" id="img1">--%>
                            <asp:ImageButton alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                                Width="16" Style="height: 16px" runat="server" ID="img1" />
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                                PopupButtonID="img1" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="30">
                        </td>
                        <td width="30">
                            &nbsp;<asp:Button Text="Get Report" ID="btnReport" runat="server" OnClick="btnReport_Click" />
                        </td>
                    </tr>
                </table>
                <table width="90%" align="center">
                    <tr>
                        <td colspan="2" class="heading" style="height: 18px">
                             MESS ITEM CONSUMPTION REPORT FORM
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
          <%--  </ContentTemplate>
        </asp:UpdatePanel>--%>
</asp:Content>
