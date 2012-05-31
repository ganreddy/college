<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EditCashBook.aspx.cs" Inherits="Accounts_EditCashBook" Title="Edit CashBook" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/jscript" language="javascript">
    function validate()
    {
     var Reciept=document.getElementById('<%=rdbReciept.ClientID%>').checked;
     var Payment=document.getElementById('<%=rdbPayment.ClientID%>').checked;
     if((Reciept==false)&& (Payment==false))
     {
     alert("choose the radio button of Reciept/Payment");
     return false;
     }
     var Plan=document.getElementById('<%=rdbPlan.ClientID%>').checked;
     var NonPlan=document.getElementById('<%=rdbNPlan.ClientID%>').checked;
     if((Plan==false)&& (NonPlan==false))
     {
     alert("choose the radio button of Plan/NonPlan");
     return false;
     }
     var Bank=document.getElementById('<%=rdbBank.ClientID%>').checked;
     var Imprest=document.getElementById('<%=rdbImprest.ClientID%>').checked;
     if((Bank==false)&& (Imprest==false))
     {
     alert("choose the radio button of Bank/Imprest");
     return false;
     }
    }
    </script>
 <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
   
    <div align="center">
        <table align="center" class="tdcls" align="center" width="80%" cellpadding="3">
            <tr>
                <td class="heading" colspan="2" style="text-align: center">
                    EDIT CASH BOOK
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:HiddenField ID="hdnEditAccountCashBook" runat="server" />
                    <asp:HiddenField ID="hdnFundType" runat="server" />          
                    <asp:HiddenField ID="hdnHead" runat="server" />            
                    <asp:HiddenField ID="hdnSubHead" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="subhead" style="width: 39%">
                    Date:<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td class="tdcls" valign="top" nowrap style="width: 39%">
                    <asp:TextBox ID="txtDate" runat="server" CssClass="txtcls"></asp:TextBox>
                    <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        runat="server" id="img">--%>
                        <asp:ImageButton alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        runat="server" id="img"/>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img" TargetControlID="txtDate"
                        Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />
                </td>
            </tr>
            <asp:Panel ID="panel1" runat="server" Visible="false">
                <tr>
                    <td class="subhead" style="width: 39%">
                        Voucher No:<span style="font-size: 10px; color: Red">*</span>
                    </td>
                    <td class="tdcls" valign="top" nowrap style="width: 39%">
                        <asp:TextBox ID="txtVoucherNo" runat="server" CssClass="txtcls"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="width: 39%">
                        Fund Type
                    </td>
                    <td style="width: 39%">
                        <asp:DropDownList ID="ddlFund" runat="server" CssClass="txtcls" Height="19px" Width="200px"
                            AutoPostBack="true" onselectedindexchanged="ddlFund_SelectedIndexChanged">
                            <asp:ListItem>---Select---</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="width: 39%">
                        Head
                    </td>
                    <td style="width: 39%">
                        <asp:DropDownList ID="ddlHead" runat="server" CssClass="txtcls" Height="19px" Width="200px"
                            AutoPostBack="true" onselectedindexchanged="ddlHead_SelectedIndexChanged">
                            <asp:ListItem>---Select---</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="width: 39%">
                        Sub Head
                    </td>
                    <td style="width: 39%">
                        <asp:DropDownList ID="ddlSubhead" runat="server" CssClass="txtcls" Height="23px"
                            Width="200px">
                            <asp:ListItem>---Select---</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="width: 39%">
                        Transaction Type<span style="font-size: 10px; color: Red">*</span>
                    </td>
                    <td style="width: 39%" class="subhead">
                        <asp:RadioButton ID="rdbReciept" runat="server" Text="Reciept" GroupName="trans" />
                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdbPayment" runat="server" Text="Payment"
                            GroupName="trans" />
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="width: 39%">
                        Planned/Non-Planned
                    </td>
                    <td class="subhead">
                        <asp:RadioButton ID="rdbPlan" runat="server" Text="Planned" GroupName="plan" />
                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdbNPlan" runat="server" Text="NonPlanned"
                            GroupName="plan" />
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="width: 39%">
                        Particulars<span style="font-size: 10px; color: Red">*</span>
                    </td>
                    <td class="tdcls" colspan="2" valign="top" style="width: 39%">
                        <asp:TextBox ID="txtParticulars" runat="server" CssClass="txtcls" TextMode="MultiLine"
                            Width="154px" Rows="4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="width: 39%">
                        Ledger Folio:<span style="font-size: 10px; color: Red">*</span>
                    </td>
                    <td class="tdcls" valign="top" nowrap style="width: 39%">
                        <asp:TextBox ID="txtLedgerFolio" runat="server" CssClass="txtcls"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="width: 39%">
                        Cash:<span style="font-size: 10px; color: Red">*</span><asp:RadioButton ID="rdbBank"
                            runat="server" Text="Bank" GroupName="cash" />
                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdbImprest" runat="server" Text="Imprest"
                            GroupName="cash" />
                    </td>
                    <td class="tdcls" valign="top" nowrap style="width: 39%">
                        <asp:TextBox ID="txtCash" runat="server" CssClass="txtcls"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="width: 39%">
                        Remarks:<span style="font-size: 10px; color: Red">*</span>
                    </td>
                    <td class="tdcls" valign="top" nowrap style="width: 39%">
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtcls"></asp:TextBox>
                    </td>
                </tr>
            </asp:Panel>
        </table>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="gdvEditCashBook" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                    CellSpacing="2" Visible="false" OnRowCommand="gdvEditCashBook_RowCommand" OnRowDataBound="gdvEditCashBook_RowDataBound">
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle CssClass="gridviewitem" />
                    <SelectedRowStyle Font-Bold="True" />
                    <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                    <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblTransactionID" runat="server" Text='<%#Bind("TransactionID")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="VoucherNo">
                            <ItemTemplate>
                                <asp:Label ID="lblVoucherNo" runat="server" Text='<%#Bind("VoucherNo")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblFundTypeID" runat="server" Text='<%#Bind("FundType")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FundType">
                            <ItemTemplate>
                                <asp:Label ID="lblFundType" runat="server" Text='<%#Bind("FundName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblHeadID" runat="server" Text='<%#Bind("Head")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>   
                        <asp:TemplateField HeaderText="Head">
                            <ItemTemplate>
                                <asp:Label ID="lblHead" runat="server" Text='<%#Bind("HeadName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblSubHeadID" runat="server" Text='<%#Bind("SubHead")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>   
                        
                        <asp:TemplateField HeaderText="SubHead">
                            <ItemTemplate>
                                <asp:Label ID="lblSubHead" runat="server" Text='<%#Bind("SubHeadName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TransactionType">
                            <ItemTemplate>
                                <asp:Label ID="lblTransactionType" runat="server" Text='<%#Bind("TransactionType")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PlanNonPlan">
                            <ItemTemplate>
                                <asp:Label ID="lblPlanNonPlan" runat="server" Text='<%#Bind("PlanNonPlan")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Particulars">
                            <ItemTemplate>
                                <asp:Label ID="lblParticulars" runat="server" Text='<%#Bind("Particulars")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LedgerFolio">
                            <ItemTemplate>
                                <asp:Label ID="lblLedgerFolio" runat="server" Text='<%#Bind("LedgerFolio")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CashType">
                            <ItemTemplate>
                                <asp:Label ID="lblCashType" runat="server" Text='<%#Bind("CashType")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cash">
                            <ItemTemplate>
                                <asp:Label ID="lblCash" runat="server" Text='<%#Bind("Cash")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks">
                            <ItemTemplate>
                                <asp:Label ID="lblRemarks" runat="server" Text='<%#Bind("Remarks")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="editing"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="del"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <table align="center" class="tdcls">
            <tr>
                <td style="text-align: center;" colspan="2">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="2">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnSave_Click" Visible="false" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
