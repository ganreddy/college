<%@ Page AutoEventWireup="true" CodeFile="DefineGroups.aspx.cs" Inherits="DefineGroups"
    Language="C#" MasterPageFile="~/MasterPage.master" Title="Define Groups"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
       function validation()
       {
         if(! isEmpty('<%=txtGroupName.ClientID%>',"Please Enter  Group Name"))return false;
       

       }
       function Confirm()
        {
            var con = confirm("Do You Want Delete This Group?");
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
        <table align="center" class="tdcls" width="60%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdnGroup" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3" class="heading" align="center">
                    DEFINE GROUPS
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td class="subhead">
                    Group Name <span style="font-size: 10px; color: #CC3300">*</span>
                </td>
                <td >
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtGroupName" runat="server" CssClass="txtcls"></asp:TextBox>
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: center" colspan="3">
                    <asp:Button align="center" ID="btnAddGroup" runat="server" Text="Add" width="50px"
                        onclick="btnAddGroup_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:GridView ID="gdvGroups" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                        CellSpacing="2" onrowcommand="gdvGroups_RowCommand" 
                        onrowdatabound="gdvGroups_RowDataBound">
                        <FooterStyle BackColor="#CCCCCC" />
                        <RowStyle CssClass="gridviewitem" />
                        <SelectedRowStyle Font-Bold="True" />
                        <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                        <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblGroupId" runat="server" Text='<%#Bind("GroupId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Group Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblGroupName" runat="server" Text='<%#Bind("GroupName")%>'></asp:Label>
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
