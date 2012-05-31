<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentTC.aspx.cs" Inherits="student_StudentTC" Title="Student Transfer Certificate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
    
    <script type="text/javascript" language="javascript">


        function validation() {
            //alert(document.getElementById('<%=hdntransfer.ClientID%>').value);
            if (document.getElementById('<%=hdntransfer.ClientID%>').value=="0") 
            {
                if (!DropdownValidate('<%=ddlBatch.ClientID%>', "Please Select Batch")) return false;
                if (!DropdownValidate('<%=ddlClasses.ClientID%>', "Please Select Class")) return false;
                if (!DropdownValidate('<%=ddlSections.ClientID%>', "Please Select Section")) return false;
                if (!DropdownValidate('<%=ddlStudentID.ClientID%>', "Please Select Student")) return false;
            }
     if(!isEmpty('<%=txtAdmNo.ClientID%>',"Please Enter Admission Number"))return false;
      if(!isEmpty('<%=txtName.ClientID%>',"Please Enter Name"))return false;
       if(!isEmpty('<%=txtFatherName.ClientID%>',"Please Enter Father Name"))return false;
       
      
         if(!isEmpty('<%=txtScheduled.ClientID%>',"Please Enter Scheduled Caste/Scheduled Tribe"))return false;
         if (!isDateFormat('<%=txtDob.ClientID%>', "Please Enter Valid Date Of Birth")) return false;
         if (!DropdownValidate('<%=ddllastClassStudied.ClientID%>', "Please Select Last Class Studied")) return false;
         
         if (!isEmpty('<%=txtTCNo.ClientID%>', "Please Enter TC Number")) return false;

         if (!isEmpty('<%=txtSubjetStud .ClientID%>', "Please Enter Subjects Studied")) return false;
         
         
         var No=document.getElementById('<%=rdbFailNo.ClientID%>').checked;
       var Once=document.getElementById('<%=rdbOnce.ClientID%>').checked;
        var Twice=document.getElementById('<%=rdbTwice.ClientID%>').checked;
       if((No==false) && (Once==false)&& (Twice==false))
       {
       alert("Please Select No/Once/Twice");
       return false;
       }
       
        var Yes=document.getElementById('<%=RadioYes.ClientID%>').checked;
       var Nor=document.getElementById('<%=RadioNo.ClientID%>').checked;
       
       if((Yes==false) && (Nor==false))
       {
       alert("Please Select Qualified For Promotion To The Higherclass Yes/No");
       return false;
       }
       
//        var Yes1=document.getElementById('<%=rdbFeeYes.ClientID%>').checked;
//       var No1=document.getElementById('<%=rdbFeeNo.ClientID%>').checked;
//       
//       if((Yes1==false) && (No1==false))
//       {
//       alert("Please Select Whether Pupil Was In Receipt Of Any Fee Concession Yes/No");
//       return false;
       //       }
       if(! isDateFormat('<%=txtDateofAttendence.ClientID%>',"Please Enter Valid Date Of Last Attendance At The School"))return false;
       

       if (document.getElementById('<%=txtDateofapplication.ClientID %>').value != "") {
           if (!isDateFormat('<%=txtDateofapplication.ClientID %>', "Date Format Should Be DD/MM/YYYY")) return false;
           
       }



       if (!isDateFormat('<%=txtdateofissuecer.ClientID%>', "Please Enter Valid  Date Of Issue Of This Certificate")) return false;
       if (!DateFormat12('<%=txtDateofapplication.ClientID%>', '<%=txtdateofissuecer.ClientID%>', "Date Of Issue Cannot Be Less Than Date Of Application")) return false;
      
       
       

             if (!DropdownValidate('<%=ddlReasion.ClientID%>', "Please Select Reasons For Leaving School")) return false;
       //if(! isEmpty('<%=txtExtraactivities.ClientID%>',"Please Enter Extra curricular activities"))return false;
       if(! isEmpty('<%=txtConduct.ClientID%>',"Please Enter Conduct"))return false;
       if(! isEmpty('<%=txtRemarks.ClientID%>',"Please Enter Remarks"))return false;
       

    }
    </script>
    
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
                    
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                            
                              <tr>
                              <td colspan="2">
                              <asp:Panel ID="pnlSearch" runat="server" >
                              <table align="center" border="0" width="100%">
                              <tr align="center">
                        <td class="heading" colspan="2">
                            <strong>SEARCH</strong>
                        </td>
                    </tr>
                               <tr>
                                        <td class="subhead" style="width: 360px" >
                                            Batch <span style="font-size: 11px; color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="true" Width="155px"
                                                Height="16%" onselectedindexchanged="ddlBatch_SelectedIndexChanged" >
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="subhead" style="width: 360px" >
                                            Branch <span style="font-size: 11px; color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlClasses" runat="server" AutoPostBack="True" Width="155px"
                                                Height="16%" onselectedindexchanged="ddlClasses_SelectedIndexChanged" >
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="subhead" style="width: 360px" >
                                            Section <span style="font-size: 11px; color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSections" runat="server" AutoPostBack="True" Width="155px"
                                                Height="16%" onselectedindexchanged="ddlSections_SelectedIndexChanged" >
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="subhead" style="width: 360px" >
                                            Student <span style="font-size: 11px; color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlStudentID" runat="server" Width="155px" Height="16%" 
                                                AutoPostBack="true" onselectedindexchanged="ddlStudentID_SelectedIndexChanged" >
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                              </table>
                              </asp:Panel>
                              </td>
                              
                              </tr>
                           
                       
                    <tr align="center">
                        <td class="heading" colspan="2">
                            <strong>TRANSFER CERTIFICATE</strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Admission No <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:TextBox ID="txtAdmNo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trName" runat="server">
                        <td class="subhead">
                            Name&nbsp; <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Parent/Guardian's Name&nbsp; <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:TextBox ID="txtFatherName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="subhead">
                            Mother Name's
                        <span style="font-size: 11px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMotherName" runat="server"></asp:TextBox>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="subhead">
                            Scheduled Caste/Scheduled Tribe&nbsp; <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:TextBox ID="txtScheduled" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Date Of Birth&nbsp; <span style="font-size: 11px; color: Red">*</span></td>
                        <td nowrap>
                            <asp:TextBox ID="txtDob" runat="server"></asp:TextBox>
                            <img id="Img3" alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16">
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Img3"
                                TargetControlID="txtdob" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Class Last Studied
                        <span style="font-size: 11px; color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddllastClassStudied" runat="server" Width="154px">
                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                    <td class="subhead">
                            TC Number<span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:TextBox ID="txtTCNo" runat="server"></asp:TextBox>
                        </td>
                     
                    </tr>
                    <tr>
                        <td class=" subhead">
                            Subjects Studied&nbsp; <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:TextBox ID="txtSubjetStud" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="subhead">
                            College/Board Annual Examination Taken With Result
                            <span style="font-size: 11px; color: Red">*</span>
                        </td>
                        <td>
                           <asp:TextBox runat="server" ID="txtAnnualExam"></asp:TextBox>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="subhead">
                            Whether Failed,Once/Twice In The Same Class
                            <span style="font-size: 11px; color: Red">*</span>
                        </td>
                        <td class="subhead">
                            <asp:RadioButton ID="rdbFailNo" runat="server" Text="No" GroupName="Fail" />&nbsp;&nbsp;
                            <asp:RadioButton ID="rdbOnce" runat="server" Text="Once" GroupName="Fail" />&nbsp;&nbsp;
                            <asp:RadioButton ID="rdbTwice" runat="server" Text="Twice" GroupName="Fail" />&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Qualified For Promotion To The Higher Class
                            <span style="font-size: 11px; color: Red">*</span></td>
                        <td class="subhead">
                            <asp:RadioButton ID="RadioYes" runat="server" class="subhead" ForeColor="Black" GroupName="rbOnly"
                                Text="Yes" />&nbsp;
                            <asp:RadioButton ID="RadioNo" runat="server" class="subhead" ForeColor="Black" GroupName="rbOnly"
                                Text="No" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="subhead">
                            Month Upto Which Fees Have Been Paid
                        </td>
                        <td>
                            <asp:TextBox ID="txtmonthlypaid" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Whether Pupil Was In Receipt Of Any Fee Concession
                        </td>
                        <td>
                            <asp:RadioButton ID="rdbFeeYes" runat="server" class="subhead" ForeColor="Black" GroupName="fee"
                                Text="Yes" />&nbsp;
                            <asp:RadioButton ID="rdbFeeNo" runat="server" class="subhead" ForeColor="Black" GroupName="fee"
                                Text="No" />
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Date Of Last Attendance At The College
                        <span style="font-size: 11px; color: Red">*</span></td>
                        <td nowrap>
                            <asp:TextBox ID="txtDateofAttendence" runat="server"></asp:TextBox>
                            <img id="Img1" alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16">
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="Img1"
                                TargetControlID="txtDateofAttendence" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="subhead">
                            Number Of College Days Upto The Date
                        <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:TextBox ID="txtnoofdays" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Number Of College Days Pupil Attended
                        <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:TextBox ID="txtStuattendence" runat="server"></asp:TextBox>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="subhead">
                            Date Of Application For The Certificate&nbsp;<span 
                                style="font-size: 11px; color: Red">*</span>
                        </td>
                        <td nowrap>
                            <asp:TextBox ID="txtDateofapplication" runat="server"></asp:TextBox>
                            <img id="Img2" alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16">
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Img2"
                                TargetControlID="txtDateofapplication" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Date Of Issue Of This Certificate<span style="font-size: 11px; color: Red">*</span>
                        </td>
                        <td nowrap>
                            <asp:TextBox ID="txtdateofissuecer" runat="server"></asp:TextBox>
                            <img id="Img5" alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16">
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="Img5"
                                TargetControlID="txtdateofissuecer" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Reasons For Leaving College
                        <span style="font-size: 11px; color: Red">*</span></td>
                        <td>
                            <asp:DropDownList ID="ddlReasion" runat="server" Width="154px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            NCC Cadet/Boy Scout/Girl Guide
                        </td>
                        <td>
                            <asp:TextBox ID="txtNcc" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Extra Curricular Activities</td>
                        <td>
                            <asp:TextBox ID="txtExtraactivities" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Conduct<span style="font-size: 11px; color: Red">*</span> </td>
                        <td>
                            <asp:TextBox ID="txtConduct" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    
                    
                    
                    <tr>
                        <td class="subhead" style="height: 26px">
                            Remarks
                        <span style="font-size: 11px; color: Red">*</span></td>
                        <td style="height: 26px">
                            <asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" colspan="2" align="center">
                          
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" colspan="2" align="center">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" colspan="2" align="center">
                            <asp:Button  ID="btnSave" runat="server" Text=" Save " 
                                onclick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

