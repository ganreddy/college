<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="DefineMessDish.aspx.cs" Inherits="DefineMessDish" Title="Define Mess Dish"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    function validation()
    {
      if(! isEmpty('<%=txtDishName.ClientID%>',"Please Enter Dish Name"))return false;
      if(document.getElementById('<%=txtDishName.ClientID %>').value!="")
        {
         if(! isAlphanumeric('<%=txtDishName.ClientID %>',"Please Enter valid Dish Name")) return false;
        }
         if(! DropdownValidate('<%=ddlMeal.ClientID%>',"Please Select Meal Type"))return false;
    
   }
       
                   

    
    function Confirm()
    {
        var con = confirm("Do You Want Delete This DishName?");
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

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>
            <div>
                <table align="center" class="tdcls" width="50%">
                    <tr>
                        <td colspan="2">
                            <asp:HiddenField ID="hdnMessDish" runat="server" />
                            .
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="heading">
                            DEFINE DISH
                        </td>
                    </tr>
                    <tr>
                        <td nowrap class="subhead">
                            Dish Name <span style="font-size: 10px; color: Red">*</span>
                            <td>
                                <asp:TextBox ID="txtDishName" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td nowrap class="subhead">
                            Meal Type <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMeal" runat="server" Width="150px">
                                <asp:ListItem>Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" OnClick="btnAdd_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                        </td>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:GridView ID="gdvMessDish" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                    CellSpacing="2" OnRowCommand="gdvMessDish_RowCommand" 
                                    OnRowDataBound="gdvMessDish_RowDataBound" AllowPaging="true" PageSize="10" 
                                    onpageindexchanging="gdvMessDish_PageIndexChanging1">
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <RowStyle CssClass="gridviewitem" />
                                    <SelectedRowStyle Font-Bold="True" />
                                    <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDishID" runat="server" Text='<%#Bind("DishID")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Dish Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDishName" runat="server" Text='<%#Bind("DishName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Meal Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMealType" runat="server" Text='<%#Bind("MealType")%>'></asp:Label>
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
