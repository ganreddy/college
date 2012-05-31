<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="StaffTrainingCourses.aspx.cs" Inherits="StaffTrainingCourses" Title="Staff Training Courses" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validation() {
            if (!DropdownValidate('<%=ddlStaffId.ClientID%>', "Please Select Staff")) return false;
            if (!isEmpty('<%=txtTrainingCourseName.ClientID%>', "Please Enter Training Course Name")) return false;
            if (!isEmpty('<%=txtPlaceHeldAt.ClientID%>', "Please Enter Place Held At")) return false;

            if (!isEmpty('<%=txtFrom.ClientID%>', "Please Enter From Date")) return false;
            if (document.getElementById('<%=txtFrom.ClientID %>').value != "") {
                if (!isDateFormat('<%=txtFrom.ClientID %>', "Date Format Should Be DD/MM/YYYY")) return false;
            }
            if (!isEmpty('<%=txtTo.ClientID%>', "Please Enter To Date")) return false;
            if (document.getElementById('<%=txtTo.ClientID %>').value != "") {
                if (!isDateFormat('<%=txtTo.ClientID %>', "Date Format Should Be DD/MM/YYYY")) return false;
            }
            if (!DateFormat12('<%=txtFrom.ClientID%>', '<%=txtTo.ClientID%>', "From Date Cannot Be Less Than To Date ")) return false;
        }
        function Confirm() {
            var con = confirm("Do You Want Delete This Caste?");
            if (con == true) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="upd" runat="server">
            <ContentTemplate>
                <table align="center" class="tdcls" width="60%">
                    <tr>
                        <td class="heading" colspan="2" style="text-align: center">
                            STAFF TRAINING COURSES
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Staff<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStaffId" runat="server" Width="154px" OnSelectedIndexChanged="ddlStaffId_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblMessage1" runat="server" Text="No Training Courses To This Employee"
                                Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Training Course Name<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTrainingCourseName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Place Held At<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPlaceHeldAt" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="heading" colspan="2">
                            DURATION
                        </td>
                    </tr>
                </table>
                <table align="center" class="tdcls" width="60%">
                    <tr>
                        <td class="subhead">
                            From<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                            <img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                                id="imgCalFrom">
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                                PopupButtonID="imgCalFrom" Format="dd/MM/yyyy" />
                        </td>
                        <td class="subhead">
                            To<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                            <img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                                id="imgCalTo">
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                                PopupButtonID="imgCalTo" Format="dd/MM/yyyy" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" style="height: 26px">
                            <asp:Button ID="btnSave" runat="server" Text="Save" Width="123px" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField ID="Message" runat="server" />
                        </td>
                    </tr>
                    <table align="center">
                        <tr>
                            <td align="center">
                                <asp:GridView ID="gdvTrainingCourses" runat="server" AutoGenerateColumns="False"
                                    BackColor="#CCCCCC" CellSpacing="2" AllowPaging="True" OnPageIndexChanging="gdvTrainingCourses_PageIndexChanging"
                                    OnRowCommand="gdvTrainingCourses_RowCommand" OnRowDataBound="gdvTrainingCourses_RowDataBound">
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <RowStyle CssClass="gridviewitem" />
                                    <SelectedRowStyle Font-Bold="True" />
                                    <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStaffID" runat="server" Text='<%#Bind("StaffId")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CourseName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCourseName" runat="server" Text='<%#Bind("CourseName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PlaceHeld">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPlaceHeld" runat="server" Text='<%#Bind("PlaceHeld")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FromDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFromDate" runat="server" Text='<%#Bind("FromDate")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ToDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblToDate" runat="server" Text='<%#Bind("toDate")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="editing"></asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="del"></asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
