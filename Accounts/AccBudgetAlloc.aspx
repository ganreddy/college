<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AccBudgetAlloc.aspx.cs" Inherits="Accounts_AccBudgetAlloc" Title="Budget Allocation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() {
            if (!isDecimal('<%=txtBudget.ClientID%>', "Please Enter The Numeric Value For Budget Amount")) return false;
            if (!isDecimal('<%=txtImprest.ClientID%>', "Please Enter The Numeric Value For Imprest Amount")) return false;

        }
 
 
        function Confirm() {
            var con = confirm("Do You Want Delete This Amount ?");
            if (con == true) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="udpNewProc" runat="server">
    <ContentTemplate>
    
    <table align="center" class="tdcls" width="70%">
        <tr>
            <td colspan="2" class="heading">
                BUDGET ALLOCATION
            </td>
        </tr>
        
         <tr>
                        <td colspan="2">
                            <asp:HiddenField ID="hdnBudgetAllocation" runat="server" />
                        </td>
                    </tr>
        <tr>
            <td class="subhead" nowrap style="width: 39%">
                Financial Year: <span style="font-size: 14px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlFinancialYear" runat="server" Height="16px" Width="154px">
                
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead" style="width: 39%">
                 Budget Amount:<span style="font-size: 14px; color: Red">*</span>&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtBudget" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  class="subhead" style="width: 39%">
                Imprest: <span style="font-size: 14px; color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtImprest" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
        <td style="text-align: center;" colspan="2">
          <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
        </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click"  />
                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
                        <td align="center" colspan="2">
                            <asp:GridView ID="gdvBudgetAllocation" runat="server" 
                                AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" onrowcommand="gdvBudgetAllocation_RowCommand" 
                                onrowdatabound="gdvBudgetAllocation_RowDataBound" >
                              
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblYearID" runat="server" Text='<%#Bind("YearID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Financial Year">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFinancialYear" runat="server" Text='<%#Bind("FinancialYear")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Budget Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBudgetAmount" runat="server" Text='<%#Bind("Budget")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Imprest">
                                        <ItemTemplate>
                                            <asp:Label ID="lblImprest" runat="server" Text='<%#Bind("Imprest")%>'></asp:Label>
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

