<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="LibBookAccession.aspx.cs" Inherits="LibBookAccession" Title="Library Book Accession" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/jscript" language="javascript">
        function RequiredValidate() {
            if (!isEmpty('<%=txtBookno.ClientID%>', "Please Enter  Accession Number")) return false;
            if (!isEmpty('<%=txtDate.ClientID%>', "Please Enter  Date of Accession ")) return false;
            if (document.getElementById('<%=txtDate.ClientID%>').value != "") {
                if (!isDateFormat('<%=txtDate.ClientID%>', "Date Format should be DD/MM/YYYY")) return false;
            }
            if (!DropdownValidate('<%=ddlBookCategory.ClientID%>', "Please Select Category")) return false;
            if (!DropdownValidate('<%=ddlMediumOfBook.ClientID%>', "Please Select Medium")) return false;

            if (!isEmpty('<%=txtPhysicalDescription.ClientID%>', "Please Enter Physical Description")) return false;
            if (!isEmpty('<%=txtIsbnNo.ClientID%>', "Please Enter ISBN")) return false;
            if (!isDecimal('<%=txtCost.ClientID%>', "Please Enter Cost(EX:800.00)")) return false;
            if (!isEmpty('<%=txtDateOfInvoice.ClientID%>', "Please Enter Date Of Invoice")) return false;
            if (document.getElementById('<%=txtDateOfInvoice.ClientID%>').value != "") {
                if (!isDateFormat('<%=txtDateOfInvoice.ClientID%>', "Date Format should be DD/MM/YYYY")) return false;
            }


            var Circulation = document.getElementById('<%=rbCirculation.ClientID%>').checked;


            var Reference = document.getElementById('<%=rbReference.ClientID%>').checked;


            if ((Circulation == false) && (Reference == false)) {
                alert("Choose Any One Circulation/Reference");
                return false;
            }


            if (!isDecimal('<%=txtCost.ClientID%>', "Please Enter Valid Cost")) return false;
            if (document.getElementById('<%=txtNoPgs.ClientID%>').value != "") {
                if (!isNumeric('<%=txtNoPgs.ClientID%>', "Please Enter Valid Pagination")) return false;
            }
            if (!DropdownValidate('<%=ddlBookStatus.ClientID%>', "Please Select Book Status")) return false;
            if (!DropdownValidate('<%=ddlTypeOfBook.ClientID%>', "Please Select Type Of Book")) return false;
            if (!isEmpty('<%=txtClassNumber.ClientID%>', "Please Enter Class No")) return false;
            if (!isEmpty('<%=txtBookNumber.ClientID%>', "Please Enter Book No")) return false;
            if (!isEmpty('<%=txtDateOfInvoice.ClientID%>', "Please Enter Date Of Invoice")) return false;
            if (document.getElementById('<%=txtDateOfInvoice.ClientID%>').value != "") {
                if (!isDateFormat('<%=txtDateOfInvoice.ClientID%>', "Date Format should be DD/MM/YYYY")) return false;
            }
        }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="udp" runat="server">
        <ContentTemplate>
            <table align="center" class="tdcls" style="width: 90%; height: 147%">
                <tr>
                    <td colspan="4" style="height: 17%" align="center">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="heading" style="height: 17%; text-align: center;">
                        BOOKS ACCESSION
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%" class="subhead">
                        Accession No<span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtBookno" runat="server" MaxLength="30"></asp:TextBox>
                    </td>
                    <td style="width: 20%" class="subhead">
                        Classification
                        <br />
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtClassification" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%" class="subhead">
                        Title
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtTitle" MaxLength="30" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 20%" class="subhead">
                        Category<span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%">
                        <asp:DropDownList ID="ddlBookCategory" runat="server" Width="154px" Height="16%"
                            OnSelectedIndexChanged="ddlBookCategory_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>India</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%" class="subhead">
                        Date Of Accession<span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtDate" MaxLength="30" runat="server"></asp:TextBox>
                        <%--<img src="../images/cal.gif" id="image1" />--%>
                        <asp:ImageButton runat="server" src="../images/cal.gif" ID="image1" />
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="image1"
                            TargetControlID="txtDate" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                    <td style="width: 20%" class="subhead">
                        Sub Category
                    </td>
                    <td style="width: 30%">
                        <asp:DropDownList ID="ddlSubCategory" runat="server" Width="154px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%" class="subhead">
                        Medium Of Book<span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%">
                        <asp:DropDownList ID="ddlMediumOfBook" runat="server" Width="154px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 20%" class="subhead">
                        Physical Description<span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%">
                        <%--<asp:DropDownList ID="DropDownList2" runat="server" Width="156px"></asp:DropDownList>--%>
                        <asp:TextBox ID="txtPhysicalDescription" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 20%" class="subhead">
                        Author(s)
                    </td>
                    <td style="height: 20%">
                        <asp:TextBox ID="txtAuthors" runat="server" MaxLength="30"></asp:TextBox>
                    </td>
                    <td style="height: 20%" class="subhead">
                        Edition
                    </td>
                    <td style="height: 20%">
                        <asp:TextBox ID="txtEdition" runat="server" MaxLength="10"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%" class="subhead">
                        Publisher
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtPublisher" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                    <td style="width: 20%" class="subhead">
                        Year Of Publication
                    </td>
                    <td style="width: 20%">
                        <asp:DropDownList ID="ddlYearofPublication" runat="server" MaxLength="6" Width="154px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%" class="subhead">
                        Place Of Publication
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtPlaceofPublication" runat="server"></asp:TextBox>
                        <td style="width: 20%" class="subhead">
                            Type Of Book<span style="color: #ff0000">*</span>
                        </td>
                        <td style="width: 30%">
                            <asp:DropDownList ID="ddlTypeOfBook" runat="server" Width="154px">
                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                <asp:ListItem Value="1">Hard Bound</asp:ListItem>
                                <asp:ListItem Value="2">Paper Bound</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td style="width: 20%" class="subhead">
                        ISBN<span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtIsbnNo" runat="server" MaxLength="20"></asp:TextBox>
                    </td>
                    <td style="width: 20%" class="subhead">
                        Subject(Provide if Available)
                    </td>
                    <td style="width: 30%">
                        <asp:DropDownList ID="ddlSubject" runat="server" Width="154px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%" class="subhead">
                        Cost<span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtCost" runat="server" MaxLength="9"></asp:TextBox>
                    </td>
                    <td style="width: 20%" class="subhead">
                        Type Of Currency
                    </td>
                    <td style="width: 30%">
                        <asp:DropDownList ID="ddlTypeOfCurrency" runat="server" Width="154px">
                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                            <asp:ListItem Value="1">Indian Rupee</asp:ListItem>
                            <asp:ListItem Value="2">US Dollar</asp:ListItem>
                            <asp:ListItem Value="3">Euro</asp:ListItem>
                            <asp:ListItem Value="4">Pound</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="width: 20%" class="subhead">
                    <td>
                        Volume
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtVolume" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 20%" class="subhead">
                        Collections<span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%">
                        <asp:RadioButton ID="rbCirculation" runat="server" CssClass="rbcls" ForeColor="Black"
                            GroupName="rbgender" Text="Circulation" /><asp:RadioButton ID="rbReference" runat="server"
                                CssClass="rbcls" ForeColor="Black" GroupName="rbgender" Text="Reference" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%" class="subhead">
                        Invoice No
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="20"></asp:TextBox>
                    </td>
                    <td style="width: 20%" class="subhead">
                        Date Of Invoice No <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtDateOfInvoice" runat="server" MaxLength="50"></asp:TextBox>
                        <%--<img src="../images/cal.gif" id="image2" />--%>
                        <asp:ImageButton runat="server" src="../images/cal.gif" ID="image2" />
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="image2"
                            TargetControlID="txtDateOfInvoice" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%" class="subhead">
                        Book Status<span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%">
                        <asp:DropDownList ID="ddlBookStatus" runat="server" Width="154px">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Text="In Library" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Out of Library" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Un Known" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 20%" class="subhead">
                        Vendor
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtVendor" MaxLength="25" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%" class="subhead">
                        Class No<span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtClassNumber" MaxLength="25" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 20%" class="subhead">
                        Book No<span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtBookNumber" MaxLength="25" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%" class="subhead">
                        Pagination
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtNoPgs" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 20%" class="subhead">
                        Source
                    </td>
                    <td style="width: 30%">
                        <asp:DropDownList ID="ddlSrc" runat="server" Width="154px" OnSelectedIndexChanged="ddlSrc_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">NVS HO</asp:ListItem>
                            <asp:ListItem Value="2">NVS RO</asp:ListItem>
                            <asp:ListItem Value="3">Local Purchase</asp:ListItem>
                            <asp:ListItem Value="4">Gift</asp:ListItem>
                            <asp:ListItem Value="5">Others</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="trOtherSrc" runat="server" visible="false">
                    <td style="width: 20%">
                        &nbsp;
                    </td>
                    <td style="width: 30%">
                        &nbsp;
                    </td>
                    <td style="width: 20%" class="subhead">
                        If Others
                    </td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtOthers" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table align="center" class="tdcls">
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblMessage1" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <table align="center" class="tdcls">
                <tr>
                    <td colspan="4" align="center" style="width: 139px">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Clear" OnClick="btnReset_Click" />&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
