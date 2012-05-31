<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LibEditBook.aspx.cs" Inherits="LibraryModule_LibEditBook" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/jscript" language="javascript">
    function RequiredValidate()
    {
    if(!isEmpty('<%=txtBookNo.ClientID%>',"please enter the Book Number" ))return false;
    if(!isEmpty('<%=txtAccessionNumber.ClientID%>',"please enter the AccessionNumber " ))return false;
    if(! DropdownValidate('<%=ddlBookCategory.ClientID%>',"pls select the Category"))return false;
     if(!isEmpty('<%=txtCost.ClientID%>',"please enter the Cost " ))return false;
     if(! DropdownValidate('<%=ddlStatus.ClientID%>',"please select BookStatus"))return false;
    }
    
    </script>

         <table align="center" class="tdcls" style="width: 90%; height: 147%">
             <tr>
                 <td  colspan="5" style="height: 17px">
                     <asp:HiddenField ID="Message" runat="server" />
                 </td>
             </tr>
            <tr>
                <td colspan="5" class="heading" style="height: 17%; text-align:center;">
                    EDIT STUDENT DETAILS</td>
            </tr>
             <tr>
                 <td style="width: 20%">
                     Book No<span style="color: #ff0000">*</span></td>
                 <td style="width: 30%">
                     <asp:TextBox ID="txtBookNo" runat="server" MaxLength="15"></asp:TextBox></td>
                 <td><asp:Button ID="btnCheck" runat="server" Text="CheckDetails"  CausesValidation="False"   /></td>
                 <td style="width: 20%">
                 </td>
                 <td style="width: 20%">
                 </td>
             </tr>
            <tr>
                <td style="width: 20%">
                    Name</td>
                <td style="width: 30%">
                    <asp:Label ID="lblName"  runat="server"></asp:Label></td>
                <td style="width: 20%">
                    Author &nbsp;Name</td>
                
                <td style="width: 20%">
                    <asp:Label ID="lblFateerName" runat="server"></asp:Label> </td>
            </tr>
             <tr>
                 <td style="width: 20%">
                     BookCategory</td>
                 <td style="width: 30%">
                     <asp:Label ID="lblAddress" runat="server"  ></asp:Label></td>
                 <td style="width: 20%">
                     Description</td>
                 
                 <td style="width: 20%">
                 <asp:Label ID="lblPhoneNo" runat="server"></asp:Label>
                 
                 </td>
             </tr>
                 <tr>
                     <td style="width: 20%">
                         Accession No<span style="color: #ff0000">*</span></td>
                     <td style="width: 30%">
                         <asp:TextBox ID="txtAccessionNumber" runat="server" MaxLength="15"></asp:TextBox></td>
                     <td style="width: 20%"><asp:Button ID="Button3" runat="server" Text="Search"  CausesValidation="False"    /></td>
                     <td style="width: 20%">
                     </td>
                     <td style="width: 20%">
                     </td>
                 </tr>
                 <tr>
                     <td colspan="5" style="width: 20%" align="center">
                         <asp:GridView ID="dgrid" runat="server" AutoGenerateSelectButton="True" DataKeyNames="BookNo"  >
                             
                         </asp:GridView>
                         <asp:HiddenField runat="server" ID="hdnSelectedStudent" />
                     </td>
                 </tr>
           
           
           
              <tr>
                  
                 <td style="width: 20%">
                     Classfication 
                     Number</td>
                 <td style="width: 30%">
                     <asp:TextBox ID="txtClassNo" runat="server"></asp:TextBox></td>
                  <td style="width: 20%">
                      Delete Book
                       <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/cal.gif"  />
                      </td>
                  <td style="width: 20%">
                  </td>
                  
             </tr>
            <tr>
                <td style="width: 20%">
                    Title</td>
                <td style="width: 30%">
                    <asp:TextBox ID="txtTitle" MaxLength="30" runat="server"></asp:TextBox></td>
                <td style="width: 20%">
                    Category<span style="color: #ff0000">*</span></td>
               
                <td style="width: 30%">
                    <asp:DropDownList ID="ddlBookCategory" runat="server" Width="156px">
                     <asp:ListItem Value="select"  >select</asp:ListItem>
                    <asp:ListItem Value="NA"  >NA</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
             <tr>
                 <td style="width: 20%">
                     Cost<span style="color: #ff0000">*</span></td>
                 <td style="width: 30%">
                     <asp:TextBox ID="txtCost" runat="server" MaxLength="9"></asp:TextBox></td>
                 <td style="width: 20%">
                     Physical Description</td>
                 
                 <td style="width: 20%">
                     <asp:TextBox ID="txtPhysicalDescription" runat="server" MaxLength="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td style="width: 20%">
                     Book Status<span style="color: #ff0000">*</span></td>
                 <td style="width: 30%">
                 <asp:DropDownList runat="server" ID="ddlStatus" Width="154px" >
                     <asp:ListItem Value="select">Select</asp:ListItem>
                 <asp:ListItem Text="In Library" Value="IN"></asp:ListItem>
                     <asp:ListItem Text="Out of Library" Value="OUT"></asp:ListItem>
                     <asp:ListItem Text="Un Known" Value="NA"></asp:ListItem>
                 </asp:DropDownList>
                 </td>
                 <td style="width: 20%">
                     Vendor</td>
                
                 <td style="width: 30%">
                 <asp:TextBox ID="txtVendor"  MaxLength="25" runat="server" ></asp:TextBox>
                 
                 </td>
             </tr>
             <tr>
                 <td style="width: 20%">
                     Number of pages</td>
                 <td style="width: 30%">
                     <asp:TextBox ID="txtNoPgs" runat="server"></asp:TextBox></td>
                 <td style="width: 20%">
                     Source</td>
                 
                 <td style="width: 30%">
                     <asp:DropDownList ID="ddlSrc" runat="server" Width="151px">
                         <asp:ListItem Value="0">Select</asp:ListItem>
                         <asp:ListItem>NVS HO</asp:ListItem>
                         <asp:ListItem>NVS RO</asp:ListItem>
                         <asp:ListItem>Local Purchase</asp:ListItem>
                         <asp:ListItem>Gift</asp:ListItem>
                         <asp:ListItem>Others</asp:ListItem>
                     </asp:DropDownList></td>
             </tr>
           
           
           
           
           
           
           
                 
                 
                 
             </table>
             <table align="center" class="tdcls">
             <tr>
                 <td colspan="4" align="center" style="width: 139px" >
                     <asp:Button ID="Button1" runat="server" Text="Save" 
                         OnClientClick="RequiredValidate();" />
                     <asp:Button ID="Button2" runat="server" Text="Clear" />&nbsp;
                     </td>
             </tr>
             </table>
</asp:Content>

