<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DefineBookCategory.aspx.cs" Inherits="Admin_DefineBookCategory" Title="Define Book Category" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../scripts/Validations.js" type="text/javascript"></script>
    
    <script type="text/javascript" language="javascript">
    function validation()
     {
          if(! isEmpty('<%=txtCategory.ClientID%>',"Please Enter Category"))return false;
//          if(document.getElementById('<%=txtCategory.ClientID %>').value!="")
//            {
//               if(! ValidateTextFormat('<%=txtCategory.ClientID %>',"Please Enter valid Category")) return false;
//            }
          if(! isEmpty('<%=txtCategoryNumber.ClientID%>',"Please Enter Category Number"))return false;
          if(document.getElementById('<%=txtCategoryNumber.ClientID %>').value!="")
            {
               if(! isNumeric('<%=txtCategoryNumber.ClientID %>',"Please Enter Valid Category Number")) return false;
            }
     }
    
   
    function Confirm()
        {
            var con = confirm("Do You Want Delete This Category/Category Number?");
           if (con==true)
           {
              return true;
           }
           else
           {
               return false;
           }
        }
    </script>

    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>
            <div>
                <table align="center" class="tdcls" width="50%">
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdnBookCategory" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="heading" style="text-align: center">
                            DEFINE BOOK CATEGORY
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Category <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Category Number<span style="font-size: 10px; color: #CC3300">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCategoryNumber" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:GridView ID="gdvBookCategory" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" PageSize="10" AllowPaging="true" 
                                onrowcommand="gdvBookCategory_RowCommand" 
                                onrowdatabound="gdvBookCategory_RowDataBound" 
                                onpageindexchanged="gdvBookCategory_PageIndexChanged" 
                                onpageindexchanging="gdvBookCategory_PageIndexChanging" 
                                onselectedindexchanging="gdvBookCategory_SelectedIndexChanging">
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategoryID" runat="server" Text='<%#Bind("CategoryID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%#Bind("Category")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CategoryNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategoryNumber" runat="server" Text='<%#Bind("CategoryNumber")%>'></asp:Label>
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
