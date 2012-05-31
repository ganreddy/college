    <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ItemCalculation.aspx.cs" Inherits="Mess_ItemCalculation" Title="Mess Item Details" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    var Quantity1=0,UnitCost1=0,Quantity2=0,UnitCost2=0, Quantity3=0,UnitCost3=0,Quantity4=0,UnitCost4=0,CostPerStud=0,Availability=0; 
    var Total=0,LabourCost=0,MiscellaneousCost=0;
    function calculation()
    {  
         if(document.getElementById('<%=txtQuantity1.ClientID%>').value!="")
         Quantity1=document.getElementById('<%=txtQuantity1.ClientID%>').value;
         if(document.getElementById('<%=txtUnitCost1.ClientID%>').value!="")
         UnitCost1=parseFloat(document.getElementById('<%=txtUnitCost1.ClientID%>').value);    
         document.getElementById('<%=txtTotalCost1.ClientID%>').value=Quantity1*UnitCost1;
         if(document.getElementById('<%=txtQuantity2.ClientID%>').value!="")
         Quantity2=document.getElementById('<%=txtQuantity2.ClientID%>').value;
         if(document.getElementById('<%=txtUnitCost2.ClientID%>').value!="")
         UnitCost2=parseFloat(document.getElementById('<%=txtUnitCost2.ClientID%>').value);    
         document.getElementById('<%=txtTotalCost2.ClientID%>').value=Quantity2*UnitCost2;
         if(document.getElementById('<%=txtQuantity3.ClientID%>').value!="")
         Quantity3=document.getElementById('<%=txtQuantity3.ClientID%>').value;
         if(document.getElementById('<%=txtUnitCost3.ClientID%>').value!="")
         UnitCost3=parseFloat(document.getElementById('<%=txtUnitCost3.ClientID%>').value);    
         document.getElementById('<%=txtTotalCost3.ClientID%>').value=Quantity3*UnitCost3;
         if(document.getElementById('<%=txtQuantity4.ClientID%>').value!="")
         Quantity4=document.getElementById('<%=txtQuantity4.ClientID%>').value;
         if(document.getElementById('<%=txtUnitCost4.ClientID%>').value!="")
         UnitCost4=parseFloat(document.getElementById('<%=txtUnitCost4.ClientID%>').value);    
         document.getElementById('<%=txtTotalCost4.ClientID%>').value=Quantity4*UnitCost4;
         if(document.getElementById('<%=txtLabourCost.ClientID%>').value!="")
         LabourCost=parseFloat(document.getElementById('<%=txtLabourCost.ClientID%>').value); 
         if(document.getElementById('<%=txtMisccellaneousCost.ClientID%>').value!="")
         MiscellaneousCost=parseFloat(document.getElementById('<%=txtMisccellaneousCost.ClientID%>').value);
         
         
         
        // document.getElementById('<%=lblAvailLeaves.ClientID%>').disabled=false;
         Availability=document.getElementById('<%=lblAvailLeaves.ClientID%>').innerText;
        // alert(Availability);
         CostPerStud=parseFloat((Quantity1*UnitCost1)+(Quantity2*UnitCost2)+(Quantity3*UnitCost3)+(Quantity4*UnitCost4)+LabourCost+MiscellaneousCost);
        // alert(CostPerStud);
        Total=parseFloat(CostPerStud/Availability);
        
         document.getElementById('<%=txtEntireTotalCost.ClientID%>').value=(Total);
         
   }
//   function calculation1()
//   {
//         
//         if(document.getElementById('<%=txtQuantity2.ClientID%>').value!="")
//         Quantity2=document.getElementById('<%=txtQuantity2.ClientID%>').value;
//         if(document.getElementById('<%=txtUnitCost2.ClientID%>').value!="")
//         UnitCost2=document.getElementById('<%=txtUnitCost2.ClientID%>').value;    
//         document.getElementById('<%=txtTotalCost2.ClientID%>').value=Quantity2*UnitCost2;
//   }
//         function calculation2()
//   {
//         
//         if(document.getElementById('<%=txtQuantity3.ClientID%>').value!="")
//         Quantity3=document.getElementById('<%=txtQuantity3.ClientID%>').value;
//         if(document.getElementById('<%=txtUnitCost3.ClientID%>').value!="")
//         UnitCost3=document.getElementById('<%=txtUnitCost3.ClientID%>').value;    
//         document.getElementById('<%=txtTotalCost3.ClientID%>').value=Quantity3*UnitCost3;
//   }
//         function calculation3()
//   {
//         
//         if(document.getElementById('<%=txtQuantity4.ClientID%>').value!="")
//         Quantity4=document.getElementById('<%=txtQuantity4.ClientID%>').value;
//         if(document.getElementById('<%=txtUnitCost4.ClientID%>').value!="")
//         UnitCost4=document.getElementById('<%=txtUnitCost4.ClientID%>').value;    
//         document.getElementById('<%=txtTotalCost4.ClientID%>').value=Quantity4*UnitCost4;
//   }
  
   
    function validate()
    {
   
         if(! isEmpty('<%=txtDate.ClientID%>',"Please Enter To Date"))return false;
         if(document.getElementById('<%=txtDate.ClientID %>').value!="")
            {
               if(! isDateFormat('<%=txtDate.ClientID %>',"Date Format Should Be DD/MM/YYYY")) return false;
            } 
         if(! DropdownValidate('<%=ddlDishName.ClientID%>',"Please Select Dish Item"))return false;
         if(! DropdownValidate('<%=ddlItem1.ClientID%>',"Please Select Item Name"))return false;
         if(! isEmpty('<%=txtQuantity1.ClientID%>',"Please Enter Quantity"))return false;
         if(! isEmpty('<%=txtUnitCost1.ClientID%>',"Please Enter Unit Cost"))return false;
         if(! isEmpty('<%=txtTotalCost1.ClientID%>',"Please Enter Total Cost"))return false;
         if(! isEmpty('<%=txtLabourCost.ClientID%>',"Please Enter Labour Cost"))return false;
         if(! isEmpty('<%=txtMisccellaneousCost.ClientID%>',"Please Enter Miscellaneous Cost"))return false;
         if(! isEmpty('<%=txtEntireTotalCost.ClientID%>',"Please Enter Item Total Cost"))return false;  
     }
    
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
      <ContentTemplate>
    <table align="center" border="0" cellpadding="1" cellspacing="1" style="width: 100%" class="maintblcls1">
        <tr align="center">
            <td class="heading" colspan="4">
                <strong>MESS ITEM DETAILS</strong>
            </td>
        </tr>
        <tr class="tdcls">
            <td colspan="4">
                <table cellpadding="1" cellspacing="1" width="100%">
                    <!---- Display for Error Messages ---------->
                    <tr class="tdcls">
                        <td align="right">
                            <font color="red"><b>Note:</b></font> All fields marked <font color="red"><sup>*</sup></font>
                            are mandatory
                        </td>
                    </tr>
                    <tr align="right">
                        <td>
                            <asp:HiddenField ID="Message" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4">
                ITEM CALCULATION
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Date: <font color="red"><sup>*</sup></font>
            </td>
            <td class="tdcls">
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate"
                    PopupButtonID="imgcal">
                </asp:CalendarExtender>
                <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                    id="imgcal">--%>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                    Width="16" ID="imgcal" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblAvailability" runat="server" Visible="false" Font-Bold="true"></asp:Label>
                <asp:Label ID="lblAvailLeaves" runat="server" Visible="true" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Dish Name <font color="red"><sup>*</sup></font>
            </td>
            <td style="width: 259px">
                <br />
                <asp:DropDownList ID="ddlDishName" runat="server" DataTextField="Name" DataValueField="Name"
                    Width="155px">
                </asp:DropDownList>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4" style="height: 17px">
                ITEMS USED
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="heading" width="20%">
                            ITEM NAME
                        </td>
                        <td class="heading" width="20%">
                            QUANTITY
                        </td>
                        <td class="heading" width="20%">
                            UNIT PER COST
                        </td>
                        <td class="heading" width="20%">
                            TOTAL COST
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="tdcls" width="20%" align="center">
                            <asp:DropDownList ID="ddlItem1" runat="server" CssClass="txtcls" Width="154px">
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:TextBox ID="txtQuantity1" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                        <td class="tdcls" style="text-align: center" width="20%" align="center">
                            <asp:TextBox ID="txtUnitCost1" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:TextBox ID="txtTotalCost1" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="tdcls" width="20%" align="center">
                            <asp:DropDownList ID="ddlItem2" runat="server" CssClass="txtcls" Width="154px">
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" valign="top" width="20%" align="center">
                            <asp:TextBox ID="txtQuantity2" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                        <td class="tdcls" style="text-align: center" width="20%" align="center">
                            <asp:TextBox ID="txtUnitCost2" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:TextBox ID="txtTotalCost2" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="tdcls" width="20%" align="center">
                            <asp:DropDownList ID="ddlItem3" runat="server" CssClass="txtcls" Width="154px">
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:TextBox ID="txtQuantity3" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                        <td class="tdcls" style="text-align: center;" width="20%" align="center">
                            <asp:TextBox ID="txtUnitCost3" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:TextBox ID="txtTotalCost3" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="tdcls" width="20%" align="center">
                            <asp:DropDownList ID="ddlItem4" runat="server" CssClass="txtcls" Width="154px">
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:TextBox ID="txtQuantity4" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                        <td class="tdcls" style="text-align: center;" width="20%" align="center">
                            <asp:TextBox ID="txtUnitCost4" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:TextBox ID="txtTotalCost4" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4">
                OTHER DETAILS
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Labour Cost <font color="red"><sup>*</sup></font>
            </td>
            <td class="tdcls">
                <asp:TextBox ID="txtLabourCost" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Miscellaneous Cost <font color="red"><sup>*</sup></font>
            </td>
            <td style="width: 259px">
                <asp:TextBox ID="txtMisccellaneousCost" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Total Cost Per Student <font color="red"><sup>*</sup></font>
            </td>
            <td style="width: 259px">
                <asp:TextBox ID="txtEntireTotalCost" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead" align="center" colspan="4"><asp:Label ID="lblMessage" runat="server" Text="lblMessage" Visible="false"></asp:Label>
            </td>
            <%--<td class="subhead" align="left">
                
            </td>--%>
        </tr>
        <tr>
            <td colspan="4" height="1%" valign="top">
                <!-- Here we start displaying the button table -->
                &nbsp;
                <table align="center" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" CssClass="btncls" Text="Save" Width="56px"
                                OnClick="btnSave_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnReset" runat="server" CssClass="btncls" Text="Reset" Width="56px" />
                        </td>
                    </tr>
                </table>
                <!-- end of displaying the button table -->
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
