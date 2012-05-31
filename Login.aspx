<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LOGIN PAGE</title>
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
            .body1 {
	background-image:url(images/JNVBG1.JPG);
	background-repeat:no-repeat;
	background-position:top center;
	margin-top: 50px;
  	height: 90%;
  	width: 85%;
  	padding: 0;
	font-family:Verdana, Arial, Helvetica, sans-serif;
	font-size:14px;
	font-style:normal;
  
	
        }
    </style>
   <script type="text/javascript" language="javascript">
    function validation()
    {
          if(! isEmpty('<%=txtUsername.ClientID%>',"Please Enter  UserName"))return false;
          if(! isEmpty('<%=txtPassword.ClientID%>',"Please Enter  Password"))return false;
    }
    </script>
</head>
<body  >
    
    <form id="form1" runat="server">
    
        <table width="70%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="3%">
                    &nbsp;
                </td>
                <td width="95%">
                    &nbsp;
                </td>
                <td width="2%" height="200px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <table width="60%" border="0" align="center" cellpadding="2" cellspacing="0">
                        <tr>
                            <td align="left">
                                <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblMessage" runat="server" Font-Names="Verdana" Font-Size="Small"
                                                Visible="false" ForeColor="Red">Invalid Login Details.</asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="heading">
                                        <td width="30%" align="left">
                                            User Name :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUsername" runat="server" TabIndex="1" />
                                        </td>
                                    </tr>
                                    <tr class="heading">
                                        <td align="left">
                                            Password :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="149px" TabIndex="2"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            &nbsp;
                                        </td>
                                        <td class="style1">
                                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                <asp:HyperLink ID="hlnkFgtPassword" NavigateUrl="#" runat="server" Text="Forgot your password?"
                                                    Font-Names="Verdana" Font-Size="X-Small"></asp:HyperLink></font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="btnLogin" runat="server" Font-Size="Small" Text="Login" Width="86px"
                                                TabIndex="4" Font-Names="Verdana" onclick="btnLogin_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                </td>
            </tr>
        </table>
        <table width="100%" border="0">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            
            <tr height="20">
                <td align="center" style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px;">
                    Copyright © 2011-12 Technosoft. All Rights Reserved.
                </td>
            </tr>
        </table>
    
    </form>
    
</body>

</html>
