<%@ Page Title="Unit Of Measurement" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="unitOfMeasurement.aspx.cs" Inherits="Admin_unitOfMeasurement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function validation() {
            if (!isEmpty('<%=txtUnit.ClientID%>', "Please Enter Unit Of Measurement")) return false;
        }
        function Confirm() 
        {
            var con = confirm("Do You Want Delete This Measurement?");
            if (con == true) 
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
                 <asp:HiddenField ID="hdnUomID" runat="server" />
             </td>
         </tr>
         <tr>
             <td colspan="2" class="heading" style="text-align: center">
                 DEFINE UNIT OF MEASUREMENT
             </td>
         </tr>
         <tr>
             <td colspan="2">
                 &nbsp;
             </td>
         </tr>
         <tr>
             <td class="subhead" width="160px">
                 Unit Of Measurement <span style="font-size: 10px; color: Red">*</span>
             </td>
             <td >
                 <asp:TextBox ID="txtUnit" runat="server"></asp:TextBox>
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
                 <asp:GridView ID="gdvUnit" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="8"
                     BackColor="#CCCCCC" CellSpacing="2" onrowdatabound="gdvUnit_RowDataBound" 
                     onpageindexchanging="gdvUnit_PageIndexChanging" 
                     onrowcommand="gdvUnit_RowCommand">
                     <FooterStyle BackColor="#CCCCCC" />
                     <RowStyle CssClass="gridviewitem" />
                     <SelectedRowStyle Font-Bold="True" />
                     <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                     <HeaderStyle BackColor="#739bcf" CssClass="gridviewheader" Font-Bold="True" 
                         ForeColor="White" />
                     <Columns>
                         <asp:TemplateField Visible="false">
                             <ItemTemplate>
                                 <asp:Label ID="lblUomId" runat="server" Text='<%#Bind("UOMID")%>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Unit Of Measurement">
                             <ItemTemplate>
                                 <asp:Label ID="lblUom" runat="server" Text='<%#Bind("UOMName")%>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField>
                             <ItemTemplate>
                                 <asp:LinkButton ID="lnkEdit" runat="server" CommandName="editing" Text="Edit"></asp:LinkButton>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField>
                             <ItemTemplate>
                                 <asp:LinkButton ID="lnkDelete" runat="server" CommandName="del" Text="Delete"></asp:LinkButton>
                             </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
                 </asp:GridView>
             </td>
         </tr>
         <tr>
             <td align="center" colspan="2">
                 &nbsp;</td>
         </tr>
     </table>
   </ContentTemplate>
   </asp:UpdatePanel>

</asp:Content>

