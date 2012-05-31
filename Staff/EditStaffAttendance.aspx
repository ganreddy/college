<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EditStaffAttendance.aspx.cs" Inherits="Staff_EditStaffAttendance" Title="Edit Staff Attendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
     function validate()
    {  
    if(! DropdownValidate('<%=ddlMonth.ClientID%>',"Please Select Month"))return false;
    if(! DropdownValidate('<%=ddlYear.ClientID%>',"Please Select Year"))return false;
}

function Numeric(Id) 
{
    var unicode = Id.charCode ? Id.charCode : Id.keyCode
    if (unicode != 8) 
    {
        //if the key isn't the backspace key (which we should allow)
        if (unicode < 48 || unicode > 57) 
        {
            //if not a number
            alert("enter Numeric only");
            return false //disable key press
        }
    }
}    
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div>
                <table align="center" class="tdcls" width="80%" border="0">
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:HiddenField ID="Message" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="heading" colspan="2" style="text-align: center">
                           EDIT STAFF ATTENDACE
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 30%">
                            Month<span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlMonth" runat="server" Height="21px" Width="154px">
                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                <asp:ListItem Value="5">May</asp:ListItem>
                                <asp:ListItem Value="6">June</asp:ListItem>
                                <asp:ListItem Value="7">July</asp:ListItem>
                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                <asp:ListItem Value="9">Sep</asp:ListItem>
                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                <asp:ListItem Value="12">Dec</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 30%">
                            Year<span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlYear" runat="server" Width="154px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="subhead" style="width: 30%">
                            No of Working Days <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtnoofworkingdays" runat="server"></asp:TextBox>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="subhead" align="center">
                            <%-- <asp:CheckBox Text="Get Attendance" ID="chkFullance" runat="server" AutoPostBack="true"
                                OnCheckedChanged="chkFullance_CheckedChanged" />--%>
                            <asp:Button ID="btnAttendance" runat="server" Text="Get Attendance" OnClick="btnAttendance_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:GridView ID="dgrid" runat="server" AutoGenerateColumns="false" Style="text-align: center"
                                AllowPaging="true" PageSize="10" OnPageIndexChanging="dgrid_PageIndexChanging"
                                OnRowEditing="dgrid_RowEditing" OnRowUpdating="dgrid_RowUpdating" OnRowCancelingEdit="dgrid_RowCancelingEdit">
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffID" runat="server" Text='<%#Bind("StaffID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Staff Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffName" runat="server" Text='<%#Bind("FullName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            NoofDaysPresent
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%--<asp:CheckBox ID="ChkAll" runat="server" />--%>
                                            <asp:Label ID="lblDays" runat="server" Text='<%#Bind("DaysPresent")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtNoOfdays" runat="server" Text='<%#Bind("DaysPresent")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="true" ShowCancelButton="true" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
