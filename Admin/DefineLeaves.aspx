<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DefineLeaves.aspx.cs" Inherits="DefineLeaves" Title="Define Leaves" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() 
        {
            if (!isEmpty('<%=txtLeaveType.ClientID%>', "Please Enter Leave Type")) return false;
        }
        function Confirm()
         {
            var con = confirm("Do you want Delete This Leave ?");
            if (con == true) 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        function validate() {
            if (!isEmpty('<%=txtLeaveType.ClientID%>', "Please Enter Leave Type")) return false;
            if (!DropdownValidate('<%=ddlStaffType.ClientID%>', "Please Select Staff Type")) return false;
            if (!isNumeric('<%=txtNoofDays.ClientID%>', "Please Enter Number Of Days Alloted")) return false;
            if (!isEmpty('<%=txtCummulative.ClientID%>', "Please Enter Cummulative Days")) return false;
            if (!isNumeric('<%=txtCummulative.ClientID%>', "Please Enter Valued Cummulative Data")) return false;
        }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>
            <div>
                <table align="center" class="tdcls" width="50%">
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdnAccountFundID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="heading" style="text-align: center">
                            DEFINE STAFF LEAVES
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Leave Type: <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:TextBox ID="txtLeaveType" runat="server" Width="154px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Staff Type: <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:DropDownList ID="ddlStaffType" runat="server" Width="154px">
                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                    <asp:ListItem Value="1">Teaching</asp:ListItem>
                                    <asp:ListItem Value="2">Non-Teaching</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            No of days Alloted: <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:TextBox ID="txtNoofDays" runat="server" Width="154px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Cummulative Days: <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:TextBox ID="txtCummulative" runat="server" Width="154px"></asp:TextBox>
                            </td>
                    </tr>
                </table>
                <table align="center" class="tdcls">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" 
                                onclick="btnAdd_Click" />
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gdvLeaves" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" onpageindexchanging="gdvLeaves_PageIndexChanging"  AllowPaging="true"
                                onrowcommand="gdvLeaves_RowCommand" onrowdatabound="gdvLeaves_RowDataBound"  PageSize="10">
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLeaveTypeID" runat="server" Text='<%#Bind("LeaveTypeID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Leave Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLeave" runat="server" Text='<%#Bind("LeaveType")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffTypeID" runat="server" Text='<%#Bind("StaffType")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Staff Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffType" runat="server" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No Of days">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoofDays" runat="server" Text='<%#Bind("Noofdays")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cummulative">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCummulative" runat="server" Text='<%#Bind("Cummulative")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="editing"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="del"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
