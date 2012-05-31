<%@ Page AutoEventWireup="true" CodeFile="DefineFee.aspx.cs" Inherits="DefineFee"
    Language="C#" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script src="App_Themes/all/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function validation()
    {
          if(! DropdownValidate('<%=ddlClass.ClientID%>',"Please Select Class"))return false;
          if(! DropdownValidate('<%=ddlCaste.ClientID%>',"Please Select Caste"))return false;
           if(! isEmpty('<%=txtAnnualFee.ClientID%>',"Please Enter AnnualFee"))return false;

    }
    </script>
    <table align="center" class="tdcls" width="60%">
        <tr>
            <td>
                <asp:HiddenField ID="Message" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="heading" style="text-align: center; height: 17px;">
                DEFINE &nbsp;FEES
            </td>
        </tr>
        <tr>
        <td>
            &nbsp;
        </td>
        </tr>
        <tr>
            <td class="subhead">
                Class <span style ="font-size:10px;color:Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlClass" runat="server" CssClass="txtcls">
                <asp:ListItem>Select</asp:ListItem>
          
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Caste <span style ="font-size:10px;color:Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlCaste" runat="server" CssClass="txtcls">
                <asp:ListItem>Select</asp:ListItem>
                
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Annual Fee <span style ="font-size:10px;color:Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtAnnualFee" runat="server" Width="120px" CssClass="txtcls">
                </asp:TextBox>
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
                <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" />&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Modify" Width="50px"  />&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="Delete" Width="50px"  />&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="dgrid" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="true" >
                    <Columns>
                        <asp:BoundField DataField="Class" HeaderText="Class" />
                        <asp:BoundField DataField="Caste" HeaderText="Caste" />
                        <asp:BoundField DataField="AnnualFee" HeaderText="Fee" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
