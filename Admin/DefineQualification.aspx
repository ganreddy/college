<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
CodeFile="DefineQualification.aspx.cs" Inherits="Admin_DefineQualification" Title="Define Qulification" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function validate()
    {
     if(! ValidateTextFormat('<%=txtQual.ClientID%>',"Please Enter Qualification"))return false;
    }
    function Confirm()
    {
        var con = confirm("Do You Want Delete This Qualification?");
    if(con==true){return true;}
    else{con==false;}
    }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
    <ContentTemplate>
   
    <table align="center" class="tdcls" width="50%">
        <tr>
            <td>
                <asp:HiddenField ID="hdnQualificationID" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="heading" style="text-align: center">
                DEFINE QUALIFICATION
            </td>
        </tr>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Qualification: <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtQual" runat="server"></asp:TextBox>
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
        
        <tr>
            <td align="center">
               <asp:GridView ID="gdvQualification" runat="server" AutoGenerateColumns="False" 
                    BackColor="#CCCCCC" CellSpacing="2" 
                    onrowcommand="gdvQualification_RowCommand" 
                    onrowdatabound="gdvQualification_RowDataBound">   
                <FooterStyle BackColor="#CCCCCC" />
                <RowStyle CssClass="gridviewitem" />
                <SelectedRowStyle Font-Bold="true" />
                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="true" ForeColor="White" />
                    <Columns>
                   <asp:TemplateField Visible="false">
                   <ItemTemplate>
                   <asp:Label ID="lblQualificationID" runat="server" Text='<%#Bind("QualificationID") %>'></asp:Label>
                   </ItemTemplate>
                   </asp:TemplateField> 
                   <asp:TemplateField HeaderText="Qualification Details">
                   <ItemTemplate>
                   <asp:Label ID="lblQualificationDetails" runat="server" Text='<%#Bind("QualificationDetails") %>'></asp:Label>
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

