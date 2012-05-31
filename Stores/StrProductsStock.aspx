<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile ="~/MasterPage.master" CodeFile="StrProductsStock.aspx.cs" Inherits="StrProductsStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
     <asp:UpdatePanel ID="udpNewProc" runat="server">
            <ContentTemplate>
        <table align="center" class="tdcls" style="width: 589px">
            <tr>
                <td colspan="3" class="heading">
                    PRODUCTS STOCK</td>
            </tr>
            <tr>
                <td >
                    <asp:RadioButton ID="rbtnDaily0" runat="server" Text="Daily" />
                </td>
                <td >
                    <asp:RadioButton ID="rbtnMonthly" runat="server" Text="Monthly" />
                </td>
                    <td>
                        <asp:RadioButton ID="rbtnYearly" runat="server" Text="Yearly" />
                </td>
            </tr>
            <tr>
                <td >
                    Select Product
                    </td>
                <td style="width: 688px">
                    <asp:DropDownList ID="ddlPrd" runat="server" AutoPostBack="True" Width="121px" >
                    </asp:DropDownList>
                   
                </td>
                
                
                <tr>
                <td colspan="3" class="heading">
                    TOLETORIES</td>
                    </tr>
            <td >Product 
                    
                                                        </td>
                <td >
                
                    <asp:DropDownList ID="ddlProduct" runat="server" Width="156px" 
                        AutoPostBack="True" >
                    </asp:DropDownList>
                                                        </td>
                    
            </tr>
           
           <tr>
                <td colspan="3" class="heading">
                    STATIONARY</td>
            </tr>
             <tr>
                <td  class="heading" colspan="2">
                    <asp:RadioButton ID="rbtnExamination" runat="server" Text="Examination" />  </td>
                    <td  class="heading">
                    <asp:RadioButton ID="rbtnOffice" runat="server" Text="Office" />  </td>
            </tr>
            <tr>Product 
                    
                                                            </td>
                
                <td >
                    <asp:DropDownList ID="ddlExmProduct" runat="server">
                    </asp:DropDownList>
                </td>
                <td >Product&nbsp;</td>
                <td >Product&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddloffProduct" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>Class
                                                            </td>
                
                <td >
                    <asp:DropDownList ID="ddlExmclass" runat="server">
                    </asp:DropDownList>
                </td>
                <td >&nbsp;</td>
            </tr>
            <tr>
                <td >
                    Section           <td >
                    
                    </td>
                
                <td >
                    <asp:DropDownList ID="ddlExmSection" runat="server">
                    </asp:DropDownList>
                </td>
                <td >&nbsp;</td>
            </tr>
             <tr>
                <td colspan="3" class="heading">
                    UNIFORM</td>
            </tr>
            
            <tr>
                <td  class="heading" colspan="2">
                    <asp:RadioButton ID="rbtnClothing" runat="server" Text="Clothing" />  </td>
                    <td  class="heading">
                    <asp:RadioButton ID="rbtnOtherItem" runat="server" Text="Other Item" />  </td>
            </tr>
            <tr>
            <td >Product</td>
            <td >
                    <asp:DropDownList ID="ddlClothingProduct" runat="server">
                    </asp:DropDownList>
                </td>
            <td>Product<asp:DropDownList ID="ddlOtherItmProduct" runat="server">
                    </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            
            <tr>
            <td >Class</td>
            <td >
                    <asp:DropDownList ID="ddlClothingclass" runat="server">
                    </asp:DropDownList>
                </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            
            <tr>
                <td style="width: 739px; height: 25px;" align="right">
                    &nbsp;</td>
                
                <td  colspan="2">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td >
                    &nbsp;</td>
                
                <td  colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                    </td>
            </tr>
            
            <tr>
                <td >
                    &nbsp;</td>
                
                <td  colspan="2">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td >
                    &nbsp;</td>
                
                <td  colspan="2">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td >
                    &nbsp;</td>
                
                <td  colspan="2">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td >
                    &nbsp;</td>
                
                <td  colspan="2">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td >
                    &nbsp;</td>
                
                <td >
                    &nbsp;</td>
            </tr>
 
           
            <tr>
                <td colspan="2" >
                    <asp:GridView ID="GridView1" runat="server" Height="72px" Width="529px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                        <FooterStyle BackColor="Tan" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    </asp:GridView>
                </td>
            </tr>
        </table  >
        <br />
        <table align="center" class="tdcls" >
        <tr>
        <td colspan="2" >
            <asp:GridView ID="GridView2" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Height="108px" Width="532px">
                <FooterStyle BackColor="Tan" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
            </asp:GridView>
        </td>
        </tr>
        <tr>
        <td align="center"  >
            <asp:Label ID="Label1" runat="server" Text="Label" Width="587px"></asp:Label>
        </td>
        </tr>
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content> 