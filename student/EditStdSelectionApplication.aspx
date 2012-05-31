<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditStdSelectionApplication.aspx.cs" Inherits="student_EditStdSelectionApplication" Title="Edit Select Form" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="updStudAdmis" runat="server">
    <ContentTemplate>
    <table align="center" border="0" cellpadding="1" cellspacing="1" class="maintblcls1"
        style="width: 100%; height: 100%">
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
                            <asp:UpdateProgress ID="upImage" runat="server" AssociatedUpdatePanelID="updStudAdmis">
                            <ProgressTemplate>
                            <asp:Image  runat="server" ID="imgUpd" ImageUrl="~/images/update.gif"/>
                            </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr>
            <td class="heading" colspan="4" valign="top">
                ADMISSION DETAILS
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td class="tdcls" colspan="4" style="width: 20%" valign="top" align="center">
            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" valign="top" width="50%">
                <table border="0" width="100%">
                    <tr>
                        <td class="subhead"  valign="top">
                            Roll No: <span style="color: #ff0000">*</span>
                        </td>
                        <td valign="top"  align="left" >
                            <asp:Label ID="lblRollNo" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    
                </table>
            </td>
            <td align="left" valign="top"  class="subhead">
                Student Photo
            </td>
            <td align="left">
                <asp:Image ID="imgStud" runat="server" Height="100px" Width="80px" ImageUrl="~/images/images.jpg" /><br />
                <asp:FileUpload ID="fudStudent" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4" valign="top">
                PERSONAL DETAILS
            </td>
        </tr>
        <tr>
                       <td class="subhead" nowrap colspan="4" >
                            Name Of The Candidate(IN BLOCK LETTERS)
                        </td>
                    </tr>
                    <tr>
                        
                        <td nowrap CssClass="txtcls"  >
                             <span class="subhead"  color:"Black" >First Name:</span>
                            <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                        </td>
                        <td nowrap  width="33%" CssClass="txtcls">
                        <span class="subhead"  color:"Black" >Middle Name:
                            
                            </span>
                            <asp:Label ID="lblMiddleName" runat="server"></asp:Label>
                        </td>
                        <td nowrap class="subhead" width="33%">Last Name:<span style="color: #ff0000">*</span>
                            
                            
                        </td>
                        <td  ><asp:Label ID="lblLastName" runat="server"></asp:Label></td>
                    </tr>
        <tr>
            <td nowrap class="subhead">
                Category:<span style="color: #ff0000"> *</span>
            </td>
           <td nowrap >
                <asp:Label ID="lblCategory" runat="server" 
                   ></asp:Label>
                    
            </td>
            <td nowrap class="subhead">
                Date Of Birth:<span style="color: #ff0000">*</span>
            </td>
            <td nowrap >
                <asp:Label ID="lbldob" runat="server" CssClass="txtcls"></asp:Label>
                
            </td>
        </tr>
        <caption>
            <tr>
                <td class="subhead" valign="top" width="30%">
                    Nationality: <span style="color: #ff0000">*</span>
                </td>
                <td   valign="top" width="20%">
                    <asp:Label ID="lblNationality1" runat="server" ></asp:Label>
                </td>
                <td  valign="top" class="subhead">
                    <span><span style="font-size: 9pt"><span style="">Religion:<span 
                        style="color: #ff0000">*</span></span></span></span>
                </td>
                <td   style="width: 30%" valign="top">
                    <asp:Label ID="lblreligion1" runat="server" ></asp:Label>
                </td>
            </tr>
           
            <tr>
                <td class="subhead" nowrap>
                    Moles Identification1:<span style="color: #ff0000">*</span>
                </td>
                <td  nowrap>
                    <asp:Label ID="lblMoles1" runat="server" ></asp:Label>
                </td>
                <td class="subhead" nowrap>
                    Moles Identification2:
                </td>
                <td  nowrap>
                    <asp:Label ID="lblMoles2" runat="server" ></asp:Label>
                </td>
            </tr>
            <caption>
                <tr>
                    <td class="subhead" nowrap>
                        <span style="color: black;">Gender:</span>:<span style="color: #ff0000">*</span>
                    </td>
                    <td  nowrap>
                        <asp:Label ID="lblGender" runat="server" ></asp:Label>
                        
                    </td>
                    <td class="subhead" nowrap>
                        Urban / Rural:
                    <span style="color: #ff0000">*</span></td>
                    <td   style="height: 27px" valign="top" width="10%">
                        <span style="vertical-align: super; color: #ff0000">&nbsp;</span>
                        <asp:Label ID="lblUrbanRural" runat="server"  ></asp:Label>
                        
                    </td>
                </tr>
                <tr>
                    <td class="subhead" nowrap>
                        Disabled:
                    </td>
                    <td  nowrap >
                        <asp:Label ID="lblPH" runat="server" ></asp:Label>
                        
                        <asp:Label ID="lblVm" runat="server" ></asp:Label>
                        
                        <asp:Label ID="lblHI" runat="server" ></asp:Label>
                    </td>
                    <td class="tdcls" style="width: 20%" valign="top">
                    </td>
                </tr>
               
                <tr>
                    <td class="heading" colspan="4" valign="top">
                        CONTACT INFORMATION
                    </td>
                </tr>
                <tr>
                    <td class="subhead" nowrap>
                        Father's Name: <span style="color: #ff0000">*</span>
                    </td>
                    <td  nowrap>
                        <asp:Label ID="lblfathername" runat="server" ></asp:Label>
                    </td>
                    <td class="subhead" nowrap>
                        Mother's Name: <span style="color: #ff0000">*</span>
                    </td>
                    <td  nowrap>
                        <asp:Label ID="lblMotherName" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" nowrap>
                        Guardian Name
                    </td>
                    <td  nowrap>
                        <asp:Label ID="lblguardname" runat="server" ></asp:Label>
                    </td>
                    <td class="subhead" nowrap>
                        Relationship With Candidate:
                    </td>
                    <td  nowrap>
                        <asp:Label ID="lblRelvthguard" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" nowrap>
                        Persent Postal Address:
                    </td>
                    <td  nowrap>
                        <asp:Label ID="lblpresentadd" runat="server" ></asp:Label>
                    </td>
                    <td class="subhead" nowrap>
                        PIN Code:</td>
                    <td  nowrap>
                        <asp:Label ID="lblPincode1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" nowrap>
                        Permanent Address: <span style="color: #ff0000">*</span>
                    </td>
                    <td  nowrap>
                        <asp:Label ID="lblpremenentAdd1" runat="server" ></asp:Label>
                    </td>
                    <td class="subhead" nowrap>
                        PIN Code:<span style="color: #ff0000">*</span></td>
                    <td  nowrap>
                        <asp:Label ID="lblPinCode2" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" nowrap>
                        Telephone: <span style="color: #ff0000">*</span>
                    </td>
                    <td  nowrap>
                        <asp:Label ID="lbltelephone" runat="server" ></asp:Label>
                    </td>
                    <td class="subhead" nowrap>
                        E-Mail ID:</td>
                    <td  nowrap>
                        <asp:Label ID="lblEmailID" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td align="center" class="heading" colspan="4"  valign="top">
                        SCHOOL(s) FROM WHERE tHE CANDIDATE PASSED CLASS-III,IV AND IS STUDYING IN 
                        CLASS-V
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td colspan="4">
                        <table width="100%">
                            <tr>
                                <td align="center" class="heading" width="22%" nowrap>
                                    
                                </td>
                                <td align="center" class="heading" width="22%" nowrap>
                                    <p align="center" nowrap>
                                        Class - III</p>
                                </td>
                                <td align="center" class="heading" width="22%" nowrap>
                                    <p align="center">
                                        Class - IV</p>
                                </td>
                                <td align="center" class="heading" width="22%" nowrap>
                                    <p align="center">
                                        Class - V</p>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="subhead" nowrap>
                                    <p>
                                        Name Of The School &nbsp;:<span style="color: #ff0000">*</span></p>
                                </td>
                                <td align="center"  nowrap>
                                    <p>
                                        <asp:Label ID="lblNameoftheSchoolClassIII" runat="server" ></asp:Label>
                                    </p>
                                </td>
                                <td align="center"  nowrap>
                                    <p style="height: 20px; width: 115px">
                                        <asp:Label ID="LblNameoftheSchoolClassIV" runat="server" ></asp:Label>
                                    </p>
                                </td>
                                <td align="center"  nowrap>
                                    <asp:Label ID="lblNameoftheSchoolClassV" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="subhead" nowrap style="width: 240px">
                                    <p>
                                         Recognized School &nbsp;:<span style="color: #ff0000">*</span></p>
                                </td>
                                  <td align="center" style="height: 27px" valign="top" width="10%" nowrap>
                        <span style="vertical-align: super; color: #ff0000">&nbsp;</span>
                        <asp:Label ID="lblRecSchoolYesNoClassIII" runat="server"  ></asp:Label>
                        
                    </td>
                                 <td  style="height: 27px" valign="top" width="10%" align="center">
                        <span style="vertical-align: super; color: #ff0000">&nbsp;</span>
                        <asp:Label ID="lblRecSchoolYesNoClassIV" runat="server"  ></asp:Label>
                       
                    </td>
                               
                                 <td  style="height: 27px" valign="top" width="10%" align="center">
                        <span style="vertical-align: super; color: #ff0000">&nbsp;</span>
                        <asp:Label  ID="lblRecSchoolYesNoClassV" runat="server"  ></asp:Label>
                        
                    </td>
                            </tr>
                            <tr>
                                <td align="left" class="subhead" nowrap style="width: 240px">
                                    <p>
                                        Month And Year Of Joining :<span style="color: #ff0000">*</span></p>
                                </td>
                                <td align="center"  nowrap>
                                    
                                        
                                        <asp:Label ID="lblMnthJoiningClassIII" runat="server" ></asp:Label>
                                        
                                    <asp:Label ID="lblYearJoiningClassIII" runat="server" ></asp:Label>
                                </td>
                               <td align="center"  nowrap>
                                    
                                        
                                        <asp:Label ID="lblMnthJoiningClassIV" runat="server" ></asp:Label>
                                    <asp:Label ID="lblYearJoiningClassIV" runat="server" ></asp:Label>
                                </td>
                                 <td align="center"  nowrap>
                                    
                                        
                                        <asp:Label ID="lblMnthJoiningClassV" runat="server" ></asp:Label>
                                    <asp:Label ID="lblYearJoiningClassV" runat="server" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="subhead" nowrap style="width: 240px">
                                    <p>
                                        Month And Year Of Passing :<span style="color: #ff0000">*</span>&nbsp;</p>
                                </td>
                                <td align="center"  nowrap>
                                    
                                        
                                        <asp:Label ID="lblMnthPassingClassIII" runat="server" ></asp:Label>
                                    <asp:Label ID="lblYearPassingClassIII" runat="server" ></asp:Label>
                                </td>
                                <td align="center"  nowrap>
                                    
                                        
                                        <asp:Label ID="lblMnthPassingClassIV" runat="server" ></asp:Label>
                                    <asp:Label ID="lblYearPassingClassIV" runat="server"></asp:Label>
                                </td>
                               <td align="center"  nowrap>
                                    
                                        
                                        <asp:Label ID="lblMnthPassingClassV" runat="server" ></asp:Label>
                                    <asp:Label ID="lblYearPassingClassV" runat="server" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="subhead" style="width: 240px">
                                   
                                        NameoftheVillage/Town:<span style="color: #ff0000">*</span>
                                       
                                        (In Which The School Is Located)
                                        
                                        
                                    
                                </td>
                               <td   valign="top" width="10%" align="center">
                        <asp:Label ID="lblNameoftheVillageClassIII" runat="server" ></asp:Label>
                    </td>
                                 <td  align="center" style="height: 27px" valign="top" width="10%" nowrap>
                        <asp:Label ID="lblNameoftheVillageClassIV" runat="server"></asp:Label>
                    </td>
                               <td  align="center" style="height: 27px" valign="top" width="10%" nowrap>
                        <asp:Label ID="lblNameoftheVillageClassV" runat="server"></asp:Label>
                    </td>
                            </tr>
                            <tr>
                                <td align="left" class="subhead" nowrap style="width: 240px">
                                    <p>
                                        Name Of The Block &nbsp;:<span style="color: #ff0000">*</span></p>
                                </td>
                                <td align="center"  nowrap>
                                    <p>
                                        <asp:Label ID="lblNameOfBlockClassIII" runat="server" ></asp:Label>
                                    </p>
                                </td>
                                <td align="center"  nowrap>
                                    <p>
                                        <asp:Label ID="lblNameOfBlockClassIV" runat="server" ></asp:Label>
                                    </p>
                                </td>
                                <td align="center"  nowrap>
                                    <asp:Label ID="lblNameOfBlockClassV" runat="server" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="subhead" nowrap style="width: 240px">
                                    <p>
                                        Name Of The District :<span style="color: #ff0000">*</span></p>
                                </td>
                                <td align="center"  nowrap>
                                    <p>
                                        <asp:Label ID="lblNameOfDistrictClassIII" runat="server" ></asp:Label>
                                    </p>
                                </td>
                                <td align="center"  nowrap>
                                    <p>
                                        <asp:Label ID="lblNameOfDistrictClassIV" runat="server" ></asp:Label>
                                        
                                        
                                    </p>
                                </td>
                                <td align="center"  nowrap>
                                    <p>
                                        <asp:Label ID="lblNameOfDistrictClassV" runat="server" ></asp:Label>
                                    </p>
                                </td>
                                
                            </tr>
                            <tr>
                                <td align="left" class="subhead" nowrap style="width: 240px">
                                    <p>
                                        School Location:Rural / Urban <span style="color: #ff0000">*</span> &nbsp;</p>
                                </td>
                                <td  style="height: 27px" align="center" valign="top" width="10%">
                        <asp:Label ID="lblSchoolLocUrbanRuralClassIII" runat="server"  ></asp:Label>
                       
                    </td>
                                 <td  style="height: 27px" align="center" valign="top" width="10%">
                        <span style="vertical-align: super; color: #ff0000">&nbsp;</span><asp:Label 
                            ID="lblSchoolLocUrbanRuralClassIV" runat="server" ></asp:Label>
                        
                       
                    </td>
                                   <td  style="height: 27px" valign="top" align="center" width="10%">
                        <span style="vertical-align: super; color: #ff0000">&nbsp;</span><asp:Label 
                            ID="lblSchoolLocUrbanRuralClassV" runat="server"  ></asp:Label>
                        
                        
                    </td>
                            </tr>
                            
                            <tr>
                                <td align="left" class="subhead" nowrap style="width: 240px">
                                   
                                </td>
                                <td align="center" class="subhead" nowrap>
                                   
                                </td>
                                <td align="center" class="subhead" nowrap>
                                    
                                </td>
                                <td align="center" class="subhead" nowrap>
                                    
                                </td>
                            </tr>
                            <tr>
                            
                                <td align="right" class="subhead" style="width: 240px"  >
                                    
                                </td>
                                <td align="right">
                                
                                </td>
                                <td align="left" class="subhead" colspan="2"  >
                                  <asp:Button ID="btnEdit" runat="server" Text="Edit" onclick="btnEdit_Click" 
                                     width="60px"    /> 
                                </td>
                                
                            </tr>
                        </table>
                    </td>
                </tr>
            </caption>
        </caption>
        
        
        
        
        
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

