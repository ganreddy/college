<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefineScholastic.aspx.cs" Inherits="CCE_DefineScholastic" Title="Define Scholastic Areas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        function validation() {
            if(!DropdownValidate('<%=ddlYear.ClientID%>',"Please Select Year"))return false;
            if(!DropdownValidate('<%=ddlSubject.ClientID%>',"Please Select Subject"))return false;
            
            
            var atLeast = 1;
            var CHK = document.getElementById("<%=chklExam.ClientID%>");
            var checkbox = CHK.getElementsByTagName("input");
            var counter = 0;
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].checked) {
                    counter++;
                }
            }
            if (atLeast > counter) {
                alert("Please select Atleast One ExamType");
                return false;
            }
            
            var atLeast = 1;
            var CHK = document.getElementById("<%=chklClass.ClientID%>");
            var checkbox = CHK.getElementsByTagName("input");
            var counter = 0;
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].checked) {
                    counter++;
                }
            }
            if (atLeast > counter) {
                alert("Please Select Atleast One Class");
                return false;
            }
            
            if (!isEmpty('<%=txtScholasticArea.ClientID%>', "Please Enter Scholastic Area")) return false;
            if(!isNumeric('<%=txtMaxMarks.ClientID%>',"Please Enter Maximum Marks"))return false;
        }
        
        function Confirm() {
            var con = confirm("Do You Want Delete This Scholastic Area ?");
            if (con == true) {
                return true;
            }
            else {
                return false
            }
        }
    </script>

    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>
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
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Year<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlYear" runat="server" Width="154px">
                                                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                    <td class="subhead">
                            Subject<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubject" runat="server" Width="154px">
                                                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Exam Type<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:CheckBoxList ID="chklExam" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"></asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Class<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:CheckBoxList ID="chklClass" runat="server"></asp:CheckBoxList>
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
                                onclick="btnAdd_Click"  />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                        </td>
                        </tr>
                       
                    
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
