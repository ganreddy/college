<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentDetails.aspx.cs" Inherits="Default2" Title="Student Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" ID="updStdAttendance">
        <ContentTemplate>
    <table align="center" border="0" cellpadding="1" cellspacing="1" class="maintblcls1"
        style="width: 90%; height: 147%">
        <tr align="center">
            <td style="text-align: center" class="heading" colspan="4">
                <strong>STUDENT ADMISSION DETAILS</strong>
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
            <td colspan="2" valign="top">
                <table border="0" width="100%">
                    <tr>
                        <td class="subhead" width="57%" valign="top">
                            Admission No
                        </td>
                        <td valign="top">
                            <asp:Label ID="lblAdmissionNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="subhead" width="57%" valign="top">
                            Hall Ticket No
                        </td>
                        <td valign="top">
                            <asp:Label ID="lblHallTicketNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" width="57%" valign="top">
                            Rank
                        </td>
                        <td valign="top">
                            <asp:Label ID="lblRank" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" width="57%" valign="top">
                            Region
                        </td>
                        <td valign="top">
                            <asp:Label ID="lblRegion" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                         <td class="subhead" style="width: 20%" valign="top">
                Joining Type
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblJoiningType" runat="server"></asp:Label>
            </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Admission Date
                        </td>
                        <td nowrap>
                            <asp:Label ID="lblAdmissionDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Year
                        </td>
                        <td>
                            <asp:Label ID="lblYear" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 20%" valign="top">
                House Alloted
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblHouse" runat="server"></asp:Label>
            </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top" width="40%" class="subhead">
                Student Photo
            </td>
            <td align="left">
                <asp:Image ID="imgStud" runat="server" Height="100px" Width="80px" ImageUrl="~/images/images.jpg" />
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4" valign="top">
                PERSONAL DETAILS
            </td>
        </tr>
        <tr>
            <td class="subhead" width="40%" valign="top">
                Full Name
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblFullName" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" width="40%">
                Date of Birth
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:Label ID="lblDOB" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead" width="30%" valign="top">
                Mother Tounge
            </td>
            <td class="tdcls" width="20%" valign="top">
                <asp:Label ID="lblMotherTounge" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top">
                <span style="color: black;">Gender</span>
            </td>
            <td class="tdcls" style="width: 20%" valign="top">
                <asp:Label ID="lblGender" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead" width="30%" valign="top">
                Urban / Rural
            </td>
            <td class="tdcls" width="20%" valign="top">
                <asp:Label ID="lblUrbanRural" runat="server"></asp:Label>
            </td>
            <td class="subhead" width="20%" valign="top">
                Mandal
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblMandal" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead" width="30%" valign="top">
                Nationality
            </td>
            <td class="tdcls" width="20%" valign="top">
                <asp:Label ID="lblNationality" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top">
                State
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblState" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td class="subhead" width="30%" valign="top">
                Religion
            </td>
            <td class="tdcls" width="20%" valign="top">
                <asp:Label ID="lblReligion" runat="server"></asp:Label>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Blood Group
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblBloodGroup" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead" width="30%" valign="top">
                Physically Challenged
            </td>
            <td class="tdcls" width="20%" valign="top">
                <asp:Label ID="lblPhysicalChallenged" runat="server"></asp:Label>
            </td>
            <td class="subhead" style="width: 30%" valign="top">
                Caste
            </td>
            <td class="tdcls" style="width: 20%" valign="top">
                <asp:Label ID="lblCaste" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead" width="30%" valign="top">
                Moles Identification1
            </td>
            <td width="20%">
                <asp:Label ID="lblMole1" runat="server"></asp:Label>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Moles Identification2
            </td>
            <td style="width: 30%">
                <asp:Label ID="lblMole2" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead" width="20%" valign="top">
                Extra Curriculum Activities
            </td>
            <td class="tdcls" width="20%" valign="top">
                <asp:Label ID="lblExtraCircullar" runat="server"></asp:Label>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Games Played
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblGames" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead" style="width: 20%" valign="top">
                Email ID
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4" valign="top">
                CONTACT INFORMATION
            </td>
        </tr>
        <tr>
            <td class="subhead" width="20%" valign="top">
                Father's Name
            </td>
            <td class="tdcls" width="20%" valign="top">
                <asp:Label ID="lblFather" runat="server"></asp:Label>
            </td>
             <td class="subhead" style="width: 20%" valign="top">
                Occupation
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblFatherOccup" runat="server"></asp:Label>
            </td>
            <%--<td class="subhead" style="width: 20%" valign="top">
                Mother's Name
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblMother" runat="server"></asp:Label>
            </td>--%>
        </tr>
        <tr>
           <%-- <td class="subhead" style="width: 20%; height: 87px;" valign="top">
                Fathers Photo
            </td>
            <td style="width: 20%; height: 87px;">
                <asp:Image ID="imgFather" runat="server" Height="100px" Width="80px" ImageUrl="~/images/images.jpg" />
            </td>--%>
           <%-- <td class="subhead" style="width: 20%; height: 87px;" valign="top">
                Mothers Photo
            </td>
            <td style="width: 20%; height: 87px;">
                <asp:Image ID="imgMother" runat="server" Height="100px" Width="80px" ImageUrl="~/images/images.jpg" />
            </td>--%>
        </tr>
        <tr>
            <td class="subhead" style="width: 20%" valign="top">
                Address 1
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblAddr1" runat="server"></asp:Label>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Annual Income
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblFatherIncome" runat="server"></asp:Label>
            </td>
            <%--<td class="subhead" style="width: 20%" valign="top">
                Address 2
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblAddr2" runat="server"></asp:Label>
            </td>--%>
        </tr>
        <tr>
            <td class="subhead" style="width: 20%" valign="top">
                Qualification
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblFatherQual" runat="server"></asp:Label>
            </td>
             <td class="subhead" style="width: 20%" valign="top">
                Telephone (Office)
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblTeleOffice" runat="server"></asp:Label>
            </td>
           <%-- <td class="subhead" style="width: 20%" valign="top">
                Qualification
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblMotherQual" runat="server"></asp:Label>
            </td>--%>
        </tr>
        <tr>
           
            <%--<td class="subhead" style="width: 20%" valign="top">
                Occupation
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblMotherOccup" runat="server"></asp:Label>
            </td>--%>
        </tr>
        <tr>
            
           <%-- <td class="subhead" style="width: 20%" valign="top">
                Annual Income
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblMotherIncome" runat="server"></asp:Label>
            </td>--%>
        </tr>
        <tr>
           
           <%-- <td class="subhead" style="width: 20%" valign="top">
                Telephone (Resi)
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblResiTele" runat="server"></asp:Label>
            </td>--%>
        </tr>
        <tr>
            <td class="tdcls" style="width: 20%" valign="top">
            </td>
            <td class="tdcls" style="width: 20%" valign="top">
            </td>
            <td class="tdcls" style="width: 20%" valign="top">
            </td>
            <td class="tdcls" style="width: 20%" valign="top">
            </td>
        </tr>
        <%--<tr>
            <td class="heading" colspan="4" style="width: 20%" valign="top">
                LOCAL GUARDIAN DETAILS
            </td>
        </tr>--%>
        <%--<tr>
            <td class="subhead" style="width: 20%" valign="top">
                Guardian Name
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblGuardianName" runat="server"></asp:Label>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Address
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblGuardianAddr" runat="server"></asp:Label>
            </td>
        </tr>--%>
       <%-- <tr>
            <td class="subhead" style="width: 20%" valign="top">
                Guardian's Photo
            </td>
            <td style="width: 20%">
                <asp:Image ID="imgGuardian" runat="server" Height="100px" Width="80px" ImageUrl="~/images/images.jpg" />
            </td>
        </tr>--%>
        <%--<tr>
            <td class="subhead" valign="top" style="width: 20%">
                Telephone
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblGuardianTele" runat="server"></asp:Label>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Mobile
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblGuardianMobile" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <tr style="font-size: 12pt">
            <td class="heading" colspan="4" style="width: 20%" valign="top">
                PAST EDUCATION HISTORY
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td colspan="4">
                <table width="100%" id="tblEduHis" runat="server">
                    <tr>
                        <td class="heading" valign="top" style="width: 20%">
                            <p align="center">
                                Previous School Name</p>
                        </td>
                        <td class="heading" style="width: 20%" valign="top">
                            <p align="center">
                                From</p>
                        </td>
                        <td class="heading" style="width: 20%" valign="top">
                            <p align="center">
                                To</p>
                        </td>
                        <td class="heading" style="width: 20%" valign="top">
                            <p align="center">
                                Medium</p>
                        </td>
                        <td class="heading" style="width: 20%" valign="top">
                            <p align="center">
                                Board Name</p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--<tr style="font-size: 12pt">
            <td colspan="4">
                <table width="100%" border="0">
                    <tr>
                        <td class="tdcls" style="width: 20%" valign="top">
                            <p>
                                <asp:TextBox ID="txtPrevSchool1" runat="server" CssClass="txtcls"></asp:TextBox>
                                &nbsp;</p>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top" nowrap>
                            <p>
                                <asp:TextBox ID="txtFrom1" runat="server" CssClass="txtcls"></asp:TextBox>
                                    <img id="FromImage1" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                        width="16">
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="FromImage1"
                                    TargetControlID="txtFrom1" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </p>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top" nowrap>
                            <p>
                                <asp:TextBox ID="txtTo1" runat="server" CssClass="txtcls"></asp:TextBox>
                                <img id="ToImage1" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                        width="16">
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="ToImage1"
                                    TargetControlID="txtTo1" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </p>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top">
                            <asp:DropDownList ID="ddlMed1" runat="server" CssClass="txtcls" Width="154px" Height="16%">
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top">
                            <asp:TextBox ID="txtrem1" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="tdcls" style="width: 20%" valign="top">
                            <asp:TextBox ID="txtPrevSchool2" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top" nowrap>
                            <p>
                                <asp:TextBox ID="txtFrom2" runat="server" CssClass="txtcls"></asp:TextBox>
                                <img id="Fromimage2" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                        width="16">
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="Fromimage2"
                                    TargetControlID="txtFrom2" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </p>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top" nowrap>
                            <p>
                                <asp:TextBox ID="txtto2" runat="server" CssClass="txtcls"></asp:TextBox>
                                <img id="ToImage2" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                        width="16">
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="ToImage2"
                                    TargetControlID="txtto2" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </p>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top">
                            <asp:DropDownList ID="ddlMed2" runat="server" CssClass="txtcls" Width="154px" Height="16%">
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top">
                            <asp:TextBox ID="txtrem2" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="tdcls" style="width: 20%" valign="top">
                            <asp:TextBox ID="txtPrevSchool3" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top" nowrap>
                            <p>
                                <asp:TextBox ID="txtFrom3" runat="server" CssClass="txtcls"></asp:TextBox>
                               <img id="FromImage3" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                        width="16">
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" PopupButtonID="FromImage3"
                                    TargetControlID="txtFrom3" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </p>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top" nowrap>
                            <p>
                                <asp:TextBox ID="txtto3" runat="server" CssClass="txtcls"></asp:TextBox>
                                <img id="ToImage3" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                        width="16">
                                <asp:CalendarExtender ID="CalendarExtender7" runat="server" PopupButtonID="ToImage3"
                                    TargetControlID="txtto3" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </p>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top">
                            <asp:DropDownList ID="ddlMed3" runat="server" CssClass="txtcls" Width="154px" Height="16%">
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top">
                            <asp:TextBox ID="txtrem3" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
        <tr style="font-size: 12pt">
            <td class="subhead" style="width: 20%" valign="top">
                Previous School TC No.
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblPrevTCNo" runat="server"></asp:Label>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                TC Issued Date
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblTCIssueDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td class="subhead" style="width: 20%" valign="top">
                TC Issue By JNV.
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblTcIssuedByJnv" runat="server"></asp:Label>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                DateOf Issue
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblDateOfIssue" runat="server"></asp:Label>
            </td>
        </tr>
        <%--<tr>
            <td class="subhead" style="width: 20%" valign="top">
                Tc Issued By JNV
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtJnvIssue" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Date Of Issue
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtDateOfIssue" runat="server" CssClass="txtcls"></asp:TextBox>
                <img src="../images/cal.gif" style="width: 16px; height: 16px" id="imgDateofIssue"/>
                <asp:CalendarExtender ID="CalendarExtender9" runat="server" PopupButtonID="imgDateofIssue"
                                    TargetControlID="txtDateOfIssue" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
            </td>
        </tr>--%>
        <tr style="font-size: 12pt">
            <td class="heading" colspan="4" style="width: 20%" valign="top">
                ADMITTED IN
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td class="subhead" style="width: 20%" valign="top">
                Branch
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblClass" runat="server"></asp:Label>
            </td>
            <%--<td class="subhead" style="width: 20%" valign="top">
                Medium
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblMedium" runat="server"></asp:Label>
            </td>--%>
            <td class="subhead" style="width: 20%" valign="top">
                Section
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblSection" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td class="subhead" style="width: 20%" valign="top">
                Batch
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblBatch" runat="server"></asp:Label>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Alpha Code
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblAlphaCode" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td class="subhead" style="width: 20%" valign="top">
                Group
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:Label ID="lblGroup" runat="server"></asp:Label>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Roll No Alloted
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                
                <asp:Label ID="lblRollNo" runat="server"></asp:Label>
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
                            <asp:Button ID="btnEdit" runat="server" CssClass="btncls" Text="Edit" Width="56px"
                                OnClick="btnEdit_Click" />
                            &nbsp;
                           <%-- <asp:Button ID="btnreset" runat="server" CssClass="btncls" Text="Reset" Width="56px" /--%>
                        </td>
                    </tr>
                </table>
                <!-- end of displaying the button table -->
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

