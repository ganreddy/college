<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="StaffApplyForLoan.aspx.cs" Inherits="StaffApplyForLoan" Title="Staff Loans" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function validate() 
        {
            if (!DropdownValidate('<%=ddlStaffName.ClientID%>', "Please Select Staff Name")) return false;
            if (!DropdownValidate('<%=ddlLoanType.ClientID%>', "Please Select Loan Type")) return false;
            if (!isEmpty('<%=txtDate.ClientID%>', "Please Enter  Date")) return false;
            if (document.getElementById('<%=txtDate.ClientID%>').value != "") {
                if (!isDateFormat('<%=txtDate.ClientID%>', "Date Format Should Be DD/MM/YYYY")) return false;
            }
            if (!isDecimal('<%=txtAmountSanctioned.ClientID%>', "Please Enter Amount in Decimal")) return false;
            if (!isNumeric('<%=txtNoOfInstallments.ClientID%>', "Please Enter Number Of Installments")) return false;
            if (!isDecimal('<%=txtFirstInstallment.ClientID%>', "Please Enter First Installment")) return false;
            if (!isDecimal('<%=txtSecondInstallment.ClientID%>', "Please Enter Second Installment")) return false;

            //     if(! isNumeric('<%=txtRemainingInstallments.ClientID%>',"Please Enter  RemainingInstallments"))return false;
            var FullPaid = document.getElementById('<%=rbtnLoanFullyPaid.ClientID%>').checked;
            var NotPaid = document.getElementById('<%=rbtnNotfullypaid.ClientID%>').checked;
            var PartiallyPaid = document.getElementById('<%=rbtnPartlypaid.ClientID%>').checked;
            if ((FullPaid) == false && (NotPaid) == false && (PartiallyPaid) == false) 
            {
                alert("Please Check Radio Button of FullyPaid/NotPaid/PartiallyPaid");
                return false;
            }
            if (!isDateFormat('<%=txtAmountRecoveryStartingDate.ClientID%>', "Please Enter  Amount Recovery Starting Date")) return false;
            if (!isEmpty('<%=txtAmountPaidDate.ClientID%>', "Please Enter Amount Paid Date")) return false;
            if (document.getElementById('<%=txtAmountPaidDate.ClientID%>').value != "") {
                if (!isDateFormat('<%=txtAmountPaidDate.ClientID%>', "Date Format Should Be DD/MM/YYYY")) return false;
            }
            if (!DropdownValidate('<%=ddlAuthorizedBy.ClientID%>', "Please Select Authorized By")) return false;
        }
     function Calculation() 
     {
         var Amount = 0, Noofinstallments = 0,First = 0,Second = 0,Remaining = 0,Remaining1 = 0,Noof1 = 0;
         if (document.getElementById('<%=txtAmountSanctioned.ClientID%>').value != "") {
             Amount = parseFloat(document.getElementById('<%=txtAmountSanctioned.ClientID%>').value);
         }
         if (document.getElementById('<%=txtNoOfInstallments.ClientID%>').value != "") {
             Noofinstallments=parseInt(document.getElementById('<%=txtNoOfInstallments.ClientID%>').value);
         }
         if(document.getElementById('<%=txtFirstInstallment.ClientID%>').value!="") {
            First=parseFloat(document.getElementById('<%=txtFirstInstallment.ClientID%>').value);
         }
         if(document.getElementById('<%=txtSecondInstallment.ClientID%>').value!="") {
            Second=parseFloat(document.getElementById('<%=txtSecondInstallment.ClientID%>').value);
        }
        Remaining = parseFloat(First + Second);
        Noof1 = parseFloat(Noofinstallments - 2);
         Remaining1 = parseFloat((Amount - Remaining) / (Noof1));
         if (document.getElementById('<%=txtRemainingInstallments.ClientID%>')) {
            document.getElementById('<%=txtRemainingInstallments.ClientID%>').value=parseFloat(Remaining1);
         }
     }
    </script>
     
    
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
    <div>
        <table align="center" class="tdcls" style="width: 576px">
            <tr>
                <td colspan="2" >
                    <asp:HiddenField ID="Message" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="heading" colspan="4" >
                    STAFF &nbsp;&nbsp;LOANS&nbsp;
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Staff Name <span style="font-size: 12px; color: Red">*</span>
                </td>
                <td >
                    <asp:DropDownList ID="ddlStaffName" runat="server" AutoPostBack="false" 
                        CssClass="txtcls" Width="154px">
                        <asp:ListItem>select</asp:ListItem>
                        <asp:ListItem>aaaa</asp:ListItem>
                        
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead" >
                    Loan Type<span style="font-size: 12px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlLoanType" runat="server" CssClass="txtcls" Width="154px"> 
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>bbb</asp:ListItem>
                       
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Date <span style="font-size: 12px; color: Red">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" CssClass="txtcls"></asp:TextBox>
                    
                        <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16" id="imgcal">--%>
                        <asp:ImageButton runat="server" alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16" id="imgcal"/>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" PopupButtonID="imgcal" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="heading" colspan="4"  valign="top">
                    LOAN DETAILS&nbsp;
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Amount Sanctioned<span style="font-size: 12px; color: Red">*</span>
                </td>
                <td class="tdcls" colspan="2" valign="top">
                    <asp:TextBox ID="txtAmountSanctioned" runat="server" CssClass="txtcls" ></asp:TextBox>
 
                                      </td>
            </tr>
            <tr>
                <td class="subhead"  valign="top">
                    Number of Installments<span style="font-size: 12px; color: Red">*</span>
                </td>
                <td class="tdcls"  >
                    <asp:TextBox ID="txtNoOfInstallments" runat="server" CssClass="txtcls"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="subhead"  >
                    First Installment <span style="font-size: 12px; color: Red">*</span>
                </td>
                <td class="tdcls"  >
                    <asp:TextBox ID="txtFirstInstallment" runat="server" CssClass="txtcls"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="subhead" >
                    Second Installment <span style="font-size: 12px; color: Red">*</span>
                </td>
                <td class="tdcls"  valign="top">
                    <asp:TextBox ID="txtSecondInstallment" runat="server" CssClass="txtcls"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Remaining Installments <span style="font-size: 12px; color: Red">*</span>
                </td>
                <td class="tdcls" valign="top">
                    <asp:TextBox ID="txtRemainingInstallments" runat="server" CssClass="txtcls" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Loan Details <span style="font-size: 12px; color: Red">*</span>
                </td>
                <td nowrap>
                    <asp:RadioButton ID="rbtnLoanFullyPaid" runat="server" Text="Fully Paid" 
                        GroupName="Loan Details" />
               
                    &nbsp;
               
                    <asp:RadioButton ID="rbtnNotfullypaid" runat="server" Text="Not Paid" 
                        GroupName="Loan Details" />
               
               
                    &nbsp;
               
               
                    <asp:RadioButton ID="rbtnPartlypaid" runat="server" Text="Partly Paid" 
                        GroupName="Loan Details" />
                </td>
            </tr>
            
            <tr>
                <td class="subhead" nowrap>
                    Amount Recovery Starting Date:<span style="font-size: 12px; color: Red">*</span>
                </td>
                <td class="tdcls"  nowrap>
                    <asp:TextBox ID="txtAmountRecoveryStartingDate" runat="server" CssClass="txtcls"></asp:TextBox>
                    
                        <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16" id="imgcal1">--%>
                        <asp:ImageButton runat="server"  alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16" id="imgcal1"/>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtAmountRecoveryStartingDate" PopupButtonID="imgcal1" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Amount Paid Date<span style="font-size: 12px; color: Red">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtAmountPaidDate" runat="server" CssClass="txtcls"></asp:TextBox>
                    <asp:ImageButton runat="server"  alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16" id="ImageButton1"/>
                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtAmountPaidDate" PopupButtonID="ImageButton1" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Authorized By <span style="font-size: 12px; color: Red">*</span>
                </td>
                <td class="tdcls" >
                    <asp:DropDownList ID="ddlAuthorizedBy" runat="server" CssClass="txtcls" Width="154px">
                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                    <asp:ListItem Value="1" >Principal</asp:ListItem>
                                <asp:ListItem Value="2">Vice Principal</asp:ListItem>
                                 <asp:ListItem Value="3">In-Charge</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Remarks
                    <td class="tdcls" colspan="2" valign="top">
                    <asp:TextBox ID="txtRemarksDescrption" runat="server" CssClass="txtcls" TextMode="MultiLine"
                        Width="154px"></asp:TextBox>
                </td>
                    </td>
            </tr>
            <tr>
            <td align="center" colspan="2">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            </td>
            </tr>
            </table>
        <table align="center" class="tdcls">
            <tr>
                <td style="text-align: center;" colspan="2">
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                    &nbsp; 
                   
                </td>
            </tr>
            <tr>
                <td align="center" >
                   <%-- <asp:GridView ID="dgridList" runat="server" AutoGenerateColumns="False" DataKeyNames="NAME">
                        <Columns>
                            <asp:BoundField DataField="NAME" HeaderText="Name" />
                            <asp:BoundField DataField="Date" HeaderText="Date" />
                            <asp:BoundField DataField="AMT" HeaderText="Amount Sanctioned" />
                            <asp:BoundField DataField="MAX" HeaderText=" Number of Installments" />
                        </Columns>
                    </asp:GridView>--%>
                </td>
            </tr>
        </table>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
