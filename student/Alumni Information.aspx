<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Alumni Information.aspx.cs" Inherits="Alumni_Information" Title="Alumni Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
     function validateSave()
     {
       if(! isEmpty('<%=txtAdmissionNo.ClientID%>',"Please Enter Admission Number"))return false;
       if (!isEmpty('<%=txtAlumniName.ClientID%>', "Please Enter Alumni Name")) return false;
       if (!isEmpty('<%=txtDateOfBirth.ClientID%>', "Please Enter Date Of Birth")) return false;
       //if (document.getElementById('<%=txtDateOfBirth.ClientID%>').value != "") 
       //{
           if (!isDateFormat('<%=txtDateOfBirth.ClientID%>', "Date Format Should Be DD/MM/YYYY")) return false;
       //}
        if(! isEmpty('<%=txtFathersName.ClientID%>',"Please Enter Father's Name"))return false; 
        if(! isEmpty('<%=txtPermanentAddress.ClientID%>',"Please Enter Permanent Address"))return false; 
        if(! isEmpty('<%=txtTelephoneNo.ClientID%>',"Please Enter TelePhone Number"))return false;
       // if(document.getElementById('<%=txtTelephoneNo.ClientID%>').value!="")
        // {
            if(!isNumeric('<%=txtTelephoneNo.ClientID%>',"Please Enter Valid Telephone Number:" ))return false;
            // }
            if (document.getElementById('<%=txtEmailId.ClientID%>').value != "") {
                if (!EmailFormat('<%=txtEmailId.ClientID%>', "Please Enter Valid E-mail Id")) return false;
            } 
        if(! isEmpty('<%=txtPresentAddress.ClientID%>',"Please Enter Present Address"))return false;
        if (!isEmpty('<%=txtPresentTelephNo.ClientID%>', "Please Enter Valid Present TelePhone Number")) return false;
       // if(document.getElementById('<%=txtPresentTelephNo.ClientID%>').value!="")
       //  {
             if (!isNumeric('<%=txtPresentTelephNo.ClientID%>', "Please Enter Valid Present Telephone Number")) return false;
        // }
        
        if(! isEmpty('<%=txtQualification.ClientID%>',"Please Enter Qualification"))return false;
        if (!DropdownValidate('<%=ddlYearOfPassing.ClientID%>', "Please Select Year Of Passing")) return false;
        if (!isEmpty('<%=txtQualificationDate.ClientID%>', "Please Enter Qualification As On Date")) return false;
       // if (document.getElementById('<%=txtQualificationDate.ClientID%>').value != "") 
        //{
            if (!isDateFormat('<%=txtQualificationDate.ClientID%>', "Date Format Should Be DD/MM/YYYY")) return false;
       // }
       
        if(! isEmpty('<%=txtJobStatus.ClientID%>',"Please Enter Job Status"))return false;

        if (!isEmpty('<%=txtStatusDate.ClientID%>', "Please Enter Status Date")) return false;
       // if (document.getElementById('txtStatusDate.ClientID').value != "") 
       // {
            if (!isDateFormat('<%=txtStatusDate.ClientID%>', "Date Format Should Be DD/MM/YYYY")) return false;
       // }
        
        
        var Engineers=document.getElementById('<%=rbEngineer.ClientID%>').checked; 
        var Medicos=document.getElementById('<%=rbMedicos.ClientID%>').checked; 
        var Administrator=document.getElementById('<%=rbAdministrators.ClientID%>').checked; 
        var Manager=document.getElementById('<%=rbManager.ClientID%>').checked; 
        var Defence=document.getElementById('<%=rbDefence.ClientID%>').checked; 
        var MainLiners=document.getElementById('<%=rbMainLiners.ClientID%>').checked; 
        var Professionals=document.getElementById('<%=rbProfessional.ClientID%>').checked; 
        var IntegratedCourses=document.getElementById('<%=rbIntegratedCourses.ClientID%>').checked; 
        if((Engineers)==false || (document.getElementById('<%=ddlEngineers.ClientID%>').selectedIndex)==0 )
        { 
        if((Medicos)==false || (document.getElementById('<%=ddlMedicos.ClientID%>').selectedIndex)==0 )
          {
        if((Administrator)==false || (document.getElementById('<%=ddlAdministrator.ClientID%>').selectedIndex)==0 )
            {
        if((Manager)==false || (document.getElementById('<%=ddlManager.ClientID%>').selectedIndex)==0)
              {  
        if((Defence)==false || (document.getElementById('<%=ddlDefence.ClientID%>').selectedIndex)==0) 
                 {   
        if((MainLiners)==false || (document.getElementById('<%=ddMainLiners.ClientID%>').selectedIndex)==0)
               {   
        if((Professionals)==false || (document.getElementById('<%=ddlProfessionals.ClientID%>').selectedIndex)==0)         
              {
              
        if((IntegratedCourses)==false)
                  {
          alert("Select The Radio Button And Corresponding Dropdown Of Engineers/Medicos/Administrator/Manager/Defence/MainLiners/Professionals/Integrated Courses");
          return false;
                 }
               }
              }
            }
           }
         }
       }
      }
       var Yes=document.getElementById('<%=rbYes.ClientID%>').checked;
       var No=document.getElementById('<%=rbNo.ClientID%>').checked;
       if((Yes==false) && (No==false))
       {
       alert("Please Choose One Radio Button Yes/No");
       return false;
       }
         if(document.getElementById('<%=rbYes.ClientID%>').checked)
         {
         if(! isEmpty('<%=txtDesign.ClientID%>',"Please Enter  Designation"))return false; 
         if(! isEmpty('<%=txtOfficeAddress.ClientID%>',"Please Enter The Office Address"))return false; 
         if(! isEmpty('<%=txtRemarks.ClientID%>',"Please Enter Remarks"))return false; 
         }
        
       
     }
    
    </script>
      

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="upd1" runat="server">
    <ContentTemplate>
    
   <table align="center" width="90%" border="0">
        <tr>
            <td>
                <asp:HiddenField ID="Message" runat="server"></asp:HiddenField>
            </td>
        </tr>
        <tr>
            <td class="heading" colspan="4" style="text-align: center" width="100%">
                STUDENT ALUMNI INFORMATION
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Admission No:<span style="color: #ff0000">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtAdmissionNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Name Of The Alumni:<span style="color: #ff0000">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtAlumniName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Date Of&nbsp; Birth<span style="color: #ff0000">*</span>
            </td>
            <td>
                 <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateOfBirth" PopupButtonID="DOB" Format="dd/MM/yyyy">
     </asp:CalendarExtender>
                <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
               <%-- <img id="DOB" src="../images/cal.gif" />--%>
               <asp:ImageButton runat="server" id="DOB" src="../images/cal.gif" alt="Pick a date" border="0" height="16"/>
            </td>
        </tr>
    
        <tr>
            <td class="subhead">
                Father's Name<span style="color: #ff0000">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtFathersName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Permanent Address<span style="color: #ff0000">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtPermanentAddress" runat="server" TextMode="MultiLine" Width="155px"></asp:TextBox>
            </td>
            <td class="subhead">
                Correspondence Address
            </td>
            <td>
                <asp:TextBox ID="txtCorrespondingAddress" runat="server" TextMode="MultiLine" Width="155px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                TelephoneNo<span style="color: #ff0000">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtTelephoneNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                E-mail Id
            </td>
            <td>
                <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Present Address<span style="color: #ff0000">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtPresentAddress" runat="server" TextMode="MultiLine" Width="155px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Present Telephone No<span style="color: #ff0000">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtPresentTelephNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Qualification Attained<span style="color: #ff0000">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtQualification" runat="server"></asp:TextBox>
            </td>
            <td class="subhead">
                As On Date<span style="color: #ff0000">*</span></td>
            <td class="tdcls" valign="top">
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtQualificationDate" PopupButtonID="QualDate" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                <asp:TextBox ID="txtQualificationDate" runat="server" ></asp:TextBox>&nbsp;
                <%--<img src="../images/cal.gif" id="QualDate" />--%>
                <asp:ImageButton runat="server" src="../images/cal.gif" id="QualDate" alt="Pick a date" border="0" height="16"/>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Year Of Passing<span style="color: #ff0000">*</span>
            </td>
            <td>
                
                <asp:DropDownList ID="ddlYearOfPassing" runat="server" CssClass="ddlcls" Width="155px" Height="16%">
                            <asp:ListItem Text="---SELECT---" Value="0">---Select---</asp:ListItem> 
                            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Job Status<span style="color: #ff0000">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtJobStatus" runat="server"></asp:TextBox>
            </td>
            <td class="subhead">
                As On Date<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" valign="top">
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtStatusDate" PopupButtonID="StatusDate" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                <asp:TextBox ID="txtStatusDate" runat="server" >
                </asp:TextBox>
                <%--<img src="../images/cal.gif" id="StatusDate" />--%>
                <asp:ImageButton runat="server" src="../images/cal.gif" id="StatusDate"  alt="Pick a date" border="0" height="16"/>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <table width="100%">
                    <tr>
                        <td class="subhead">
                            <asp:RadioButton ID="rbEngineer" runat="server" CssClass="rbcls" ForeColor="Black"
                                GroupName="rbJobStatus" Text="Engineers" Width="70px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEngineers" runat="server" CssClass="ddlcls" Width="155px" Height="16%">
                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                             <asp:ListItem Text="B.Tech" Value="1"></asp:ListItem>
                              <asp:ListItem Text="M.Tech" Value="2"></asp:ListItem>
                              <asp:ListItem Text="3rd Diploma(BCA)" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            <asp:RadioButton ID="rbMedicos" runat="server"  CssClass="rbcls" ForeColor="Black"
                                GroupName="rbJobStatus" Text="Medicos" Width="70px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMedicos" runat="server" CssClass="ddlcls" Width="155px" Height="16%">
                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                            <asp:ListItem Text="MBBS/BAMS" Value="1"></asp:ListItem>
                            <asp:ListItem Text="MD/MS" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Other Diplomas" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            <asp:RadioButton ID="rbAdministrators" runat="server" CssClass="rbcls" ForeColor="Black"
                                GroupName="rbJobStatus" Text="Administrator" Width="70px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAdministrator" runat="server" CssClass="ddlcls" Width="155px" Height="16%">
                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                            <asp:ListItem Text="IAS/IPS allied" Value="1"></asp:ListItem>
                            <asp:ListItem Text="State Civil Services/Police" Value="2"></asp:ListItem>
                            <asp:ListItem Text="IITs" Value="3"></asp:ListItem>
                            <asp:ListItem Text="IIMs" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Others" Value="5"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            <asp:RadioButton ID="rbManager" runat="server" CssClass="rbcls" ForeColor="Black"
                                GroupName="rbJobStatus" Text="Manager" Width="70px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlManager" runat="server" CssClass="ddlcls" Width="155px" Height="16%">
                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                            <asp:ListItem Text="MasterinManagement" Value="1"></asp:ListItem>
                            <asp:ListItem Text="BBA" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            <asp:RadioButton ID="rbDefence" runat="server" CssClass="rbcls" ForeColor="Black"
                                GroupName="rbJobStatus" Text="Defence" Width="70px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDefence" runat="server" CssClass="ddlcls" Width="155px" Height="16%">
                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Officers" Value="1"></asp:ListItem>
                            <asp:ListItem Text="JCOS/HCO/OR" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap class="subhead">
                            <asp:RadioButton ID="rbMainLiners" runat="server" CssClass="rbcls" ForeColor="Black"
                                GroupName="rbJobStatus" Text="Main Liners" Width="70px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddMainLiners" runat="server" CssClass="ddlcls" Width="155px" Height="16%">
                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                            <asp:ListItem Text="BA/B.Sc&B.Com" Value="1"></asp:ListItem>
                            <asp:ListItem Text="MA/M.Sc/M.Com" Value="2"></asp:ListItem>
                            <asp:ListItem Text="B.ED/M.ED/Teacher Diploma" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap class="subhead">
                            <asp:RadioButton ID="rbProfessional" runat="server" CssClass="rbcls" ForeColor="Black"
                                GroupName="rbJobStatus" Text="Professionals" Width="70px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProfessionals" runat="server" CssClass="ddlcls" Width="155px" Height="16%">
                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Professionals/freelancers" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap class="subhead">
                            <asp:RadioButton ID="rbIntegratedCourses" runat="server" CssClass="rbcls" ForeColor="Black"
                                GroupName="rbJobStatus" Text="Integrated Courses" Width="70px" />
                        </td>
                        <td>
                            <%--<asp:DropDownList ID="ddlIntegratedCourses" runat="server" CssClass="ddlcls" Width="155px" Height="16%" Enabled="false">
                            <asp:ListItem Text="---select---" Value="0"></asp:ListItem>
                            </asp:DropDownList>--%>
                        </td>
                        </tr>
                    
                    <tr>
                        <td nowrap class="subhead">
                            <asp:RadioButton ID="rbOthers" runat="server" CssClass="rbcls" ForeColor="Black"
                                GroupName="rbJobStatus" Text="If Others" Width="60px" Height="29px" />
                        </td>
                        <td>
                           <asp:TextBox ID="txtJobStatus1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td  class="subhead">
                In Service<span style="color: #ff0000">*</span>
            </td>
            <td class="subhead">
                <asp:RadioButton ID="rbYes" runat="server" CssClass="rbcls" ForeColor="Black" GroupName="rbInService"
                    Text="Yes" oncheckedchanged="rbYes_CheckedChanged" AutoPostBack="true" />
                <asp:RadioButton ID="rbNo" runat="server" CssClass="rbcls" ForeColor="Black" GroupName="rbInService"
                    Text="No" oncheckedchanged="rbNo_CheckedChanged" AutoPostBack="true" />
            </td>
        </tr>
        
        <asp:Panel ID="Panel1" runat="server" Visible="false">
        <tr>
            <td class="subhead" >
                Designation<span style="color: #ff0000">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtDesign" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Office Address<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" valign="top">
                <asp:TextBox ID="txtOfficeAddress" runat="server"  TextMode="MultiLine" Width="155px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Remarks<span style="color: #ff0000">*</span>
            </td>
            <td class="tdcls" valign="top">
                <asp:TextBox ID="txtRemarks" runat="server"  TextMode="MultiLine" Width="155px"   ></asp:TextBox>
            </td>
        </tr>
        </asp:Panel>
       
        <tr><td></td><td></td></tr>
         <tr><td></td><td colspan="2" align="center"><asp:Label ID="lblMessage" runat="server"></asp:Label></td></tr>
          <tr><td></td><td></td></tr>
        <tr class="tdcls" style="font-size: 12pt">
            <td colspan="4" height="1%" valign="top">
                <!-- Here we start displaying the button table -->
                &nbsp;
                <table align="center" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Button ID="btnsave" runat="server" CssClass="btncls" Text="Save" 
                                Width="56px" onclick="btnsave_Click" />
                            &nbsp;
                            <asp:Button ID="btnreset" runat="server" CssClass="btncls" Text="Reset" 
                                Width="56px" onclick="btnreset_Click"  />
                        </td>
                    </tr>
                </table>
                
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
