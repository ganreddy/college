<%@ Page MasterPageFile="~/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="ReportMessStock.aspx.cs" Inherits="ReportMessStock" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
function validation()
{
    var count=0;
    if (document.getElementById('<%=ddlCategory.ClientID%>').selectedIndex==0)
              count=count+1;
    if(count==1)
  alert("Please Select Atleast One Option");
}
function CallPrint(strid)
{
 var prtContent = document.getElementById(strid);
 var WinPrint = window.open('','','letf=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
 WinPrint.document.write(prtContent.innerHTML);
 WinPrint.document.close();
 WinPrint.focus();
 WinPrint.print();
 WinPrint.close();
 prtContent.innerHTML=strOldOne;
}
</script>
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <div style="text-align: center;">
        <table style="text-align: center;">
            <tr>
                <td >
                    Select Category&nbsp;</td>
                <td style="height: 24px; width: 195px;">
                  <asp:DropDownList ID="ddlCategory" runat="server" DataTextField="categryname" DataValueField="categryname"
                      Width="212px">
                      <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>Selectjhfj</asp:ListItem>
                      </asp:DropDownList>&nbsp;
                </td>
                <td style="width: 158px; height: 24px">
                    <asp:Button ID="btnReport" runat="server" Text="Get Report" 
                        style="height: 26px" /></td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td style="height: 24px">
                    </td>
                <td style="width: 195px; height: 24px">
                    &nbsp;<asp:Button ID="btnExcell" runat="server"  Text="Download As Excell" /></td>
                <td style="width: 158px; height: 24px">
                    &nbsp;<asp:Button ID="Button1" runat="server" OnClientClick="javascript:CallPrint('tblprint')"
                        Text="Print" /></td>
            </tr>
        </table>
        <table id="tblprint" class="tdcls" align="center"><tr><td>
        <asp:Repeater ID="repeaterFaculty" runat="server">
            <HeaderTemplate>
                <table cellspacing="1" style="background-color: #c1c1c1;">
             <tr>
                        <td colspan='8' style='text-align: center;'>
                            <b>JAWAHAR NAVODAYA VIDYALAYA :: KOMMADI - 530 041</b></td>
                    </tr>
                    <tr>
                        <td colspan='8' style='text-align: center;'>
                            <b>VISAKHAPATNAM DIST. (A.P.) </b></td>
                    </tr>
                    <tr>
                        <td colspan='8' style='text-align: center;'>
                            <b>STOCK OF  IN MESS </b>
                        </td>
                    </tr>
               
                    <tr style="background-color: #c1c1c1; font-weight: bold;">
                        <td style="text-align:center">
                            Item
                        </td>
                        <td style="text-align:center">
                            Quantity
                        </td>
                       
                       
                        
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="background-color: #eeeeee;">
                    <td>
                        <%# Eval("itemName")%>
                    </td>
                    
                    
                    <td>
                        <%# Eval("Qty")%>
                    </td>
                    
                    
                   
                </tr>
              
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater></td></tr></table>
    </div>
    <asp:HiddenField  runat="server" ID="Message" />
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
