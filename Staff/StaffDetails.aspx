<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StaffDetails.aspx.cs" Inherits="Staff_StaffDetails" Title="View Staff Details" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <table align="center" border="0" cellpadding="1" cellspacing="1" style="width:100%" class="maintblcls1">
        <tr align="center">
            <td class="heading" colspan="4">
                <strong>STAFF DETAILS</strong>
            </td>
        </tr>
        <tr class="tdcls">
            <td colspan="4">
                <table cellpadding="1" cellspacing="1" width="100%">
                    <!---- Display for Error Messages ---------->
                    <tr class="tdcls">
                        <td align="right">
                            <font color="red"><b>Note:</b></font> All fields marked <font color="red"><sup>*</sup></font>
                            are mandatory
                        </td>
                    </tr>
                    <tr align="right">
                        <td>
                            <asp:HiddenField ID="Message" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4">
                Profile
            </td>
        </tr>
        <tr>
            <td class="subhead">
                StaffNo: 
            </td>
            <td class="tdcls">
                <asp:Label ID="lblStaffNo" runat="server"></asp:Label>
            </td>
            <td class="subhead" valign="top" align="left" rowspan="2" colspan="2" valign="top">
                <table width="100%">
                    <tr>
                        <td valign="top" width="50%" class=""subhead">
                            Photo:
                        </td>
                        <td width="50%">
                            <asp:Image ID="imgStaff" runat="server" Height="100px" Width="80px" ImageUrl="~/images/images.jpg" />
                            
                        </td>
                    </tr>
                </table>  
            </td>
        </tr>
        <tr>
            <td class="subhead" valign="top">
                Date:
            </td>
            <td class="tdcls" valign="top">
                <asp:Label ID="lblDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4" style="height: 17px">
                Personal Details
            </td>
        </tr>
        <tr>
            <td class="subhead" colspan="1">
                Full Name 
            </td>
            <td>
                <asp:Label ID="lblFullNameStaffDetails" runat="server"></asp:Label>
            </td>
            <td class="subhead">
                Date of Birth
            </td>
            <td class="tdcls" colspan="1">
                <asp:Label ID="lblDOBStaffDetails" runat="server"  
                    MaxLength="15"></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td class="subhead" colspan="1">
                Mother Tounge
            </td>
            <td>
                <asp:Label ID="lblMotherToungeStaffDetails" runat="server" 
                     Width="154px">
                    
                </asp:Label>
            </td>
            <td class="subhead">
                Gender
            </td>
            <td class="tdcls">
                <asp:Label ID="lblmaleStaffDetails" runat="server"/>&nbsp;
                
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Nationality
            </td>
            <td>
                <asp:Label ID="lblNation" runat="server"></asp:Label>
            </td>
            <td class="subhead" nowrap>
                Teaching/Non-Teaching
            </td>
            <td class="tdcls">
               <asp:Label ID="lblTeach" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Religion 
            </td>
            <td>
                <asp:Label ID="lblReligion" runat="server"></asp:Label>
            </td>
            <td class="subhead">
                Native Place 
            </td>
            <td class="tdcls" colspan="2">
                <asp:Label ID="lblNativePlaceStaffDetails" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Home Town
            </td>
            <td>
                <asp:Label ID="lblHomeTownStaffDetails" runat="server"></asp:Label>
            </td>
            <td class="subhead">
                Physically Challenged
            </td>
            <td>
                <asp:Label ID="lblPhysicallyChallangedStaffDetails" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            
            <td class="subhead">
                Caste
            </td>
            <td class="tdcls">
                <asp:Label ID="lblcasteStaffDetails" runat="server"   Width="154px"
                    >
                </asp:Label>
            </td>
            <td class="subhead" colspan="1">
                Martial Status
            </td>
            <td>
                <asp:Label ID="lblMartialStatusStaffDetails" runat="server" 
                     Width="154px">
                    
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Mode of AppointMent
            </td>
            <td>
                <asp:Label runat="server" ID="lblModeofAppointMent" Width="154px">
                    
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead" colspan="5">
                Identification Marks :
            </td>
           
        </tr>
        <tr>
            <td class="subhead">
                Mole1:
                
            </td>
            <td class="tdcls">
                <asp:Label ID="lblIdentificationmole1StaffDetails" runat="server" 
                    Height="27px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Mole2 :
            </td>
            <td>
                <asp:Label ID="lblIdentificationMole2" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4">
                Recruitment Information
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Name Of The Post
            </td>
            <td>
                <asp:Label ID="lblPostNameStaffDetails" runat="server"  
                   ></asp:Label>
            </td>
            <td class="subhead">
                Cader
            </td>
            <td class="tdcls">
                <asp:Label ID="lblCaderStaffDetails" runat="server"   Width="154px">
                   
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Type Of Post 
            </td>
            <td>
                <asp:Label ID="lblTypeofPostStaffDetails" runat="server" 
                     Width="154px">
                    
                </asp:Label>
            </td>
            <td class="subhead" nowrap>
                Sanction Of Post
            </td>
            <td class="tdcls">
                <asp:Label ID="lblSanctionofpostStaffDetails" runat="server" 
                    Width="154px">
                    
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Basic Pay + Grade Pay
            </td>
            <td>
                <asp:Label ID="lblBasicPayGradePayStaffDetails" runat="server" 
                    ></asp:Label>
            </td>
            <td class="subhead" nowrap>
                Date Of Joining
            </td>
            <td class="tdcls">
                <asp:Label ID="lblDateofJoiningInJNVStaffDetails" runat="server" 
                    ></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Date Of&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblDateofRetire" runat="server">
                   
                </asp:Label>
                <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td class="tdcls" nowrap>
                <asp:Label ID="lblDateOfStaffDetails" runat="server"  
                    ></asp:Label>
                
            </td>
            <td class="subhead" nowrap>
                Years Of Experience 
            </td>
            <td class="tdcls">
                <asp:Label ID="lblYearsOfExperianceStaffDetails" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead" nowrap>
                Date of Initial Joining
            </td>
            <td class="tdcls">
                <asp:Label ID="lblDateofInitialjoinginJNVSStaffDetails" runat="server" 
                    ></asp:Label>
                
            </td>
            <td class="subhead">
                Discharge of Terminal Benefits<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td nowrap>
                <asp:Label ID="lblDischargeBenefits" runat="server"></asp:Label>
            </td>
            
        </tr>
        <tr>          
            <td class="subhead">
                Nominee 
            </td>
            <td class="tdcls">
                <asp:Label ID="lblNomineeStaffDetails" runat="server"></asp:Label>
            </td>
            <td class="subhead">
                GSLIS Record No
            </td>
            <td>
                <asp:Label ID="lblGSLIS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            
            <td class="subhead">
                GPF A/c No: 
            </td>
            <td class="tdcls">
                <asp:Label ID="lblGpfaccountstaffDetails" runat="server"></asp:Label>
            </td>
            <td class="subhead">
                Certificate Submitted
            </td>
            <td>
                <asp:Label ID="lblCert" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdcls" colspan="2">
                &nbsp;
            </td>
            <td class="tdcls">
                &nbsp;
            </td>
            <td class="tdcls">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4" style="height: 17px">
                Contact information
            </td>
        </tr>
        <tr>
            <td class="subhead" nowrap>
                Permanent Address
            </td>
            <td class="tdcls">
                <asp:Label ID="lblPerminantAddress" runat="server"></asp:Label>
            </td>
            <td class="subhead">
                Present Address 
            </td>
            <td class="tdcls" >
                <asp:Label ID="lblPresentAddress" runat="server"  ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Telephone
            </td>
            <td class="tdcls">
                <asp:Label ID="lblTelephone" runat="server"  ></asp:Label>
            </td>
            <td class="subhead">
                Mobile
            </td>
            <td class="tdcls" >
                <asp:Label ID="lblMobile" runat="server"  ></asp:Label>
            </td>
        </tr>
       <%-- <tr>
            <td class="heading" colspan="4" style="height: 17px">
                Qualifications
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="heading" width="20%">
                            Name Of The Degree
                        </td>
                        <td class="heading" width="20%">
                            Subject
                        </td>
                        <td class="heading" width="20%">
                            Name Of The University
                        </td>
                        <td class="heading" width="20%">
                            Year of Passing
                        </td>
                        <td class="heading" width="20%">
                            Percentage
                        </td>
                    </tr>
                </table>
            </td>
            
        </tr>--%>
        
          <tr style="font-size: 12pt">
            <td class="heading" colspan="4" style="width: 20%" valign="top">
                Staff Qualification
            </td>
        </tr>
        <tr style="font-size: 12pt" >
            <td colspan="4">
                <table width="100%" id="tblQualification" runat="server">
                    <tr>
                        <td class="heading" valign="top" style="width: 20%">
                            <p align="center">
                                Degree</p>
                        </td>
                        <td class="heading" style="width: 20%" valign="top">
                            <p align="center">
                                Subject</p>
                        </td>
                        <td class="heading" style="width: 20%" valign="top">
                            <p align="center">
                               University</p>
                        </td>
                        <td class="heading" style="width: 20%" valign="top">
                            <p align="center">
                                YearOFPassing</p>
                        </td>
                        <td class="heading" style="width: 20%" valign="top">
                            <p align="center">
                                Percentage</p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        <tr>
            <td class="heading" colspan="4">
                Family Details
            </td>
        </tr>
        <tr>
            <td class="heading" width="25%">
                <p align="center">
                    &nbsp;</p>
            </td>
            <td class="heading" width="25%">
                <p align="center">
                    Spouse</p>
            </td>
            <td class="heading" width="25%">
                <p align="center" style="text-align: center">
                    Children</p>
            </td>
            <td class="heading" width="25%">
                <p align="center">
                    Parents</p>
            </td>
            
        </tr>
        <tr>
            <td class="subhead">
                Name <span style="font-size: 10px; color: Red">*</span>&nbsp;
            </td>
            <td class="tdcls" align="center">
                <asp:Label ID="lblSpouseNameStaffDetails" runat="server"  MaxLength="50"></asp:Label>
            </td>
            <td class="tdcls" style="text-align: center">
                <asp:Label ID="lblNameChildrenStaffDetails" runat="server"  MaxLength="50"
                    ></asp:Label>
            </td>
            <td class="tdcls" align="center">
                <asp:Label ID="lblParentsNameStaffDetails" runat="server"  MaxLength="50"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td class="subhead">
                Contact No<span style="font-size: 10px; color: Red">*</span>&nbsp;
                
            </td>
            <td class="tdcls" valign="top" align="center">
                <asp:Label ID="lblSpouseContectNoStaffDetails" runat="server" 
                    MaxLength="20"></asp:Label>
            </td>
            <td class="tdcls" valign="top" style="text-align: center">
                <asp:Label ID="lblcontactChiStaffDetails" runat="server"  MaxLength="50"
                   ></asp:Label>
            </td>
            <td class="tdcls" valign="top" align="center">
                <asp:Label ID="lblParentsContectNoStaffDetails" runat="server" 
                    MaxLength="15"></asp:Label>
            </td>
            
        </tr>
        <tr style="font-size: 12pt">
            <td class="subhead">
                Place<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td class="tdcls" align="center">
                
                <asp:Label ID="lblSPlaceStaffDetails" runat="server"></asp:Label>
            </td>
            <td class="tdcls" style="text-align: center">
                <asp:Label ID="lblChildrenPlaceStaffDetails" runat="server"  MaxLength="50"
                    ></asp:Label>
            </td>
            <td class="tdcls" align="center">
                <asp:Label ID="lblParentsPlaceStaffDetails" runat="server"  MaxLength="15"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td class="subhead">
                Employee Status<span style="font-size: 10px; color: Red">
                    *</span>&nbsp;
            </td>
            <td class="tdcls" align="center">
                
                <asp:Label ID="lblSEmpStatusStaffDetails" runat="server"></asp:Label>
            </td>
            <td class="tdcls" style="text-align: center">
                <asp:Label ID="lblChildrenEmpstatusStaffDetails" runat="server" 
                    MaxLength="50" ></asp:Label>
            </td>
            <td class="tdcls" align="center">
                <asp:Label ID="lblParentsEmpStatusStaffDetails" runat="server" 
                    MaxLength="15"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td colspan="5" height="1%" valign="top">
                <!-- Here we start displaying the button table -->
                &nbsp;
                <table align="center" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Button ID="btnSaveStaffDetails" runat="server" Text="Edit"
                                Width="56px" onclick="btnSaveStaffDetails_Click"  />
                            &nbsp;
                            </td>
                    </tr>
                </table>
                <!-- end of displaying the button table -->
            </td>
        </tr>
    </table>
  
</asp:Content>

