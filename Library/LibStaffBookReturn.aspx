<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LibStaffBookReturn.aspx.cs" Inherits="LibraryModule_LibStaffBookReturn" Title="Library StaffBook Return" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../scripts/Validations.js" type="text/javascript"></script>
 <script type="text/jscript" language="javascript">
    function RequiredValidate()
    {
        if (!DropdownValidate('<%=ddlStaff.ClientID%>', "Please Select Staff")) return false;

        var count = 0;
        var tableElement = document.getElementById('<%=gdvLibBook.ClientID%>');
        if (tableElement == null) {
           // alert("Please check Atleast one book");
            return false;
        }
        else {
            for (var i = 1; i < tableElement.rows.length; i++) {
                var rowElem = tableElement.rows[i];
                var cell = rowElem.cells[0];
                //alert(cell);
                if (cell.childNodes[0].type == "checkbox") {
                    if (cell.childNodes[0].checked == true) {
                        count = 1;
                        break;
                    }
                }

            }
            if (count == 0) {
                alert("Please Check Atleast One Check Box");
                return false;
            }
        }

        if (!isEmpty('<%=txtDateOfReturn.ClientID%>', "Please Enter Date Of Return")) return false;
        if (document.getElementById('<%=txtDateOfReturn.ClientID%>').value != "") {
            if (!isDateFormat('<%=txtDateOfReturn.ClientID%>', "Date Format should be DD/MM/YYYY")) return false;
        }
      if(! DropdownValidate('<%=ddlFine.ClientID%>',"Please Select Fine"))return false;
      if (document.getElementById('<%=ddlFine.ClientID%>').selectedIndex == 2 || document.getElementById('<%=ddlFine.ClientID%>').selectedIndex == 3) {
         if (!isDecimal('<%=txtAmount.ClientID%>', "Please Enter FineAmount")) return false;
         if (!isEmpty('<%=txtDateOfPayment.ClientID%>', "Please Enter Date Of Payment")) return false;
         if (document.getElementById('<%=txtDateOfPayment.ClientID%>').value != "") {
             if (!isDateFormat('<%=txtDateOfPayment.ClientID%>', "Date Format should be DD/MM/YYYY")) return false;
         }
      if(! isEmpty('<%=txtReceiptno.ClientID%>',"Please Enter RecieptNo" ))return false;
     }
     
     //if(! CheckBox1('<%=this.gdvLibBook.ClientID%>',"Please select Atleast one CheckBox"))return false;
    }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="udpLib" runat="server">
        <ContentTemplate>
            <table align="center" class="tdcls" style="width: 70%; height: 147%">
                <tr>
                    <td colspan="4" style="height: 17%">
                        <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="heading" style="height: 17%">
                        STAFF BOOKS RETURN / FINE
                    </td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                <tr>
                    <td style="width: 30%" class="subhead">
                        Staff<span style="color: #ff0000">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStaff" runat="server" AutoPostBack="True" 
                            Width="154px" onselectedindexchanged="ddlStaff_SelectedIndexChanged">
                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Label ID="lblmsg" runat="server" Text="No Books Issued To This Staff"
                            Visible="false"></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <td colspan="4" align="center">
                        <asp:GridView ID="gdvLibBook" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                            CellSpacing="2" onrowdatabound="gdvLibBook_RowDataBound">
                            <FooterStyle BackColor="#CCCCCC" />
                            <RowStyle CssClass="gridviewitem" />
                            <SelectedRowStyle Font-Bold="True" />
                            <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                            <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBookID" runat="server" Text='<%#Bind("BookID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkBook" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Accession No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAcessionNo" runat="server" Text='<%#Bind("AccessionNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitle" runat="server" Text='<%#Bind("Title")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Issued To">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIssuedTo" runat="server" Text='<%#Bind("IssueType")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecieverID" runat="server" Text='<%#Bind("RecieverID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Class">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClass" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBookStatus" runat="server" Text='<%#Bind("ReturnStatus")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr id="trReturnDate" runat="server" >
                    <td align="left" style="width: 30%" class="subhead">
                        Date Of Return<span style="color: #ff0000">*</span>
                    </td>
                    <td >
                        <asp:TextBox ID="txtDateOfReturn" runat="server" MaxLength="50">
            
                        </asp:TextBox>
                        <%--<img src="../images/cal.gif" id="image2" style="width: 16px; height: 16px" />--%>
                        <asp:ImageButton runat="server" id="image2" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                width="16"/>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="image2"
                            TargetControlID="txtDateOfReturn" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr id="trFine" runat="server" class="subhead">
                    <td style="width: 30%">
                        Fine<span style="color: #ff0000">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFine" runat="server" AutoPostBack="True" 
                            Width="154px" onselectedindexchanged="ddlFine_SelectedIndexChanged" >
                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                            <asp:ListItem Value="1">No Fine</asp:ListItem>
                            <asp:ListItem Value="2">Pay Fine Now</asp:ListItem>
                            <asp:ListItem Value="3">Pay Fine Later</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlFine" runat="server" Visible="false">                            
            <table align="center" class="tdcls" runat="server" id="tblFines" visible="true" width="70%">
             
                <tr>
                    <td align="left" style="width: 30%" class="subhead">
                        Fine Amount<span style="color: #ff0000">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAmount" runat="server" MaxLength="50">
            
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 30%" class="subhead">
                        Date Of Payment<span style="color: #ff0000">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDateOfPayment" runat="server" MaxLength="50">
            
                        </asp:TextBox>
                        <%--<img src="../images/cal.gif" id="image1" style="width: 16px; height: 16px" />--%>
                        <asp:ImageButton runat="server" id="image1" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                width="16"/>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="image1"
                            TargetControlID="txtDateOfPayment" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width:30%" class="subhead">
                        Fine Receipt No<span style="color: #ff0000">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtReceiptno" runat="server" MaxLength="50">
                        </asp:TextBox>
                    </td>
                </tr>
                
            </table>
             </asp:Panel> 
            <table align="center" class="tdcls">
            <tr><td align="center"><asp:Label ID="lblMessage" runat="server" Visible="false" ></asp:Label></td></tr>
                <tr>
                    <td colspan="4" align="center" style="width: 20%">
                        <asp:Button ID="btnSave" runat="server" Text="Save" 
                             onclick="btnSave_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" onclick="btnClear_Click" 
                            style="height: 26px" />&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

