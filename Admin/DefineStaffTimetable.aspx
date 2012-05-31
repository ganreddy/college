<%@ Page AutoEventWireup="true" CodeFile="DefineStaffTimetable.aspx.cs" Inherits="DefineStaffTimetable" Language="C#" MasterPageFile="~/MasterPage.master" %>



<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script src="App_Themes/all/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function validation()
    {
                if(! DropdownValidate('<%=ddlStaffId.ClientID%>',"Please Select StaffId"))return false;
                if(! DropdownValidate('<%=ddlDayOfWeak.ClientID%>',"Please Select Day Of Weak"))return false;
                if(! DropdownValidate('<%=ddlPeriods.ClientID%>',"Please Select Periods"))return false;
                if(! DropdownValidate('<%=ddlClass.ClientID%>',"Please Select Class"))return false;
                if(! DropdownValidate('<%=ddlSection.ClientID%>',"Please Select Section"))return false;
                if(! DropdownValidate('<%=ddlSubject.ClientID%>',"Please Select Subject"))return false;

    }
    </script>
    <div>
        <table align="center" class="tdcls" width="60%">
            <tr>
                <td  >
                    <asp:HiddenField ID="Message" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="heading" colspan="2" style="text-align: center">
                    DEFINE STAFF TIME TABLE</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="subhead">
                    Staff ID<span style="font-size:17px;color:Red">*</span></td>
                <td class="subhead">
                    <asp:DropDownList ID="ddlStaffId" runat="server" CssClass="txtcls" Width="93px" >
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Selectfd</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CheckBox ID="ChkThiStaffOnly" runat="server" AutoPostBack="True"  Text="Display Periods of Selected Staff Only" />
                    </td>
            </tr>
            <tr>
                <td class="subhead">
                    Day of Week<span style="font-size:17px;color:Red">*</span></td>
                <td style="height: 27px">
                    <asp:DropDownList ID="ddlDayOfWeak" runat="server" CssClass="txtcls" Width="93px">
                    <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="Sunday">Sunday</asp:ListItem>
                        <asp:ListItem Value="Monday">Monday</asp:ListItem>
                        <asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
                        <asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
                        <asp:ListItem Value="Thursday">Thursday</asp:ListItem>
                        <asp:ListItem Value="Friday">Friday</asp:ListItem>
                        <asp:ListItem Value="Saturday">Saturday</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td class="subhead">
                    Period<span style="font-size:17px;color:Red">*</span></td>
                <td>
                    <asp:DropDownList ID="ddlPeriods" runat="server" CssClass="txtcls" Width="93px">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Selectfd</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td class="subhead">
                    Class<span style="font-size:17px;color:Red">*</span></td>
                <td>
                    <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" 
                        CssClass="txtcls" Width="93px">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Selectfd</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td class="subhead">
                    Section<span style="font-size:17px;color:Red">*</span></td>
                <td style="height: 25px">
                    <asp:DropDownList ID="ddlSection" runat="server" CssClass="txtcls" Width="93px">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Selectfd</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td class="subhead">
                    Subject<span style="font-size:17px;color:Red">*</span></td>
                <td>
                    <asp:DropDownList ID="ddlSubject" runat="server" CssClass="txtcls" Width="93px">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Selectfd</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
            <td>&nbsp;</td>
            </tr>
        </table>
        <table align="center" class="tdcls" width="576px">
            <tr>
                <td align="center">
                    <asp:Button ID="btnAdd" runat="server"  Text="Add" Width="70px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server"  Text="Delete" Width="70px" />
                    &nbsp;&nbsp;<asp:Button ID="Modify" runat="server" Text="MODIFY"  Width="70px"/>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="dgrid" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="true">
                        <Columns>
                            <asp:BoundField DataField="NAME" HeaderText="Staff Name" />
                            <asp:BoundField DataField="DayofWeek" HeaderText="Day" />
                            <asp:BoundField DataField="periodName" HeaderText="Period" />
                            <asp:BoundField DataField="subjectid" HeaderText="Subject" />
                            <asp:BoundField DataField="classid" HeaderText="Class" />
                            <asp:BoundField DataField="sectionId" HeaderText="Section" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
