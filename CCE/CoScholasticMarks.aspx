<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CoScholasticMarks.aspx.cs" Inherits="CCE_CoScholasticMarks" Title="Co-Scholastic Marks" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript">
    
    </script>
    
    <script type="text/javascript" language="javascript">
        function validation()
    {
   // alert();
    if (!DropdownValidate('<%=ddlBatch.ClientID%>', "Please Select Batch")) return false;
    if (!DropdownValidate('<%=ddlClass.ClientID%>', "Please Select Class")) return false;
    if (!DropdownValidate('<%=ddlSection.ClientID%>', "Please Select Section")) return false;
    if (!DropdownValidate('<%=ddlCoScholasticArea.ClientID%>', "Please Select Co-Scholastic Area")) return false;
    }
    </script>


    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div>
        <table align="center" class="tdcls" width="60%">
            <tr>
                <td colspan="2" class="heading">
                    C0-SCHOLASTIC MARKS
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:HiddenField ID="hdnWeightage" runat="server" />
                    <asp:HiddenField ID="hdnValues" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Batch<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlBatch" runat="server" Width="154px" 
                        AutoPostBack="true" onselectedindexchanged="ddlBatch_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Class<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlClass" runat="server" Width="154px" 
                        AutoPostBack="true" onselectedindexchanged="ddlClass_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Section <span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSection" runat="server" Width="154px" 
                        AutoPostBack="true" onselectedindexchanged="ddlSection_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Co-Scholastic Area <span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCoScholasticArea" runat="server" Width="154px" 
                        AutoPostBack="true" 
                        onselectedindexchanged="ddlCoScholasticArea_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Table ID="tb" runat="server" BorderWidth="1">
                    </asp:Table>
                </td>
            </tr>
            
             <tr>
             <td align="center" colspan="2">
                 <asp:GridView ID="gdvCoScholastic" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                     CellSpacing="2" onrowdatabound="gdvCoScholastic_RowDataBound" >
                     <FooterStyle BackColor="#CCCCCC" />
                     <RowStyle CssClass="gridviewitem" />
                     <SelectedRowStyle Font-Bold="True" />
                     <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                     <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                     <Columns>
                        <asp:TemplateField HeaderText="StudID" Visible="false">
                             <ItemTemplate>
                                 <asp:Label ID="lblStudID" runat="server" Text='<%#Bind("StudID")%>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField >
                         <asp:TemplateField  >
                             <ItemTemplate>
                                 <asp:CheckBox ID="chkSelect" runat="server" />
                             </ItemTemplate>
                         </asp:TemplateField >
                         
                         <asp:TemplateField HeaderText="FullName">
                             <ItemTemplate>
                                 <asp:Label ID="lblFullName" runat="server" Text='<%#Bind("FullName")%>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField >
                         <asp:TemplateField HeaderText="Category">
                             <ItemTemplate>
                                 <asp:Label ID="lblCaste" runat="server" Text='<%#Bind("Caste")%>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Category">
                             <ItemTemplate>
                                 <asp:Label ID="lblCasteID" runat="server" Text='<%#Bind("CasteID")%>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Sex">
                             <ItemTemplate>
                                 <asp:Label ID="lblGender" runat="server" Text='<%#Bind("gender")%>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                        
                       <asp:TemplateField HeaderText="Indicators">
                             <ItemTemplate>
                                 <asp:CheckBoxList ID="chkIndicators" runat="server" >
                                 
                                 </asp:CheckBoxList>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Grade">
                             <ItemTemplate>
                                 <asp:TextBox ID="txtGrade" runat="server" Width="100%"></asp:TextBox>
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
            <tr>
                <td align="center" style="height: 15px;" colspan="2">
                    <br />
                    <asp:Button ID="btnAdd" runat="server" Text="Save" Width="50px" 
                        onclick="btnAdd_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            
        </table>
       
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
