<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="DefineMessItemCategory.aspx.cs" Inherits="DefineMessItemCategory" Title="Define Mess Items"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitiona//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    
    function validation()
    {
           if(! isEmpty('<%=txtItemName.ClientID%>',"Please Enter Mess Item Name"))return false;
           if(! DropdownValidate('<%=ddlCategory.ClientID%>',"Please Select Category"))return false;
           if(document.getElementById('<%=ddlCategory.ClientID%>').selectedIndex=="1")
           {
             if(! DropdownValidate('<%=ddlPeriod.ClientID%>',"Please Select Periodicity"))return false;
             if(! DropdownValidate('<%=ddlSubCat.ClientID%>',"Please Select Sub Category"))return false;
         }
         if (!DropdownValidate('<%=ddlUom.ClientID%>', "Please Select Units Of Measurement ")) return false;
    }
    function Show()
    {
       
       if(document.getElementById('<%=ddlCategory.ClientID%>').selectedIndex=="1")
       {
         document.getElementById('<%=trPeriod.ClientID%>').style.display="inline";
         document.getElementById('<%=trSubCat.ClientID%>').style.display="inline";
       }
       else
       {
         document.getElementById('<%=trPeriod.ClientID%>').style.display="none";
         document.getElementById('<%=trSubCat.ClientID%>').style.display="none";
       }
    }
    function Confirm()
    {
        var con = confirm("Do You Want Delete This Item ?");
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
                <table align="center" class="tdcls" width="60%">
                    <tr>
                        <td colspan="2" class="heading">
                            DEFINE&nbsp; ITEM
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td colspan="2">
                            <asp:HiddenField ID="hdnItemID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Name Of Item <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtItemName" runat="server" Width="154px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Category <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" runat="server" Width="154px">
                                <asp:ListItem>---Select---</asp:ListItem>
                                <asp:ListItem Value="1">Store</asp:ListItem>
                                <asp:ListItem Value="2">Mess</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr runat="server" id="trPeriod">
                        <td class="subhead">
                            Periodicity <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPeriod" runat="server" Width="154px">
                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                <asp:ListItem Value="1">Daily</asp:ListItem>
                                <asp:ListItem Value="2">Monthly</asp:ListItem>
                                <asp:ListItem Value="3">Yearly</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr runat="server" id="trSubCat">
                        <td class="subhead">
                            Sub Category <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubCat" runat="server" Width="154px">
                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                <asp:ListItem Value="1">Toileteries</asp:ListItem>
                                <asp:ListItem Value="2">Uniform</asp:ListItem>
                                <asp:ListItem Value="3">Stationary</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr runat="server" id="tr1">
                        <td class="subhead">
                            Units Of Measurement <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUom" runat="server" Width="154px">
                                <%--<asp:ListItem Value="0">---Select---</asp:ListItem>
                                <asp:ListItem Value="1">Toileteries</asp:ListItem>
                                <asp:ListItem Value="2">Uniform</asp:ListItem>
                                <asp:ListItem Value="3">Stationary</asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 15px;" colspan="2">
                            <br />
                            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" OnClick="btnAdd_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:GridView ID="gdvItem" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                    AllowPaging="true" PageSize="10"
                                CellSpacing="2" OnRowDataBound="gdvItem_RowDataBound" 
                                OnRowCommand="gdvItem_RowCommand" 
                                onpageindexchanging="gdvItem_PageIndexChanging">
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemID" runat="server" Text='<%#Bind("ItemId")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemName" runat="server" Text='<%#Bind("ItemName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%#Bind("Type")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Periodicity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%#Bind("Periodicity")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubCat" runat="server" Text='<%#Bind("SubCategory")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="UOM" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUOMID" runat="server" Text='<%#Bind("UOM")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UOM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUOM" runat="server" Text='<%#Bind("UOMName")%>'></asp:Label>
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
