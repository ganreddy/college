<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SetStaffLeaves.aspx.cs" Inherits="SetStaffLeaves" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function validate()
    {
   
    if(! DropdownValidate('<%=ddlStaffName.ClientID%>',"Please Select StaffName"))return false;
    if(! DropdownValidate('<%=ddlLeaveNameDefineLeaves.ClientID%>',"Please Select Leaves Type"))return false;
    if(! isEmpty('<%=txtMaxNoLeavesAllowedDefineLeaves.ClientID%>',"Please Enter Max No Of Leaves"))return false;
      if(document.getElementById('<%=txtMaxNoLeavesAllowedDefineLeaves.ClientID %>').value!="")
        {
           if(! ZipCode('<%=txtMaxNoLeavesAllowedDefineLeaves.ClientID %>',"Please Enter Correct Leaves")) return false;
        }
////        if(! isEmpty('<%=txtReasonDefileLeaves.ClientID%>',"Please Enter Reason"))return false;
////      if(document.getElementById('<%=txtReasonDefileLeaves.ClientID %>').value!="")
////        {
////           if(! ValidateTextFormat('<%=txtReasonDefileLeaves.ClientID %>',"Please Enter Correct Reason")) return false;
////        }
        
        
        
     var Avilable=document.getElementById('<%=rbtnBalAvialableDefileLeaves1.ClientID%>').checked;
     
     var Deposit=document.getElementById('<%=rbtnBalDepositDefileLeaves2.ClientID%>').checked;
     var Balance=document.getElementById('<%=rbtnBalanceDefileLeaves3.ClientID%>').checked;
     if((Avilable==false)&& (Deposit==false)&&(Balance==false))
     {
     alert("Choose Any One Radio Button");
     return false;
     }
        
     }
       
    
    
    
    </script>
   <asp:ScriptManager ID="sct" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
    

    
    <div>
        <table align="center" class="tdcls" style="width: "90%">
            <tr>
                <td style="height: 33px">
                    <asp:HiddenField ID="Message" runat="server" />
                </td>
            <tr>
                <td class="heading" colspan="4" style="text-align: center;" >
                    DEFINE LEAVES
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 39%" class="subhead" >
                    Staff Name<span style ="font-size:14px;color:Red">&nbsp;*</td>
                    <td style="width: 39%">
                        <asp:DropDownList ID="ddlStaffName" runat="server" Height="29px" Width="137px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>er</asp:ListItem>
                        </asp:DropDownList>
                                                        </td>
            </tr>
            <tr>
                <td style="width: 39%" class="subhead" >
                    Leave Type
                <span style="font-size:14px;color:Red">*</span></td>
                <td style="width: 39%">
                    <asp:DropDownList ID="ddlLeaveNameDefineLeaves" runat="server" Width="139px">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>qw</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 39%" nowrap  class="subhead">
                    Max No of Leaves Allowed
                <span style="font-size:14px;color:Red">*</span></td>
                <td style="width: 39%">
                    <asp:TextBox ID="txtMaxNoLeavesAllowedDefineLeaves" runat="server" >
                        </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 39%" nowrap class="subhead">
                    Balanace Of Leaves
                <span style="font-size:14px;color:Red">*</span></td>
                <td  style="width: 29%">
                    <asp:RadioButton ID="rbtnBalAvialableDefileLeaves1" runat="server" name="Avilable" value="1"
                        Text="Avilable" GroupName="BalanceOfLeaves" />
                
                    <asp:RadioButton ID="rbtnBalDepositDefileLeaves2" runat="server" Text="Deposit" input type="radio" value="2"
                        GroupName="BalanceOfLeaves" />
                
               
                    <asp:RadioButton ID="rbtnBalanceDefileLeaves3" runat="server" Text="Balance" input type="radio" value="3" 
                        GroupName="BalanceOfLeaves" />
                </td>
            </tr>
            <tr>
                <td style="width: 39%" class="subhead">
                    Reason
                </td>
                <td style="width: 39%" class="subhead">
                    <asp:TextBox ID="txtReasonDefileLeaves" runat="server" TextMode="MultiLine" ></asp:TextBox>
                </td>
            </tr>
        </table>
        <table align="center"  style="width: 80%" >
            <tr>
                <td align="center">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSave" runat="server"  Text="Save" Width="50px" /> 
                        
                   
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="dgridList" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="true"
                        DataKeyNames="NAME" >
                        <Columns>
                            <asp:BoundField DataField="NAME" HeaderText="Name" />
                            <asp:BoundField DataField="MAX" HeaderText="Max No of Leaves Allowed" />
                            <asp:BoundField DataField="CREDITS" HeaderText="No of Leaves Remaining" />
                            <asp:BoundField DataField="Reason" HeaderText="Reason" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
