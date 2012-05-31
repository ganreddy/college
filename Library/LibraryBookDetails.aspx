<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LibraryBookDetails.aspx.cs" Inherits="Library_LibraryBookDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
  <%--<label>Book Id</label> <asp:TextBox  runat="server" ID="txtId" ></asp:TextBox>
  <asp:Button ID="btnGet" runat="server" CssClass="btncls" 
        Text="Get Data" Width="91px" />--%>
        
        <table align="center" border="0" cellpadding="1" cellspacing="1" class="maintblcls1"
        style="width: 90%; height: 147%">
        <tr align="center">
            <td style="text-align: center" class="heading" colspan="4">
                <strong>Library Book Details</strong>
            </td>
        </tr>
        <tr class="tdcls">
            <td colspan="4" valign="top">
                <table cellpadding="1" cellspacing="1" width="100%">
                    <!---- Display for Error Messages ---------->
                    
                    <tr align="right">
                        <td colspan="2" style="width: 20%" id="TD1" runat="server" align="left">
                            <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        <tr>
            <td class="subhead" width="40%" valign="top">
                AccessionNo
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblAccessionNo" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%">
                Classification 
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblClassification" runat="server"></asp:Label>
            </td>
        </tr>
         <tr>
            <td class="subhead" width="40%" valign="top">
                Title
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%">
                Category 
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblCategory" runat="server"></asp:Label>
            </td>
        </tr>
         <tr>
            <td class="subhead" width="40%" valign="top">
                DateOfAccession
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblDateOfAccession" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%">
                Sub Category 
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblSubCategory" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td class="subhead" width="40%" valign="top">
                Medium Of Book
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblMEdiumOfBook" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%">
                PhysicalDescription
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblPhysicalDesc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead" width="40%" valign="top">
                Author
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblAuthor" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%">
                Edition
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblEdition" runat="server"></asp:Label>
            </td>
        </tr>
        
         <tr>
            <td class="subhead" width="40%" valign="top">
                Publisher
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblPublisher" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%">
                YearOfPublication
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblYearOfPublication" runat="server"></asp:Label>
            </td>
        </tr>
        
         <tr>
            <td class="subhead" width="40%" valign="top">
                PlaceOfPublication
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblPlaceOfPublication" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%">
                TypeOfBook
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblTypeOfBook" runat="server"></asp:Label>
            </td>
        </tr>
        
         <tr>
            <td class="subhead" width="40%" valign="top">
                ISBN
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblISBN" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%">
                Subject
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblSubject" runat="server"></asp:Label>
            </td>
        </tr>
        
         <tr>
            <td class="subhead" width="40%" valign="top">
                Cost
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblCost" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%">
                TypeOfCurrency
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblTypeOfCurrency" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td class="subhead" width="40%" valign="top" style="height: 18px">
                Volume
            </td>
            <td class="tdcls" valign="top" width="20%" style="height: 18px">
                <asp:Label ID="lblVolume" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%" style="height: 18px">
                Collections
            </td>
            <td class="tdcls" valign="top" width="20%" style="height: 18px">
                <asp:Label ID="lblCollections" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td class="subhead" width="40%" valign="top">
                InVoiceNo
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblInvoiceNo" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%">
                DateOfInvoice
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblDateOfInvoice" runat="server"></asp:Label>
            </td>
        </tr>
        
         <tr>
            <td class="subhead" width="40%" valign="top">
                BookStatus
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblBookStatus" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%">
                Vendor
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblVendor" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td class="subhead" width="40%" valign="top">
                ClassNo
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblClassNo" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%">
                BookNo
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblBookNo" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td class="subhead" width="40%" valign="top">
                Pagination
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblPagination" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%">
                Source
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblSource" runat="server"></asp:Label>
            </td>
        </tr>
        
         <tr style="font-size: 12pt">
            <td class="tdcls" style="width: 20%" valign="top">
            </td>
            <td class="tdcls" style="width: 20%" valign="top">
            </td>
            <td class="tdcls" style="width: 20%" valign="top">
            </td>
            <td class="tdcls" style="width: 20%" valign="top">
            </td>
        </tr>
        <tr class="tdcls" style="font-size: 12pt">
            <td colspan="4" valign="top">
                <!-- Here we start displaying the button table -->
                &nbsp;
                <table align="center" border="0" cellpadding="0" cellspacing="0" style="width: 128px;
                    height: 11px" width="128">
                    <tr>
                        <td style="width: 20%">
                            <asp:Button ID="btnsave" runat="server" CssClass="btncls" Text="Edit" 
                                Width="56px" onclick="btnsave_Click"
                                 />
                            &nbsp;
                            <asp:Button ID="btnreset" runat="server" CssClass="btncls" Text="Reset" Width="56px" />
                        </td>
                    </tr>
                </table>
                <!-- end of displaying the button table -->
            </td>
        </tr>
    </table>
</asp:Content>

