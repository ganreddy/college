<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefineFeeHeaders.aspx.cs" Inherits="Admin_DefineFeeHeaders" Title="Define Fee Headers" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function validate() {
            if (!isEmpty('<%=txtHead.ClientID%>', "Please Enter Account Head")) return false;
             if(! DropdownValidate('<%=ddlFeeType.ClientID%>',"Please Select Fund Type"))return false;
        }
        function Confirm() {
            var con = confirm("Do You Want Delete This Head ?");
            if (con == true) {
                return true;
            }
            else {
                return false;
            }
        }
        function Clear() {
            document.getElementById('<%=txtHead.ClientID%>').value = "";
            document.getElementById('<%=ddlFeeType.ClientID%>').value = 0;
            document.getElementById('<%=btnAdd.ClientID%>').innerText = "Add";
            //return false;
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
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="heading" style="text-align: center">
                            DEFINE FEE HEADERS
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Fee Head <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:TextBox ID="txtHead" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Fee Type <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:DropDownList ID="ddlFeeType" runat="server" Width="154px">
                                </asp:DropDownList>
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
                        <td >
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAdd" runat="server" Text="Add"  
                                onclick="btnAdd_Click"  />
                                <asp:Button ID="btnClear" runat="server" Text="Clear"  onclick="btnClear_Click" 
                                 />
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
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
                            <asp:GridView ID="gdvFeeHead" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" onrowcommand="gdvFeeHead_RowCommand" 
                                AllowPaging="true" PageSize="10"
                                onrowdatabound="gdvFeeHead_RowDataBound" 
                                onpageindexchanging="gdvFeeHead_PageIndexChanging" >
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
                                    <asp:TemplateField HeaderText="Header Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeaderName" runat="server" Text='<%#Bind("HeaderName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fee Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFeeType" runat="server" Text='<%#Bind("FeeType")%>'></asp:Label>
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
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFeeTypeID" runat="server" Text='<%#Bind("FeeTypeID")%>'></asp:Label>
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

