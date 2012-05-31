<%@ Page AutoEventWireup="true" CodeFile="DefineExamSubject.aspx.cs" Inherits="DefineExamSubject"
    Language="C#" MasterPageFile="~/MasterPage.master" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function validation()
    {
        if(! DropdownValidate('<%=ddlBatch.ClientID%>',"Please Select Batch"))return false;
        if(! DropdownValidate('<%=ddlTest.ClientID%>',"Please Select Test"))return false;
        if(! DropdownValidate('<%=ddlClass.ClientID%>',"Please Select class"))return false;
        if(! DropdownValidate('<%=ddlSection.ClientID%>',"Please Select section"))return false;
        if(! DropdownValidate('<%=ddlGroup.ClientID%>',"Please Select group"))return false;
        if(! DropdownValidate('<%=ddlSubject.ClientID%>',"Please Select subject"))return false;
       
        if(! isEmpty('<%=txtExamDate.ClientID%>',"Please Enter ExamDate"))return false;
      if(document.getElementById('<%=txtExamDate.ClientID %>').value!="")
        {
           if(! isDateFormat('<%=txtExamDate.ClientID %>',"Date Format should be dd/mm/yyyy")) return false;
        }
   
        if(! isEmpty('<%=txtMaxMarks.ClientID%>',"Please Enter maxmarks"))return false;
        if(! isEmpty('<%=txtPassMark.ClientID%>',"Please Enter passmarks"))return false;
        if(! DropdownValidate('<%=ddlStatus.ClientID%>',"Please Select status"))return false;
        }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <table align="center" class="tdcls" width="70%">
        <tr>
            <td >
                <asp:HiddenField ID="Message" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="heading" >
                DEFINE EXAM&nbsp;
            </td>
        </tr>
        <tr>
        <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="subhead">
                Batch <span style="font-size: 10px; color: Red">*</span>
            </td>
            </td>
            <td>
                <asp:DropDownList ID="ddlBatch" runat="server" CssClass="txtcls">
                <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>aaaa</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
        </tr>
        <tr>
            <td class="subhead">
                Test <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlTest" runat="server" CssClass="txtcls">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>aswa</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead" >
                Class <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlClass" runat="server" CssClass="txtcls" AutoPostBack="True">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>bbbb</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead" >
                Section/Group for +1/+2<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlSection" runat="server" CssClass="txtcls">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>Selaa</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlGroup" runat="server">
                <asp:ListItem>Select</asp:ListItem>
                 <asp:ListItem>Sefgt</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead" >
                Subject <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubject" runat="server" CssClass="txtcls">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>Selectgfg</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td  class="subhead">
                Exam Date <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtExamDate" runat="server" CssClass="txtcls"></asp:TextBox>
                
                    <img alt="Pick a date" border="0" height="16"  src="../images/cal.gif" width="16" id="imgcal" >
                <asp:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtExamDate" PopupButtonID="imgcal">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="subhead" >
                Max Marks<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td  >
                <asp:TextBox ID="txtMaxMarks" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  class="subhead">
                Pass Mark <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtPassMark" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
        </tr>
        <tr visible="false">
            <td class="subhead" >
                Exam Satus <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="txtcls">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="YET">Yet To Be Held</asp:ListItem>
                    <asp:ListItem Value="CMP">Completed</asp:ListItem>
                    <asp:ListItem Value="CRT">Corrected</asp:ListItem>
                    <asp:ListItem Value="CLL">Cancelled</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>&nbsp;
    <table align="center" class="tdcls" width="576px">
        <tr>
            <td align="center">
                <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" 
                      />&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Modify" Width="50px" />&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="Delete" Width="50px" />
                
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="dgrid" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="true">
                    <Columns>
                        <asp:BoundField DataField="ExamName" HeaderText="Name" />
                        <asp:BoundField DataField="Subject" HeaderText="Subject" />
                        <asp:BoundField DataField="Class" HeaderText="Class" />
                        <asp:BoundField DataField="Section" HeaderText="Section" />
                        <asp:BoundField DataField="BatchId" HeaderText="Batch" />
                        <asp:BoundField DataField="examDate" HeaderText="Exam Date" />
                        <asp:BoundField DataField="MaxMarks" HeaderText="Max Marks" />
                        <asp:BoundField DataField="PasMark" HeaderText="Pass Mark" />
                        <asp:BoundField DataField="status" HeaderText="Exam Status" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
