<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditStudentTC.aspx.cs" Inherits="student_EditStudentTC" Title="Edit Student Transfer Certificate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
    
    
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="upd1" runat="server">
    <ContentTemplate>
    <table align="center" border="0" width="60%">
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdntransfer" runat="server" />
                        </td>
                    </tr>
                    <%--<tr align="center">
                        <td class="heading" colspan="2">
                            <strong>SEARCH</strong>
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                              <tr>
                                        <td class="subhead" width="54%">
                                            Batch <span style="font-size: 11px; color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBatch" runat="server" ></asp:Label>
                                               
                                                
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="subhead" width="54%">
                                            Class <span style="font-size: 11px; color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblClasses" runat="server" ></asp:Label>
                                                
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="subhead" width="54%">
                                            Section <span style="font-size: 11px; color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSections" runat="server" ></asp:Label>
                                                
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="subhead" width="54%">
                                            Student <span style="font-size: 11px; color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblStudentID" runat="server" ></asp:Label>
                                        </td>
                                    </tr>--%>
                                
                           
                       
                    <tr align="center">
                        <td class="heading" colspan="2">
                            <strong>TRANSFER CERTIFICATE</strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Admission No <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:Label ID="lblAdmNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trName" runat="server">
                        <td class="subhead">
                            Name&nbsp; <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Father Name&nbsp; <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:Label ID="lblFatherName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Mother Name
                        <span style="font-size: 11px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:Label ID="lblMotherName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Scheduled Caste/Scheduled Tribe&nbsp; <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:Label ID="lblScheduled" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Date Of Birth&nbsp; <span style="font-size: 11px; color: Red">*</span></td>
                        <td nowrap>
                            <asp:Label ID="lblDob" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Class Last Studied
                        <span style="font-size: 11px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:Label ID="lblLastStudied" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="subhead">TcNo</td>
                    <td>
                            <asp:Label ID="lblTcNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class=" subhead">
                            Subjects Studied&nbsp; <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:Label ID="lblSubjetStud" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            School/Board Annual Examination Taken with Result
                            <span style="font-size: 11px; color: Red">*</span>
                        </td>
                        <td>
                           <asp:Label runat="server" ID="lblAnnualExam"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Whether Failed,Once/twice in the Same Class
                            <span style="font-size: 11px; color: Red">*</span>
                        </td>
                        <td >
                            <asp:Label ID="lblFailed" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Qualified for Promotion to the Higherclass
                            <span style="font-size: 11px; color: Red">*</span></td>
                        <td >
                            <asp:Label ID="lblQualifiedPromotion" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="subhead">
                            Month Upto Which fees have been Paid
                        </td>
                        <td>
                            <asp:Label ID="lblMnthPaid" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Whether Pupil was in Receipt of any fee concession
                        </td>
                        <td>
                            <asp:Label ID="lblPupilReceipt" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Date of last attendance at the school
                        <span style="font-size: 11px; color: Red">*</span></td>
                        <td nowrap>
                            <asp:Label ID="lblDOfAttendance" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Number of School days upto the date
                        <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:Label ID="lblNofSchoolDays" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Number of School days Pupil attended
                        <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:Label ID="lblnofPupilAttended" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Date of application for the certificate&nbsp;
                        </td>
                        <td nowrap>
                            <asp:Label ID="lblDateofApplication" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Date of issue of this certificate
                        </td>
                        <td nowrap>
                            <asp:Label ID="lblDofIssue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Reasons for leaving the school
                        <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:Label ID="lblReasons" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            NCC Cadet/Boy Scout/Girl Guide
                        </td>
                        <td>
                            <asp:Label ID="lblNcc" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Extra curricular activities</td>
                        <td>
                            <asp:Label ID="lblExtraactivities" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Conduct<span style="font-size: 11px; color: Red">*</span> </td>
                        <td>
                            <asp:Label ID="lblConduct" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                    
                    
                    <tr>
                        <td class="subhead">
                            Remarks
                        <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" colspan="2" align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" colspan="2" align="center">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" colspan="2" align="center">
                            <asp:Button ID="btnEditLibBookDetails" runat="server" Text="Edit" 
                                onclick="btnEditLibBookDetails_Click" />
                        </td>
                    </tr>
                </table>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
