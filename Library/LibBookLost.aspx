<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LibBookLost.aspx.cs" Inherits="LibBookLost" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

<script src="../scripts/Validations.js" type="text/javascript"></script>
    <script type="text/jscript" language="javascript">
    function RequiredValidate()
    {
    if(!isEmpty('<%=txtBookno.ClientID%>',"please enter the Accession Number" ))return false;
    if(!isNumeric('<%=txtBookno.ClientID%>',"please enter Numeric of AccessionNo" ))return false;
    if(!isEmpty('<%=txtStudentId.ClientID%>',"please enter the StudentId" ))return false;
    //if(!isNumeric('<%=txtStudentId.ClientID%>',"please enter Numeric of StudentId" ))return false;
    if(!isEmpty('<%=txtStaffId.ClientID%>',"please enter the StaffId" ))return false;
    //if(!isNumeric('<%=txtStaffId.ClientID%>',"please enter Numeric of StaffId" ))return false;
    if(!isDateFormat('<%=txtDateOfAccession.ClientID%>',"please enter dd/mm/yyyy Format of DateOfAccession" ))return false;
//    if(! DropdownValidate('<%=ddlTypeOfBook.ClientID%>',"pls select TypeofBook"))return false;
//    if(! DropdownValidate('<%=ddlMediumOfBook.ClientID%>',"pls select MediumofBook"))return false;
    if(!isEmpty('<%=txtIsbnNo.ClientID%>',"please enter the ISBN number" ))return false;
    if(!isEmpty('<%=txtCost.ClientID%>',"please enter the Cost" ))return false;
    if(!isEmpty('<%=txtClassNumber.ClientID%>',"please enter ClassNumber" ))return false;
    if(!isEmpty('<%=txtBookNumber.ClientID%>',"please enter BookNumber" ))return false;
    if(!isEmpty('<%=txtAmount.ClientID%>',"please enter Amount" ))return false;
    if(!isEmpty('<%=txtReceiptno.ClientID%>',"please enter Fine Reciept Number" ))return false;
    if(!isDateFormat('<%=txtDateOfPayment.ClientID%>',"please enter dd/mm/yyyy Format of DateOfPayment" ))return false;
   
    
    
    
    }
  </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

<table align="center" class="tdcls" style="width: 90%; height: 147%">
             <tr>
                 <td  colspan="4" style="height: 17%">
                 <asp:HiddenField runat="server" ID="Message"/>
                 </td>
             </tr>
            <tr>
                <td colspan="4" class="heading" style="height: 17%; text-align:center; ">
                    BOOK LOST</td>
            </tr>
             <tr>
                 <td style="width: 20%" class="subhead">
                     Accession No<span style="color: #ff0000">*</span></td>
                 <td style="width: 30%">
                     <asp:TextBox ID="txtBookno" runat="server" MaxLength="30"></asp:TextBox></td>
                 <td style="width: 20%" class="subhead">
                     Classfication Number<br />
                     </td>
                 <td style="width: 30%">
                     <asp:TextBox ID="txtClassNo" runat="server"></asp:TextBox></td>
             </tr>
             
             <tr>
                 <td style="width: 20%">
                     </td>
                 <td style="width: 20%">
                     </td>
                 <td style="width: 20%" class="subhead">
                   Lost By</td>
                 <td style="width: 30%">
                    <asp:RadioButton ID="rbStudentId" runat="server" Checked="True" CssClass="rbStudent" ForeColor="Black"
                        GroupName="rbCollection" Text="Student" /><asp:RadioButton ID="rbStaffId" runat="server" Checked="True" CssClass="rbStaff" ForeColor="Black"
                        GroupName="rbCollection" Text="Staff" /></td>
             </tr>
             
             
             
             <tr>
                 <td style="width: 20%" class="subhead">
                     Student Id<span style="color: #ff0000">*</span></td>
                 <td style="width: 30%">
                     <asp:TextBox ID="txtStudentId" runat="server" MaxLength="30"></asp:TextBox></td>
                 <td style="width: 20%" class="subhead">
                     Staff Id<span style="color: #ff0000">*</span><br />
                   </td>
                 <td style="width: 30%">
                     <asp:TextBox ID="txtStaffId" runat="server"></asp:TextBox></td>
             </tr>
             
             
                         
            <tr>
                <td style="width: 20%" class="subhead">
                    Title</td>
                <td style="width: 30%" class="subhead"> 
                    <asp:TextBox ID="txtTitle" MaxLength="30" runat="server"></asp:TextBox></td>
                <td style="width: 20%" class="subhead">
                    Category</td>
                <td style="width: 30%">
                    <asp:DropDownList ID="ddlBookCategory" runat="server" Width="59%" Height="16%"></asp:DropDownList></td>
            </tr>
             <tr>
                <td style="width: 20%" class="subhead">
                    Date Of Accession<span style="color: #ff0000">*</span></td>
                <td style="width: 30%">
                    <asp:TextBox ID="txtDateOfAccession" MaxLength="30" runat="server"></asp:TextBox>
                <img src="../images/cal.gif" id="image1" />
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="image1" TargetControlID="txtDateOfAccession">
                    </asp:CalendarExtender>
                
                </td>
                <td style="width: 20%" class="subhead">
                    Type Of Book<span style="color: #ff0000">*</span></td>
                <td style="width: 30%">
                    <asp:DropDownList ID="ddlTypeOfBook" runat="server" Width="59%" Height="16%"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 20%" class="subhead">
                    Medium Of Book<span style="color: #ff0000">*</span></td>
                <td style="width: 30%">
                     <asp:DropDownList ID="ddlMediumOfBook" runat="server" Width="59%" 
                         Height="16px"></asp:DropDownList></td>
                <td style="width: 20%" class="subhead">
                    Physical Description</td>
                <td style="width: 30%">
                  <%--<asp:DropDownList ID="DropDownList2" runat="server" Width="156px"></asp:DropDownList>--%>
                   <asp:TextBox ID="txtPublication" runat="server" MaxLength="50"></asp:TextBox>
                   </td>
            </tr>
             <tr>
                 <td style="width: 20%" class="subhead">
                     Author(s)</td>
                 <td style="height: 30%">
                     <asp:TextBox ID="txtAuthors" runat="server" MaxLength="30"></asp:TextBox></td>
                 <td style="width: 20%" class="subhead">
                     Edition</td>
                 <td style="height: 30%">
                     <asp:TextBox ID="txtEdition" runat="server" MaxLength="10"></asp:TextBox></td>
             </tr>
             <tr>
                 <td style="width: 20%" class="subhead">
                     Publisher</td>
                 <td style="width: 30%">
                   <asp:TextBox ID="txtPublisher" runat="server" MaxLength="50"></asp:TextBox></td>
                 <td style="width: 20%" class="subhead">
                    Year Of Publication</td>
                 <td style="width: 30%">
                    <asp:DropDownList ID="ddlYearofPublication" runat="server" MaxLength="6" Width="59%" Height="16%"></asp:DropDownList></td>
             </tr>
             <tr>
                 <td style="width: 20%" class="subhead">
                     Place Of Publication>
                 <td style="width: 30%">
                  <asp:DropDownList ID="ddlPlaceOfPublication" runat="server" MaxLength="6" Width="59%" Height="16%"></asp:DropDownList>
                 <td>
                    <%--Year Of Publication<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server"
                         ControlToValidate="ddlYearofPublication" ErrorMessage="Please enter year of publication"
                         SetFocusOnError="True">*</asp:RequiredFieldValidator>--%></td>
                 <td style="width: 20%">
                    </td>
             </tr>
             
             
             
             
             <tr>
                 <td style="width: 20%" class="subhead">
                     ISBN<span style="color: #ff0000">*</span></td>
                 <td style="width: 30%">
                     <asp:TextBox ID="txtIsbnNo" runat="server" MaxLength="20"></asp:TextBox></td>
                 <td style="width: 20%" class="subhead">
                     Subject(Provide if Available)</td>
                 <td style="width: 30%">
                     <asp:DropDownList ID="ddlSubject" runat="server" Width="59%" Height="16%"></asp:DropDownList></td>
             </tr>
             <tr>
                 <td style="width: 20%" class="subhead">
                     Cost<span style="color: #ff0000">*</span></td>
                 <td style="width: 30%">
                     <asp:TextBox ID="txtCost" runat="server" MaxLength="9"></asp:TextBox></td>
                 <td style="width: 20%" class="subhead">
                    Type Of Curency</td>
                 <td style="width: 30%">
                      <asp:DropDownList ID="ddlTypeOfCurrency" runat="server" Width="59%" Height="16%"></asp:DropDownList></td>
             </tr>
             
             <tr>
             <td style="width: 20%" class="subhead">Volume </td>             
             <td style="width: 30%">
             <asp:DropDownList ID="ddlVolume" runat="server" Width="59%" Height="16%"></asp:DropDownList>
             </td>            
             <td style="width: 20%" class="subhead"> Collections<span style="color: #ff0000">*</span> </td>            
             <td style="width: 30%">
              <asp:RadioButton ID="rbCirculation" runat="server" Checked="True" CssClass="rbcls" ForeColor="Black"
                        GroupName="rbgender" Text="Circulation" /><asp:RadioButton ID="rbReference" runat="server" Checked="True" CssClass="rbcls" ForeColor="Black"
                        GroupName="rbgender" Text="Reference" />
             </td>
             </tr>
             <tr>
                 <td style="width: 20%" class="subhead">
                     Invoice No</td>
                 <td style="width: 30%">
                     <asp:TextBox ID="TextBox2" runat="server" MaxLength="20"></asp:TextBox></td>
                 <td style="width: 20%" class="subhead">
                     Date Of Invoice No</td>
                 <td style="width: 30%">
                    <asp:TextBox ID="txtDateOfInvoice" runat="server" MaxLength="50" ></asp:TextBox>
                     <img src="../images/cal.gif" id="image2"/>
                     <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="image2" TargetControlID="txtDateOfInvoice">
                     </asp:CalendarExtender>
                     </td>
             </tr>
             
             <tr>
                 <td style="width: 20%" class="subhead">
                     Status Of The Book</td>
                 <td style="width: 30%">
                     <asp:TextBox ID="txtBookStatus"  MaxLength="25" runat="server" ></asp:TextBox>
                 </td>
                 <td style="width: 20%" class="subhead">
                     Vendor</td>
                 <td style="width: 30%">
                 <asp:TextBox ID="txtVendor"  MaxLength="25" runat="server" ></asp:TextBox>
                 
                 </td>
             </tr>
             <tr>
             <td style="width: 20%" class="subhead">
              Class No<span style="color: #ff0000">*</span>
             </td>
             <td style="width: 30%"> <asp:TextBox ID="txtClassNumber"  MaxLength="25" runat="server" ></asp:TextBox></td>
             <td style="width: 20%" class="subhead">
             Book No<span style="color: #ff0000">*</span>
             </td>
             <td style="width:30%"><asp:TextBox ID="txtBookNumber"  MaxLength="25" runat="server" ></asp:TextBox></td>
             </tr>
             
             <tr>
                 <td style="width: 20%" class="subhead">
                     Pagination</td>
                 <td style="width: 30%">
                     <asp:TextBox ID="txtNoPgs" runat="server"></asp:TextBox></td>
                 <td style="width: 20%" class="subhead">
                     Source</td>
                 <td style="width: 30%">
                     <asp:DropDownList ID="ddlSrc" runat="server" Width="59%" Height="16%">
                         <asp:ListItem Value="0">Select</asp:ListItem>
                         <asp:ListItem>NVS HO</asp:ListItem>
                         <asp:ListItem>NVS RO</asp:ListItem>
                         <asp:ListItem>Local Purchase</asp:ListItem>
                         <asp:ListItem>Gift</asp:ListItem>
                         <asp:ListItem>Others</asp:ListItem>
                     </asp:DropDownList></td>
             </tr>
             
             <tr>
            <td style="width: 20%" class="subhead">
               Fine Amount<span style="color: #ff0000">*</span></td>  
            
        
            <td style="width:30%">
                <asp:TextBox ID="txtAmount" runat="server" MaxLength="9">
            
                </asp:TextBox></td>
                
        
            <td style="width: 20%" class="subhead">
             Date Of Payment<span style="color: #ff0000">*</span>
            </td>
            <td style="width:30%">
                <asp:TextBox ID="txtDateOfPayment" runat="server" MaxLength="25" >
                </asp:TextBox>
                <img src="../images/cal.gif" id="image3" style="width: 16px; height: 16px" />
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="image3" TargetControlID="txtDateOfPayment">
                </asp:CalendarExtender>
                </td>
        </tr>
             
             <tr>
            <td style="width: 20%" class="subhead">
              Fine Receipt No<span style="color: #ff0000">*</span>
            </td>
            <td style="width: 30%">
                <asp:TextBox ID="txtReceiptno" runat="server" MaxLength="50"  ></asp:TextBox>
                </td>
        </tr>
             
             
          
             
             </table>
             <table align="center" class="tdcls">
             <tr>
                 <td colspan="4" align="center" style="width: 139px" >
                     <asp:Button ID="Button1" runat="server" Text="Save" OnClientClick="RequiredValidate();" />
                     <asp:Button ID="Button2" runat="server" Text="Clear" />&nbsp;
                     
                     </td>
             </tr>
             </table>
</asp:Content>

