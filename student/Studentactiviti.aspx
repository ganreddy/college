<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Studentactiviti.aspx.cs" Inherits="student_Studentactiviti" Title="Student Activities" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validation() {
            if (!DropdownValidate('<%=ddlClub.ClientID%>', "Please Select Club Name")) return false;
            if (!DropdownValidate('<%=ddlactivittype.ClientID%>', "Please Select Activity Type ")) return false;
            if (!DropdownValidate('<%=ddlActivites.ClientID%>', "Please Select Activity Name")) return false;
            if (!isEmpty('<%=txtFrom.ClientID%>', "Please Enter Date")) return false;
            if (document.getElementById('<%=txtFrom.ClientID%>').value != "") {
                if (!isDateFormat('<%=txtFrom.ClientID%>', "Date Format should Be DD/MM/YYYY")) return false;
            }
            if (!DropdownValidate('<%=ddlHouse.ClientID%>', "Please Select House")) return false;
            // if(!validationCheckList('<%=House.ClientID%>',"Please Select Check item"))return false;
            /*if(!validationCheckList('<%=SelList.ClientID%>',"Please Select Check item"))return false;*/
        }
        function val1() {
            
            if (!DropdownValidate('<%=ddlactivittype.ClientID%>', "Please Select Activity Type ")) return false;
            if (!DropdownValidate('<%=ddlActivites.ClientID%>', "Please Select Activity Name")) return false;
            if (!isEmpty('<%=txtFrom.ClientID%>', "Please Enter Date")) return false;
            if (document.getElementById('<%=txtFrom.ClientID%>').value != "") {
                if (!isDateFormat('<%=txtFrom.ClientID%>', "Date Format should Be DD/MM/YYYY")) return false;
            }
            if (!DropdownValidate('<%=ddlHouse.ClientID%>', "Please Select House")) return false;
            if (!validationCheckList('<%=SelList.ClientID%>', "Please Check item")) return false;

        }
        function val2() {
            if (!DropdownValidate('<%=ddlactivittype.ClientID%>', "Please Select Activity Type ")) return false;
            if (!DropdownValidate('<%=ddlActivites.ClientID%>', "Please Select Activity Name")) return false;
            if (!isEmpty('<%=txtFrom.ClientID%>', "Please Enter Date")) return false;
            if (document.getElementById('<%=txtFrom.ClientID%>').value != "") {
                if (!isDateFormat('<%=txtFrom.ClientID%>', "Date Format should Be DD/MM/YYYY")) return false;
            }
            if (!DropdownValidate('<%=ddlHouse.ClientID%>', "Please Select House")) return false;
            if (!validationCheckList('<%=House.ClientID%>', "Please Select Check Item")) return false;
        }
        function val3() {
            if (!validationCheckList('<%=SelList.ClientID%>', "Please Check item")) return false;

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

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>
            <table style="width: 100%; height: 100%">
                <tr>
                    
                    <td width="100%" align="center">
                        <table width="70%">
                            <tr>
                                <td class="heading" colspan="2" style="text-align: center">
                                    STUDENT ACTIVITIES
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="subhead">
                                    Club Name<span style="font-size: 17px; color: Red">*</span></td>
                                <td style="width: 169px">
                                    <asp:DropDownList ID="ddlClub" runat="server" AutoPostBack="True" 
                                        Height="16%" 
                                        Width="154px">
                                       
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="subhead">
                                    Activity Type<span style="font-size: 17px; color: Red">*</span>
                                </td>
                                <td style="width: 169px">
                                    <asp:DropDownList ID="ddlactivittype" runat="server" AutoPostBack="True" Width="154px"
                                        Height="16%" OnSelectedIndexChanged="ddlactivittype_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Individual</asp:ListItem>
                                        <asp:ListItem Value="2">Group</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            
                            <tr>
                                <td class="subhead">
                                    Activity Name<span style="font-size: 17px; color: Red">*</span>
                                </td>
                                <td style="width: 169px">
                                    <asp:DropDownList ID="ddlActivites" runat="server" Height="16px" Width="154px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="subhead">
                                    Date<span style="font-size: 17px; color: Red">*</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFrom" runat="server" Width="154px"></asp:TextBox>
                                    &nbsp;<asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="imgCalFrom" TargetControlID="txtFrom">
                                    </asp:CalendarExtender>
                                    <%--<img id="imgCalFrom" alt="Pick a date" border="0" height="16" src="../images/cal.gif"></img>--%>
                                    <asp:ImageButton  runat="server" ID="imgCalFrom" alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="subhead">
                                    House<span style="font-size: 17px; color: Red">*</span>
                                </td>
                                <td style="width: 169px">
                                    <asp:DropDownList ID="ddlHouse" runat="server" Width="154px" Height="16%" OnSelectedIndexChanged="ddlHouse_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <asp:Panel ID="tbList" runat="server">
                                            <table style="border-style: groove;">
                                                <tr>
                                                    <td>
                                                        <asp:CheckBoxList ID="House" runat="server">
                                                        </asp:CheckBoxList>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button1" runat="server" Text="&gt;&gt;" Width="29px" OnClick="Button1_Click" /><br />
                                                        <asp:Button ID="Button2" runat="server" Text="&lt;&lt;" Width="29px" OnClick="Button2_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:CheckBoxList ID="SelList" runat="server">
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </center>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="width: 169px">
                                    <asp:Button ID="btnShow" runat="server" Text="Add to Activity" OnClick="btnShow_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="SinglePnl" runat="server">
                                        <asp:GridView ID="GvSingle" runat="server" AutoGenerateColumns="False" DataKeyNames="StudID"
                                            OnRowCommand="GvSingle_RowCommand" OnRowDataBound="GvSingle_RowDataBound" OnRowUpdating="GvSingle_RowUpdating">
                                            <Columns>
                                                <asp:BoundField DataField="FullName" HeaderText="Name" />
                                                <asp:BoundField DataField="HouseName" HeaderText="House Name" />
                                                <asp:BoundField DataField="ClubName" HeaderText="Club Name" />
                                                <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClub" runat="server" Text='<%#Bind("Club")%>'></asp:Label>
                                            </ItemTemplate>
                                     </asp:TemplateField> 
                                                <asp:BoundField DataField="ClassName" HeaderText="Class" />
                                                <asp:BoundField DataField="SectionName" HeaderText="Section" />
                                                <asp:BoundField DataField="Activities" HeaderText="Activity" />
                                                    <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActivity" runat="server" Text='<%#Bind("Activity")%>'></asp:Label>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                                <asp:BoundField DataField="Date" HeaderText="Date" />
                                                <asp:TemplateField HeaderText="Prize">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlPrize" runat="server">
                                                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                            <asp:ListItem Value="1">I</asp:ListItem>
                                                            <asp:ListItem Value="2">II</asp:ListItem>
                                                            <asp:ListItem Value="3">III</asp:ListItem>
                                                            <asp:ListItem Value="4">IV</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:ButtonField ButtonType="Button" CommandName="Update" Text="Update" />
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                    <asp:Panel ID="GroupPnl" runat="server">
                                        <asp:GridView ID="GvGroup" runat="server" AutoGenerateColumns="False" OnRowCommand="GvGroup_RowCommand"
                                            OnRowDataBound="GvGroup_RowDataBound" onrowupdating="GvGroup_RowUpdating">
                                            <Columns>
                                                <asp:BoundField DataField="HouseName" HeaderText="House Name" />
                                                <asp:BoundField DataField="ClubName" HeaderText="Club Name" />
                                                <asp:BoundField DataField="Activities" HeaderText="Activity" />
                                                   <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActivity" runat="server" Text='<%#Bind("Activity")%>'></asp:Label>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                                <asp:BoundField DataField="Date" HeaderText="Date" />
                                                <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClub" runat="server" Text='<%#Bind("Club")%>'></asp:Label>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Prize">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlPrize1" runat="server">
                                                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                            <asp:ListItem Value="1">I</asp:ListItem>
                                                            <asp:ListItem Value="2">II</asp:ListItem>
                                                            <asp:ListItem Value="3">III</asp:ListItem>
                                                            <asp:ListItem Value="4">IV</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:ButtonField ButtonType="Button" CommandName="Update" Text="Update" />
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lblMassage" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
