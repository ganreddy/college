<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AddCoScholasticMarks.aspx.cs" Inherits="CCE_AddCoScholasticMarks" Title="Add Co-Scholastic Marks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function GetDetails(Rows, Columns) {
            document.getElementById('<%=hdnValues.ClientID%>').value = "";
            for (var i = 0; i < Rows; i++) {
                var txtTotalID = "ctl00_ContentPlaceHolder1_txtTotal" + i;
                var gradeID = "ctl00_ContentPlaceHolder1_txtGrade" + i;
                var Weigthage = "ctl00_ContentPlaceHolder1_txtAverage" + i;
                for (var j = 0; j < Columns; j++) {
                    var txtID = "ctl00_ContentPlaceHolder1_txtMarks" + i + j;
                    if (j != Columns - 1)
                        document.getElementById('<%=hdnValues.ClientID%>').value += document.getElementById("ctl00_ContentPlaceHolder1_hdnStdID" + i).value + "~" + document.getElementById("ctl00_ContentPlaceHolder1_hdnScholasticID" + j).value + "~" + document.getElementById(txtID).value + "#";
                    else
                        document.getElementById('<%=hdnValues.ClientID%>').value += document.getElementById("ctl00_ContentPlaceHolder1_hdnStdID" + i).value + "~" + document.getElementById("ctl00_ContentPlaceHolder1_hdnScholasticID" + j).value + "~" + document.getElementById(txtID).value;
                }
                document.getElementById('<%=hdnValues.ClientID%>').value += "@"
                if (i != Rows - 1)
                    document.getElementById('<%=hdnTotal.ClientID%>').value += document.getElementById("ctl00_ContentPlaceHolder1_hdnStdID" + i).value + "~" + document.getElementById(txtTotalID).value + "~" + document.getElementById(gradeID).value + "~" + document.getElementById(Weigthage).value + "#";
                else
                    document.getElementById('<%=hdnTotal.ClientID%>').value += document.getElementById("ctl00_ContentPlaceHolder1_hdnStdID" + i).value + "~" + document.getElementById(txtTotalID).value + "~" + document.getElementById(gradeID).value + "~" + document.getElementById(Weigthage).value;

            }


        }
        function Validate(Presentrow, Presentcolumn) {

            if ((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 46)
                event.keyCode = event.keyCode;
            else
                event.keyCode = 0;
        }
        function CalcMarks(Presentrow, Presentcolumn, TotalColumns) {
            var sum = 0, txtValue = 0, TotalMarks = 0;
            for (var i = 0; i < TotalColumns; i++) {

                var txtID = "ctl00_ContentPlaceHolder1_txtMarks" + Presentrow + i;
                var MarksID = "ctl00_ContentPlaceHolder1_hdnMaxMarks" + i;
                if (parseFloat(document.getElementById(txtID).value) > parseFloat(document.getElementById(MarksID).value)) {
                    alert("Marks Should not be greater than " + document.getElementById(MarksID).value);
                    return false;
                }
                TotalMarks += parseFloat(document.getElementById(MarksID).value);
                //alert(TotalMarks);
                if (document.getElementById(txtID).value == "")
                    txtValue = 0;
                else
                    txtValue = parseFloat(document.getElementById(txtID).value);
                sum = parseFloat(sum) + txtValue;
            }
            document.getElementById("ctl00_ContentPlaceHolder1_txtTotal" + Presentrow).value = sum;
            document.getElementById("ctl00_ContentPlaceHolder1_txtAverage" + Presentrow).value = sum / TotalColumns;
            sum = parseFloat(sum / TotalColumns);
            if (parseFloat(sum) > parseFloat(4.0) && parseFloat(sum) <= parseFloat(5.0))
                document.getElementById("ctl00_ContentPlaceHolder1_txtGrade" + Presentrow).value = "A";
            if (parseFloat(sum) >= parseFloat(3.1) && parseFloat(sum) <= parseFloat(4.0))
                document.getElementById("ctl00_ContentPlaceHolder1_txtGrade" + Presentrow).value = "B";
            if (parseFloat(sum) >= parseFloat(2.1) && parseFloat(sum) <= parseFloat(3.0))
                document.getElementById("ctl00_ContentPlaceHolder1_txtGrade" + Presentrow).value = "C";
            if (parseFloat(sum) >= parseFloat(1.1) && parseFloat(sum) <= parseFloat(2.0))
                document.getElementById("ctl00_ContentPlaceHolder1_txtGrade" + Presentrow).value = "D";
            if (parseFloat(sum) >= parseFloat(0) && parseFloat(sum) <= parseFloat(1.0))
                document.getElementById("ctl00_ContentPlaceHolder1_txtGrade" + Presentrow).value = "E";

        }
        function Clear() {
            document.getElementById('<%=ddlCoscholastic.ClientID%>').value = 0;
            document.getElementById('<%=ddlSkills.ClientID%>').value = 0;
            document.getElementById('<%=ddlBatch.ClientID%>').value = 0;
            document.getElementById('<%=ddlClass.ClientID%>').value = 0;
            document.getElementById('<%=ddlSection.ClientID%>').value = 0;
        }
        function validation() {
            if (!DropdownValidate('<%=ddlCoscholastic.ClientID%>', "Please Select Co-Scholastic Area")) return false;
            if (!DropdownValidate('<%=ddlSkills.ClientID%>', "Please Select Skills")) return false;
            if (!DropdownValidate('<%=ddlBatch.ClientID%>', "Please Select Batch")) return false;
            if (!DropdownValidate('<%=ddlClass.ClientID%>', "Please Select Class")) return false;
            if (!DropdownValidate('<%=ddlSection.ClientID%>', "Please Select Section")) return false;
        }
    </script>

    <%-- <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>--%>
    <div>
        <table align="center" class="tdcls" width="60%">
            <tr>
                <td colspan="2" class="heading">
                    ADD CO-SCHOLASTIC MARKS
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
                    <asp:HiddenField ID="hdnTotal" runat="server" />
                </td>
            </tr>
            <tr id="Tr1" visible="false" runat="server">
                <td class="subhead">
                    Academic Year<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server" Width="154px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Co-Scholastic Area <span style="font-size: 10px; color: #CC3300">*</span>
                    <td>
                        <asp:DropDownList ID="ddlCoscholastic" runat="server" AutoPostBack="true" Width="180"
                            OnSelectedIndexChanged="ddlCoscholastic_SelectedIndexChanged" TabIndex="1">
                        </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td class="subhead">
                    SKILLS <span style="font-size: 10px; color: #CC3300">*</span>
                    <td>
                        <asp:DropDownList ID="ddlSkills" runat="server" AutoPostBack="true" Width="180" OnSelectedIndexChanged="ddlSkills_SelectedIndexChanged" TabIndex="2">
                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td class="subhead">
                    Batch<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlBatch" runat="server" Width="180px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" TabIndex="3">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Class<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlClass" runat="server" Width="180px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" TabIndex="4">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Section <span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSection" runat="server" Width="180px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlSection_SelectedIndexChanged" TabIndex="5">
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
                <td align="center" style="height: 15px;" colspan="2">
                    <br />
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" OnClick="btnAdd_Click" TabIndex="6"/>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" Width="50px" TabIndex="7"/>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
