<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefineExam.aspx.cs" Inherits="CCE_DefineExam" Title="Define Exam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    function validate()
    {
    if(!DropdownValidate('<%=ddlTerm.ClientID%>',"Please Select Term"))return false;
     if(! isEmpty('<%=txtExam.ClientID%>',"Please Enter Exam"))return false;
     if (!isEmpty('<%=txtWeightage.ClientID%>', "Please Enter Weightage")) return false;
     if (document.getElementById('<%=txtWeightage.ClientID %>').value != "") {
         if (!isNumeric('<%=txtWeightage.ClientID %>', "Please Enter Numeric Value For Weightage")) return false;
     } 
    }
    function Confirm()
        {
           var con=confirm("Do You Want Delete This Exam?");
           if (con==true)
           {
              return true;
           }
           else
           {
               return false;
           }
        }
    </script>


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
 <asp:UpdatePanel ID="upd" runat="server">
 <ContentTemplate>
     <table align="center" class="tdcls" width="50%">
         <tr>
             <td>
                 <asp:HiddenField ID="hdnCasteID" runat="server" />
             </td>
         </tr>
         <tr>
             <td colspan="2" class="heading" style="text-align: center">
                 DEFINE EXAM
             </td>
         </tr>
         <tr>
             <td colspan="2">
                 &nbsp;
             </td>
         </tr>
         <tr>
             <td class="subhead" width="160px">
                 Term <span style="font-size: 10px; color: Red">*</span>
             </td>
             <td >
                 <asp:DropDownList ID="ddlTerm" runat="server" Width="154">
                  <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                  <asp:ListItem Text="Term 1" Value="1"></asp:ListItem>
                  <asp:ListItem Text="Term 2" Value="2"></asp:ListItem>
                 </asp:DropDownList>
             </td>
         </tr>
         <tr>
             <td class="subhead" width="160px">
                 Exam <span style="font-size: 10px; color: Red">*</span>
             </td>
             <td >
                 <asp:TextBox ID="txtExam" runat="server"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="subhead" width="160px">
                 Weightage <span style="font-size: 10px; color: Red">*</span>
             </td>
             <td >
                 <asp:TextBox ID="txtWeightage" runat="server"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td colspan="2" align="center">
                 <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
             </td>
         </tr>
         <tr>
             <td align="center" colspan="2">
                 <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" OnClick="btnAdd_Click" />
             </td>
         </tr>
         <tr>
             <td align="center" colspan="2">
                 <asp:GridView ID="gdvExam" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                     CellSpacing="2" OnRowCommand="gdvExam_RowCommand" OnRowDataBound="gdvExam_RowDataBound">
                     <FooterStyle BackColor="#CCCCCC" />
                     <RowStyle CssClass="gridviewitem" />
                     <SelectedRowStyle Font-Bold="True" />
                     <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                     <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                     <Columns>
                         <asp:TemplateField Visible="false">
                             <ItemTemplate>
                                 <asp:Label ID="lblExamID" runat="server" Text='<%#Bind("ExamID")%>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Term">
                             <ItemTemplate>
                                 <asp:Label ID="lblTermID" runat="server" Text='<%#Bind("TermID")%>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Exam">
                             <ItemTemplate>
                                 <asp:Label ID="lblExam" runat="server" Text='<%#Bind("ExamName")%>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Weightage">
                             <ItemTemplate>
                                 <asp:Label ID="lblWeightage" runat="server" Text='<%#Bind("Weightage")%>'></asp:Label>
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
                     </Columns>
                 </asp:GridView>
             </td>
         </tr>
     </table>
   </ContentTemplate>
   </asp:UpdatePanel>
</asp:Content>
