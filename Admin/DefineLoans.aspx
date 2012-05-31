<%@ Page AutoEventWireup="true" CodeFile="DefineLoans.aspx.cs" Inherits="DefineLoans" Language="C#" MasterPageFile="~/MasterPage.master" Title="Define Loans" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
  
<asp:content id="Content1" runat="Server" contentplaceholderid="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
     function validation()
     {
                if(! isEmpty('<%=txtName.ClientID%>',"Please Enter Loan Name"))return false;
      if(document.getElementById('<%=txtName.ClientID %>').value!="")
        {
           if(! ValidateTextFormat('<%=txtName.ClientID %>',"Please Enter Valid Loan Name")) return false;
        }
         if(! isEmpty('<%=txtMaxAmount.ClientID%>',"Please Enter Max Amount"))return false;
      if(document.getElementById('<%=txtMaxAmount.ClientID %>').value!="")
        {
           if(! ZipCode('<%=txtMaxAmount.ClientID %>',"Please Enter Valid Max Amount")) return false;
        }
        
        if(! isEmpty('<%=txtMaxNoofInstallments.ClientID%>',"Please Enter Max No Of Installments"))return false;
      if(document.getElementById('<%=txtMaxNoofInstallments.ClientID %>').value!="")
        {
           if(! ZipCode('<%=txtMaxNoofInstallments.ClientID %>',"Please Enter Valid Installments")) return false;
        }
       
        
        }
   

     
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>
        <div>
    
        <table align="center" class="tdcls" style="width: 576px">
            <tr>
                <td>
                    <asp:HiddenField ID="hdnStaffLoanId" runat="server" />
                </td>
            </tr>
            
            <tr>
                <td class="heading" colspan="2" style="text-align: center">
                    DEFINE LOANS</td>
            </tr>
            <tr>
                <td style="width: 195px"  class="subhead">
                    Loan Name<span style="font-size: 14px; color: Red">*</span></td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="txtcls"></asp:TextBox>
                   </td>
            </tr>
            <tr>
                <td style="width: 195px" class="subhead">
                    Max Amount<span style="font-size: 14px; color: Red">*</span></td>
                <td>
                <asp:TextBox ID="txtMaxAmount" runat="server" CssClass="txtcls"></asp:TextBox>
                   </td>
                    </tr>
            <tr>
                <td style="width: 195px" class="subhead">
                    Max No of Installments<span style="font-size: 14px; color: Red">*</span></td>
                <td>
                <asp:TextBox ID="txtMaxNoofInstallments" runat="server" CssClass="txtcls"></asp:TextBox>
                   </td>
                    </tr>
            <tr>
                <td  class="subhead">
                    Remarks</td>
                <td>
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtcls" TextMode="MultiLine" Width="154px"></asp:TextBox>
                    </td>
            </tr>
        </table>
        <table align="center" class="tdcls" width="576px">
            <tr>
                <td align="center" style="height: 26px">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" 
                        onclick="btnAdd_Click"/>
                    
                    
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="gdvStaffLoanMaster" runat="server" 
                        AutoGenerateColumns="False" BackColor="#CCCCCC"
                        CellSpacing="2" onrowcommand="gdvStaffLoanMaster_RowCommand" 
                        onrowdatabound="gdvStaffLoanMaster_RowDataBound" >
                        <FooterStyle BackColor="#CCCCCC" />
                        <RowStyle CssClass="gridviewitem" />
                        <SelectedRowStyle Font-Bold="True" />
                        <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                        <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                        <Columns>
                           <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblLoanId" runat="server" Text='<%#Bind("LoanId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblLoanName" runat="server" Text='<%#Bind("LoanName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" Max Amount Allowed">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaxAmount" runat="server" Text='<%#Bind("MaxAmount")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText=" Max No Installments">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaxNoofinstallments" runat="server" Text='<%#Bind("MaxNoofinstallments")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText=" Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemarks" runat="server" Text='<%#Bind("Remarks")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                         
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="editing"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
     </div>  
 
    
  
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
