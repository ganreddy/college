<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefineFeeType.aspx.cs" Inherits="Admin_DefineFeeType" Title="Define Fee Type" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>

<script type="text/javascript" language="javascript">
        function validate() {
            if (!isEmpty('<%=txtFeetype.ClientID%>', "Please Enter Fee Type")) return false;
            
            if (!isDateFormat('<%=txtDate.ClientID%>', "Please Enter Last Date In The Format Of DD/MM/YYYY")) return false;
             
        }
        function Confirm() {
            var con = confirm("Do You Want Delete This Fee Type ?");
            if (con == true) {
                return true;
            }
            else {
                return false;
            }
        }
        function Clear() {
            document.getElementById('<%=txtFeetype.ClientID%>').value = "";
            document.getElementById('<%=txtDate.ClientID%>').value = "";
            document.getElementById('<%=btnAdd.ClientID%>').innerText = "Add";
            //return false;
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
                            DEFINE FEE TYPE
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Fee Type <span style="font-size: 10px; color: #CC3300">*</span>
                            <td>
                                <asp:TextBox ID="txtFeetype" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                    
                    <tr>
                        <td class="subhead">
                            Last Date Of The Fee<td>
                                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                <asp:ImageButton runat="server" ID="Img4" alt="Pick a date" border="0" Height="16"
                            src="../images/cal.gif" Width="16" />
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Img4"
                            TargetControlID="txtDate" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                            </td>
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
                                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="50px" 
                                onclick="btnClear_Click" />
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
                            <asp:GridView ID="gdvAccountsHead" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" onrowcommand="gdvAccountsHead_RowCommand" 
                                AllowPaging="true" PageSize="10"
                                onrowdatabound="gdvAccountsHead_RowDataBound" 
                                onpageindexchanging="gdvAccountsHead_PageIndexChanging" >
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                   <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeadID" runat="server" Text='<%#Bind("FeeTypeID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fee Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeadName" runat="server" Text='<%#Bind("FeeType")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Last Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLastDate" runat="server" Text='<%#Bind("LastDate")%>'></asp:Label>
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

