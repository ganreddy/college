<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StaffSalary.aspx.cs" Inherits="Staff_StaffSalary" Title="Define Salary Heads" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
//        function validate() {
//            if (!DropdownValidate('<%=ddlStaffId.ClientID%>', "Please Select Staff")) return false;
//            if (!CheckBox1('<%=this.gdvStaffSal.ClientID%>', "Please Select The CheckBox")) return false;
//        }
        function validate() {
            if (!DropdownValidate('<%=ddlStaffId.ClientID%>', "Please Select Staff")) return false;
            var isValid = 0;
            var Decimal = /^[0-9]+(\.[0-9]+)+$/;
            var gridView = document.getElementById('<%= gdvStaffSal.ClientID %>');
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
                alert("Please Select Atleast One Check Box");
                return false;
            }


        }
      

        

//        function validfloat(txt, ev) {
//            ev.returnValue = (ev.keyCode >= 48 && ev.keyCode <= 57 || ev.keyCode == 46 && txt.value.indexOf('.') == -1);

//            if (ev.returnValue) {
//                return true;
//            }
//            else {
//                alert("Enter Numeric or Decimal Value");
//                return false;
//            }
//        }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div>
                <table align="center" class="tdcls" width="60%" border="0">
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:HiddenField ID="Message" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="heading" colspan="2" style="text-align: center">
                            STAFF SALARY
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" align="center">
                            Staff<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlStaffId" runat="server" Width="154px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <%--<tr>
                        <td colspan="3" class="subhead" align="center">
                            <asp:CheckBox Text="Full Attendance" ID="chkFullance" runat="server" AutoPostBack="true"
                                OnCheckedChanged="chkFullance_CheckedChanged" />
                        </td>
                    </tr>--%>
                    <tr class="tdcls">
                        <%-- <td align="center" colspan="2" style="width: 20%">
                            <font color="red"><b></b><sup>*</sup></font>Please Select The Absenties<font color="red"></font>
                            
                        </td>--%>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:GridView ID="gdvStaffSal" runat="server" AutoGenerateColumns="false" Style="text-align: center"
                                AllowPaging="true" PageSize="10" OnRowDataBound="dgrid_RowDataBound" OnPageIndexChanging="gdvStaffSal_PageIndexChanging">
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkAll" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeadID" runat="server" Text='<%#Bind("HeadID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Head Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeadName" runat="server" Text='<%#Bind("HeadName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Head Name">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField> --%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCalculationType" runat="server" Text='<%#Bind("CalculationType")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount/Percentage">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercentage" runat="server" Visible='<%# Convert.ToBoolean(Eval("Percentage"))%>'
                                                Text='<%#Bind("Percentage")%>'></asp:Label>
                                            <asp:TextBox ID="txtAmount" runat="server" Visible='<%#! Convert.ToBoolean(Eval("Percentage"))%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Header" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeaderID" runat="server" Text='<%#Bind("HeaderID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Header" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeaderName" runat="server" Text='<%#Bind("HeaderName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="btnSave" runat="server" Text="Save" Width="90px" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

