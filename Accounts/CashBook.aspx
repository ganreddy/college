<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CashBook.aspx.cs" Inherits="Accounts_CashBook" Title="Cash Book" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        
        function validate() 
        {
            if (! isDateFormat('<%=txtDate.ClientID%>', "Please Enter Date")) return false;
            if (! isEmpty('<%=txtVoucherNo.ClientID%>', "Please Enter Voucher No")) return false;
            if(! DropdownValidate('<%=ddlFund.ClientID%>',"Please Select Fund Type"))return false;
               var rdbReciept=document.getElementById('<%=rdbReciept.ClientID%>').checked;
               var rdbPayment=document.getElementById('<%=rdbPayment.ClientID%>').checked;
               if((rdbReciept==false) && (rdbPayment==false))
               {
               alert("Please Select Transaction Type");
               return false;
               }
               
               var rdbPlan=document.getElementById('<%=rdbPlan.ClientID%>').checked;
               var rdbNPlan=document.getElementById('<%=rdbNPlan.ClientID%>').checked;
               if((rdbPlan==false) && (rdbNPlan==false))
               {
               alert("Please Select Planned/Non-Planned");
               return false;
               }
             if (! isEmpty('<%=txtParticulars.ClientID%>', "Please Enter Particulars")) return false;
             if (! isEmpty('<%=txtLedgerFolio.ClientID%>', "Please Enter Ledger Folio")) return false;
                var rdbBank=document.getElementById('<%=rdbBank.ClientID%>').checked;
                var rdbImprest=document.getElementById('<%=rdbImprest.ClientID%>').checked;
               if((rdbBank==false) && (rdbImprest==false))
               {
               alert("Please Select Cash Type");
               return false;
               }
               if (! isDecimal('<%=txtCash.ClientID%>', "Please Enter Cash")) return false;
               
             if (! isEmpty('<%=txtRemarks.ClientID%>', "Please Enter Remarks")) return false;
             }
     function allowNum()
     {
          if((event.keyCode>47 && event.keyCode<58) ||(event.keyCode==46))
          {
             event.keyCode=event.keyCode;
          }
          else
          {
             event.keyCode=0;
          }
     }
     function calc()
     {
     
         if(document.getElementById('<%=rdbReciept.ClientID%>').checked)
         {
             if(document.getElementById('<%=rdbBank.ClientID%>').checked)
             {
                if(document.getElementById('<%=txtCash.ClientID%>').value!="")
                {
                 document.getElementById('<%=lblImprestCB.ClientID%>').innerText=  parseFloat(document.getElementById('<%=lblImprestOB.ClientID%>').innerText);
                 document.getElementById('<%=lblBankCB.ClientID%>').innerText= parseFloat(document.getElementById('<%=txtCash.ClientID%>').value) + parseFloat(document.getElementById('<%=lblBankOB.ClientID%>').innerText);
                }
             }
             if(document.getElementById('<%=rdbImprest.ClientID%>').checked)
             {
                if(document.getElementById('<%=txtCash.ClientID%>').value!="")
                {
                  document.getElementById('<%=lblBankCB.ClientID%>').innerText=parseFloat(document.getElementById('<%=lblBankOB.ClientID%>').innerText) ;
                  document.getElementById('<%=lblImprestCB.ClientID%>').innerText=  parseFloat(document.getElementById('<%=lblImprestOB.ClientID%>').innerText) + parseFloat(document.getElementById('<%=txtCash.ClientID%>').value);
                }
             }
         } 
         
         
         
          if(document.getElementById('<%=rdbPayment.ClientID%>').checked)
             {
                if(document.getElementById('<%=rdbImprest.ClientID%>').checked)
                {
                  if(document.getElementById('<%=txtCash.ClientID%>').value!="")
                  {
                  document.getElementById('<%=lblBankCB.ClientID%>').innerText=parseFloat(document.getElementById('<%=lblBankOB.ClientID%>').innerText);
                  document.getElementById('<%=lblImprestCB.ClientID%>').innerText=  parseFloat(document.getElementById('<%=lblImprestOB.ClientID%>').innerText) - parseFloat(document.getElementById('<%=txtCash.ClientID%>').value);
                 }
               }
               if(document.getElementById('<%=rdbBank.ClientID%>').checked)
                {
                  if(document.getElementById('<%=txtCash.ClientID%>').value!="")
                  {
                  document.getElementById('<%=lblBankCB.ClientID%>').innerText=parseFloat(document.getElementById('<%=lblBankOB.ClientID%>').innerText)- parseFloat(document.getElementById('<%=txtCash.ClientID%>').value);
                  document.getElementById('<%=lblImprestCB.ClientID%>').innerText=  parseFloat(document.getElementById('<%=lblImprestOB.ClientID%>').innerText) ;
                 }
               }
         }   
         
                   
         if(document.getElementById('<%=lblBankCB.ClientID%>').innerText!= "")
          {
             document.getElementById('<%=lblTotalCB.ClientID%>').innerText =  parseFloat(document.getElementById('<%=lblBankCB.ClientID%>').innerText) + parseFloat(document.getElementById('<%=lblImprestCB.ClientID%>').innerText);
          }
            
    }
     </script>
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>
    <div align="center">
        <table align="center" class="tdcls" align="center" width="80%" cellpadding="3">
            <tr>
                <td class="heading" colspan="2" style="text-align: center">
                    CSAH BOOK 
                </td>
            </tr>
            <tr>
              <td class="heading" colspan="2" style="text-align: center" >
                  OPENING BALANCE
              </td>
            </tr>
           <tr>
                <td class="subhead" style="width: 39%">
                    Bank:
                </td>
                <td class="tdcls" valign="top" nowrap style="width: 39%">
                    <asp:Label ID="lblBankOB" runat="server" CssClass="txtcls"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="subhead" style="width: 39%">
                    Imprest:
                </td>
                <td class="tdcls" valign="top" nowrap style="width: 39%">
                    <asp:Label ID="lblImprestOB" runat="server" CssClass="txtcls"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="subhead" style="width: 39%">
                    Total:
                </td>
                <td class="tdcls" valign="top" nowrap style="width: 39%">
                    <asp:Label ID="lblTotalOB" runat="server" CssClass="txtcls"></asp:Label>
                </td>
            </tr>
            <tr>
              <td class="heading" colspan="2" style="text-align: center" >
                  CURRENT TRANSACTION DETAILS
              </td>
            </tr>
            <tr>
                <td class="subhead" style="width: 39%">
                    Date:<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td class="tdcls" valign="top" nowrap style="width: 39%">
                    <asp:TextBox ID="txtDate" runat="server" CssClass="txtcls"></asp:TextBox>
                   <%-- <img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        runat="server" id="imgcal">--%>
                        <asp:ImageButton alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        runat="server" id="imgcal"/>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate"
                        PopupButtonID="imgcal" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
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
                    Fund Type<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td style="width: 39%">
                    <asp:DropDownList ID="ddlFund" runat="server" CssClass="txtcls" Height="19px" 
                        Width="200px" onselectedindexchanged="ddlFund_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem>---Select---</asp:ListItem>
                        <asp:ListItem>xxx</asp:ListItem>
                        <asp:ListItem>yyy</asp:ListItem>
                        <asp:ListItem>zzz</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead" style="width: 39%">
                    Head
                </td>
                <td style="width: 39%">
                    <asp:DropDownList ID="ddlHead" runat="server" CssClass="txtcls" Height="19px" 
                        Width="200px" onselectedindexchanged="ddlHead_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem>---Select---</asp:ListItem>
                        <asp:ListItem>xxx</asp:ListItem>
                        <asp:ListItem>yyy</asp:ListItem>
                        <asp:ListItem>zzz</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead" style="width: 39%">
                    Sub Head                 </td>
                <td style="width: 39%">
                    <asp:DropDownList ID="ddlSubhead" runat="server" CssClass="txtcls" Height="23px"
                        Width="200px">
                        <asp:ListItem>---Select---</asp:ListItem>
                        <asp:ListItem>aaa</asp:ListItem>
                        <asp:ListItem>bbb</asp:ListItem>
                        <asp:ListItem>ccc</asp:ListItem>
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
                    Planned/Non-Planned<span style="font-size: 10px; color: Red">*</span></td>
                <td class="subhead">
                    <asp:RadioButton ID="rdbPlan" runat="server" Text="Planned" GroupName="plan" />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdbNPlan" runat="server" Text="Non-Planned"
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
                    Cash:<span style="font-size: 10px; color: Red">*</span><asp:RadioButton ID="rdbBank" runat="server" Text="Bank" GroupName="cash" />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdbImprest" runat="server" Text="Imprest" GroupName="cash" />
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
            <tr>
              <td class="heading" colspan="2" style="text-align: center" >
                  BALANCE AFTER TRANSACTION
              </td>
             
            </tr>
            <tr>
                <td class="subhead" style="width: 39%">
                    Bank:
                </td>
                <td class="tdcls" valign="top" nowrap style="width: 39%">
                    <asp:Label ID="lblBankCB" runat="server" CssClass="txtcls"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="subhead" style="width: 39%">
                    Imprest:
                </td>
                <td class="tdcls" valign="top" nowrap style="width: 39%">
                    <asp:Label ID="lblImprestCB" runat="server" CssClass="txtcls"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="subhead" style="width: 39%">
                    Total:
                </td>
                <td class="tdcls" valign="top" nowrap style="width: 39%">
                    <asp:Label ID="lblTotalCB" runat="server" CssClass="txtcls"></asp:Label>
                </td>
            </tr>
            
        </table>
        <table align="center" class="tdcls">
            <tr>
                <td style="text-align: center;" colspan="2">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
