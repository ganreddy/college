<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DefineJoiningType.aspx.cs" Inherits="Admin_DefineJoiningType" Title="Define Joining Type" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    function validate()
    {
     if(! ValidateTextFormat('<%=txtJoinType.ClientID%>',"Please Enter Joining Type"))return false;
    }
    function Confirm()
    {
        var con = confirm("Do You Want Delete This Joining Type ?");
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
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
        
    <table align="center" class="tdcls" width="50%">
        <tr>
            <td>
                <asp:HiddenField ID="hdnBatchID" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="4" class="heading" style="text-align: center">
                DEFINE JOINING TYPE
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td class="subhead" colspan="2">
                Joining Type <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtJoinType" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    &nbsp;
    <table align="center" class="tdcls">
        <tr>
            <td align="center" colspan="4">
                <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" OnClick="btnAdd_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gdvJoiningType" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                    OnDataBound="gdvJoiningType_DataBound" OnRowCommand="gdvJoiningType_RowCommand" CellSpacing="2">
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle  Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblJTID" runat="server" Text='<%#Bind("JTID")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Joining Type">
                            <ItemTemplate>
                                <asp:Label ID="lblJTName" runat="server" Text='<%#Bind("JTName")%>'></asp:Label>
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
