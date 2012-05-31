<%@ Page AutoEventWireup="true" CodeFile="DefineClassSection.aspx.cs" Inherits="DefineClassSection"
    Language="C#" MasterPageFile="~/MasterPage.master" Title="Define Class Section" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    function validate()
    {
        if(! isEmpty('<%=txtSection.ClientID%>',"Please Enter Section"))return false;
    }
    function Confirm()
    {
        var con = confirm("Do You Want Delete This Section ?");
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
                        <asp:HiddenField ID="hdnSection" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="heading" style="text-align: center">
                        DEFINE SECTIONS
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="subhead">
                        Section Name <span style="font-size: 10px; color: Red">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSection" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr><td>&nbsp;</td></tr>
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
                        <asp:GridView ID="gdvBatch" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                            CellSpacing="2" OnRowCommand="gdvBatch_RowCommand" OnRowDataBound="gdvBatch_RowDataBound">
                            <FooterStyle BackColor="#CCCCCC" />
                            <RowStyle CssClass="gridviewitem" />
                            <SelectedRowStyle Font-Bold="True" />
                            <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                            <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSectionID" runat="server" Text='<%#Bind("SectionID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Section">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSectionName" runat="server" Text='<%#Bind("SectionName")%>'></asp:Label>
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
