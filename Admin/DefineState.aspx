<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
CodeFile="DefineState.aspx.cs" Inherits="Admin_DefineState" Title="Define State" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function validate()
    {
     if(! ValidateTextFormat('<%=txtState.ClientID%>',"Please Enter State"))return false;
    }
    function Confirm()
        {
            var con = confirm("Do You Want Delete This State ?");
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
    <table align="center" class="tdcls" width="50%">
        <tr>
            <td style="width: 200px">
                <asp:HiddenField ID="hdnStateID" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="heading" style="text-align: center">
                DEFINE STATE
            </td>
        </tr>
       
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="subhead" style="width: 200px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                State <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td style="width: 200px">&nbsp;</td>
        <td>&nbsp;</td>
        </tr>
    
        <tr>
        
            <td align="left" style="width: 200px" >
                
                   
            </td>
            <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" 
                    onclick="btnAdd_Click"  /></td>
        </tr>
         <tr>
         <td  align="right" style="width: 200px">
                            &nbsp;</td>
                    <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                        </td>
                        
                    </tr>
        
        <tr>
        
            <td align="center" colspan="2">
        <asp:GridView ID="gdvState" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" OnRowCommand="gdvState_RowCommand" 
                    OnRowDataBound="gdvState_RowDataBound" AllowPaging="true" PageSize="10" 
                    onpageindexchanging="gdvState_PageIndexChanging">
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStateID" runat="server" Text='<%#Bind("StateID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStateName" runat="server" Text='<%#Bind("StateName")%>'></asp:Label>
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

