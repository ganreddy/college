    <%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
        CodeFile="StrNewProducts.aspx.cs" Inherits="StrNewProducts" Title="New Procurement" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
     <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function CalcAmount()
    {
          var Rate=0,Quan=0;
          var Amt=0;
          if(document.getElementById('<%= txtProductItemRateNewProcirement.ClientID%>').value!="")
          {
            Rate=parseFloat(document.getElementById('<%= txtProductItemRateNewProcirement.ClientID%>').value);
            if(document.getElementById('<%=txtQuantityProcurredNewProcirement.ClientID %>').value!="")
            {
            Quan=parseFloat(document.getElementById('<%=txtQuantityProcurredNewProcirement.ClientID %>').value);
            }
          }
          Amt=Quan * Rate;
          document.getElementById('<%=txtAmountNewProcirement.ClientID %>').value=parseFloat(Amt);
    }
    function validate()
    {
         if(! DropdownValidate('<%=ddlPeriodicityNewProcirement.ClientID%>',"Please Select Periodicity"))return false;
         if(! DropdownValidate('<%=ddlCategoryNewProcirement.ClientID%>',"Please Select Category"))return false;
         if(document.getElementById('<%=ddlCategoryNewProcirement.ClientID%>').selectedIndex==2||document.getElementById('<%=ddlCategoryNewProcirement.ClientID%>').selectedIndex==3)
         if(! DropdownValidate('<%=ddlPurposeNewProcirement.ClientID%>',"Please Select Purpose"))return false;
         if(! DropdownValidate('<%=ddlProductNewProcirement.ClientID%>',"Please Select Product"))return false;
         if(! isEmpty('<%= txtProductItemRateNewProcirement.ClientID%>',"Please Enter Product Item Rate"))return false;
         if(document.getElementById('<%=txtProductItemRateNewProcirement.ClientID %>').value!="")
            {
               if(! isDecimal('<%=txtProductItemRateNewProcirement.ClientID %>',"Please Enter Correct Product Item Rate")) return false;
            }
             if(! isEmpty('<%= txtQuantityProcurredNewProcirement.ClientID%>',"Please Enter Quantity Procurred"))return false;
         if(document.getElementById('<%=txtQuantityProcurredNewProcirement.ClientID %>').value!="")
            {
                if (!isNumeric('<%=txtQuantityProcurredNewProcirement.ClientID %>', "Please Enter Correct Quantity Procurred")) return false;
            }
         if(! isEmpty('<%=txtAmountNewProcirement.ClientID%>',"Please Enter Amount"))return false;
         if(document.getElementById('<%=txtAmountNewProcirement.ClientID %>').value!="")
            {
                if (!isDecimal('<%=txtAmountNewProcirement.ClientID %>', "Please Enter Correct Amount")) return false;
            }
         if (!isEmpty('<%=txtPurchaseAdvisoryCommitteeNewProcirement.ClientID%>', "Please Enter Purchase Advisory Committee Date")) return false;
         if (document.getElementById('<%=txtPurchaseAdvisoryCommitteeNewProcirement.ClientID %>').value != "") {
             if (!isDateFormat('<%=txtPurchaseAdvisoryCommitteeNewProcirement.ClientID %>', "Date Format Should Be DD/MM/YYYY")) return false;
            }
         if (!isEmpty('<%=txtDateOfOrderNewProcirement.ClientID%>', "Please Enter Date Of Order")) return false;
         if (document.getElementById('<%=txtDateOfOrderNewProcirement.ClientID %>').value != "")
          {
              if (!isDateFormat('<%=txtDateOfOrderNewProcirement.ClientID %>', "Date Format Should Be DD/MM/YYYY")) return false;
          }
         
         if (!isEmpty('<%=txtDateOfDeliveryatJNVNewProcirement.ClientID%>', "Please Enter Date Of Delivery At JNV")) return false;
         if (document.getElementById('<%=txtDateOfDeliveryatJNVNewProcirement.ClientID %>').value != "") {
             if (!isDateFormat('<%=txtDateOfDeliveryatJNVNewProcirement.ClientID %>', "Date Format Should Be DD/MM/YYYY")) return false;
            }
         if(! isEmpty('<%=txtSupplyDelveryDateNewProcirement.ClientID%>',"Please Enter Expected Delivery Date"))return false;
        
         if(! isDateFormat('<%=txtSupplyDelveryDateNewProcirement.ClientID %>',"Date Format Should Be DD/MM/YYYY")) return false;


         if (!DateFormat12('<%=txtPurchaseAdvisoryCommitteeNewProcirement.ClientID %>', '<%=txtDateOfOrderNewProcirement.ClientID %>', "Please Enter Purchase Advisory Committee Date <= Date Of Order")) return false;
         
     
      
          if (!DateFormat12('<%=txtDateOfOrderNewProcirement.ClientID %>', '<%=txtSupplyDelveryDateNewProcirement.ClientID %>', "Please Enter Date Of Order <= Expected Delivery Date")) return false;
     
         
         if (!DateFormat12('<%=txtSupplyDelveryDateNewProcirement.ClientID %>', '<%=txtDateOfDeliveryatJNVNewProcirement.ClientID %>', "Please Enter Expected Delivery Date <= Date of Delivery At Jnv")) return false; 
     }    
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="udpNewProc" runat="server">
            <ContentTemplate>
                <table align="center" class="tdcls" width="70%">
                    <tr>
                        <td colspan="2" class="heading">
                            NEW PROCUREMENT
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            Periodicity: <span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPeriodicityNewProcirement" runat="server" Style="margin-left: 0px"
                                Height="18px" Width="154px" AutoPostBack="true" OnSelectedIndexChanged="ddlPeriodicityNewProcirement_SelectedIndexChanged">
                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                <asp:ListItem Value="1">Daily</asp:ListItem>
                                <asp:ListItem Value="2">Monthly</asp:ListItem>
                                <asp:ListItem Value="3">Yearly</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            Category: <span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategoryNewProcirement" runat="server" Height="16px" Width="154px"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlCategoryNewProcirement_SelectedIndexChanged">
                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                <asp:ListItem Value="1">Toiletries</asp:ListItem>
                                <asp:ListItem Value="2">Uniform</asp:ListItem>
                                <asp:ListItem Value="3">Stationary</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="trPurpose" runat="server">
                        <td class="subhead" nowrap style="width: 39%">
                            Purpose: <span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPurposeNewProcirement" runat="server" Width="154px">
                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" nowrap style="width: 39%">
                            Item: <span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProductNewProcirement" runat="server" Height="16px" Width="154px"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlProductNewProcirement_SelectedIndexChanged1">
                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            Item Rate:<span style="font-size: 14px; color: Red">*</span>&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtProductItemRateNewProcirement" runat="server"></asp:TextBox>
                            <asp:Label ID="lblAvailableItems" runat="server" Visible="false" Font-Bold="true" ForeColor="DarkBlue"></asp:Label>
                            <asp:Label ID="lblAvailability" runat="server" Visible="true" Font-Bold="true" ForeColor="DarkBlue"></asp:Label>
                            <asp:Label ID="lblMeasurements" runat="server" Visible="true" Font-Bold="true" ForeColor="DarkBlue"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            Quantity Procured: <span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtQuantityProcurredNewProcirement" runat="server"></asp:TextBox>
                            <asp:Label ID="lblMeasurement" runat="server" Visible="true"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%; height: 26px;">
                            Amount :<span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td style="height: 26px">
                            <asp:TextBox ID="txtAmountNewProcirement" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 39%" class="subhead">
                            Purchase Advisory Committee Date:<span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPurchaseAdvisoryCommitteeNewProcirement" runat="server"></asp:TextBox>
                            <%-- <img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16" id="imgcal2">--%>
                            <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                                Width="16" ID="imgcal2" />
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtPurchaseAdvisoryCommitteeNewProcirement"
                                PopupButtonID="imgcal2" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            Date Of Order: <span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDateOfOrderNewProcirement" runat="server"></asp:TextBox>
                            <%--                <img alt="Pick a date" border="0" src="../images/cal.gif" id="imgcal0">
--%>
                            <asp:ImageButton runat="server" alt="Pick a date" border="0" src="../images/cal.gif"
                                ID="imgcal0" />
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateOfOrderNewProcirement"
                                PopupButtonID="imgcal0" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 39%" class="subhead">
                            Expected Delivery Date: <span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td style="height: 25px">
                            <asp:TextBox ID="txtSupplyDelveryDateNewProcirement" runat="server"></asp:TextBox>
                            <%--                <img alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="imgcal" style="margin-top: 0px">
--%>
                            <asp:ImageButton ID="imgcal" runat="server" alt="Pick a date" border="0" Height="16"
                                src="../images/cal.gif" Style="margin-top: 0px" />
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSupplyDelveryDateNewProcirement"
                                PopupButtonID="imgcal" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            Date Of Delivery At JNV: <span style="font-size: 14px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDateOfDeliveryatJNVNewProcirement" runat="server"></asp:TextBox>
                            <%--    <img alt="Pick a date" border="0" src="../images/cal.gif" id="imgcal1">--%>
                            <asp:ImageButton runat="server" alt="Pick a date" border="0" src="../images/cal.gif"
                                ID="imgcal1" />
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDateOfDeliveryatJNVNewProcirement"
                                PopupButtonID="imgcal1" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
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
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="grdProduct" runat="server" Height="106px" Width="303px" BackColor="LightGoldenrodYellow"
                                BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
                                GridLines="None"  >
                                <FooterStyle BackColor="Tan" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            </asp:GridView>
                            <asp:HiddenField ID="Message" runat="server" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    
</asp:Content>
