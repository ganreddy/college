<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="MessPurchases.aspx.cs" Inherits="MessPurchases" Title="Mess Purchases" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    
     function validation()
    {
          if(! DropdownValidate('<%=ddlMonth.ClientID%>',"Please Select Month"))return false;
          if(! DropdownValidate('<%=ddlYear.ClientID%>',"Please Select Year"))return false;
          if(! DropdownValidate('<%=ddlItem.ClientID%>',"Please Select Item"))return false;
          if(! isEmpty('<%=txtQuantityOpen.ClientID%>',"Please Enter Opening Quantity"))return false;
          if(! isEmpty('<%=txtRateOpening.ClientID%>',"Please Enter Opening Rate"))return false;
          if(! isEmpty('<%=txtQuantityPurchase.ClientID%>',"Please Enter Quantity Purchase"))return false;
          //if(! isEmpty('<%=txtRatePurchase.ClientID%>',"Please Enter Rate Purchase"))return false;
          if(! isEmpty('<%=txtQuantityConsumption.ClientID%>',"Please Enter Quantity Consumption"))return false;
          if(! isEmpty('<%=txtRateConsumption.ClientID%>',"Please Enter Rate Consumption"))return false;
          if(! isEmpty('<%=txtAmountConsumption.ClientID%>',"Please Enter Amount Consumption"))return false;          
          if(! isEmpty('<%=txtAmountPurchase.ClientID%>',"Please Enter Amount Purchase"))return false;          
   }
   
    function Calculation()
    {
    var QuantityOpen=0,AmountTotal=0,QuantityTotal=0,OpeningAmount=0,OpeningRate=0,Total=0,ClosingBal=0,QuantityPurchase=0,AmountPurchase=0,QuantityConsumption=0,RateConsumption=0, AmountConsumption=0,QuantityRate=0;
   
    if(document.getElementById('<%=txtQuantityOpen.ClientID%>').value!="")
    {
      QuantityOpen=parseFloat(document.getElementById('<%=txtQuantityOpen.ClientID%>').value);
    }
      if(document.getElementById('<%=txtRateOpening.ClientID%>').value!="")
      {
        OpeningRate=parseFloat(document.getElementById('<%=txtRateOpening.ClientID%>').value);
      }
       document.getElementById('<%=txtAmountOpening.ClientID%>').value=parseFloat(QuantityOpen*OpeningRate);
     
    
    if(document.getElementById('<%=txtQuantityPurchase.ClientID%>').value!="")
    {
      QuantityPurchase=parseFloat(document.getElementById('<%=txtQuantityPurchase.ClientID%>').value);
    }
    if (document.getElementById('<%=txtRatePurchase.ClientID%>').value != "") {
        QuantityRate = parseFloat(document.getElementById('<%=txtRatePurchase.ClientID%>').value);
    }
    else {
        document.getElementById('<%=txtRatePurchase.ClientID%>').value = 0;
    }
       document.getElementById('<%=txtAmountPurchase.ClientID%>').value=parseFloat(QuantityPurchase*QuantityRate);


       document.getElementById('<%=txtQuantityTotal.ClientID%>').value = QuantityOpen + QuantityPurchase;
       document.getElementById('<%=txtAmountotal.ClientID%>').value = parseFloat(document.getElementById('<%=txtAmountOpening.ClientID%>').value) + parseFloat(document.getElementById('<%=txtAmountPurchase.ClientID%>').value);
       document.getElementById('<%=txtRateTotal.ClientID%>').value = parseFloat(document.getElementById('<%=txtAmountotal.ClientID%>').value) / parseFloat(document.getElementById('<%=txtQuantityTotal.ClientID%>').value);
       
       if(document.getElementById('<%=txtAmountotal.ClientID%>').value!="")
        {
      AmountTotal=parseFloat(document.getElementById('<%=txtAmountotal.ClientID%>').value);
        }
      if(document.getElementById('<%=txtQuantityTotal.ClientID%>').value!="")
      {
        QuantityTotal=parseFloat(document.getElementById('<%=txtQuantityTotal.ClientID%>').value);
      }

      if (document.getElementById('<%=txtQuantityConsumption.ClientID%>').value != "") {
          QuantityConsumption = parseFloat(document.getElementById('<%=txtQuantityConsumption.ClientID%>').value);
      }
      else {
          document.getElementById('<%=txtQuantityConsumption.ClientID%>').value = 0;
      }
       if(document.getElementById('<%=txtRateConsumption.ClientID%>').value!="")
      {
        RateConsumption=parseFloat(document.getElementById('<%=txtRateConsumption.ClientID%>').value);
      }
       document.getElementById('<%=txtAmountConsumption.ClientID%>').value=parseFloat(QuantityConsumption*RateConsumption);
      
       
     if(document.getElementById('<%=txtQuantityPurchase.ClientID%>').value!="")
     {
        QuantityPurchase=parseFloat(document.getElementById('<%=txtQuantityPurchase.ClientID%>').value);
     }
        document.getElementById('<%=txtQuantityTotal.ClientID%>').value=(QuantityOpen) + (QuantityPurchase);
   
   
     if(document.getElementById('<%=txtAmountPurchase.ClientID%>').value!="")
     {
     AmountPurchase=parseFloat(document.getElementById('<%=txtAmountPurchase.ClientID%>').value);
     }
     document.getElementById('<%=txtAmountotal.ClientID%>').value=(parseFloat(QuantityOpen*OpeningRate)+parseFloat(AmountPurchase));
  
  
     if(document.getElementById('<%=txtQuantityConsumption.ClientID%>').value!="")
     {
     QuantityConsumption=parseFloat(document.getElementById('<%=txtQuantityConsumption.ClientID%>').value);
     }
     document.getElementById('<%=txtQuantityClosing.ClientID%>').value=(QuantityOpen+QuantityPurchase)-(QuantityConsumption);
     
     if(document.getElementById('<%=txtAmountConsumption.ClientID%>').value!="")
     {
     AmountConsumption=parseFloat(document.getElementById('<%=txtAmountConsumption.ClientID%>').value);
 }
     //document.getElementById('<%=txtRateTotal.ClientID%>').value=parseFloat(AmountTotal/QuantityTotal);
      document.getElementById('<%=txtRateConsumption.ClientID%>').value=parseFloat(AmountTotal/QuantityTotal);
      document.getElementById('<%=txtRateClosing.ClientID%>').value=parseFloat(AmountTotal/QuantityTotal);
      // document.getElementById('<%=txtAmountClosing.ClientID%>').value=(QuantityOpen*OpeningRate)-(AmountConsumption);
      document.getElementById('<%=txtAmountClosing.ClientID%>').value = document.getElementById('<%=txtAmountotal.ClientID%>').value - (AmountConsumption);

//      if (document.getElementById('<%=txtQuantityClosing.ClientID%>').value == 0 && document.getElementById('<%=txtAmountClosing.ClientID%>').value == 0) {
//          document.getElementById('<%=txtRateClosing.ClientID%>').value = 0;
//      }
      
  } 
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table align="center" class="tdcls" width="80%">
                <tr>
                    <td colspan="6" class="heading">
                        MESS PURCHASE
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td nowrap class="subhead">
                        Month&nbsp; <span style="font-size: 17px; color: Red">*</span>
                    </td>
                    <td style="width: 32px">
                        <asp:DropDownList ID="ddlMonth" runat="server" Width="120px" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                            AutoPostBack="true">
                            <asp:ListItem Text="--Select--" Value="0">---Select---</asp:ListItem>
                            <asp:ListItem Text="Jan" Value="1">Jan</asp:ListItem>
                            <asp:ListItem Text="Feb" Value="2">Feb</asp:ListItem>
                            <asp:ListItem Text="Mar" Value="3">Mar</asp:ListItem>
                            <asp:ListItem Text="Apr" Value="4">Apr</asp:ListItem>
                            <asp:ListItem Text="May" Value="5">May</asp:ListItem>
                            <asp:ListItem Text="Jun" Value="6">jun</asp:ListItem>
                            <asp:ListItem Text="Jul" Value="7">Jul</asp:ListItem>
                            <asp:ListItem Text="Aug" Value="8">Aug</asp:ListItem>
                            <asp:ListItem Text="Sept" Value="9">Sept</asp:ListItem>
                            <asp:ListItem Text="Oct" Value="10">Oct</asp:ListItem>
                            <asp:ListItem Text="Nov" Value="11">Nov</asp:ListItem>
                            <asp:ListItem Text="Dec" Value="12">Dec</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="subhead" style="width: 98px">
                        Year <span style="font-size: 17px; color: Red">*</span>
                    </td>
                    <td style="width: 32px">
                        <asp:DropDownList ID="ddlYear" runat="server" Width="120px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                            AutoPostBack="true">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 318px; height: 55px;">
                        &nbsp;
                    </td>
                    <td style="width: 292px; height: 55px;">
                        &nbsp;
                    </td>
                    <td style="width: 187px; height: 55px;">
                        &nbsp;
                    </td>
                    <td style="width: 246px; height: 55px;">
                        &nbsp;
                    </td>
                </tr>
                <%--<tr>
            <td nowrap class="subhead">
                Year&nbsp; <span style="font-size: 17px; color: Red">*</span>
            </td>
            <td style="width: 32px">
                <asp:DropDownList ID="ddlYear" runat="server" Width="120px">
                </asp:DropDownList>
            </td>
            <td style="width: 318px; height: 55px;">
                &nbsp;
            </td>
            <td style="width: 292px; height: 55px;">
                &nbsp;
            </td>
            <td style="width: 187px; height: 55px;">
                &nbsp;
            </td>
            <td style="width: 246px; height: 55px;">
                &nbsp;
            </td>
        </tr>--%>
                <tr>
                    <td nowrap class="subhead" style="height: 25px">
                        Item Name <span style="font-size: 17px; color: Red">*</span>
                    </td>
                    <td style="width: 32px; height: 25px;">
                        <asp:DropDownList ID="ddlItem" runat="server" Width="120px" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged"
                            AutoPostBack="true">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </td>
                    <td style="width: 98px; height: 25px;">
                        &nbsp;
                    </td>
                    <td style="width: 292px; height: 25px;">
                        &nbsp;
                    </td>
                    <td style="width: 187px; height: 25px;">
                        &nbsp;
                    </td>
                    <td style="width: 246px; height: 25px;">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="subhead">
                        Opening Balance
                    </td>
                    <td class="subhead" style="width: 98px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Purchase
                    </td>
                    <td class="subhead">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Total
                    </td>
                    <td class="subhead">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Consumption
                    </td>
                    <td class="subhead">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Closing Balance
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="height: 35px">
                        Quantity
                    </td>
                    <td style="width: 32px; height: 35px;">
                        <asp:TextBox ID="txtQuantityOpen" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 98px; height: 35px;">
                        <asp:TextBox ID="txtQuantityPurchase" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 292px; height: 35px;">
                        <asp:TextBox ID="txtQuantityTotal" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 187px; height: 35px;">
                        <asp:TextBox ID="txtQuantityConsumption" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 246px; height: 35px;">
                        <asp:TextBox ID="txtQuantityClosing" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" style="height: 40px">
                        Rate
                    </td>
                    <td style="width: 32px; height: 40px;">
                        <asp:TextBox ID="txtRateOpening" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 98px; height: 40px;">
                        <asp:TextBox ID="txtRatePurchase" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 292px; height: 40px;">
                        <asp:TextBox ID="txtRateTotal" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 187px; height: 40px;">
                        <asp:TextBox ID="txtRateConsumption" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 246px; height: 40px;">
                        <asp:TextBox ID="txtRateClosing" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="subhead">
                        Amount
                    </td>
                    <td style="width: 32px; height: 23px;">
                        <asp:TextBox ID="txtAmountOpening" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 98px; height: 23px;">
                        <asp:TextBox ID="txtAmountPurchase" runat="server" Height="22px"></asp:TextBox>
                    </td>
                    <td style="width: 292px; height: 23px;">
                        <asp:TextBox ID="txtAmountotal" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 187px; height: 23px;">
                        <asp:TextBox ID="txtAmountConsumption" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 246px; height: 23px;">
                        <asp:TextBox ID="txtAmountClosing" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px;" colspan="6">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnCatSave" runat="server" Text="Save" Width="50px" OnClick="btnCatSave_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="50px" />
                    </td>
                </tr>
            </table>
            <br />
            <br />

            <script language="javascript" type="text/javascript">


        function Select2_onclick() {

        }


            </script>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
