<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="ReportStudentAttendance.aspx.cs" Inherits="ReportStudentAttendance" Title="Report Student Attendance"   %>


 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
function validate()
{
 var count=0;
 if (document.getElementById('<%=ddlBatch.ClientID%>').selectedIndex==0)
              count=count+1;
 if(count==5)
  alert("Please Select Atleast One Option");
  
  if (document.getElementById('<%=ddlClasses.ClientID%>').selectedIndex==0)
              count=count+1;
 if(count==5)
  alert("Please Select Atleast One Option");
  
  if (document.getElementById('<%=ddlSections.ClientID%>').selectedIndex==0)
              count=count+1;
 
 if(count==5)
  alert("Please Select Atleast One Option");
  if(! DropdownValidate('<%=ddlMonth.ClientID%>',"Please Select Month"))return false;
  if(! DropdownValidate('<%=ddlYear.ClientID%>',"Please Select Year"))return false;
}

    </script>
 
    <div>
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>--%>
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
                    STUDENT ATTENDANCE REPORT
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
                    <asp:DropDownList ID="ddlBatch" runat="server" Width="154px" 
                        onselectedindexchanged="ddlBatch_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Class
                </td>
                <td>
                    <asp:DropDownList ID="ddlClasses" runat="server" Width="154px" 
                        onselectedindexchanged="ddlClasses_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Section
                </td>
                <td>
                    <asp:DropDownList ID="ddlSections" runat="server" Width="154px" 
                        onselectedindexchanged="ddlSections_SelectedIndexChanged" AutoPostBack="true">
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
                    Month <span style="color: #ff0000">*</span></td>
                <td width="30">
                    <asp:DropDownList ID="ddlMonth" runat="server" Width="154px">
                    <asp:ListItem Text="Select" Value="0">---Select---</asp:ListItem>
                    <asp:ListItem Text="Jan" Value="1">Jan</asp:ListItem>
                    <asp:ListItem Text="Feb" Value="2">Feb</asp:ListItem>
                    <asp:ListItem Text="Mar" Value="3">Mar</asp:ListItem>
                    <asp:ListItem Text="Apr" Value="4">Apr</asp:ListItem>
                    <asp:ListItem Text="May" Value="5">May</asp:ListItem>
                    <asp:ListItem Text="Jun" Value="6">jun</asp:ListItem>
                    <asp:ListItem Text="Jul" Value="7">Jul</asp:ListItem>
                    <asp:ListItem Text="Aug" Value="8">Aug</asp:ListItem>
                    <asp:ListItem Text="Sept" Value="9">Sept</asp:ListItem>
                    <asp:ListItem Text="Oct" Value="10">Oct</asp:ListItem>
                    <asp:ListItem Text="Nov" Value="11">Nov</asp:ListItem>
                    <asp:ListItem Text="Dec" Value="12">Dec</asp:ListItem> 
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Year <span style="color: #ff0000">*</span></td>
                <td width="30">
                    <asp:DropDownList ID="ddlYear" runat="server" Width="154px">
                        
                    </asp:DropDownList>
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
                    <asp:Button Text="Get Report" ID="btnReport" runat="server" OnClick="btnReport_Click" />
                </td>
            </tr>
        </table>
        <table align="center" class="tdcls" width="90%">
            <tr>
                <td class="heading" colspan="4" style="text-align: center">
                     STUDENT ATTENDANCE REPORT&nbsp; FORM
                </td>
            </tr>
            <tr>
                <td>
                    <td colspan="2" align="center">
                     <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" Height="700px">
                    </rsweb:ReportViewer>
                </td>
                </td>
            </tr>
        </table>
        <%--<table width="90%" align="center">
            <tr>
                <td colspan="4" align="center">
                    <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" Height="700px">
                    </rsweb:ReportViewer>
                    
                    
                </td>
            </tr>
        </table>--%>
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
