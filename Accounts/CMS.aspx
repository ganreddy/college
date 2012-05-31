<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CMS.aspx.cs" Inherits="Accounts_CMS" Title="Consolidated Monthly Statement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function PrintWin() {
            window.print();
        }
        function CheckRadio(rowindex) {
            var count = 0;
            var tableElement = document.getElementById('<%=rdbPlan.ClientID%>');
            for (var i = 1; i < tableElement.rows.length; i++) {
                var rowElem = tableElement.rows[i];
                var cell = rowElem.cells[0];
                //alert(cell);
                if (cell.childNodes[0].type == "radio") {
                    //assign the status of the Select All checkbox to the cell checkbox within the grid
                    cell.childNodes[0].checked = false;
                }

            }
            tableElement.rows[rowindex + 1].cells[0].childNodes[0].checked = true;
            


        }
        function validations() {
            if (!DropdownValidate('<%=ddlMnth.ClientID%>', "Please Select Month")) return false;
            if (!DropdownValidate('<%=ddlYear.ClientID%>', "Please Select Year")) return false;
            if (!validationCheckList('<%=rdbPlan.ClientID%>', "Please Select Planned/Non-Planned")) return false;
           

    }
    function validationCheckList(elem, msg) {


        var chkBoxList = document.getElementById(elem);
        if (chkBoxList != null) {
            var chkBoxCount = chkBoxList.getElementsByTagName("input");
            var flag = 0;
            for (var i = 0; i < chkBoxCount.length; i++) {
                if (chkBoxCount[i].checked == true) {
                    flag = 1;
                }
            }
            if (flag == 1) {
                return true
            }
            else {
                alert(msg);
                return false;
            }
        }

    }
    </script>

    <table width="80%" align="center" border="0">
        <tr>
            <td colspan="2">
                <asp:HiddenField ID="hdn" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="heading" nowrap>
                CONSOLIDATED MONTHLY STATEMENT
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tdcls" width="100%">
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
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td class="subhead" nowrap>
                            <asp:RadioButtonList ID="rdbPlan" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Planned" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Non-Planned" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="Get Statement" OnClick="btnSave_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnPrint" runat="server" Text="Print" />
            </td>
        </tr>
    </table>
    <table width="100%" style="border-left-color: black; border-bottom-color: black;
        border-top-color: black; border-right-color: black; font-size: 12px" id="tblCMS"
        border="1" runat="server">
        <tr>
            <td width="5%">
                S.No
            </td>
            <td width="35%">
                HEAD OF ACCOUNT / UNITS
            </td>
            <td width="20%">
                <table style="border-left-color: black; border-bottom-color: black; border-top-color: black;
                    border-right-color: black; font-size: 12px" border="1" width="100%">
                    <tr>
                        <td colspan="2" align="center">
                            Budget Allocation
                        </td>
                    </tr>
                    <tr>
                        <td width="50%">
                            (BE/RE/FG)
                        </td>
                        <td width="50%">
                           Cumulative upto previous Month
                        </td>
                    </tr>
                    
                </table>
            </td>
            <td width="40%" valign="top">
                <table style="border-left-color: black; border-bottom-color: black; border-top-color: black;
                    border-right-color: black; font-size: 12px" border="1" width="100%">
                    <tr>
                        <td colspan="4" align="center">
                            Actual Expenses during the month
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" nowrap>
                           Actual
                        </td>
                        <td width="25%">
                            NIBA
                        </td>
                        <td width="25%">
                            EM & SD
                        </td>
                        <td width="25%">
                            Total
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
