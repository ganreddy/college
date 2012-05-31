<%@ Page  Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DefineAccHeads.aspx.cs" Inherits="Admin_DefineAccHeads"  Title="Define Account Heads"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() 
        {
            if (!isEmpty('<%=txtHead.ClientID%>', "Please Enter Account Head")) return false;
             if(! DropdownValidate('<%=ddlFund.ClientID%>',"Please Select Fund Type"))return false;
             if (!isDecimal('<%=txtFundAmt.ClientID%>', "Please Enter Funds Amount")) return false;
        }
        function Confirm() 
        {
            var con = confirm("Do You Want Delete This Head?");
            if (con == true)
             {
                return true;
             }
            else
             {
                return false;
             }
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
                            <asp:HiddenField ID="hdnAccountHeadID" runat="server" />
                             <asp:HiddenField ID="hdnSubAccountHead" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="heading" style="text-align: center">
                            DEFINE ACCOUNT HEADS
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                     <tr>
                        <td class="subhead">
                            Account Fund <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:DropDownList ID="ddlFund" runat="server" Width="154px">
                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Account Head <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:TextBox ID="txtHead" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                   
                    <tr>
                        <td class="subhead">
                             Fund Amount<span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:TextBox ID="txtFundAmt" runat="server"></asp:TextBox> 
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
                                onclick="btnAdd_Click"  />
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
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gdvAccountsHead" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" onrowcommand="gdvAccountsHead_RowCommand" 
                                AllowPaging="true" PageSize="10"
                                onrowdatabound="gdvAccountsHead_RowDataBound" 
                                onpageindexchanging="gdvAccountsHead_PageIndexChanging" >
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                   <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeadID" runat="server" Text='<%#Bind("HeadID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Head Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeadName" runat="server" Text='<%#Bind("HeadName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Account Fund">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAccountFund" runat="server" Text='<%#Bind("FundName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Fund Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmountFund" runat="server" Text='<%#Bind("FundAmount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFundId" runat="server" Text='<%#Bind("FundID")%>'></asp:Label>
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
