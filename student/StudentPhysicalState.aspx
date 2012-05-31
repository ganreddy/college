<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentPhysicalState.aspx.cs" Inherits="StudentModule_StudentPhysicalState" Title="Student Physical State" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

 <script type="text/jscript" language="javascript">
    function RequiredValidate()
    {
     if(! DropdownValidate('<%=ddlBatch.ClientID%>',"Please Select Batch"))return false;
     if(! DropdownValidate('<%=ddlClasses.ClientID%>',"Please Select Class"))return false;
     if(! DropdownValidate('<%=ddlSections.ClientID%>',"Please Select Section"))return false;
     if(! DropdownValidate('<%=ddlStudent.ClientID%>',"Please Select Student"))return false;
     if(!isNumeric('<%=txtHeight.ClientID%>',"Please Enter Numeric For Height" ))return false;
     if(!isNumeric('<%=txtWeight.ClientID%>',"Please Enter Numeric For Weight" ))return false;
     if(!isEmpty('<%=txtBloodgroup.ClientID%>',"Please Enter Blood Group" ))return false;
     //if(!isEmpty('<%=txtAilments.ClientID%>',"Please enter the Ailments" ))return false;
//      if(!ValidateTextFormat('<%=txtAilments.ClientID%>',"Please enter Chars for Ailments" ))return false;
      //if(!isEmpty('<%=txtAllergies.ClientID%>',"please enter the Allergies" ))return false;
////      if(!ValidateTextFormat('<%=txtAllergies.ClientID%>',"please enter Chars for Allergies" ))return false;
     //(!isNumeric('<%=txtChest.ClientID%>',"please Enter Numeric For Chest" ))return false;
     
    }
   
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
 <asp:UpdatePanel ID="UpdPanel" runat="server">
 <ContentTemplate>
 
<table align="center" class="tdcls" style="width: 90%; height: 147%" >
<tr>
<td>

<asp:HiddenField ID="hdnID" runat="server"></asp:HiddenField> 
</td>
</tr>

    <tr >
    <td  class=heading colspan="2" style="text-align:center" style="width: 20%">STUDENT 
        PHYSICAL STATE
    </td>
    </tr>
    
       <tr>
            <td style="width: 20%" class="subhead" >
                Batch <span style="color: #ff0000">*</span></td>
            
            <td style="width: 30%" >
                <asp:DropDownList ID="ddlBatch" runat="server" Width="155px" Height="16%" 
                    onselectedindexchanged="ddlBatch_SelectedIndexChanged" AutoPostBack="true">  
                   
                    
                </asp:DropDownList>
               </td>
            
        </tr>
        <tr>
            <td style="width: 20%" class="subhead">Class<span style="color: #ff0000">*</span>
            </td>
            <td style="width: 30%"  >
                <asp:DropDownList ID="ddlClasses" runat="server" Width="155px" Height="16%" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlClasses_SelectedIndexChanged"  >
                </asp:DropDownList>
                </td>
            
        </tr>
        <tr>
            <td style="width: 20%" class="subhead">Section<span style="color: #ff0000">*</span>
            </td>
            <td  style="width: 30%">
                <asp:DropDownList ID="ddlSections" runat="server" Width="155px" Height="16%"   
                    AutoPostBack="True" onselectedindexchanged="ddlSections_SelectedIndexChanged" > 
                     
                </asp:DropDownList>
                </td>
            
        </tr>
        <tr>
            <td style="width: 20%" class="subhead">
                Student<span style="color: #ff0000">*</span></td>
            <td style="width: 30%">
                <asp:DropDownList ID="ddlStudent"  Width="155px" Height="16%" runat="server"  
                    AutoPostBack="true" onselectedindexchanged="ddlStudent_SelectedIndexChanged" >
                </asp:DropDownList>
                </td>
            
        </tr>  
         
        <tr>
            <td style="width: 20%" class="subhead">
                Height<span style="color: #ff0000">*</span></td>
            <td  style="width: 30%">
                <asp:TextBox ID="txtHeight" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="width: 20%" class="subhead">
                Weight<span style="color: #ff0000">*</span></td>
            <td style="width: 30%">
                <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="width: 20%" class="subhead">
                Ailments</td>
            <td style="width: 30%">
                <asp:TextBox ID="txtAilments" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 20%" class="subhead">
                Alergies</td>
            <td style="width: 30%">
                <asp:TextBox ID="txtAllergies" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 20%" class="subhead">
                Eyesight</td>
            <td style="width: 30%">
                <asp:TextBox ID="txtEyesight" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="width: 20%" class="subhead">
                Blood Group<span style="color: #ff0000">*</span></td>
            <td style="width: 30%" >
                <asp:TextBox ID="txtBloodgroup" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="width: 20%" class="subhead">
                Diet Preffered </td>
            <td style="width: 30%" >
                <asp:TextBox ID="txtDietPreferred" runat="server"></asp:TextBox>
               </td>
        </tr>
        <tr>
            <td style="width: 20%" class="subhead">
                Chest</td>
            <td style="width: 30%" >
                <asp:TextBox ID="txtChest" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="width: 20%" class="subhead">
                Chronic Disease </td>
            <td style="width: 30%" >
                <asp:TextBox ID="txtChronocDisease" runat="server"></asp:TextBox>
               </td>
        </tr>
        
        <tr>
            <td style="width: 20%" class="subhead">
                Medical Opinion</td>
            <td  style="width: 30%">
                <asp:TextBox ID="txtMedicalOPenion" runat="server" Width="155px" TextMode="MultiLine"></asp:TextBox>
               </td>
        </tr>
       <tr><td></td><td></td></tr>
       <tr><td align="center">&nbsp;</td><td>
           <asp:Label ID="lblSave" runat="server"></asp:Label>
                &nbsp;<asp:Label ID="lblDelete" runat="server"></asp:Label>
           </td></tr>
       <tr><td></td><td></td></tr>
       <tr><td></td><td></td></tr>
        <tr>
            <td align="right"  style="width: 20%">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                   
                 
            </td>
            <td   style="width: 20%">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAdd" runat="server" Text="Save" OnClientClick="return RequiredValidate();" 
                   onclick="btnAdd_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
    </table>
    </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>

