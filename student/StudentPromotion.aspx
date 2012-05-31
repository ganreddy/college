<%@ Page Title="Student Promotion" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentPromotion.aspx.cs" Inherits="student_StudentPromotion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
            <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function CheckAllClick(chkAllID) {
            var count = 0;
            var tableElement = document.getElementById('<%=gdvStudent.ClientID%>');
            if (chkAllID.checked) {
                for (var i = 1; i < tableElement.rows.length; i++) {
                    var rowElem = tableElement.rows[i];
                    var cell = rowElem.cells[0];
                    //alert(cell);
                    if (cell.childNodes[0].type == "checkbox") {
                        //assign the status of the Select All checkbox to the cell checkbox within the grid
                        cell.childNodes[0].checked = true;
                    }

                }
            }
            else {
                for (var i = 1; i < tableElement.rows.length; i++) {
                    var rowElem = tableElement.rows[i];
                    var cell = rowElem.cells[0];
                    if (cell.childNodes[0].type == "checkbox") {
                        cell.childNodes[0].checked = false;
                    }

                }
            }
        }
        function validation() {
            if (!DropdownValidate('<%=ddlBatch.ClientID%>', "Please Select Batch")) return false;
            if (!DropdownValidate('<%=ddlClass.ClientID%>', "Please Select Class")) return false;
            if (!DropdownValidate('<%=ddlSection.ClientID%>', "Please Select Section")) return false;
            
        }
    </script>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
       <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <table align="center" class="tdcls" width="50%">
                <tr>
                    <td>
                        <asp:HiddenField ID="hdnStudentPromotion" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="heading" style="text-align: center">
                        STUDENT PROMOTION
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="subhead" align="center">
                        <asp:Panel ID="pnlSearchName" runat="server" Width="100%">
                            <table width="100%">
                                <tr>
                                    <td class="subhead" align="left" style="width: 188px">
                                        Batch<span style="font-size: 11px; color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="true" Width="155px"
                                         Height="16%" onselectedindexchanged="ddlBatch_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subhead" align="left" style="width: 188px">
                                        Branch<span style="font-size: 11px; color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" Width="155px"
                                        Height="16%" onselectedindexchanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subhead" align="left" style="width: 188px">
                                        Section<span style="font-size: 11px; color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="true" Width="155px"
                                        Height="16%" onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        
                    </td>
                    
                </tr>
                <tr id="trsearch" runat="server">
                    <td align="center">
                        <asp:GridView ID="gdvStudent" runat="server" AutoGenerateColumns="false" BackColor="#CCCCCC"
                        CellSpacing="2" onrowdatabound="gdvStudent_RowDataBound">
                           <FooterStyle BackColor="#CCCCCC" />
                                 <RowStyle CssClass="gridviewitem" />
                                 <SelectedRowStyle Font-Bold="True" />
                                 <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                 <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStudID" runat="server" Text='<%#Bind("StudID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStudName" runat="server" Text='<%#Bind("FullName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Admission No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAdmNo" runat="server" Text='<%#Bind("AdmissionNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DOB">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDob" runat="server" Text='<%#Bind("DOB")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Father's Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFatherName" runat="server" Text='<%#Bind("FatherName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Class">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClass" runat="server" Text='<%#Bind("ClassName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Section">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlSections" runat="server"></asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" width="100%">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="text-align: center" width="100%">
                        <asp:Button ID="btnPromote" runat="server" Text="Promote" 
                            onclick="btnPromote_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
       </asp:UpdatePanel>
</asp:Content>

