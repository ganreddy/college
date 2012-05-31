<%@ Page Title="Define CoScholastic Grade" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefineCoScholasticGrade.aspx.cs" Inherits="CCE_DefineCoScholasticGrade" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validate() {
             if(! DropdownValidate('<%=ddlCoscholastic.ClientID%>',"Please Select Co-Scholastic Area"))return false;
             if(document.getElementById('<%=ddlSkills.ClientID%>').options.length > 1 )  
             {
              if (!DropdownValidate('<%=ddlSkills.ClientID%>', "Please Select Skill")) return false;
             }
             if (! DropdownValidate('<%=ddlGrade.ClientID%>', "Please Select Grade")) return false;
            
        }
        function Confirm() {
            var con = confirm("Do You Want To Delete This Grade?");
            if (con == true) {
                return true;
            }
            else {
                return false;
            }
        }
        function clearform()
        {
           document.getElementById('<%=ddlGrade.ClientID%>').options(document.getElementById('<%=ddlGrade.ClientID%>').selectedIndex).value = 0;
           document.getElementById('<%=ddlCoscholastic.ClientID%>').options(document.getElementById('<%=ddlCoscholastic.ClientID%>').selectedIndex).value = 0;
           document.getElementById('<%=ddlSkills.ClientID%>').options(document.getElementById('<%=ddlSkills.ClientID%>').selectedIndex).value = 0;
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
                            <asp:HiddenField ID="hdnInd" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="heading" style="text-align: center">
                            DEFINE CO-SCHOLASTIC GRADE
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
                            Skills <span style="font-size: 10px; color: #CC3300">*</span>
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
                            Grade <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                               <asp:DropDownList ID="ddlGrade" runat="server">
                               <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                               <asp:ListItem Text="A" Value="A"></asp:ListItem>
                               <asp:ListItem Text="B" Value="B"></asp:ListItem>
                               <asp:ListItem Text="C" Value="C"></asp:ListItem>
                               <asp:ListItem Text="D" Value="D"></asp:ListItem>
                               <asp:ListItem Text="E" Value="E"></asp:ListItem>
                               
                               </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Co-Scholastic Indicators <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:CheckBoxList ID="chkIndicators" runat="server" >                               
                                 </asp:CheckBoxList>
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
                                            <asp:Label ID="lblGradeID" runat="server" Text='<%#Bind("GradeID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Grade">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGrade" runat="server" Text='<%#Bind("Grade")%>'></asp:Label>
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
                                     <asp:TemplateField HeaderText="Indicators" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIndicators" runat="server" Text='<%#Bind("Indicators")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Indicators">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIndi" runat="server"></asp:Label>
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
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnClear" runat="server" Text="Clear" Width="50px" onclick="btnClear_Click" 
                                />
                        </td>
                    </tr>
                    
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

