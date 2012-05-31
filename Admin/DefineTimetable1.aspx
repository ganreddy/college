 <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefineTimetable1.aspx.cs" Inherits="Admin_DefineTimetable1" Title="Define TimeTable" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>
     <script type="text/javascript" language="javascript">
         function validation() {
             if (!DropdownValidate('<%=ddlDays.ClientID%>', "Please Select Day")) return false;
             if (!DropdownValidate('<%=ddlPeriods.ClientID%>', "Please Select Periods")) return false;
             if (!DropdownValidate('<%=ddlTeacher.ClientID%>', "Please Select Teacher")) return false;   
                        if(! DropdownValidate('<%=ddlClass.ClientID%>',"Please Select Class"))return false;
                       
                        if(! DropdownValidate('<%=ddlSection.ClientID%>',"Please Select Section"))return false;
                        if (!DropdownValidate('<%=ddlSubject.ClientID%>', "Please Select Subject")) return false;
                        if (!DropdownValidate('<%=ddlYear.ClientID%>', "Please Select Year")) return false;
    }
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
    <ContentTemplate>
    <table style="height: 100%; width: 80%" align="center"> 
        <tr>
             <td width="80%" align="center">
                <table width="80%" align="center">
                    <tr>
                        <td colspan="2" class="heading"  style="text-align: center">
                            Class Wise Time Table</td>
                    </tr>
                    <tr>
                        <td style="height: 26px" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 27px" class="subhead">
                            Days<span style="color: #ff0000">*</span></td>
                        <td >
                            <asp:DropDownList ID="ddlDays" runat="server"  Width="154px">
                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem> 
                            <asp:ListItem Value="2">2</asp:ListItem> 
                            <asp:ListItem Value="3">3</asp:ListItem> 
                             <asp:ListItem Value="4">4</asp:ListItem> 
                               <asp:ListItem Value="5">5</asp:ListItem> 
                               <asp:ListItem Value="6">6</asp:ListItem> 
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td  class="subhead">
                            Periods<span style="color: #ff0000">*</span></td>
                        <td >
                            <asp:DropDownList ID="ddlPeriods" runat="server" AutoPostBack="True"  Width="154px"
                                onselectedindexchanged="ddlPeriods_SelectedIndexChanged" >
                           
                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem> 
                            <asp:ListItem Value="2">2</asp:ListItem> 
                            <asp:ListItem Value="3">3</asp:ListItem> 
                             <asp:ListItem Value="4">4</asp:ListItem> 
                               <asp:ListItem Value="5">5</asp:ListItem> 
                               <asp:ListItem Value="6">6</asp:ListItem>
                               
                            <asp:ListItem Value="7">7</asp:ListItem> 
                            <asp:ListItem Value="8">8</asp:ListItem> 
                            <asp:ListItem Value="9">9</asp:ListItem> 
                             <asp:ListItem Value="10">10</asp:ListItem> 
                               <asp:ListItem Value="11">11</asp:ListItem> 
                               <asp:ListItem Value="12">12</asp:ListItem>
                               
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 27px" class="subhead">
                            Teacher<span style="color: #ff0000">*</span>
                        </td>
                        <td style="height: 27px">
                            <asp:DropDownList ID="ddlTeacher" runat="server"  Width="154px"
                                onselectedindexchanged="ddlTeacher_SelectedIndexChanged">
                            
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 24px" class="subhead">
                            Class<span style="color: #ff0000">*</span>
                        </td>
                        <td style="height: 24px">
                            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True"  Width="154px"
                                onselectedindexchanged="ddlClass_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Section<span style="color: #ff0000">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSection" runat="server"  Width="154px"
                                onselectedindexchanged="ddlSection_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Subject<span style="color: #ff0000">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubject" runat="server"  Width="154px"
                                onselectedindexchanged="ddlSubject_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead">
                            Year<span style="color: #ff0000">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlYear" runat="server"  Width="154px"
                                onselectedindexchanged="ddlYear_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                            <asp:ListItem Value="1">2011</asp:ListItem>
                            <asp:ListItem Value="2">2012</asp:ListItem>
                             <asp:ListItem Value="3">2013</asp:ListItem>
                              <asp:ListItem Value="4">2014</asp:ListItem>
                               <asp:ListItem Value="5">2015</asp:ListItem>
                                <asp:ListItem Value="6">2016</asp:ListItem>
                                 <asp:ListItem Value="7">2017</asp:ListItem>
                                 <asp:ListItem Value="8">2018</asp:ListItem>

                                 <asp:ListItem Value="9">2019</asp:ListItem>
                                 
                                 <asp:ListItem Value="10">2020</asp:ListItem>
                                <asp:ListItem Value="11">2021</asp:ListItem>
                                 <asp:ListItem Value="12">2022</asp:ListItem>
                                  <asp:ListItem Value="13">2023</asp:ListItem>
                                   <asp:ListItem Value="14">2024</asp:ListItem>
                                    <asp:ListItem Value="15">2025</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                           
                            <asp:GridView ID="Gv" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC">
                             <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle  Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                <Columns> 
                  
                
                  
                    </Columns> 
                </asp:GridView>
                           
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 23px">
                           
                           
                           
                        </td>
                        <td style="height: 23px">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text="Label"></asp:Label>
                           
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <table><tr><td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add" 
                                Width="70px" /></td></tr></table></td>
                    </tr>
                </table>
            </td>
            
        </tr>
    </table>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

