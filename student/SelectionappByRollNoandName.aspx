<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SelectionappByRollNoandName.aspx.cs" Inherits="student_SelectionappByRollNoandName" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function CheckRadio(rowindex) {
        var count = 0;
        var tableElement = document.getElementById('<%=gdvStud.ClientID%>');
        for (var i = 1; i < tableElement.rows.length; i++) {
            var rowElem = tableElement.rows[i];
            var cell = rowElem.cells[0];
            //alert(cell);
            if (cell.childNodes[0].type == "radio") {
                //assign the status of the Select All checkbox to the cell checkbox within the grid
                cell.childNodes[0].checked = false;
            }

        }
        tableElement.rows[rowindex + 1].cells[0].childNodes[0].checked = true;
    }
    function window.onload() {
        ShowHide();
    }
    function ShowHide() {
        if (document.getElementById('<%=rdbName.ClientID%>').checked) {
            document.getElementById('<%=pnlAdmSearch.ClientID%>').style.display = "none";
            document.getElementById('<%=pnlSearchName.ClientID%>').style.display = "inline";
        }
        if (document.getElementById('<%=rdbAdminNo.ClientID%>').checked) {
            document.getElementById('<%=pnlAdmSearch.ClientID%>').style.display = "inline";
            document.getElementById('<%=pnlSearchName.ClientID%>').style.display = "none";
        }
        return;
    }
    
    </script>
 <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%--<asp:UpdatePanel ID="updStudAdmis" runat="server">
    <ContentTemplate>--%>
    <table align="center" width="90%" border="0">
                <tr>
                    <td>
                        <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
                    </td>
                </tr>
                <tr>
                    <td class="heading" colspan="2" style="text-align: center" width="100%">
                        STUDENT INFORMATION
                    </td>
                </tr>
                <tr>
                    <td class="subhead">
                        Search By:
                    </td>
                    <td class="subhead">
                        <asp:RadioButton ID="rdbAdminNo" runat="server" class="subhead" ForeColor="Black"
                            GroupName="rbOnly" Text="RollNo" />&nbsp;
                        <asp:RadioButton ID="rdbName" runat="server" class="subhead" ForeColor="Black" GroupName="rbOnly"
                            Text="Student Name" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlAdmSearch" runat="server">
                            <table width="100%" border="0">
                                <tr>
                                    <td class="subhead" >
                                        Roll No:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAdmissionNo" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" 
                                             />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlSearchName" runat="server">
                            <table width="100%">
                                <tr>
                                    <td class="subhead" >
                                        Name :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnNmeSearch" runat="server" Text="Search" 
                                            onclick="btnNmeSearch_Click" />
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td class="subhead" style="height: 26px" >
                                        Class <span style="font-size: 11px; color: Red">*</span>
                                    </td>
                                    <td style="height: 26px">
                                        <asp:DropDownList ID="ddlClasses" runat="server" AutoPostBack="True" Width="155px"
                                            Height="16%" onselectedindexchanged="ddlClasses_SelectedIndexChanged" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subhead" >
                                        Section <span style="font-size: 11px; color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSections" runat="server" AutoPostBack="True" Width="155px"
                                            Height="16%" onselectedindexchanged="ddlSections_SelectedIndexChanged1" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>--%>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr id="trSearch" runat="server">
                    <td colspan="2" align="center">
                        <asp:GridView ID="gdvStud" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                            CellSpacing="2" onrowediting="gdvStud_RowEditing"    
                             >
                            <FooterStyle BackColor="#CCCCCC" />
                            <RowStyle CssClass="gridviewitem" />
                            <SelectedRowStyle Font-Bold="True" />
                            <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                            <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField Visible="true" HeaderText="Roll No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStudentID" runat="server" Text='<%#Bind("RollNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="First Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFullName" runat="server" Text='<%#Bind("FirstName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAdmisNo" runat="server" Text='<%#Bind("LastName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DOB">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDob" runat="server" Text='<%#Bind("DOB")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Father's Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFather" runat="server" Text='<%#Bind("FatherName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mother's Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMother" runat="server" Text='<%#Bind("MotherName")%>' nowrap></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Class">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClass" runat="server" Text='<%#Bind("ClassName")%>' nowrap></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Section">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSection" runat="server" Text='<%#Bind("SectionName")%>' nowrap></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
               <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    
</asp:Content>
