<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefineMedium.aspx.cs" 
Inherits="Admin_DefineMedium" Title="Define Medium" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function validate()
    {
     if(! ValidateTextFormat('<%=txtMedium.ClientID%>',"Please Enter Medium"))return false;
    }
    function Confirm()
    {
        var con = confirm("Do You Want Delete This Medium");
     if(con==true){return true;}
     else{return false;}
    }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
    <ContentTemplate>
    
    
    <table align="center" class="tdcls" width="50%">
        <tr>
            <td>
                <asp:HiddenField ID="hdnMediumID" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="heading" style="text-align: center">
                DEFINE MEDIUM
            </td>
        </tr>
        <tr>
        <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="subhead" width="160px">
                Medium: <span style="font-size: 10px; color:#CC3300 ">*</span>
                <td>
                    <asp:TextBox ID="txtMedium" runat="server"></asp:TextBox>
                </td>
        </tr>
    </table>
    <table align="center" class="tdcls" >
        <tr>
        <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" onclick="btnAdd_Click"  
                     />&nbsp;&nbsp;&nbsp;
                
            </td>
        </tr>
        <tr><td></td></tr>
        <tr><td><asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label></td></tr>
        <tr><td></td></tr>
        <tr><td></td></tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gdvMedium"  runat="server" 
                    AutoGenerateColumns="False" BackColor="#CCCCCC" CellSpacing="2" 
                    onrowcommand="gdvMedium_RowCommand" onrowdatabound="gdvMedium_RowDataBound" >
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle CssClass="gridviewitem" />
                    <SelectedRowStyle Font-Bold="true" />
                    <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                    <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="true" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField Visible="false">
                       <ItemTemplate>
                       <asp:Label ID="lblMediumID" runat="server" Text='<%#Bind("MediumID") %>'></asp:Label>
                       </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Medium">
                       <ItemTemplate>
                       <asp:Label ID="lblLanguage" runat="server" Text='<%#Bind("Language") %>'></asp:Label>
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

