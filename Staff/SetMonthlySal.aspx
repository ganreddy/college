<%@ Page AutoEventWireup="true" CodeFile="SetMonthlySal.aspx.cs" Inherits="SetMonthlySal"
    Language="C#" MasterPageFile="~/MasterPage.master" Title="Monthly Salary" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validation() {
            if (!DropdownValidate('<%=ddlStaffName.ClientID%>', "Please Select Staff")) return false;
            if (!DropdownValidate('<%=ddlMnth.ClientID%>', "Please Select Month")) return false;
            if (!DropdownValidate('<%=ddlYear.ClientID%>', "Please Select Year")) return false;
        }
        function allowNum() {
            if ((event.keyCode > 47 && event.keyCode < 58) || (event.keyCode == 46)) {
                event.keyCode = event.keyCode;
            }
            else {
                event.keyCode = 0;
            }
        }
        function calc() {

            var Str = new String(document.getElementById('<%=hdn.ClientID%>').value);
            var Add = parseInt(Str.split('@')[0]);
            var Ded = parseInt(Str.split('@')[1]);
            var sum = 0, sub = 0;
            for (i = 1; i <= Add; i++) {
                if (document.getElementById('ctl00_ContentPlaceHolder1_txtAdd' + i).value != "")
                    sum = sum + parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_txtAdd' + i).value);
            }
            document.getElementById('<%=txtadd.ClientID%>').value = parseFloat(sum);
            for (j = 1; j <= Ded; j++) {
                if (document.getElementById('ctl00_ContentPlaceHolder1_txtDed' + j).value != "")
                    sub = sub + parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_txtDed' + j).value);
            }
            document.getElementById('<%=txtDel.ClientID%>').value = parseFloat(sub);
            document.getElementById('<%=txtGrand.ClientID%>').value = parseFloat(sum) - parseFloat(sub);



        }
    
    </script>
    <asp:ScriptManager ID="sct" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div>
                <table width="80%" align="center" border="0">
                    <tr>
                        <td colspan="2">
                            <asp:HiddenField ID="hdn" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="heading" nowrap>
                            &nbsp;MONTHLY SALARIES&nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="tdcls" width="100%">
                                <tr>
                                    <td class="subhead" nowrap>
                                        Staff Name<span style="font-size: 12px; color: Red">*</span>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlStaffName" runat="server" Width="154px">
                                            <asp:ListItem>select</asp:ListItem>
                                            <asp:ListItem>qq</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subhead" nowrap>
                                        Select Month <span style="font-size: 12px; color: Red">*</span>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlMnth" runat="server" Width="154px">
                                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                                            <asp:ListItem Value="1">Jan</asp:ListItem>
                                            <asp:ListItem Value="2">Feb</asp:ListItem>
                                            <asp:ListItem Value="3">Mar</asp:ListItem>
                                            <asp:ListItem Value="4">Apr</asp:ListItem>
                                            <asp:ListItem Value="5">May</asp:ListItem>
                                            <asp:ListItem Value="6">June</asp:ListItem>
                                            <asp:ListItem Value="7">July</asp:ListItem>
                                            <asp:ListItem Value="8">Aug</asp:ListItem>
                                            <asp:ListItem Value="9">Sep</asp:ListItem>
                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                            <asp:ListItem Value="11">Nov</asp:ListItem>
                                            <asp:ListItem Value="12">Dec</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subhead" nowrap>
                                        Select Year <span style="font-size: 12px; color: Red">*</span>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlYear" runat="server" Width="154px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Additions</b>
                        </td>
                        <td>
                            <b>Deductions</b>
                        </td>
                    </tr>
                    <tr>
                        <td id="saltab">
                            <table style="border-left-color: black; border-bottom-color: black; border-top-color: black;
                                border-right-color: black" id="tblAdd" border="1" runat="server">
                                <tbody>
                                </tbody>
                            </table>
                        </td>
                        <td>
                            <table style="border-left-color: black; border-bottom-color: black; border-top-color: black;
                                border-right-color: black" id="tblDed" border="1" runat="server">
                                <tbody>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td width="130">
                                        Gross
                                    </td>
                                    <td width="130">
                                        <asp:TextBox ID="txtadd" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td width="130">
                                        Total Deductions
                                    </td>
                                    <td width="130">
                                        <asp:TextBox ID="txtDel" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;" colspan="2">
                            <br />
                            NET PAY
                            <asp:TextBox ID="txtGrand" runat="server" /><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;" colspan="2">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
