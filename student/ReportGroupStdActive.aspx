<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportGroupStdActive.aspx.cs" Inherits="student_GroupStdActive" Title="Activity Between Two Dates Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        function validation()
         {
            if(!isEmpty('<%=txtFromDate.ClientID%>',"Please Enter From Date"))return false;
        if(document.getElementById('<%=txtFromDate.ClientID%>').value!="")
        {
            if(!isDateFormat('<%=txtFromDate.ClientID%>',"Date Formet Should Be DD/MM/YYYY"))return false;
        }
        
        if(!isEmpty('<%=txtToDate.ClientID%>',"Please Enter To Date"))return false;
        if(document.getElementById('<%=txtToDate.ClientID%>').value!="")
        {
            if(!isDateFormat('<%=txtToDate.ClientID%>',"Date Formet Should Be DD/MM/YYYY"))return false;
        }

        if (!DropdownValidate('<%=ddlClub.ClientID%>', "Please Select Club Name")) return false;
        if(!DropdownValidate('<%=ddlactivtytype.ClientID%>',"Please Select Activity Type"))return false;
        if(!DropdownValidate('<%=ddlprize.ClientID%>',"Please Select Prize"))return false;
            

        }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%--<asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>--%>
            <div>
                <table align="center" class="tdcls" width="60%">
                    <tr>
                        <td class="heading" colspan="2" style="text-align: center" width="80%">
                            STUDENT ACTIVITY REPORT
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            From Date<span style="font-size: 17px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFromDate" runat="server" Width="154px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgCalFrom"
                                TargetControlID="txtFromDate">
                            </asp:CalendarExtender>
                            <%--<img id="imgCalFrom" alt="Pick a date" border="0" height="16" src="../images/cal.gif">--%>
                            <asp:ImageButton runat="server" id="imgCalFrom" border="0" height="16" src="../images/cal.gif" width="16"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            To Date<span style="font-size: 17px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtToDate" runat="server" Width="154px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="img1"
                                TargetControlID="txtToDate">
                            </asp:CalendarExtender>
                            <%--<img id="img1" alt="Pick a date" border="0" height="16" src="../images/cal.gif">--%>
                            <asp:ImageButton runat="server" id="img1" border="0" height="16" src="../images/cal.gif" width="16"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Club Name<span style="font-size: 17px; color: Red">*</span></td>
                        <td>
                            <asp:DropDownList ID="ddlClub" runat="server" Height="16%" 
                                Width="154px">
                                
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Activity Type <span style="font-size: 17px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlactivtytype" runat="server" Height="16%" Width="154px">
                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                <asp:ListItem Value="1">Individual</asp:ListItem>
                                <asp:ListItem Value="2">Group</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Prize<span style="font-size: 17px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlprize" runat="server" Width="154px" Height="16%">
                                <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                <asp:ListItem Value="0">ALL</asp:ListItem>
                                <asp:ListItem Value="1">I</asp:ListItem>
                                <asp:ListItem Value="2">II</asp:ListItem>
                                <asp:ListItem Value="3">III</asp:ListItem>
                               <%-- <asp:ListItem Value="4">IV</asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <center>
                                <asp:Button ID="btnReport" runat="server" Text="Get Report" OnClick="btnReport_Click" /></center>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table align="center" class="tdcls" width="90%">
                    <tr>
                        <td class="heading" colspan="4" style="text-align: center" width="90%">
                            STUDENT ACTIVITY REPORT FORM
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <rsweb:ReportViewer ID="StudntActivityReport" runat="server" Width="100%">
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
                </td> </tr>
            </div>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
