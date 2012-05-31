<%@ Page AutoEventWireup="true" CodeFile="DefineSubjects.aspx.cs" Inherits="DefineSubjects"
    Language="C#" MasterPageFile="~/MasterPage.master" Title="Define Subjects"%>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
     function validation()
     {
                if(! isEmpty('<%=txtSubject.ClientID%>',"Please Enter Subject"))return false;
      if(document.getElementById('<%=txtSubject.ClientID %>').value!="")
        {
           if(! ValidateTextFormat('<%=txtSubject.ClientID %>',"Please Enter Valid Subject")) return false;
        }
        
     }
   function Confirm()
        {
            var con = confirm("Do You Want Delete This Subject Name ?");
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

  <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>
        <div>
        <table align="center" class="tdcls" width="50%">
                    </tr>
            <caption>
                <tr>
                    <td>
                        <asp:HiddenField ID="hdnSubjectID" runat="server" />
                    </td>
                </tr>
                
                <tr>
                    <td class="heading" colspan="2" style="text-align: center">
                        DEFINE SUBJECTS
                    </td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                <tr>
                    <td class="subhead">
                        Subject Name <span style="font-size: 10px; color: Red">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="txtcls"></asp:TextBox>
                    </td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add" 
                            Width="50px" />
                    </td>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:GridView ID="gdvSubjects" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="8"
                                BackColor="#CCCCCC" CellSpacing="2" onrowcommand="gdvSubjects_RowCommand" 
                                onrowdatabound="gdvSubjects_RowDataBound" 
                                onpageindexchanging="gdvSubjects_PageIndexChanging">
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle BackColor="#739bcf" CssClass="gridviewheader" Font-Bold="True" 
                                    ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubjectId" runat="server" Text='<%#Bind("SubjectId")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubjectName" runat="server" Text='<%#Bind("SubjectName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="editing" Text="Edit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="del" Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </tr>
            </caption>
        </table>
   </div>  
 
    
  
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
