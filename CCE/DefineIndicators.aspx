<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefineIndicators.aspx.cs" Inherits="CCE_DefineIndicators" Title="Define Co-Scholastic Indicators" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() {
            if (!DropdownValidate('<%=ddlCoscholastic.ClientID%>', "Please Select Co-Scholastic Area")) return false;
            if(document.getElementById('<%=ddlSkills.ClientID%>').options.length > 1 )  
            {
              if (!DropdownValidate('<%=ddlSkills.ClientID%>', "Please Select Skill")) return false;
            }
            if (!isEmpty('<%=txtIndicator.ClientID%>', "Please Enter Indicator")) return false;
           
        }
        function Confirm() {
            var con = confirm("Do You Want To Delete This Indicator ?");
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
            document.getElementById('<%=txtIndicator.ClientID%>').value = "";
            document.getElementById('<%=btnAdd.ClientID%>').value = "Add";
            
            
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
                            <asp:HiddenField ID="hdnAccountHeadID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="heading" style="text-align: center">
                            DEFINE CO-SCHOLASTIC INDICATORS
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Co-Scholastic Area <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:DropDownList ID="ddlCoscholastic" runat="server" 
                                    onselectedindexchanged="ddlCoscholastic_SelectedIndexChanged" AutoPostBack="true" Width="180">
                                </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Skills 
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
                            Co-Scholastic Indicator <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:TextBox ID="txtIndicator" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
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
                            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" 
                                onclick="btnAdd_Click"  />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="50px" onclick="btnClear_Click" 
                                />
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
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
                            <asp:GridView ID="gdvIndicators" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" onrowcommand="gdvIndicators_RowCommand" 
                                AllowPaging="true" PageSize="10"
                                onrowdatabound="gdvIndicators_RowDataBound" 
                                onpageindexchanging="gdvIndicators_PageIndexChanging" >
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                   <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIndicatorID" runat="server" Text='<%#Bind("IndicatorID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Indicator">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIndicator" runat="server" Text='<%#Bind("Indicator")%>'></asp:Label>
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

