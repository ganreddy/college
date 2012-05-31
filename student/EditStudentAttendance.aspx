<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditStudentAttendance.aspx.cs" Inherits="student_EditStudentAttendance" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validation() {
            if (!DropdownValidate('<%=ddlBatch.ClientID%>', "Please Select Batch")) return false;
            if (!DropdownValidate('<%=ddlClasses.ClientID%>', "Please Select Class")) return false;
            if (!DropdownValidate('<%=ddlSections.ClientID%>', "Please Select Sections")) return false;

            if (!DropdownValidate('<%=ddlMonth.ClientID%>', "Please Select Month")) return false;
            if (!DropdownValidate('<%=ddlYear.ClientID%>', "Please Select Year")) return false;


            if (!isNumeric('<%=txtnoofworkingdays.ClientID%>', "Please Enter Valid Number Of Working Days")) return false;
            //      if(document.getElementById('<%=txtnoofworkingdays.ClientID %>').value!="")
            //        {
            //         if(! ZipCode('<%=txtnoofworkingdays.ClientID %>',"Please Enter Correct Number Of Working Days")) return false;
            //        }
            //if(! IsInteger('<%=txtnoofworkingdays.ClientID%>',"Please Enter Number Of Working Days less than 31"))return false;
            var Days = document.getElementById('<%=txtnoofworkingdays.ClientID%>').value;
            var Month = document.getElementById('<%=ddlMonth.ClientID%>').selectedIndex;
            if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12) {
                if (Days > 31) {
                    alert("Please Enter Days between 1 and 31");
                    document.getElementById('<%=txtnoofworkingdays.ClientID%>').focus();
                    return false;
                }
            }
            if (Month == 4 || Month == 6 || Month == 9 || Month == 11) {
                if (Days > 30) {
                    alert("Please Enter Number Of Working Days Between 1 And 30");
                    document.getElementById('<%=txtnoofworkingdays.ClientID%>').focus();
                    return false;
                }
            }
            var year = document.getElementById('<%=ddlYear.ClientID%>').value;
            if (Month == 2) {
                if (year % 4 == 0) {
                    var flag = false;
                    if (year % 100 != 0) flag = true;
                    else if (year % 400 == 0) flag = true;
                    if (flag) {
                        if (Days > 29) {
                            alert("Enter Days Between 1 And 28 For Leap Year");
                            return false;
                        }
                    }
                }
                else
                    if (Days > 28) {
                    alert("please Enter Days Between 1 And 28");
                    return false;
                }
            }
            else {
                return true;
            }

        }

        function Checkvalidation() {

            var Days = document.getElementById('<%=txtnoofworkingdays.ClientID%>').value;
            var Month = document.getElementById('<%=ddlMonth.ClientID%>').selectedIndex;
            if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12) {
                if (Days > 31) {
                    alert("Please Enter Days Between 1 And 31");
                    document.getElementById('<%=txtnoofworkingdays.ClientID%>').focus();
                    return false;
                }
            }
            if (Month == 4 || Month == 6 || Month == 9 || Month == 11) {
                if (Days > 30) {
                    alert("Please Enter Number Of Working Days Between 1 And 30");
                    document.getElementById('<%=txtnoofworkingdays.ClientID%>').focus();
                    return false;
                }
            }
            var year = document.getElementById('<%=ddlYear.ClientID%>').value;
            if (Month == 2) {
                if (year % 4 == 0) {
                    var flag = false;
                    if (year % 100 != 0) flag = true;
                    else if (year % 400 == 0) flag = true;
                    if (flag) {
                        if (Days > 29) {
                            alert("Enter Days Between 1 And 28 For Leap Year");
                            return false;
                        }
                    }
                }
                else
                    if (Days > 28) {
                    alert("please Enter Days Between 1 And 28");
                    return false;
                }
            }
            else {
                return true;
            }

        }
        function Numeric(Id) {
            var unicode = Id.charCode ? Id.charCode : Id.keyCode
            if (unicode != 8) { //if the key isn't the backspace key (which we should allow)
                if (unicode < 48 || unicode > 57) {//if not a number
                    alert("Enter Numeric Only");
                    return false //disable key press
                }
            }
        }
    </script>


    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    
    <asp:UpdatePanel runat="server" ID="updStdAttendance">
        <ContentTemplate>
            <div>
                <table align="center" class="tdcls" width="50%">
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
                        </td>
                    </tr>
                    <tr>
                        <td class="heading" colspan="2" style="text-align: center">
                            STUDENT ATTENDACE
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Batch <span style="font-size: 17px; color: Red">*</span>
                        </td>
                        <td width="30">
                            <asp:DropDownList ID="ddlBatch" runat="server" Width="154px" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Selectede</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Class <span style="font-size: 17px; color: Red">*</span>
                        </td>
                        <td width="30">
                            <asp:DropDownList ID="ddlClasses" runat="server" Width="154px" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Selgrect</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Section <span style="font-size: 17px; color: Red">*</span>
                        </td>
                        <td width="30">
                            <asp:DropDownList ID="ddlSections" runat="server" Width="154px" OnSelectedIndexChanged="ddlSections_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Select Month &amp; Year <span style="font-size: 17px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMonth" runat="server" Height="16px" Width="77px">
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
                            <asp:DropDownList ID="ddlYear" runat="server" Height="16px" Width="73px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            No of Working Days <span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td style="height: 21px" width="30">
                            <asp:TextBox ID="txtnoofworkingdays" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="subhead" align="center">
                            <%--<asp:CheckBox  Text="Full Attendance" ID="chkFullance" runat="server" AutoPostBack="true"
                    oncheckedchanged="chkFullance_CheckedChanged"  />--%>
                            <asp:Button ID="btnAttendance" runat="server" Text="Get Attendance" OnClick="btnAttendance_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:GridView ID="gdvStuAttenance" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" onrowcancelingedit="gdvStuAttenance_RowCancelingEdit" 
                                onrowediting="gdvStuAttenance_RowEditing" 
                                onrowupdating="gdvStuAttenance_RowUpdating" 
                                onpageindexchanging="gdvStuAttenance_PageIndexChanging">
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStudID" runat="server" Text='<%#Bind("StudID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFullName" runat="server" Text='<%#Bind("FullName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No OF Days Present">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoOfDaysPresents" runat="server" Text='<%#Bind("DaysPresent")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtNoOfDaysPresents" runat="server" onkeypress="return Numeric(event)" Text='<%#Bind("DaysPresent")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="true" ShowCancelButton="true" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

