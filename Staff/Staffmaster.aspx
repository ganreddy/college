<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Staffmaster.aspx.cs" Inherits="Staffmaster" Title="Staff Admission" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function AddPhoto(UploadID, ImageID) {
            var path = document.getElementById(UploadID).value;
            document.getElementById(ImageID).src = path;
        }

        function Retirement() {
            if (document.getElementById('<%=ddlDateofStaffDetails.ClientID%>').selectedIndex == 1) {
                var Bday = document.getElementById('<%=txtDOBStaffDetails.ClientID%>').value.split("/")[0];
                var BMon = document.getElementById('<%=txtDOBStaffDetails.ClientID%>').value.split("/")[1];
                var BYear = parseInt(document.getElementById('<%=txtDOBStaffDetails.ClientID%>').value.split("/")[2]);
                var Year = BYear + 70;
                if (Retirement != "") {
                    document.getElementById('<%=txtDateOfStaffDetails.ClientID%>').value = Bday + "/" + BMon + "/" + Year;
                }
            }
        }
        function validate() {

            if (!isEmpty('<%= txtStaffNo.ClientID %>', "Please Enter Staff No")) return false;

            //         
            //          if(! isEmpty('<%=txtDate.ClientID%>',"Please Enter Date"))return false;
            //      if(document.getElementById('<%=txtDate.ClientID %>').value!="")
            //        {
            //           if(! isDateFormat('<%=txtDate.ClientID %>',"Date Format should be dd/mm/yyyy")) return false;
            //        }

            if (!isEmpty('<%=txtFullNameStaffDetails.ClientID%>', "Please Enter Full Name")) return false;

            if (!isEmpty('<%=txtDOBStaffDetails.ClientID%>', "Please Enter Date Of Birth")) return false;
            if (document.getElementById('<%=txtDOBStaffDetails.ClientID %>').value != "") {
                if (!isDateFormat('<%=txtDOBStaffDetails.ClientID %>', "Date Format Should Be DD/MM/YYYY")) return false;
            }
            if (!DropdownValidate('<%=ddlMotherToungeStaffDetails.ClientID%>', "Please Select Mother Tounge")) return false;

            var Male = document.getElementById('<%=rbmaleStaffDetails.ClientID%>').checked;
            var Female = document.getElementById('<%=rbnFemaleStaffDetails.ClientID%>').checked;
            if ((Male == false) && (Female == false)) {
                alert("Please Choose Any One Male/Female");
                return false;
            }

            if (!DropdownValidate('<%=ddlNationalityStaffDetails.ClientID%>', "Please Select Nationality")) return false;
            if (!DropdownValidate('<%=ddlTeachindNonRTeachingStaffDetails.ClientID%>', "Please Select Teaching/NonTeaching Details")) return false;


            if (!isEmpty('<%= txtReligion.ClientID%>', "Please Enter Religion")) return false;
            if (document.getElementById('<%=txtReligion.ClientID %>').value != "") {
                if (!ValidateTextFormat('<%= txtReligion.ClientID %>', "Please Enter Correct Religion")) return false;
            }
            if (!DropdownValidate('<%=ddlPhysicallyChallangedStaffDetails.ClientID%>', "Please Select Physically Challanged")) return false;
            if (!DropdownValidate('<%=ddlcasteStaffDetails.ClientID%>', "Please Select Caste")) return false;
            if (!DropdownValidate('<%=ddlMartialStatusStaffDetails.ClientID%>', "Please Select Martial Status")) return false;
            if (!DropdownValidate('<%=ddlModeofAppointMent.ClientID%>', "Please Select Mode of AppointMent")) return false;
            if (!isEmpty('<%= txtIdentificationmole1StaffDetails.ClientID%>', "Please Enter Identification Mole")) return false;
            if (document.getElementById('<%=txtIdentificationmole1StaffDetails.ClientID %>').value != "") {
                if (!ValidateTextFormat('<%= txtIdentificationmole1StaffDetails.ClientID %>', "Please Enter Correct Identification Mole")) return false;
            }
            if (!isEmpty('<%= txtPostNameStaffDetails.ClientID%>', "Please Enter Name Of The Post")) return false;
            if (document.getElementById('<%=txtPostNameStaffDetails.ClientID %>').value != "") {
                if (!ValidateTextFormat('<%= txtPostNameStaffDetails.ClientID %>', "Please Enter Correct Name Of The Post")) return false;
            }
            if (!DropdownValidate('<%=ddlCaderStaffDetails.ClientID%>', "Please Select Cader")) return false;

            if (!isEmpty('<%=txtDOBStaffDetails.ClientID%>', "Please Enter Date Of Birth")) return false;
            if (document.getElementById('<%=txtDOBStaffDetails.ClientID %>').value != "") {
                if (!isDateFormat('<%=txtDOBStaffDetails.ClientID %>', "Date Format Should Be DD/MM/YYYY")) return false;
            }

            if (!DropdownValidate('<%=ddlTypeofPostStaffDetails.ClientID%>', "Please Select Type Of Post")) return false;
            if (!DropdownValidate('<%=ddlSanctionofpostStaffDetails.ClientID%>', "Please Select Sanction Of Post")) return false;

            if (!isEmpty('<%= txtBasicPayGradePayStaffDetails.ClientID%>', "Please Enter Grade Pay In Numeric")) return false;
            if (document.getElementById('<%=txtBasicPayGradePayStaffDetails.ClientID %>').value != "") {
                if (!isDecimal('<%= txtBasicPayGradePayStaffDetails.ClientID %>', "Please Enter Valid Basic Pay")) return false;
            }
            if (!isEmpty('<%=txtDateofJoiningInJNVStaffDetails.ClientID%>', "Please Enter Date Of Joining In JNVS")) return false;
            if (document.getElementById('<%=txtDateofJoiningInJNVStaffDetails.ClientID %>').value != "") {
                if (!isDateFormat('<%=txtDateofJoiningInJNVStaffDetails.ClientID %>', "Date Format Should Be DD/MM/YYYY")) return false;
            }
            if (!DropdownValidate('<%=ddlDateofStaffDetails.ClientID%>', "Please Select Option for Retirement/Suspension/Resignation")) return false;
            if (!isEmpty('<%=txtDateOfStaffDetails.ClientID%>', "Please Enter Date Of Retirement/Suspension/Resignation")) return false;
            if (document.getElementById('<%=txtDateOfStaffDetails.ClientID %>').value != "") {
                if (!isDateFormat('<%=txtDateOfStaffDetails.ClientID %>', "Date Format Should Be DD/MM/YYYY For Retirement/Suspension/Resignation")) return false;
            }
            if (!isEmpty('<%=txtDateofInitialjoinginJNVSStaffDetails.ClientID%>', "Please Enter Date Of Initial Joining In JNVS(Samithi) ")) return false;
            if (document.getElementById('<%=txtDateofInitialjoinginJNVSStaffDetails.ClientID %>').value != "") {
                if (!isDateFormat('<%=txtDateofInitialjoinginJNVSStaffDetails.ClientID %>', "Date Format Should Be DD/MM/YYYY")) return false;
            }
            if (!DateFormat12('<%= txtDateofInitialjoinginJNVSStaffDetails.ClientID%>', '<%= txtDateofJoiningInJNVStaffDetails.ClientID%>', "Please Enter Date Of Initial Joining In JNV Samithi<=Date Of Joining In JNV ")) return false;


            if (!isEmpty('<%= txtYearsOfExperianceStaffDetails.ClientID%>', "Please Enter Years Of Experiance")) return false;
            if (document.getElementById('<%=txtYearsOfExperianceStaffDetails.ClientID %>').value != "") {
                if (!isNumeric('<%= txtYearsOfExperianceStaffDetails.ClientID %>', "Please Enter Correct Years Of Experiance")) return false;
            }
            var PF = document.getElementById('<%= chkPFStaffDetails.ClientID %>').checked;
            var LIC = document.getElementById('<%= chkLICStaffDetails.ClientID %>').checked;
            var Gratuity = document.getElementById('<%= chkGratuityStaffDetails.ClientID %>').checked;
            if ((PF) == false && (LIC) == false && (Gratuity) == false) {
                alert("select Atleast One CheckBox of PF/LIC/Gratuity");
                return false;
            }

            if (!ValidateTextFormat('<%= txtNomineeStaffDetails.ClientID%>', "Please Enter Nominee")) return false;
            if (!isEmpty('<%= txtGpfaccountstaffDetails.ClientID%>', "Please Enter GPF A/C")) return false;

            if (!isEmpty('<%= txtPerminantAddress.ClientID%>', "Please Enter Permanent Address")) return false;
            if (document.getElementById('<%=txtPerminantAddress.ClientID %>').value != "") {
                //if(! ValidateTextFormat('<%= txtPerminantAddress.ClientID %>',"Please enter correct Address ")) return false;
            }
            if (!isEmpty('<%= txtPresentAddress.ClientID%>', "Please Enter Present Address")) return false;
            if (document.getElementById('<%=txtPresentAddress.ClientID %>').value != "") {
                //if(! ValidateTextFormat('<%= txtPresentAddress.ClientID %>',"Please enter correct Present Address ")) return false;
            }
            //            if (!isEmpty('<%= txtTelephone.ClientID%>', "Please Enter Telephone Number")) return false;
            //            if (document.getElementById('<%=txtTelephone.ClientID %>').value != "") {

            //                if (!isNumeric('<%= txtTelephone.ClientID %>', "Please Enter Correct Telephone Number ")) return false;

            //            }
            if (!isNumeric('<%= txtMobile.ClientID%>', "Please Enter Mobile Number")) return false;


           if (!DropdownValidate('<%= ddlDegree1StaffDetails.ClientID %>', "Please Select Name of Degree")) return false;

            if (!DropdownValidate('<%= ddlSubject1StaffDetails.ClientID %>', "Please Select Subject")) return false;

            if (!isEmpty('<%= txtUniversity1StaffDetails.ClientID %>', "Please Enter University")) return false;
            if (!DropdownValidate('<%= ddlPassingYear1StaffDetails.ClientID %>', "Please Select Passing Year")) return false;
            if (!isEmpty('<%= txtPersent1StaffDetails.ClientID %>', "Please Enter Percentage")) return false;



            if (document.getElementById('<%= ddlMartialStatusStaffDetails.ClientID%>').selectedIndex == 1) {
                if (!isEmpty('<%= txtSpouseNameStaffDetails.ClientID%>', "Please Enter Spouse Name")) return false;
                if (document.getElementById('<%=txtSpouseNameStaffDetails.ClientID %>').value != "") {
                    if (!ValidateTextFormat('<%= txtSpouseNameStaffDetails.ClientID %>', "Please Enter Correct Spouse Name ")) return false;
                }
                if (!isEmpty('<%= txtSpouseContectNoStaffDetails.ClientID%>', "Please Enter Spouse Contact Number")) return false;
                if (document.getElementById('<%=txtSpouseContectNoStaffDetails.ClientID %>').value != "") {
                    if (!isNumeric('<%= txtSpouseContectNoStaffDetails.ClientID %>', "Please Enter correct Spouse Contact Number ")) return false;
                }
                //if(! isEmpty('<%= txtSpouseContectNoStaffDetails.ClientID%>',"Please Enter Contect number"))return false;
                //      if(document.getElementById('<%=txtSpouseContectNoStaffDetails.ClientID %>').value!="")
                //        {
                //           if(! isNumeric('<%= txtSpouseContectNoStaffDetails.ClientID %>',"Please enter correct Contect Number ")) return false;
                //        }
                if (!isEmpty('<%= txtSPlaceStaffDetails.ClientID%>', "Please Enter Spouse Place")) return false;
            }

////            if (!isEmpty('<%= txtNameChildrenStaffDetails.ClientID%>', "Please Enter Children's Name")) return false;
////            if (document.getElementById('<%=txtNameChildrenStaffDetails.ClientID %>').value != "") {
////                if (!ValidateTextFormat('<%= txtNameChildrenStaffDetails.ClientID %>', "Please Enter Correct Children's Name")) return false;
////            }
            //        if(! isEmpty('<%= txtcontactChiStaffDetails.ClientID%>',"Please Enter Contect  number"))return false;
            //      if(document.getElementById('<%=txtcontactChiStaffDetails.ClientID %>').value!="")
            //        {
            //         if(! isNumeric('<%= txtcontactChiStaffDetails.ClientID %>',"Please enter correct  Contect Number ")) return false;
            //        }
            //         if(! isEmpty('<%= txtChildrenPlaceStaffDetails.ClientID%>',"Please Enter place"))return false;
            //      if(document.getElementById('<%=txtChildrenPlaceStaffDetails.ClientID %>').value!="")
            //        {
            //           if(! ValidateTextFormat('<%= txtChildrenPlaceStaffDetails.ClientID %>',"Please enter correct Place ")) return false;
            //        }
            //        if(! isEmpty('<%= txtChildrenEmpstatusStaffDetails.ClientID%>',"Please Enter Employee Status"))return false;
            //      if(document.getElementById('<%=txtChildrenEmpstatusStaffDetails.ClientID %>').value!="")
            //        {
            //           if(! ValidateTextFormat('<%= txtChildrenEmpstatusStaffDetails.ClientID %>',"Please enter correct Emoployee Status ")) return false;
            //        }
            if (!isEmpty('<%= txtParentsNameStaffDetails.ClientID%>', "Please Enter Parent's Name")) return false;
            if (document.getElementById('<%=txtParentsNameStaffDetails.ClientID %>').value != "") {
                if (!ValidateTextFormat('<%= txtParentsNameStaffDetails.ClientID %>', "Please Enter Correct Childrens Name")) return false;
            }


                    if(! isEmpty('<%= txtParentsContectNoStaffDetails.ClientID%>',"Please Enter Contect  number"))return false;
                  if(document.getElementById('<%=txtParentsContectNoStaffDetails.ClientID %>').value!="") {
                      if(! isNumeric('<%= txtParentsContectNoStaffDetails.ClientID %>',"Please enter correct  Contect Number ")) return false;
                    }


                     if(! isEmpty('<%= txtParentsPlaceStaffDetails.ClientID%>',"Please Enter place"))return false;
                 if(document.getElementById('<%=txtParentsPlaceStaffDetails.ClientID %>').value!="")
                   {
                       if(! ValidateTextFormat('<%= txtParentsPlaceStaffDetails.ClientID %>',"Please enter correct Place ")) return false;
                   }
            //        
            //        
            //        if(! isEmpty('<%= txtParentsEmpStatusStaffDetails.ClientID%>',"Please Enter Employee Status"))return false;
            //      if(document.getElementById('<%=txtParentsEmpStatusStaffDetails.ClientID %>').value!="")
            //        {
            //           if(! ValidateTextFormat('<%= txtParentsEmpStatusStaffDetails.ClientID %>',"Please enter correct Emoployee Status ")) return false;
            //        }


        }
   
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%--<asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>--%>
    <table align="center" border="0" cellpadding="1" cellspacing="1" style="width: 100%"
        class="maintblcls1">
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
                PROFILE
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Staff No: <font color="red"><sup>*</sup></font>
            </td>
            <td class="tdcls">
                <asp:TextBox ID="txtStaffNo" runat="server"></asp:TextBox>
            </td>
            <td class="subhead" valign="top" align="left" rowspan="2" colspan="2" valign="top">
                <table width="100%">
                    <tr>
                        <td valign="top" width="50%" class="subhead">
                            Photo:
                        </td>
                        <td width="50%">
                            <asp:Image ID="imgStaff" runat="server" Height="100px" Width="80px" ImageUrl="~/images/images.jpg" />
                            <br />
                            <asp:FileUpload ID="fudStaffPhoto" runat="server" valign="top" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="subhead" valign="top" style="display: none">
                Admission Date:
            </td>
            <td class="tdcls" valign="top" style="display: none">
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16" style="height: 16px"
                    runat="server" id="imgcal">--%>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                    Width="16" Style="height: 16px" ID="imgcal" />
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                    PopupButtonID="imgcal" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4" style="height: 17px">
                PERSONAL DETAILS
            </td>
        </tr>
        <tr>
            <td class="subhead" colspan="1">
                Full Name <span style="color: black;"><span style="font-size: 10px; color: Red">*</span>
                </span>
            </td>
            <td>
                <asp:TextBox ID="txtFullNameStaffDetails" runat="server"></asp:TextBox>
            </td>
            <td class="subhead">
                Date Of Birth<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td class="tdcls" colspan="1">
                <asp:TextBox ID="txtDOBStaffDetails" runat="server" CssClass="txtcls" MaxLength="15"></asp:TextBox>
                <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16" id="imgcal1">--%>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                    Width="16" ID="imgcal1" />
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDOBStaffDetails"
                    PopupButtonID="imgcal1" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="subhead" colspan="1">
                Mother Tounge&nbsp; <span style="color: black;"><span style="font-size: 10px; color: Red">
                    *</span> </span>
            </td>
            <td>
                <asp:DropDownList ID="ddlMotherToungeStaffDetails" runat="server" CssClass="ddlcls"
                    Width="154px">
                    <%-- <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="Telugu">Telugu</asp:ListItem>
                    <asp:ListItem Value="English">English</asp:ListItem>
                    <asp:ListItem></asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td class="subhead">
                Gender<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td class="tdcls">
                <asp:RadioButton ID="rbmaleStaffDetails" runat="server" CssClass="rbcls" ForeColor="Black"
                    GroupName="Gender" Text="Male" />&nbsp;
                <asp:RadioButton ID="rbnFemaleStaffDetails" runat="server" CssClass="rbcls" ForeColor="Black"
                    GroupName="Gender" Text="Female" />
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Nationality<span style="font-size: 10px; color: Red"> *</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlNationalityStaffDetails" runat="server" CssClass="ddlcls"
                    Width="154px">
                    <asp:ListItem>Select</asp:ListItem>
                    <%--<asp:ListItem Value="1">Indian</asp:ListItem>
                    <asp:ListItem Value="2">NRI</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td class="subhead" nowrap>
                Teaching/Non-Teaching&nbsp; <span style="color: black;"><span style="font-size: 10px;
                    color: Red">*</span>&nbsp;
            </td>
            <td class="tdcls">
                <asp:DropDownList ID="ddlTeachindNonRTeachingStaffDetails" runat="server" Width="154px">
                    <%-- <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="T">Teaching</asp:ListItem>
                    <asp:ListItem Value="NT">Non Teaching</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Religion <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtReligion" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
            <%--<td class="subhead">
                Native Place <span style="font-size: 10px; color: Red"> *</span>
            </td>
            <td class="tdcls" colspan="2">
                <asp:TextBox ID="txtNativePlaceStaffDetails" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>--%>
        </tr>
        <tr>
            <td class="subhead">
                Home Town
            </td>
            <td>
                <asp:TextBox ID="txtHomeTownStaffDetails" runat="server"></asp:TextBox>
            </td>
            <td class="subhead">
                Physically Challenged <font color="red"><sup>*</sup></font>
            </td>
            <td>
                <asp:DropDownList ID="ddlPhysicallyChallangedStaffDetails" runat="server" CssClass="ddlcls"
                    Width="154px">
                    <asp:ListItem>Select</asp:ListItem>
                    <%-- <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Caste <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td class="tdcls">
                <asp:DropDownList ID="ddlcasteStaffDetails" runat="server" CssClass="ddlcls" Width="154px">
                </asp:DropDownList>
            </td>
            <td class="subhead" colspan="1">
                Martial Status <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlMartialStatusStaffDetails" runat="server" CssClass="ddlcls"
                    Width="154px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Mode Of AppointMent <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlModeofAppointMent" Width="154px">
                    <asp:ListItem Value="">Select </asp:ListItem>
                    <%--<asp:ListItem Value="Direct ">Direct</asp:ListItem>
                    <asp:ListItem Value="Persional Interest">Persional Interest</asp:ListItem>
                    <asp:ListItem Value="On Deceplinary Grounds">On Deceplinary Grounds</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead" colspan="4">
                Identification Marks :
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Mole1: <span style="font-size: 10px; color: Red">&nbsp;*</span>
            </td>
            <td class="tdcls">
                <asp:TextBox ID="txtIdentificationmole1StaffDetails" runat="server" Width="236px"
                    Height="27px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Mole2 :
            </td>
            <td>
                <asp:TextBox ID="txtIdentificationMole2" runat="server" Width="236px" Height="27px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4">
                RECRUITMENT INFORMATION
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Name Of The Post<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtPostNameStaffDetails" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
            <td class="subhead">
                Cader<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td class="tdcls">
                <asp:DropDownList ID="ddlCaderStaffDetails" runat="server" CssClass="ddlcls" Width="154px">
                    <asp:ListItem Value="">Select </asp:ListItem>
                    <%-- <asp:ListItem Value="PGT ">P.G.T </asp:ListItem>
                    <asp:ListItem Value="TGT">T.G.T</asp:ListItem>
                    <asp:ListItem Value="PRC">Principal</asp:ListItem>
                    <asp:ListItem Value="VP">Vice Principal</asp:ListItem>
                    <asp:ListItem Value="MIS">Miscellinious</asp:ListItem>
                    <asp:ListItem Value="G4">Grade4</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Type Of Post <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlTypeofPostStaffDetails" runat="server" CssClass="ddlcls"
                    Width="154px">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <%--<asp:ListItem Value="TV">Training Vacation</asp:ListItem>
                    <asp:ListItem Value="TN">Training Non Vacation</asp:ListItem>
                    <asp:ListItem Value="NV">Non Training Vacation</asp:ListItem>
                    <asp:ListItem Value="NN">Non Training Non Vacation</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td class="subhead" nowrap>
                Sanction Of Post<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td class="tdcls">
                <asp:DropDownList ID="ddlSanctionofpostStaffDetails" runat="server" CssClass="txtcls"
                    Width="154px">
                    <asp:ListItem>Select</asp:ListItem>
                    <%-- <asp:ListItem Value="Planned">Planned</asp:ListItem>
                    <asp:ListItem Value="Non Planned">NonPlanned</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Basic Pay + Grade Pay<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtBasicPayGradePayStaffDetails" runat="server" CssClass="txtcls"
                    MaxLength="9"></asp:TextBox>
            </td>
            <td class="subhead" nowrap>
                Date Of Joining <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td class="tdcls">
                <asp:TextBox ID="txtDateofJoiningInJNVStaffDetails" runat="server" CssClass="txtcls"></asp:TextBox>
                <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16" id="imgcal5">--%>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                    Width="16" ID="imgcal5" />
                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtDateofJoiningInJNVStaffDetails"
                    PopupButtonID="imgcal5" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Date Of&nbsp;&nbsp;<span style="font-size: 10px; color: Red">*</span> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlDateofStaffDetails" runat="server">
                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                    <asp:ListItem Value="1">Retirement</asp:ListItem>
                    <asp:ListItem Value="2">Suspension</asp:ListItem>
                    <asp:ListItem Value="3">Resignation</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="tdcls" nowrap>
                <asp:TextBox ID="txtDateOfStaffDetails" runat="server" CssClass="txtcls" MaxLength="9"></asp:TextBox>
                <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                    id="imgcal3">--%>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                    Width="16" ID="imgcal3" />
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDateOfStaffDetails"
                    PopupButtonID="imgcal3" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
            <td class="subhead" nowrap>
                Years Of Experience <span style="font-size: 10px; color: Red">*</span>&nbsp;
            </td>
            <td class="tdcls">
                <asp:TextBox ID="txtYearsOfExperianceStaffDetails" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead" nowrap>
                Date of Initial Joining<span style="font-size: 10px; color: Red">*</span>
            </td>
            <td class="tdcls">
                <asp:TextBox ID="txtDateofInitialjoinginJNVSStaffDetails" runat="server" CssClass="txtcls"></asp:TextBox>
                <%-- <img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                    id="imgcal6">--%>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                    Width="16" ID="imgcal6" />
                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDateofInitialjoinginJNVSStaffDetails"
                    PopupButtonID="imgcal6" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
            <td class="subhead">
                Discharge of Terminal Benefits<span style="font-size: 10px; color: Red">*</span>&nbsp;
            </td>
            <td nowrap>
                <asp:CheckBox ID="chkPFStaffDetails" runat="server" Text="PF" />
                &nbsp;&nbsp;
                <asp:CheckBox ID="chkLICStaffDetails" runat="server" Text="LIC" />
                &nbsp;&nbsp;
                <asp:CheckBox ID="chkGratuityStaffDetails" runat="server" Text="Gratuity" />
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Nominee <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td class="tdcls">
                <asp:TextBox ID="txtNomineeStaffDetails" runat="server"></asp:TextBox>
            </td>
            <td class="subhead">
                GSLIS Record No
            </td>
            <td>
                <asp:TextBox ID="txtGSLIS" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                GPF/CPF A/c No: <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td class="tdcls">
                <asp:TextBox ID="txtGpfaccountstaffDetails" runat="server"></asp:TextBox>
            </td>
            <td class="subhead">
                Certificate Submitted
            </td>
            <td>
                <asp:RadioButton ID="rbtnMedicalYes" runat="server" Text="Yes" GroupName="Medical Certificate " />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbtnMedicalNo" runat="server" Text="No" GroupName="Medical Certificate " />
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
                CONTACT INFORMATION
            </td>
        </tr>
        <tr>
            <td class="subhead" nowrap>
                Permanent Address<span style="font-size: 10px; color: Red"> *</span>
            </td>
            <td class="tdcls">
                <asp:TextBox ID="txtPerminantAddress" runat="server" CssClass="txtcls" TextMode="MultiLine"
                    Height="49px" Width="153px"></asp:TextBox>
            </td>
            <td class="subhead">
                Present Address <span style="font-size: 10px; color: Red">*</span>
            </td>
            <td class="tdcls">
                <asp:TextBox ID="txtPresentAddress" runat="server" CssClass="txtcls" TextMode="MultiLine"
                    Height="49px" Width="153px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Telephone&nbsp;<%--<span style="font-size: 10px; color: Red"> *</span>--%>
            </td>
            <td class="tdcls">
                <asp:TextBox ID="txtTelephone" runat="server" CssClass="txtcls" MaxLength="15"></asp:TextBox>
            </td>
            <td class="subhead">
                Mobile<span style="font-size: 10px; color: Red">*</span>&nbsp;
            </td>
            <td class="tdcls">
                <asp:TextBox ID="txtMobile" runat="server" CssClass="txtcls" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4" style="height: 17px">
                QUALIFICATION
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="heading" width="20%">
                            NAME OF THE DEGREE
                        </td>
                        <td class="heading" width="20%">
                            SUBJECT
                        </td>
                        <td class="heading" width="20%">
                            NAME OF THE UNIVERSITY
                        </td>
                        <td class="heading" width="20%">
                            YEAR OF PASSING
                        </td>
                        <td class="heading" width="20%">
                            PERCENTAGE
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="tdcls" width="20%" align="center">
                            <asp:DropDownList ID="ddlDegree1StaffDetails" runat="server" CssClass="txtcls" Width="154px">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:DropDownList ID="ddlSubject1StaffDetails" runat="server" CssClass="txtcls" Width="154px">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" style="text-align: center" width="20%" align="center">
                            <asp:TextBox ID="txtUniversity1StaffDetails" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:DropDownList ID="ddlPassingYear1StaffDetails" runat="server" CssClass="txtcls"
                                Width="154px">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:TextBox ID="txtPersent1StaffDetails" runat="server" CssClass="txtcls" MaxLength="5"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="tdcls" width="20%" align="center">
                            <asp:DropDownList ID="ddlDegree2StaffDetails" runat="server" CssClass="txtcls" Width="154px">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" valign="top" width="20%" align="center">
                            <asp:DropDownList ID="ddlSubject2StaffDetails" runat="server" CssClass="txtcls" Width="154px">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" style="text-align: center" width="20%" align="center">
                            <asp:TextBox ID="txtUniversity2StaffDetails" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:DropDownList ID="ddlPassingYear2StaffDetails" runat="server" CssClass="txtcls"
                                Width="154px">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:TextBox ID="txtPersent2StaffDetails" runat="server" CssClass="txtcls" MaxLength="5"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="tdcls" width="20%" align="center">
                            <asp:DropDownList ID="ddlDegree3StaffDetails" runat="server" CssClass="txtcls" Width="154px">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:DropDownList ID="ddlSubject3StaffDetails" runat="server" CssClass="txtcls" Width="154px">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" style="text-align: center;" width="20%" align="center">
                            <asp:TextBox ID="txtUniversity3StaffDetails" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:DropDownList ID="ddlPassingYear3StaffDetails" runat="server" CssClass="txtcls"
                                Width="154px">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="tdcls" width="20%" align="center">
                            <asp:TextBox ID="txtPersent3StaffDetails" runat="server" CssClass="txtcls" MaxLength="5"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4">
                FAMILY DETAILS
            </td>
        </tr>
        <tr>
            <td class="heading" width="25%">
                <p align="center">
                    &nbsp;</p>
            </td>
            <td class="heading" width="25%">
                <p align="center">
                    SPOUSE</p>
            </td>
            <td class="heading" width="25%">
                <p align="center" style="text-align: center">
                    CHILDREN</p>
            </td>
            <td class="heading" width="25%">
                <p align="center">
                    PARENTS</p>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Name <span style="font-size: 10px; color: Red">*</span>&nbsp;
            </td>
            <asp:Panel ID="pnlSpouseName" runat="server">
                <td class="tdcls" align="center">
                    <asp:TextBox ID="txtSpouseNameStaffDetails" runat="server" MaxLength="50"></asp:TextBox>
                </td>
            </asp:Panel>
            <td class="tdcls" style="text-align: center">
                <asp:TextBox ID="txtNameChildrenStaffDetails" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            <td class="tdcls" align="center">
                <asp:TextBox ID="txtParentsNameStaffDetails" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Contact No<span style="font-size: 10px; color: Red">*</span>&nbsp;
            </td>
            <asp:Panel ID="pnlSPouseContact" runat="server">
                <td class="tdcls" valign="top" align="center">
                    <asp:TextBox ID="txtSpouseContectNoStaffDetails" runat="server" MaxLength="20"></asp:TextBox>
                </td>
            </asp:Panel>
            <td class="tdcls" valign="top" style="text-align: center">
                <asp:TextBox ID="txtcontactChiStaffDetails" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            <td class="tdcls" valign="top" align="center">
                <asp:TextBox ID="txtParentsContectNoStaffDetails" runat="server" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td class="subhead">
                Place<span style="font-size: 10px; color: Red">*</span>
            </td>
            <asp:Panel ID="pnlSpousePlace" runat="server">
                <td class="tdcls" align="center">
                    <asp:TextBox ID="txtSPlaceStaffDetails" runat="server"></asp:TextBox>
                </td>
            </asp:Panel>
            <td class="tdcls" style="text-align: center">
                <asp:TextBox ID="txtChildrenPlaceStaffDetails" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            <td class="tdcls" align="center">
                <asp:TextBox ID="txtParentsPlaceStaffDetails" runat="server" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Employee Status<span style="font-size: 10px; color: Red"> *</span>&nbsp;
            </td>
            <asp:Panel ID="pnlSpouseStatus" runat="server">
                <td class="tdcls" align="center">
                    <asp:TextBox ID="txtSEmpStatusStaffDetails" runat="server"></asp:TextBox>
                </td>
            </asp:Panel>
            <td class="tdcls" style="text-align: center">
                <asp:TextBox ID="txtChildrenEmpstatusStaffDetails" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            <td class="tdcls" align="center">
                <asp:TextBox ID="txtParentsEmpStatusStaffDetails" runat="server" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" height="1%" valign="top">
                <!-- Here we start displaying the button table -->
                &nbsp;
                <table align="center" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Button ID="btnSaveStaffDetails" runat="server" CssClass="btncls" Text="Save"
                                Width="56px" OnClick="btnSaveStaffDetails_Click" />
                            &nbsp;&nbsp;
                            </td>
                    </tr>
                </table>
                <!-- end of displaying the button table -->
            </td>
        </tr>
    </table>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
