<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LibSubCategory.aspx.cs" Inherits="Admin_LibSubCategory" Title="Library SubCategory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">

        function validation() 
        {
        if(! isEmpty('<%=txtLibSubCategory.ClientID%>',"Please Enter  Sub Category"))return false;
        if(! isNumeric('<%=txtSCNo.ClientID%>',"Please Enter  Sub Category Number"))return false;
        if(! DropdownValidate('<%=ddlLibSubCategory.ClientID%>',"Please Select Category"))return false;
        
        
        
         

            

        }
        
        function Confirm() {
            var con = confirm("Do You Want Delete This Subcategory ?");
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
                            DEFINE LIBRARY SUBCATEGORY
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:HiddenField ID="hdnLibSubCategoryID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Sub Category Name <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLibSubCategory" runat="server" Width="154px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Sub Category Number <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSCNo" runat="server" Width="154px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    
                    <tr>
                        <td class="subhead">
                            Category <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLibSubCategory" runat="server" Width="154px">
                                <asp:ListItem>---Select---</asp:ListItem>
                                
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    
                    <tr>
                        <td align="center" style="height: 15px;" colspan="2">
                            <br />
                            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" 
                                onclick="btnAdd_Click"  />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                        </td>
                        </tr>
                       
                    <tr>
                        <td align="center" colspan="2">
                            <asp:GridView ID="gdvLibSubCategory" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" onrowcommand="gdvLibSubCategory_RowCommand" 
                                onrowdatabound="gdvLibSubCategory_RowDataBound" AllowPaging="true" 
                                PageSize="10" onpageindexchanging="gdvLibSubCategory_PageIndexChanging"  >
                                
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubCategoryID" runat="server" Text='<%#Bind("SubCategoryID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubCategory" runat="server" Text='<%#Bind("SubCategory")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Category Number">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubCategoryNumber" runat="server" Text='<%#Bind("SubCategoryNumber")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%#Bind("Category")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategoryId" runat="server" Text='<%#Bind("CategoryID")%>'></asp:Label>
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


