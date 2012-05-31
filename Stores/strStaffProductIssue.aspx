    <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
        CodeFile="StrStaffProductIssue.aspx.cs" Inherits="Stores_StrStaffProductIssue"
        Title="Staff Product Issue" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    function calc()
    { 
         var Quant=0,amt=0,rate=0;
         if(document.getElementById('<%=txtQuantity.ClientID%>').value!="")
         Quant=document.getElementById('<%=txtQuantity.ClientID%>').value;
         if(document.getElementById('<%=txtRate.ClientID%>').value!="")
         rate=document.getElementById('<%=txtRate.ClientID%>').value;    
         document.getElementById('<%=txtAmount.ClientID%>').value=Quant*rate;
    }
    function validation()
    {
        if(! DropdownValidate('<%=ddlPeriodicityNewProcirement.ClientID%>',"Please Select Periodicity"))return false;
        if(! DropdownValidate('<%=ddlCategoryNewProcirement.ClientID%>',"Please Select Category"))return false;
        if(document.getElementById('<%=ddlCategoryNewProcirement.ClientID%>').selectedIndex==2||document.getElementById('<%=ddlCategoryNewProcirement.ClientID%>').selectedIndex==3)
        if(! DropdownValidate('<%=ddlPurposeNewProcirement.ClientID%>',"Please Select Purpose"))return false;
        if(! DropdownValidate('<%=ddlProductNewProcirement.ClientID%>',"Please Select Product"))return false;   
        if(! DropdownValidate('<%=ddlProductNewProcirement.ClientID%>',"Please Select Product"))return false;
        if(! isDateFormat('<%=txtDateOfIsuue.ClientID%>',"Please Enter Date Of Issue In The Format Of DD/MM/YYYY"))return false;
        if (!isNumeric('<%=txtQuantity.ClientID%>', "Please Enter Quantity Per Head")) return false;
        if (!isDecimal('<%=txtRate.ClientID%>', "Please Enter Rate")) return false;
        if(! isDecimal('<%=txtAmount.ClientID%>',"Please Enter Amount"))return false;
//        var Availability=document.getElementById('<%=lblAvailability.ClientID%>').innerText;
//        var Quantity=document.getElementById('<%=txtQuantity.ClientID%>').value;
//        alert(Availability);
//        alert(Quantity);
//        if(Quantity>Availability)
//        {
//            alert("Please Enter Quantity less than Available Items");
//            return false;
//        }          
             var Availability=document.getElementById('<%=lblAvailability.ClientID%>').innerText;
             var Quantity=document.getElementById('<%=txtQuantity.ClientID%>').value;
             var count = 0;
             var tableElement = document.getElementById('<%=gdvStaffData.ClientID%>');
        for (var i = 1; i < tableElement.rows.length; i++)
          {
                 var rowElem = tableElement.rows[i];
                 var cell = rowElem.cells[0];
                 //alert(cell);
                 if (cell.childNodes[0].type == "checkbox") 
                 {
                  if(cell.childNodes[0].checked==true)
                  {
                    count++;                
                  } 
                 }        
         } 
         if(count==0) {
         
         alert("Please Check Atleast One Check Box");
         return false;
         }
           var Items=Quantity*count;
           if (Items>Availability)
           {
           alert("Please Enter Issued Items Less Than Available Items ");
           return false;
           }
     
    }  
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
    <ContentTemplate>
    <div>
            <table align="center" class="tdcls" width="70%">
                </tr>
                <tr>
                    <td colspan="2" class="heading">
                        STAFF PRODUCT ISSUE
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="heading">
                        PRODUCT
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
                    <td class="subhead" style="width: 39%; height: 27px;">
                        Category: <span style="font-size: 14px; color: Red">*</span>
                    </td>
                    <td style="height: 27px">
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
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" nowrap style="width: 39%">
                        Product: <span style="font-size: 14px; color: Red">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProductNewProcirement" runat="server" Height="16px" Width="154px"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlProductNewProcirement_SelectedIndexChanged">
                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblAvailableItems" runat="server" Visible="false" Font-Bold="true" ForeColor="DarkBlue"></asp:Label>
                        <asp:Label ID="lblAvailability" runat="server" Visible="true" Font-Bold="true" ForeColor="DarkBlue"></asp:Label>
                        <asp:Label ID="lblMeasurements" runat="server" Visible="false" Font-Bold="true" ForeColor="DarkBlue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="heading">
                        STAFF
                    </td>
                </tr>
                <tr>
                    <td align="left" width="39%" class="subhead">
                        Date Of Issue: <span style="font-size: 14px; color: Red">*</span>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDateOfIsuue" runat="server"></asp:TextBox>
                        <%-- <img alt="Pick a date" border="0" height="16" src="../images/cal.gif" id="imgcal">--%>
                        <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                            ID="imgcal" />
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateOfIsuue"
                            PopupButtonID="imgcal" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="subhead" width="39%">
                        Quantity Per Head: <span style="font-size: 14px; color: Red">*</span>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" class="subhead" width="39%">
                        Rate: <span style="font-size: 14px; color: Red">*</span>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtRate" runat="server"></asp:TextBox>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" width="39%" class="subhead">
                        Amount :<span style="font-size: 14px; color: Red">*</span>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblQuantity" runat="server" Visible="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;" colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                       
                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="subhead" align="center">
                        <asp:CheckBox ID="CheckSelectAll" runat="server" Text="Check Select All" AutoPostBack="true"
                            OnCheckedChanged="CheckSelectAll_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:GridView ID="gdvStaffData" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                            CellSpacing="2" AllowPaging="true" PageSize="10" OnPageIndexChanging="gdvStaffData_PageIndexChanging">
                            <FooterStyle BackColor="#CCCCCC" />
                            <RowStyle CssClass="gridviewitem" />
                            <SelectedRowStyle Font-Bold="True" />
                            <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                            <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkAll" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" HeaderText="StaffID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStaffID" runat="server" Text='<%#Bind("StaffID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFullName" runat="server" Text='<%#Bind("FullName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="Message" runat="server" />
                    </td>
                </tr>
            </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
