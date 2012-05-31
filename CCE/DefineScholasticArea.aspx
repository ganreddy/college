<%@ Page Title="DEFINE SCHOLASTIC AREAS" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DefineScholasticArea.aspx.cs" Inherits="CCE_DefineScholasticArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function validation() {
            if (!DropdownValidate('<%=ddlYear.ClientID%>', "Please Select Year")) return false;
            if (!DropdownValidate('<%=ddlSubject.ClientID%>', "Please Select Subject")) return false;
            if (!DropdownValidate('<%=ddlExamType.ClientID%>', "Please Select Exam Type")) return false;
            if (!DropdownValidate('<%=ddlClass.ClientID%>', "Please Select Class")) return false;
            if (!isEmpty('<%=txtScholasticArea.ClientID%>', "Please Enter Scholastic Area")) return false;
            if (!isEmpty('<%=txtMaxMarks.ClientID%>', "Please Enter Maximum Marks")) return false;
            if(!isNumeric('<%=txtMaxMarks.ClientID%>', "Please Enter Valid Maximum Marks")) return false;
        }
        function Confirm() {
            var con = confirm("Do You Want Delete This Scholastic Area ?");
            if (con == true) {
                return true;
            }
            else {
                return false;
            }
        }
        function Clear() {
            document.getElementById('<%=ddlYear.ClientID%>').value = 0;
            document.getElementById('<%=ddlSubject.ClientID%>').value = 0;
            document.getElementById('<%=ddlExamType.ClientID%>').value = 0;
            document.getElementById('<%=ddlClass.ClientID%>').value = 0;
            document.getElementById('<%=txtScholasticArea.ClientID%>').value = "";
            document.getElementById('<%=txtMaxMarks.ClientID%>').value = "";
            document.getElementById('<%=btnAdd.ClientID%>').value = "Add";
//            document.getElementById('<%=gdvArea.ClientID%>').display = "none";
//            return false;
                   }
                   
    </script>

    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>
            <div>
                <div>
                    <table align="center" class="tdcls" width="60%">
                        <tr>
                            <td colspan="2" class="heading">
                                DEFINE SCHOLASTIC AREAS
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:HiddenField ID="hdnSubAccountHeadID" runat="server" />
                                <asp:HiddenField ID="hdnYear" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="subhead">
                                Year<span style="font-size: 10px; color: Red">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlYear" runat="server" Width="154px" 
                                    onselectedindexchanged="ddlYear_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="subhead">
                                Subject<span style="font-size: 10px; color: Red">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSubject" runat="server" Width="154px" AutoPostBack="true"
                                    onselectedindexchanged="ddlSubject_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="subhead">
                                Exam Type<span style="font-size: 10px; color: Red">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlExamType" runat="server" Width="154px" AutoPostBack="true"
                                    onselectedindexchanged="ddlExamType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="subhead">
                                Class<span style="font-size: 10px; color: Red">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlClass" runat="server" Width="154px" AutoPostBack="true"
                                    onselectedindexchanged="ddlClass_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="subhead">
                                Scholastic Area <span style="font-size: 10px; color: Red">*</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtScholasticArea" runat="server" Width="154px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="subhead">
                                Maximum Marks <span style="font-size: 10px; color: Red">*</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMaxMarks" runat="server" Width="154px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="height: 15px;" colspan="2">
                                <br />
                                <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" 
                                    onclick="btnAdd_Click" />
                                    <asp:Button ID="btnClear" runat="server" Text="Clear" Width="50px" onclick="btnClear_Click" 
                                    />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:GridView ID="gdvArea" runat="server" AutoGenerateColumns="false" BackColor="#CCCCCC"
                                CellSpacing="2" AllowPaging="true" PageSize="10" 
                                    onpageindexchanging="gdvArea_PageIndexChanging" 
                                    onrowcommand="gdvArea_RowCommand" onrowdatabound="gdvArea_RowDataBound">
                                 <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblScholasticID" runat="server" Text='<%#Bind("ScholasticID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ScholasticArea">
                                        <ItemTemplate>
                                            <asp:Label ID="lblScholasticArea" runat="server" Text='<%#Bind("ScholasticArea")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false"> 
                                        <ItemTemplate>
                                            <asp:Label ID="lblExamID" runat="server" Text='<%#Bind("ExamID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ExamName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExamName" runat="server" Text='<%#Bind("ExamName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubjectID" runat="server" Text='<%#Bind("SubjectID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SubjectName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubjectName" runat="server" Text='<%#Bind("SubjectName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClassID" runat="server" Text='<%#Bind("ClassID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ClassName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClassName" runat="server" Text='<%#Bind("ClassName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MaxMarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarks" runat="server" Text='<%#Bind("MaxMarks")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="editing"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="del"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblYear" runat="server" Text='<%#Bind("AcadYear")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
