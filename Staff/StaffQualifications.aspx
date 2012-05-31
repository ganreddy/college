<%@ Page  MasterPageFile="~/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="StaffQualifications.aspx.cs" Inherits="StaffQualifications" %>
 

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function validation()
    {
                        if(! DropdownValidate('<%=ddlStaffId.ClientID%>',"Please Select Staff Id"))return false;
                        if(! DropdownValidate('<%=ddlNameOfDegree.ClientID%>',"Please Select Name Of Degree"))return false;
                        if(! DropdownValidate('<%=ddlPassingYear1.ClientID%>',"Please Select passing Year"))return false;
                        if(! DropdownValidate('<%=ddlSubject.ClientID%>',"Please Select Subject"))return false;
        if(! isEmpty('<%=txtPersent.ClientID%>',"Please Enter Present"))return false;
        if(! isEmpty('<%=txtNameOfUniversity.ClientID%>',"Please Enter Name Of University"))return false;

    }
    </script>
    <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
     <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
    <div>
        <table align="center" class="tdcls" width="70%">
            <tr>
                <td class="heading" colspan="2" style="text-align: center">
                    STAFF QUAIFICATIONS
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td class="subhead">
                    Staff ID<span style="font-size: 10px; color: Red">*</span>
                    </td>
                <td>
                    <asp:DropDownList ID="ddlStaffId" runat="server" AutoPostBack="True" 
                        Width="154px" onselectedindexchanged="ddlStaffId_SelectedIndexChanged">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>aaaa</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td class="subhead">
                    Name<span style="font-size: 10px; color: Red">*</span>
                    </td>
                <td>
                    <asp:Label ID="lblName" runat="server" Height="21px" Text="Label" Width="154px"></asp:Label></td>
            </tr>
            <tr>
                <td class="subhead">
                    Designation<span style="font-size: 10px; color: Red">*</span>
                    </td>
                <td>
                    <asp:Label ID="lblDesignation" runat="server" Height="21px" Text="Label" Width="154px"></asp:Label></td>
            </tr>
            <tr>
                <td class="heading" colspan="2">
                    DETAILS&nbsp;</td>
            </tr>
        </table>
        <table align="center" class="tdcls" width="70%" >
            <tr>
                <td class="subhead">
                    Name of Degree<span style="font-size: 10px; color: Red">*</span>
                    </td>
                <td style="width: 155px; height: 16px;">
                      <asp:DropDownList ID="ddlNameOfDegree" runat="server" CssClass="txtcls" Width="180px">
                      <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="1">Bsc</asp:ListItem>
                    <asp:ListItem Value="2">Bcom</asp:ListItem>
                    <asp:ListItem Value="3">BA</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                <td class="subhead">
                    From <span style="font-size: 10px; color: Red">*</span>
                    </td>
                <td style="height: 16px">
                <asp:DropDownList ID="ddlPassingYear1" runat="server" CssClass="txtcls" Width="154px">
                <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="1">2000</asp:ListItem>
                    <asp:ListItem Value="2">2001</asp:ListItem>
                    <asp:ListItem Value="3">2002</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="subhead">
                    Subject<span style="font-size: 10px; color: Red">*</span>
                    </td>
                <td>
                     <asp:DropDownList ID="ddlSubject" runat="server" CssClass="txtcls" Width="180px">
                     <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="1">Computers</asp:ListItem>
                    <asp:ListItem Value="2">Maths</asp:ListItem>
                     <asp:ListItem Value="3">Physics</asp:ListItem>

                    
                    </asp:DropDownList></td>
                <td class="subhead">
                    Percent <span style="font-size: 10px; color: Red">*</span>
                 </td>
                <td>
             <asp:TextBox ID="txtPersent" runat="server" CssClass="txtcls"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Name of University <span style="font-size: 10px; color: Red">*</span>
                    </td>
                <td>
                    <asp:TextBox ID="txtNameOfUniversity" runat="server" Width="178px"></asp:TextBox></td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="Message" runat="server" />
                </td>
            </tr>
        </table>
        <table align="center" class="tdcls" width="576">
            <tr>
                <td align="center">
                    <asp:Button ID="btnSave" runat="server"  Text="Save" Width="115px" 
                        onclick="btnSave_Click" />
                    
                </td>
            </tr>
        </table>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
