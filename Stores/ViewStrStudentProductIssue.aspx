﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewStrStudentProductIssue.aspx.cs" Inherits="Stores_ViewStrStudentProductIssue" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
 <script src="../scripts/Validations.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
 function Confirm()
        {
           var con=confirm("Do you want delete this Data ?");
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
    <asp:UpdatePanel ID="upd" runat="server">
    <ContentTemplate>
    
<table align="center" class="tdcls" width="70%">
<tr>
                        <td>
                            <asp:HiddenField ID="hdnStudID" runat="server" />
                        </td>
</tr>
        <tr>
        
            <td colspan="2" class="heading">
                STUDENT PRODUCT ISSUE
            </td>
           
           </tr></tr>
            <tr>
            <td align="left" class="subhead" >
                Batch <span style="color: #ff0000">*</span></td>
            
            <td align="left" >
                <asp:DropDownList ID="ddlBatch" runat="server" Height="16px" Width="130px"  
                     AutoPostBack="true" 
                    onselectedindexchanged="ddlBatch_SelectedIndexChanged">  
                   
                    
                </asp:DropDownList>
               </td>
            
        </tr>
        <tr>
            <td align="left" class="subhead" width="39%">
                Branch:<span style="font-size: 14px; color: Red">*</span>&nbsp;
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlClass" runat="server" Height="16px" Width="130px" 
                    onselectedindexchanged="ddlClass_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" class="subhead" width="39%">
                Section: <span style="font-size: 14px; color: Red">*</span>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlSection" runat="server" Height="16px" Width="130px" 
                    onselectedindexchanged="ddlSection_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td align="left" class="subhead" width="39%">
                Student: <span style="font-size: 14px; color: Red">*</span>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlStudent" runat="server" Height="16px" Width="130px" 
                    AutoPostBack="true" onselectedindexchanged="ddlStudent_SelectedIndexChanged"  
                    >
                    <asp:ListItem>Select</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
        <td align="center" style="height: 19px"></td>
        <td align="left" style="height: 19px"></td>
        </tr>
        
        <tr><td></td><td>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td></tr>
        <tr><td></td><td></td></tr>
        
        <tr>
            <td colspan="2" align="center">
                  <asp:GridView ID="gdvStuData" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" onrowcommand="gdvStuData_RowCommand" 
                      ondatabound="gdvStuData_DataBound"  >
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle  Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                
                                <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProduct" runat="server" Text='<%#Bind("Product")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="ItemName">
                                <ItemTemplate>
                                <asp:Label ID="lblItemName" runat="server" Text='<%#Bind("ItemName") %>'></asp:Label>
                                </ItemTemplate>
                               
                                </asp:TemplateField>
                                    <asp:TemplateField Visible="true" HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Bind("Quantity")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DateOfIssue">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDateofIssue" runat="server" Text='<%#Bind("DateofIssue")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                           <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" CommandName="del"></asp:LinkButton>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                
                                </Columns>
                            </asp:GridView> 
                
            
                <asp:HiddenField ID="Message" runat="server" />
            </td>
        </tr>
           </table>
           </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

