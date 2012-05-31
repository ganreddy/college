<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="MessDishConsumption.aspx.cs" Inherits="MessCreateMenu" Title="Mess Dish Consumption" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    
    function validation()
    {
       
        if(! isDateFormat('<%=txtDate.ClientID%>',"Please Enter Date"))return false;
        if(document.getElementById('<%=txtDate.ClientID %>').value!="")
        {
           if(! isDateFormat('<%=txtDate.ClientID %>',"Date Format Should Be DD/MM/YYYY")) return false;
        }
        if(! DropdownValidate('<%=ddlDishName.ClientID%>',"Please Select Dish Name For Morning Snacks"))return false;
        if(!isEmpty ('<%=txtNameofStu.ClientID%>',"Please Enter Number Of Students For Morning Snacks"))return false;
        if(!isNumeric ('<%=txtNameofStu.ClientID%>',"Please Enter Correct Number Of Students For Morning Snacks"))return false;
        var Availability=document.getElementById('<%=lblAvailDisplay.ClientID%>').innerText;
        var NoOfStudents= document.getElementById('<%=lblAvailLeaves.ClientID%>').innerText;
        var totalnoofstd=parseInt(Availability - NoOfStudents);
//        alert(totalnoofstd);
        var std=document.getElementById('<%=txtNameofStu.ClientID%>').value;
         if(totalnoofstd < std)
             {
                 alert("Please Enter Number Of Students For Morning Snacks <= Available Students");
                 document.getElementById('<%=txtNameofStu.ClientID%>').focus();
                 return false;
             }
        if(! DropdownValidate('<%=ddlDishName2.ClientID%>',"Please Select Dish Name For Breakfast"))return false;
        if(! isEmpty('<%=txtNameofStu2.ClientID%>',"Please Enter Number Of Students For Breakfast"))return false;
        if(! isNumeric('<%=txtNameofStu2.ClientID%>',"Please Enter Valid Number Of Students For Breakfast"))return false;
        
         var std1=document.getElementById('<%=txtNameofStu2.ClientID%>').value;
         if(totalnoofstd < std1)
         
             {
                 alert("Please Enter Number Of Students For Breakfast <= Available Students");
                 document.getElementById('<%=txtNameofStu2.ClientID%>').focus();
                 return false;
             }
        if(! DropdownValidate('<%=ddlDishName3.ClientID%>',"Please Select Dish Name For Lunch"))return false;
        if(! isEmpty('<%=txtNameofStu3.ClientID%>',"Please Enter  Number Of Students For Lunch"))return false;
        if(! isNumeric('<%=txtNameofStu3.ClientID%>',"Please Enter Valid Number Of Students For Lunch"))return false;
        var std2=document.getElementById('<%=txtNameofStu3.ClientID%>').value;
         if(totalnoofstd < std2)
         
            {
                 alert("Please Enter Number Of Students For Lunch <= Available Students");
                document.getElementById('<%=txtNameofStu3.ClientID%>').focus();
                 return false;
             }
        if(! DropdownValidate('<%=ddlDishName4.ClientID%>',"Please Select Dish Name For Evening Snacks"))return false;
        if(! isEmpty('<%=txtNameofStu4.ClientID%>',"Please Enter  Number Of Students For Evening Snacks"))return false;
         if(! isNumeric('<%=txtNameofStu4.ClientID%>',"Please Enter Valid Number Of Students For Evening Snacks"))return false;
        
        var std3=document.getElementById('<%=txtNameofStu4.ClientID%>').value;
         if(totalnoofstd < std3)
         
             {
                 alert("Please Enter Number Of Students For Evening Snacks <= Available Students");
                 document.getElementById('<%=txtNameofStu4.ClientID%>').focus();
                 return false;
             }
        if(! DropdownValidate('<%=ddlDishName5.ClientID%>',"Please Select Dish Name For Dinner"))return false;
        if(! isEmpty('<%=txtNameofStu5.ClientID%>',"Please Enter  Number Of Students For Dinner"))return false;
        if(! isNumeric('<%=txtNameofStu5.ClientID%>',"Please Enter Valid Number Of Students For Dinner"))return false;
         
         var std4=document.getElementById('<%=txtNameofStu5.ClientID%>').value;
         if(totalnoofstd < std4)
         
             {
                 alert("Please Enter Number Of Students For Dinner <= Available Students");
                 document.getElementById('<%=txtNameofStu5.ClientID%>').focus();
                 return false;
             }

    }
    </script>

    
    <asp:UpdatePanel ID="updItemConsumption" runat="server" >
    <ContentTemplate>
    <table align="center" class="tdcls" width="50%">
        <tr>
            <td colspan="4" class="heading">
                MESS DAILY MENU
            </td>
           
        </tr>
        <tr>
        <td>
        </td>
            <td >
            <asp:Label ID="lblAvailability"  runat="server" Visible="false" Font-Bold="true"></asp:Label>
            <asp:Label ID="lblAvailLeaves" runat="server" Visible="false" Font-Bold="true"></asp:Label>
            <asp:Label ID="lblAvailDisplay" runat="server" Font-Bold="true" ></asp:Label>
            <asp:Label ID="lblTotalStudents" runat="server" Font-Bold="true" ></asp:Label>
            <asp:Label ID="lblAvilablestd" runat="server" Font-Bold="true" ></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="subhead">
                Date <span style="font-size: 17px; color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" OnTextChanged="txtDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate"
                    PopupButtonID="imgcal">
                </asp:CalendarExtender>
                <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                    id="imgcal">--%>
                <asp:ImageButton runat="server" alt="Pick a date" border="0" Height="16" src="../images/cal.gif"
                    Width="16" ID="imgcal" />
            </td>
            
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4" class="heading">
                MORNING SNACKS
            </td>
        </tr>
                        
        <tr>
            <td class="subhead">
                <br />
                Dish Name <span style="font-size: 17px; color: Red">*</span>
                <br />
                <br />
                No Of Students <span style="font-size: 17px; color: Red">*</span>
            </td>
            <td >
                <table>
                    <tr>
                        <td >
                            <br />
                            <asp:DropDownList ID="ddlDishName" runat="server" DataTextField="Name" DataValueField="Name"
                                Width="155px">
                                <asp:ListItem>Select</asp:ListItem>
                               
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:TextBox ID="txtNameofStu" runat="server">
                            </asp:TextBox>
                        </td>
                        
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="heading">
                    BREAKFAST
            </td>
           
        </tr>
        <tr>
            <td class="subhead">
                <br />
                Dish Name <span style="font-size: 17px; color: Red">*</span>
                <br />
                <br />
                No Of Students <span style="font-size: 17px; color: Red">*</span>
            </td>
            <td >
                <table>
                    <tr>
                        <td >
                            <br />
                            <asp:DropDownList ID="ddlDishName2" runat="server" DataTextField="Name" DataValueField="Name"
                                Width="155px">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Selectede</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:TextBox ID="txtNameofStu2" runat="server">
                            </asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="heading">
                LUNCH
            </td>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                <br />
                Dish Name <span style="font-size: 17px; color: Red">*</span>
                <br />
                <br />
                No Of Students <span style="font-size: 17px; color: Red">*</span>
            </td>
            <td >
                <table>
                    <tr>
                        <td >
                            <br />
                            <asp:DropDownList ID="ddlDishName3" runat="server" DataTextField="Name" DataValueField="Name"
                                Width="155px">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Selectede</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:TextBox ID="txtNameofStu3" runat="server">
                            </asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="heading">
                EVENING SNACKS
            </td>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                <br />
                Dish Name <span style="font-size: 17px; color: Red">*</span>
                <br />
                <br />
                No Of Students <span style="font-size: 17px; color: Red">*</span>
            </td>
            <td >
                <table>
                    <tr>
                        <td >
                            <br />
                            <asp:DropDownList ID="ddlDishName4" runat="server" DataTextField="Name" DataValueField="Name"
                                Width="155px">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Selectede</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:TextBox ID="txtNameofStu4" runat="server">
                            </asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="heading">
                DINNER
            </td>
            </td>
        </tr>
        <tr>
            <td class="subhead">
                <br />
                Dish Name <span style="font-size: 17px; color: Red">*</span>
                <br />
                <br />
                No Of Students <span style="font-size: 17px; color: Red">*</span>
            </td>
            <td >
                <table>
                    <tr>
                        <td >
                            <br />
                            <asp:DropDownList ID="ddlDishName5" runat="server" DataTextField="Name" DataValueField="Name"
                                Width="155px">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Selectede</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:TextBox ID="txtNameofStu5" runat="server">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
   
    </td> </tr>
    <tr>
        <td align="center">
            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" style="height: 15px;" colspan="4">
            <br />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </td>
    </tr>
    <br />
    <br />
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
