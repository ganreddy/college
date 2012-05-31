<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefineCoScholastic.aspx.cs" Inherits="CCE_DefineCoScholastic" Title="Define Co-Scholastic Area" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    function validate()
    {
    if(!isEmpty('<%=txtCoScholastic.ClientID%>',"Please Enter Co-Scholastic Area"))return false;
    }
    function Confirm()
        {
           var con=confirm("Do you want delete this Co-Scholastic Area?");
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


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
 <asp:UpdatePanel ID="upd" runat="server">
 <ContentTemplate>
     <table align="center" class="tdcls" width="50%">
         <tr>
             <td>
                 <asp:HiddenField ID="hdnCasteID" runat="server" />
             </td>
         </tr>
         <tr>
             <td colspan="2" class="heading" style="text-align: center">
                 DEFINE CO-SCHOLASTIC AREA
             </td>
         </tr>
         <tr>
             <td colspan="2">
                 &nbsp;
             </td>
         </tr>
         <tr>
             <td class="subhead" width="160px">
                 Co-Scholastic Area <span style="font-size: 10px; color: Red">*</span>
             </td>
             <td >
                 <asp:TextBox ID="txtCoScholastic" runat="server"></asp:TextBox>
             </td>
         </tr>
         
         <tr>
             <td colspan="2" align="center">
                 <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
             </td>
         </tr>
         <tr>
             <td align="center" colspan="2">
                 <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" OnClick="btnAdd_Click" />
             </td>
         </tr>
         <tr>
             <td align="center" colspan="2">
                 <asp:GridView ID="gdvCoScholastic" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                     CellSpacing="2" OnRowCommand="gdvCoScholastic_RowCommand" OnRowDataBound="gdvCoScholastic_RowDataBound">
                     <FooterStyle BackColor="#CCCCCC" />
                     <RowStyle CssClass="gridviewitem" />
                     <SelectedRowStyle Font-Bold="True" />
                     <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                     <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                     <Columns>
                         <asp:TemplateField Visible="false">
                             <ItemTemplate>
                                 <asp:Label ID="lblCoScholasticID" runat="server" Text='<%#Bind("CoScholasticID")%>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Co-Scholastic Area">
                             <ItemTemplate>
                                 <asp:Label ID="lblCoScholasticArea" runat="server" Text='<%#Bind("CoScholasticArea")%>'></asp:Label>
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

