<%@ Page Title="Define Activities" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefineActivities.aspx.cs" Inherits="Admin_DefineActivities" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
        <script src="../scripts/Validations.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function validation() {
        if (!DropdownValidate('<%=ddlClube.ClientID%>', "Please Select Club ")) return false;

        if (!isEmpty('<%=txtActivities.ClientID%>', "Please Enter Activities")) return false;
        if (!DropdownValidate('<%=ddlType.ClientID%>', "Please Select Type")) return false;
    }
    function Confirm() {
        var con = confirm("Do You Want Delete This Activiti?");
        if (con == true) {
            return true;
        }
        else {
            return false;
        }
    }

</script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
                 <table align="center" class="tdcls" width="50%">
                    <tr>
                        <td>
                          <asp:HiddenField ID="hdnActivitiesID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="heading" colspan="2" style="text-align: center">
                                DEFINE ACTIVITIES
                        </td>
                    </tr>
                     <tr>
                         <td colspan="2">
                             &nbsp;
                         </td>
                     </tr>
                     <tr>
                        <td class="subhead" width="160px">
                            Club Name<span style="font-size: 10px; color: Red">*</span></td>
                        <td>
                            <asp:DropDownList ID="ddlClube" runat="server" CssClass="txtcls" Width="154px" 
                                onselectedindexchanged="ddlClube_SelectedIndexChanged" AutoPostBack=true  >
                                
                            </asp:DropDownList>
                        </td>
                     </tr>
                     <tr>
                         <td class="subhead" width="160px">
                             Activities <span style="font-size: 10px; color: Red">*</span>
                         </td>
                         <td>
                             <asp:TextBox ID="txtActivities" runat="server"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                        <td class="subhead" width="160px">
                            Type<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlType" runat="server" CssClass="txtcls" Width="154px" 
                                onselectedindexchanged="ddlType_SelectedIndexChanged" AutoPostBack=true  >
                           <asp:ListItem Value="0">---Select---</asp:ListItem>
                            <asp:ListItem Value="1">Individual</asp:ListItem>
                            <asp:ListItem Value="2">Group</asp:ListItem>
                           </asp:DropDownList>
                        </td>
                     </tr>
                     <tr>
                         <td colspan="2" align="center">
                             <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td align="center" colspan="2">
                             <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" 
                                 onclick="btnAdd_Click"/>
                         </td>
                     </tr>
                     <tr>
                         <td align="center" colspan="2">
                             <asp:GridView ID="gdvActivities" runat="server" AutoGenerateColumns="false" BackColor="#CCCCCC"
                                 CellSpacing="2" AllowPaging="true" PageSize="8" OnRowCommand="gdvActivities_RowCommand" 
                                 onrowdatabound="gdvActivities_RowDataBound" 
                                 onpageindexchanging="gdvActivities_PageIndexChanging">
                                 <FooterStyle BackColor="#CCCCCC" />
                                 <RowStyle CssClass="gridviewitem" />
                                 <SelectedRowStyle Font-Bold="True" />
                                 <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                 <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                 <Columns>
                                    <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActid" runat="server" Text='<%#Bind("ActivitiID")%>'></asp:Label>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Activities">
                                        <ItemTemplate>
                                                <asp:Label ID="lblActivities" runat="server" Text='<%#Bind("Activities")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClub" runat="server" Text='<%#Bind("Club")%>'></asp:Label>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Club">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClubName" runat="server" Text='<%#Bind("ClubName")%>'></asp:Label>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblType" runat="server" Text='<%#Bind("Type")%>'></asp:Label>
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
        </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>

