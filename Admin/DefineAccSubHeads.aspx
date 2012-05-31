<%@ Page Title="Define Accounts Subheads" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="DefineAccSubHeads.aspx.cs" Inherits="Admin_DefineAccSubHeads" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        function validation()
         {
            if (!DropdownValidate('<%=ddlHeads.ClientID%>', "Please Select Heads")) return false;
            
            if (!isEmpty('<%=txtSubHead.ClientID%>', "Please Enter Sub Head")) return false;
             if (!isDecimal('<%=txtFundAmnt.ClientID%>', "Please Enter Valid Fund Amount")) return false;
           
            

        }
        
        function Confirm() {
            var con = confirm("Do You Want Delete This Item ?");
            if (con == true) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>
            <div>
                <table align="center" class="tdcls" width="60%">
                    <tr>
                        <td colspan="2" class="heading">
                            DEFINE ACCOUNTS SUB HEADS
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 118px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:HiddenField ID="hdnSubAccountHeadID" runat="server" />
                            <asp:HiddenField ID="hdnSubAccountHead" runat="server" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="subhead" style="width: 118px">
                            Heads <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlHeads" runat="server" Width="154px">
                                <asp:ListItem>---Select---</asp:ListItem>
                                <asp:ListItem Value="1">XXX</asp:ListItem>
                                <asp:ListItem Value="2">YYY</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 118px">
                            Sub Head <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSubHead" runat="server" Width="154px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td class="subhead" style="width: 118px">
                            Fund Amount <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFundAmnt" runat="server" Width="154px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 118px">
                           
                        </td>
                        <td>
                             
                        </td>
                    
                    <tr>
                        <td class="subhead" align="center" style="width: 118px">
                           
                        </td>
                        <td>
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" 
                                onclick="btnAdd_Click"  />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 15px;" colspan="2">
                            <br />
                           <%-- <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" 
                                onclick="btnAdd_Click"  />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                        </td>
                        </tr>
                       
                    <tr>
                        <td align="center" colspan="2">
                            <asp:GridView ID="gdvAccountSubHead" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" onrowcommand="gdvAccountSubHead_RowCommand" 
                                AllowPaging="true" PageSize="10"
                                onrowdatabound="gdvAccountSubHead_RowDataBound" 
                                onpageindexchanging="gdvAccountSubHead_PageIndexChanging">
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubHeadID" runat="server" Text='<%#Bind("SubHeadID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SubHead Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubHeadName" runat="server" Text='<%#Bind("SubHeadName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Heads">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeadID" runat="server" Text='<%#Bind("HeadName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fund Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFundAmt" runat="server" Text='<%#Bind("FundAmount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHead" runat="server" Text='<%#Bind("HeadID")%>'></asp:Label>
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
