<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentLeave.aspx.cs" Inherits="StudentLeave"
    MasterPageFile="~/MasterPage.master" Title="Student Leaves" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validation() {
            if (!DropdownValidate('<%=ddlBatch.ClientID%>', "Please Select Batch")) return false;
            if (!DropdownValidate('<%=ddlClasses.ClientID%>', "Please Select Class")) return false;
            if (!DropdownValidate('<%=ddlSection.ClientID%>', "Please Select Section")) return false;
            if (!DropdownValidate('<%=ddlStudent.ClientID%>', "Please Select Student")) return false;


            if (!isEmpty('<%=txtFrom.ClientID%>', "Please Enter From Date")) return false;
            if (document.getElementById('<%=txtFrom.ClientID %>').value != "") {
                if (!isDateFormat('<%=txtFrom.ClientID %>', "Date Format Should Be DD/MM/YYYY")) return false;
            }

            if (!isEmpty('<%=txtTo.ClientID%>', "Please Enter To Date")) return false;
            if (document.getElementById('<%=txtTo.ClientID %>').value != "") {
                if (!isDateFormat('<%=txtTo.ClientID %>', "Date Format Should Be DD/MM/YYYY")) return false;
            }
            if (!DateFormat123('<%=txtFrom.ClientID %>', '<%=txtTo.ClientID %>', "Please Enter From Date < To Date")) return false;

            if (!DropdownValidate('<%=ddlhousemaster.ClientID%>', "Please Select Hostel/House Master")) return false;
            if (!isEmpty('<%=txtReason.ClientID%>', "Please Enter Reason")) return false;


        }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="Upd" runat="server">
        <ContentTemplate>
            <table align="center" class="tdcls" width="50%">
                <tr>
                    <td>
                        <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
                    </td>
                </tr>
                <tr>
                    <td class="heading" colspan="2" style="text-align: center">
                        STUDENT LEAVE
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="subhead">
                        Batch <span style="font-size: 17px; color: Red">*</span>
                    </td>
                    <td width="30">
                        <asp:DropDownList ID="ddlBatch" runat="server" Width="154px" AutoPostBack="true"
                            Height="16%" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="subhead">
                        Class <span style="font-size: 17px; color: Red">*</span>
                    </td>
                    <td width="30">
                        <asp:DropDownList ID="ddlClasses" runat="server" Width="154px" Height="16%" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="subhead">
                        Section <span style="font-size: 17px; color: Red">*</span>
                    </td>
                    <td width="30">
                        <asp:DropDownList ID="ddlSection" runat="server" Width="154px" Height="16%" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="subhead">
                        Student <span style="font-size: 17px; color: Red">*</span>
                    </td>
                    <td width="30">
                        <asp:DropDownList ID="ddlStudent" runat="server" Width="154px" Height="16%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="subhead">
                        From <span style="font-size: 17px; color: Red">*</span>
                    </td>
                    <td nowrap>
                        <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                        <%-- <img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16" id="imgcal" >--%>
                        <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                            Width="16" ID="imgcal" />
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                            PopupButtonID="imgcal" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td class="subhead">
                        To <span style="font-size: 17px; color: Red">*</span>
                    </td>
                    <td nowrap>
                        <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                        <%-- <img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16" id="imgcal1">--%>
                        <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                            Width="16" ID="imgcal1" />
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                            PopupButtonID="imgcal1" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td class="subhead">
                        Hostel/House Master<span style="font-size: 17px; color: Red">*</span>
                    </td>
                    <td style="height: 21px" width="30">
                        <asp:DropDownList ID="ddlhousemaster" runat="server" Width="154px" Height="16%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="subhead">
                        Reason <span style="font-size: 17px; color: Red">*</span>
                        <td style="height: 21px" width="30">
                            <asp:TextBox ID="txtReason" TextMode="MultiLine" runat="server" Width="155px"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="height: 21px">
                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="90px" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
