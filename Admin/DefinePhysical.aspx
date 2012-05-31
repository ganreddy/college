<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DefinePhysical.aspx.cs" Inherits="Admin_DefinePhysical" Title="Define Physical  Challenges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() {
            if (!ValidateTextFormat('<%=txtPH.ClientID%>', "Please Enter Physical  Challenges Type")) return false;
        }
        function Confirm()
        {
            var con = confirm("Do You Want Delete This Physical  Challenges Type ?");
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
    <table align="center" class="tdcls" width="50%">
        <tr>
            <td>
                <asp:HiddenField ID="hdnPH" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="heading" style="text-align: center">
                DEFINE PHYSICALLY CHALLENGED
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Physically Challenged <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtPH" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" OnClick="btnAdd_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="gdvPH" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                    CellSpacing="2" OnRowCommand="gdvPH_RowCommand" OnRowDataBound="gdvPH_RowDataBound">
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle CssClass="gridviewitem" />
                    <SelectedRowStyle Font-Bold="True" />
                    <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                    <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPHId" runat="server" Text='<%#Bind("PHId")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Physical  Challenge">
                            <ItemTemplate>
                                <asp:Label ID="lblPHName" runat="server" Text='<%#Bind("PHType")%>'></asp:Label>
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
</asp:Content>
