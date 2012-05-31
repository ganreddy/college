<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefineHouse.aspx.cs" Inherits="Admin_DefineStudentHouse" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
     <script src="../scripts/Validations.js" type="text/javascript"></script>
     <script type="text/javascript" language="javascript">
    function validate()
    {
        if (!ValidateTextFormat('<%=txtHouse.ClientID%>', "Please Enter House")) return false;
    }
     function Confirm()
        {
            var con = confirm("Do You Want Delete This House ?");
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
                         <asp:HiddenField ID="hdnHouseID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="heading" colspan="2" style="text-align: center">
                        HOUSE ALLOTED
                    </td>
                </tr>
                 <tr>
                         <td colspan="2">
                             &nbsp;
                         </td>
                     </tr>
                      <tr>
                        <td class="subhead" width="160px">
                            House Name <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtHouse" runat="server"></asp:TextBox>
                        </td>
                     </tr>
                     <tr>
                        <td colspan="2" align="center">
                             <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                         </td>
                     </tr>
                      <tr>
                         <td align="center" colspan="2">
                             <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" 
                                 onclick="btnAdd_Click" />
                         </td>
                     </tr>
                     <tr>
                        <td align="center" colspan="2">
                            <asp:GridView ID="gdvHouse" runat="server" AutoGenerateColumns="false"
                            BackColor="#CCCCCC" CellSpacing="2" onrowcommand="gdvHouse_RowCommand" 
                                onrowdatabound="gdvHouse_RowDataBound" >
                            <FooterStyle BackColor="#CCCCCC" />
                                 <RowStyle CssClass="gridviewitem" />
                                 <SelectedRowStyle Font-Bold="True" />
                                 <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                 <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                 <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHouseID" runat="server" Text='<%#Bind("HouseID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="House Name"> 
                                        <ItemTemplate>
                                            <asp:Label ID="lblHouseName" runat="server" Text='<%#Bind("HouseName")%>'></asp:Label>
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

