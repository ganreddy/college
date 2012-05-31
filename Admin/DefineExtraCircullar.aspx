<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefineExtraCircullar.aspx.cs" 
Inherits="Admin_DefineExtraCircullar" Title="Define Extra Curricular" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function validate()
    {
     if(! isEmpty('<%=txtExtraCircullar.ClientID%>',"Please Enter Extra Curricular Activity"))return false;
    }
     function Confirm()
    {
        var con = confirm("Do You Want Delete This Extra Curricular Activity");
    if(con==true)
    {
    return true;
    }
    else{return false;}
    }
    </script>
    

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
    <ContentTemplate>
    
    <table align="center" class="tdcls" width="50%">
        <tr>
            <td>
                <asp:HiddenField ID="hdnExtraCurricularID" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="heading" style="text-align: center">
                DEFINE EXTRA CURRICULAR ACTIVITIES
            </td>
        </tr>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="subhead" >
                Extra Curricular Activity: <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtExtraCircullar" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>&nbsp;
    <table align="center" class="tdcls">
        <tr>
            <td align="center">
                <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" onclick="btnAdd_Click" 
                    />&nbsp;&nbsp;
                
            </td>
        </tr>
        <tr><td></td></tr>
        <tr><td></td></tr>
        <tr><td><asp:Label ID="lblMessage" runat="server"></asp:Label></td></tr>
        <tr><td></td></tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gdvECA" runat="server" AutoGenerateColumns="False" 
                    AllowPaging="true" PageSize="10"
                    BackColor="#CCCCCC" CellSpacing="2" onrowcommand="gdvECA_RowCommand" 
                    onrowdatabound="gdvECA_RowDataBound" 
                    onpageindexchanging="gdvECA_PageIndexChanging" > 
                    
                <FooterStyle BackColor="#CCCCCC" />
                <RowStyle CssClass="gridviewitem" />
                <SelectedRowStyle Font-Bold="true" />
                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="true" ForeColor="White" />
                    <Columns>
                   <asp:TemplateField Visible="false">
                   <ItemTemplate>
                   <asp:Label ID="lblExtraCurricularID" runat="server" Text='<%#Bind("ExtraCurricularID") %>'></asp:Label>
                   </ItemTemplate>
                   </asp:TemplateField> 
                   <asp:TemplateField HeaderText="Extra Curricular Activity">
                   <ItemTemplate>
                   <asp:Label ID="lblActivity" runat="server" Text='<%#Bind("Activity") %>'></asp:Label>
                   </ItemTemplate>
                   <%--<EditItemTemplate>
                   <asp:Label ID="lblClassNo" runat="server" Text='<%#Bind("ClassName")%>'></asp:Label>
                   </EditItemTemplate>--%>
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

