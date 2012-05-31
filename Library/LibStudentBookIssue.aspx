<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="LibStudentBookIssue.aspx.cs" Inherits="LibraryModule_LibStudentBookIssue"
    Title="Library Student Book Issue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    
    function RequiredValidate()
    {
      if(! DropdownValidate('<%=ddlBatch.ClientID%>',"Please Select Batch"))return false;
     if(! DropdownValidate('<%=ddlClasses.ClientID%>',"Please Select Class"))return false;
     if(! DropdownValidate('<%=ddlSections.ClientID%>',"Please Select Section"))return false;
     if (!DropdownValidate('<%=ddlStudent.ClientID%>', "Please Select Student")) return false;
     var count = 0;
     var tableElement = document.getElementById('<%=gdvLibBook.ClientID%>');
     if (tableElement == null) {
         alert("Please Check Atleast One Book");
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



     if (!isEmpty('<%=txtIssueDate.ClientID%>', "Please Enter IssueDate")) return false;
     if (document.getElementById('<%=txtIssueDate.ClientID%>').value != "") {
         if (!isDateFormat('<%=txtIssueDate.ClientID%>', "Date Format Should be DD/MM/YYYY")) return false;
     }
     if (!isEmpty('<%=txtDueDate.ClientID%>', "Please Enter Due Date")) return false;
     if (document.getElementById('<%=txtDueDate.ClientID%>').value != "") {
         if (!isDateFormat('<%=txtDueDate.ClientID%>', "Date Format Should be DD/MM/YYYY")) return false;
     }
      
    //if(!CheckBox1('<%=this.gdvLibBook.ClientID%>',"Please check Atleast one check box" ))return false;
    
    }
    
   
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="udpLib" runat="server">
        <ContentTemplate>
            <table align="center" class="tdcls" style="width: 80%;">
                <tr>
                    <td colspan="4" style="height: 17%">
                        <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="heading" style="height: 17%">
                        STUDENT BOOKS ISSUE
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" class="subhead">
                        Batch<span style="color: #ff0000">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBatch" runat="server" Width="154px" Height="16%"  AutoPostBack="true"
                            onselectedindexchanged="ddlBatch_SelectedIndexChanged">
                            <asp:ListItem Text="select">Select</asp:ListItem>
                            <asp:ListItem Text="2006">2006-2009</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" class="subhead">
                        Branch <span style="color: #ff0000">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlClasses" runat="server" AutoPostBack="True" Width="154px"
                            Height="16%" onselectedindexchanged="ddlClasses_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%--<asp:TextBox ID="txtStudent" runat="server" MaxLength="11"></asp:TextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" class="subhead">
                        Section<span style="color: #ff0000">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSections" runat="server" AutoPostBack="True" Width="154px"
                            Height="16%" onselectedindexchanged="ddlSections_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" class="subhead">
                        Student<span style="color: #ff0000">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" Width="154px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="heading" style="height: 17%">
                         BOOKS DETAILS
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" class="subhead">
                        Accession No 
                    </td>
                    <td>
                        <asp:TextBox ID="txtAccessionNo" runat="server" MaxLength="11"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnCheck" runat="server" Text="CheckDetails" 
                            onclick="btnCheck_Click" />
                        
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:GridView ID="gdvLibBook" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                            CellSpacing="2" onrowdatabound="gdvLibBook_RowDataBound" 
                            AllowPaging="true" PageSize="10" onpageindexchanging="gdvLibBook_PageIndexChanging" 
                           >
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
                                        <asp:CheckBox ID="chkBook" runat="server"  />
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
                                        <asp:Label ID="lblName" runat="server" text='<%#Bind("FullName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Class">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClass" runat="server" Text='<%#Bind("ClassName")%>'></asp:Label>
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
                <tr>
                    <td colspan="4" class="heading" style="height: 17%">
                         ISSUE DETAILS
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" class="subhead">
                        Issue Date<span style="color: #ff0000">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtIssueDate" runat="server" MaxLength="11"></asp:TextBox>
                        <a href="javascript:NewCal('ctl00$ContentPlaceHolder1$txtIssueDate','mmddyyyy',false)">
                            <%--<img id="image1" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                width="16">--%>
                                <asp:ImageButton runat="server" id="image1" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                width="16"/></a>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="image1"
                            TargetControlID="txtIssueDate" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" class="subhead">
                        Due Date<span style="color: #ff0000">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDueDate" runat="server" MaxLength="11"></asp:TextBox>
                        <a href="javascript:NewCal('ctl00$ContentPlaceHolder1$txtDueDate','mmddyyyy',false)">
                            <%--<img id="image2" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                width="16">--%>
                                <asp:ImageButton runat="server" id="image2" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                width="16"/></a>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="image2"
                            TargetControlID="txtDueDate" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                
            </table>
            <table align="center" class="tdcls">
                <tr>
                    <td align="center">
                    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style="width: 30%">
                        <asp:Button ID="btnSave" runat="server" Text="Save" 
                             onclick="Button1_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" 
                            onclick="btnClear_Click" />&nbsp;
                    </td>
                </tr>
                
            </table>
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
