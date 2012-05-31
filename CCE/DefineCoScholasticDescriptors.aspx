<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefineCoScholasticDescriptors.aspx.cs" Inherits="CCE_DefineCoScholasticDescriptors" Title="Define Coscholastic Descriptors" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() {
            if(! DropdownValidate('<%=ddlCoscholastic.ClientID%>',"Please Select Co-Scholastic Area"))return false;
        }
        function Confirm() {
            var con = confirm("Do you want delete this Indicator ?");
            if (con == true) {
                return true;
            }
            else {
                return false;
            }
        }
        function Clear() {
            document.getElementById('<%=ddlCoscholastic.ClientID%>').value = 0;
            document.getElementById('<%=ddlSkills.ClientID%>').value = 0;
            document.getElementById('<%=txtDescriptor.ClientID%>').value = "";
        }
    </script>

   
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>
            <div>
                <table align="center" class="tdcls" width="50%">
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdnsecriptors" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="heading" style="text-align: center">
                            DEFINE CO-SCHOLASTIC DESCRIPTORS
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            CO-SCHOLASTIC AREA <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:DropDownList ID="ddlCoscholastic" runat="server" 
                                    onselectedindexchanged="ddlCoscholastic_SelectedIndexChanged" AutoPostBack="true" Width="180">
                                </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            SKILLS <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:DropDownList ID="ddlSkills" runat="server" 
                                    AutoPostBack="true" 
                                    onselectedindexchanged="ddlSkills_SelectedIndexChanged" Width="180">
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            DESCRIPTOR <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:TextBox ID="txtDescriptor" runat="server" TextMode="MultiLine" Rows="6"></asp:TextBox>
                            </td>
                    </tr>
                    
                    
                    
                </table>
                <table align="center" class="tdcls">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gdvGrades" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" onpageindexchanging="gdvGrades_PageIndexChanging" 
                                onrowcommand="gdvGrades_RowCommand" onrowdatabound="gdvGrades_RowDataBound">
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                   <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescriptorID" runat="server" Text='<%#Bind("descriptorid")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descriptor">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescriptor" runat="server" Text='<%#Bind("descriptor")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCoScholasticID" runat="server" Text='<%#Bind("CoScholasticID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Co-Scholastic Area">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCoscholasticArea" runat="server" Text='<%#Bind("CoScholasticArea")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAssesmentID" runat="server" Text='<%#Bind("AssesmentID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Skill">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAssesmentArea" runat="server" Text='<%#Bind("AssesmentArea")%>'></asp:Label>
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
                        <td>
                            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" 
                                onclick="btnAdd_Click"  />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="50px" 
                                 />
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

