<%@ Page AutoEventWireup="true" CodeFile="DefineStaffSal.aspx.cs" Inherits="DefineStaffSal"
    Language="C#" MasterPageFile="~/MasterPage.master" Title="Define Staff Salaries"%>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />


    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function validation()
    {
                if(! isEmpty('<%=txtnameoffield.ClientID%>',"Please Enter Name Of Field"))return false;
                if(! DropdownValidate('<%=ddlType.ClientID%>',"Please Select Type"))return false;

    }
    function Confirm()
    {
        var con = confirm("Do You Want Delete This Field ?");
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
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>
        <div>
                    <table align="center" class="tdcls" width="40%">
                        <tr>
                            <td colspan="2" class="heading" style="text-align: center">
                                DEFINE SALARIES&nbsp;
                            </td>
                        </tr>
                        <tr><td>&nbsp;</td></tr>
                        <tr>
            <td colspan="2">
                <asp:HiddenField ID="hdnSalaryID" runat="server" />
            </td>
        </tr>
                        <tr>
                            <td nowrap class="subhead">
                                Name of Field<span style="font-size: 17px; color: Red">*</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnameoffield" runat="server" CssClass="txtcls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="subhead" >
                                Type<span style="font-size: 17px; color: Red">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlType" runat="server" Width="154px" >
                                  
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Addition</asp:ListItem>
                                <asp:ListItem Value="2">Deduction</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
        <td></td>
            <td align="left">
                <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
             <tr><td>&nbsp;</td></tr>       
         <tr><td align="center"  colspan="2" >       
        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="60px" 
                 onclick="btnAdd_Click" />
                 
        
        </td></tr>
        <tr>
        <td align="Center" colspan="2">
        <asp:GridView ID="gdvSalary" runat="server" AutoGenerateColumns="False" 
                BackColor="#CCCCCC" AllowPaging="true" PageSize="8"
                                CellSpacing="2" onrowcommand="gdvSalary_RowCommand" 
                onrowdatabound="gdvSalary_RowDataBound" 
                onpageindexchanging="gdvSalary_PageIndexChanging"> 
                
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle  Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFieldId" runat="server" Text='<%#Bind("FieldId")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name of Field">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNameOfTheField" runat="server" Text='<%#Bind("NameOfTheField")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                     <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%#Bind("type")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="editing"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="del"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
        </td>
        </tr>
    </table>
 </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
