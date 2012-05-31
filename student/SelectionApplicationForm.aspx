<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SelectionApplicationForm.aspx.cs" Inherits="student_SelectionApplicationForm" Title="Selection Form" %>
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
     function validate()
    {
     if(! isEmpty('<%=txtRollNo.ClientID%>',"Please Enter Roll Number"))return false;
//     if(! isEmpty('<%=txtFirstName.ClientID%>',"Please Enter First Name"))return false;
//     //if(! isEmpty('<%=txtMiddleName.ClientID%>',"Please Enter Middle Name"))return false;
     //     if(! isEmpty('<%=txtLastName.ClientID%>',"Please Enter Last Name"))return false;
     if (!isEmpty('<%=txtFirstName.ClientID%>', "Please Enter First Name")) return false;
     if (document.getElementById('<%=txtFirstName.ClientID%>').value == 'Type First Name Here') {
         alert("Please Enter First Name");
         document.getElementById('<%=txtFirstName.ClientID%>').focus();
         return false;
     }
     //if(! isEmpty('<%=txtMiddleName.ClientID%>',"Please Enter Middle Name"))return false;
     if (!isEmpty('<%=txtLastName.ClientID%>', "Please Enter Last Name")) return false;
     if (document.getElementById('<%=txtLastName.ClientID%>').value == 'Type Last Name Here') {
         alert("Please Enter Last Name");
         document.getElementById('<%=txtLastName.ClientID%>').focus();
         return false;
     }
      if(! DropdownValidate('<%=ddlCategory.ClientID%>',"Please Select Category"))return false;
      if(! isDateFormat('<%=txtdob.ClientID%>',"Please Enter Valid DOB"))return false;
       if(! DropdownValidate('<%=ddlNationality1.ClientID%>',"Please Select Nationality"))return false;
       if(! isEmpty('<%=txtreligion1.ClientID%>',"Please Enter Religion"))return false;

       if (!isEmpty('<%=txtMoles1.ClientID%>', "Please Enter Moles Identification1")) return false;
        var Male=document.getElementById('<%=rbmale.ClientID%>').checked;
             var Female=document.getElementById('<%=rbfemale.ClientID%>').checked;    
            if((Male==false)&& (Female==false))
             {
             alert("Choose Any One Male/Female");
             document.getElementById('<%=rbtnUrban.ClientID%>').focus();
            return false;
            }
             
             var Urban=document.getElementById('<%=rbtnUrban.ClientID%>').checked;
             var Rural=document.getElementById('<%=rbtnRural.ClientID%>').checked;    
             if((Urban==false)&& (Rural==false))
             {
             alert("Choose Any One Urban/Rural");
             document.getElementById('<%=rbtnUrban.ClientID%>').focus();
             return false;
             }
             if(! isEmpty('<%=txtfathername.ClientID%>',"Please Enter Father's Name"))return false;
             if(! isEmpty('<%=txtMotherName.ClientID%>',"Please Enter Mother's Name"))return false;
             if (!isEmpty('<%=txtpremenentAdd1.ClientID%>', "Please Enter Permanent  Address")) return false;
             if(! isNumeric('<%=txtPinCode2.ClientID%>',"Please Enter Pin code"))return false;
             if (!isNumeric('<%=txttelephone.ClientID%>', "Please Enter Valid Telephone Number")) return false;
            //          if(! EmailFormat('<%=txtEmailID.ClientID%>',"Please Enter valid E-mail Id"))return false;
            if (document.getElementById('<%=txtEmailID.ClientID%>').value != "") 
            {
                if (!EmailFormat('<%=txtEmailID.ClientID%>', "Please Enter valid E-mail Id")) return false;
            }
            if(! isEmpty('<%=txtClassIII1.ClientID%>',"Please Enter School Name"))return false;
            if(! isEmpty('<%=txtClassIV1.ClientID%>',"Please Enter School Name"))return false;
            if(! isEmpty('<%=txtClassV1.ClientID%>',"Please Enter School Name"))return false;
            var Yes1=document.getElementById('<%=rbRecSchoolYes.ClientID%>').checked;
            var No1=document.getElementById('<%=rbRecSchoolNo.ClientID%>').checked;    
            if((Yes1==false)&& (No1==false))
            {
            alert("Choose Any One Recognized/Not Recognized");
            return false;
            }
            
            var Yes2=document.getElementById('<%=rbRecSchoolYes1.ClientID%>').checked;
            var No2=document.getElementById('<%=rbRecSchoolNo1.ClientID%>').checked;    
            if((Yes2==false)&& (No2==false))
            {
            alert("Choose Any One Recognized/Not Recognized");
            return false;
            }
            
             var Yes3=document.getElementById('<%=rbRecSchoolYes2.ClientID%>').checked;
            var No3=document.getElementById('<%=rbRecSchoolNo2.ClientID%>').checked;    
            if((Yes3==false)&& (No3==false))
            {
            alert("Choose Any One Recognized/Not Recognized");
            return false;
        }
        if (!DropdownValidate('<%=ddlMnthClassIII3.ClientID%>', "Please Select Month Of Joining")) return false;
        if (!DropdownValidate('<%=ddlYearClassIII3.ClientID%>', "Please Select Year Of Joining")) return false;

        if (!DropdownValidate('<%=ddlMnthClassIII4 .ClientID%>', "Please Select Month Of Passing")) return false;
        if (!DropdownValidate('<%=ddlYearClassIII4.ClientID%>', "Please Select Year Of Passing")) return false;
        
        if (!DropdownValidate('<%=ddlMnthClassIV3 .ClientID%>', "Please Select Month Of Joining")) return false;
        if (!DropdownValidate('<%=ddlYearClassIV3.ClientID%>', "Please Select Year Of Joining")) return false;

        if (!DropdownValidate('<%=ddlMnthClassIV4 .ClientID%>', "Please Select Month Of Passing")) return false;
        if (!DropdownValidate('<%=ddlYearClassIV4.ClientID%>', "Please Select Year Of Passing")) return false;

        if (!DropdownValidate('<%=ddlMnthClassV3 .ClientID%>', "Please Select Month Of Joining")) return false;
        if (!DropdownValidate('<%=ddlYearClassV3.ClientID%>', "Please Select Year Of Joining")) return false;

        if (!DropdownValidate('<%=ddlMnthClassV4 .ClientID%>', "Please Select Month Of Passing")) return false;
        if (!DropdownValidate('<%=ddlYearClassV4.ClientID%>', "Please Select Year Of Passing")) return false;
        
        if ((document.getElementById('<%=ddlYearClassIII4.ClientID%>').value) <= (document.getElementById('<%=ddlYearClassIII3.ClientID%>').value)) {
            alert("Year Of Joining  III Class Cannot Be Less Than Year Of Passing III Class");
            document.getElementById('<%=ddlYearClassIII4.ClientID%>').focus();
            return false;
        }
        if ((document.getElementById('<%=ddlYearClassIV4.ClientID%>').value) <= (document.getElementById('<%=ddlYearClassIV3.ClientID%>').value)) {
            alert("Year Of Joining  IV Class Cannot Be Less Than Year Of Passing IV Class");
            document.getElementById('<%=ddlYearClassIV4.ClientID%>').focus();
            return false;
        }
        if ((document.getElementById('<%=ddlYearClassV4.ClientID%>').value) <= (document.getElementById('<%=ddlYearClassV3.ClientID%>').value)) {
            alert("Year Of Joining  V Class Cannot Be Less Than Year Of Passing V Class");
            document.getElementById('<%=ddlYearClassV4.ClientID%>').focus();
            return false;
        }
        if ((document.getElementById('<%=ddlYearClassIII4.ClientID%>').value) > (document.getElementById('<%=ddlYearClassIV3.ClientID%>').value)) {
            alert("Year Of Joining  III Class Cannot Be Less Than Year Of Passing IV Class");
            document.getElementById('<%=ddlYearClassIV3.ClientID%>').focus();
            return false;
        }
        if ((document.getElementById('<%=ddlYearClassIV4.ClientID%>').value) > (document.getElementById('<%=ddlYearClassV3.ClientID%>').value)) {
            alert("Year Of Joining  V Class Cannot Be Less Than Year Of Passing IV Class");
            document.getElementById('<%=ddlYearClassV3.ClientID%>').focus();
            return false;
        }


        if (parseInt(document.getElementById('<%=ddlYearClassIII4.ClientID%>').value) <= parseInt(document.getElementById('<%=ddlYearClassIV3.ClientID%>').value)) {
            if (parseInt(document.getElementById('<%=ddlYearClassIII4.ClientID%>').value) == parseInt(document.getElementById('<%=ddlYearClassIV3.ClientID%>').value)) {
                if (parseInt(document.getElementById('<%=ddlMnthClassIII4.ClientID%>').value) > parseInt(document.getElementById('<%=ddlMnthClassIV3.ClientID%>').value)) {
                    alert("Month Of Joining  III Class Cannot Be Less Than Month Of Passing IV Class");
                    document.getElementById('<%=ddlMnthClassIV3.ClientID%>').focus();
                    return false;
                }
            }

        }
        else {

            alert("Year Of Joining  ");
            document.getElementById('<%=ddlYearClassIV3.ClientID%>').focus();
            return false;
        }

        if (parseInt(document.getElementById('<%=ddlYearClassIV4.ClientID%>').value) <= parseInt(document.getElementById('<%=ddlYearClassV3.ClientID%>').value)) {
            if (parseInt(document.getElementById('<%=ddlYearClassIV4.ClientID%>').value) == parseInt(document.getElementById('<%=ddlYearClassV3.ClientID%>').value)) {
                if (parseInt(document.getElementById('<%=ddlMnthClassIV4.ClientID%>').value) > parseInt(document.getElementById('<%=ddlMnthClassV3.ClientID%>').value)) {
                    alert("Month Of Joining  V Class Cannot Be Less Than Month Of Passing IV Class");
                    document.getElementById('<%=ddlMnthClassIV4.ClientID%>').focus();
                    return false;
                }
            }
        }
        else {
            ////alert();
            // alert("Year ");
            //alert();
            document.getElementById('<%=ddlMnthClassV3.ClientID%>').focus();
            return false;
        }


            

//        if (!DropdownValidate('<%=ddlMnthClassIII3.ClientID%>', "Please Select Month ")) return false;
//        if ((document.getElementById('<%=ddlYearClassIII3.ClientID%>').value) > (document.getElementById('<%=ddlYearClassIII4.ClientID%>').value)) {
//                alert("1");
//            alert("Year Of Passing Of IV  Class Cannot Be Less Than Year Of Joining Of III Class");
//            document.getElementById('<%=ddlYearClassIII3.ClientID%>').focus();
//            return false;
//        }
        

//        if (!DropdownValidate('<%=ddlYearClassIV3.ClientID%>', "Please Select Month ")) return false;
//        if ((document.getElementById('<%=ddlYearClassIV3.ClientID%>').value) >= (document.getElementById('<%=ddlYearClassIV4.ClientID%>').value)) {
//            alert("2");
//            alert("Year Of Passing Of IV  Class Cannot Be Less Than Year Of Joining Of III Class");
//            document.getElementById('<%=ddlYearClassIV3.ClientID%>').focus();
//            return false;
//        }

////        if (!DropdownValidate('<%=ddlMnthClassV3.ClientID%>', "Please Select Month ")) return false;
//        if ((document.getElementById('<%=ddlYearClassV3.ClientID%>').value) > (document.getElementById('<%=ddlYearClassV4.ClientID%>').value)) {
//            alert("3");
//            alert("Year Of Passing Of IV  Class Cannot Be Less Than Year Of Joining Of III Class");
//            document.getElementById('<%=ddlYearClassV3.ClientID%>').focus();
//            return false;
//        }


//        if (!DropdownValidate('<%=ddlMnthClassIII4.ClientID%>', "Please Select Month ")) return false;
//        if ((document.getElementById('<%= ddlYearClassIII4.ClientID%>').value) >= (document.getElementById('<%=ddlYearClassV3.ClientID%>').value)) {
//            alert("4");
//            alert("Year Of Passing Of IV  Class Cannot Be Less Than Year Of Joining Of III Class");
//            document.getElementById('<%=ddlYearClassV3.ClientID%>').focus();
//            return false;
//        }


//        if (!DropdownValidate('<%=ddlMnthClassIV4.ClientID%>', "Please Select Month ")) return false;
//        if ((document.getElementById('<%=ddlYearClassIV3.ClientID%>').value) >= (document.getElementById('<%=ddlYearClassIII4.ClientID%>').value)) {
//            alert("5");
//            alert("Year Of Passing Of IV  Class Cannot Be Less Than Year Of Joining Of III Class");
//            document.getElementById('<%=ddlYearClassIV3.ClientID%>').focus();
//            return false;
//        }

//       if (!DropdownValidate('<%=ddlMnthClassV4.ClientID%>', "Please Select Month ")) return false;
//        if ((document.getElementById('<%=ddlYearClassIV3.ClientID%>').value) >= (document.getElementById('<%=ddlYearClassV4.ClientID%>').value)) {
//            alert("6");
//            alert("Year Of Passing Of IV  Class Cannot Be Less Than Year Of Joining Of III Class");
//            document.getElementById('<%=ddlYearClassV4.ClientID%>').focus();
//            return false;
//        }

        //if (!DropdownValidate('<%=ddlMnthClassV4.ClientID%>', "Please Select Month ")) return false;
        
            
//            if((document.getElementById('<%=ddlYearClassIV3.ClientID%>').value )>= (document.getElementById('<%=ddlYearClassV3.ClientID%>').value ))
//            {
//            alert("Year Of Joining Of IV Class And V Class Cannot Be Less Than Year Of Joining Of III Class");
//            document.getElementById('<%=ddlYearClassV3.ClientID%>').focus();
//            return false;
//            }
//            if(! DropdownValidate('<%=ddlYearClassIII3.ClientID%>',"Please Select Year "))return false;
//            if(! DropdownValidate('<%=ddlMnthClassIII4.ClientID%>',"Please Select Month"))return false;
//            if(! DropdownValidate('<%=ddlYearClassIII4.ClientID%>',"Please Select Year"))return false;
//            if ((document.getElementById('<%=ddlYearClassIII4.ClientID%>').value ) >= (document.getElementById('<%=ddlYearClassIV4.ClientID%>').value ))
//            {
//            alert(" Year of Passing Of IV Class Cannot Be Less Than Year Of Passing Of III Class");
//            document.getElementById('<%=ddlYearClassIV4.ClientID%>').focus();
//            return false;
//            }
//            if((document.getElementById('<%=ddlYearClassIV4.ClientID%>').value )>= (document.getElementById('<%=ddlYearClassV4.ClientID%>').value ))
//            {
//            alert("Year Of Passing Of IV and V Class Cannot Be Less Than Year Of Passing Of III Class");
//            document.getElementById('<%=ddlYearClassV4.ClientID%>').focus();
//            return false;
//            }
//            if(! DropdownValidate('<%=ddlMnthClassIV3.ClientID%>',"Please Select Month "))return false;
//            if(! DropdownValidate('<%=ddlYearClassIV3.ClientID%>',"Please Select Year "))return false;
//            if(! DropdownValidate('<%=ddlMnthClassIV4.ClientID%>',"Please Select Month"))return false;
//            if(! DropdownValidate('<%=ddlYearClassIV4.ClientID%>',"Please Select Year"))return false;
//            
//            if(! DropdownValidate('<%=ddlMnthClassV3.ClientID%>',"Please Select Month "))return false;
//            if(! DropdownValidate('<%=ddlYearClassV3.ClientID%>',"Please Select Year "))return false;
//            if(! DropdownValidate('<%=ddlMnthClassV4.ClientID%>',"Please Select Month"))return false;
//            if(! DropdownValidate('<%=ddlYearClassV4.ClientID%>',"Please Select Year"))return false;
            
                    
            
          if(! isEmpty('<%=txtClassIII5.ClientID%>',"Please Enter Name Of Village/Town"))return false;
          if(! isEmpty('<%=txtClassIV5.ClientID%>',"Please Enter Name Of Village/Town"))return false;
          if(! isEmpty('<%=txtClassV5.ClientID%>',"Please Enter Name Of Village/Town"))return false;
          
            if(! isEmpty('<%=txtClassIII6.ClientID%>',"Please Enter Name Of Block"))return false;
            if(! isEmpty('<%=txtClassIV6.ClientID%>',"Please Enter Name Of Block"))return false;
            if(! isEmpty('<%=txtClassV6.ClientID%>',"Please Enter Name Of Block"))return false;
            
            if(! DropdownValidate('<%=ddlClassIII7.ClientID%>',"Please Select District"))return false;
            if(! DropdownValidate('<%=ddlClassIV7.ClientID%>',"Please Select District"))return false;
            if(! DropdownValidate('<%=ddlClassV7.ClientID%>',"Please Select District"))return false;
            
            var LocUrban1=document.getElementById('<%=rbSchoolLocUrban.ClientID%>').checked;
            var LocRural1=document.getElementById('<%=rbSchoolLocRural.ClientID%>').checked;    
            if((LocUrban1==false)&& (LocRural1==false))
            {
            alert("Choose Any Location Urban/Rural");
            return false;
            }
            
            var LocUrban2=document.getElementById('<%=rbSchoolLocUrban1.ClientID%>').checked;
            var LocRural2=document.getElementById('<%=rbSchoolLocRural1.ClientID%>').checked;    
            if((LocUrban2==false)&& (LocRural2==false)) 
            {
            alert("Choose Any Location Urban/Rural");
            return false;
            }
            
             var LocUrban3=document.getElementById('<%=rbSchoolLocUrban2.ClientID%>').checked;
            var LocRural3=document.getElementById('<%=rbSchoolLocRural2.ClientID%>').checked;    
            if((LocUrban3==false)&& (LocRural3==false))  
            {
            alert("Choose Location Urban/Rural");
            return false;
            }


            
//            if ((document.getElementById('<%=ddlYearClassIII4.ClientID%>').value) <= (document.getElementById('<%=ddlMnthClassIII3.ClientID%>').value)) {
//                if ((document.getElementById('<%=ddlMnthClassIII4.ClientID%>').value) <= (document.getElementById('<%=ddlMnthClassIII3.ClientID%>').value)) {
//                    //alert(document.getElementById('<%=ddlYearClassIV3.ClientID%>').value);
//                    alert("Select mnt1");
//                    document.getElementById('<%=ddlMnthClassIII4.ClientID%>').focus();
//                    return false;

//                }
//                else {
//                    alert("Year Of Joining III Class Cannot Be Less Than Year Of Passing III Class");
//                    document.getElementById('<%=ddlYearClassIV4.ClientID%>').focus();
//                    return false;

//                }
//            }

//            if ((document.getElementById('<%=ddlYearClassIV4.ClientID%>').value) <= (document.getElementById('<%=ddlYearClassIV3.ClientID%>').value)) {
//                if ((document.getElementById('<%=ddlMnthClassIV4.ClientID%>').value) <= (document.getElementById('<%=ddlMnthClassIV3.ClientID%>').value)) {
//                    alert(document.getElementById('<%=ddlYearClassIV3.ClientID%>').value);
//                    alert("Select mnt2");
//                    document.getElementById('<%=ddlMnthClassIV4.ClientID%>').focus();
//                    return false;

//                }
//                else {
//                    alert("Year Of Joining III Class Cannot Be Less Than Year Of Passing III Class");
//                    document.getElementById('<%=ddlYearClassIV4.ClientID%>').focus();
//                    return false;

//                }
//            }

//            if ((document.getElementById('<%=ddlYearClassV4.ClientID%>').value) <= (document.getElementById('<%=ddlYearClassV3.ClientID%>').value)) {
//                if ((document.getElementById('<%=ddlMnthClassV4.ClientID%>').value) <= (document.getElementById('<%=ddlMnthClassIV4.ClientID%>').value)) {
//                    //alert(document.getElementById('<%=ddlYearClassIV3.ClientID%>').value);
//                    alert("Select mnt3");
//                    document.getElementById('<%=ddlMnthClassV4.ClientID%>').focus();
//                    return false;

//                }
//                else {
//                    alert("Year Of Joining III Class Cannot Be Less Than Year Of Passing III Class");
//                    document.getElementById('<%=ddlYearClassV4.ClientID%>').focus();
//                    return false;

//                }
//            }

//            if ((document.getElementById('<%=ddlYearClassIV3.ClientID%>').value) >= (document.getElementById('<%=ddlMnthClassIII4.ClientID%>').value)) {
//                if ((document.getElementById('<%=ddlMnthClassIV3.ClientID%>').value) >= (document.getElementById('<%=ddlMnthClassIII4.ClientID%>').value)) {
//                    //alert(document.getElementById('<%=ddlYearClassIV3.ClientID%>').value);
//                    alert("Select mnt4");
//                    document.getElementById('<%=ddlYearClassIV3.ClientID%>').focus();
//                    return false;

//                }
//                else {
//                    alert("Year Of Joining III Class Cannot Be Less Than Year Of Passing III Class");
//                    document.getElementById('<%=ddlMnthClassIV3.ClientID%>').focus();
//                    return false;

//                }
//            }

//            if ((document.getElementById('<%=ddlYearClassV3.ClientID%>').value) <= (document.getElementById('<%=ddlYearClassIV4.ClientID%>').value)) {
//                if ((document.getElementById('<%=ddlMnthClassV3.ClientID%>').value) <= (document.getElementById('<%=ddlMnthClassIII4.ClientID%>').value)) {
//                    //alert(document.getElementById('<%=ddlYearClassIV3.ClientID%>').value);
//                    alert("Select mnt5");
//                    document.getElementById('<%=ddlMnthClassV3.ClientID%>').focus();
//                    return false;

//                }
//                else {
//                    alert("Year Of Joining V Class Cannot Be Less Than Year Of Passing IV Class");
//                    document.getElementById('<%=ddlYearClassV3.ClientID%>').focus();
//                    return false;

//                }
            //                        }
            //if ((document.getElementById('<%=ddlYearClassIII4.ClientID%>').value) <= (document.getElementById('<%=ddlYearClassIII3.ClientID%>').value)) {
               // alert("Year Of Joining  III Class Cannot Be Less Than Year Of Passing III Class");
                //document.getElementById('<%=ddlYearClassIII4.ClientID%>').focus();
                //return false;
            //}


           // if ((document.getElementById('<%=ddlYearClassIV4.ClientID%>').value) <= (document.getElementById('<%=ddlYearClassIV3.ClientID%>').value)) {
               // alert("Year Of Joining  IV Class Cannot Be Less Than Year Of Passing IV Class");
               // document.getElementById('<%=ddlYearClassIV4.ClientID%>').focus();
               // return false;
           // }


            //if ((document.getElementById('<%=ddlYearClassV4.ClientID%>').value) <= (document.getElementById('<%=ddlYearClassV3.ClientID%>').value)) {
               // alert("Year Of Joining  V Class Cannot Be Less Than Year Of Passing V Class");
               // document.getElementById('<%=ddlYearClassV4.ClientID%>').focus();
               // return false;
           // }



//            if ((document.getElementById('<%=ddlMnthClassIII4.ClientID%>').value) <(document.getElementById('<%=ddlMnthClassIII3.ClientID%>').value)) {
//                alert("Month Of Joining  III Class Cannot Be Less Than Month Of Passing III Class");
//                document.getElementById('<%=ddlMnthClassIII4.ClientID%>').focus();
//                return false;
//            }

//            if ((document.getElementById('<%=ddlMnthClassIV4.ClientID%>').value) < (document.getElementById('<%=ddlMnthClassIV3.ClientID%>').value)) {
//                alert("Month Of Joining  IV Class Cannot Be Less Than Month Of Passing IV Class");
//                document.getElementById('<%=ddlMnthClassIV4.ClientID%>').focus();
//                return false;
//            }
//            if ((document.getElementById('<%=ddlMnthClassV4.ClientID%>').value) < (document.getElementById('<%=ddlMnthClassV3.ClientID%>').value)) {
//                alert("Month Of Joining  V Class Cannot Be Less Than Month Of Passing V Class");
//                document.getElementById('<%=ddlMnthClassV4.ClientID%>').focus();
//                return false;
//            }
            
            
            
//            if ((document.getElementById('<%=ddlYearClassIII4.ClientID%>').value) > (document.getElementById('<%=ddlYearClassIV3.ClientID%>').value)) {
//                alert("Year Of Joining  V Class Cannot Be Less Than Year Of Passing V Class");
//                document.getElementById('<%=ddlYearClassIV3.ClientID%>').focus();
//                return false;
//            }
//            if ((document.getElementById('<%=ddlYearClassIV4.ClientID%>').value) > (document.getElementById('<%=ddlYearClassV3.ClientID%>').value)) {
//                alert("Year Of Joining  V Class Cannot Be Less Than Year Of Passing V Class");
//                document.getElementById('<%=ddlYearClassV3.ClientID%>').focus();
//                return false;
            //            }
           

            
            
            
//            if ((document.getElementById('<%=ddlMnthClassIII4.ClientID%>').value) < (document.getElementById('<%=ddlMnthClassIV3.ClientID%>').value)) {
//                alert("Month Of Joining  IV Class Cannot Be Less Than Month Of Passing III Class");
//                document.getElementById('<%=ddlMnthClassIII4.ClientID%>').focus();
//                return false;
//            }

//            if ((document.getElementById('<%=ddlMnthClassIV4.ClientID%>').value) < (document.getElementById('<%=ddlMnthClassV3.ClientID%>').value)) {
//                alert("Year Of Joining  V Class Cannot Be Less Than Year Of Passing V Class");
//                document.getElementById('<%=ddlMnthClassV3.ClientID%>').focus();
//                return false;
//            }


           
           
    }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="updStudAdmis" runat="server">
    <ContentTemplate>
    <table align="center" border="0" cellpadding="1" cellspacing="1" class="maintblcls1"
        style="width: 100%; height: 100%">
        <tr align="center">
            <td style="text-align: center" class="heading" width="100%" colspan="4">
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
                Admission Details<span></span>
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
                            <asp:TextBox ID="txtRollNo" runat="server" CssClass="txtcls" Width="154px"></asp:TextBox>
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
                Personal Details
            </td>
        </tr>
      
                    <tr>
                    <td class="subhead" nowrap>
                        Name Of The Candidate(IN BLOCK LETTERS):
                    </td>
                    <td class="subhead" >
                        <asp:TextBox ID="txtFirstName" runat="server" Width="154px"></asp:TextBox>
                        <asp:TextBoxWatermarkExtender ID="txtfstname" runat="server"  TargetControlID="txtFirstName" WatermarkText="Type First Name Here" WatermarkCssClass="watermarked" ></asp:TextBoxWatermarkExtender>
                        </td>
                        <td class="subhead" >
                         <asp:TextBox ID="txtMiddleName" runat="server" Width="154px"></asp:TextBox>
                         <asp:TextBoxWatermarkExtender ID="TextBoxMiddlename" runat="server"  TargetControlID="txtMiddleName" WatermarkText="Type Middle Name Here" WatermarkCssClass="watermarked" ></asp:TextBoxWatermarkExtender>
                        </td>
                        <td class="subhead" >
                        <asp:TextBox ID="txtLastName" Width="154px" runat="server"></asp:TextBox>
                        <asp:TextBoxWatermarkExtender ID="TextBoxLast" runat="server"  TargetControlID="txtLastName" WatermarkText="Type Last Name Here" WatermarkCssClass="watermarked" ></asp:TextBoxWatermarkExtender>
                    </td>
                    <td class="tdcls" style="width: 20%" valign="top">
                    </td>
                </tr>
                    
        <tr>
            <td nowrap class="subhead">
                Category:<span style="color: #ff0000"> *</span>
            </td>
           <td nowrap class="subhead">
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="ddlcls" Width="154px"
                    Height="16%">
                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                    <asp:ListItem Value="1">OC</asp:ListItem>
                    <asp:ListItem Value="2">OBC</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td nowrap class="subhead">
                Date Of Birth:<span style="color: #ff0000">*</span>
            </td>
            <td nowrap class="subhead">
                <asp:TextBox ID="txtdob" Width="154px" runat="server" CssClass="txtcls"></asp:TextBox>
                <asp:ImageButton runat="server" id="image1" alt="Pick a date" border="0" height="16" src="../images/cal.gif"
                    width="16"/>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="image1"
                    TargetControlID="txtdob" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <caption>
            <tr>
                <td class="subhead" valign="top" width="30%">
                    Nationality: <span style="color: #ff0000">*</span>
                </td>
                <td class="tdcls" valign="top" width="20%">
                    <asp:DropDownList ID="ddlNationality1" runat="server" CssClass="ddlcls" 
                        Height="16%" Width="154px">
                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                        <asp:ListItem Value="1">Indian</asp:ListItem>
                        <asp:ListItem Value="2">NRI</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="subhead" valign="top">
                    <span><span style="font-size: 9pt"><span style="">Religion:<span 
                        style="color: #ff0000">*</span></span></span></span>
                </td>
                <td class="tdcls" style="width: 30%" valign="top" >
                    <asp:TextBox ID="txtreligion1" runat="server" Width="154px" CssClass="txtcls"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td class="subhead" nowrap>
                    Moles Identification1:<span style="color: #ff0000">*</span>
                </td>
                <td class="subhead" nowrap>
                    <asp:TextBox ID="txtMoles1" runat="server" CssClass="txtcls" Width="154px"></asp:TextBox>
                </td>
                <td class="subhead" nowrap>
                    Moles Identification2:
                </td>
                <td class="subhead" nowrap>
                    <asp:TextBox ID="txtMoles2" Width="154px" runat="server" CssClass="txtcls"></asp:TextBox>
                </td>
            </tr>
            <caption>
                <tr>
                    <td class="subhead" nowrap>
                        <span style="color: black;">Gender:</span>:<span style="color: #ff0000">*</span>
                    </td>
                    <td class="subhead" nowrap>
                        <asp:RadioButton ID="rbmale" runat="server" class="subhead" ForeColor="Black" 
                            GroupName="rbgender" Text="Male" />
                        &nbsp;
                        <asp:RadioButton ID="rbfemale" runat="server" class="subhead" ForeColor="Black" 
                            GroupName="rbgender" Text="Female" />
                    </td>
                    <td class="subhead" nowrap>
                        Urban / Rural:
                    <span style="color: #ff0000">*</span></td>
                    <td class="tdcls" style="height: 27px" valign="top" width="10%">
                        <span style="vertical-align: super; color: #ff0000"><span style="">&nbsp;</span><asp:RadioButton 
                            ID="rbtnUrban" runat="server"  CssClass="subhead" 
                            ForeColor="Black" GroupName="rburban" Text="Urban" />
                        &nbsp;
                        <asp:RadioButton ID="rbtnRural" runat="server" CssClass="subhead" 
                            ForeColor="Black" GroupName="rburban" Text="Rural" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" nowrap>
                        Disabled:
                    </td>
                    <td class="subhead" >
                        <asp:CheckBox ID="chkPH" runat="server" Text="Physically handicapped" />
                        </td>
                        <td class="subhead" >
                        <asp:CheckBox ID="chkVm" runat="server" Text="Visually Impaired" />
                        </td>
                        <td class="subhead" >
                        <asp:CheckBox ID="chkHI" runat="server" Text="Hearing Impaired" />
                    </td>
                    <td class="tdcls" style="width: 20%" valign="top">
                    </td>
                </tr>
               
                <tr>
                    <td class="heading" colspan="4" valign="top">
                        Contact Information
                    </td>
                </tr>
                <tr>
                    <td class="subhead" nowrap>
                        Father's Name: <span style="color: #ff0000">*</span>
                    </td>
                    <td class="subhead" nowrap>
                        <asp:TextBox Width="154px" ID="txtfathername" runat="server" CssClass="txtcls"></asp:TextBox>
                    </td>
                    <td class="subhead" nowrap>
                        Mother's Name: <span style="color: #ff0000">*</span>
                    </td>
                    <td class="subhead" nowrap>
                        <asp:TextBox ID="txtMotherName" Width="154px" runat="server" CssClass="txtcls"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" nowrap>
                        Guardian Name
                    </td>
                    <td class="subhead" nowrap>
                        <asp:TextBox ID="txtguardname" Width="154px" runat="server" CssClass="txtcls"></asp:TextBox>
                    </td>
                    <td class="subhead" nowrap>
                        Relationship With Candidate:
                    </td>
                    <td class="subhead" nowrap>
                        <asp:TextBox ID="txtRelvthguard" Width="154px" runat="server" CssClass="txtcls"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" nowrap>
                        Persent Postal Address:
                    </td>
                    <td class="subhead" nowrap>
                        <asp:TextBox ID="txtpresentadd"  runat="server" CssClass="txtcls" 
                            TextMode="MultiLine" Width="154px"></asp:TextBox>
                    </td>
                    <td class="subhead" nowrap>
                        PIN Code:</td>
                    <td class="subhead" nowrap>
                        <asp:TextBox ID="txtPincode1" Width="154px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" nowrap>
                        Permanent Address: <span style="color: #ff0000">*</span>
                    </td>
                    <td class="subhead" nowrap>
                        <asp:TextBox ID="txtpremenentAdd1" runat="server" CssClass="txtcls" 
                            TextMode="MultiLine" Width="154px"></asp:TextBox>
                    </td>
                    <td class="subhead" nowrap>
                        PIN Code:<span style="color: #ff0000">*</span></td>
                    <td class="subhead" nowrap>
                        <asp:TextBox ID="txtPinCode2" Width="154px" runat="server" CssClass="txtcls"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="subhead" nowrap>
                        Telephone: <span style="color: #ff0000">*</span>
                    </td>
                    <td class="subhead" nowrap>
                        <asp:TextBox ID="txttelephone" Width="154px" runat="server" CssClass="txtcls"></asp:TextBox>
                    </td>
                    <td class="subhead" nowrap>
                        E-Mail ID:</td>
                    <td class="subhead" nowrap>
                        <asp:TextBox ID="txtEmailID" Width="154px" runat="server" CssClass="txtcls"></asp:TextBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td align="center" class="heading" colspan="4" style="width: 20%" valign="top">
                        School(s) From Where The Candidate Passed Class-III,IV And Is Studying In 
                        Class-V
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td colspan="4">
                        <table width="100%">
                            <tr>
                                <td align="center" class="heading" width="22%" nowrap>
                                    
                                </td>
                                <td align="center" class="heading" width="22%" nowrap>
                                    <p align="center">
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
                                <td align="center" class="subhead" nowrap>
                                    <p>
                                        <asp:TextBox ID="txtClassIII1" Width="154px" runat="server" CssClass="txtcls"></asp:TextBox>
                                        
   
    
                                    </p>
                                </td>
                                <td align="center" align="center" class="subhead" nowrap>
                                    <p style="height: 20px; width: 115px">
                                        <asp:TextBox ID="txtClassIV1" Width="154px" runat="server" CssClass="txtcls" ></asp:TextBox>
                                    </p>
                                </td>
                                <td align="center" class="subhead" nowrap>
                                    <asp:TextBox ID="txtClassV1" Width="154px" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="subhead" nowrap>
                                    <p>
                                         Recognized School &nbsp;:<span style="color: #ff0000">*</span></p>
                                </td>
                                  <td class="tdcls" style="height: 27px" valign="top" width="10%"  nowrap>
                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton 
                            ID="rbRecSchoolYes" runat="server"  CssClass="subhead" 
                            ForeColor="Black" GroupName="rbRecSchool" Text="Yes" />
                        &nbsp;
                        <asp:RadioButton ID="rbRecSchoolNo" runat="server" CssClass="subhead" 
                            ForeColor="Black" GroupName="rbRecSchool" Text="No" />
                        
                    </td>
                                 <td class="tdcls" style="height: 27px" valign="top"  width="10%" nowrap>
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton 
                            ID="rbRecSchoolYes1" runat="server"  CssClass="subhead" 
                            ForeColor="Black" GroupName="rbRecSchool1" Text="Yes" />
                        &nbsp;
                        <asp:RadioButton ID="rbRecSchoolNo1" runat="server" CssClass="subhead" 
                            ForeColor="Black" GroupName="rbRecSchool1" Text="No" />
                        
                    </td>
                               
                                 <td class="tdcls" style="height: 27px" valign="top" width="10%"  nowrap>
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton 
                            ID="rbRecSchoolYes2" runat="server"  CssClass="subhead" 
                            ForeColor="Black" GroupName="rbRecSchool2" Text="Yes" />
                        &nbsp;
                        <asp:RadioButton ID="rbRecSchoolNo2" runat="server" CssClass="subhead" 
                            ForeColor="Black" GroupName="rbRecSchool2" Text="No" />
                        
                    </td>
                            </tr>
                            <tr>
                                <td align="left" class="subhead" nowrap>
                                    <p>
                                        Month And Year Of Joining :<span style="color: #ff0000">*</span></p>
                                </td>
                                <td align="center" class="subhead" nowrap>
                                    
                                        
                                        <asp:DropDownList ID="ddlMnthClassIII3" runat="server" Width="77px" >
                                        <asp:ListItem Value="0" Text="Select" >---Select---</asp:ListItem>
                                        <asp:ListItem Value="1" Text="Jan" >Jan</asp:ListItem>
                                         <asp:ListItem Value="2" Text="Feb">Feb</asp:ListItem>
                                         <asp:ListItem Value="3" Text="March">March</asp:ListItem>
                                         <asp:ListItem Value="4" Text="April">April</asp:ListItem>
                                         <asp:ListItem Value="5" Text="May">May</asp:ListItem>
                                         <asp:ListItem Value="6" Text="June">June</asp:ListItem>
                                         <asp:ListItem Value="7" Text="July">July</asp:ListItem>
                                         <asp:ListItem Value="8" Text="Aug">Aug</asp:ListItem>
                                         <asp:ListItem Value="9" Text="Sep">Sep</asp:ListItem>
                                         <asp:ListItem Value="10" Text="Oct">Oct</asp:ListItem>
                                         <asp:ListItem Value="11" Text="Nov">Nov</asp:ListItem>
                                         <asp:ListItem Value="12" Text="Dec">Dec</asp:ListItem>
                                        </asp:DropDownList>
                                    <asp:DropDownList ID="ddlYearClassIII3" runat="server" Width="77px">
                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                               <td align="center" class="subhead" nowrap>
                                    
                                        
                                        <asp:DropDownList ID="ddlMnthClassIV3" runat="server" Width="77px">
                                        <asp:ListItem Value="0" Text="Select" >---Select---</asp:ListItem>
                                        <asp:ListItem Value="1" Text="Jan" >Jan</asp:ListItem>
                                         <asp:ListItem Value="2" Text="Feb">Feb</asp:ListItem>
                                         <asp:ListItem Value="3" Text="March">March</asp:ListItem>
                                         <asp:ListItem Value="4" Text="April">April</asp:ListItem>
                                         <asp:ListItem Value="5" Text="May">May</asp:ListItem>
                                         <asp:ListItem Value="6" Text="June">June</asp:ListItem>
                                         <asp:ListItem Value="7" Text="July">July</asp:ListItem>
                                         <asp:ListItem Value="8" Text="Aug">Aug</asp:ListItem>
                                         <asp:ListItem Value="9" Text="Sep">Sep</asp:ListItem>
                                         <asp:ListItem Value="10" Text="Oct">Oct</asp:ListItem>
                                         <asp:ListItem Value="11" Text="Nov">Nov</asp:ListItem>
                                         <asp:ListItem Value="12" Text="Dec">Dec</asp:ListItem>
                                        </asp:DropDownList>
                                    <asp:DropDownList ID="ddlYearClassIV3" runat="server" Width="77px">
                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                 <td align="center" class="subhead" nowrap>
                                    
                                        
                                        <asp:DropDownList ID="ddlMnthClassV3" runat="server" Width="77px">
                                        <asp:ListItem Value="0" Text="Select" >---Select---</asp:ListItem>
                                        <asp:ListItem Value="1" Text="Jan" >Jan</asp:ListItem>
                                         <asp:ListItem Value="2" Text="Feb">Feb</asp:ListItem>
                                         <asp:ListItem Value="3" Text="March">March</asp:ListItem>
                                         <asp:ListItem Value="4" Text="April">April</asp:ListItem>
                                         <asp:ListItem Value="5" Text="May">May</asp:ListItem>
                                         <asp:ListItem Value="6" Text="June">June</asp:ListItem>
                                         <asp:ListItem Value="7" Text="July">July</asp:ListItem>
                                         <asp:ListItem Value="8" Text="Aug">Aug</asp:ListItem>
                                         <asp:ListItem Value="9" Text="Sep">Sep</asp:ListItem>
                                         <asp:ListItem Value="10" Text="Oct">Oct</asp:ListItem>
                                         <asp:ListItem Value="11" Text="Nov">Nov</asp:ListItem>
                                         <asp:ListItem Value="12" Text="Dec">Dec</asp:ListItem>
                                        </asp:DropDownList>
                                    <asp:DropDownList ID="ddlYearClassV3" runat="server" Width="77px">
                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="subhead" nowrap>
                                    <p>
                                        Month And Year Of Passing :<span style="color: #ff0000">*</span>&nbsp;</p>
                                </td>
                                <td align="center" class="subhead" nowrap>
                                    
                                        
                                        <asp:DropDownList ID="ddlMnthClassIII4" runat="server" Width="77px">
                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                     
                                        <asp:ListItem Value="1" Text="Jan" >Jan</asp:ListItem>
                                         <asp:ListItem Value="2" Text="Feb">Feb</asp:ListItem>
                                         <asp:ListItem Value="3" Text="March">March</asp:ListItem>
                                         <asp:ListItem Value="4" Text="April">April</asp:ListItem>
                                         <asp:ListItem Value="5" Text="May">May</asp:ListItem>
                                         <asp:ListItem Value="6" Text="June">June</asp:ListItem>
                                         <asp:ListItem Value="7" Text="July">July</asp:ListItem>
                                         <asp:ListItem Value="8" Text="Aug">Aug</asp:ListItem>
                                         <asp:ListItem Value="9" Text="Sep">Sep</asp:ListItem>
                                         <asp:ListItem Value="10" Text="Oct">Oct</asp:ListItem>
                                         <asp:ListItem Value="11" Text="Nov">Nov</asp:ListItem>
                                         <asp:ListItem Value="12" Text="Dec">Dec</asp:ListItem>
                                        </asp:DropDownList>
                                    <asp:DropDownList ID="ddlYearClassIII4" runat="server" Width="77px">
                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="center" class="subhead" nowrap>
                                    
                                        
                                        <asp:DropDownList ID="ddlMnthClassIV4" runat="server" Width="77px" 
                                            Height="16px">
                                        <asp:ListItem Value="0" Text="Select" >---Select---</asp:ListItem>
                                        <asp:ListItem Value="1" Text="Jan" >Jan</asp:ListItem>
                                         <asp:ListItem Value="2" Text="Feb">Feb</asp:ListItem>
                                         <asp:ListItem Value="3" Text="March">March</asp:ListItem>
                                         <asp:ListItem Value="4" Text="April">April</asp:ListItem>
                                         <asp:ListItem Value="5" Text="May">May</asp:ListItem>
                                         <asp:ListItem Value="6" Text="June">June</asp:ListItem>
                                         <asp:ListItem Value="7" Text="July">July</asp:ListItem>
                                         <asp:ListItem Value="8" Text="Aug">Aug</asp:ListItem>
                                         <asp:ListItem Value="9" Text="Sep">Sep</asp:ListItem>
                                         <asp:ListItem Value="10" Text="Oct">Oct</asp:ListItem>
                                         <asp:ListItem Value="11" Text="Nov">Nov</asp:ListItem>
                                         <asp:ListItem Value="12" Text="Dec">Dec</asp:ListItem>
                                        </asp:DropDownList>
                                    <asp:DropDownList ID="ddlYearClassIV4" runat="server" Width="77px">
                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                               <td align="center" class="subhead" nowrap>
                                    
                                        
                                        <asp:DropDownList ID="ddlMnthClassV4" runat="server" Width="77px">
                                        <asp:ListItem Value="0" Text="Select" >---Select---</asp:ListItem>
                                        <asp:ListItem Value="1" Text="Jan" >Jan</asp:ListItem>
                                         <asp:ListItem Value="2" Text="Feb">Feb</asp:ListItem>
                                         <asp:ListItem Value="3" Text="March">March</asp:ListItem>
                                         <asp:ListItem Value="4" Text="April">April</asp:ListItem>
                                         <asp:ListItem Value="5" Text="May">May</asp:ListItem>
                                         <asp:ListItem Value="6" Text="June">June</asp:ListItem>
                                         <asp:ListItem Value="7" Text="July">July</asp:ListItem>
                                         <asp:ListItem Value="8" Text="Aug">Aug</asp:ListItem>
                                         <asp:ListItem Value="9" Text="Sep">Sep</asp:ListItem>
                                         <asp:ListItem Value="10" Text="Oct">Oct</asp:ListItem>
                                         <asp:ListItem Value="11" Text="Nov">Nov</asp:ListItem>
                                         <asp:ListItem Value="12" Text="Dec">Dec</asp:ListItem>
                                        </asp:DropDownList>
                                    <asp:DropDownList ID="ddlYearClassV4" runat="server" Width="77px">
                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="subhead">
                                   
                                        Name Of The Village/Town:<span style="color: #ff0000">*</span>
                                       
                                        (In Which The School Is Located)
                                        
                                       
                                    
                                </td>
                               <td class="tdcls" align="center"  valign="top" width="10%" nowrap>
                        <asp:TextBox ID="txtClassIII5" runat="server" Width="154px"></asp:TextBox>
                    </td>
                                 <td class="tdcls" align="center" style="height: 27px" valign="top" width="10%" nowrap>
                        <asp:TextBox ID="txtClassIV5" Width="154px" runat="server"></asp:TextBox>
                    </td>
                               <td class="tdcls" align="center" style="height: 27px" valign="top" width="10%" nowrap>
                        <asp:TextBox ID="txtClassV5" Width="154px" runat="server"></asp:TextBox>
                    </td>
                            </tr>
                            <tr>
                                <td align="left" class="subhead" nowrap>
                                    <p>
                                        Name Of The Block &nbsp;:<span style="color: #ff0000">*</span></p>
                                </td>
                                <td align="center" class="subhead" nowrap>
                                    <p>
                                        <asp:TextBox ID="txtClassIII6" runat="server" CssClass="txtcls" Width="154px"></asp:TextBox>
                                    </p>
                                </td>
                                <td align="center" class="subhead" nowrap>
                                    <p>
                                        <asp:TextBox ID="txtClassIV6" runat="server" CssClass="txtcls" Width="154px"></asp:TextBox>
                                    </p>
                                </td>
                                <td align="center" class="subhead" nowrap>
                                    <asp:TextBox ID="txtClassV6" runat="server" Width="154px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="subhead" nowrap>
                                    <p>
                                        Name Of The District :<span style="color: #ff0000">*</span></p>
                                </td>
                                <td align="center" class="subhead" nowrap>
                                    <p>
                                        <asp:DropDownList ID="ddlClassIII7" runat="server" Width="154px">
                                        <%--<asp:ListItem Value="0" >---Select---</asp:ListItem>
                                        <asp:ListItem Value="1">CurrentDistrict</asp:ListItem>
                                        <asp:ListItem Value="2">Others</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </p>
                                </td>
                                <td align="center" class="subhead" nowrap>
                                    <p>
                                        <asp:DropDownList ID="ddlClassIV7" runat="server" Width="154px">
                                        
                                        </asp:DropDownList>
                                    </p>
                                </td>
                                <td align="center" class="subhead" nowrap>
                                    <p>
                                        <asp:DropDownList ID="ddlClassV7" runat="server" Width="154px">
                                        
                                        </asp:DropDownList>
                                    </p>
                                </td>
                                
                            </tr>
                            <tr>
                                <td align="left" class="subhead" nowrap>
                                    <p>
                                        School Location:Rural / Urban <span style="color: #ff0000">*</span> &nbsp;</p>
                                </td>
                                <td class="tdcls"  style="height: 27px" valign="top" width="10%">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton 
                            ID="rbSchoolLocUrban" runat="server"  CssClass="subhead" 
                            ForeColor="Black" GroupName="rbSchoolLoc" Text="Urban" />
                        &nbsp;
                        <asp:RadioButton ID="rbSchoolLocRural" runat="server" CssClass="subhead" 
                            ForeColor="Black" GroupName="rbSchoolLoc" Text="Rural" />
                        
                    </td>
                                 <td class="tdcls"  style="height: 27px" valign="top" width="10%">
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton 
                            ID="rbSchoolLocUrban1" runat="server"  CssClass="subhead" 
                            ForeColor="Black" GroupName="rbSchoolLoc1" Text="Urban" />
                        &nbsp;
                        <asp:RadioButton ID="rbSchoolLocRural1" runat="server" CssClass="subhead" 
                            ForeColor="Black" GroupName="rbSchoolLoc1" Text="Rural" />
                       
                    </td>
                                   <td class="tdcls"  style="height: 27px" valign="top" width="10%">
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton 
                            ID="rbSchoolLocUrban2" runat="server"  CssClass="subhead" 
                            ForeColor="Black" GroupName="rbSchoolLoc2" Text="Urban" />
                        &nbsp;
                        <asp:RadioButton ID="rbSchoolLocRural2" runat="server" CssClass="subhead" 
                            ForeColor="Black" GroupName="rbSchoolLoc2" Text="Rural" />
                        
                    </td>
                            </tr>
                            
                            <tr>
                                <td align="left" class="subhead" nowrap>
                                   
                                </td>
                                <td align="center" class="subhead" nowrap>
                                   
                                </td>
                                <td align="center" class="subhead" nowrap>
                                    
                                </td>
                                <td align="center" class="subhead" nowrap>
                                    
                                </td>
                            </tr>
                            <tr>
                            
                                <td align="right" class="subhead"  >
                                    
                                </td>
                                <td></td>
                                <td align="left" class="subhead" colspan="2"  >
                                   <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                                        onclick="btnSubmit_Click" />
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

