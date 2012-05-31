<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DefineFeeAllocation.aspx.cs" Inherits="Admin_DefineFeeAllocation" Title="Define Fee Allocation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        function validate() {
            if (!DropdownValidate('<%=ddlYear.ClientID%>', "Please Select Year")) return false;

            // var Decimal = /^[0-9]+(\.[0-9]+){0,1}+$/;
            var Decimal = /^[0-9]+(\.[0-9]+)+$/;
            var atLeast = 1;
            var CHK = document.getElementById("<%=chklist.ClientID%>");
            var checkbox = CHK.getElementsByTagName("input");
            var counter = 0;
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].checked) {
                    counter++;
                }
            }
            if (atLeast > counter) {
                alert("Please Select Atleast One Class");
                return false;
            }
            if (!DropdownValidate('<%=ddlCategory.ClientID%>', "Please Select Category")) return false;
            if (!DropdownValidate('<%=ddlFeeType.ClientID%>', "Please Select Fees Type")) return false;


            var isValid = 0;
            var gridView = document.getElementById('<%= gdvFeeAlloc.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null) {
                    if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                            isValid = 1;
                            if (inputs.length == 2) {
                                if (inputs[1].type == "text") {
                                    if (!inputs[1].value.match(Decimal)) {
                                        alert("Please Enter Valid Amount(like 1200.00)");
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (isValid == 0) {
                alert("Please Select Atleast One Fee Header");
                return false;
            }


        }
        function Show() {
            var chkBoxList = document.getElementById('<%=chklist.ClientID%>');
            var chkBoxCount = chkBoxList.getElementsByTagName("input");
            var flag = 0;
            for (var i = 0; i < chkBoxCount.length; i++) {
                if (chkBoxCount[i].checked == true) {

                    if (chkBoxCount[i].nextSibling.innerHTML == "11th") {
                        
                        flag = 1;
                        break;
                        
                        
                    }

                    if (chkBoxCount[i].nextSibling.innerHTML == "12th") {
                       
                        flag = 1;
                        break;


                    }

                }


            }
            if (flag == 1) {
               
                document.getElementById('<%=pnl.ClientID %>').style.display = "inline";
            }
            else {
                
                document.getElementById('<%=pnl.ClientID %>').style.display = "none";
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
                        <td colspan="2" class="heading">
                            DEFINE FEE ALLOCATION
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:HiddenField ID="hdnFee" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Year <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlYear" runat="server" Width="154px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Branch <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:CheckBoxList ID="chklist" runat="server" Width="77px">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr id="pnl" runat="server">
                        
                            <td class="subhead">
                                Group
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlGropu" runat="server" Height="16px" Width="151px">
                                </asp:DropDownList>
                            </td>
                        
                    </tr>
                    <tr>
                        <td class="subhead">
                            Category <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" runat="server" Width="154px">
                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                <asp:ListItem Value="1">Officers</asp:ListItem>
                                <asp:ListItem Value="2">JCO</asp:ListItem>
                                <asp:ListItem Value="3">OR</asp:ListItem>
                                <asp:ListItem Value="4">Civilians</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Fee Type <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlFeeType" runat="server" Width="154px" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                <asp:ListItem>---Select---</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:GridView ID="gdvFeeAlloc" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2">
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#648733" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeadID" runat="server" Text='<%#Bind("HeadID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fee Header">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFeeHeader" runat="server" Text='<%#Bind("HeaderName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <%-- <asp:TextBox ID="txtamount" runat="server" onkeypress="validfloat(this,event)"></asp:TextBox>--%>
                                            <asp:TextBox ID="txtamount" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td  colspan="2">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAdd" runat="server" Text="Add"  OnClick="btnAdd_Click" />
                            <br />
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
