<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="ItemConsumption.aspx.cs" Inherits="MessConsumption"  Title="Mess Item consumption"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function validation()
    {
          if(! isEmpty('<%=txtDate.ClientID%>',"Please Enter Date"))return false;
      if(document.getElementById('<%=txtDate.ClientID %>').value!="")
        {
           if(! isDateFormat('<%=txtDate.ClientID %>',"Date Format Should Be DD/MM/YYYY")) return false;
           if (!DropdownValidate('<%=ddlItemName.ClientID%>', "Please Select Item Name")) return false;
           if (!DropdownValidate('<%=ddlUOM.ClientID%>', "Please Select  Units Of Measurement")) return false;
           if (!isNumeric('<%=txtQuantity.ClientID%>', "Please Enter Valid Quantity")) return false;
           // ddlUOMif(!isDecimal('<%=txtQuantity.ClientID%>',"Please Enter Quantity"))return false;

        }
    }
    function Confirm()
        {
           var con=confirm("Do You Want Delete This Item?");
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
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="updItemConsumption" runat="server">
    <ContentTemplate>
   <table align="center" class="tdcls" width="60%" border="0">
        <tr>
            <td colspan="2" class="heading">
                CONSUMPTION
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td class="subhead">
                Date<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                    id="imgcal">--%>
                    <asp:ImageButton runat="server" alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                    id="imgcal"/>
                <asp:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"
                    PopupButtonID="imgcal">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Item Name<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlItemName" runat="server" Width="154px">
                 <asp:ListItem>Select</asp:ListItem>
                    
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Units Of Measurement<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlUOM" runat="server" Width="154px">
                 <asp:ListItem>Select</asp:ListItem>
                    
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Quantity<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtQuantity">
                </asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button Text=">>" runat="server" ID="btnAdd" onclick="btnAdd_Click"   />
                    
                
            </td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align: middle;">
                
            </td>
        </tr>
        <tr><td style="height: 18px"></td><td style="height: 18px">
            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            </td></tr>
        <tr><td></td><td>&nbsp;</td></tr>
        <tr>
            <td colspan="2" align="center">
               <asp:GridView ID="gdvItemConsumption" runat="server" AutoGenerateColumns="False" 
                    BackColor="#CCCCCC" CellSpacing="2" 
                    onrowcommand="gdvItemConsumption_RowCommand" 
                    onrowdatabound="gdvItemConsumption_RowDataBound"  
                    > 
                                  
                <FooterStyle BackColor="#CCCCCC" />
                <RowStyle CssClass="gridviewitem" />
                <SelectedRowStyle Font-Bold="true" />
                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="true" ForeColor="White" />
                    <Columns>
                   <asp:TemplateField Visible="false">
                   <ItemTemplate>
                   <asp:Label ID="lblItemID" runat="server" Text='<%#Bind("ItemID") %>'></asp:Label>
                   </ItemTemplate>
                   </asp:TemplateField> 
                   <asp:TemplateField HeaderText="ItemName">
                   <ItemTemplate>
                   <asp:Label ID="lblItemName" runat="server" Text='<%#Bind("ItemName") %>'></asp:Label>
                   </ItemTemplate>
                   </asp:TemplateField>  
                   <asp:TemplateField  Visible="false">
                   <ItemTemplate>
                   <asp:Label ID="lblUOMID" runat="server" Text='<%#Bind("UOMID") %>'></asp:Label>
                   </ItemTemplate>
                   </asp:TemplateField> 
                    <asp:TemplateField HeaderText="UOM">
                   <ItemTemplate>
                   <asp:Label ID="lblUOMName" runat="server" Text='<%#Bind("UOMName") %>'></asp:Label>
                   </ItemTemplate>
                   </asp:TemplateField> 
                   <asp:TemplateField HeaderText="Quantity" >
                   <ItemTemplate>
                   <asp:Label ID="lblQuantity" runat="server" Text='<%#Bind("Quantity") %>'></asp:Label>
                   </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField>
                   <ItemTemplate>
                   <asp:LinkButton ID="lnkDelete" runat="server" Text="Remove" CommandName="del"></asp:LinkButton>
                   </ItemTemplate>
                   </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
            </td>
        </tr>
        <tr>
            <td style="height: 15px;" colspan="2" align="center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
            </td>
        </tr>
    </table>
     </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
</asp:Content>
