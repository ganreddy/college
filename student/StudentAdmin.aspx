<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="StudentAdmin.aspx.cs" Inherits="StudentModule_StudentAdmin" Title="Student Admission" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/jscript" language="javascript">
    function ResetForm()
    {
     document.forms[0].reset();
     return false;   
    }
    function AddPhoto(UploadID,ImageID)
    {
      var path=document.getElementById(UploadID).value;
      document.getElementById(ImageID).src=path;
  }
  
    
    function RequiredValidate()
    {
        if (!isEmpty('<%=txtAdmissionNo.ClientID%>', "Please Enter Student Admission Number")) return false;
        if (!isEmpty('<%=txtHallTicket.ClientID%>', "Please Enter Hall Ticket Number")) return false;
        if (!isNumeric('<%=txtRank.ClientID%>', "Please Enter Rank")) return false;
        if (!isEmpty('<%=txtRegion.ClientID%>', "Please Enter Region")) return false;
        if (!isDateFormat('<%=txtAdmissionmDate.ClientID%>', "Please Enter Valid Admission Date ")) return false;
        if (!DropdownValidate('<%=ddlJoinType.ClientID%>', "Please Select Joining Type")) return false;
        if (!DropdownValidate('<%=ddlYear.ClientID%>', "Please Select Year")) return false;
        if (!isEmpty('<%=ddlHouseAlloted.ClientID%>', "Please Enter House Alloted")) return false;
     if (!isEmpty('<%=txtfullname.ClientID%>', "Please Enter Full Name")) return false;
     if (!isEmpty('<%=txtdob.ClientID%>', "Please Enter Date Of Birth")) return false;
     if (document.getElementById('<%=txtdob.ClientID%>').value != "") {
         if (!isDateFormat('<%=txtdob.ClientID%>', "Date of Birth should be DD/MM/YYYY")) return false;
     }
     if(! DropdownValidate('<%=ddlMotherTounge.ClientID%>',"Please Select Mother Tongue"))return false;
     var male=document.getElementById('<%=rbmale.ClientID%>').checked;
     var female=document.getElementById('<%=rbfemale.ClientID%>').checked;
     if((male==false)&& (female==false))
     {
     alert("Please Choose One Radio Button (Male or Female)");
     return false;
     }
     var Urban=document.getElementById('<%=rbtnUrban.ClientID%>').checked;
     var Rural=document.getElementById('<%=rbtnRural.ClientID%>').checked;
     if((Urban==false)&&(Rural==false))
     {
     alert("Please Choose One Radio Button (Urban or Rural)");
     return false;
     }
     if (!isEmpty('<%=txtMandal.ClientID%>', "Please Enter Mandal")) return false;
     if (!isEmpty('<%=txtNationality.ClientID%>', "Please Enter Nationality")) return false;
     if(! DropdownValidate('<%=ddlstate.ClientID%>',"Please Select State"))return false;
     
     if(! DropdownValidate('<%=ddlPhysicallyChallanged.ClientID%>',"Please Select Whether Physically Challenged"))return false;
     if(! DropdownValidate('<%=ddlcaste.ClientID%>',"Please Select Caste"))return false;
     
     if(!isEmpty('<%=txtMoles1.ClientID%>',"Please Enter Moles Identification1" ))return false;
     if (!DropdownValidate('<%=ddlECA.ClientID%>', "Please Select Extra Curricular Activity")) return false;

     if (!isEmpty('<%=txtfathername.ClientID%>', "Please Enter Father's Name")) return false;
     if (!isEmpty('<%=txtoccupation.ClientID%>', "Please Enter Father Occupation")) return false;
     if(!isEmpty('<%=txtaddr1.ClientID%>',"Please Enter Address1" ))return false;
    
      if(! DropdownValidate('<%=ddlFatherAnnualIncome.ClientID%>',"Please Select Fathers Annual Income"))return false;
     
     
     if(!isEmpty('<%=txtteloffice.ClientID%>',"Please Enter Telephone No" ))return false;
     if(document.getElementById('<%=txtteloffice.ClientID%>').value!="")
         {
            if(!ChkPhoneNum('<%=txtteloffice.ClientID%>',"Please Enter Valid Telephone No" ))return false;
         }
     
      if(!isEmpty('<%=txtPrevSchool1.ClientID%>',"Please Enter Pevious School Name" ))return false;
     
     
     
     if(!isEmpty('<%=txtPrevSchoolTc.ClientID%>',"Please Enter Previous School TC No" ))return false;
     if(!isDateFormat('<%=txtTcDate.ClientID%>',"Please Enter Valid TC Date" ))return false;
//     if(!isEmpty('<%=txtJnvIssue.ClientID%>',"Please Enter the TCIssuedByJNV" ))return false;
//     
     if(!isDateFormat('<%=txtFrom1.ClientID%>',"Please Enter Valid From Date " ))return false;
     if(!isDateFormat('<%=txtTo1.ClientID%>',"Please Enter Valid To Date" ))return false;
     if(! DropdownValidate('<%=ddlMed1.ClientID%>',"Please Select Medium"))return false;
     if(!isEmpty('<%=txtrem1.ClientID%>',"Please Enter Board Name" ))return false;
     
     
     
    // if(!isDateFormat('<%=txtDateOfIssue.ClientID%>',"Please Enter the Date Of Issue of dd/MM/yyyy Format" ))return false;
     if(document.getElementById('<%=txtTcDate.ClientID%>').value!="")
     {
       if(!isDateFormat('<%=txtTcDate.ClientID%>',"Please Enter Valid From Date DD/MM/YYYY" ))return false;
     }
     
     if(document.getElementById('<%=txtFrom1.ClientID%>').value!="")
     {
       if(!isDateFormat('<%=txtFrom1.ClientID%>',"Please Enter Valid From Date DD/MM/YYYY" ))return false;
     }
     if(document.getElementById('<%=txtTo1.ClientID%>').value!="")
     {
       if(!isDateFormat('<%=txtTo1.ClientID%>',"Please Enter Valid TO Date DD/MM/YYYY" ))return false;
     }
     if(document.getElementById('<%=txtFrom2.ClientID%>').value!="")
     {
       if(!isDateFormat('<%=txtFrom2.ClientID%>',"Please Enter Valid From Date DD/MM/YYYY" ))return false;
     }
     if(document.getElementById('<%=txtto2.ClientID%>').value!="")
     {
       if(!isDateFormat('<%=txtto2.ClientID%>',"Please Enter Valid TO Date DD/YY/YYYY" ))return false;
     }
     if(document.getElementById('<%=txtFrom3.ClientID%>').value!="")
     {
       if(!isDateFormat('<%=txtFrom3.ClientID%>',"Please Enter Valid From Date DD/MM/YYYY" ))return false;
     }
     if(document.getElementById('<%=txtto3.ClientID%>').value!="")
     {
       if(!isDateFormat('<%=txtto3.ClientID%>',"Please Enter Valid TO Date DD/MM/YYYY" ))return false;
     }
     
     if(! DropdownValidate('<%=ddlClass.ClientID%>',"Please Select Branch"))return false;
     if(! DropdownValidate('<%=ddlBatch.ClientID%>',"Please Select Batch"))return false;
     if(! DropdownValidate('<%=ddlSection.ClientID%>',"Please Select Section"))return false;
     
     if(!isEmpty('<%=txtRollNo.ClientID%>',"Please Enter Roll Number" ))return false;
     
    }
    
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
   <%-- <asp:UpdatePanel ID="updStudAdmis" runat="server">
    <ContentTemplate>--%>
    <table align="center" border="0" cellpadding="1" cellspacing="1" class="maintblcls1"
        style="width: 90%; height: 147%">
        <tr align="center">
            <td style="text-align: center" class="heading" colspan="4">
                <strong>STUDENT ADMISSION</strong>
            </td>
        </tr>
        <tr class="tdcls">
            <td colspan="4" valign="top">
                <table cellpadding="1" cellspacing="1" width="100%">
                    <!---- Display for Error Messages ---------->
                    <tr class="tdcls">
                        <td align="right" colspan="6" style="width: 20%">
                            <font color="red"><b>Note:</b></font> All fields marked <font color="red"><sup>*</sup></font>
                            are mandatory
                        </td>
                    </tr>
                    <tr align="right">
                        <td colspan="2" style="width: 20%" id="TD1" runat="server" align="center">
                            <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
                            <%--<asp:UpdateProgress ID="upImage" runat="server" AssociatedUpdatePanelID="updStudAdmis">
                            <ProgressTemplate>
                            <asp:Image  runat="server" ID="imgUpd" ImageUrl="~/images/update.gif"/>
                            </ProgressTemplate>
                            </asp:UpdateProgress>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr>
            <td class="heading" colspan="4" valign="top">
                <strong>ADMISSION</strong>
            DETAILS
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td class="tdcls" colspan="4" style="width: 20%" valign="top" align="center">
            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" valign="top">
                <table border="0" width="100%">
                    <tr>
                        <td class="subhead" width="57%" valign="top">
                            Admission No <span style="color: #ff0000">*</span>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtAdmissionNo" runat="server" CssClass="txtcls" 
                                ontextchanged="txtAdmissionNo_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" width="57%" valign="top">
                            Hall Ticket No<span style="color: #ff0000">*</span>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtHallTicket" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" width="57%" valign="top">
                            Rank<span style="color: #ff0000">*</span>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtRank" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" width="57%" valign="top">
                            Region<span style="color: #ff0000">*</span>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtRegion" runat="server" CssClass="txtcls"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    <td class="subhead" style="width: 20%" valign="top">
                Joining Type<span style="color: #ff0000">*</span>
            </td>
                        <td class="tdcls" style="width: 30%" valign="top">
                <asp:DropDownList ID="ddlJoinType" runat="server" CssClass="ddlcls" Width="154px"
                    Height="16%">
                    
                </asp:DropDownList>
            </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Admission Date
                        </td>
                        <td nowrap>
                            <asp:TextBox ID="txtAdmissionmDate" runat="server"></asp:TextBox>
                            <asp:ImageButton  runat="server" ID="Img1" alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"/>
                            <asp:CalendarExtender ID="CalendarExtender10" runat="server" PopupButtonID="Img1"
                                TargetControlID="txtAdmissionmDate" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Year Of Admission<span style="color: #ff0000">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlYear" runat="server" Width="154px"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top" width="40%" class="subhead">
                Student Photo
            </td>
            <td align="left">
                <asp:Image ID="imgStud" runat="server" Height="100px" Width="80px" ImageUrl="~/images/images.jpg" /><br />
                <asp:FileUpload ID="fudStudent" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="subhead"  valign="top">
                Hostel/House Name
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <%--<asp:TextBox ID="txtHouseAlloted" runat="server"></asp:TextBox>--%>
                <asp:DropDownList ID="ddlHouseAlloted" runat="server" CssClass="txtcls" Width="154px"
                Height="16%">
                <asp:ListItem Value="0">---Select---</asp:ListItem>
                <asp:ListItem Value="1">Days Scholar</asp:ListItem>
                <asp:ListItem Value="2">Hostel</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4" valign="top">
                PERSONAL DETAILS
            </td>
        </tr>
        <tr>
            <td class="subhead" width="40%" valign="top">
                Full Name <span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:TextBox ID="txtfullname" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
            <td class="subhead" valign="top" width="40%">
                Date of Birth <span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" valign="top" width="20%">
                <asp:TextBox ID="txtdob" runat="server" CssClass="txtcls"></asp:TextBox>
                <asp:ImageButton runat="server" id="image1" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                    width="16"/>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="image1"
                    TargetControlID="txtdob" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="subhead" width="30%" valign="top">
                Mother Tounge<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" width="20%" valign="top">
                <asp:DropDownList ID="ddlMotherTounge" runat="server" CssClass="ddlcls" Width="154px"
                    Height="16%">
                </asp:DropDownList>
            </td>
            <td class="subhead" valign="top">
                <span style="color: black;">Gender</span><span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 20%" valign="top">
                <asp:RadioButton ID="rbmale" runat="server" class="subhead" ForeColor="Black" GroupName="rbgender"
                    Text="Male" />&nbsp;
                <asp:RadioButton ID="rbfemale" runat="server" class="subhead" ForeColor="Black" GroupName="rbgender"
                    Text="Female" />
            </td>
        </tr>
        <tr>
            <td class="subhead" width="30%" valign="top">
                Urban / Rural
            </td>
            <td class="tdcls" width="20%" valign="top">
                <span style="vertical-align: super; color: #ff0000"><span style="">&nbsp;</span><asp:RadioButton
                    ID="rbtnUrban" runat="server" Checked="True" CssClass="subhead" ForeColor="Black"
                    GroupName="rburban" Text="Urban" />&nbsp;
                    <asp:RadioButton ID="rbtnRural" runat="server" CssClass="subhead" ForeColor="Black"
                        GroupName="rburban" Text="Rural" /></span>
            </td>
            <td class="subhead" width="20%" valign="top">
                <span style="color: black">Mandal <span style="color: #ff0000">*</span></span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtMandal" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead" width="30%" valign="top">
                Nationality <span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" width="20%" valign="top">
                <asp:TextBox ID="txtNationality" runat="server"></asp:TextBox>
            </td>
            <td class="subhead" valign="top">
                <span><span style="font-size: 9pt"><span style="">State<span style="color: #ff0000">*</span></span></span></span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:DropDownList ID="ddlstate" runat="server" CssClass="ddlcls" Width="154px" Height="16%">
                    <asp:ListItem Value="1">Andhra Pradesh</asp:ListItem>
                    <asp:ListItem Value="2">Karnataka</asp:ListItem>
                    <asp:ListItem Value="3">Maharashtra</asp:ListItem>
                    <asp:ListItem Value="4">Tamilanadu</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td class="subhead" width="30%" valign="top">
                Religion
            </td>
            <td class="tdcls" width="20%" valign="top">
                <asp:TextBox ID="txtreligion" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Blood Group<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:DropDownList ID="ddlBloodGroup" runat="server" CssClass="ddlcls" Width="154px"
                    Height="16%">
                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                    <asp:ListItem Value="1">O+</asp:ListItem>
                    <asp:ListItem Value="2">O-</asp:ListItem>
                    <asp:ListItem Value="3">A+</asp:ListItem>
                    <asp:ListItem Value="4">A-</asp:ListItem>
                    <asp:ListItem Value="5">B+</asp:ListItem>
                    <asp:ListItem Value="6">B-</asp:ListItem>
                    <asp:ListItem Value="7">AB+</asp:ListItem>
                    <asp:ListItem Value="8">AB-</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead" width="30%" valign="top">
                Physically Challenged<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" width="20%" valign="top">
                <asp:DropDownList ID="ddlPhysicallyChallanged" runat="server" CssClass="ddlcls" Width="154px"
                    Height="16%">
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="subhead" style="width: 30%" valign="top">
                Caste<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 20%" valign="top">
                <asp:DropDownList ID="ddlcaste" runat="server" CssClass="ddlcls" Width="154px" Height="16%">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead" width="30%" valign="top">
                Moles Identification1<span style="color: #ff0000">*</span>
            </td>
            <td width="20%">
                <asp:TextBox ID="txtMoles1" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Moles Identification2
            </td>
            <td style="width: 30%">
                <asp:TextBox ID="txtMoles2" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead" width="20%" valign="top">
                Extra Curriculum Activities<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" width="20%" valign="top">
                <asp:DropDownList ID="ddlECA" runat="server" CssClass="txtcls" Width="154px">
                </asp:DropDownList>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Games Played
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtGamesPlayed" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead" style="width: 20%" valign="top">
                Email ID
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4" valign="top">
                CONTACT INFORMATION
            </td>
        </tr>
        <tr>
            <td class="subhead" width="20%" valign="top">
                Parent's / Guardian's Name <span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" width="20%" valign="top">
                <asp:TextBox ID="txtfathername" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Occupation<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtoccupation" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
            <%--<td class="subhead" style="width: 20%" valign="top">
                Mother's Name <span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtMotherName" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>--%>
        </tr>
        <%--<tr>
            <td class="subhead" style="width: 20%; height: 87px;" valign="top">
                Father's Photo
            </td>
            <td style="width: 20%; height: 87px;">
                <asp:Image ID="imgFather" runat="server" Height="100px" Width="80px" ImageUrl="~/images/images.jpg" /><br />
                <asp:FileUpload ID="fudFatherPhoto" runat="server" Width="154px" />
            </td>
            <td class="subhead" style="width: 20%; height: 87px;" valign="top">
                Mother's Photo
            </td>
            <td style="width: 20%; height: 87px;">
                <asp:Image ID="imgMother" runat="server" Height="100px" Width="80px" ImageUrl="~/images/images.jpg" /><br />
                <asp:FileUpload ID="fudMother" runat="server" Width="154px" />
            </td>
        </tr>--%>
        <tr>
            <td class="subhead" style="width: 20%" valign="top">
                Address 1 <span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtaddr1" runat="server" CssClass="txtcls" TextMode="MultiLine"
                    Width="154px"></asp:TextBox>
            </td>
             <td class="subhead" style="width: 20%" valign="top">
                Annual Income<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
             
              <asp:DropDownList ID="ddlFatherAnnualIncome" runat="server" CssClass="txtcls" Width="154px"
                    Height="16%">
                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                    <asp:ListItem Value="1">3000-6000</asp:ListItem>
                    <asp:ListItem Value="2">6000-12000</asp:ListItem>
                    <asp:ListItem Value="3">12000-18000</asp:ListItem>
                    <asp:ListItem Value="4">18000-24000</asp:ListItem>
                    <asp:ListItem Value="5">24000-30000</asp:ListItem>
                    <asp:ListItem Value="6">30000-36000</asp:ListItem>
                    <asp:ListItem Value="7">36000-50000</asp:ListItem>
                    <asp:ListItem Value="8">50000&amp; Above</asp:ListItem>
                    
                    </asp:DropDownList>
            </td>
            <%--<td class="subhead" style="width: 20%" valign="top">
                Address 2
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtAddress2" runat="server" CssClass="txtcls" TextMode="MultiLine"
                    Width="154px"></asp:TextBox>
            </td>--%>
        </tr>
        <tr>
            <td class="subhead" style="width: 20%" valign="top">
                Qualification
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:DropDownList ID="ddlQualFather" runat="server" CssClass="txtcls" Width="154px" Height="16%">
                <asp:ListItem Value="0">---Select---</asp:ListItem>
                <asp:ListItem Value="1">Illiterate</asp:ListItem>
                <asp:ListItem Value="2">Middle</asp:ListItem>
                <asp:ListItem Value="3">HighSchool</asp:ListItem>
                <asp:ListItem Value="4">Graduate</asp:ListItem>
                <asp:ListItem Value="5">PostGraduate</asp:ListItem>
                <asp:ListItem Value="6">UnderGraduate</asp:ListItem>
                    
                </asp:DropDownList>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Telephone (Office) <span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtteloffice" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
            <%--<td class="subhead" style="width: 20%" valign="top">
                Qualification
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:DropDownList ID="ddlQualMother" runat="server" CssClass="txtcls" Width="154px"
                    Height="16%">
                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                <asp:ListItem Value="1">Illiterate</asp:ListItem>
                <asp:ListItem Value="2">Middle</asp:ListItem>
                <asp:ListItem Value="3">HighSchool</asp:ListItem>
                <asp:ListItem Value="4">Graduate</asp:ListItem>
                <asp:ListItem Value="5">PostGraduate</asp:ListItem>
                <asp:ListItem Value="6">UnderGraduate</asp:ListItem>
                </asp:DropDownList>
            </td>--%>
        </tr>
        <tr>
            
           <%-- <td class="subhead" style="width: 20%" valign="top">
                Occupation
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtOccupationMother" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>--%>
        </tr>
        <tr>
           
           <%-- <td class="subhead" style="width: 20%" valign="top">
                Annual Income
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
               
                 <asp:DropDownList ID="ddlMotherAnnualIncome" runat="server" CssClass="txtcls" Width="154px"
                    Height="16%">
                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                    <asp:ListItem Value="1">3000-6000</asp:ListItem>
                    <asp:ListItem Value="2">6000-12000</asp:ListItem>
                    <asp:ListItem Value="3">12000-18000</asp:ListItem>
                    <asp:ListItem Value="4">18000-24000</asp:ListItem>
                    <asp:ListItem Value="5">24000-30000</asp:ListItem>
                    <asp:ListItem Value="6">30000-36000</asp:ListItem>
                    <asp:ListItem Value="7">36000-50000</asp:ListItem>
                    <asp:ListItem Value="8">50000&amp; Above</asp:ListItem>
                    </asp:DropDownList>
            </td>--%>
        </tr>
        <tr>
            
            <%--<td class="subhead" style="width: 20%" valign="top">
                Telephone (Resi)
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtPhoneMother" runat="server" CssClass="txtcls"></asp:TextBox>
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
        </tr>
        <tr>
            <td class="subhead" style="width: 20%" valign="top">
                Guardian Name<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtguardname" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Address<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtguardaddress" runat="server" CssClass="txtcls" TextMode="MultiLine"
                    Width="154px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead" style="width: 20%" valign="top">
                Guardian's Photo
            </td>
            <td style="width: 20%">
                <asp:Image ID="imgGuardian" runat="server" Height="100px" Width="80px" ImageUrl="~/images/images.jpg" /><br />
                <asp:FileUpload ID="fudGuardian" runat="server" Width="154px" />
            </td>
        </tr>
        <tr>
            <td class="subhead" valign="top" style="width: 20%">
                Telephone<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtguardtel" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Mobile<sMobile
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtguardmobile" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
        </tr>--%>
        <tr style="font-size: 12pt">
            <td class="heading" colspan="4" style="width: 20%" valign="top">
                PAST EDUCATION HISTORY      </td>
        </tr>
        <tr style="font-size: 12pt">
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="heading" valign="top" style="width: 20%">
                            <p align="center">
                                PREVIOUS COLLEGE NAME</p>
                        </td>
                        <td class="heading" style="width: 20%" valign="top">
                            <p align="center">
                                FROM</p>
                        </td>
                        <td class="heading" style="width: 20%" valign="top">
                            <p align="center">
                                TO</p>
                        </td>
                        <td class="heading" style="width: 20%" valign="top">
                            <p align="center">
                                MEDIUM</p>
                        </td>
                        <td class="heading" style="width: 20%" valign="top">
                            <p align="center">
                                BOARD NAME</p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="font-size: 12pt">
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
                                <asp:ImageButton runat="server" id="FromImage1" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                    width="16"/>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="FromImage1"
                                    TargetControlID="txtFrom1" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </p>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top" nowrap>
                            <p>
                                <asp:TextBox ID="txtTo1" runat="server" CssClass="txtcls"></asp:TextBox>
                                <asp:ImageButton runat="server" id="ToImage1" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                    width="16"/>
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
                                <asp:ImageButton runat="server" id="Fromimage2" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                    width="16"/>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="Fromimage2"
                                    TargetControlID="txtFrom2" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </p>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top" nowrap>
                            <p>
                                <asp:TextBox ID="txtto2" runat="server" CssClass="txtcls"></asp:TextBox>
                                <asp:ImageButton runat="server" id="ToImage2" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                    width="16"/>
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
                                <asp:ImageButton runat="server" id="FromImage3" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                    width="16"/>
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" PopupButtonID="FromImage3"
                                    TargetControlID="txtFrom3" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </p>
                        </td>
                        <td class="tdcls" style="width: 20%" valign="top" nowrap>
                            <p>
                                <asp:TextBox ID="txtto3" runat="server" CssClass="txtcls"></asp:TextBox>
                                <asp:ImageButton runat="server" id="ToImage3" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                                    width="16"/>
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
        </tr>
        <tr style="font-size: 12pt">
            <td class="subhead" style="width: 20%" valign="top">
                Previous Institution TC No.<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <span>
                    <asp:TextBox ID="txtPrevSchoolTc" runat="server" CssClass="txtcls"></asp:TextBox></span>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                TC Issued Date<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtTcDate" runat="server" CssClass="txtcls"></asp:TextBox>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                    id="imgTCDate"/>
                <asp:CalendarExtender ID="CalendarExtender8" runat="server" PopupButtonID="imgTCDate"
                    TargetControlID="txtTcDate" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <asp:Panel ID="pnltc" runat="server" Visible="false">
        <tr>
            <td class="subhead" style="width: 20%" valign="top">
                TC Issued By JNV </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtJnvIssue" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Date Of Issue
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtDateOfIssue" runat="server" CssClass="txtcls"></asp:TextBox>
                <asp:ImageButton runat="server" src="../images/cal.gif" style="width: 16px; height: 16px" id="imgDateofIssue" />
                <asp:CalendarExtender ID="CalendarExtender9" runat="server" PopupButtonID="imgDateofIssue"
                    TargetControlID="txtDateOfIssue" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        </asp:Panel>
        <tr style="font-size: 12pt">
            <td class="heading" colspan="4" style="width: 20%" valign="top">
                ADMITTED IN      </td>
        </tr>
        <tr style="font-size: 12pt">
            <td class="subhead" style="width: 20%" valign="top">
                Branch<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:DropDownList ID="ddlClass" runat="server" CssClass="ddlcls" Width="154px" Height="16%">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem Selected="True">No</asp:ListItem>
                </asp:DropDownList>
            </td>
             <td class="subhead" style="width: 20%" valign="top">
                Section<span style="color: #ff0000">* </span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:DropDownList ID="ddlSection" runat="server" CssClass="txtcls" Width="154px"
                    Height="16%">
                </asp:DropDownList>
            </td>
            <asp:Panel ID="pnl" runat="server" Visible="false">
            <td class="subhead" style="width: 20%" valign="top" >
                Medium <span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top" >
                <asp:DropDownList ID="ddlMedium" runat="server" CssClass="ddlcls" Width="154px" Height="16%">
                </asp:DropDownList>
            </td>
            </asp:Panel>
            <%--<td class="subhead" rowspan="2" style="width: 20%" valign="top">
                <span style="vertical-align: super; color: #ff0000"></span>
                <br />
            </td>--%>
        </tr>
        <tr style="font-size: 12pt">
            <td class="subhead" style="width: 20%" valign="top">
                Batch<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <span>
                    <asp:DropDownList ID="ddlBatch" runat="server" Width="154px"></asp:DropDownList></span>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Roll No Alloted<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtRollNo" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>
            <%--<td class="subhead" style="width: 20%" valign="top">
                Alpha Code<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:TextBox ID="txtAlphaCode" runat="server" CssClass="txtcls"></asp:TextBox>
            </td>--%>
        </tr>
        <tr style="font-size: 12pt">
           <%-- <td class="subhead" style="width: 20%" valign="top">
                Group
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:DropDownList ID="ddlGroup" runat="server" Width="154px" Height="16%">
                </asp:DropDownList>
                &nbsp;
            </td>--%>
            
        </tr>
         <tr style="font-size: 12pt" id="trCurHead" runat="server">
            <td class="heading" colspan="4" style="width: 20%" valign="top">
                CURRENT STATUS
            </td>
        </tr>
        <tr style="font-size: 12pt" id="trCurBatch" runat="server">
            <td class="subhead" style="width: 20%" valign="top">
                Batch<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <span>
                    <asp:DropDownList ID="ddlCurBatch" runat="server" Width="154px">
                    <asp:ListItem>---Select---</asp:ListItem>
                    </asp:DropDownList>
                </span>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Branch<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:DropDownList ID="ddlCurClass" runat="server" CssClass="ddlcls" Width="154px" Height="16%">
                    <asp:ListItem>---Select---</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="font-size: 12pt" id="trCurSection" runat="server">
            <td class="subhead" style="width: 20%" valign="top">
                Section<span style="color: #ff0000">* </span>
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:DropDownList ID="ddlCurSection" runat="server" CssClass="txtcls" Width="154px"
                    Height="16%">
                    <asp:ListItem>---Select---</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="subhead" style="width: 20%" valign="top">
                Group
            </td>
            <td class="tdcls" style="width: 30%" valign="top">
                <asp:DropDownList ID="ddlCurGroup" runat="server" Width="154px" Height="16%">
                <asp:ListItem>---Select---</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
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
                            <asp:Button ID="btnsave" runat="server" CssClass="btncls" Text="Save" Width="56px"
                                OnClick="btnsave_Click" />
                            &nbsp;
                            <asp:Button ID="btnreset" runat="server" CssClass="btncls" Text="Reset" 
                                Width="54px" />
                        </td>
                    </tr>
                </table>
                <!-- end of displaying the button table -->
            </td>
        </tr>
    </table>
   <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    
</asp:Content>
