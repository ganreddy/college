<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="StaffSalaryPaySlip.aspx.cs" Inherits="Staff_StaffSalaryPaySlip" Title="Salary Slip" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
   
   function printDiv() 
   { 
      var divToPrint=document.getElementById('<%=divPrint.ClientID%>'); 
      //alert(divToPrint.innerHTML);
      var newWin=window.open('','','width=200,height=100'); 
      newWin.document.open(); 
      newWin.document.write('<html><body onload="window.print()"><br/><br/><br/><table width="100%"><tr><td align="center">'+divToPrint.innerHTML+'</td></tr></table></body></html>'); 
      newWin.document.close(); 
      setTimeout(function(){newWin.close();},10); 
   }
   function validate()
    {
   
         if(! DropdownValidate('<%=ddlStaffId.ClientID%>',"Please Select Staff"))return false;
         if(! DropdownValidate('<%=ddlMonth.ClientID%>',"Please Select Month"))return false;
         if(! DropdownValidate('<%=ddlYear.ClientID%>',"Please Select Year"))return false;
         if(! isNumeric('<%= txtNoOfWorkingDays.ClientID %>',"Please Enter Number Of Working Days")) return false;
    }
    </script>


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div>
                <table align="center" class="tdcls" width="60%" border="0">
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:HiddenField ID="Message" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="heading" colspan="2" style="text-align: center">
                            STAFF &nbsp;SALARY &nbsp;PAY SLIP
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" align="left">
                            Staff<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlStaffId" runat="server" Width="154px" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" align="left">
                            Month<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlMonth" runat="server" Width="154px" AutoPostBack="true">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                <asp:ListItem Value="5">May</asp:ListItem>
                                <asp:ListItem Value="6">Jun</asp:ListItem>
                                <asp:ListItem Value="7">Jul</asp:ListItem>
                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                <asp:ListItem Value="9">Sep</asp:ListItem>
                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                <asp:ListItem Value="12">Dec</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" align="left">
                            Year<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlYear" runat="server" Width="154px" AutoPostBack="true" 
                                onselectedindexchanged="ddlYear_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" align="left">
                            NO Of  Working Days<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNoOfWorkingDays" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="height: 26px">
                            <asp:Button ID="btnGetPaySlip" runat="server" Text="Get Pay Slip" Width="123px" OnClick="btnGetPaySlip_Click" />
                            <asp:Button ID="btnPrint" runat="server" Text="Print" Width="100px" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="center" style="height: 26px">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" width="100%">
                            <div id="divPrint" runat="server" align="center">
                                <asp:Panel ID="panel1" runat="server">
                                    <table cellspacing="2" cellpadding="2" width="100%" border="1">
                                    <tr>
                                            <td align="left" colspan="2">
                                               <center>
                                                    <b> JAWAHAR NAVODAYA VIDYALAYA</b> </center> </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <center>
                                                    <b>PAY SLIP FOR THE MONTH OF
                                                        <asp:Label ID="lblMonth" runat="server"></asp:Label>
                                                    </b>
                                                </center>
                                               <asp:Label ID="lblName" runat="server"></asp:Label>
                                                <br />
                                                                                          
                                                <br />
                                                <asp:Label ID="lblDes" runat="server"></asp:Label>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <b><u>Earnings:</u></b>
                                            </td>
                                            <td align="left">
                                                <b><u>Deductions:</u></b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" valign="top">
                                                <div id="dvPaySlip" runat="server" style="vertical-align:top;">
                                                </div>
                                            </td>
                                            <td align="center" valign="top">
                                                <div id="dvPayslip1" runat="server" style="vertical-align:top;"> 
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" valign="top">
                                                <div id="dvGrossAddition" runat="server">
                                                </div>
                                            </td>
                                            <td align="center" valign="top">
                                                <div id="dvGrossDeduction" runat="server">
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div id="dvNetAmount" runat="server">
                                                </div>
                                            </td>   
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
                <table align="center" class="tdcls" width="60%" border="0">
                    <tr>
                        <td style="text-align: center;">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;">
                            &nbsp;
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
