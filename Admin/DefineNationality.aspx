<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DefineNationality.aspx.cs" Inherits="Admin_DefineNationality" Title="Define Nationality" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    function validate()
    {
     if(! isEmpty('<%=txtNationality.ClientID%>',"Please Enter Nationality"))return false;
    }
    function Confirm()
    {
        var con = confirm("Do You Want Delete This Batch ?");
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
            <table align="center" class="tdcls" width="50%">
                <tr>
                    <td colspan="2">
                        <asp:HiddenField ID="hdnNation" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="heading" style="text-align: center">
                        DEFINE NATIONALITY
                    </td>
                </tr>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="subhead">
                        Nationality <span style="font-size: 10px; color: Red">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNationality" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" OnClick="btnAdd_Click"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:GridView ID="gdvNation" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                            CellSpacing="2" OnRowCommand="gdvNation_RowCommand" OnRowDataBound="gdvNation_RowDataBound">
                            <FooterStyle BackColor="#CCCCCC" />
                            <RowStyle CssClass="gridviewitem" />
                            <SelectedRowStyle Font-Bold="True" />
                            <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                            <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNationalityID" runat="server" Text='<%#Bind("NationalityID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nationality">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNation" runat="server" Text='<%#Bind("Nation")%>'></asp:Label>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
