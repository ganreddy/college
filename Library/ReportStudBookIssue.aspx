<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportStudBookIssue.aspx.cs" Inherits="Library_ReportStudentBookIssue" Title="Student Book Issue Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="../scripts/Validations.js" type="text/javascript"></script>

 <script type="text/javascript" language="javascript">
        function validate() 
        { 
             if(document.getElementById('<%=txtFromDate.ClientID%>').value!="")
                   if (! isDateFormat('<%=txtFromDate.ClientID%>', "Please Enter valid From Date")) return false;
             if(document.getElementById('<%=txtToDate.ClientID%>').value!="")
                   if (! isDateFormat('<%=txtToDate.ClientID%>', "Please Enter valid To Date")) return false;
                
                if(document.getElementById('<%=txtDueFromDate.ClientID%>').value!="")
                   if (! isDateFormat('<%=txtDueFromDate.ClientID%>', "Please Enter valid Due From Date")) return false;
             if(document.getElementById('<%=txtDueToDate.ClientID%>').value!="")
                   if (! isDateFormat('<%=txtDueToDate.ClientID%>', "Please Enter valid Due To Date")) return false;
                      
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
                     STUDENT BOOK ISSUE REPORT            
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
                    <asp:ImageButton runat="server" id="Img1" border="0" height="16" src="../images/cal.gif" width="16"/>
                    <asp:CalendarExtender ID="CalendarExtender0" runat="server" PopupButtonID="Img1"
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
                   <%-- <img id="Img2" border="0" height="16" src="../images/cal.gif" width="16">--%>
                   <asp:ImageButton runat="server" id="Img2" border="0" height="16" src="../images/cal.gif" width="16"/>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Img2"
                    TargetControlID="txtToDate" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Due From Date
                </td>
                <td>
                    <asp:TextBox ID="txtDueFromDate" runat="server"></asp:TextBox>
                    <%--<img id="Img3" border="0" height="16" src="../images/cal.gif" width="16">--%>
                    <asp:ImageButton runat="server" id="Img3" border="0" height="16" src="../images/cal.gif" width="16"/>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Img3"
                    TargetControlID="txtDueFromDate" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                   Due To Date
                </td>
                <td>
                    <asp:TextBox ID="txtDueToDate" runat="server"></asp:TextBox>
                    <%--<img id="Img4" border="0" height="16" src="../images/cal.gif" width="16">--%>
                    <asp:ImageButton runat="server" id="Img4" border="0" height="16" src="../images/cal.gif" width="16"/>
                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="Img4"
                    TargetControlID="txtDueToDate" Format="dd/MM/yyyy">
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
                        <td colspan="4" class="heading" style="height: 18px">
                            STUDENT BOOK ISSUE REPORT FORM
                        </td>
                    </tr>
            <tr>
                <td colspan="4" align="center">
                    <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" >
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

