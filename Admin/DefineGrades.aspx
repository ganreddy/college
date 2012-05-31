<%@ Page AutoEventWireup="true" CodeFile="DefineGrades.aspx.cs" Inherits="DefineGrades"
    Language="C#" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script src="App_Themes/all/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function validation()
    {
            if(! isEmpty('<%=txtGrade.ClientID%>',"Please Enter GradeName"))return false;
            if(! isEmpty('<%=txtFromPercent.ClientID%>',"Please Enter FromPercent"))return false;
            if(! isEmpty('<%=txtToPercent.ClientID%>',"Please Enter ToPercent"))return false;


    }
    </script>
    <table align="center" class="tdcls" width="60%">
        <tr>
            <td>
                <asp:HiddenField ID="Message" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="heading" style="text-align: center">
                DEFINE GRADES
            </td>
        </tr>
        <tr>
        <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="subhead">
                Grade Name  <span style ="font-size:10px;color:Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtGrade" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                From Percent <span style ="font-size:10px;color:Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtFromPercent" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                To Percent <span style ="font-size:10px;color:Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtToPercent" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Remarks 
            </td>
            <td>
                <asp:TextBox ID="txtRemarks" runat="server" Width="120px" TextMode="multiline" CssClass="txtcls">
                </asp:TextBox>
            </td>
        </tr>
    </table>&nbsp;
    <table align="center" class="tdcls" width="576px">
        <tr>
            <td align="center">
                <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" 
                     />&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Modify" Width="50px"  />&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="Delete" Width="50px"  />&nbsp;&nbsp;
                
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="dgrid" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="true">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="Name" />
                        <asp:BoundField DataField="percentFrom" HeaderText="From" />
                        <asp:BoundField DataField="percentTo" HeaderText="To" />
                        <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
