<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Delete Staff.aspx.cs" Inherits="Staff_Delete_Staff" Title="Delete Staff" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validation() {
            if (!DropdownValidate('<%=ddlStaffId.ClientID%>', "Please Select Batch")) return false;
           
        }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" ID="updStdAttendance">
        <ContentTemplate>
            <div>
                <table align="center" class="tdcls" width="50%">
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
                        </td>
                    </tr>
                    <tr>
                        <td class="heading" colspan="2" style="text-align: center">
                            Delete Staff
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Staff Name <span style="font-size: 17px; color: Red">*</span>
                        </td>
                        <td width="30" align="center">
                            <asp:DropDownList ID="ddlStaffId" runat="server" Width="154px" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnSave" runat="server" Text="Delete" Width="115px" 
                                onclick="btnSave_Click"  />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
